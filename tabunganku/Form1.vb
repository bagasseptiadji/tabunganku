Imports System.IO

Public Class Form1
    ' Variabel saldo untuk menyimpan total saldo tabungan
    Dim saldo As Decimal = 0
    ' Path ke file CSV tempat menyimpan data tabungan
    Dim filePath As String = ""

    ' Inisialisasi DataGridView saat form dimuat
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Fokus awal pada ComboBox, memilih "Menabung"
        cmbTransaksi.SelectedItem = "Menabung"

        ' Menambahkan kolom pada DataGridView jika belum ada
        If dgvRiwayat.Columns.Count = 0 Then
            dgvRiwayat.Columns.Add("Tanggal", "Tanggal")
            dgvRiwayat.Columns.Add("Jumlah", "Jumlah (Rp)")
            dgvRiwayat.Columns.Add("Keterangan", "Keterangan")
        End If
    End Sub

    ' Menambahkan tabungan ke file CSV
    ' Menambahkan tabungan ke file CSV
    Private Sub btnTambah_Click(sender As Object, e As EventArgs) Handles btnTambah.Click
        Dim jumlah As Decimal
        Dim keterangan As String = txtKeterangan.Text.Trim()

        ' Validasi jika input jumlah adalah angka yang valid dan lebih besar dari 0
        If Decimal.TryParse(txtJumlah.Text, jumlah) AndAlso jumlah > 0 Then
            ' Cek jenis transaksi yang dipilih (Menabung atau Penarikan)
            If cmbTransaksi.SelectedItem = "Menabung" Then
                saldo += jumlah
                keterangan = "Menabung: " & keterangan ' Tambahkan keterangan untuk menabung
            ElseIf cmbTransaksi.SelectedItem = "Penarikan" Then
                ' Cek apakah saldo mencukupi untuk penarikan
                If saldo >= jumlah Then
                    saldo -= jumlah
                    keterangan = "Penarikan: " & keterangan ' Tambahkan keterangan untuk penarikan
                Else
                    MessageBox.Show("Saldo tidak cukup untuk melakukan penarikan!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Return ' Jika saldo tidak cukup, proses dihentikan
                End If
            Else
                MessageBox.Show("Pilih jenis transaksi (Menabung/Penarikan) terlebih dahulu!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return ' Jika jenis transaksi belum dipilih, proses dihentikan
            End If

            ' Menambahkan riwayat transaksi ke DataGridView
            dgvRiwayat.Rows.Add(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), jumlah.ToString("N0"), keterangan)
            ' Update label saldo
            lblSaldo.Text = "Rp " & saldo.ToString("N0")
            ' Tampilkan pesan sukses
            MessageBox.Show("Transaksi berhasil!", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information)
            ' Kosongkan input
            txtJumlah.Clear()
            txtKeterangan.Clear()

            ' Tanyakan apakah ingin menyimpan file
            If String.IsNullOrEmpty(filePath) Then
                ' Jika filePath kosong, minta pengguna memilih file untuk menyimpan
                Dim result As DialogResult = MessageBox.Show("Apakah Anda ingin menyimpan file tabungan?", "Simpan File", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                If result = DialogResult.Yes Then
                    btnBuatBaru_Click(sender, e) ' Panggil fungsi untuk membuat file baru jika belum ada
                Else
                    ' Menampilkan popup jika memilih No
                    MessageBox.Show("Data tidak tersimpan!", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            Else
                ' Simpan data jika file sudah ada
                SimpanData(jumlah, keterangan)
            End If
        Else
            MessageBox.Show("Masukkan jumlah yang valid!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub


    ' Prosedur untuk menyimpan data transaksi ke file CSV
    Private Sub SimpanData(jumlah As Decimal, keterangan As String)
        Dim isNewFile As Boolean = Not File.Exists(filePath)

        ' Menulis data ke file CSV
        Using writer As StreamWriter = New StreamWriter(filePath, True)
            ' Jika file baru, tambahkan header
            If isNewFile Then writer.WriteLine("Tanggal,Jumlah (Rp),Keterangan")
            ' Menulis transaksi ke file
            writer.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") & "," & jumlah & "," & keterangan)
        End Using
    End Sub

    ' Membaca dan menampilkan data dari file CSV
    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        BacaData()
    End Sub

    ' Prosedur untuk membaca dan menampilkan data dari file CSV
    ' Membaca dan menampilkan data dari file CSV
    Private Sub BacaData(Optional customFilePath As String = "")
        Dim targetFile As String = If(String.IsNullOrEmpty(customFilePath), filePath, customFilePath)

        ' Cek apakah file ada
        If Not File.Exists(targetFile) Then
            MessageBox.Show("File tidak ditemukan!", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        ' Cek apakah file kosong
        If New FileInfo(targetFile).Length = 0 Then
            MessageBox.Show("File kosong, tidak ada data untuk ditampilkan.", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        dgvRiwayat.Rows.Clear()
        saldo = 0  ' Reset saldo sebelum membaca file baru

        ' Membaca data dari file CSV
        Using reader As New StreamReader(targetFile)
            Dim headerSkipped As Boolean = False

            While Not reader.EndOfStream
                Dim line As String = reader.ReadLine()
                Dim data As String() = line.Split(","c)

                ' Lewati baris pertama jika itu header
                If Not headerSkipped Then
                    headerSkipped = True
                    Continue While
                End If

                ' Pastikan data memiliki format yang benar (Tanggal, Jumlah, Keterangan)
                If data.Length = 3 AndAlso IsNumeric(data(1)) Then
                    Dim jumlah As Decimal = Convert.ToDecimal(data(1))
                    Dim keterangan As String = data(2).Trim()

                    dgvRiwayat.Rows.Add(data(0), jumlah.ToString("N0"), keterangan)

                    ' Cek jenis transaksi: Jika "Menabung", tambah saldo; jika "Penarikan", kurangi saldo
                    If keterangan.StartsWith("Menabung") Then
                        saldo += jumlah
                    ElseIf keterangan.StartsWith("Penarikan") Then
                        saldo -= jumlah
                    End If
                End If
            End While
        End Using

        ' Update label saldo setelah membaca file
        lblSaldo.Text = "Rp " & saldo.ToString("N0")
    End Sub


    ' Membuka file CSV lain
    Private Sub btnBukaFile_Click(sender As Object, e As EventArgs) Handles btnBukaFile.Click
        Using openFileDialog As New OpenFileDialog()
            openFileDialog.Filter = "CSV Files (*.csv)|*.csv|All Files (*.*)|*.*"
            openFileDialog.Title = "Pilih File Tabungan"

            If openFileDialog.ShowDialog() = DialogResult.OK Then
                filePath = openFileDialog.FileName
                ' Menampilkan nama file di label
                lblFileName.Text = "File: " & Path.GetFileName(filePath)
                BacaData(filePath)
            End If
        End Using
    End Sub

    ' Membuat file tabungan baru
    Private Sub btnBuatBaru_Click(sender As Object, e As EventArgs) Handles btnBuatBaru.Click
        Using saveFileDialog As New SaveFileDialog()
            saveFileDialog.Filter = "CSV Files (*.csv)|*.csv|All Files (*.*)|*.*"
            saveFileDialog.Title = "Buat File Tabungan Baru"

            If saveFileDialog.ShowDialog() = DialogResult.OK Then
                filePath = saveFileDialog.FileName
                ' Menulis header CSV jika file baru
                File.WriteAllText(filePath, "Tanggal,Jumlah (Rp),Keterangan" & Environment.NewLine)
                dgvRiwayat.Rows.Clear()
                saldo = 0
                lblSaldo.Text = "Rp 0"
                MessageBox.Show("File tabungan baru berhasil dibuat!", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End Using
        lblFileName.Text = "File: " & Path.GetFileName(filePath)

    End Sub

    ' Menghapus baris yang dipilih di DataGridView dan memperbarui file CSV
    Private Sub btnHapus_Click(sender As Object, e As EventArgs) Handles btnHapus.Click
        If dgvRiwayat.SelectedRows.Count > 0 Then
            Dim result As DialogResult = MessageBox.Show("Apakah Anda yakin ingin menghapus data yang dipilih?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
            If result = DialogResult.Yes Then
                For Each row As DataGridViewRow In dgvRiwayat.SelectedRows.Cast(Of DataGridViewRow).ToArray()
                    If Not row.IsNewRow Then
                        dgvRiwayat.Rows.Remove(row) ' Menghapus baris yang dipilih
                    End If
                Next
                SimpanUlangCSV()
                MessageBox.Show("Data berhasil dihapus!", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information)
                BacaData() ' Memperbarui data setelah penghapusan
            End If
        Else
            MessageBox.Show("Pilih data yang ingin dihapus!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    ' Prosedur menyimpan ulang CSV setelah penghapusan data
    Private Sub SimpanUlangCSV()
        Using writer As StreamWriter = New StreamWriter(filePath, False)
            writer.WriteLine("Tanggal,Jumlah (Rp),Keterangan") ' Menulis ulang header
            For Each row As DataGridViewRow In dgvRiwayat.Rows
                If Not row.IsNewRow Then
                    writer.WriteLine(row.Cells(0).Value.ToString() & "," & row.Cells(1).Value.ToString() & "," & row.Cells(2).Value.ToString())
                End If
            Next
        End Using
    End Sub

    ' Filter data berdasarkan semua kolom
    Private Sub btnFilter_Click(sender As Object, e As EventArgs) Handles btnFilter.Click
        Dim keyword As String = txtFilter.Text.Trim().ToLower()
        For Each row As DataGridViewRow In dgvRiwayat.Rows
            If Not row.IsNewRow Then
                Dim rowData As String = row.Cells(0).Value.ToString().ToLower() & " " & row.Cells(1).Value.ToString().ToLower() & " " & row.Cells(2).Value.ToString().ToLower()
                row.Visible = rowData.Contains(keyword) ' Menyembunyikan baris yang tidak sesuai dengan keyword
            End If
        Next
    End Sub

    ' Pop-up panduan penggunaan aplikasi
    Private Sub btnInfo_Click(sender As Object, e As EventArgs) Handles btnInfo.Click
        Dim panduan As String = "Panduan Penggunaan Aplikasi Tabunganku:" & vbCrLf & vbCrLf &
                            "1. Pilih jenis transaksi (Menabung/Penarikan) pada menu pilihan." & vbCrLf &
                            "2. Masukkan jumlah tabungan dan keterangan, lalu klik 'Tambah'." & vbCrLf &
                            "   - Jika memilih 'Menabung', jumlah akan ditambahkan ke saldo." & vbCrLf &
                            "   - Jika memilih 'Penarikan', jumlah akan dikurangi dari saldo, asalkan saldo cukup." & vbCrLf &
                            "3. Pilih data lalu klik 'Hapus' untuk menghapus tabungan." & vbCrLf &
                            "4. Gunakan 'Buka File' untuk membuka data tabungan lain." & vbCrLf &
                            "5. Klik 'Buat Baru' untuk membuat file tabungan baru." & vbCrLf &
                            "6. Gunakan fitur filter untuk mencari data lebih cepat."

        MessageBox.Show(panduan, "Panduan Penggunaan", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    ' Menyimpan perubahan data ketika edit sel di DataGridView
    Private Sub dgvRiwayat_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dgvRiwayat.CellEndEdit
        SimpanUlangCSV() ' Menyimpan data setelah perubahan di DataGridView
    End Sub

    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs) Handles GroupBox1.Enter

    End Sub
End Class
