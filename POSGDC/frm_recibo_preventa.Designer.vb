<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frm_recibo_preventa
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
        Me.btnNuevoCliente = New System.Windows.Forms.Button()
        Me.btnaceptar = New System.Windows.Forms.Button()
        Me.lblNumeroVenta = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.rbPagominimo = New System.Windows.Forms.RadioButton()
        Me.rbPagototal = New System.Windows.Forms.RadioButton()
        Me.chkllevacambio = New System.Windows.Forms.CheckBox()
        Me.lblsubtotalp = New System.Windows.Forms.Label()
        Me.lbldescuentop = New System.Windows.Forms.Label()
        Me.lblisvp = New System.Windows.Forms.Label()
        Me.lblmontominimop = New System.Windows.Forms.Label()
        Me.lbltotalp = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblsubtotal = New System.Windows.Forms.Label()
        Me.lbldescuento = New System.Windows.Forms.Label()
        Me.lblisv = New System.Windows.Forms.Label()
        Me.lblmontominimo = New System.Windows.Forms.Label()
        Me.lblmontototal = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.lblcambio = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtdeduccion = New System.Windows.Forms.TextBox()
        Me.txtpuntos = New System.Windows.Forms.TextBox()
        Me.txttarjetacredito = New System.Windows.Forms.TextBox()
        Me.txtefectivo = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Efectivo = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.txtTelefonoCliente = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtNombreCliente = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtIdentidad = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.lblLimiteCredito = New System.Windows.Forms.Label()
        Me.lblSaldo = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnNuevoCliente
        '
        Me.btnNuevoCliente.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnNuevoCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNuevoCliente.Image = Global.POSGDC.My.Resources.Resources.cancel
        Me.btnNuevoCliente.Location = New System.Drawing.Point(518, 494)
        Me.btnNuevoCliente.Margin = New System.Windows.Forms.Padding(4)
        Me.btnNuevoCliente.Name = "btnNuevoCliente"
        Me.btnNuevoCliente.Size = New System.Drawing.Size(156, 115)
        Me.btnNuevoCliente.TabIndex = 15
        Me.btnNuevoCliente.Text = "Cancelar"
        Me.btnNuevoCliente.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnNuevoCliente.UseVisualStyleBackColor = True
        '
        'btnaceptar
        '
        Me.btnaceptar.Enabled = False
        Me.btnaceptar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnaceptar.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnaceptar.Image = Global.POSGDC.My.Resources.Resources.checked
        Me.btnaceptar.Location = New System.Drawing.Point(297, 494)
        Me.btnaceptar.Margin = New System.Windows.Forms.Padding(4)
        Me.btnaceptar.Name = "btnaceptar"
        Me.btnaceptar.Size = New System.Drawing.Size(156, 115)
        Me.btnaceptar.TabIndex = 14
        Me.btnaceptar.Text = "Aceptar"
        Me.btnaceptar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnaceptar.UseVisualStyleBackColor = True
        '
        'lblNumeroVenta
        '
        Me.lblNumeroVenta.AutoSize = True
        Me.lblNumeroVenta.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNumeroVenta.Location = New System.Drawing.Point(21, 19)
        Me.lblNumeroVenta.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblNumeroVenta.Name = "lblNumeroVenta"
        Me.lblNumeroVenta.Size = New System.Drawing.Size(140, 20)
        Me.lblNumeroVenta.TabIndex = 27
        Me.lblNumeroVenta.Text = "Numero Venta: "
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.rbPagominimo)
        Me.Panel1.Controls.Add(Me.rbPagototal)
        Me.Panel1.Controls.Add(Me.chkllevacambio)
        Me.Panel1.Controls.Add(Me.lblsubtotalp)
        Me.Panel1.Controls.Add(Me.lbldescuentop)
        Me.Panel1.Controls.Add(Me.lblisvp)
        Me.Panel1.Controls.Add(Me.lblmontominimop)
        Me.Panel1.Controls.Add(Me.lbltotalp)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.lblsubtotal)
        Me.Panel1.Controls.Add(Me.lbldescuento)
        Me.Panel1.Controls.Add(Me.lblisv)
        Me.Panel1.Controls.Add(Me.lblmontominimo)
        Me.Panel1.Controls.Add(Me.lblmontototal)
        Me.Panel1.Location = New System.Drawing.Point(25, 199)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(533, 261)
        Me.Panel1.TabIndex = 2
        '
        'rbPagominimo
        '
        Me.rbPagominimo.AutoSize = True
        Me.rbPagominimo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold)
        Me.rbPagominimo.Location = New System.Drawing.Point(194, 226)
        Me.rbPagominimo.Name = "rbPagominimo"
        Me.rbPagominimo.Size = New System.Drawing.Size(147, 24)
        Me.rbPagominimo.TabIndex = 8
        Me.rbPagominimo.TabStop = True
        Me.rbPagominimo.Text = "Monto Minimo"
        Me.rbPagominimo.UseVisualStyleBackColor = True
        '
        'rbPagototal
        '
        Me.rbPagototal.AutoSize = True
        Me.rbPagototal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold)
        Me.rbPagototal.Location = New System.Drawing.Point(33, 226)
        Me.rbPagototal.Name = "rbPagototal"
        Me.rbPagototal.Size = New System.Drawing.Size(120, 24)
        Me.rbPagototal.TabIndex = 7
        Me.rbPagototal.TabStop = True
        Me.rbPagototal.Text = "Pago Total"
        Me.rbPagototal.UseVisualStyleBackColor = True
        '
        'chkllevacambio
        '
        Me.chkllevacambio.AutoSize = True
        Me.chkllevacambio.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold)
        Me.chkllevacambio.Location = New System.Drawing.Point(367, 227)
        Me.chkllevacambio.Name = "chkllevacambio"
        Me.chkllevacambio.Size = New System.Drawing.Size(142, 24)
        Me.chkllevacambio.TabIndex = 9
        Me.chkllevacambio.Text = "Lleva cambio"
        Me.chkllevacambio.UseVisualStyleBackColor = True
        '
        'lblsubtotalp
        '
        Me.lblsubtotalp.AutoSize = True
        Me.lblsubtotalp.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblsubtotalp.Location = New System.Drawing.Point(236, 44)
        Me.lblsubtotalp.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblsubtotalp.Name = "lblsubtotalp"
        Me.lblsubtotalp.Size = New System.Drawing.Size(66, 20)
        Me.lblsubtotalp.TabIndex = 47
        Me.lblsubtotalp.Text = "L. 0.00"
        '
        'lbldescuentop
        '
        Me.lbldescuentop.AutoSize = True
        Me.lbldescuentop.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbldescuentop.Location = New System.Drawing.Point(236, 74)
        Me.lbldescuentop.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbldescuentop.Name = "lbldescuentop"
        Me.lbldescuentop.Size = New System.Drawing.Size(66, 20)
        Me.lbldescuentop.TabIndex = 46
        Me.lbldescuentop.Text = "L. 0.00"
        '
        'lblisvp
        '
        Me.lblisvp.AutoSize = True
        Me.lblisvp.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblisvp.Location = New System.Drawing.Point(236, 108)
        Me.lblisvp.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblisvp.Name = "lblisvp"
        Me.lblisvp.Size = New System.Drawing.Size(66, 20)
        Me.lblisvp.TabIndex = 45
        Me.lblisvp.Text = "L. 0.00"
        '
        'lblmontominimop
        '
        Me.lblmontominimop.AutoSize = True
        Me.lblmontominimop.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblmontominimop.Location = New System.Drawing.Point(236, 191)
        Me.lblmontominimop.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblmontominimop.Name = "lblmontominimop"
        Me.lblmontominimop.Size = New System.Drawing.Size(66, 20)
        Me.lblmontominimop.TabIndex = 44
        Me.lblmontominimop.Text = "L. 0.00"
        '
        'lbltotalp
        '
        Me.lbltotalp.AutoSize = True
        Me.lbltotalp.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbltotalp.Location = New System.Drawing.Point(236, 145)
        Me.lbltotalp.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbltotalp.Name = "lbltotalp"
        Me.lbltotalp.Size = New System.Drawing.Size(66, 20)
        Me.lbltotalp.TabIndex = 43
        Me.lbltotalp.Text = "L. 0.00"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(187, 12)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(149, 20)
        Me.Label2.TabIndex = 42
        Me.Label2.Text = "Balance General"
        '
        'lblsubtotal
        '
        Me.lblsubtotal.AutoSize = True
        Me.lblsubtotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblsubtotal.Location = New System.Drawing.Point(29, 44)
        Me.lblsubtotal.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblsubtotal.Name = "lblsubtotal"
        Me.lblsubtotal.Size = New System.Drawing.Size(84, 20)
        Me.lblsubtotal.TabIndex = 41
        Me.lblsubtotal.Text = "Subtotal:"
        '
        'lbldescuento
        '
        Me.lbldescuento.AutoSize = True
        Me.lbldescuento.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbldescuento.Location = New System.Drawing.Point(26, 74)
        Me.lbldescuento.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbldescuento.Name = "lbldescuento"
        Me.lbldescuento.Size = New System.Drawing.Size(153, 20)
        Me.lbldescuento.TabIndex = 40
        Me.lbldescuento.Text = "Total Descuento:"
        '
        'lblisv
        '
        Me.lblisv.AutoSize = True
        Me.lblisv.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblisv.Location = New System.Drawing.Point(26, 108)
        Me.lblisv.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblisv.Name = "lblisv"
        Me.lblisv.Size = New System.Drawing.Size(87, 20)
        Me.lblisv.TabIndex = 39
        Me.lblisv.Text = "Total isv:"
        '
        'lblmontominimo
        '
        Me.lblmontominimo.AutoSize = True
        Me.lblmontominimo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblmontominimo.Location = New System.Drawing.Point(26, 191)
        Me.lblmontominimo.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblmontominimo.Name = "lblmontominimo"
        Me.lblmontominimo.Size = New System.Drawing.Size(132, 20)
        Me.lblmontominimo.TabIndex = 38
        Me.lblmontominimo.Text = "Monto minimo:"
        '
        'lblmontototal
        '
        Me.lblmontototal.AutoSize = True
        Me.lblmontototal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblmontototal.Location = New System.Drawing.Point(26, 145)
        Me.lblmontototal.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblmontototal.Name = "lblmontototal"
        Me.lblmontototal.Size = New System.Drawing.Size(109, 20)
        Me.lblmontototal.TabIndex = 37
        Me.lblmontototal.Text = "Monto total:"
        '
        'Panel2
        '
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.lblcambio)
        Me.Panel2.Controls.Add(Me.Label4)
        Me.Panel2.Controls.Add(Me.txtdeduccion)
        Me.Panel2.Controls.Add(Me.txtpuntos)
        Me.Panel2.Controls.Add(Me.txttarjetacredito)
        Me.Panel2.Controls.Add(Me.txtefectivo)
        Me.Panel2.Controls.Add(Me.Label8)
        Me.Panel2.Controls.Add(Me.Label6)
        Me.Panel2.Controls.Add(Me.Label3)
        Me.Panel2.Controls.Add(Me.Efectivo)
        Me.Panel2.Location = New System.Drawing.Point(578, 53)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(342, 407)
        Me.Panel2.TabIndex = 3
        '
        'lblcambio
        '
        Me.lblcambio.AutoSize = True
        Me.lblcambio.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblcambio.Location = New System.Drawing.Point(51, 374)
        Me.lblcambio.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblcambio.Name = "lblcambio"
        Me.lblcambio.Size = New System.Drawing.Size(141, 20)
        Me.lblcambio.TabIndex = 47
        Me.lblcambio.Text = "Cambio: L. 0.00"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(99, 11)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(152, 20)
        Me.Label4.TabIndex = 46
        Me.Label4.Text = "Metodos de pago"
        '
        'txtdeduccion
        '
        Me.txtdeduccion.Font = New System.Drawing.Font("Microsoft YaHei UI", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtdeduccion.Location = New System.Drawing.Point(55, 266)
        Me.txtdeduccion.Margin = New System.Windows.Forms.Padding(4)
        Me.txtdeduccion.Name = "txtdeduccion"
        Me.txtdeduccion.Size = New System.Drawing.Size(222, 38)
        Me.txtdeduccion.TabIndex = 13
        '
        'txtpuntos
        '
        Me.txtpuntos.Font = New System.Drawing.Font("Microsoft YaHei UI", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtpuntos.Location = New System.Drawing.Point(55, 130)
        Me.txtpuntos.Margin = New System.Windows.Forms.Padding(4)
        Me.txtpuntos.Name = "txtpuntos"
        Me.txtpuntos.Size = New System.Drawing.Size(222, 38)
        Me.txtpuntos.TabIndex = 11
        '
        'txttarjetacredito
        '
        Me.txttarjetacredito.Font = New System.Drawing.Font("Microsoft YaHei UI", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txttarjetacredito.Location = New System.Drawing.Point(55, 202)
        Me.txttarjetacredito.Margin = New System.Windows.Forms.Padding(4)
        Me.txttarjetacredito.Name = "txttarjetacredito"
        Me.txttarjetacredito.Size = New System.Drawing.Size(222, 38)
        Me.txttarjetacredito.TabIndex = 12
        '
        'txtefectivo
        '
        Me.txtefectivo.Font = New System.Drawing.Font("Microsoft YaHei UI", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtefectivo.Location = New System.Drawing.Point(53, 64)
        Me.txtefectivo.Margin = New System.Windows.Forms.Padding(4)
        Me.txtefectivo.Name = "txtefectivo"
        Me.txtefectivo.Size = New System.Drawing.Size(222, 38)
        Me.txtefectivo.TabIndex = 10
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(51, 244)
        Me.Label8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(166, 20)
        Me.Label8.TabIndex = 41
        Me.Label8.Text = "Deduccion Planilla"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(51, 106)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(139, 20)
        Me.Label6.TabIndex = 40
        Me.Label6.Text = "Puntos Ficohsa"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(51, 178)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(135, 20)
        Me.Label3.TabIndex = 39
        Me.Label3.Text = "Tarjeta Credito"
        '
        'Efectivo
        '
        Me.Efectivo.AutoSize = True
        Me.Efectivo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Efectivo.Location = New System.Drawing.Point(51, 40)
        Me.Efectivo.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Efectivo.Name = "Efectivo"
        Me.Efectivo.Size = New System.Drawing.Size(77, 20)
        Me.Efectivo.TabIndex = 38
        Me.Efectivo.Text = "Efectivo"
        '
        'Panel3
        '
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel3.Controls.Add(Me.txtTelefonoCliente)
        Me.Panel3.Controls.Add(Me.Label5)
        Me.Panel3.Controls.Add(Me.txtNombreCliente)
        Me.Panel3.Controls.Add(Me.Label1)
        Me.Panel3.Controls.Add(Me.txtIdentidad)
        Me.Panel3.Controls.Add(Me.Label7)
        Me.Panel3.Location = New System.Drawing.Point(25, 53)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(533, 137)
        Me.Panel3.TabIndex = 1
        '
        'txtTelefonoCliente
        '
        Me.txtTelefonoCliente.Font = New System.Drawing.Font("Microsoft YaHei UI", 10.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTelefonoCliente.Location = New System.Drawing.Point(191, 90)
        Me.txtTelefonoCliente.Margin = New System.Windows.Forms.Padding(4)
        Me.txtTelefonoCliente.Name = "txtTelefonoCliente"
        Me.txtTelefonoCliente.Size = New System.Drawing.Size(328, 30)
        Me.txtTelefonoCliente.TabIndex = 6
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(11, 90)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(163, 20)
        Me.Label5.TabIndex = 26
        Me.Label5.Text = "Telefono o E-mail:"
        '
        'txtNombreCliente
        '
        Me.txtNombreCliente.Font = New System.Drawing.Font("Microsoft YaHei UI", 10.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNombreCliente.Location = New System.Drawing.Point(191, 51)
        Me.txtNombreCliente.Margin = New System.Windows.Forms.Padding(4)
        Me.txtNombreCliente.Name = "txtNombreCliente"
        Me.txtNombreCliente.Size = New System.Drawing.Size(328, 30)
        Me.txtNombreCliente.TabIndex = 5
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(13, 51)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(145, 20)
        Me.Label1.TabIndex = 24
        Me.Label1.Text = "Nombre Cliente:"
        '
        'txtIdentidad
        '
        Me.txtIdentidad.Font = New System.Drawing.Font("Microsoft YaHei UI", 10.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIdentidad.Location = New System.Drawing.Point(191, 11)
        Me.txtIdentidad.Margin = New System.Windows.Forms.Padding(4)
        Me.txtIdentidad.Name = "txtIdentidad"
        Me.txtIdentidad.Size = New System.Drawing.Size(328, 30)
        Me.txtIdentidad.TabIndex = 4
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(13, 17)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(150, 20)
        Me.Label7.TabIndex = 22
        Me.Label7.Text = "RTN o Identidad:"
        '
        'lblLimiteCredito
        '
        Me.lblLimiteCredito.AutoSize = True
        Me.lblLimiteCredito.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLimiteCredito.ForeColor = System.Drawing.Color.Red
        Me.lblLimiteCredito.Location = New System.Drawing.Point(22, 474)
        Me.lblLimiteCredito.Name = "lblLimiteCredito"
        Me.lblLimiteCredito.Size = New System.Drawing.Size(65, 17)
        Me.lblLimiteCredito.TabIndex = 48
        Me.lblLimiteCredito.Text = "Credito:"
        Me.lblLimiteCredito.Visible = False
        '
        'lblSaldo
        '
        Me.lblSaldo.AutoSize = True
        Me.lblSaldo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSaldo.Location = New System.Drawing.Point(505, 9)
        Me.lblSaldo.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblSaldo.Name = "lblSaldo"
        Me.lblSaldo.Size = New System.Drawing.Size(193, 20)
        Me.lblSaldo.TabIndex = 49
        Me.lblSaldo.Text = "Credito Disponible: L."
        '
        'frm_recibo_preventa
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.ClientSize = New System.Drawing.Size(968, 635)
        Me.ControlBox = False
        Me.Controls.Add(Me.lblSaldo)
        Me.Controls.Add(Me.lblLimiteCredito)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.lblNumeroVenta)
        Me.Controls.Add(Me.btnNuevoCliente)
        Me.Controls.Add(Me.btnaceptar)
        Me.Name = "frm_recibo_preventa"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Generar Recibo Preventa"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnNuevoCliente As Button
    Friend WithEvents btnaceptar As Button
    Friend WithEvents lblNumeroVenta As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents lblsubtotalp As Label
    Friend WithEvents lbldescuentop As Label
    Friend WithEvents lblisvp As Label
    Friend WithEvents lblmontominimop As Label
    Friend WithEvents lbltotalp As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents lblsubtotal As Label
    Friend WithEvents lbldescuento As Label
    Friend WithEvents lblisv As Label
    Friend WithEvents lblmontominimo As Label
    Friend WithEvents lblmontototal As Label
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Label4 As Label
    Friend WithEvents txtdeduccion As TextBox
    Friend WithEvents txtpuntos As TextBox
    Friend WithEvents txttarjetacredito As TextBox
    Friend WithEvents txtefectivo As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Efectivo As Label
    Friend WithEvents Panel3 As Panel
    Friend WithEvents txtNombreCliente As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents txtIdentidad As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents lblLimiteCredito As Label
    Friend WithEvents lblSaldo As Label
    Friend WithEvents chkllevacambio As CheckBox
    Friend WithEvents lblcambio As Label
    Friend WithEvents rbPagominimo As RadioButton
    Friend WithEvents rbPagototal As RadioButton
    Friend WithEvents txtTelefonoCliente As TextBox
    Friend WithEvents Label5 As Label
End Class
