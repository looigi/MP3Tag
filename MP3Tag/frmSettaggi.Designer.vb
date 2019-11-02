<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSettaggi
    Inherits System.Windows.Forms.Form

    'Form esegue l'override del metodo Dispose per pulire l'elenco dei componenti.
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

    'Richiesto da Progettazione Windows Form
    Private components As System.ComponentModel.IContainer

    'NOTA: la procedura che segue è richiesta da Progettazione Windows Form
    'Può essere modificata in Progettazione Windows Form.  
    'Non modificarla nell'editor del codice.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
		Me.optNormale = New System.Windows.Forms.RadioButton()
		Me.optProxy = New System.Windows.Forms.RadioButton()
		Me.Panel1 = New System.Windows.Forms.Panel()
		Me.cmdSalva = New System.Windows.Forms.Button()
		Me.Label3 = New System.Windows.Forms.Label()
		Me.txtDominio = New System.Windows.Forms.TextBox()
		Me.Label2 = New System.Windows.Forms.Label()
		Me.txtPassword = New System.Windows.Forms.TextBox()
		Me.Label1 = New System.Windows.Forms.Label()
		Me.txtUtenza = New System.Windows.Forms.TextBox()
		Me.Label4 = New System.Windows.Forms.Label()
		Me.lstCompleti = New System.Windows.Forms.ListBox()
		Me.lstContenuto = New System.Windows.Forms.ListBox()
		Me.Label5 = New System.Windows.Forms.Label()
		Me.Label6 = New System.Windows.Forms.Label()
		Me.Label7 = New System.Windows.Forms.Label()
		Me.txtCartella = New System.Windows.Forms.TextBox()
		Me.txtDiventa = New System.Windows.Forms.TextBox()
		Me.cmdSalva1 = New System.Windows.Forms.Button()
		Me.cmdSalva2 = New System.Windows.Forms.Button()
		Me.txtDestinazione = New System.Windows.Forms.TextBox()
		Me.txtContenuto = New System.Windows.Forms.TextBox()
		Me.Label8 = New System.Windows.Forms.Label()
		Me.Label9 = New System.Windows.Forms.Label()
		Me.cmdPulisce1 = New System.Windows.Forms.Button()
		Me.lblAlias1 = New System.Windows.Forms.Label()
		Me.lblAlias2 = New System.Windows.Forms.Label()
		Me.cmdPulisce2 = New System.Windows.Forms.Button()
		Me.Label10 = New System.Windows.Forms.Label()
		Me.cmdEliminaRemoti = New System.Windows.Forms.Button()
		Me.Panel1.SuspendLayout()
		Me.SuspendLayout()
		'
		'optNormale
		'
		Me.optNormale.AutoSize = True
		Me.optNormale.Location = New System.Drawing.Point(13, 13)
		Me.optNormale.Name = "optNormale"
		Me.optNormale.Size = New System.Drawing.Size(64, 17)
		Me.optNormale.TabIndex = 0
		Me.optNormale.TabStop = True
		Me.optNormale.Text = "Normale"
		Me.optNormale.UseVisualStyleBackColor = True
		'
		'optProxy
		'
		Me.optProxy.AutoSize = True
		Me.optProxy.Location = New System.Drawing.Point(185, 12)
		Me.optProxy.Name = "optProxy"
		Me.optProxy.Size = New System.Drawing.Size(51, 17)
		Me.optProxy.TabIndex = 1
		Me.optProxy.TabStop = True
		Me.optProxy.Text = "Proxy"
		Me.optProxy.UseVisualStyleBackColor = True
		'
		'Panel1
		'
		Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.Panel1.Controls.Add(Me.cmdSalva)
		Me.Panel1.Controls.Add(Me.Label3)
		Me.Panel1.Controls.Add(Me.txtDominio)
		Me.Panel1.Controls.Add(Me.Label2)
		Me.Panel1.Controls.Add(Me.txtPassword)
		Me.Panel1.Controls.Add(Me.Label1)
		Me.Panel1.Controls.Add(Me.txtUtenza)
		Me.Panel1.Location = New System.Drawing.Point(185, 36)
		Me.Panel1.Name = "Panel1"
		Me.Panel1.Size = New System.Drawing.Size(284, 113)
		Me.Panel1.TabIndex = 2
		'
		'cmdSalva
		'
		Me.cmdSalva.Location = New System.Drawing.Point(203, 83)
		Me.cmdSalva.Name = "cmdSalva"
		Me.cmdSalva.Size = New System.Drawing.Size(75, 23)
		Me.cmdSalva.TabIndex = 6
		Me.cmdSalva.Text = "Salva"
		Me.cmdSalva.UseVisualStyleBackColor = True
		'
		'Label3
		'
		Me.Label3.AutoSize = True
		Me.Label3.Location = New System.Drawing.Point(4, 63)
		Me.Label3.Name = "Label3"
		Me.Label3.Size = New System.Drawing.Size(45, 13)
		Me.Label3.TabIndex = 5
		Me.Label3.Text = "Dominio"
		'
		'txtDominio
		'
		Me.txtDominio.Location = New System.Drawing.Point(63, 56)
		Me.txtDominio.Name = "txtDominio"
		Me.txtDominio.Size = New System.Drawing.Size(220, 20)
		Me.txtDominio.TabIndex = 4
		'
		'Label2
		'
		Me.Label2.AutoSize = True
		Me.Label2.Location = New System.Drawing.Point(4, 36)
		Me.Label2.Name = "Label2"
		Me.Label2.Size = New System.Drawing.Size(53, 13)
		Me.Label2.TabIndex = 3
		Me.Label2.Text = "Password"
		'
		'txtPassword
		'
		Me.txtPassword.Location = New System.Drawing.Point(63, 30)
		Me.txtPassword.Name = "txtPassword"
		Me.txtPassword.Size = New System.Drawing.Size(216, 20)
		Me.txtPassword.TabIndex = 2
		'
		'Label1
		'
		Me.Label1.AutoSize = True
		Me.Label1.Location = New System.Drawing.Point(4, 10)
		Me.Label1.Name = "Label1"
		Me.Label1.Size = New System.Drawing.Size(41, 13)
		Me.Label1.TabIndex = 1
		Me.Label1.Text = "Utenza"
		'
		'txtUtenza
		'
		Me.txtUtenza.Location = New System.Drawing.Point(63, 4)
		Me.txtUtenza.Name = "txtUtenza"
		Me.txtUtenza.Size = New System.Drawing.Size(216, 20)
		Me.txtUtenza.TabIndex = 0
		'
		'Label4
		'
		Me.Label4.Location = New System.Drawing.Point(10, 167)
		Me.Label4.Name = "Label4"
		Me.Label4.Size = New System.Drawing.Size(459, 15)
		Me.Label4.TabIndex = 3
		Me.Label4.Text = "Alias cartelle completi"
		Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		'
		'lstCompleti
		'
		Me.lstCompleti.FormattingEnabled = True
		Me.lstCompleti.Location = New System.Drawing.Point(15, 185)
		Me.lstCompleti.Name = "lstCompleti"
		Me.lstCompleti.Size = New System.Drawing.Size(457, 95)
		Me.lstCompleti.TabIndex = 4
		'
		'lstContenuto
		'
		Me.lstContenuto.FormattingEnabled = True
		Me.lstContenuto.Location = New System.Drawing.Point(14, 336)
		Me.lstContenuto.Name = "lstContenuto"
		Me.lstContenuto.Size = New System.Drawing.Size(457, 95)
		Me.lstContenuto.TabIndex = 6
		'
		'Label5
		'
		Me.Label5.Location = New System.Drawing.Point(12, 318)
		Me.Label5.Name = "Label5"
		Me.Label5.Size = New System.Drawing.Size(459, 15)
		Me.Label5.TabIndex = 5
		Me.Label5.Text = "Alias cartelle contenuto"
		Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		'
		'Label6
		'
		Me.Label6.AutoSize = True
		Me.Label6.Location = New System.Drawing.Point(12, 286)
		Me.Label6.Name = "Label6"
		Me.Label6.Size = New System.Drawing.Size(42, 13)
		Me.Label6.TabIndex = 7
		Me.Label6.Text = "Cartella"
		'
		'Label7
		'
		Me.Label7.AutoSize = True
		Me.Label7.Location = New System.Drawing.Point(215, 286)
		Me.Label7.Name = "Label7"
		Me.Label7.Size = New System.Drawing.Size(44, 13)
		Me.Label7.TabIndex = 8
		Me.Label7.Text = "Diventa"
		'
		'txtCartella
		'
		Me.txtCartella.Location = New System.Drawing.Point(59, 283)
		Me.txtCartella.Name = "txtCartella"
		Me.txtCartella.Size = New System.Drawing.Size(150, 20)
		Me.txtCartella.TabIndex = 9
		'
		'txtDiventa
		'
		Me.txtDiventa.Location = New System.Drawing.Point(265, 283)
		Me.txtDiventa.Name = "txtDiventa"
		Me.txtDiventa.Size = New System.Drawing.Size(136, 20)
		Me.txtDiventa.TabIndex = 10
		'
		'cmdSalva1
		'
		Me.cmdSalva1.Location = New System.Drawing.Point(441, 281)
		Me.cmdSalva1.Name = "cmdSalva1"
		Me.cmdSalva1.Size = New System.Drawing.Size(28, 22)
		Me.cmdSalva1.TabIndex = 11
		Me.cmdSalva1.Text = "S"
		Me.cmdSalva1.UseVisualStyleBackColor = True
		'
		'cmdSalva2
		'
		Me.cmdSalva2.Location = New System.Drawing.Point(443, 437)
		Me.cmdSalva2.Name = "cmdSalva2"
		Me.cmdSalva2.Size = New System.Drawing.Size(28, 22)
		Me.cmdSalva2.TabIndex = 16
		Me.cmdSalva2.Text = "S"
		Me.cmdSalva2.UseVisualStyleBackColor = True
		'
		'txtDestinazione
		'
		Me.txtDestinazione.Location = New System.Drawing.Point(265, 439)
		Me.txtDestinazione.Name = "txtDestinazione"
		Me.txtDestinazione.Size = New System.Drawing.Size(136, 20)
		Me.txtDestinazione.TabIndex = 15
		'
		'txtContenuto
		'
		Me.txtContenuto.Location = New System.Drawing.Point(61, 439)
		Me.txtContenuto.Name = "txtContenuto"
		Me.txtContenuto.Size = New System.Drawing.Size(151, 20)
		Me.txtContenuto.TabIndex = 14
		'
		'Label8
		'
		Me.Label8.AutoSize = True
		Me.Label8.Location = New System.Drawing.Point(218, 442)
		Me.Label8.Name = "Label8"
		Me.Label8.Size = New System.Drawing.Size(51, 13)
		Me.Label8.TabIndex = 13
		Me.Label8.Text = "Destinaz."
		'
		'Label9
		'
		Me.Label9.AutoSize = True
		Me.Label9.Location = New System.Drawing.Point(14, 442)
		Me.Label9.Name = "Label9"
		Me.Label9.Size = New System.Drawing.Size(44, 13)
		Me.Label9.TabIndex = 12
		Me.Label9.Text = "Conten."
		'
		'cmdPulisce1
		'
		Me.cmdPulisce1.Location = New System.Drawing.Point(407, 281)
		Me.cmdPulisce1.Name = "cmdPulisce1"
		Me.cmdPulisce1.Size = New System.Drawing.Size(28, 22)
		Me.cmdPulisce1.TabIndex = 17
		Me.cmdPulisce1.Text = "P"
		Me.cmdPulisce1.UseVisualStyleBackColor = True
		'
		'lblAlias1
		'
		Me.lblAlias1.AutoSize = True
		Me.lblAlias1.Location = New System.Drawing.Point(407, 166)
		Me.lblAlias1.Name = "lblAlias1"
		Me.lblAlias1.Size = New System.Drawing.Size(45, 13)
		Me.lblAlias1.TabIndex = 18
		Me.lblAlias1.Text = "Label10"
		'
		'lblAlias2
		'
		Me.lblAlias2.AutoSize = True
		Me.lblAlias2.Location = New System.Drawing.Point(419, 318)
		Me.lblAlias2.Name = "lblAlias2"
		Me.lblAlias2.Size = New System.Drawing.Size(45, 13)
		Me.lblAlias2.TabIndex = 19
		Me.lblAlias2.Text = "Label10"
		'
		'cmdPulisce2
		'
		Me.cmdPulisce2.Location = New System.Drawing.Point(407, 437)
		Me.cmdPulisce2.Name = "cmdPulisce2"
		Me.cmdPulisce2.Size = New System.Drawing.Size(28, 22)
		Me.cmdPulisce2.TabIndex = 20
		Me.cmdPulisce2.Text = "P"
		Me.cmdPulisce2.UseVisualStyleBackColor = True
		'
		'Label10
		'
		Me.Label10.AutoSize = True
		Me.Label10.Location = New System.Drawing.Point(218, 479)
		Me.Label10.Name = "Label10"
		Me.Label10.Size = New System.Drawing.Size(160, 13)
		Me.Label10.TabIndex = 21
		Me.Label10.Text = "Elimina files cancellazioni remote"
		'
		'cmdEliminaRemoti
		'
		Me.cmdEliminaRemoti.Location = New System.Drawing.Point(396, 474)
		Me.cmdEliminaRemoti.Name = "cmdEliminaRemoti"
		Me.cmdEliminaRemoti.Size = New System.Drawing.Size(75, 23)
		Me.cmdEliminaRemoti.TabIndex = 22
		Me.cmdEliminaRemoti.Text = "Elimina"
		Me.cmdEliminaRemoti.UseVisualStyleBackColor = True
		'
		'frmSettaggi
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.ClientSize = New System.Drawing.Size(480, 509)
		Me.Controls.Add(Me.cmdEliminaRemoti)
		Me.Controls.Add(Me.Label10)
		Me.Controls.Add(Me.cmdPulisce2)
		Me.Controls.Add(Me.lblAlias2)
		Me.Controls.Add(Me.lblAlias1)
		Me.Controls.Add(Me.cmdPulisce1)
		Me.Controls.Add(Me.cmdSalva2)
		Me.Controls.Add(Me.txtDestinazione)
		Me.Controls.Add(Me.txtContenuto)
		Me.Controls.Add(Me.Label8)
		Me.Controls.Add(Me.Label9)
		Me.Controls.Add(Me.cmdSalva1)
		Me.Controls.Add(Me.txtDiventa)
		Me.Controls.Add(Me.txtCartella)
		Me.Controls.Add(Me.Label7)
		Me.Controls.Add(Me.Label6)
		Me.Controls.Add(Me.lstContenuto)
		Me.Controls.Add(Me.Label5)
		Me.Controls.Add(Me.lstCompleti)
		Me.Controls.Add(Me.Label4)
		Me.Controls.Add(Me.Panel1)
		Me.Controls.Add(Me.optProxy)
		Me.Controls.Add(Me.optNormale)
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
		Me.MaximizeBox = False
		Me.MinimizeBox = False
		Me.Name = "frmSettaggi"
		Me.ShowIcon = False
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
		Me.Text = "Settaggi"
		Me.Panel1.ResumeLayout(False)
		Me.Panel1.PerformLayout()
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub
	Friend WithEvents optNormale As System.Windows.Forms.RadioButton
    Friend WithEvents optProxy As System.Windows.Forms.RadioButton
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtDominio As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtPassword As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtUtenza As System.Windows.Forms.TextBox
    Friend WithEvents cmdSalva As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lstCompleti As System.Windows.Forms.ListBox
    Friend WithEvents lstContenuto As System.Windows.Forms.ListBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtCartella As System.Windows.Forms.TextBox
    Friend WithEvents txtDiventa As System.Windows.Forms.TextBox
    Friend WithEvents cmdSalva1 As System.Windows.Forms.Button
    Friend WithEvents cmdSalva2 As System.Windows.Forms.Button
    Friend WithEvents txtDestinazione As System.Windows.Forms.TextBox
    Friend WithEvents txtContenuto As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents cmdPulisce1 As System.Windows.Forms.Button
    Friend WithEvents lblAlias1 As System.Windows.Forms.Label
    Friend WithEvents lblAlias2 As System.Windows.Forms.Label
    Friend WithEvents cmdPulisce2 As System.Windows.Forms.Button
	Friend WithEvents Label10 As Label
	Friend WithEvents cmdEliminaRemoti As Button
End Class
