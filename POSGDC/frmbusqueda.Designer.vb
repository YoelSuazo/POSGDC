<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmbusqueda
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmbusqueda))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.chkAnulado = New System.Windows.Forms.CheckBox()
        Me.txtbusqeda = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.btnsalir = New System.Windows.Forms.Button()
        Me.lblidrecibo = New System.Windows.Forms.Label()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.btnReimprime = New System.Windows.Forms.Button()
        Me.btnAnulaRecibo = New System.Windows.Forms.Button()
        Me.dgvRecibosPreventa = New System.Windows.Forms.DataGridView()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.dgvRecibosPreventa, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.chkAnulado)
        Me.Panel1.Controls.Add(Me.txtbusqeda)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1161, 79)
        Me.Panel1.TabIndex = 3
        '
        'chkAnulado
        '
        Me.chkAnulado.AutoSize = True
        Me.chkAnulado.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold)
        Me.chkAnulado.Location = New System.Drawing.Point(1005, 26)
        Me.chkAnulado.Name = "chkAnulado"
        Me.chkAnulado.Size = New System.Drawing.Size(125, 29)
        Me.chkAnulado.TabIndex = 4
        Me.chkAnulado.Text = "Anulados"
        Me.chkAnulado.UseVisualStyleBackColor = True
        '
        'txtbusqeda
        '
        Me.txtbusqeda.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtbusqeda.Location = New System.Drawing.Point(170, 24)
        Me.txtbusqeda.Margin = New System.Windows.Forms.Padding(4)
        Me.txtbusqeda.Name = "txtbusqeda"
        Me.txtbusqeda.Size = New System.Drawing.Size(697, 30)
        Me.txtbusqeda.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(13, 24)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(125, 25)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Descripción"
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.btnsalir)
        Me.Panel2.Controls.Add(Me.lblidrecibo)
        Me.Panel2.Controls.Add(Me.btnAceptar)
        Me.Panel2.Controls.Add(Me.btnReimprime)
        Me.Panel2.Controls.Add(Me.btnAnulaRecibo)
        Me.Panel2.Controls.Add(Me.dgvRecibosPreventa)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 79)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1161, 595)
        Me.Panel2.TabIndex = 4
        '
        'btnsalir
        '
        Me.btnsalir.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnsalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnsalir.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold)
        Me.btnsalir.Image = Global.POSGDC.My.Resources.Resources.cross
        Me.btnsalir.Location = New System.Drawing.Point(993, 427)
        Me.btnsalir.Margin = New System.Windows.Forms.Padding(4)
        Me.btnsalir.Name = "btnsalir"
        Me.btnsalir.Size = New System.Drawing.Size(151, 122)
        Me.btnsalir.TabIndex = 38
        Me.btnsalir.Text = "Salir"
        Me.btnsalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnsalir.UseVisualStyleBackColor = True
        '
        'lblidrecibo
        '
        Me.lblidrecibo.AutoSize = True
        Me.lblidrecibo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblidrecibo.Location = New System.Drawing.Point(13, 447)
        Me.lblidrecibo.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblidrecibo.Name = "lblidrecibo"
        Me.lblidrecibo.Size = New System.Drawing.Size(166, 25)
        Me.lblidrecibo.TabIndex = 33
        Me.lblidrecibo.Text = "Numero Recibo:"
        '
        'btnAceptar
        '
        Me.btnAceptar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAceptar.BackColor = System.Drawing.Color.Transparent
        Me.btnAceptar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAceptar.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAceptar.Image = Global.POSGDC.My.Resources.Resources.checked
        Me.btnAceptar.Location = New System.Drawing.Point(822, 427)
        Me.btnAceptar.Margin = New System.Windows.Forms.Padding(4)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(151, 122)
        Me.btnAceptar.TabIndex = 32
        Me.btnAceptar.Text = "Aceptar"
        Me.btnAceptar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnAceptar.UseVisualStyleBackColor = False
        '
        'btnReimprime
        '
        Me.btnReimprime.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnReimprime.BackColor = System.Drawing.Color.Transparent
        Me.btnReimprime.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnReimprime.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnReimprime.Image = Global.POSGDC.My.Resources.Resources.print
        Me.btnReimprime.Location = New System.Drawing.Point(652, 427)
        Me.btnReimprime.Margin = New System.Windows.Forms.Padding(4)
        Me.btnReimprime.Name = "btnReimprime"
        Me.btnReimprime.Size = New System.Drawing.Size(151, 122)
        Me.btnReimprime.TabIndex = 31
        Me.btnReimprime.Text = "Reimpimir"
        Me.btnReimprime.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnReimprime.UseVisualStyleBackColor = False
        '
        'btnAnulaRecibo
        '
        Me.btnAnulaRecibo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAnulaRecibo.BackColor = System.Drawing.Color.Transparent
        Me.btnAnulaRecibo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAnulaRecibo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAnulaRecibo.Image = Global.POSGDC.My.Resources.Resources.prohibition
        Me.btnAnulaRecibo.Location = New System.Drawing.Point(435, 427)
        Me.btnAnulaRecibo.Margin = New System.Windows.Forms.Padding(4)
        Me.btnAnulaRecibo.Name = "btnAnulaRecibo"
        Me.btnAnulaRecibo.Size = New System.Drawing.Size(197, 122)
        Me.btnAnulaRecibo.TabIndex = 30
        Me.btnAnulaRecibo.Text = "Anular Recibo"
        Me.btnAnulaRecibo.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnAnulaRecibo.UseVisualStyleBackColor = False
        '
        'dgvRecibosPreventa
        '
        Me.dgvRecibosPreventa.AllowUserToAddRows = False
        Me.dgvRecibosPreventa.AllowUserToDeleteRows = False
        Me.dgvRecibosPreventa.AllowUserToResizeRows = False
        Me.dgvRecibosPreventa.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvRecibosPreventa.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvRecibosPreventa.Location = New System.Drawing.Point(12, 3)
        Me.dgvRecibosPreventa.Name = "dgvRecibosPreventa"
        Me.dgvRecibosPreventa.ReadOnly = True
        Me.dgvRecibosPreventa.RowTemplate.Height = 30
        Me.dgvRecibosPreventa.Size = New System.Drawing.Size(1132, 417)
        Me.dgvRecibosPreventa.TabIndex = 3
        '
        'frmbusqueda
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1161, 674)
        Me.ControlBox = False
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmbusqueda"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Busqueda Boletas de Preventa"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.dgvRecibosPreventa, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents txtbusqeda As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Panel2 As Panel
    Friend WithEvents dgvRecibosPreventa As DataGridView
    Friend WithEvents btnAceptar As Button
    Friend WithEvents btnReimprime As Button
    Friend WithEvents btnAnulaRecibo As Button
    Friend WithEvents chkAnulado As CheckBox
    Friend WithEvents lblidrecibo As Label
    Friend WithEvents btnsalir As Button
    Friend WithEvents ToolTip1 As ToolTip
End Class
