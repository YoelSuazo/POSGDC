<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCierre
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCierre))
        Me.btnReimprime = New System.Windows.Forms.Button()
        Me.btnregresar = New System.Windows.Forms.Button()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.PrintDocument1 = New System.Drawing.Printing.PrintDocument()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lblcajero = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lblfecha = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.lblMontoInicial = New System.Windows.Forms.Label()
        Me.lbllote = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.txtdolares = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtcarnet = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtcafe = New System.Windows.Forms.TextBox()
        Me.txtwildacart = New System.Windows.Forms.TextBox()
        Me.txtempleados = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtpuntos = New System.Windows.Forms.TextBox()
        Me.txttarjeta = New System.Windows.Forms.TextBox()
        Me.txtefectivo = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnReimprime
        '
        Me.btnReimprime.BackColor = System.Drawing.Color.Transparent
        Me.btnReimprime.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnReimprime.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnReimprime.Image = Global.POSGDC.My.Resources.Resources.compraSaldo
        Me.btnReimprime.Location = New System.Drawing.Point(561, 666)
        Me.btnReimprime.Margin = New System.Windows.Forms.Padding(4)
        Me.btnReimprime.Name = "btnReimprime"
        Me.btnReimprime.Size = New System.Drawing.Size(196, 134)
        Me.btnReimprime.TabIndex = 8
        Me.btnReimprime.Text = "Cerrar Lote"
        Me.btnReimprime.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnReimprime.UseVisualStyleBackColor = False
        '
        'btnregresar
        '
        Me.btnregresar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnregresar.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnregresar.Image = Global.POSGDC.My.Resources.Resources.back
        Me.btnregresar.Location = New System.Drawing.Point(765, 666)
        Me.btnregresar.Margin = New System.Windows.Forms.Padding(4)
        Me.btnregresar.Name = "btnregresar"
        Me.btnregresar.Size = New System.Drawing.Size(196, 134)
        Me.btnregresar.TabIndex = 71
        Me.btnregresar.Text = "Regresar"
        Me.btnregresar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnregresar.UseVisualStyleBackColor = True
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PictureBox1.Image = Global.POSGDC.My.Resources.Resources.logodelcampo1
        Me.PictureBox1.Location = New System.Drawing.Point(13, 13)
        Me.PictureBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(182, 180)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 68
        Me.PictureBox1.TabStop = False
        '
        'PrintDocument1
        '
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(27, 254)
        Me.DataGridView1.Margin = New System.Windows.Forms.Padding(4)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.Size = New System.Drawing.Size(877, 163)
        Me.DataGridView1.TabIndex = 78
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.lblcajero)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.lblfecha)
        Me.Panel1.Controls.Add(Me.Label8)
        Me.Panel1.Controls.Add(Me.lblMontoInicial)
        Me.Panel1.Controls.Add(Me.lbllote)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Location = New System.Drawing.Point(202, 12)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(759, 181)
        Me.Panel1.TabIndex = 79
        '
        'lblcajero
        '
        Me.lblcajero.AutoSize = True
        Me.lblcajero.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold)
        Me.lblcajero.Location = New System.Drawing.Point(219, 131)
        Me.lblcajero.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblcajero.Name = "lblcajero"
        Me.lblcajero.Size = New System.Drawing.Size(40, 25)
        Me.lblcajero.TabIndex = 75
        Me.lblcajero.Text = " -- "
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(20, 131)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(111, 25)
        Me.Label4.TabIndex = 74
        Me.Label4.Text = "Cajero(a):"
        '
        'lblfecha
        '
        Me.lblfecha.AutoSize = True
        Me.lblfecha.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold)
        Me.lblfecha.Location = New System.Drawing.Point(219, 95)
        Me.lblfecha.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblfecha.Name = "lblfecha"
        Me.lblfecha.Size = New System.Drawing.Size(40, 25)
        Me.lblfecha.TabIndex = 73
        Me.lblfecha.Text = " -- "
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(20, 95)
        Me.Label8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(79, 25)
        Me.Label8.TabIndex = 72
        Me.Label8.Text = "Fecha:"
        '
        'lblMontoInicial
        '
        Me.lblMontoInicial.AutoSize = True
        Me.lblMontoInicial.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold)
        Me.lblMontoInicial.Location = New System.Drawing.Point(219, 55)
        Me.lblMontoInicial.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblMontoInicial.Name = "lblMontoInicial"
        Me.lblMontoInicial.Size = New System.Drawing.Size(40, 25)
        Me.lblMontoInicial.TabIndex = 71
        Me.lblMontoInicial.Text = " -- "
        '
        'lbllote
        '
        Me.lbllote.AutoSize = True
        Me.lbllote.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold)
        Me.lbllote.Location = New System.Drawing.Point(219, 19)
        Me.lbllote.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbllote.Name = "lbllote"
        Me.lbllote.Size = New System.Drawing.Size(40, 25)
        Me.lbllote.TabIndex = 70
        Me.lbllote.Text = " -- "
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(20, 55)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(141, 25)
        Me.Label7.TabIndex = 69
        Me.Label7.Text = "Monto Inicial:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(20, 19)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(150, 25)
        Me.Label1.TabIndex = 68
        Me.Label1.Text = "Lote de venta:"
        '
        'Panel2
        '
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.txtdolares)
        Me.Panel2.Controls.Add(Me.Label14)
        Me.Panel2.Controls.Add(Me.DataGridView1)
        Me.Panel2.Controls.Add(Me.txtcarnet)
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Controls.Add(Me.txtcafe)
        Me.Panel2.Controls.Add(Me.txtwildacart)
        Me.Panel2.Controls.Add(Me.txtempleados)
        Me.Panel2.Controls.Add(Me.Label3)
        Me.Panel2.Controls.Add(Me.txtpuntos)
        Me.Panel2.Controls.Add(Me.txttarjeta)
        Me.Panel2.Controls.Add(Me.txtefectivo)
        Me.Panel2.Controls.Add(Me.Label12)
        Me.Panel2.Controls.Add(Me.Label11)
        Me.Panel2.Controls.Add(Me.Label10)
        Me.Panel2.Controls.Add(Me.Label9)
        Me.Panel2.Controls.Add(Me.Label6)
        Me.Panel2.Controls.Add(Me.Label5)
        Me.Panel2.Location = New System.Drawing.Point(13, 209)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(948, 441)
        Me.Panel2.TabIndex = 80
        '
        'txtdolares
        '
        Me.txtdolares.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtdolares.Location = New System.Drawing.Point(270, 148)
        Me.txtdolares.Margin = New System.Windows.Forms.Padding(4)
        Me.txtdolares.Name = "txtdolares"
        Me.txtdolares.Size = New System.Drawing.Size(175, 34)
        Me.txtdolares.TabIndex = 80
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(22, 159)
        Me.Label14.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(93, 25)
        Me.Label14.TabIndex = 94
        Me.Label14.Text = "Dolares:"
        '
        'txtcarnet
        '
        Me.txtcarnet.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtcarnet.Location = New System.Drawing.Point(729, 198)
        Me.txtcarnet.Margin = New System.Windows.Forms.Padding(4)
        Me.txtcarnet.Name = "txtcarnet"
        Me.txtcarnet.Size = New System.Drawing.Size(175, 34)
        Me.txtcarnet.TabIndex = 85
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(481, 209)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(84, 25)
        Me.Label2.TabIndex = 93
        Me.Label2.Text = "Carnet:"
        '
        'txtcafe
        '
        Me.txtcafe.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtcafe.Location = New System.Drawing.Point(729, 153)
        Me.txtcafe.Margin = New System.Windows.Forms.Padding(4)
        Me.txtcafe.Name = "txtcafe"
        Me.txtcafe.Size = New System.Drawing.Size(175, 34)
        Me.txtcafe.TabIndex = 84
        '
        'txtwildacart
        '
        Me.txtwildacart.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtwildacart.Location = New System.Drawing.Point(729, 104)
        Me.txtwildacart.Margin = New System.Windows.Forms.Padding(4)
        Me.txtwildacart.Name = "txtwildacart"
        Me.txtwildacart.Size = New System.Drawing.Size(175, 34)
        Me.txtwildacart.TabIndex = 83
        '
        'txtempleados
        '
        Me.txtempleados.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtempleados.Location = New System.Drawing.Point(729, 59)
        Me.txtempleados.Margin = New System.Windows.Forms.Padding(4)
        Me.txtempleados.Name = "txtempleados"
        Me.txtempleados.Size = New System.Drawing.Size(175, 34)
        Me.txtempleados.TabIndex = 82
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(391, 10)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(149, 25)
        Me.Label3.TabIndex = 92
        Me.Label3.Text = "Detalle Cajero"
        '
        'txtpuntos
        '
        Me.txtpuntos.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtpuntos.Location = New System.Drawing.Point(270, 196)
        Me.txtpuntos.Margin = New System.Windows.Forms.Padding(4)
        Me.txtpuntos.Name = "txtpuntos"
        Me.txtpuntos.Size = New System.Drawing.Size(175, 34)
        Me.txtpuntos.TabIndex = 81
        '
        'txttarjeta
        '
        Me.txttarjeta.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txttarjeta.Location = New System.Drawing.Point(270, 104)
        Me.txttarjeta.Margin = New System.Windows.Forms.Padding(4)
        Me.txttarjeta.Name = "txttarjeta"
        Me.txttarjeta.Size = New System.Drawing.Size(175, 34)
        Me.txttarjeta.TabIndex = 79
        '
        'txtefectivo
        '
        Me.txtefectivo.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtefectivo.Location = New System.Drawing.Point(270, 60)
        Me.txtefectivo.Margin = New System.Windows.Forms.Padding(4)
        Me.txtefectivo.Name = "txtefectivo"
        Me.txtefectivo.Size = New System.Drawing.Size(175, 34)
        Me.txtefectivo.TabIndex = 78
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(480, 164)
        Me.Label12.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(128, 25)
        Me.Label12.TabIndex = 91
        Me.Label12.Text = "Cafe Gratis:"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(480, 115)
        Me.Label11.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(205, 25)
        Me.Label11.TabIndex = 90
        Me.Label11.Text = "Wildcart Disponible:"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(480, 67)
        Me.Label10.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(202, 25)
        Me.Label10.TabIndex = 89
        Me.Label10.Text = "Credito Empleados:"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(21, 203)
        Me.Label9.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(86, 25)
        Me.Label9.TabIndex = 88
        Me.Label9.Text = "Puntos:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(21, 115)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(188, 25)
        Me.Label6.TabIndex = 87
        Me.Label6.Text = "Tarjeta de credito:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(21, 68)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(96, 25)
        Me.Label5.TabIndex = 86
        Me.Label5.Text = "Efectivo:"
        '
        'frmCierre
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.ClientSize = New System.Drawing.Size(981, 842)
        Me.ControlBox = False
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.btnReimprime)
        Me.Controls.Add(Me.btnregresar)
        Me.Controls.Add(Me.PictureBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmCierre"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cierre"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnReimprime As Button
    Friend WithEvents btnregresar As Button
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Label13 As Label
    Friend WithEvents lblTotal As Label
    Friend WithEvents PrintDocument1 As Printing.PrintDocument
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents Panel1 As Panel
    Friend WithEvents lblcajero As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents lblfecha As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents lblMontoInicial As Label
    Friend WithEvents lbllote As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Panel2 As Panel
    Friend WithEvents txtdolares As TextBox
    Friend WithEvents Label14 As Label
    Friend WithEvents txtcarnet As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents txtcafe As TextBox
    Friend WithEvents txtwildacart As TextBox
    Friend WithEvents txtempleados As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents txtpuntos As TextBox
    Friend WithEvents txttarjeta As TextBox
    Friend WithEvents txtefectivo As TextBox
    Friend WithEvents Label12 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
End Class
