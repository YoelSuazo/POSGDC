<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmMetodoPago
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMetodoPago))
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.chkDivido = New System.Windows.Forms.CheckBox()
        Me.PrintDocument1 = New System.Drawing.Printing.PrintDocument()
        Me.PrintPreviewDialog1 = New System.Windows.Forms.PrintPreviewDialog()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtRTN = New System.Windows.Forms.TextBox()
        Me.txtNombref = New System.Windows.Forms.TextBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lblpreventamonto = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblcambiomoney = New System.Windows.Forms.Label()
        Me.lblefectivoregreso = New System.Windows.Forms.Label()
        Me.lbltotalpagar = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lblCambio = New System.Windows.Forms.Label()
        Me.lbldolares = New System.Windows.Forms.Label()
        Me.PrintDocument2 = New System.Drawing.Printing.PrintDocument()
        Me.PrintPreviewDialog2 = New System.Windows.Forms.PrintPreviewDialog()
        Me.txttc = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtpuntos = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtCredito = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtcarnet = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtdolar = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtwildcart = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtcafe = New System.Windows.Forms.Label()
        Me.lblpagocreditototal = New System.Windows.Forms.Label()
        Me.lblCreditoDisponible = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.lblDescuento = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.lblsubtotalcondescuento = New System.Windows.Forms.Label()
        Me.lblisvcondescuento = New System.Windows.Forms.Label()
        Me.lbltotalcondescuento = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtefectivo = New System.Windows.Forms.TextBox()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Image = Global.POSGDC.My.Resources.Resources.cancel
        Me.Button1.Location = New System.Drawing.Point(732, 629)
        Me.Button1.Margin = New System.Windows.Forms.Padding(4)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(157, 131)
        Me.Button1.TabIndex = 100
        Me.Button1.Text = "Cancelar"
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.Image = Global.POSGDC.My.Resources.Resources.checked
        Me.Button2.Location = New System.Drawing.Point(732, 479)
        Me.Button2.Margin = New System.Windows.Forms.Padding(4)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(154, 131)
        Me.Button2.TabIndex = 10
        Me.Button2.Text = "Aceptar"
        Me.Button2.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button2.UseVisualStyleBackColor = True
        '
        'chkDivido
        '
        Me.chkDivido.AutoSize = True
        Me.chkDivido.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkDivido.Location = New System.Drawing.Point(732, 437)
        Me.chkDivido.Margin = New System.Windows.Forms.Padding(4)
        Me.chkDivido.Name = "chkDivido"
        Me.chkDivido.Size = New System.Drawing.Size(165, 21)
        Me.chkDivido.TabIndex = 100
        Me.chkDivido.Text = "Imprimir dos veces"
        Me.chkDivido.UseVisualStyleBackColor = True
        '
        'PrintDocument1
        '
        '
        'PrintPreviewDialog1
        '
        Me.PrintPreviewDialog1.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.PrintPreviewDialog1.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.PrintPreviewDialog1.ClientSize = New System.Drawing.Size(400, 300)
        Me.PrintPreviewDialog1.Enabled = True
        Me.PrintPreviewDialog1.Icon = CType(resources.GetObject("PrintPreviewDialog1.Icon"), System.Drawing.Icon)
        Me.PrintPreviewDialog1.Name = "PrintPreviewDialog1"
        Me.PrintPreviewDialog1.Visible = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(16, 208)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(41, 17)
        Me.Label2.TabIndex = 100
        Me.Label2.Text = "RTN:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 239)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(62, 17)
        Me.Label3.TabIndex = 100
        Me.Label3.Text = "Nombre:"
        '
        'txtRTN
        '
        Me.txtRTN.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRTN.Location = New System.Drawing.Point(76, 194)
        Me.txtRTN.Margin = New System.Windows.Forms.Padding(4)
        Me.txtRTN.Name = "txtRTN"
        Me.txtRTN.Size = New System.Drawing.Size(508, 29)
        Me.txtRTN.TabIndex = 8
        '
        'txtNombref
        '
        Me.txtNombref.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNombref.Location = New System.Drawing.Point(76, 230)
        Me.txtNombref.Margin = New System.Windows.Forms.Padding(4)
        Me.txtNombref.Name = "txtNombref"
        Me.txtNombref.Size = New System.Drawing.Size(508, 29)
        Me.txtNombref.TabIndex = 9
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Panel1.Controls.Add(Me.lblpreventamonto)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.lblcambiomoney)
        Me.Panel1.Controls.Add(Me.lblefectivoregreso)
        Me.Panel1.Controls.Add(Me.lbltotalpagar)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.txtRTN)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.txtNombref)
        Me.Panel1.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Panel1.Location = New System.Drawing.Point(11, 482)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(637, 284)
        Me.Panel1.TabIndex = 100
        '
        'lblpreventamonto
        '
        Me.lblpreventamonto.Font = New System.Drawing.Font("Microsoft YaHei UI", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblpreventamonto.ForeColor = System.Drawing.Color.Lime
        Me.lblpreventamonto.Location = New System.Drawing.Point(395, 111)
        Me.lblpreventamonto.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblpreventamonto.Name = "lblpreventamonto"
        Me.lblpreventamonto.Size = New System.Drawing.Size(192, 28)
        Me.lblpreventamonto.TabIndex = 7
        Me.lblpreventamonto.Text = "."
        Me.lblpreventamonto.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(8, 101)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(256, 29)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Pagado en Preventa:"
        '
        'lblcambiomoney
        '
        Me.lblcambiomoney.Font = New System.Drawing.Font("Microsoft YaHei UI", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblcambiomoney.ForeColor = System.Drawing.Color.Lime
        Me.lblcambiomoney.Location = New System.Drawing.Point(393, 149)
        Me.lblcambiomoney.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblcambiomoney.Name = "lblcambiomoney"
        Me.lblcambiomoney.Size = New System.Drawing.Size(192, 30)
        Me.lblcambiomoney.TabIndex = 5
        Me.lblcambiomoney.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblefectivoregreso
        '
        Me.lblefectivoregreso.Font = New System.Drawing.Font("Microsoft YaHei UI", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblefectivoregreso.ForeColor = System.Drawing.Color.Lime
        Me.lblefectivoregreso.Location = New System.Drawing.Point(393, 65)
        Me.lblefectivoregreso.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblefectivoregreso.Name = "lblefectivoregreso"
        Me.lblefectivoregreso.Size = New System.Drawing.Size(192, 28)
        Me.lblefectivoregreso.TabIndex = 4
        Me.lblefectivoregreso.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lbltotalpagar
        '
        Me.lbltotalpagar.Font = New System.Drawing.Font("Microsoft YaHei UI", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbltotalpagar.ForeColor = System.Drawing.Color.Lime
        Me.lbltotalpagar.Location = New System.Drawing.Point(393, 20)
        Me.lbltotalpagar.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbltotalpagar.Name = "lbltotalpagar"
        Me.lbltotalpagar.Size = New System.Drawing.Size(192, 28)
        Me.lbltotalpagar.TabIndex = 3
        Me.lbltotalpagar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(8, 150)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(110, 29)
        Me.Label6.TabIndex = 2
        Me.Label6.Text = "Cambio:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(8, 57)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(154, 25)
        Me.Label5.TabIndex = 1
        Me.Label5.Text = "Total Ingresado:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(8, 14)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(133, 25)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Total a pagar:"
        '
        'lblCambio
        '
        Me.lblCambio.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCambio.Location = New System.Drawing.Point(824, 326)
        Me.lblCambio.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblCambio.Name = "lblCambio"
        Me.lblCambio.Size = New System.Drawing.Size(178, 30)
        Me.lblCambio.TabIndex = 14
        Me.lblCambio.Text = "$1 = "
        Me.lblCambio.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbldolares
        '
        Me.lbldolares.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbldolares.Location = New System.Drawing.Point(634, 326)
        Me.lbldolares.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbldolares.Name = "lbldolares"
        Me.lbldolares.Size = New System.Drawing.Size(182, 30)
        Me.lbldolares.TabIndex = 15
        Me.lbldolares.Text = "Dolares: $"
        Me.lbldolares.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'PrintDocument2
        '
        '
        'PrintPreviewDialog2
        '
        Me.PrintPreviewDialog2.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.PrintPreviewDialog2.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.PrintPreviewDialog2.ClientSize = New System.Drawing.Size(400, 300)
        Me.PrintPreviewDialog2.Enabled = True
        Me.PrintPreviewDialog2.Icon = CType(resources.GetObject("PrintPreviewDialog2.Icon"), System.Drawing.Icon)
        Me.PrintPreviewDialog2.Name = "PrintPreviewDialog2"
        Me.PrintPreviewDialog2.Visible = False
        '
        'txttc
        '
        Me.txttc.Font = New System.Drawing.Font("Microsoft YaHei UI", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txttc.Location = New System.Drawing.Point(15, 134)
        Me.txttc.Margin = New System.Windows.Forms.Padding(4)
        Me.txttc.Name = "txttc"
        Me.txttc.Size = New System.Drawing.Size(445, 38)
        Me.txttc.TabIndex = 1
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(11, 108)
        Me.Label8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(408, 20)
        Me.Label8.TabIndex = 18
        Me.Label8.Text = "Tarjeta de credito (Enter para agregar tarjeta ):"
        '
        'txtpuntos
        '
        Me.txtpuntos.Font = New System.Drawing.Font("Microsoft YaHei UI", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtpuntos.Location = New System.Drawing.Point(15, 198)
        Me.txtpuntos.Margin = New System.Windows.Forms.Padding(4)
        Me.txtpuntos.Name = "txtpuntos"
        Me.txtpuntos.Size = New System.Drawing.Size(445, 38)
        Me.txtpuntos.TabIndex = 2
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(11, 176)
        Me.Label9.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(73, 20)
        Me.Label9.TabIndex = 20
        Me.Label9.Text = "Puntos:"
        '
        'txtCredito
        '
        Me.txtCredito.Font = New System.Drawing.Font("Microsoft YaHei UI", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCredito.Location = New System.Drawing.Point(16, 268)
        Me.txtCredito.Margin = New System.Windows.Forms.Padding(4)
        Me.txtCredito.Name = "txtCredito"
        Me.txtCredito.Size = New System.Drawing.Size(445, 38)
        Me.txtCredito.TabIndex = 3
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(12, 245)
        Me.Label10.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(174, 20)
        Me.Label10.TabIndex = 22
        Me.Label10.Text = "Credito Empleados:"
        '
        'txtcarnet
        '
        Me.txtcarnet.Font = New System.Drawing.Font("Microsoft YaHei UI", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtcarnet.Location = New System.Drawing.Point(472, 268)
        Me.txtcarnet.Margin = New System.Windows.Forms.Padding(4)
        Me.txtcarnet.Name = "txtcarnet"
        Me.txtcarnet.Size = New System.Drawing.Size(445, 38)
        Me.txtcarnet.TabIndex = 6
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(468, 245)
        Me.Label11.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(71, 20)
        Me.Label11.TabIndex = 30
        Me.Label11.Text = "Carnet:"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(467, 181)
        Me.Label12.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(112, 20)
        Me.Label12.TabIndex = 28
        Me.Label12.Text = "Cafe Gratis:"
        '
        'txtdolar
        '
        Me.txtdolar.Font = New System.Drawing.Font("Microsoft YaHei UI", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtdolar.Location = New System.Drawing.Point(471, 135)
        Me.txtdolar.Margin = New System.Windows.Forms.Padding(4)
        Me.txtdolar.Name = "txtdolar"
        Me.txtdolar.Size = New System.Drawing.Size(445, 38)
        Me.txtdolar.TabIndex = 5
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(467, 114)
        Me.Label13.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(99, 20)
        Me.Label13.TabIndex = 26
        Me.Label13.Text = "Efectivo $:"
        '
        'txtwildcart
        '
        Me.txtwildcart.Font = New System.Drawing.Font("Microsoft YaHei UI", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtwildcart.Location = New System.Drawing.Point(472, 63)
        Me.txtwildcart.Margin = New System.Windows.Forms.Padding(4)
        Me.txtwildcart.Name = "txtwildcart"
        Me.txtwildcart.Size = New System.Drawing.Size(445, 38)
        Me.txtwildcart.TabIndex = 4
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(468, 43)
        Me.Label14.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(180, 20)
        Me.Label14.TabIndex = 24
        Me.Label14.Text = "Wildcart Disponible:"
        '
        'txtcafe
        '
        Me.txtcafe.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtcafe.Location = New System.Drawing.Point(469, 204)
        Me.txtcafe.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.txtcafe.Name = "txtcafe"
        Me.txtcafe.Size = New System.Drawing.Size(444, 30)
        Me.txtcafe.TabIndex = 101
        Me.txtcafe.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblpagocreditototal
        '
        Me.lblpagocreditototal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblpagocreditototal.Location = New System.Drawing.Point(333, 326)
        Me.lblpagocreditototal.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblpagocreditototal.Name = "lblpagocreditototal"
        Me.lblpagocreditototal.Size = New System.Drawing.Size(265, 30)
        Me.lblpagocreditototal.TabIndex = 103
        Me.lblpagocreditototal.Text = "Pago Total al Credito"
        Me.lblpagocreditototal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblCreditoDisponible
        '
        Me.lblCreditoDisponible.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCreditoDisponible.Location = New System.Drawing.Point(13, 326)
        Me.lblCreditoDisponible.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblCreditoDisponible.Name = "lblCreditoDisponible"
        Me.lblCreditoDisponible.Size = New System.Drawing.Size(308, 30)
        Me.lblCreditoDisponible.TabIndex = 104
        Me.lblCreditoDisponible.Text = "Credito Disponible: "
        Me.lblCreditoDisponible.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(10, 9)
        Me.Label15.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(323, 18)
        Me.Label15.TabIndex = 105
        Me.Label15.Text = "Tab para avanzar y (Shift + Tab) para retroceder"
        '
        'lblDescuento
        '
        Me.lblDescuento.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDescuento.Location = New System.Drawing.Point(319, 403)
        Me.lblDescuento.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDescuento.Name = "lblDescuento"
        Me.lblDescuento.Size = New System.Drawing.Size(260, 30)
        Me.lblDescuento.TabIndex = 102
        Me.lblDescuento.Text = "Descuento:"
        Me.lblDescuento.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label16
        '
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(13, 368)
        Me.Label16.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(269, 30)
        Me.Label16.TabIndex = 106
        Me.Label16.Text = "Nuevo Balance."
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblsubtotalcondescuento
        '
        Me.lblsubtotalcondescuento.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblsubtotalcondescuento.Location = New System.Drawing.Point(13, 403)
        Me.lblsubtotalcondescuento.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblsubtotalcondescuento.Name = "lblsubtotalcondescuento"
        Me.lblsubtotalcondescuento.Size = New System.Drawing.Size(298, 30)
        Me.lblsubtotalcondescuento.TabIndex = 107
        Me.lblsubtotalcondescuento.Text = "Subtotal:"
        Me.lblsubtotalcondescuento.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblisvcondescuento
        '
        Me.lblisvcondescuento.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblisvcondescuento.Location = New System.Drawing.Point(587, 403)
        Me.lblisvcondescuento.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblisvcondescuento.Name = "lblisvcondescuento"
        Me.lblisvcondescuento.Size = New System.Drawing.Size(260, 30)
        Me.lblisvcondescuento.TabIndex = 108
        Me.lblisvcondescuento.Text = "ISV:"
        Me.lblisvcondescuento.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbltotalcondescuento
        '
        Me.lbltotalcondescuento.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbltotalcondescuento.Location = New System.Drawing.Point(12, 448)
        Me.lbltotalcondescuento.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbltotalcondescuento.Name = "lbltotalcondescuento"
        Me.lbltotalcondescuento.Size = New System.Drawing.Size(367, 30)
        Me.lbltotalcondescuento.TabIndex = 109
        Me.lbltotalcondescuento.Text = "Total:"
        Me.lbltotalcondescuento.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(12, 39)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(83, 20)
        Me.Label7.TabIndex = 16
        Me.Label7.Text = "Efectivo:"
        '
        'txtefectivo
        '
        Me.txtefectivo.Font = New System.Drawing.Font("Microsoft YaHei UI", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtefectivo.Location = New System.Drawing.Point(16, 63)
        Me.txtefectivo.Margin = New System.Windows.Forms.Padding(4)
        Me.txtefectivo.Name = "txtefectivo"
        Me.txtefectivo.Size = New System.Drawing.Size(445, 38)
        Me.txtefectivo.TabIndex = 0
        '
        'frmMetodoPago
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.ClientSize = New System.Drawing.Size(949, 787)
        Me.ControlBox = False
        Me.Controls.Add(Me.lbltotalcondescuento)
        Me.Controls.Add(Me.lblisvcondescuento)
        Me.Controls.Add(Me.lblsubtotalcondescuento)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.lblCreditoDisponible)
        Me.Controls.Add(Me.lblpagocreditototal)
        Me.Controls.Add(Me.lblDescuento)
        Me.Controls.Add(Me.txtcafe)
        Me.Controls.Add(Me.txtcarnet)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.txtdolar)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.txtwildcart)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.txtCredito)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.txtpuntos)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.txttc)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.txtefectivo)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.lbldolares)
        Me.Controls.Add(Me.lblCambio)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.chkDivido)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmMetodoPago"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Pago"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Button1 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents chkDivido As CheckBox
    Friend WithEvents PrintDocument1 As Printing.PrintDocument
    Friend WithEvents PrintPreviewDialog1 As PrintPreviewDialog
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents txtRTN As TextBox
    Friend WithEvents txtNombref As TextBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents lblCambio As Label
    Friend WithEvents lblcambiomoney As Label
    Friend WithEvents lblefectivoregreso As Label
    Friend WithEvents lbltotalpagar As Label
    Friend WithEvents lbldolares As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents lblpreventamonto As Label
    Friend WithEvents PrintDocument2 As Printing.PrintDocument
    Friend WithEvents PrintPreviewDialog2 As PrintPreviewDialog
    Friend WithEvents txttc As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents txtpuntos As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents txtCredito As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents txtcarnet As TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents txtdolar As TextBox
    Friend WithEvents Label13 As Label
    Friend WithEvents txtwildcart As TextBox
    Friend WithEvents Label14 As Label
    Friend WithEvents txtcafe As Label
    Friend WithEvents lblpagocreditototal As Label
    Friend WithEvents lblCreditoDisponible As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents lblDescuento As Label
    Friend WithEvents Label16 As Label
    Friend WithEvents lblsubtotalcondescuento As Label
    Friend WithEvents lblisvcondescuento As Label
    Friend WithEvents lbltotalcondescuento As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents txtefectivo As TextBox
End Class
