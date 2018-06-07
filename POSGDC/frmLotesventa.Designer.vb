<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmlotesventa
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
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

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmlotesventa))
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Fecha = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MontoInicial = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btn_edit = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.lblalma = New System.Windows.Forms.Label()
        Me.lblusuario = New System.Windows.Forms.Label()
        Me.btncarga = New System.Windows.Forms.Button()
        Me.lblNUMLOTE = New System.Windows.Forms.Label()
        Me.lblMonto = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.chk_filtrofecha = New System.Windows.Forms.CheckBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.btn_buscarlotes = New System.Windows.Forms.Button()
        Me.dtp_fechafinal = New System.Windows.Forms.DateTimePicker()
        Me.dtp_fechainicial = New System.Windows.Forms.DateTimePicker()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.rdb_ventanormal = New System.Windows.Forms.RadioButton()
        Me.rdb_preventa = New System.Windows.Forms.RadioButton()
        Me.rdb_todos = New System.Windows.Forms.RadioButton()
        Me.lbltipoventa = New System.Windows.Forms.Label()
        Me.btn_lotescerrados = New System.Windows.Forms.Button()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Button3
        '
        Me.Button3.Enabled = False
        Me.Button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button3.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold)
        Me.Button3.Image = Global.POSGDC.My.Resources.Resources.close
        Me.Button3.Location = New System.Drawing.Point(1216, 453)
        Me.Button3.Margin = New System.Windows.Forms.Padding(4)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(235, 134)
        Me.Button3.TabIndex = 5
        Me.Button3.Text = "Cerrar Lote"
        Me.Button3.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold)
        Me.Button2.Image = Global.POSGDC.My.Resources.Resources.back
        Me.Button2.Location = New System.Drawing.Point(1216, 595)
        Me.Button2.Margin = New System.Windows.Forms.Padding(4)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(235, 134)
        Me.Button2.TabIndex = 3
        Me.Button2.Text = "Regresar"
        Me.Button2.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button2.UseVisualStyleBackColor = True
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.id, Me.Fecha, Me.MontoInicial, Me.btn_edit})
        Me.DataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.DataGridView1.Location = New System.Drawing.Point(11, 277)
        Me.DataGridView1.Margin = New System.Windows.Forms.Padding(4)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.RowTemplate.Height = 30
        Me.DataGridView1.Size = New System.Drawing.Size(1177, 292)
        Me.DataGridView1.TabIndex = 7
        '
        'id
        '
        Me.id.HeaderText = "Numero de Lote"
        Me.id.Name = "id"
        Me.id.ReadOnly = True
        '
        'Fecha
        '
        Me.Fecha.HeaderText = "Fecha"
        Me.Fecha.Name = "Fecha"
        Me.Fecha.ReadOnly = True
        '
        'MontoInicial
        '
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.MontoInicial.DefaultCellStyle = DataGridViewCellStyle1
        Me.MontoInicial.HeaderText = "Monto Inicial"
        Me.MontoInicial.Name = "MontoInicial"
        Me.MontoInicial.ReadOnly = True
        '
        'btn_edit
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.btn_edit.DefaultCellStyle = DataGridViewCellStyle2
        Me.btn_edit.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btn_edit.HeaderText = "Seleccionar"
        Me.btn_edit.Name = "btn_edit"
        Me.btn_edit.ReadOnly = True
        Me.btn_edit.Text = "Seleccionar"
        Me.btn_edit.UseColumnTextForButtonValue = True
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.POSGDC.My.Resources.Resources.Logo_Connect
        Me.PictureBox1.Location = New System.Drawing.Point(776, 15)
        Me.PictureBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(412, 95)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 8
        Me.PictureBox1.TabStop = False
        '
        'lblalma
        '
        Me.lblalma.AutoSize = True
        Me.lblalma.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblalma.Location = New System.Drawing.Point(16, 26)
        Me.lblalma.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblalma.Name = "lblalma"
        Me.lblalma.Size = New System.Drawing.Size(232, 25)
        Me.lblalma.TabIndex = 9
        Me.lblalma.Text = "Ventas generadas por:"
        '
        'lblusuario
        '
        Me.lblusuario.AutoSize = True
        Me.lblusuario.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblusuario.Location = New System.Drawing.Point(15, 74)
        Me.lblusuario.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblusuario.Name = "lblusuario"
        Me.lblusuario.Size = New System.Drawing.Size(197, 25)
        Me.lblusuario.TabIndex = 10
        Me.lblusuario.Text = "Almacen asignado:"
        '
        'btncarga
        '
        Me.btncarga.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btncarga.Enabled = False
        Me.btncarga.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btncarga.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold)
        Me.btncarga.Image = Global.POSGDC.My.Resources.Resources.loading
        Me.btncarga.Location = New System.Drawing.Point(1216, 168)
        Me.btncarga.Margin = New System.Windows.Forms.Padding(4)
        Me.btncarga.Name = "btncarga"
        Me.btncarga.Size = New System.Drawing.Size(235, 134)
        Me.btncarga.TabIndex = 3
        Me.btncarga.Text = "Cargar Lote"
        Me.btncarga.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btncarga.UseVisualStyleBackColor = True
        '
        'lblNUMLOTE
        '
        Me.lblNUMLOTE.AutoSize = True
        Me.lblNUMLOTE.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNUMLOTE.ForeColor = System.Drawing.Color.Red
        Me.lblNUMLOTE.Location = New System.Drawing.Point(13, 598)
        Me.lblNUMLOTE.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblNUMLOTE.Name = "lblNUMLOTE"
        Me.lblNUMLOTE.Size = New System.Drawing.Size(275, 29)
        Me.lblNUMLOTE.TabIndex = 11
        Me.lblNUMLOTE.Text = "Num. de lote de venta:"
        '
        'lblMonto
        '
        Me.lblMonto.AutoSize = True
        Me.lblMonto.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMonto.ForeColor = System.Drawing.Color.Red
        Me.lblMonto.Location = New System.Drawing.Point(841, 598)
        Me.lblMonto.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblMonto.Name = "lblMonto"
        Me.lblMonto.Size = New System.Drawing.Size(92, 29)
        Me.lblMonto.TabIndex = 12
        Me.lblMonto.Text = "Monto:"
        '
        'Button1
        '
        Me.Button1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Image = Global.POSGDC.My.Resources.Resources.cart
        Me.Button1.Location = New System.Drawing.Point(1216, 25)
        Me.Button1.Margin = New System.Windows.Forms.Padding(4)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(235, 135)
        Me.Button1.TabIndex = 13
        Me.Button1.Text = "Nuevo Lote"
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.chk_filtrofecha)
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Controls.Add(Me.rdb_ventanormal)
        Me.Panel1.Controls.Add(Me.rdb_preventa)
        Me.Panel1.Controls.Add(Me.rdb_todos)
        Me.Panel1.Location = New System.Drawing.Point(12, 117)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1176, 153)
        Me.Panel1.TabIndex = 14
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(596, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(87, 29)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "Filtros"
        '
        'chk_filtrofecha
        '
        Me.chk_filtrofecha.AutoSize = True
        Me.chk_filtrofecha.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chk_filtrofecha.Location = New System.Drawing.Point(20, 108)
        Me.chk_filtrofecha.Name = "chk_filtrofecha"
        Me.chk_filtrofecha.Size = New System.Drawing.Size(167, 24)
        Me.chk_filtrofecha.TabIndex = 6
        Me.chk_filtrofecha.Text = "Filtrar por fecha"
        Me.chk_filtrofecha.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.btn_buscarlotes)
        Me.Panel2.Controls.Add(Me.dtp_fechafinal)
        Me.Panel2.Controls.Add(Me.dtp_fechainicial)
        Me.Panel2.Controls.Add(Me.Label3)
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Location = New System.Drawing.Point(255, 77)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(860, 71)
        Me.Panel2.TabIndex = 5
        '
        'btn_buscarlotes
        '
        Me.btn_buscarlotes.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_buscarlotes.Image = Global.POSGDC.My.Resources.Resources.lens
        Me.btn_buscarlotes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_buscarlotes.Location = New System.Drawing.Point(632, 10)
        Me.btn_buscarlotes.Name = "btn_buscarlotes"
        Me.btn_buscarlotes.Size = New System.Drawing.Size(204, 52)
        Me.btn_buscarlotes.TabIndex = 8
        Me.btn_buscarlotes.Text = "Buscar Lotes"
        Me.btn_buscarlotes.UseVisualStyleBackColor = True
        '
        'dtp_fechafinal
        '
        Me.dtp_fechafinal.CustomFormat = ""
        Me.dtp_fechafinal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_fechafinal.Location = New System.Drawing.Point(330, 39)
        Me.dtp_fechafinal.Name = "dtp_fechafinal"
        Me.dtp_fechafinal.Size = New System.Drawing.Size(277, 24)
        Me.dtp_fechafinal.TabIndex = 7
        Me.dtp_fechafinal.Value = New Date(2018, 4, 12, 0, 0, 0, 0)
        '
        'dtp_fechainicial
        '
        Me.dtp_fechainicial.CustomFormat = ""
        Me.dtp_fechainicial.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_fechainicial.Location = New System.Drawing.Point(34, 39)
        Me.dtp_fechainicial.Name = "dtp_fechainicial"
        Me.dtp_fechainicial.Size = New System.Drawing.Size(277, 24)
        Me.dtp_fechainicial.TabIndex = 6
        Me.dtp_fechainicial.Value = New Date(2018, 4, 12, 0, 0, 0, 0)
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(336, 16)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(107, 20)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Fecha Final"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(30, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(116, 20)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Fecha Inicial"
        '
        'rdb_ventanormal
        '
        Me.rdb_ventanormal.AutoSize = True
        Me.rdb_ventanormal.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdb_ventanormal.Location = New System.Drawing.Point(20, 80)
        Me.rdb_ventanormal.Name = "rdb_ventanormal"
        Me.rdb_ventanormal.Size = New System.Drawing.Size(144, 24)
        Me.rdb_ventanormal.TabIndex = 2
        Me.rdb_ventanormal.TabStop = True
        Me.rdb_ventanormal.Text = "Venta Normal"
        Me.rdb_ventanormal.UseVisualStyleBackColor = True
        '
        'rdb_preventa
        '
        Me.rdb_preventa.AutoSize = True
        Me.rdb_preventa.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdb_preventa.Location = New System.Drawing.Point(20, 50)
        Me.rdb_preventa.Name = "rdb_preventa"
        Me.rdb_preventa.Size = New System.Drawing.Size(104, 24)
        Me.rdb_preventa.TabIndex = 1
        Me.rdb_preventa.TabStop = True
        Me.rdb_preventa.Text = "Preventa"
        Me.rdb_preventa.UseVisualStyleBackColor = True
        '
        'rdb_todos
        '
        Me.rdb_todos.AutoSize = True
        Me.rdb_todos.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdb_todos.Location = New System.Drawing.Point(20, 20)
        Me.rdb_todos.Name = "rdb_todos"
        Me.rdb_todos.Size = New System.Drawing.Size(81, 24)
        Me.rdb_todos.TabIndex = 0
        Me.rdb_todos.TabStop = True
        Me.rdb_todos.Text = "Todos"
        Me.rdb_todos.UseVisualStyleBackColor = True
        '
        'lbltipoventa
        '
        Me.lbltipoventa.AutoSize = True
        Me.lbltipoventa.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold)
        Me.lbltipoventa.ForeColor = System.Drawing.Color.Red
        Me.lbltipoventa.Location = New System.Drawing.Point(521, 598)
        Me.lbltipoventa.Name = "lbltipoventa"
        Me.lbltipoventa.Size = New System.Drawing.Size(71, 29)
        Me.lbltipoventa.TabIndex = 15
        Me.lbltipoventa.Text = "Lote:"
        '
        'btn_lotescerrados
        '
        Me.btn_lotescerrados.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_lotescerrados.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_lotescerrados.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_lotescerrados.Image = Global.POSGDC.My.Resources.Resources.closesing
        Me.btn_lotescerrados.Location = New System.Drawing.Point(1216, 310)
        Me.btn_lotescerrados.Margin = New System.Windows.Forms.Padding(4)
        Me.btn_lotescerrados.Name = "btn_lotescerrados"
        Me.btn_lotescerrados.Size = New System.Drawing.Size(235, 135)
        Me.btn_lotescerrados.TabIndex = 16
        Me.btn_lotescerrados.Text = "Lotes Cerrados"
        Me.btn_lotescerrados.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_lotescerrados.UseVisualStyleBackColor = True
        '
        'frmlotesventa
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1616, 783)
        Me.ControlBox = False
        Me.Controls.Add(Me.btn_lotescerrados)
        Me.Controls.Add(Me.lbltipoventa)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.lblMonto)
        Me.Controls.Add(Me.lblNUMLOTE)
        Me.Controls.Add(Me.lblusuario)
        Me.Controls.Add(Me.lblalma)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.btncarga)
        Me.Controls.Add(Me.Button2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmlotesventa"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Lotes de venta"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Button3 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents lblalma As Label
    Friend WithEvents lblusuario As Label
    Friend WithEvents btncarga As Button
    Friend WithEvents lblNUMLOTE As Label
    Friend WithEvents lblMonto As Label
    Friend WithEvents id As DataGridViewTextBoxColumn
    Friend WithEvents Fecha As DataGridViewTextBoxColumn
    Friend WithEvents MontoInicial As DataGridViewTextBoxColumn
    Friend WithEvents btn_edit As DataGridViewButtonColumn
    Friend WithEvents Button1 As Button
    Friend WithEvents Panel1 As Panel
    Friend WithEvents chk_filtrofecha As CheckBox
    Friend WithEvents Panel2 As Panel
    Friend WithEvents btn_buscarlotes As Button
    Friend WithEvents dtp_fechafinal As DateTimePicker
    Friend WithEvents dtp_fechainicial As DateTimePicker
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents rdb_ventanormal As RadioButton
    Friend WithEvents rdb_preventa As RadioButton
    Friend WithEvents rdb_todos As RadioButton
    Friend WithEvents Label1 As Label
    Friend WithEvents lbltipoventa As Label
    Friend WithEvents btn_lotescerrados As Button
End Class
