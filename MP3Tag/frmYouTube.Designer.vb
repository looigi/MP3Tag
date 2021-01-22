<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmYouTube
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
	'Non modificarla mediante l'editor del codice.
	<System.Diagnostics.DebuggerStepThrough()> _
	Private Sub InitializeComponent()
		Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmYouTube))
		Me.pnlGestione = New System.Windows.Forms.Panel()
		Me.btnApriChiudi = New System.Windows.Forms.Button()
		Me.lstVideoCompleto = New System.Windows.Forms.ListBox()
		Me.lstVideo = New System.Windows.Forms.ListBox()
		Me.Label1 = New System.Windows.Forms.Label()
		Me.AxWindowsMediaPlayer1 = New AxWMPLib.AxWindowsMediaPlayer()
		Me.pnlCaricamento = New System.Windows.Forms.Panel()
		Me.Label2 = New System.Windows.Forms.Label()
		Me.cmdElimina = New System.Windows.Forms.Button()
		Me.cmdRefresh = New System.Windows.Forms.Button()
		Me.pnlGestione.SuspendLayout()
		CType(Me.AxWindowsMediaPlayer1, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.pnlCaricamento.SuspendLayout()
		Me.SuspendLayout()
		'
		'pnlGestione
		'
		Me.pnlGestione.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
			Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
		Me.pnlGestione.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.pnlGestione.Controls.Add(Me.cmdRefresh)
		Me.pnlGestione.Controls.Add(Me.cmdElimina)
		Me.pnlGestione.Controls.Add(Me.btnApriChiudi)
		Me.pnlGestione.Controls.Add(Me.lstVideoCompleto)
		Me.pnlGestione.Controls.Add(Me.lstVideo)
		Me.pnlGestione.Controls.Add(Me.Label1)
		Me.pnlGestione.Location = New System.Drawing.Point(0, 0)
		Me.pnlGestione.Name = "pnlGestione"
		Me.pnlGestione.Size = New System.Drawing.Size(200, 410)
		Me.pnlGestione.TabIndex = 1
		'
		'btnApriChiudi
		'
		Me.btnApriChiudi.Location = New System.Drawing.Point(176, 4)
		Me.btnApriChiudi.Name = "btnApriChiudi"
		Me.btnApriChiudi.Size = New System.Drawing.Size(19, 23)
		Me.btnApriChiudi.TabIndex = 3
		Me.btnApriChiudi.Text = "<"
		Me.btnApriChiudi.UseVisualStyleBackColor = True
		'
		'lstVideoCompleto
		'
		Me.lstVideoCompleto.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lstVideoCompleto.FormattingEnabled = True
		Me.lstVideoCompleto.ItemHeight = 16
		Me.lstVideoCompleto.Location = New System.Drawing.Point(65, 212)
		Me.lstVideoCompleto.Name = "lstVideoCompleto"
		Me.lstVideoCompleto.Size = New System.Drawing.Size(33, 36)
		Me.lstVideoCompleto.TabIndex = 2
		Me.lstVideoCompleto.Visible = False
		'
		'lstVideo
		'
		Me.lstVideo.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lstVideo.FormattingEnabled = True
		Me.lstVideo.ItemHeight = 16
		Me.lstVideo.Location = New System.Drawing.Point(4, 31)
		Me.lstVideo.Name = "lstVideo"
		Me.lstVideo.Size = New System.Drawing.Size(191, 164)
		Me.lstVideo.TabIndex = 1
		'
		'Label1
		'
		Me.Label1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
			Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.Label1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
		Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.Label1.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label1.Location = New System.Drawing.Point(4, 4)
		Me.Label1.Name = "Label1"
		Me.Label1.Size = New System.Drawing.Size(166, 23)
		Me.Label1.TabIndex = 0
		Me.Label1.Text = "Lista Video"
		Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		'
		'AxWindowsMediaPlayer1
		'
		Me.AxWindowsMediaPlayer1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
			Or System.Windows.Forms.AnchorStyles.Left) _
			Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.AxWindowsMediaPlayer1.Enabled = True
		Me.AxWindowsMediaPlayer1.Location = New System.Drawing.Point(5, 4)
		Me.AxWindowsMediaPlayer1.Name = "AxWindowsMediaPlayer1"
		Me.AxWindowsMediaPlayer1.OcxState = CType(resources.GetObject("AxWindowsMediaPlayer1.OcxState"), System.Windows.Forms.AxHost.State)
		Me.AxWindowsMediaPlayer1.Size = New System.Drawing.Size(453, 410)
		Me.AxWindowsMediaPlayer1.TabIndex = 2
		'
		'pnlCaricamento
		'
		Me.pnlCaricamento.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
		Me.pnlCaricamento.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.pnlCaricamento.Controls.Add(Me.Label2)
		Me.pnlCaricamento.Location = New System.Drawing.Point(66, 125)
		Me.pnlCaricamento.Name = "pnlCaricamento"
		Me.pnlCaricamento.Size = New System.Drawing.Size(344, 157)
		Me.pnlCaricamento.TabIndex = 5
		'
		'Label2
		'
		Me.Label2.Font = New System.Drawing.Font("Verdana", 26.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label2.Location = New System.Drawing.Point(20, 25)
		Me.Label2.Name = "Label2"
		Me.Label2.Size = New System.Drawing.Size(300, 105)
		Me.Label2.TabIndex = 0
		Me.Label2.Text = "Caricamento in corso"
		Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		'
		'cmdElimina
		'
		Me.cmdElimina.Location = New System.Drawing.Point(4, 202)
		Me.cmdElimina.Name = "cmdElimina"
		Me.cmdElimina.Size = New System.Drawing.Size(75, 23)
		Me.cmdElimina.TabIndex = 4
		Me.cmdElimina.Text = "Elimina"
		Me.cmdElimina.UseVisualStyleBackColor = True
		'
		'cmdRefresh
		'
		Me.cmdRefresh.Location = New System.Drawing.Point(120, 201)
		Me.cmdRefresh.Name = "cmdRefresh"
		Me.cmdRefresh.Size = New System.Drawing.Size(75, 23)
		Me.cmdRefresh.TabIndex = 6
		Me.cmdRefresh.Text = "Refresh"
		Me.cmdRefresh.UseVisualStyleBackColor = True
		'
		'frmYouTube
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.ClientSize = New System.Drawing.Size(456, 412)
		Me.Controls.Add(Me.pnlCaricamento)
		Me.Controls.Add(Me.pnlGestione)
		Me.Controls.Add(Me.AxWindowsMediaPlayer1)
		Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
		Me.MinimizeBox = False
		Me.Name = "frmYouTube"
		Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
		Me.Text = "YoutTube"
		Me.pnlGestione.ResumeLayout(False)
		CType(Me.AxWindowsMediaPlayer1, System.ComponentModel.ISupportInitialize).EndInit()
		Me.pnlCaricamento.ResumeLayout(False)
		Me.ResumeLayout(False)

	End Sub
	Friend WithEvents pnlGestione As Panel
	Friend WithEvents lstVideo As ListBox
	Friend WithEvents Label1 As Label
	Friend WithEvents lstVideoCompleto As ListBox
	Friend WithEvents AxWindowsMediaPlayer1 As AxWMPLib.AxWindowsMediaPlayer
	Friend WithEvents btnApriChiudi As Button
	Friend WithEvents pnlCaricamento As Panel
	Friend WithEvents Label2 As Label
	Friend WithEvents cmdElimina As Button
	Friend WithEvents cmdRefresh As Button
End Class
