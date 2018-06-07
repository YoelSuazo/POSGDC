<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class POSVENTA
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(POSVENTA))
        Me.Button3 = New System.Windows.Forms.Button()
        Me.btnLoteventas = New System.Windows.Forms.Button()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.lblNombreusuario = New System.Windows.Forms.Label()
        Me.lblAlmacen = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.lblinfoperfil = New System.Windows.Forms.Label()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Button3
        '
        Me.Button3.BackColor = System.Drawing.Color.Transparent
        Me.Button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button3.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button3.Image = Global.POSGDC.My.Resources.Resources.file
        Me.Button3.Location = New System.Drawing.Point(298, 391)
        Me.Button3.Margin = New System.Windows.Forms.Padding(4)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(414, 216)
        Me.Button3.TabIndex = 2
        Me.Button3.Text = "Anulación y reimpresion"
        Me.Button3.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button3.UseVisualStyleBackColor = False
        '
        'btnLoteventas
        '
        Me.btnLoteventas.BackColor = System.Drawing.Color.Transparent
        Me.btnLoteventas.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLoteventas.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLoteventas.Image = Global.POSGDC.My.Resources.Resources.cashier
        Me.btnLoteventas.Location = New System.Drawing.Point(10, 391)
        Me.btnLoteventas.Margin = New System.Windows.Forms.Padding(4)
        Me.btnLoteventas.Name = "btnLoteventas"
        Me.btnLoteventas.Size = New System.Drawing.Size(266, 216)
        Me.btnLoteventas.TabIndex = 0
        Me.btnLoteventas.Text = "Lote de ventas"
        Me.btnLoteventas.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnLoteventas.UseVisualStyleBackColor = False
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox1.Image = Global.POSGDC.My.Resources.Resources.logodelcampo1
        Me.PictureBox1.Location = New System.Drawing.Point(13, 13)
        Me.PictureBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(395, 370)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 1
        Me.PictureBox1.TabStop = False
        '
        'lblNombreusuario
        '
        Me.lblNombreusuario.AutoSize = True
        Me.lblNombreusuario.BackColor = System.Drawing.Color.Transparent
        Me.lblNombreusuario.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNombreusuario.Location = New System.Drawing.Point(415, 83)
        Me.lblNombreusuario.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblNombreusuario.Name = "lblNombreusuario"
        Me.lblNombreusuario.Size = New System.Drawing.Size(20, 29)
        Me.lblNombreusuario.TabIndex = 3
        Me.lblNombreusuario.Text = "."
        '
        'lblAlmacen
        '
        Me.lblAlmacen.AutoSize = True
        Me.lblAlmacen.BackColor = System.Drawing.Color.Transparent
        Me.lblAlmacen.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAlmacen.Location = New System.Drawing.Point(415, 241)
        Me.lblAlmacen.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblAlmacen.Name = "lblAlmacen"
        Me.lblAlmacen.Size = New System.Drawing.Size(20, 29)
        Me.lblAlmacen.TabIndex = 4
        Me.lblAlmacen.Text = "."
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.Transparent
        Me.Button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold)
        Me.Button1.Image = Global.POSGDC.My.Resources.Resources.logout_2
        Me.Button1.Location = New System.Drawing.Point(735, 391)
        Me.Button1.Margin = New System.Windows.Forms.Padding(4)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(250, 216)
        Me.Button1.TabIndex = 5
        Me.Button1.Text = "Cerrar sesión"
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button1.UseVisualStyleBackColor = False
        '
        'lblinfoperfil
        '
        Me.lblinfoperfil.AutoSize = True
        Me.lblinfoperfil.BackColor = System.Drawing.Color.Transparent
        Me.lblinfoperfil.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblinfoperfil.Location = New System.Drawing.Point(416, 169)
        Me.lblinfoperfil.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblinfoperfil.Name = "lblinfoperfil"
        Me.lblinfoperfil.Size = New System.Drawing.Size(14, 20)
        Me.lblinfoperfil.TabIndex = 7
        Me.lblinfoperfil.Text = "."
        '
        'POSVENTA
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1010, 622)
        Me.ControlBox = False
        Me.Controls.Add(Me.lblinfoperfil)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.lblAlmacen)
        Me.Controls.Add(Me.lblNombreusuario)
        Me.Controls.Add(Me.btnLoteventas)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.PictureBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "POSVENTA"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Principal"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Button3 As Button
    Friend WithEvents btnLoteventas As Button
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents lblNombreusuario As Label
    Friend WithEvents lblAlmacen As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents lblinfoperfil As Label
End Class
