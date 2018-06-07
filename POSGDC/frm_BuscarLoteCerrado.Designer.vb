<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frm_BuscarLoteCerrado
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
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
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.RadioButton2 = New System.Windows.Forms.RadioButton()
        Me.RadioButton1 = New System.Windows.Forms.RadioButton()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnbuscar = New System.Windows.Forms.Button()
        Me.dtpfechafinal = New System.Windows.Forms.DateTimePicker()
        Me.dtpfechainicial = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.dgvlotescerrados = New System.Windows.Forms.DataGridView()
        Me.id_lote = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Fecha = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Monto_Inicial = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btnaceptar = New System.Windows.Forms.Button()
        Me.btncancelar = New System.Windows.Forms.Button()
        Me.PrintDocument1 = New System.Drawing.Printing.PrintDocument()
        Me.PrintDialog1 = New System.Windows.Forms.PrintDialog()
        Me.lblnumeroloteimp = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.dgvlotescerrados, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.RadioButton2)
        Me.Panel1.Controls.Add(Me.RadioButton1)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.btnbuscar)
        Me.Panel1.Controls.Add(Me.dtpfechafinal)
        Me.Panel1.Controls.Add(Me.dtpfechainicial)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Location = New System.Drawing.Point(10, 12)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(835, 163)
        Me.Panel1.TabIndex = 0
        '
        'RadioButton2
        '
        Me.RadioButton2.AutoSize = True
        Me.RadioButton2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold)
        Me.RadioButton2.Location = New System.Drawing.Point(388, 20)
        Me.RadioButton2.Name = "RadioButton2"
        Me.RadioButton2.Size = New System.Drawing.Size(119, 29)
        Me.RadioButton2.TabIndex = 9
        Me.RadioButton2.TabStop = True
        Me.RadioButton2.Text = "Preventa"
        Me.RadioButton2.UseVisualStyleBackColor = True
        '
        'RadioButton1
        '
        Me.RadioButton1.AutoSize = True
        Me.RadioButton1.Checked = True
        Me.RadioButton1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold)
        Me.RadioButton1.Location = New System.Drawing.Point(182, 20)
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.Size = New System.Drawing.Size(164, 29)
        Me.RadioButton1.TabIndex = 8
        Me.RadioButton1.TabStop = True
        Me.RadioButton1.Text = "Venta Normal"
        Me.RadioButton1.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label3.Location = New System.Drawing.Point(10, 15)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(166, 34)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Tipo Lote: "
        '
        'btnbuscar
        '
        Me.btnbuscar.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold)
        Me.btnbuscar.Image = Global.POSGDC.My.Resources.Resources.lens
        Me.btnbuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnbuscar.Location = New System.Drawing.Point(641, 61)
        Me.btnbuscar.Name = "btnbuscar"
        Me.btnbuscar.Size = New System.Drawing.Size(146, 74)
        Me.btnbuscar.TabIndex = 6
        Me.btnbuscar.Text = "Buscar"
        Me.btnbuscar.UseVisualStyleBackColor = True
        '
        'dtpfechafinal
        '
        Me.dtpfechafinal.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpfechafinal.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold)
        Me.dtpfechafinal.Location = New System.Drawing.Point(182, 105)
        Me.dtpfechafinal.Name = "dtpfechafinal"
        Me.dtpfechafinal.Size = New System.Drawing.Size(389, 30)
        Me.dtpfechafinal.TabIndex = 5
        '
        'dtpfechainicial
        '
        Me.dtpfechainicial.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpfechainicial.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold)
        Me.dtpfechainicial.Location = New System.Drawing.Point(182, 60)
        Me.dtpfechainicial.Name = "dtpfechainicial"
        Me.dtpfechainicial.Size = New System.Drawing.Size(389, 30)
        Me.dtpfechainicial.TabIndex = 4
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label2.Location = New System.Drawing.Point(10, 103)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(166, 36)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Fecha Final:"
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label1.Location = New System.Drawing.Point(10, 58)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(166, 34)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Fecha Inicial:"
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.dgvlotescerrados)
        Me.Panel2.Location = New System.Drawing.Point(10, 181)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(833, 391)
        Me.Panel2.TabIndex = 1
        '
        'dgvlotescerrados
        '
        Me.dgvlotescerrados.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvlotescerrados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvlotescerrados.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.id_lote, Me.Fecha, Me.Monto_Inicial})
        Me.dgvlotescerrados.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvlotescerrados.Location = New System.Drawing.Point(0, 0)
        Me.dgvlotescerrados.Name = "dgvlotescerrados"
        Me.dgvlotescerrados.RowTemplate.Height = 24
        Me.dgvlotescerrados.Size = New System.Drawing.Size(833, 391)
        Me.dgvlotescerrados.TabIndex = 1
        '
        'id_lote
        '
        Me.id_lote.HeaderText = "Id Lote"
        Me.id_lote.Name = "id_lote"
        Me.id_lote.ReadOnly = True
        '
        'Fecha
        '
        Me.Fecha.HeaderText = "Fecha"
        Me.Fecha.Name = "Fecha"
        Me.Fecha.ReadOnly = True
        '
        'Monto_Inicial
        '
        Me.Monto_Inicial.HeaderText = "Monto Inicial"
        Me.Monto_Inicial.Name = "Monto_Inicial"
        Me.Monto_Inicial.ReadOnly = True
        '
        'btnaceptar
        '
        Me.btnaceptar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnaceptar.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnaceptar.Image = Global.POSGDC.My.Resources.Resources.printer1
        Me.btnaceptar.Location = New System.Drawing.Point(530, 590)
        Me.btnaceptar.Margin = New System.Windows.Forms.Padding(4)
        Me.btnaceptar.Name = "btnaceptar"
        Me.btnaceptar.Size = New System.Drawing.Size(148, 119)
        Me.btnaceptar.TabIndex = 103
        Me.btnaceptar.Text = "Reimprimir"
        Me.btnaceptar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnaceptar.UseVisualStyleBackColor = True
        '
        'btncancelar
        '
        Me.btncancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btncancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btncancelar.Image = Global.POSGDC.My.Resources.Resources.cancel
        Me.btncancelar.Location = New System.Drawing.Point(707, 590)
        Me.btncancelar.Margin = New System.Windows.Forms.Padding(4)
        Me.btncancelar.Name = "btncancelar"
        Me.btncancelar.Size = New System.Drawing.Size(138, 119)
        Me.btncancelar.TabIndex = 104
        Me.btncancelar.Text = "Cancelar"
        Me.btncancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btncancelar.UseVisualStyleBackColor = True
        '
        'PrintDocument1
        '
        '
        'PrintDialog1
        '
        Me.PrintDialog1.UseEXDialog = True
        '
        'lblnumeroloteimp
        '
        Me.lblnumeroloteimp.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold)
        Me.lblnumeroloteimp.Location = New System.Drawing.Point(12, 590)
        Me.lblnumeroloteimp.Name = "lblnumeroloteimp"
        Me.lblnumeroloteimp.Size = New System.Drawing.Size(390, 34)
        Me.lblnumeroloteimp.TabIndex = 105
        Me.lblnumeroloteimp.Text = "Numero de Lote:"
        '
        'frm_BuscarLoteCerrado
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.ClientSize = New System.Drawing.Size(861, 722)
        Me.Controls.Add(Me.lblnumeroloteimp)
        Me.Controls.Add(Me.btnaceptar)
        Me.Controls.Add(Me.btncancelar)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frm_BuscarLoteCerrado"
        Me.Text = "Reimpresion Lote Cerrado"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        CType(Me.dgvlotescerrados, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents btnbuscar As Button
    Friend WithEvents dtpfechafinal As DateTimePicker
    Friend WithEvents dtpfechainicial As DateTimePicker
    Friend WithEvents Panel2 As Panel
    Friend WithEvents dgvlotescerrados As DataGridView
    Friend WithEvents btnaceptar As Button
    Friend WithEvents btncancelar As Button
    Friend WithEvents RadioButton2 As RadioButton
    Friend WithEvents RadioButton1 As RadioButton
    Friend WithEvents Label3 As Label
    Friend WithEvents id_lote As DataGridViewTextBoxColumn
    Friend WithEvents Fecha As DataGridViewTextBoxColumn
    Friend WithEvents Monto_Inicial As DataGridViewTextBoxColumn
    Friend WithEvents PrintDocument1 As Printing.PrintDocument
    Friend WithEvents PrintDialog1 As PrintDialog
    Friend WithEvents lblnumeroloteimp As Label
End Class
