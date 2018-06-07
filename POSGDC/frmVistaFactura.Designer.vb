<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmVistaFactura
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmVistaFactura))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.lblcajero = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lbltotal = New System.Windows.Forms.Label()
        Me.lblimp = New System.Windows.Forms.Label()
        Me.lbldesc = New System.Windows.Forms.Label()
        Me.lblsub = New System.Windows.Forms.Label()
        Me.lblestado = New System.Windows.Forms.Label()
        Me.lblfecha = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.lblRTN = New System.Windows.Forms.Label()
        Me.lblNombreCliente = New System.Windows.Forms.Label()
        Me.lblrango = New System.Windows.Forms.Label()
        Me.lblnumventa = New System.Windows.Forms.Label()
        Me.lbllote = New System.Windows.Forms.Label()
        Me.lblinterno = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblNumerofactura = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnpago = New System.Windows.Forms.Button()
        Me.btnReimprime = New System.Windows.Forms.Button()
        Me.btnregresar = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.PrintDocument1 = New System.Drawing.Printing.PrintDocument()
        Me.PrintPreviewDialog1 = New System.Windows.Forms.PrintPreviewDialog()
        Me.Panel1.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.Controls.Add(Me.Label13)
        Me.Panel1.Controls.Add(Me.Label12)
        Me.Panel1.Controls.Add(Me.Label11)
        Me.Panel1.Controls.Add(Me.Label10)
        Me.Panel1.Controls.Add(Me.Label9)
        Me.Panel1.Controls.Add(Me.lblcajero)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.lbltotal)
        Me.Panel1.Controls.Add(Me.lblimp)
        Me.Panel1.Controls.Add(Me.lbldesc)
        Me.Panel1.Controls.Add(Me.lblsub)
        Me.Panel1.Controls.Add(Me.lblestado)
        Me.Panel1.Controls.Add(Me.lblfecha)
        Me.Panel1.Controls.Add(Me.Label8)
        Me.Panel1.Controls.Add(Me.DataGridView1)
        Me.Panel1.Controls.Add(Me.lblRTN)
        Me.Panel1.Controls.Add(Me.lblNombreCliente)
        Me.Panel1.Controls.Add(Me.lblrango)
        Me.Panel1.Controls.Add(Me.lblnumventa)
        Me.Panel1.Controls.Add(Me.lbllote)
        Me.Panel1.Controls.Add(Me.lblinterno)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.lblNumerofactura)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Location = New System.Drawing.Point(17, 16)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(967, 773)
        Me.Panel1.TabIndex = 0
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(716, 620)
        Me.Label13.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(126, 20)
        Me.Label13.TabIndex = 29
        Me.Label13.Text = "Total a pagar:"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(473, 620)
        Me.Label12.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(101, 20)
        Me.Label12.TabIndex = 28
        Me.Label12.Text = "Impuestos:"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(252, 620)
        Me.Label11.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(105, 20)
        Me.Label11.TabIndex = 27
        Me.Label11.Text = "Descuento:"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(23, 620)
        Me.Label10.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(84, 20)
        Me.Label10.TabIndex = 26
        Me.Label10.Text = "Subtotal:"
        '
        'Label9
        '
        Me.Label9.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(743, 294)
        Me.Label9.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(73, 20)
        Me.Label9.TabIndex = 25
        Me.Label9.Text = "Estado:"
        '
        'lblcajero
        '
        Me.lblcajero.AutoSize = True
        Me.lblcajero.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblcajero.Location = New System.Drawing.Point(220, 294)
        Me.lblcajero.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblcajero.Name = "lblcajero"
        Me.lblcajero.Size = New System.Drawing.Size(36, 25)
        Me.lblcajero.TabIndex = 24
        Me.lblcajero.Text = " -- "
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(21, 294)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(111, 25)
        Me.Label4.TabIndex = 23
        Me.Label4.Text = "Cajero(a):"
        '
        'lbltotal
        '
        Me.lbltotal.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.lbltotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbltotal.ForeColor = System.Drawing.Color.Lime
        Me.lbltotal.Location = New System.Drawing.Point(715, 640)
        Me.lbltotal.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbltotal.Name = "lbltotal"
        Me.lbltotal.Size = New System.Drawing.Size(225, 65)
        Me.lbltotal.TabIndex = 22
        Me.lbltotal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblimp
        '
        Me.lblimp.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.lblimp.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblimp.ForeColor = System.Drawing.Color.Lime
        Me.lblimp.Location = New System.Drawing.Point(472, 640)
        Me.lblimp.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblimp.Name = "lblimp"
        Me.lblimp.Size = New System.Drawing.Size(217, 65)
        Me.lblimp.TabIndex = 21
        Me.lblimp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbldesc
        '
        Me.lbldesc.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.lbldesc.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbldesc.ForeColor = System.Drawing.Color.Lime
        Me.lbldesc.Location = New System.Drawing.Point(251, 640)
        Me.lbldesc.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbldesc.Name = "lbldesc"
        Me.lbldesc.Size = New System.Drawing.Size(197, 65)
        Me.lbldesc.TabIndex = 20
        Me.lbldesc.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblsub
        '
        Me.lblsub.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.lblsub.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblsub.ForeColor = System.Drawing.Color.Lime
        Me.lblsub.Location = New System.Drawing.Point(23, 640)
        Me.lblsub.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblsub.Name = "lblsub"
        Me.lblsub.Size = New System.Drawing.Size(197, 65)
        Me.lblsub.TabIndex = 19
        Me.lblsub.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblestado
        '
        Me.lblestado.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblestado.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.lblestado.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblestado.ForeColor = System.Drawing.Color.Lime
        Me.lblestado.Location = New System.Drawing.Point(743, 314)
        Me.lblestado.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblestado.Name = "lblestado"
        Me.lblestado.Size = New System.Drawing.Size(197, 37)
        Me.lblestado.TabIndex = 18
        Me.lblestado.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblfecha
        '
        Me.lblfecha.AutoSize = True
        Me.lblfecha.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblfecha.Location = New System.Drawing.Point(220, 257)
        Me.lblfecha.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblfecha.Name = "lblfecha"
        Me.lblfecha.Size = New System.Drawing.Size(36, 25)
        Me.lblfecha.TabIndex = 17
        Me.lblfecha.Text = " -- "
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(21, 257)
        Me.Label8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(79, 25)
        Me.Label8.TabIndex = 16
        Me.Label8.Text = "Fecha:"
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(27, 354)
        Me.DataGridView1.Margin = New System.Windows.Forms.Padding(4)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.RowTemplate.Height = 30
        Me.DataGridView1.Size = New System.Drawing.Size(913, 225)
        Me.DataGridView1.TabIndex = 15
        '
        'lblRTN
        '
        Me.lblRTN.AutoSize = True
        Me.lblRTN.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRTN.Location = New System.Drawing.Point(220, 218)
        Me.lblRTN.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblRTN.Name = "lblRTN"
        Me.lblRTN.Size = New System.Drawing.Size(36, 25)
        Me.lblRTN.TabIndex = 14
        Me.lblRTN.Text = " -- "
        '
        'lblNombreCliente
        '
        Me.lblNombreCliente.AutoSize = True
        Me.lblNombreCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNombreCliente.Location = New System.Drawing.Point(220, 177)
        Me.lblNombreCliente.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblNombreCliente.Name = "lblNombreCliente"
        Me.lblNombreCliente.Size = New System.Drawing.Size(36, 25)
        Me.lblNombreCliente.TabIndex = 13
        Me.lblNombreCliente.Text = " -- "
        '
        'lblrango
        '
        Me.lblrango.AutoSize = True
        Me.lblrango.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblrango.Location = New System.Drawing.Point(220, 140)
        Me.lblrango.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblrango.Name = "lblrango"
        Me.lblrango.Size = New System.Drawing.Size(36, 25)
        Me.lblrango.TabIndex = 12
        Me.lblrango.Text = " -- "
        '
        'lblnumventa
        '
        Me.lblnumventa.AutoSize = True
        Me.lblnumventa.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblnumventa.Location = New System.Drawing.Point(220, 98)
        Me.lblnumventa.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblnumventa.Name = "lblnumventa"
        Me.lblnumventa.Size = New System.Drawing.Size(36, 25)
        Me.lblnumventa.TabIndex = 10
        Me.lblnumventa.Text = " -- "
        '
        'lbllote
        '
        Me.lbllote.AutoSize = True
        Me.lbllote.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbllote.Location = New System.Drawing.Point(220, 58)
        Me.lbllote.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbllote.Name = "lbllote"
        Me.lbllote.Size = New System.Drawing.Size(36, 25)
        Me.lbllote.TabIndex = 9
        Me.lbllote.Text = " -- "
        '
        'lblinterno
        '
        Me.lblinterno.AutoSize = True
        Me.lblinterno.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblinterno.Location = New System.Drawing.Point(220, 22)
        Me.lblinterno.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblinterno.Name = "lblinterno"
        Me.lblinterno.Size = New System.Drawing.Size(36, 25)
        Me.lblinterno.TabIndex = 8
        Me.lblinterno.Text = " -- "
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(21, 218)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(62, 25)
        Me.Label7.TabIndex = 7
        Me.Label7.Text = "RTN:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(21, 177)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(168, 25)
        Me.Label6.TabIndex = 6
        Me.Label6.Text = "Nombre Cliente:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(21, 140)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(81, 25)
        Me.Label5.TabIndex = 5
        Me.Label5.Text = "Rango:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(21, 98)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(128, 25)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Num. venta:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(21, 22)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(98, 25)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "#Interno:"
        '
        'lblNumerofactura
        '
        Me.lblNumerofactura.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblNumerofactura.AutoSize = True
        Me.lblNumerofactura.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNumerofactura.Location = New System.Drawing.Point(633, 12)
        Me.lblNumerofactura.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblNumerofactura.Name = "lblNumerofactura"
        Me.lblNumerofactura.Size = New System.Drawing.Size(45, 29)
        Me.lblNumerofactura.TabIndex = 1
        Me.lblNumerofactura.Text = " -- "
        Me.lblNumerofactura.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(21, 58)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(150, 25)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Lote de venta:"
        '
        'btnpago
        '
        Me.btnpago.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnpago.BackColor = System.Drawing.Color.Transparent
        Me.btnpago.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnpago.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnpago.Image = Global.POSGDC.My.Resources.Resources.prohibition
        Me.btnpago.Location = New System.Drawing.Point(1020, 15)
        Me.btnpago.Margin = New System.Windows.Forms.Padding(4)
        Me.btnpago.Name = "btnpago"
        Me.btnpago.Size = New System.Drawing.Size(196, 129)
        Me.btnpago.TabIndex = 28
        Me.btnpago.Text = "Anular factura"
        Me.btnpago.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnpago.UseVisualStyleBackColor = False
        '
        'btnReimprime
        '
        Me.btnReimprime.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnReimprime.BackColor = System.Drawing.Color.Transparent
        Me.btnReimprime.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnReimprime.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnReimprime.Image = Global.POSGDC.My.Resources.Resources.print
        Me.btnReimprime.Location = New System.Drawing.Point(1020, 177)
        Me.btnReimprime.Margin = New System.Windows.Forms.Padding(4)
        Me.btnReimprime.Name = "btnReimprime"
        Me.btnReimprime.Size = New System.Drawing.Size(196, 134)
        Me.btnReimprime.TabIndex = 29
        Me.btnReimprime.Text = "Reimpimir"
        Me.btnReimprime.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnReimprime.UseVisualStyleBackColor = False
        '
        'btnregresar
        '
        Me.btnregresar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnregresar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnregresar.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnregresar.Image = Global.POSGDC.My.Resources.Resources.back
        Me.btnregresar.Location = New System.Drawing.Point(1020, 522)
        Me.btnregresar.Margin = New System.Windows.Forms.Padding(4)
        Me.btnregresar.Name = "btnregresar"
        Me.btnregresar.Size = New System.Drawing.Size(196, 134)
        Me.btnregresar.TabIndex = 30
        Me.btnregresar.Text = "Regresar"
        Me.btnregresar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnregresar.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button2.BackColor = System.Drawing.Color.Transparent
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.Image = Global.POSGDC.My.Resources.Resources.printer
        Me.Button2.Location = New System.Drawing.Point(1020, 346)
        Me.Button2.Margin = New System.Windows.Forms.Padding(4)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(196, 134)
        Me.Button2.TabIndex = 31
        Me.Button2.Text = "Original"
        Me.Button2.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button2.UseVisualStyleBackColor = False
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
        'frmVistaFactura
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1259, 804)
        Me.ControlBox = False
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.btnregresar)
        Me.Controls.Add(Me.btnReimprime)
        Me.Controls.Add(Me.btnpago)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmVistaFactura"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Vista Factura"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents btnpago As Button
    Friend WithEvents btnReimprime As Button
    Friend WithEvents btnregresar As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents lblNumerofactura As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents lblRTN As Label
    Friend WithEvents lblNombreCliente As Label
    Friend WithEvents lblrango As Label
    Friend WithEvents lblnumventa As Label
    Friend WithEvents lbllote As Label
    Friend WithEvents lblinterno As Label
    Friend WithEvents lblfecha As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents lblestado As Label
    Friend WithEvents lbltotal As Label
    Friend WithEvents lblimp As Label
    Friend WithEvents lbldesc As Label
    Friend WithEvents lblsub As Label
    Friend WithEvents lblcajero As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents PrintDocument1 As Printing.PrintDocument
    Friend WithEvents PrintPreviewDialog1 As PrintPreviewDialog
End Class
