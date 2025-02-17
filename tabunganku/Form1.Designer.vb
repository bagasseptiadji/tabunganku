<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        dgvRiwayat = New DataGridView()
        lblSaldo = New Label()
        txtJumlah = New TextBox()
        btnTambah = New Button()
        btnRefresh = New Button()
        ofdBukaFile = New OpenFileDialog()
        btnHapus = New Button()
        txtKeterangan = New TextBox()
        lblInput = New Label()
        lblKeterangan = New Label()
        Label2 = New Label()
        Label1 = New Label()
        GroupBox1 = New GroupBox()
        lblFileName = New Label()
        Label7 = New Label()
        Label5 = New Label()
        Label6 = New Label()
        cmbTransaksi = New ComboBox()
        btnInfo = New Button()
        btnFilter = New Button()
        Label3 = New Label()
        txtFilter = New TextBox()
        Label4 = New Label()
        btnBuatBaru = New Button()
        btnBukaFile = New Button()
        SaveFileDialog = New SaveFileDialog()
        CType(dgvRiwayat, ComponentModel.ISupportInitialize).BeginInit()
        GroupBox1.SuspendLayout()
        SuspendLayout()
        ' 
        ' dgvRiwayat
        ' 
        dgvRiwayat.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvRiwayat.Location = New Point(23, 30)
        dgvRiwayat.Name = "dgvRiwayat"
        dgvRiwayat.RowHeadersWidth = 62
        dgvRiwayat.Size = New Size(813, 225)
        dgvRiwayat.TabIndex = 0
        ' 
        ' lblSaldo
        ' 
        lblSaldo.AutoSize = True
        lblSaldo.Font = New Font("Segoe UI", 15F)
        lblSaldo.Location = New Point(859, 102)
        lblSaldo.Name = "lblSaldo"
        lblSaldo.Size = New Size(0, 41)
        lblSaldo.TabIndex = 1
        ' 
        ' txtJumlah
        ' 
        txtJumlah.Location = New Point(164, 319)
        txtJumlah.Name = "txtJumlah"
        txtJumlah.Size = New Size(206, 31)
        txtJumlah.TabIndex = 2
        ' 
        ' btnTambah
        ' 
        btnTambah.Location = New Point(33, 433)
        btnTambah.Name = "btnTambah"
        btnTambah.Size = New Size(99, 66)
        btnTambah.TabIndex = 3
        btnTambah.Text = "Tambah"
        btnTambah.UseVisualStyleBackColor = True
        ' 
        ' btnRefresh
        ' 
        btnRefresh.Location = New Point(271, 433)
        btnRefresh.Name = "btnRefresh"
        btnRefresh.Size = New Size(99, 66)
        btnRefresh.TabIndex = 5
        btnRefresh.Text = "Refresh Data"
        btnRefresh.UseVisualStyleBackColor = True
        ' 
        ' ofdBukaFile
        ' 
        ofdBukaFile.FileName = "OpenFileDialog1"
        ' 
        ' btnHapus
        ' 
        btnHapus.Location = New Point(152, 433)
        btnHapus.Name = "btnHapus"
        btnHapus.Size = New Size(99, 66)
        btnHapus.TabIndex = 8
        btnHapus.Text = "Hapus"
        btnHapus.UseVisualStyleBackColor = True
        ' 
        ' txtKeterangan
        ' 
        txtKeterangan.Location = New Point(164, 377)
        txtKeterangan.Name = "txtKeterangan"
        txtKeterangan.Size = New Size(206, 31)
        txtKeterangan.TabIndex = 9
        ' 
        ' lblInput
        ' 
        lblInput.AutoSize = True
        lblInput.Location = New Point(26, 319)
        lblInput.Name = "lblInput"
        lblInput.Size = New Size(114, 25)
        lblInput.TabIndex = 10
        lblInput.Text = "Input Jumlah"
        ' 
        ' lblKeterangan
        ' 
        lblKeterangan.AutoSize = True
        lblKeterangan.Location = New Point(26, 377)
        lblKeterangan.Name = "lblKeterangan"
        lblKeterangan.Size = New Size(106, 25)
        lblKeterangan.TabIndex = 11
        lblKeterangan.Text = "Keterangan "
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(142, 319)
        Label2.Name = "Label2"
        Label2.Size = New Size(16, 25)
        Label2.TabIndex = 12
        Label2.Text = ":"
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(142, 377)
        Label1.Name = "Label1"
        Label1.Size = New Size(16, 25)
        Label1.TabIndex = 13
        Label1.Text = ":"
        ' 
        ' GroupBox1
        ' 
        GroupBox1.Controls.Add(lblFileName)
        GroupBox1.Controls.Add(Label7)
        GroupBox1.Controls.Add(Label5)
        GroupBox1.Controls.Add(Label6)
        GroupBox1.Controls.Add(cmbTransaksi)
        GroupBox1.Controls.Add(btnInfo)
        GroupBox1.Controls.Add(btnFilter)
        GroupBox1.Controls.Add(Label3)
        GroupBox1.Controls.Add(txtFilter)
        GroupBox1.Controls.Add(Label4)
        GroupBox1.Controls.Add(btnBuatBaru)
        GroupBox1.Controls.Add(btnBukaFile)
        GroupBox1.Controls.Add(dgvRiwayat)
        GroupBox1.Controls.Add(Label1)
        GroupBox1.Controls.Add(lblSaldo)
        GroupBox1.Controls.Add(btnRefresh)
        GroupBox1.Controls.Add(Label2)
        GroupBox1.Controls.Add(txtJumlah)
        GroupBox1.Controls.Add(lblKeterangan)
        GroupBox1.Controls.Add(btnTambah)
        GroupBox1.Controls.Add(lblInput)
        GroupBox1.Controls.Add(btnHapus)
        GroupBox1.Controls.Add(txtKeterangan)
        GroupBox1.Location = New Point(24, 12)
        GroupBox1.Name = "GroupBox1"
        GroupBox1.Size = New Size(1096, 525)
        GroupBox1.TabIndex = 14
        GroupBox1.TabStop = False
        GroupBox1.Text = "Tabunganku"
        ' 
        ' lblFileName
        ' 
        lblFileName.AutoSize = True
        lblFileName.Font = New Font("Segoe UI", 9F)
        lblFileName.Location = New Point(859, 35)
        lblFileName.Name = "lblFileName"
        lblFileName.Size = New Size(0, 25)
        lblFileName.TabIndex = 25
        ' 
        ' Label7
        ' 
        Label7.AutoSize = True
        Label7.Font = New Font("Segoe UI", 9F)
        Label7.Location = New Point(859, 70)
        Label7.Name = "Label7"
        Label7.Size = New Size(135, 25)
        Label7.TabIndex = 24
        Label7.Text = "Total Tabungan:"
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Location = New Point(142, 273)
        Label5.Name = "Label5"
        Label5.Size = New Size(16, 25)
        Label5.TabIndex = 23
        Label5.Text = ":"
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Location = New Point(26, 273)
        Label6.Name = "Label6"
        Label6.Size = New Size(63, 25)
        Label6.TabIndex = 22
        Label6.Text = "Pilihan"
        ' 
        ' cmbTransaksi
        ' 
        cmbTransaksi.FormattingEnabled = True
        cmbTransaksi.Items.AddRange(New Object() {"Menabung", "Penarikan"})
        cmbTransaksi.Location = New Point(164, 270)
        cmbTransaksi.Name = "cmbTransaksi"
        cmbTransaksi.Size = New Size(206, 33)
        cmbTransaksi.TabIndex = 21
        ' 
        ' btnInfo
        ' 
        btnInfo.Location = New Point(737, 433)
        btnInfo.Name = "btnInfo"
        btnInfo.Size = New Size(99, 66)
        btnInfo.TabIndex = 20
        btnInfo.Text = "Info (?)"
        btnInfo.UseVisualStyleBackColor = True
        ' 
        ' btnFilter
        ' 
        btnFilter.Location = New Point(728, 273)
        btnFilter.Name = "btnFilter"
        btnFilter.Size = New Size(110, 31)
        btnFilter.TabIndex = 19
        btnFilter.Text = "Cari Data"
        btnFilter.UseVisualStyleBackColor = True
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Location = New Point(496, 273)
        Label3.Name = "Label3"
        Label3.Size = New Size(16, 25)
        Label3.TabIndex = 18
        Label3.Text = ":"
        ' 
        ' txtFilter
        ' 
        txtFilter.Location = New Point(518, 273)
        txtFilter.Name = "txtFilter"
        txtFilter.Size = New Size(191, 31)
        txtFilter.TabIndex = 16
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Location = New Point(391, 273)
        Label4.Name = "Label4"
        Label4.Size = New Size(84, 25)
        Label4.TabIndex = 17
        Label4.Text = "Cari Data"
        ' 
        ' btnBuatBaru
        ' 
        btnBuatBaru.Location = New Point(619, 433)
        btnBuatBaru.Name = "btnBuatBaru"
        btnBuatBaru.Size = New Size(99, 66)
        btnBuatBaru.TabIndex = 15
        btnBuatBaru.Text = "Data Baru"
        btnBuatBaru.UseVisualStyleBackColor = True
        ' 
        ' btnBukaFile
        ' 
        btnBukaFile.Location = New Point(505, 433)
        btnBukaFile.Name = "btnBukaFile"
        btnBukaFile.Size = New Size(99, 66)
        btnBukaFile.TabIndex = 14
        btnBukaFile.Text = "Buka File"
        btnBukaFile.UseVisualStyleBackColor = True
        ' 
        ' Form1
        ' 
        AutoScaleDimensions = New SizeF(10F, 25F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1148, 564)
        Controls.Add(GroupBox1)
        Name = "Form1"
        Text = "Aplikasi Tabunganku"
        CType(dgvRiwayat, ComponentModel.ISupportInitialize).EndInit()
        GroupBox1.ResumeLayout(False)
        GroupBox1.PerformLayout()
        ResumeLayout(False)
    End Sub

    Friend WithEvents dgvRiwayat As DataGridView
    Friend WithEvents lblSaldo As Label
    Friend WithEvents txtJumlah As TextBox
    Friend WithEvents btnTambah As Button
    Friend WithEvents btnRefresh As Button
    Friend WithEvents ofdBukaFile As OpenFileDialog
    Friend WithEvents btnHapus As Button
    Friend WithEvents txtKeterangan As TextBox
    Friend WithEvents lblInput As Label
    Friend WithEvents lblKeterangan As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents btnBukaFile As Button
    Friend WithEvents btnBuatBaru As Button
    Friend WithEvents SaveFileDialog As SaveFileDialog
    Friend WithEvents btnFilter As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents txtFilter As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents btnInfo As Button
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents cmbTransaksi As ComboBox
    Friend WithEvents Label7 As Label
    Friend WithEvents lblFileName As Label

End Class
