<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmVenta
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmVenta))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btncargalista = New System.Windows.Forms.Button()
        Me.lstventaespera = New System.Windows.Forms.ListBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lblAlmacen = New System.Windows.Forms.Label()
        Me.lblUsuario = New System.Windows.Forms.Label()
        Me.btnpago = New System.Windows.Forms.Button()
        Me.btnespera = New System.Windows.Forms.Button()
        Me.btncancela = New System.Windows.Forms.Button()
        Me.lblnomlo = New System.Windows.Forms.Label()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.btnDisponible = New System.Windows.Forms.Button()
        Me.btnConsultasaldo = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.lblnombrecliente = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtcod = New System.Windows.Forms.TextBox()
        Me.cmbTipo = New System.Windows.Forms.ComboBox()
        Me.lblSub = New System.Windows.Forms.Label()
        Me.lblimp = New System.Windows.Forms.Label()
        Me.lbltotal = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnbeneficio = New System.Windows.Forms.Button()
        Me.btnar = New System.Windows.Forms.Button()
        Me.ListView1 = New System.Windows.Forms.ListView()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.Cantidad = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Descripcion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Subtotal = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Impuesto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.precio = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.idmaterialcentro = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.factorimpues = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cuanto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.preciovent = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.InventarioNegativo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Disponible = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.txtCodigo = New System.Windows.Forms.TextBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnReciboPreventa = New System.Windows.Forms.Button()
        Me.btnActualizarInventario = New System.Windows.Forms.Button()
        Me.lblboletapreventa = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.btn_reimprimir = New System.Windows.Forms.Button()
        Me.lblnombrefactura = New System.Windows.Forms.Label()
        Me.lbltipoventa = New System.Windows.Forms.Label()
        Me.txtbusqeda = New System.Windows.Forms.TextBox()
        Me.PrintDocument1 = New System.Drawing.Printing.PrintDocument()
        Me.PrintDialog1 = New System.Windows.Forms.PrintDialog()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btncargalista)
        Me.GroupBox1.Controls.Add(Me.lstventaespera)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(4, 4)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox1.Size = New System.Drawing.Size(314, 320)
        Me.GroupBox1.TabIndex = 15
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Ventas En espera"
        '
        'btncargalista
        '
        Me.btncargalista.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btncargalista.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btncargalista.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btncargalista.Location = New System.Drawing.Point(19, 269)
        Me.btncargalista.Margin = New System.Windows.Forms.Padding(4)
        Me.btncargalista.Name = "btncargalista"
        Me.btncargalista.Size = New System.Drawing.Size(281, 43)
        Me.btncargalista.TabIndex = 46
        Me.btncargalista.Text = "Cargar Lista Espera"
        Me.btncargalista.UseVisualStyleBackColor = True
        '
        'lstventaespera
        '
        Me.lstventaespera.FormattingEnabled = True
        Me.lstventaespera.ItemHeight = 16
        Me.lstventaespera.Location = New System.Drawing.Point(18, 32)
        Me.lstventaespera.Margin = New System.Windows.Forms.Padding(4)
        Me.lstventaespera.Name = "lstventaespera"
        Me.lstventaespera.Size = New System.Drawing.Size(279, 228)
        Me.lstventaespera.TabIndex = 0
        '
        'Label4
        '
        Me.Label4.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(330, 124)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(114, 29)
        Me.Label4.TabIndex = 24
        Me.Label4.Text = "Material:"
        '
        'lblAlmacen
        '
        Me.lblAlmacen.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblAlmacen.AutoSize = True
        Me.lblAlmacen.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAlmacen.Location = New System.Drawing.Point(345, 19)
        Me.lblAlmacen.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblAlmacen.Name = "lblAlmacen"
        Me.lblAlmacen.Size = New System.Drawing.Size(45, 29)
        Me.lblAlmacen.TabIndex = 25
        Me.lblAlmacen.Text = " -- "
        '
        'lblUsuario
        '
        Me.lblUsuario.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblUsuario.AutoSize = True
        Me.lblUsuario.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUsuario.Location = New System.Drawing.Point(345, 65)
        Me.lblUsuario.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblUsuario.Name = "lblUsuario"
        Me.lblUsuario.Size = New System.Drawing.Size(45, 29)
        Me.lblUsuario.TabIndex = 26
        Me.lblUsuario.Text = " -- "
        '
        'btnpago
        '
        Me.btnpago.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnpago.BackColor = System.Drawing.Color.Transparent
        Me.btnpago.Enabled = False
        Me.btnpago.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnpago.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnpago.Image = Global.POSGDC.My.Resources.Resources.money
        Me.btnpago.Location = New System.Drawing.Point(169, 723)
        Me.btnpago.Margin = New System.Windows.Forms.Padding(4)
        Me.btnpago.Name = "btnpago"
        Me.btnpago.Size = New System.Drawing.Size(164, 131)
        Me.btnpago.TabIndex = 27
        Me.btnpago.Text = "Pago (F2)"
        Me.btnpago.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnpago.UseVisualStyleBackColor = False
        '
        'btnespera
        '
        Me.btnespera.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnespera.BackColor = System.Drawing.Color.Transparent
        Me.btnespera.Enabled = False
        Me.btnespera.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnespera.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnespera.Image = Global.POSGDC.My.Resources.Resources.hourglass__2_
        Me.btnespera.Location = New System.Drawing.Point(340, 723)
        Me.btnespera.Margin = New System.Windows.Forms.Padding(4)
        Me.btnespera.Name = "btnespera"
        Me.btnespera.Size = New System.Drawing.Size(146, 131)
        Me.btnespera.TabIndex = 28
        Me.btnespera.Text = "Espera"
        Me.btnespera.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnespera.UseVisualStyleBackColor = False
        '
        'btncancela
        '
        Me.btncancela.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btncancela.BackColor = System.Drawing.Color.Transparent
        Me.btncancela.Enabled = False
        Me.btncancela.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btncancela.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btncancela.Image = Global.POSGDC.My.Resources.Resources.cancelarventa
        Me.btncancela.Location = New System.Drawing.Point(494, 723)
        Me.btncancela.Margin = New System.Windows.Forms.Padding(4)
        Me.btncancela.Name = "btncancela"
        Me.btncancela.Size = New System.Drawing.Size(149, 131)
        Me.btncancela.TabIndex = 29
        Me.btncancela.Text = "Cancelar"
        Me.btncancela.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btncancela.UseVisualStyleBackColor = False
        '
        'lblnomlo
        '
        Me.lblnomlo.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblnomlo.AutoSize = True
        Me.lblnomlo.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblnomlo.Location = New System.Drawing.Point(34, 300)
        Me.lblnomlo.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblnomlo.Name = "lblnomlo"
        Me.lblnomlo.Size = New System.Drawing.Size(0, 24)
        Me.lblnomlo.TabIndex = 30
        '
        'Button4
        '
        Me.Button4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button4.BackColor = System.Drawing.Color.Transparent
        Me.Button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button4.Image = Global.POSGDC.My.Resources.Resources.nuevaventa
        Me.Button4.Location = New System.Drawing.Point(868, 15)
        Me.Button4.Margin = New System.Windows.Forms.Padding(4)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(196, 132)
        Me.Button4.TabIndex = 31
        Me.Button4.Text = "Nueva venta (F3)"
        Me.Button4.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button4.UseVisualStyleBackColor = False
        '
        'btnDisponible
        '
        Me.btnDisponible.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnDisponible.BackColor = System.Drawing.Color.Transparent
        Me.btnDisponible.Enabled = False
        Me.btnDisponible.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDisponible.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDisponible.Image = Global.POSGDC.My.Resources.Resources.transaction
        Me.btnDisponible.Location = New System.Drawing.Point(170, 596)
        Me.btnDisponible.Margin = New System.Windows.Forms.Padding(4)
        Me.btnDisponible.Name = "btnDisponible"
        Me.btnDisponible.Size = New System.Drawing.Size(157, 112)
        Me.btnDisponible.TabIndex = 32
        Me.btnDisponible.Text = "Recarga Carnet"
        Me.btnDisponible.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnDisponible.UseVisualStyleBackColor = False
        '
        'btnConsultasaldo
        '
        Me.btnConsultasaldo.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnConsultasaldo.BackColor = System.Drawing.Color.Transparent
        Me.btnConsultasaldo.Enabled = False
        Me.btnConsultasaldo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnConsultasaldo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnConsultasaldo.Image = Global.POSGDC.My.Resources.Resources.consultasaldo
        Me.btnConsultasaldo.Location = New System.Drawing.Point(13, 596)
        Me.btnConsultasaldo.Margin = New System.Windows.Forms.Padding(4)
        Me.btnConsultasaldo.Name = "btnConsultasaldo"
        Me.btnConsultasaldo.Size = New System.Drawing.Size(148, 112)
        Me.btnConsultasaldo.TabIndex = 33
        Me.btnConsultasaldo.Text = "Saldo Carnet"
        Me.btnConsultasaldo.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnConsultasaldo.UseVisualStyleBackColor = False
        '
        'Button1
        '
        Me.Button1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold)
        Me.Button1.Image = Global.POSGDC.My.Resources.Resources.cross
        Me.Button1.Location = New System.Drawing.Point(1462, 15)
        Me.Button1.Margin = New System.Windows.Forms.Padding(4)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(151, 132)
        Me.Button1.TabIndex = 37
        Me.Button1.Text = "Salir"
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button1.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.Button2)
        Me.GroupBox2.Controls.Add(Me.lblnombrecliente)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.txtcod)
        Me.GroupBox2.Controls.Add(Me.cmbTipo)
        Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(12, 365)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox2.Size = New System.Drawing.Size(314, 223)
        Me.GroupBox2.TabIndex = 38
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Tipo de cliente"
        '
        'Button2
        '
        Me.Button2.Enabled = False
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Location = New System.Drawing.Point(8, 160)
        Me.Button2.Margin = New System.Windows.Forms.Padding(4)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(289, 43)
        Me.Button2.TabIndex = 49
        Me.Button2.Text = "Limpiar Empleado y Beneficio"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'lblnombrecliente
        '
        Me.lblnombrecliente.AutoSize = True
        Me.lblnombrecliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblnombrecliente.Location = New System.Drawing.Point(8, 138)
        Me.lblnombrecliente.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblnombrecliente.Name = "lblnombrecliente"
        Me.lblnombrecliente.Size = New System.Drawing.Size(30, 18)
        Me.lblnombrecliente.TabIndex = 48
        Me.lblnombrecliente.Text = " -- "
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(8, 70)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(42, 20)
        Me.Label5.TabIndex = 46
        Me.Label5.Text = "Cod"
        '
        'txtcod
        '
        Me.txtcod.Enabled = False
        Me.txtcod.Location = New System.Drawing.Point(8, 95)
        Me.txtcod.Margin = New System.Windows.Forms.Padding(4)
        Me.txtcod.Name = "txtcod"
        Me.txtcod.Size = New System.Drawing.Size(298, 26)
        Me.txtcod.TabIndex = 45
        '
        'cmbTipo
        '
        Me.cmbTipo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbTipo.FormattingEnabled = True
        Me.cmbTipo.Location = New System.Drawing.Point(8, 31)
        Me.cmbTipo.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbTipo.Name = "cmbTipo"
        Me.cmbTipo.Size = New System.Drawing.Size(298, 33)
        Me.cmbTipo.TabIndex = 0
        '
        'lblSub
        '
        Me.lblSub.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblSub.BackColor = System.Drawing.Color.Black
        Me.lblSub.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSub.ForeColor = System.Drawing.Color.Lime
        Me.lblSub.Location = New System.Drawing.Point(1045, 747)
        Me.lblSub.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblSub.Name = "lblSub"
        Me.lblSub.Size = New System.Drawing.Size(200, 106)
        Me.lblSub.TabIndex = 39
        Me.lblSub.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblimp
        '
        Me.lblimp.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblimp.BackColor = System.Drawing.Color.Black
        Me.lblimp.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblimp.ForeColor = System.Drawing.Color.Lime
        Me.lblimp.Location = New System.Drawing.Point(1253, 747)
        Me.lblimp.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblimp.Name = "lblimp"
        Me.lblimp.Size = New System.Drawing.Size(179, 106)
        Me.lblimp.TabIndex = 40
        Me.lblimp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbltotal
        '
        Me.lbltotal.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbltotal.BackColor = System.Drawing.Color.Black
        Me.lbltotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbltotal.ForeColor = System.Drawing.Color.Lime
        Me.lbltotal.Location = New System.Drawing.Point(1439, 747)
        Me.lbltotal.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbltotal.Name = "lbltotal"
        Me.lbltotal.Size = New System.Drawing.Size(178, 106)
        Me.lbltotal.TabIndex = 41
        Me.lbltotal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(1045, 722)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(75, 18)
        Me.Label1.TabIndex = 42
        Me.Label1.Text = "Subtotal:"
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(1255, 722)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(91, 18)
        Me.Label2.TabIndex = 43
        Me.Label2.Text = "Impuestos:"
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(1442, 722)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(51, 18)
        Me.Label3.TabIndex = 44
        Me.Label3.Text = "Total:"
        '
        'btnbeneficio
        '
        Me.btnbeneficio.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnbeneficio.BackColor = System.Drawing.Color.Transparent
        Me.btnbeneficio.Enabled = False
        Me.btnbeneficio.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnbeneficio.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnbeneficio.Image = Global.POSGDC.My.Resources.Resources.empleados
        Me.btnbeneficio.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnbeneficio.Location = New System.Drawing.Point(12, 722)
        Me.btnbeneficio.Margin = New System.Windows.Forms.Padding(4)
        Me.btnbeneficio.Name = "btnbeneficio"
        Me.btnbeneficio.Size = New System.Drawing.Size(149, 131)
        Me.btnbeneficio.TabIndex = 45
        Me.btnbeneficio.Text = "Beneficios (F12)"
        Me.btnbeneficio.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnbeneficio.UseVisualStyleBackColor = False
        '
        'btnar
        '
        Me.btnar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnar.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold)
        Me.btnar.Image = Global.POSGDC.My.Resources.Resources.bill
        Me.btnar.Location = New System.Drawing.Point(1072, 16)
        Me.btnar.Margin = New System.Windows.Forms.Padding(4)
        Me.btnar.Name = "btnar"
        Me.btnar.Size = New System.Drawing.Size(197, 132)
        Me.btnar.TabIndex = 46
        Me.btnar.Text = "Facturas (F5)"
        Me.btnar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnar.UseVisualStyleBackColor = True
        '
        'ListView1
        '
        Me.ListView1.Alignment = System.Windows.Forms.ListViewAlignment.[Default]
        Me.ListView1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ListView1.Enabled = False
        Me.ListView1.Location = New System.Drawing.Point(1128, 202)
        Me.ListView1.Margin = New System.Windows.Forms.Padding(4)
        Me.ListView1.Name = "ListView1"
        Me.ListView1.Size = New System.Drawing.Size(486, 506)
        Me.ListView1.TabIndex = 56
        Me.ListView1.UseCompatibleStateImageBehavior = False
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Cantidad, Me.Descripcion, Me.Subtotal, Me.Impuesto, Me.precio, Me.idmaterialcentro, Me.factorimpues, Me.cuanto, Me.preciovent, Me.InventarioNegativo, Me.Disponible})
        Me.DataGridView1.Location = New System.Drawing.Point(335, 202)
        Me.DataGridView1.Margin = New System.Windows.Forms.Padding(4)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowTemplate.Height = 30
        Me.DataGridView1.Size = New System.Drawing.Size(785, 506)
        Me.DataGridView1.TabIndex = 53
        '
        'Cantidad
        '
        Me.Cantidad.HeaderText = "Cantidad"
        Me.Cantidad.Name = "Cantidad"
        Me.Cantidad.ReadOnly = True
        '
        'Descripcion
        '
        Me.Descripcion.HeaderText = "Descripcion"
        Me.Descripcion.Name = "Descripcion"
        Me.Descripcion.ReadOnly = True
        '
        'Subtotal
        '
        Me.Subtotal.HeaderText = "Subtotal"
        Me.Subtotal.Name = "Subtotal"
        Me.Subtotal.ReadOnly = True
        '
        'Impuesto
        '
        Me.Impuesto.HeaderText = "Impuesto"
        Me.Impuesto.Name = "Impuesto"
        Me.Impuesto.ReadOnly = True
        '
        'precio
        '
        Me.precio.HeaderText = "precio"
        Me.precio.Name = "precio"
        Me.precio.ReadOnly = True
        '
        'idmaterialcentro
        '
        Me.idmaterialcentro.HeaderText = "idmaterialcentro"
        Me.idmaterialcentro.Name = "idmaterialcentro"
        Me.idmaterialcentro.Visible = False
        '
        'factorimpues
        '
        Me.factorimpues.HeaderText = "factorimpues"
        Me.factorimpues.Name = "factorimpues"
        Me.factorimpues.Visible = False
        '
        'cuanto
        '
        Me.cuanto.HeaderText = "cuanto"
        Me.cuanto.Name = "cuanto"
        Me.cuanto.ReadOnly = True
        Me.cuanto.Visible = False
        '
        'preciovent
        '
        Me.preciovent.HeaderText = "preciovent"
        Me.preciovent.Name = "preciovent"
        Me.preciovent.ReadOnly = True
        Me.preciovent.Visible = False
        '
        'InventarioNegativo
        '
        Me.InventarioNegativo.HeaderText = "negativo"
        Me.InventarioNegativo.Name = "InventarioNegativo"
        Me.InventarioNegativo.ReadOnly = True
        Me.InventarioNegativo.Visible = False
        '
        'Disponible
        '
        Me.Disponible.HeaderText = "Disponible"
        Me.Disponible.Name = "Disponible"
        Me.Disponible.ReadOnly = True
        '
        'txtCodigo
        '
        Me.txtCodigo.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtCodigo.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCodigo.Location = New System.Drawing.Point(335, 159)
        Me.txtCodigo.Margin = New System.Windows.Forms.Padding(4)
        Me.txtCodigo.Name = "txtCodigo"
        Me.txtCodigo.Size = New System.Drawing.Size(785, 34)
        Me.txtCodigo.TabIndex = 54
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.btnReciboPreventa)
        Me.Panel1.Controls.Add(Me.btnActualizarInventario)
        Me.Panel1.Controls.Add(Me.lblboletapreventa)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.btn_reimprimir)
        Me.Panel1.Controls.Add(Me.btnDisponible)
        Me.Panel1.Controls.Add(Me.lblnombrefactura)
        Me.Panel1.Controls.Add(Me.lbltipoventa)
        Me.Panel1.Controls.Add(Me.txtbusqeda)
        Me.Panel1.Controls.Add(Me.txtCodigo)
        Me.Panel1.Controls.Add(Me.DataGridView1)
        Me.Panel1.Controls.Add(Me.ListView1)
        Me.Panel1.Controls.Add(Me.btnar)
        Me.Panel1.Controls.Add(Me.btnbeneficio)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.lbltotal)
        Me.Panel1.Controls.Add(Me.lblimp)
        Me.Panel1.Controls.Add(Me.lblSub)
        Me.Panel1.Controls.Add(Me.GroupBox2)
        Me.Panel1.Controls.Add(Me.Button1)
        Me.Panel1.Controls.Add(Me.btnConsultasaldo)
        Me.Panel1.Controls.Add(Me.Button4)
        Me.Panel1.Controls.Add(Me.lblnomlo)
        Me.Panel1.Controls.Add(Me.btncancela)
        Me.Panel1.Controls.Add(Me.btnespera)
        Me.Panel1.Controls.Add(Me.btnpago)
        Me.Panel1.Controls.Add(Me.lblUsuario)
        Me.Panel1.Controls.Add(Me.lblAlmacen)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.GroupBox1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1629, 877)
        Me.Panel1.TabIndex = 0
        '
        'btnReciboPreventa
        '
        Me.btnReciboPreventa.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnReciboPreventa.BackColor = System.Drawing.Color.Transparent
        Me.btnReciboPreventa.Enabled = False
        Me.btnReciboPreventa.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnReciboPreventa.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnReciboPreventa.Image = Global.POSGDC.My.Resources.Resources.payment_method
        Me.btnReciboPreventa.Location = New System.Drawing.Point(651, 723)
        Me.btnReciboPreventa.Margin = New System.Windows.Forms.Padding(4)
        Me.btnReciboPreventa.Name = "btnReciboPreventa"
        Me.btnReciboPreventa.Size = New System.Drawing.Size(193, 131)
        Me.btnReciboPreventa.TabIndex = 64
        Me.btnReciboPreventa.Text = "Recibo Preventa"
        Me.btnReciboPreventa.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnReciboPreventa.UseVisualStyleBackColor = False
        '
        'btnActualizarInventario
        '
        Me.btnActualizarInventario.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnActualizarInventario.Enabled = False
        Me.btnActualizarInventario.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnActualizarInventario.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold)
        Me.btnActualizarInventario.Image = Global.POSGDC.My.Resources.Resources.exchange
        Me.btnActualizarInventario.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnActualizarInventario.Location = New System.Drawing.Point(851, 723)
        Me.btnActualizarInventario.Name = "btnActualizarInventario"
        Me.btnActualizarInventario.Size = New System.Drawing.Size(147, 130)
        Me.btnActualizarInventario.TabIndex = 63
        Me.btnActualizarInventario.Text = "Actualizar Inventario"
        Me.btnActualizarInventario.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnActualizarInventario.UseVisualStyleBackColor = True
        '
        'lblboletapreventa
        '
        Me.lblboletapreventa.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblboletapreventa.AutoSize = True
        Me.lblboletapreventa.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold)
        Me.lblboletapreventa.Location = New System.Drawing.Point(877, 782)
        Me.lblboletapreventa.Name = "lblboletapreventa"
        Me.lblboletapreventa.Size = New System.Drawing.Size(155, 17)
        Me.lblboletapreventa.TabIndex = 62
        Me.lblboletapreventa.Text = "F6 Boletas Preventa"
        Me.lblboletapreventa.Visible = False
        '
        'Label6
        '
        Me.Label6.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(865, 747)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(167, 17)
        Me.Label6.TabIndex = 61
        Me.Label6.Text = "F1 Crédito Empleados"
        '
        'btn_reimprimir
        '
        Me.btn_reimprimir.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_reimprimir.BackColor = System.Drawing.Color.Transparent
        Me.btn_reimprimir.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_reimprimir.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_reimprimir.Image = Global.POSGDC.My.Resources.Resources.printer1
        Me.btn_reimprimir.Location = New System.Drawing.Point(1277, 15)
        Me.btn_reimprimir.Margin = New System.Windows.Forms.Padding(4)
        Me.btn_reimprimir.Name = "btn_reimprimir"
        Me.btn_reimprimir.Size = New System.Drawing.Size(177, 132)
        Me.btn_reimprimir.TabIndex = 60
        Me.btn_reimprimir.Text = "Reimprimir (F4)"
        Me.btn_reimprimir.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_reimprimir.UseVisualStyleBackColor = False
        '
        'lblnombrefactura
        '
        Me.lblnombrefactura.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblnombrefactura.AutoSize = True
        Me.lblnombrefactura.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold)
        Me.lblnombrefactura.ForeColor = System.Drawing.Color.Red
        Me.lblnombrefactura.Location = New System.Drawing.Point(561, 126)
        Me.lblnombrefactura.Name = "lblnombrefactura"
        Me.lblnombrefactura.Size = New System.Drawing.Size(207, 29)
        Me.lblnombrefactura.TabIndex = 59
        Me.lblnombrefactura.Text = "Numero Factura:"
        '
        'lbltipoventa
        '
        Me.lbltipoventa.AutoSize = True
        Me.lbltipoventa.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold)
        Me.lbltipoventa.ForeColor = System.Drawing.Color.Red
        Me.lbltipoventa.Location = New System.Drawing.Point(846, 19)
        Me.lbltipoventa.Name = "lbltipoventa"
        Me.lbltipoventa.Size = New System.Drawing.Size(79, 29)
        Me.lbltipoventa.TabIndex = 58
        Me.lbltipoventa.Text = "Venta"
        '
        'txtbusqeda
        '
        Me.txtbusqeda.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtbusqeda.Enabled = False
        Me.txtbusqeda.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtbusqeda.Location = New System.Drawing.Point(1128, 159)
        Me.txtbusqeda.Margin = New System.Windows.Forms.Padding(4)
        Me.txtbusqeda.Name = "txtbusqeda"
        Me.txtbusqeda.Size = New System.Drawing.Size(485, 34)
        Me.txtbusqeda.TabIndex = 57
        '
        'PrintDialog1
        '
        Me.PrintDialog1.UseEXDialog = True
        '
        'frmVenta
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(120.0!, 120.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoSize = True
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1629, 877)
        Me.ControlBox = False
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "frmVenta"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "POSGDC de Ventas"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents lstventaespera As ListBox
    Friend WithEvents Label4 As Label
    Friend WithEvents lblAlmacen As Label
    Friend WithEvents lblUsuario As Label
    Friend WithEvents btnpago As Button
    Friend WithEvents btnespera As Button
    Friend WithEvents btncancela As Button
    Friend WithEvents lblnomlo As Label
    Friend WithEvents Button4 As Button
    Friend WithEvents btnDisponible As Button
    Friend WithEvents btnConsultasaldo As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents Button2 As Button
    Friend WithEvents lblnombrecliente As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents txtcod As TextBox
    Friend WithEvents cmbTipo As ComboBox
    Friend WithEvents lblSub As Label
    Friend WithEvents lblimp As Label
    Friend WithEvents lbltotal As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents btnbeneficio As Button
    Friend WithEvents btnar As Button
    Friend WithEvents ListView1 As ListView
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents txtCodigo As TextBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents txtbusqeda As TextBox
    Friend WithEvents lbltipoventa As Label
    Friend WithEvents lblnombrefactura As Label
    Friend WithEvents btn_reimprimir As Button
    Friend WithEvents PrintDocument1 As Printing.PrintDocument
    Friend WithEvents PrintDialog1 As PrintDialog
    Friend WithEvents lblboletapreventa As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents btncargalista As Button
    Friend WithEvents Cantidad As DataGridViewTextBoxColumn
    Friend WithEvents Descripcion As DataGridViewTextBoxColumn
    Friend WithEvents Subtotal As DataGridViewTextBoxColumn
    Friend WithEvents Impuesto As DataGridViewTextBoxColumn
    Friend WithEvents precio As DataGridViewTextBoxColumn
    Friend WithEvents idmaterialcentro As DataGridViewTextBoxColumn
    Friend WithEvents factorimpues As DataGridViewTextBoxColumn
    Friend WithEvents cuanto As DataGridViewTextBoxColumn
    Friend WithEvents preciovent As DataGridViewTextBoxColumn
    Friend WithEvents InventarioNegativo As DataGridViewTextBoxColumn
    Friend WithEvents Disponible As DataGridViewTextBoxColumn
    Friend WithEvents btnActualizarInventario As Button
    Friend WithEvents btnReciboPreventa As Button
End Class
