<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frm_recargaWildcard
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_recargaWildcard))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.rdbRecargas = New System.Windows.Forms.RadioButton()
        Me.txtCodigoCarnet = New System.Windows.Forms.TextBox()
        Me.lblcodigowildcard = New System.Windows.Forms.Label()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.dgvHistorial = New System.Windows.Forms.DataGridView()
        Me.lblSaldo = New System.Windows.Forms.Label()
        Me.rdbCompras = New System.Windows.Forms.RadioButton()
        Me.fecha = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.monto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.factura = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Panel1.SuspendLayout()
        Me.Panel4.SuspendLayout()
        CType(Me.dgvHistorial, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.rdbCompras)
        Me.Panel1.Controls.Add(Me.lblSaldo)
        Me.Panel1.Controls.Add(Me.rdbRecargas)
        Me.Panel1.Controls.Add(Me.txtCodigoCarnet)
        Me.Panel1.Controls.Add(Me.lblcodigowildcard)
        Me.Panel1.Location = New System.Drawing.Point(15, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(643, 156)
        Me.Panel1.TabIndex = 12
        '
        'rdbRecargas
        '
        Me.rdbRecargas.AutoSize = True
        Me.rdbRecargas.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold)
        Me.rdbRecargas.Location = New System.Drawing.Point(320, 107)
        Me.rdbRecargas.Name = "rdbRecargas"
        Me.rdbRecargas.Size = New System.Drawing.Size(268, 29)
        Me.rdbRecargas.TabIndex = 16
        Me.rdbRecargas.TabStop = True
        Me.rdbRecargas.Text = "Ver historial de recargas"
        Me.rdbRecargas.UseVisualStyleBackColor = True
        '
        'txtCodigoCarnet
        '
        Me.txtCodigoCarnet.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCodigoCarnet.Location = New System.Drawing.Point(190, 15)
        Me.txtCodigoCarnet.Margin = New System.Windows.Forms.Padding(4)
        Me.txtCodigoCarnet.Name = "txtCodigoCarnet"
        Me.txtCodigoCarnet.Size = New System.Drawing.Size(395, 30)
        Me.txtCodigoCarnet.TabIndex = 13
        '
        'lblcodigowildcard
        '
        Me.lblcodigowildcard.AutoSize = True
        Me.lblcodigowildcard.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold)
        Me.lblcodigowildcard.Location = New System.Drawing.Point(9, 15)
        Me.lblcodigowildcard.Name = "lblcodigowildcard"
        Me.lblcodigowildcard.Size = New System.Drawing.Size(159, 25)
        Me.lblcodigowildcard.TabIndex = 12
        Me.lblcodigowildcard.Text = "Codigo Carnet:"
        '
        'Panel4
        '
        Me.Panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel4.Controls.Add(Me.dgvHistorial)
        Me.Panel4.Location = New System.Drawing.Point(15, 162)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(643, 383)
        Me.Panel4.TabIndex = 15
        '
        'dgvHistorial
        '
        Me.dgvHistorial.AllowUserToAddRows = False
        Me.dgvHistorial.AllowUserToDeleteRows = False
        Me.dgvHistorial.AllowUserToResizeRows = False
        Me.dgvHistorial.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvHistorial.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvHistorial.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.fecha, Me.monto, Me.factura})
        Me.dgvHistorial.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvHistorial.Location = New System.Drawing.Point(0, 0)
        Me.dgvHistorial.Name = "dgvHistorial"
        Me.dgvHistorial.RowTemplate.Height = 24
        Me.dgvHistorial.Size = New System.Drawing.Size(641, 381)
        Me.dgvHistorial.TabIndex = 0
        '
        'lblSaldo
        '
        Me.lblSaldo.AutoSize = True
        Me.lblSaldo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold)
        Me.lblSaldo.Location = New System.Drawing.Point(9, 65)
        Me.lblSaldo.Name = "lblSaldo"
        Me.lblSaldo.Size = New System.Drawing.Size(242, 25)
        Me.lblSaldo.TabIndex = 18
        Me.lblSaldo.Text = "Saldo Disponible: L0.00"
        '
        'rdbCompras
        '
        Me.rdbCompras.AutoSize = True
        Me.rdbCompras.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold)
        Me.rdbCompras.Location = New System.Drawing.Point(14, 107)
        Me.rdbCompras.Name = "rdbCompras"
        Me.rdbCompras.Size = New System.Drawing.Size(266, 29)
        Me.rdbCompras.TabIndex = 19
        Me.rdbCompras.TabStop = True
        Me.rdbCompras.Text = "Ver historial de compras"
        Me.rdbCompras.UseVisualStyleBackColor = True
        '
        'fecha
        '
        Me.fecha.HeaderText = "Fecha"
        Me.fecha.Name = "fecha"
        Me.fecha.ReadOnly = True
        '
        'monto
        '
        Me.monto.HeaderText = "Monto"
        Me.monto.Name = "monto"
        Me.monto.ReadOnly = True
        '
        'factura
        '
        Me.factura.HeaderText = "Factura"
        Me.factura.Name = "factura"
        Me.factura.ReadOnly = True
        '
        'frm_recargaWildcard
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(675, 584)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frm_recargaWildcard"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Consulta y Recarga WildCard"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        CType(Me.dgvHistorial, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents txtCodigoCarnet As TextBox
    Friend WithEvents lblcodigowildcard As Label
    Friend WithEvents Panel4 As Panel
    Friend WithEvents rdbRecargas As RadioButton
    Friend WithEvents dgvHistorial As DataGridView
    Friend WithEvents lblSaldo As Label
    Friend WithEvents rdbCompras As RadioButton
    Friend WithEvents fecha As DataGridViewTextBoxColumn
    Friend WithEvents monto As DataGridViewTextBoxColumn
    Friend WithEvents factura As DataGridViewTextBoxColumn
End Class
