<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmPlayer
	Inherits System.Windows.Forms.Form

	'Form esegue l'override del metodo Dispose per pulire l'elenco dei componenti.
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

	'Richiesto da Progettazione Windows Form
	Private components As System.ComponentModel.IContainer

	'NOTA: la procedura che segue è richiesta da Progettazione Windows Form
	'Può essere modificata in Progettazione Windows Form.  
	'Non modificarla nell'editor del codice.
	<System.Diagnostics.DebuggerStepThrough()>
	Private Sub InitializeComponent()
		Me.components = New System.ComponentModel.Container()
		Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPlayer))
		Me.lstTesto = New System.Windows.Forms.ListBox()
		Me.pnlTasti = New System.Windows.Forms.Panel()
		Me.lblTempoTotaleInterno = New System.Windows.Forms.Label()
		Me.lblTempoPassatoInterno = New System.Windows.Forms.Label()
		Me.BarraAvanzamentoInterna = New System.Windows.Forms.TrackBar()
		Me.picSettings = New System.Windows.Forms.PictureBox()
		Me.picPlay = New System.Windows.Forms.PictureBox()
		Me.picIndietro = New System.Windows.Forms.PictureBox()
		Me.picAvanti = New System.Windows.Forms.PictureBox()
		Me.lblNomeCanzone = New System.Windows.Forms.Label()
		Me.pnlImmagine = New System.Windows.Forms.Panel()
		Me.pnlStelle = New System.Windows.Forms.Panel()
		Me.picStelle7 = New System.Windows.Forms.PictureBox()
		Me.picStelle6 = New System.Windows.Forms.PictureBox()
		Me.picStelle1 = New System.Windows.Forms.PictureBox()
		Me.picStelle2 = New System.Windows.Forms.PictureBox()
		Me.picStelle3 = New System.Windows.Forms.PictureBox()
		Me.picStelle4 = New System.Windows.Forms.PictureBox()
		Me.picStelle5 = New System.Windows.Forms.PictureBox()
		Me.pnlBarra = New System.Windows.Forms.Panel()
		Me.BarraAvanzamento = New System.Windows.Forms.TrackBar()
		Me.lblTempoTotale = New System.Windows.Forms.Label()
		Me.lblTempoPassato = New System.Windows.Forms.Label()
		Me.picMP3 = New System.Windows.Forms.PictureBox()
		Me.lblFiltroImpostato = New System.Windows.Forms.Label()
		Me.pnlCanzoni = New System.Windows.Forms.Panel()
		Me.lblCanzone = New System.Windows.Forms.Label()
		Me.lblAlbum = New System.Windows.Forms.Label()
		Me.lblArtista = New System.Windows.Forms.Label()
		Me.lstCanzone = New System.Windows.Forms.ListBox()
		Me.lstAlbum = New System.Windows.Forms.ListBox()
		Me.lstArtista = New System.Windows.Forms.ListBox()
		Me.pnlImpostazioni = New System.Windows.Forms.Panel()
		Me.pnlImpostazioniInterno = New System.Windows.Forms.Panel()
		Me.pnlAvanzamento = New System.Windows.Forms.Panel()
		Me.lblAvanzamentoFile = New System.Windows.Forms.Label()
		Me.lblAvanzamento = New System.Windows.Forms.Label()
		Me.cmdCompattaMP3 = New System.Windows.Forms.Button()
		Me.cmdSistemaImmagini = New System.Windows.Forms.Button()
		Me.cmdStatistiche = New System.Windows.Forms.Button()
		Me.cmdEliminaTesti = New System.Windows.Forms.Button()
		Me.cmdChiudeImpostazioni = New System.Windows.Forms.Button()
		Me.chkScaricaLyric = New System.Windows.Forms.CheckBox()
		Me.cmdGestioneTAG = New System.Windows.Forms.Button()
		Me.chkRandom = New System.Windows.Forms.CheckBox()
		Me.cmdAggiornaCanzoni = New System.Windows.Forms.Button()
		Me.chkVisuaImmArtista = New System.Windows.Forms.CheckBox()
		Me.cmdEliminaVuote = New System.Windows.Forms.Button()
		Me.Label1 = New System.Windows.Forms.Label()
		Me.chkRicordaAscoltate = New System.Windows.Forms.CheckBox()
		Me.chkUltime = New System.Windows.Forms.CheckBox()
		Me.chkSuperiori = New System.Windows.Forms.CheckBox()
		Me.chkWikipedia = New System.Windows.Forms.CheckBox()
		Me.chkRicercaSuTesto = New System.Windows.Forms.CheckBox()
		Me.chkPartePlayer = New System.Windows.Forms.CheckBox()
		Me.cmdEliminaBrutte = New System.Windows.Forms.Button()
		Me.chkPrime = New System.Windows.Forms.CheckBox()
		Me.chkPath = New System.Windows.Forms.CheckBox()
		Me.pnlSopra = New System.Windows.Forms.Panel()
		Me.cmdEstrai = New System.Windows.Forms.Button()
		Me.chkSpectrum = New System.Windows.Forms.CheckBox()
		Me.chkFiltroNome = New System.Windows.Forms.CheckBox()
		Me.cmbSchedaAudio = New System.Windows.Forms.ComboBox()
		Me.cmdFiltraTesto = New System.Windows.Forms.Button()
		Me.Label2 = New System.Windows.Forms.Label()
		Me.txtFiltroTesto = New System.Windows.Forms.TextBox()
		Me.chkSpostaImmagini = New System.Windows.Forms.CheckBox()
		Me.chkFiltroTesto = New System.Windows.Forms.CheckBox()
		Me.chkBellezza = New System.Windows.Forms.CheckBox()
		Me.cmbBellezza = New System.Windows.Forms.ComboBox()
		Me.tmrVisualizzaImmArtista = New System.Windows.Forms.Timer(Me.components)
		Me.pnlStelleInterno = New System.Windows.Forms.Panel()
		Me.picStelle7Interno = New System.Windows.Forms.PictureBox()
		Me.picStelle6Interno = New System.Windows.Forms.PictureBox()
		Me.picStelle1Interno = New System.Windows.Forms.PictureBox()
		Me.picStelle2Interno = New System.Windows.Forms.PictureBox()
		Me.picStelle3Interno = New System.Windows.Forms.PictureBox()
		Me.picStelle4Interno = New System.Windows.Forms.PictureBox()
		Me.picStelle5Interno = New System.Windows.Forms.PictureBox()
		Me.cmdRefreshTesto = New System.Windows.Forms.Button()
		Me.tmrCambioImmagine = New System.Windows.Forms.Timer(Me.components)
		Me.tmrNascondeBarra = New System.Windows.Forms.Timer(Me.components)
		Me.pnlFinestra = New System.Windows.Forms.Panel()
		Me.cmdMassimizza = New System.Windows.Forms.Button()
		Me.cmdMinimizzaForm = New System.Windows.Forms.Button()
		Me.cmdChiudeForm = New System.Windows.Forms.Button()
		Me.tmrCanzone = New System.Windows.Forms.Timer(Me.components)
		Me.pnlModifiche = New System.Windows.Forms.Panel()
		Me.cmdPlaylist = New System.Windows.Forms.Button()
		Me.cmdAnnullaMod = New System.Windows.Forms.Button()
		Me.cmdRinomina = New System.Windows.Forms.Button()
		Me.cmdElimina = New System.Windows.Forms.Button()
		Me.lblNomeInModifica = New System.Windows.Forms.Label()
		Me.tmrSpostaScrittaTitolo = New System.Windows.Forms.Timer(Me.components)
		Me.tmrEffettoImmagine = New System.Windows.Forms.Timer(Me.components)
		Me.lblAggiornamentoCanzoni = New System.Windows.Forms.Label()
		Me.pnlFiltro = New System.Windows.Forms.Panel()
		Me.cmdAnnullaFiltro = New System.Windows.Forms.Button()
		Me.cmdFiltro = New System.Windows.Forms.Button()
		Me.lblFiltro = New System.Windows.Forms.Label()
		Me.tmrFadeOUT = New System.Windows.Forms.Timer(Me.components)
		Me.pnlSpectrum2 = New System.Windows.Forms.Panel()
		Me.tmrRefreshTesto = New System.Windows.Forms.Timer(Me.components)
		Me.lstTraduzione = New System.Windows.Forms.ListBox()
		Me.tmrTesto = New System.Windows.Forms.Timer(Me.components)
		Me.picLingua = New System.Windows.Forms.PictureBox()
		Me.tmrPartenza = New System.Windows.Forms.Timer(Me.components)
		Me.lblTesti = New System.Windows.Forms.Label()
		Me.tmrSpostaYouTube = New System.Windows.Forms.Timer(Me.components)
		Me.pnlTuttoSchermo = New System.Windows.Forms.PictureBox()
		Me.tmrPrendeThumbs = New System.Windows.Forms.Timer(Me.components)
		Me.pnlImmagineArtista = New DoubleBufferedPanels()
		Me.cmdRicaricaMembri = New System.Windows.Forms.Button()
		Me.pnlMembriInterno = New System.Windows.Forms.Panel()
		Me.pnlTestoInterno = New System.Windows.Forms.Panel()
		Me.cmdApreCartella = New System.Windows.Forms.Button()
		Me.cmdRefreshtestoInterno = New System.Windows.Forms.Button()
		Me.cmdTraduzione = New System.Windows.Forms.Button()
		Me.cmdTesto = New System.Windows.Forms.Button()
		Me.cmdSalva = New System.Windows.Forms.Button()
		Me.cmdVisualizzaMembri = New System.Windows.Forms.Button()
		Me.cmdEliminaImmagineArtista = New System.Windows.Forms.Button()
		Me.lblNomeArtistaImm = New System.Windows.Forms.Label()
		Me.picImmagineArtista = New System.Windows.Forms.PictureBox()
		Me.pnlSotto = New System.Windows.Forms.Panel()
		Me.lblNomeImmArtista = New System.Windows.Forms.Label()
		Me.pnlTasti.SuspendLayout()
		CType(Me.BarraAvanzamentoInterna, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.picSettings, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.picPlay, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.picIndietro, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.picAvanti, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.pnlImmagine.SuspendLayout()
		Me.pnlStelle.SuspendLayout()
		CType(Me.picStelle7, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.picStelle6, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.picStelle1, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.picStelle2, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.picStelle3, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.picStelle4, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.picStelle5, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.pnlBarra.SuspendLayout()
		CType(Me.BarraAvanzamento, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.picMP3, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.pnlCanzoni.SuspendLayout()
		Me.pnlImpostazioni.SuspendLayout()
		Me.pnlImpostazioniInterno.SuspendLayout()
		Me.pnlAvanzamento.SuspendLayout()
		Me.pnlStelleInterno.SuspendLayout()
		CType(Me.picStelle7Interno, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.picStelle6Interno, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.picStelle1Interno, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.picStelle2Interno, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.picStelle3Interno, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.picStelle4Interno, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.picStelle5Interno, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.pnlFinestra.SuspendLayout()
		Me.pnlModifiche.SuspendLayout()
		Me.pnlFiltro.SuspendLayout()
		CType(Me.picLingua, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.pnlTuttoSchermo, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.pnlImmagineArtista.SuspendLayout()
		CType(Me.picImmagineArtista, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.SuspendLayout()
		'
		'lstTesto
		'
		Me.lstTesto.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lstTesto.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lstTesto.FormattingEnabled = True
		Me.lstTesto.HorizontalScrollbar = True
		Me.lstTesto.Location = New System.Drawing.Point(286, 440)
		Me.lstTesto.Name = "lstTesto"
		Me.lstTesto.Size = New System.Drawing.Size(244, 260)
		Me.lstTesto.TabIndex = 1
		'
		'pnlTasti
		'
		Me.pnlTasti.BackColor = System.Drawing.Color.FromArgb(CType(CType(34, Byte), Integer), CType(CType(34, Byte), Integer), CType(CType(0, Byte), Integer))
		Me.pnlTasti.Controls.Add(Me.lblTempoTotaleInterno)
		Me.pnlTasti.Controls.Add(Me.lblTempoPassatoInterno)
		Me.pnlTasti.Controls.Add(Me.BarraAvanzamentoInterna)
		Me.pnlTasti.Controls.Add(Me.picSettings)
		Me.pnlTasti.Controls.Add(Me.picPlay)
		Me.pnlTasti.Controls.Add(Me.picIndietro)
		Me.pnlTasti.Controls.Add(Me.picAvanti)
		Me.pnlTasti.Controls.Add(Me.lblNomeCanzone)
		Me.pnlTasti.Location = New System.Drawing.Point(13, 317)
		Me.pnlTasti.Name = "pnlTasti"
		Me.pnlTasti.Size = New System.Drawing.Size(588, 100)
		Me.pnlTasti.TabIndex = 2
		'
		'lblTempoTotaleInterno
		'
		Me.lblTempoTotaleInterno.BackColor = System.Drawing.Color.Transparent
		Me.lblTempoTotaleInterno.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblTempoTotaleInterno.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
		Me.lblTempoTotaleInterno.Location = New System.Drawing.Point(340, 39)
		Me.lblTempoTotaleInterno.Name = "lblTempoTotaleInterno"
		Me.lblTempoTotaleInterno.Size = New System.Drawing.Size(56, 23)
		Me.lblTempoTotaleInterno.TabIndex = 11
		Me.lblTempoTotaleInterno.Text = "Label2"
		Me.lblTempoTotaleInterno.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		'
		'lblTempoPassatoInterno
		'
		Me.lblTempoPassatoInterno.BackColor = System.Drawing.Color.Transparent
		Me.lblTempoPassatoInterno.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblTempoPassatoInterno.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
		Me.lblTempoPassatoInterno.Location = New System.Drawing.Point(134, 40)
		Me.lblTempoPassatoInterno.Name = "lblTempoPassatoInterno"
		Me.lblTempoPassatoInterno.Size = New System.Drawing.Size(56, 23)
		Me.lblTempoPassatoInterno.TabIndex = 10
		Me.lblTempoPassatoInterno.Text = "Label1"
		Me.lblTempoPassatoInterno.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		'
		'BarraAvanzamentoInterna
		'
		Me.BarraAvanzamentoInterna.Location = New System.Drawing.Point(250, 52)
		Me.BarraAvanzamentoInterna.Name = "BarraAvanzamentoInterna"
		Me.BarraAvanzamentoInterna.Size = New System.Drawing.Size(104, 45)
		Me.BarraAvanzamentoInterna.TabIndex = 9
		'
		'picSettings
		'
		Me.picSettings.BackColor = System.Drawing.Color.Transparent
		Me.picSettings.BackgroundImage = CType(resources.GetObject("picSettings.BackgroundImage"), System.Drawing.Image)
		Me.picSettings.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
		Me.picSettings.Location = New System.Drawing.Point(473, 39)
		Me.picSettings.Name = "picSettings"
		Me.picSettings.Size = New System.Drawing.Size(41, 50)
		Me.picSettings.TabIndex = 8
		Me.picSettings.TabStop = False
		'
		'picPlay
		'
		Me.picPlay.BackColor = System.Drawing.Color.Transparent
		Me.picPlay.BackgroundImage = CType(resources.GetObject("picPlay.BackgroundImage"), System.Drawing.Image)
		Me.picPlay.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
		Me.picPlay.Location = New System.Drawing.Point(325, 25)
		Me.picPlay.Name = "picPlay"
		Me.picPlay.Size = New System.Drawing.Size(41, 50)
		Me.picPlay.TabIndex = 7
		Me.picPlay.TabStop = False
		'
		'picIndietro
		'
		Me.picIndietro.BackColor = System.Drawing.Color.Transparent
		Me.picIndietro.BackgroundImage = CType(resources.GetObject("picIndietro.BackgroundImage"), System.Drawing.Image)
		Me.picIndietro.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
		Me.picIndietro.Location = New System.Drawing.Point(203, 25)
		Me.picIndietro.Name = "picIndietro"
		Me.picIndietro.Size = New System.Drawing.Size(41, 50)
		Me.picIndietro.TabIndex = 6
		Me.picIndietro.TabStop = False
		'
		'picAvanti
		'
		Me.picAvanti.BackColor = System.Drawing.Color.Transparent
		Me.picAvanti.BackgroundImage = CType(resources.GetObject("picAvanti.BackgroundImage"), System.Drawing.Image)
		Me.picAvanti.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
		Me.picAvanti.Location = New System.Drawing.Point(404, 39)
		Me.picAvanti.Name = "picAvanti"
		Me.picAvanti.Size = New System.Drawing.Size(41, 50)
		Me.picAvanti.TabIndex = 5
		Me.picAvanti.TabStop = False
		'
		'lblNomeCanzone
		'
		Me.lblNomeCanzone.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblNomeCanzone.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
		Me.lblNomeCanzone.Location = New System.Drawing.Point(73, 4)
		Me.lblNomeCanzone.Name = "lblNomeCanzone"
		Me.lblNomeCanzone.Size = New System.Drawing.Size(100, 36)
		Me.lblNomeCanzone.TabIndex = 3
		Me.lblNomeCanzone.Text = "Label1"
		Me.lblNomeCanzone.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		'
		'pnlImmagine
		'
		Me.pnlImmagine.Controls.Add(Me.pnlStelle)
		Me.pnlImmagine.Controls.Add(Me.pnlBarra)
		Me.pnlImmagine.Controls.Add(Me.picMP3)
		Me.pnlImmagine.Location = New System.Drawing.Point(-5, -1)
		Me.pnlImmagine.Name = "pnlImmagine"
		Me.pnlImmagine.Size = New System.Drawing.Size(234, 171)
		Me.pnlImmagine.TabIndex = 3
		'
		'pnlStelle
		'
		Me.pnlStelle.BackColor = System.Drawing.Color.Transparent
		Me.pnlStelle.Controls.Add(Me.picStelle7)
		Me.pnlStelle.Controls.Add(Me.picStelle6)
		Me.pnlStelle.Controls.Add(Me.picStelle1)
		Me.pnlStelle.Controls.Add(Me.picStelle2)
		Me.pnlStelle.Controls.Add(Me.picStelle3)
		Me.pnlStelle.Controls.Add(Me.picStelle4)
		Me.pnlStelle.Controls.Add(Me.picStelle5)
		Me.pnlStelle.Location = New System.Drawing.Point(3, 13)
		Me.pnlStelle.Name = "pnlStelle"
		Me.pnlStelle.Size = New System.Drawing.Size(226, 30)
		Me.pnlStelle.TabIndex = 3
		'
		'picStelle7
		'
		Me.picStelle7.Location = New System.Drawing.Point(2, 3)
		Me.picStelle7.Name = "picStelle7"
		Me.picStelle7.Size = New System.Drawing.Size(32, 29)
		Me.picStelle7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
		Me.picStelle7.TabIndex = 6
		Me.picStelle7.TabStop = False
		'
		'picStelle6
		'
		Me.picStelle6.Location = New System.Drawing.Point(34, 3)
		Me.picStelle6.Name = "picStelle6"
		Me.picStelle6.Size = New System.Drawing.Size(32, 29)
		Me.picStelle6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
		Me.picStelle6.TabIndex = 5
		Me.picStelle6.TabStop = False
		'
		'picStelle1
		'
		Me.picStelle1.Location = New System.Drawing.Point(194, 3)
		Me.picStelle1.Name = "picStelle1"
		Me.picStelle1.Size = New System.Drawing.Size(32, 29)
		Me.picStelle1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
		Me.picStelle1.TabIndex = 4
		Me.picStelle1.TabStop = False
		'
		'picStelle2
		'
		Me.picStelle2.Location = New System.Drawing.Point(162, 3)
		Me.picStelle2.Name = "picStelle2"
		Me.picStelle2.Size = New System.Drawing.Size(32, 29)
		Me.picStelle2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
		Me.picStelle2.TabIndex = 3
		Me.picStelle2.TabStop = False
		'
		'picStelle3
		'
		Me.picStelle3.Location = New System.Drawing.Point(130, 3)
		Me.picStelle3.Name = "picStelle3"
		Me.picStelle3.Size = New System.Drawing.Size(32, 29)
		Me.picStelle3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
		Me.picStelle3.TabIndex = 2
		Me.picStelle3.TabStop = False
		'
		'picStelle4
		'
		Me.picStelle4.Location = New System.Drawing.Point(98, 3)
		Me.picStelle4.Name = "picStelle4"
		Me.picStelle4.Size = New System.Drawing.Size(32, 29)
		Me.picStelle4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
		Me.picStelle4.TabIndex = 1
		Me.picStelle4.TabStop = False
		'
		'picStelle5
		'
		Me.picStelle5.Location = New System.Drawing.Point(66, 3)
		Me.picStelle5.Name = "picStelle5"
		Me.picStelle5.Size = New System.Drawing.Size(32, 29)
		Me.picStelle5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
		Me.picStelle5.TabIndex = 0
		Me.picStelle5.TabStop = False
		'
		'pnlBarra
		'
		Me.pnlBarra.BackColor = System.Drawing.Color.Black
		Me.pnlBarra.Controls.Add(Me.BarraAvanzamento)
		Me.pnlBarra.Controls.Add(Me.lblTempoTotale)
		Me.pnlBarra.Controls.Add(Me.lblTempoPassato)
		Me.pnlBarra.Location = New System.Drawing.Point(31, 149)
		Me.pnlBarra.Name = "pnlBarra"
		Me.pnlBarra.Size = New System.Drawing.Size(200, 19)
		Me.pnlBarra.TabIndex = 2
		'
		'BarraAvanzamento
		'
		Me.BarraAvanzamento.Location = New System.Drawing.Point(49, -1)
		Me.BarraAvanzamento.Name = "BarraAvanzamento"
		Me.BarraAvanzamento.Size = New System.Drawing.Size(104, 45)
		Me.BarraAvanzamento.TabIndex = 6
		'
		'lblTempoTotale
		'
		Me.lblTempoTotale.BackColor = System.Drawing.Color.Transparent
		Me.lblTempoTotale.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblTempoTotale.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
		Me.lblTempoTotale.Location = New System.Drawing.Point(144, -1)
		Me.lblTempoTotale.Name = "lblTempoTotale"
		Me.lblTempoTotale.Size = New System.Drawing.Size(56, 23)
		Me.lblTempoTotale.TabIndex = 5
		Me.lblTempoTotale.Text = "Label2"
		Me.lblTempoTotale.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		'
		'lblTempoPassato
		'
		Me.lblTempoPassato.BackColor = System.Drawing.Color.Transparent
		Me.lblTempoPassato.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblTempoPassato.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
		Me.lblTempoPassato.Location = New System.Drawing.Point(-4, -1)
		Me.lblTempoPassato.Name = "lblTempoPassato"
		Me.lblTempoPassato.Size = New System.Drawing.Size(56, 23)
		Me.lblTempoPassato.TabIndex = 4
		Me.lblTempoPassato.Text = "Label1"
		Me.lblTempoPassato.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		'
		'picMP3
		'
		Me.picMP3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.picMP3.Location = New System.Drawing.Point(23, 13)
		Me.picMP3.Name = "picMP3"
		Me.picMP3.Size = New System.Drawing.Size(180, 137)
		Me.picMP3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
		Me.picMP3.TabIndex = 1
		Me.picMP3.TabStop = False
		'
		'lblFiltroImpostato
		'
		Me.lblFiltroImpostato.BackColor = System.Drawing.Color.DarkRed
		Me.lblFiltroImpostato.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.lblFiltroImpostato.Font = New System.Drawing.Font("Arial Narrow", 17.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblFiltroImpostato.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
		Me.lblFiltroImpostato.Location = New System.Drawing.Point(748, 69)
		Me.lblFiltroImpostato.Name = "lblFiltroImpostato"
		Me.lblFiltroImpostato.Size = New System.Drawing.Size(34, 25)
		Me.lblFiltroImpostato.TabIndex = 10
		Me.lblFiltroImpostato.Text = " ***"
		Me.lblFiltroImpostato.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.lblFiltroImpostato.Visible = False
		'
		'pnlCanzoni
		'
		Me.pnlCanzoni.BackColor = System.Drawing.Color.Black
		Me.pnlCanzoni.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.pnlCanzoni.Controls.Add(Me.lblCanzone)
		Me.pnlCanzoni.Controls.Add(Me.lblAlbum)
		Me.pnlCanzoni.Controls.Add(Me.lblArtista)
		Me.pnlCanzoni.Controls.Add(Me.lstCanzone)
		Me.pnlCanzoni.Controls.Add(Me.lstAlbum)
		Me.pnlCanzoni.Controls.Add(Me.lstArtista)
		Me.pnlCanzoni.ForeColor = System.Drawing.Color.White
		Me.pnlCanzoni.Location = New System.Drawing.Point(19, 196)
		Me.pnlCanzoni.Name = "pnlCanzoni"
		Me.pnlCanzoni.Size = New System.Drawing.Size(617, 100)
		Me.pnlCanzoni.TabIndex = 4
		'
		'lblCanzone
		'
		Me.lblCanzone.BackColor = System.Drawing.Color.FromArgb(CType(CType(84, Byte), Integer), CType(CType(84, Byte), Integer), CType(CType(20, Byte), Integer))
		Me.lblCanzone.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblCanzone.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
		Me.lblCanzone.Location = New System.Drawing.Point(513, 65)
		Me.lblCanzone.Name = "lblCanzone"
		Me.lblCanzone.Size = New System.Drawing.Size(99, 23)
		Me.lblCanzone.TabIndex = 6
		Me.lblCanzone.Text = "Canzone"
		Me.lblCanzone.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		'
		'lblAlbum
		'
		Me.lblAlbum.BackColor = System.Drawing.Color.FromArgb(CType(CType(84, Byte), Integer), CType(CType(84, Byte), Integer), CType(CType(20, Byte), Integer))
		Me.lblAlbum.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblAlbum.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
		Me.lblAlbum.Location = New System.Drawing.Point(510, 39)
		Me.lblAlbum.Name = "lblAlbum"
		Me.lblAlbum.Size = New System.Drawing.Size(102, 23)
		Me.lblAlbum.TabIndex = 5
		Me.lblAlbum.Text = "Album"
		Me.lblAlbum.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		'
		'lblArtista
		'
		Me.lblArtista.BackColor = System.Drawing.Color.FromArgb(CType(CType(84, Byte), Integer), CType(CType(84, Byte), Integer), CType(CType(20, Byte), Integer))
		Me.lblArtista.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblArtista.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
		Me.lblArtista.Location = New System.Drawing.Point(506, 13)
		Me.lblArtista.Name = "lblArtista"
		Me.lblArtista.Size = New System.Drawing.Size(106, 23)
		Me.lblArtista.TabIndex = 4
		Me.lblArtista.Text = "Artista"
		Me.lblArtista.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		'
		'lstCanzone
		'
		Me.lstCanzone.BackColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(32, Byte), Integer), CType(CType(32, Byte), Integer))
		Me.lstCanzone.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lstCanzone.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lstCanzone.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
		Me.lstCanzone.FormattingEnabled = True
		Me.lstCanzone.Location = New System.Drawing.Point(277, 4)
		Me.lstCanzone.Name = "lstCanzone"
		Me.lstCanzone.Size = New System.Drawing.Size(120, 78)
		Me.lstCanzone.Sorted = True
		Me.lstCanzone.TabIndex = 2
		'
		'lstAlbum
		'
		Me.lstAlbum.BackColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(32, Byte), Integer), CType(CType(32, Byte), Integer))
		Me.lstAlbum.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lstAlbum.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lstAlbum.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
		Me.lstAlbum.FormattingEnabled = True
		Me.lstAlbum.Location = New System.Drawing.Point(137, 4)
		Me.lstAlbum.Name = "lstAlbum"
		Me.lstAlbum.Size = New System.Drawing.Size(120, 78)
		Me.lstAlbum.Sorted = True
		Me.lstAlbum.TabIndex = 1
		'
		'lstArtista
		'
		Me.lstArtista.BackColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(32, Byte), Integer), CType(CType(32, Byte), Integer))
		Me.lstArtista.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lstArtista.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lstArtista.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
		Me.lstArtista.FormattingEnabled = True
		Me.lstArtista.Location = New System.Drawing.Point(4, 4)
		Me.lstArtista.Name = "lstArtista"
		Me.lstArtista.Size = New System.Drawing.Size(120, 78)
		Me.lstArtista.Sorted = True
		Me.lstArtista.TabIndex = 0
		'
		'pnlImpostazioni
		'
		Me.pnlImpostazioni.AutoScroll = True
		Me.pnlImpostazioni.BackColor = System.Drawing.Color.Silver
		Me.pnlImpostazioni.BackgroundImage = Global.MP3Tag.My.Resources.Resources.sfondo_impostazioni_2
		Me.pnlImpostazioni.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
		Me.pnlImpostazioni.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.pnlImpostazioni.Controls.Add(Me.pnlImpostazioniInterno)
		Me.pnlImpostazioni.Location = New System.Drawing.Point(475, 28)
		Me.pnlImpostazioni.Name = "pnlImpostazioni"
		Me.pnlImpostazioni.Size = New System.Drawing.Size(547, 561)
		Me.pnlImpostazioni.TabIndex = 5
		'
		'pnlImpostazioniInterno
		'
		Me.pnlImpostazioniInterno.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
		Me.pnlImpostazioniInterno.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.pnlImpostazioniInterno.Controls.Add(Me.pnlAvanzamento)
		Me.pnlImpostazioniInterno.Controls.Add(Me.cmdCompattaMP3)
		Me.pnlImpostazioniInterno.Controls.Add(Me.cmdSistemaImmagini)
		Me.pnlImpostazioniInterno.Controls.Add(Me.cmdStatistiche)
		Me.pnlImpostazioniInterno.Controls.Add(Me.cmdEliminaTesti)
		Me.pnlImpostazioniInterno.Controls.Add(Me.cmdChiudeImpostazioni)
		Me.pnlImpostazioniInterno.Controls.Add(Me.chkScaricaLyric)
		Me.pnlImpostazioniInterno.Controls.Add(Me.cmdGestioneTAG)
		Me.pnlImpostazioniInterno.Controls.Add(Me.chkRandom)
		Me.pnlImpostazioniInterno.Controls.Add(Me.cmdAggiornaCanzoni)
		Me.pnlImpostazioniInterno.Controls.Add(Me.chkVisuaImmArtista)
		Me.pnlImpostazioniInterno.Controls.Add(Me.cmdEliminaVuote)
		Me.pnlImpostazioniInterno.Controls.Add(Me.Label1)
		Me.pnlImpostazioniInterno.Controls.Add(Me.chkRicordaAscoltate)
		Me.pnlImpostazioniInterno.Controls.Add(Me.chkUltime)
		Me.pnlImpostazioniInterno.Controls.Add(Me.chkSuperiori)
		Me.pnlImpostazioniInterno.Controls.Add(Me.chkWikipedia)
		Me.pnlImpostazioniInterno.Controls.Add(Me.chkRicercaSuTesto)
		Me.pnlImpostazioniInterno.Controls.Add(Me.chkPartePlayer)
		Me.pnlImpostazioniInterno.Controls.Add(Me.cmdEliminaBrutte)
		Me.pnlImpostazioniInterno.Controls.Add(Me.chkPrime)
		Me.pnlImpostazioniInterno.Controls.Add(Me.chkPath)
		Me.pnlImpostazioniInterno.Controls.Add(Me.pnlSopra)
		Me.pnlImpostazioniInterno.Controls.Add(Me.cmdEstrai)
		Me.pnlImpostazioniInterno.Controls.Add(Me.chkSpectrum)
		Me.pnlImpostazioniInterno.Controls.Add(Me.chkFiltroNome)
		Me.pnlImpostazioniInterno.Controls.Add(Me.cmbSchedaAudio)
		Me.pnlImpostazioniInterno.Controls.Add(Me.cmdFiltraTesto)
		Me.pnlImpostazioniInterno.Controls.Add(Me.Label2)
		Me.pnlImpostazioniInterno.Controls.Add(Me.txtFiltroTesto)
		Me.pnlImpostazioniInterno.Controls.Add(Me.chkSpostaImmagini)
		Me.pnlImpostazioniInterno.Controls.Add(Me.chkFiltroTesto)
		Me.pnlImpostazioniInterno.Controls.Add(Me.chkBellezza)
		Me.pnlImpostazioniInterno.Controls.Add(Me.cmbBellezza)
		Me.pnlImpostazioniInterno.Location = New System.Drawing.Point(30, 10)
		Me.pnlImpostazioniInterno.Name = "pnlImpostazioniInterno"
		Me.pnlImpostazioniInterno.Size = New System.Drawing.Size(486, 520)
		Me.pnlImpostazioniInterno.TabIndex = 31
		'
		'pnlAvanzamento
		'
		Me.pnlAvanzamento.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
		Me.pnlAvanzamento.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.pnlAvanzamento.Controls.Add(Me.lblAvanzamentoFile)
		Me.pnlAvanzamento.Controls.Add(Me.lblAvanzamento)
		Me.pnlAvanzamento.Location = New System.Drawing.Point(178, 260)
		Me.pnlAvanzamento.Name = "pnlAvanzamento"
		Me.pnlAvanzamento.Size = New System.Drawing.Size(272, 46)
		Me.pnlAvanzamento.TabIndex = 23
		Me.pnlAvanzamento.Visible = False
		'
		'lblAvanzamentoFile
		'
		Me.lblAvanzamentoFile.BackColor = System.Drawing.Color.Transparent
		Me.lblAvanzamentoFile.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblAvanzamentoFile.ForeColor = System.Drawing.Color.Olive
		Me.lblAvanzamentoFile.Location = New System.Drawing.Point(5, 23)
		Me.lblAvanzamentoFile.Name = "lblAvanzamentoFile"
		Me.lblAvanzamentoFile.Size = New System.Drawing.Size(262, 23)
		Me.lblAvanzamentoFile.TabIndex = 8
		Me.lblAvanzamentoFile.Text = "Label2"
		Me.lblAvanzamentoFile.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		'
		'lblAvanzamento
		'
		Me.lblAvanzamento.BackColor = System.Drawing.Color.Transparent
		Me.lblAvanzamento.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblAvanzamento.ForeColor = System.Drawing.Color.Olive
		Me.lblAvanzamento.Location = New System.Drawing.Point(5, 0)
		Me.lblAvanzamento.Name = "lblAvanzamento"
		Me.lblAvanzamento.Size = New System.Drawing.Size(262, 23)
		Me.lblAvanzamento.TabIndex = 7
		Me.lblAvanzamento.Text = "Label2"
		Me.lblAvanzamento.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		'
		'cmdCompattaMP3
		'
		Me.cmdCompattaMP3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.cmdCompattaMP3.Location = New System.Drawing.Point(301, 226)
		Me.cmdCompattaMP3.Name = "cmdCompattaMP3"
		Me.cmdCompattaMP3.Size = New System.Drawing.Size(180, 23)
		Me.cmdCompattaMP3.TabIndex = 36
		Me.cmdCompattaMP3.Text = "Compatta MP3"
		Me.cmdCompattaMP3.UseVisualStyleBackColor = True
		'
		'cmdSistemaImmagini
		'
		Me.cmdSistemaImmagini.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.cmdSistemaImmagini.Location = New System.Drawing.Point(301, 197)
		Me.cmdSistemaImmagini.Name = "cmdSistemaImmagini"
		Me.cmdSistemaImmagini.Size = New System.Drawing.Size(180, 23)
		Me.cmdSistemaImmagini.TabIndex = 35
		Me.cmdSistemaImmagini.Text = "Sistema Immagini"
		Me.cmdSistemaImmagini.UseVisualStyleBackColor = True
		'
		'cmdStatistiche
		'
		Me.cmdStatistiche.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.cmdStatistiche.Location = New System.Drawing.Point(13, 168)
		Me.cmdStatistiche.Name = "cmdStatistiche"
		Me.cmdStatistiche.Size = New System.Drawing.Size(180, 23)
		Me.cmdStatistiche.TabIndex = 34
		Me.cmdStatistiche.Text = "Statistiche"
		Me.cmdStatistiche.UseVisualStyleBackColor = True
		'
		'cmdEliminaTesti
		'
		Me.cmdEliminaTesti.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.cmdEliminaTesti.Location = New System.Drawing.Point(301, 168)
		Me.cmdEliminaTesti.Name = "cmdEliminaTesti"
		Me.cmdEliminaTesti.Size = New System.Drawing.Size(180, 23)
		Me.cmdEliminaTesti.TabIndex = 31
		Me.cmdEliminaTesti.Text = "Elimina tutti i testi"
		Me.cmdEliminaTesti.UseVisualStyleBackColor = True
		'
		'cmdChiudeImpostazioni
		'
		Me.cmdChiudeImpostazioni.BackColor = System.Drawing.Color.Red
		Me.cmdChiudeImpostazioni.ForeColor = System.Drawing.Color.White
		Me.cmdChiudeImpostazioni.Location = New System.Drawing.Point(452, 4)
		Me.cmdChiudeImpostazioni.Name = "cmdChiudeImpostazioni"
		Me.cmdChiudeImpostazioni.Size = New System.Drawing.Size(29, 23)
		Me.cmdChiudeImpostazioni.TabIndex = 2
		Me.cmdChiudeImpostazioni.Text = "X"
		Me.cmdChiudeImpostazioni.UseVisualStyleBackColor = False
		'
		'chkScaricaLyric
		'
		Me.chkScaricaLyric.AutoSize = True
		Me.chkScaricaLyric.Checked = True
		Me.chkScaricaLyric.CheckState = System.Windows.Forms.CheckState.Checked
		Me.chkScaricaLyric.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.chkScaricaLyric.Location = New System.Drawing.Point(15, 7)
		Me.chkScaricaLyric.Name = "chkScaricaLyric"
		Me.chkScaricaLyric.Size = New System.Drawing.Size(100, 17)
		Me.chkScaricaLyric.TabIndex = 4
		Me.chkScaricaLyric.Text = "Scarica testo"
		Me.chkScaricaLyric.UseVisualStyleBackColor = True
		'
		'cmdGestioneTAG
		'
		Me.cmdGestioneTAG.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.cmdGestioneTAG.Location = New System.Drawing.Point(8, 492)
		Me.cmdGestioneTAG.Name = "cmdGestioneTAG"
		Me.cmdGestioneTAG.Size = New System.Drawing.Size(473, 23)
		Me.cmdGestioneTAG.TabIndex = 30
		Me.cmdGestioneTAG.Text = "Gestione TAG"
		Me.cmdGestioneTAG.UseVisualStyleBackColor = True
		'
		'chkRandom
		'
		Me.chkRandom.AutoSize = True
		Me.chkRandom.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.chkRandom.Location = New System.Drawing.Point(12, 273)
		Me.chkRandom.Name = "chkRandom"
		Me.chkRandom.Size = New System.Drawing.Size(73, 17)
		Me.chkRandom.TabIndex = 3
		Me.chkRandom.Text = "Random"
		Me.chkRandom.UseVisualStyleBackColor = True
		'
		'cmdAggiornaCanzoni
		'
		Me.cmdAggiornaCanzoni.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.cmdAggiornaCanzoni.Location = New System.Drawing.Point(13, 141)
		Me.cmdAggiornaCanzoni.Name = "cmdAggiornaCanzoni"
		Me.cmdAggiornaCanzoni.Size = New System.Drawing.Size(180, 23)
		Me.cmdAggiornaCanzoni.TabIndex = 10
		Me.cmdAggiornaCanzoni.Text = "Refresh canzoni"
		Me.cmdAggiornaCanzoni.UseVisualStyleBackColor = True
		'
		'chkVisuaImmArtista
		'
		Me.chkVisuaImmArtista.AutoSize = True
		Me.chkVisuaImmArtista.Checked = True
		Me.chkVisuaImmArtista.CheckState = System.Windows.Forms.CheckState.Checked
		Me.chkVisuaImmArtista.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.chkVisuaImmArtista.Location = New System.Drawing.Point(15, 29)
		Me.chkVisuaImmArtista.Name = "chkVisuaImmArtista"
		Me.chkVisuaImmArtista.Size = New System.Drawing.Size(178, 17)
		Me.chkVisuaImmArtista.TabIndex = 5
		Me.chkVisuaImmArtista.Text = "Visualizza immagini artista"
		Me.chkVisuaImmArtista.UseVisualStyleBackColor = True
		'
		'cmdEliminaVuote
		'
		Me.cmdEliminaVuote.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.cmdEliminaVuote.Location = New System.Drawing.Point(301, 142)
		Me.cmdEliminaVuote.Name = "cmdEliminaVuote"
		Me.cmdEliminaVuote.Size = New System.Drawing.Size(180, 23)
		Me.cmdEliminaVuote.TabIndex = 29
		Me.cmdEliminaVuote.Text = "Pulizia completa"
		Me.cmdEliminaVuote.UseVisualStyleBackColor = True
		'
		'Label1
		'
		Me.Label1.BackColor = System.Drawing.Color.Transparent
		Me.Label1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
		Me.Label1.Location = New System.Drawing.Point(5, 244)
		Me.Label1.Name = "Label1"
		Me.Label1.Size = New System.Drawing.Size(91, 26)
		Me.Label1.TabIndex = 6
		Me.Label1.Text = "Ordinamento"
		Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		'
		'chkRicordaAscoltate
		'
		Me.chkRicordaAscoltate.AutoSize = True
		Me.chkRicordaAscoltate.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.chkRicordaAscoltate.Location = New System.Drawing.Point(12, 293)
		Me.chkRicordaAscoltate.Name = "chkRicordaAscoltate"
		Me.chkRicordaAscoltate.Size = New System.Drawing.Size(138, 17)
		Me.chkRicordaAscoltate.TabIndex = 28
		Me.chkRicordaAscoltate.Text = "Ricorda le ascoltate"
		Me.chkRicordaAscoltate.UseVisualStyleBackColor = True
		'
		'chkUltime
		'
		Me.chkUltime.AutoSize = True
		Me.chkUltime.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.chkUltime.Location = New System.Drawing.Point(12, 316)
		Me.chkUltime.Name = "chkUltime"
		Me.chkUltime.Size = New System.Drawing.Size(155, 17)
		Me.chkUltime.TabIndex = 7
		Me.chkUltime.Text = "Ultime canzoni inserite"
		Me.chkUltime.UseVisualStyleBackColor = True
		'
		'chkSuperiori
		'
		Me.chkSuperiori.AutoSize = True
		Me.chkSuperiori.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.chkSuperiori.Location = New System.Drawing.Point(44, 386)
		Me.chkSuperiori.Name = "chkSuperiori"
		Me.chkSuperiori.Size = New System.Drawing.Size(233, 17)
		Me.chkSuperiori.TabIndex = 27
		Me.chkSuperiori.Text = "Mostra anche per bellezza superiore"
		Me.chkSuperiori.UseVisualStyleBackColor = True
		'
		'chkWikipedia
		'
		Me.chkWikipedia.AutoSize = True
		Me.chkWikipedia.Checked = True
		Me.chkWikipedia.CheckState = System.Windows.Forms.CheckState.Checked
		Me.chkWikipedia.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.chkWikipedia.Location = New System.Drawing.Point(15, 49)
		Me.chkWikipedia.Name = "chkWikipedia"
		Me.chkWikipedia.Size = New System.Drawing.Size(123, 17)
		Me.chkWikipedia.TabIndex = 8
		Me.chkWikipedia.Text = "Mostra Wikipedia"
		Me.chkWikipedia.UseVisualStyleBackColor = True
		'
		'chkRicercaSuTesto
		'
		Me.chkRicercaSuTesto.AutoSize = True
		Me.chkRicercaSuTesto.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.chkRicercaSuTesto.Location = New System.Drawing.Point(128, 472)
		Me.chkRicercaSuTesto.Name = "chkRicercaSuTesto"
		Me.chkRicercaSuTesto.Size = New System.Drawing.Size(113, 17)
		Me.chkRicercaSuTesto.TabIndex = 26
		Me.chkRicercaSuTesto.Text = "Anche sul testo"
		Me.chkRicercaSuTesto.UseVisualStyleBackColor = True
		'
		'chkPartePlayer
		'
		Me.chkPartePlayer.AutoSize = True
		Me.chkPartePlayer.Checked = True
		Me.chkPartePlayer.CheckState = System.Windows.Forms.CheckState.Checked
		Me.chkPartePlayer.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.chkPartePlayer.Location = New System.Drawing.Point(15, 72)
		Me.chkPartePlayer.Name = "chkPartePlayer"
		Me.chkPartePlayer.Size = New System.Drawing.Size(180, 17)
		Me.chkPartePlayer.TabIndex = 9
		Me.chkPartePlayer.Text = "Apre direttamente il player"
		Me.chkPartePlayer.UseVisualStyleBackColor = True
		'
		'cmdEliminaBrutte
		'
		Me.cmdEliminaBrutte.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.cmdEliminaBrutte.Location = New System.Drawing.Point(246, 356)
		Me.cmdEliminaBrutte.Name = "cmdEliminaBrutte"
		Me.cmdEliminaBrutte.Size = New System.Drawing.Size(82, 23)
		Me.cmdEliminaBrutte.TabIndex = 25
		Me.cmdEliminaBrutte.Text = "Elimina brutte"
		Me.cmdEliminaBrutte.UseVisualStyleBackColor = True
		'
		'chkPrime
		'
		Me.chkPrime.AutoSize = True
		Me.chkPrime.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.chkPrime.Location = New System.Drawing.Point(12, 339)
		Me.chkPrime.Name = "chkPrime"
		Me.chkPrime.Size = New System.Drawing.Size(152, 17)
		Me.chkPrime.TabIndex = 11
		Me.chkPrime.Text = "Prime canzoni inserite"
		Me.chkPrime.UseVisualStyleBackColor = True
		'
		'chkPath
		'
		Me.chkPath.AutoSize = True
		Me.chkPath.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.chkPath.Location = New System.Drawing.Point(197, 411)
		Me.chkPath.Name = "chkPath"
		Me.chkPath.Size = New System.Drawing.Size(83, 17)
		Me.chkPath.TabIndex = 24
		Me.chkPath.Text = "Crea path"
		Me.chkPath.UseVisualStyleBackColor = True
		'
		'pnlSopra
		'
		Me.pnlSopra.Location = New System.Drawing.Point(290, 64)
		Me.pnlSopra.Name = "pnlSopra"
		Me.pnlSopra.Size = New System.Drawing.Size(62, 32)
		Me.pnlSopra.TabIndex = 6
		Me.pnlSopra.Visible = False
		'
		'cmdEstrai
		'
		Me.cmdEstrai.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.cmdEstrai.Location = New System.Drawing.Point(43, 409)
		Me.cmdEstrai.Name = "cmdEstrai"
		Me.cmdEstrai.Size = New System.Drawing.Size(148, 23)
		Me.cmdEstrai.TabIndex = 22
		Me.cmdEstrai.Text = "Estrai canzoni per filtro"
		Me.cmdEstrai.UseVisualStyleBackColor = True
		'
		'chkSpectrum
		'
		Me.chkSpectrum.AutoSize = True
		Me.chkSpectrum.Checked = True
		Me.chkSpectrum.CheckState = System.Windows.Forms.CheckState.Checked
		Me.chkSpectrum.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.chkSpectrum.Location = New System.Drawing.Point(165, 102)
		Me.chkSpectrum.Name = "chkSpectrum"
		Me.chkSpectrum.Size = New System.Drawing.Size(135, 17)
		Me.chkSpectrum.TabIndex = 12
		Me.chkSpectrum.Text = "Spectrum Analyzer"
		Me.chkSpectrum.UseVisualStyleBackColor = True
		Me.chkSpectrum.Visible = False
		'
		'chkFiltroNome
		'
		Me.chkFiltroNome.AutoSize = True
		Me.chkFiltroNome.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.chkFiltroNome.Location = New System.Drawing.Point(128, 456)
		Me.chkFiltroNome.Name = "chkFiltroNome"
		Me.chkFiltroNome.Size = New System.Drawing.Size(134, 17)
		Me.chkFiltroNome.TabIndex = 21
		Me.chkFiltroNome.Text = "Solo sul nome MP3"
		Me.chkFiltroNome.UseVisualStyleBackColor = True
		'
		'cmbSchedaAudio
		'
		Me.cmbSchedaAudio.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.cmbSchedaAudio.FormattingEnabled = True
		Me.cmbSchedaAudio.Location = New System.Drawing.Point(12, 158)
		Me.cmbSchedaAudio.Name = "cmbSchedaAudio"
		Me.cmbSchedaAudio.Size = New System.Drawing.Size(283, 21)
		Me.cmbSchedaAudio.TabIndex = 13
		Me.cmbSchedaAudio.Visible = False
		'
		'cmdFiltraTesto
		'
		Me.cmdFiltraTesto.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.cmdFiltraTesto.Location = New System.Drawing.Point(268, 436)
		Me.cmdFiltraTesto.Name = "cmdFiltraTesto"
		Me.cmdFiltraTesto.Size = New System.Drawing.Size(31, 23)
		Me.cmdFiltraTesto.TabIndex = 20
		Me.cmdFiltraTesto.Text = "->"
		Me.cmdFiltraTesto.UseVisualStyleBackColor = True
		'
		'Label2
		'
		Me.Label2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label2.ForeColor = System.Drawing.Color.Blue
		Me.Label2.Location = New System.Drawing.Point(12, 171)
		Me.Label2.Name = "Label2"
		Me.Label2.Size = New System.Drawing.Size(279, 16)
		Me.Label2.TabIndex = 14
		Me.Label2.Text = "Scheda audio per Spectrum"
		Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.Label2.Visible = False
		'
		'txtFiltroTesto
		'
		Me.txtFiltroTesto.Location = New System.Drawing.Point(128, 436)
		Me.txtFiltroTesto.Name = "txtFiltroTesto"
		Me.txtFiltroTesto.Size = New System.Drawing.Size(129, 20)
		Me.txtFiltroTesto.TabIndex = 19
		'
		'chkSpostaImmagini
		'
		Me.chkSpostaImmagini.AutoSize = True
		Me.chkSpostaImmagini.Checked = True
		Me.chkSpostaImmagini.CheckState = System.Windows.Forms.CheckState.Checked
		Me.chkSpostaImmagini.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.chkSpostaImmagini.Location = New System.Drawing.Point(15, 95)
		Me.chkSpostaImmagini.Name = "chkSpostaImmagini"
		Me.chkSpostaImmagini.Size = New System.Drawing.Size(121, 17)
		Me.chkSpostaImmagini.TabIndex = 15
		Me.chkSpostaImmagini.Text = "Sposta immagini"
		Me.chkSpostaImmagini.UseVisualStyleBackColor = True
		'
		'chkFiltroTesto
		'
		Me.chkFiltroTesto.AutoSize = True
		Me.chkFiltroTesto.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.chkFiltroTesto.Location = New System.Drawing.Point(15, 438)
		Me.chkFiltroTesto.Name = "chkFiltroTesto"
		Me.chkFiltroTesto.Size = New System.Drawing.Size(109, 17)
		Me.chkFiltroTesto.TabIndex = 18
		Me.chkFiltroTesto.Text = "Filtra per testo"
		Me.chkFiltroTesto.UseVisualStyleBackColor = True
		'
		'chkBellezza
		'
		Me.chkBellezza.AutoSize = True
		Me.chkBellezza.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.chkBellezza.Location = New System.Drawing.Point(12, 362)
		Me.chkBellezza.Name = "chkBellezza"
		Me.chkBellezza.Size = New System.Drawing.Size(127, 17)
		Me.chkBellezza.TabIndex = 16
		Me.chkBellezza.Text = "Filtra per bellezza"
		Me.chkBellezza.UseVisualStyleBackColor = True
		'
		'cmbBellezza
		'
		Me.cmbBellezza.FormattingEnabled = True
		Me.cmbBellezza.Location = New System.Drawing.Point(145, 358)
		Me.cmbBellezza.Name = "cmbBellezza"
		Me.cmbBellezza.Size = New System.Drawing.Size(93, 21)
		Me.cmbBellezza.TabIndex = 17
		'
		'tmrVisualizzaImmArtista
		'
		Me.tmrVisualizzaImmArtista.Interval = 1000
		'
		'pnlStelleInterno
		'
		Me.pnlStelleInterno.BackColor = System.Drawing.Color.Transparent
		Me.pnlStelleInterno.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.pnlStelleInterno.Controls.Add(Me.picStelle7Interno)
		Me.pnlStelleInterno.Controls.Add(Me.picStelle6Interno)
		Me.pnlStelleInterno.Controls.Add(Me.picStelle1Interno)
		Me.pnlStelleInterno.Controls.Add(Me.picStelle2Interno)
		Me.pnlStelleInterno.Controls.Add(Me.picStelle3Interno)
		Me.pnlStelleInterno.Controls.Add(Me.picStelle4Interno)
		Me.pnlStelleInterno.Controls.Add(Me.picStelle5Interno)
		Me.pnlStelleInterno.Location = New System.Drawing.Point(386, 63)
		Me.pnlStelleInterno.Name = "pnlStelleInterno"
		Me.pnlStelleInterno.Size = New System.Drawing.Size(230, 30)
		Me.pnlStelleInterno.TabIndex = 12
		'
		'picStelle7Interno
		'
		Me.picStelle7Interno.Location = New System.Drawing.Point(2, 0)
		Me.picStelle7Interno.Name = "picStelle7Interno"
		Me.picStelle7Interno.Size = New System.Drawing.Size(32, 29)
		Me.picStelle7Interno.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
		Me.picStelle7Interno.TabIndex = 6
		Me.picStelle7Interno.TabStop = False
		'
		'picStelle6Interno
		'
		Me.picStelle6Interno.Location = New System.Drawing.Point(34, 0)
		Me.picStelle6Interno.Name = "picStelle6Interno"
		Me.picStelle6Interno.Size = New System.Drawing.Size(32, 29)
		Me.picStelle6Interno.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
		Me.picStelle6Interno.TabIndex = 5
		Me.picStelle6Interno.TabStop = False
		'
		'picStelle1Interno
		'
		Me.picStelle1Interno.Location = New System.Drawing.Point(194, 0)
		Me.picStelle1Interno.Name = "picStelle1Interno"
		Me.picStelle1Interno.Size = New System.Drawing.Size(32, 29)
		Me.picStelle1Interno.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
		Me.picStelle1Interno.TabIndex = 4
		Me.picStelle1Interno.TabStop = False
		'
		'picStelle2Interno
		'
		Me.picStelle2Interno.Location = New System.Drawing.Point(162, 0)
		Me.picStelle2Interno.Name = "picStelle2Interno"
		Me.picStelle2Interno.Size = New System.Drawing.Size(32, 29)
		Me.picStelle2Interno.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
		Me.picStelle2Interno.TabIndex = 3
		Me.picStelle2Interno.TabStop = False
		'
		'picStelle3Interno
		'
		Me.picStelle3Interno.Location = New System.Drawing.Point(130, 0)
		Me.picStelle3Interno.Name = "picStelle3Interno"
		Me.picStelle3Interno.Size = New System.Drawing.Size(32, 29)
		Me.picStelle3Interno.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
		Me.picStelle3Interno.TabIndex = 2
		Me.picStelle3Interno.TabStop = False
		'
		'picStelle4Interno
		'
		Me.picStelle4Interno.Location = New System.Drawing.Point(98, 0)
		Me.picStelle4Interno.Name = "picStelle4Interno"
		Me.picStelle4Interno.Size = New System.Drawing.Size(32, 29)
		Me.picStelle4Interno.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
		Me.picStelle4Interno.TabIndex = 1
		Me.picStelle4Interno.TabStop = False
		'
		'picStelle5Interno
		'
		Me.picStelle5Interno.Location = New System.Drawing.Point(66, 0)
		Me.picStelle5Interno.Name = "picStelle5Interno"
		Me.picStelle5Interno.Size = New System.Drawing.Size(32, 29)
		Me.picStelle5Interno.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
		Me.picStelle5Interno.TabIndex = 0
		Me.picStelle5Interno.TabStop = False
		'
		'cmdRefreshTesto
		'
		Me.cmdRefreshTesto.Location = New System.Drawing.Point(364, 8)
		Me.cmdRefreshTesto.Name = "cmdRefreshTesto"
		Me.cmdRefreshTesto.Size = New System.Drawing.Size(94, 23)
		Me.cmdRefreshTesto.TabIndex = 8
		Me.cmdRefreshTesto.Text = "Refresh Testo"
		Me.cmdRefreshTesto.UseVisualStyleBackColor = True
		Me.cmdRefreshTesto.Visible = False
		'
		'tmrCambioImmagine
		'
		Me.tmrCambioImmagine.Interval = 25000
		'
		'tmrNascondeBarra
		'
		Me.tmrNascondeBarra.Interval = 1000
		'
		'pnlFinestra
		'
		Me.pnlFinestra.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
		Me.pnlFinestra.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.pnlFinestra.Controls.Add(Me.cmdMassimizza)
		Me.pnlFinestra.Controls.Add(Me.cmdMinimizzaForm)
		Me.pnlFinestra.Controls.Add(Me.cmdChiudeForm)
		Me.pnlFinestra.Location = New System.Drawing.Point(654, 342)
		Me.pnlFinestra.Name = "pnlFinestra"
		Me.pnlFinestra.Size = New System.Drawing.Size(94, 31)
		Me.pnlFinestra.TabIndex = 7
		'
		'cmdMassimizza
		'
		Me.cmdMassimizza.Location = New System.Drawing.Point(34, 3)
		Me.cmdMassimizza.Name = "cmdMassimizza"
		Me.cmdMassimizza.Size = New System.Drawing.Size(25, 23)
		Me.cmdMassimizza.TabIndex = 2
		Me.cmdMassimizza.Text = "/\"
		Me.cmdMassimizza.UseVisualStyleBackColor = True
		Me.cmdMassimizza.Visible = False
		'
		'cmdMinimizzaForm
		'
		Me.cmdMinimizzaForm.Location = New System.Drawing.Point(6, 3)
		Me.cmdMinimizzaForm.Name = "cmdMinimizzaForm"
		Me.cmdMinimizzaForm.Size = New System.Drawing.Size(25, 23)
		Me.cmdMinimizzaForm.TabIndex = 1
		Me.cmdMinimizzaForm.Text = "\/"
		Me.cmdMinimizzaForm.UseVisualStyleBackColor = True
		Me.cmdMinimizzaForm.Visible = False
		'
		'cmdChiudeForm
		'
		Me.cmdChiudeForm.BackColor = System.Drawing.Color.Red
		Me.cmdChiudeForm.Font = New System.Drawing.Font("Consolas", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.cmdChiudeForm.ForeColor = System.Drawing.Color.White
		Me.cmdChiudeForm.Location = New System.Drawing.Point(62, 3)
		Me.cmdChiudeForm.Name = "cmdChiudeForm"
		Me.cmdChiudeForm.Size = New System.Drawing.Size(25, 23)
		Me.cmdChiudeForm.TabIndex = 0
		Me.cmdChiudeForm.Text = "X"
		Me.cmdChiudeForm.UseVisualStyleBackColor = False
		Me.cmdChiudeForm.Visible = False
		'
		'tmrCanzone
		'
		Me.tmrCanzone.Interval = 500
		'
		'pnlModifiche
		'
		Me.pnlModifiche.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
		Me.pnlModifiche.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.pnlModifiche.Controls.Add(Me.cmdPlaylist)
		Me.pnlModifiche.Controls.Add(Me.cmdAnnullaMod)
		Me.pnlModifiche.Controls.Add(Me.cmdRinomina)
		Me.pnlModifiche.Controls.Add(Me.cmdElimina)
		Me.pnlModifiche.Controls.Add(Me.lblNomeInModifica)
		Me.pnlModifiche.Location = New System.Drawing.Point(831, 566)
		Me.pnlModifiche.Name = "pnlModifiche"
		Me.pnlModifiche.Size = New System.Drawing.Size(175, 112)
		Me.pnlModifiche.TabIndex = 7
		Me.pnlModifiche.Visible = False
		'
		'cmdPlaylist
		'
		Me.cmdPlaylist.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.cmdPlaylist.Location = New System.Drawing.Point(3, 69)
		Me.cmdPlaylist.Name = "cmdPlaylist"
		Me.cmdPlaylist.Size = New System.Drawing.Size(166, 20)
		Me.cmdPlaylist.TabIndex = 10
		Me.cmdPlaylist.Text = "Mette in playlist"
		Me.cmdPlaylist.UseVisualStyleBackColor = True
		Me.cmdPlaylist.Visible = False
		'
		'cmdAnnullaMod
		'
		Me.cmdAnnullaMod.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.cmdAnnullaMod.Location = New System.Drawing.Point(3, 87)
		Me.cmdAnnullaMod.Name = "cmdAnnullaMod"
		Me.cmdAnnullaMod.Size = New System.Drawing.Size(166, 20)
		Me.cmdAnnullaMod.TabIndex = 9
		Me.cmdAnnullaMod.Text = "Annulla"
		Me.cmdAnnullaMod.UseVisualStyleBackColor = True
		'
		'cmdRinomina
		'
		Me.cmdRinomina.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.cmdRinomina.Location = New System.Drawing.Point(3, 50)
		Me.cmdRinomina.Name = "cmdRinomina"
		Me.cmdRinomina.Size = New System.Drawing.Size(166, 20)
		Me.cmdRinomina.TabIndex = 8
		Me.cmdRinomina.Text = "Rinomina"
		Me.cmdRinomina.UseVisualStyleBackColor = True
		'
		'cmdElimina
		'
		Me.cmdElimina.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.cmdElimina.Location = New System.Drawing.Point(3, 31)
		Me.cmdElimina.Name = "cmdElimina"
		Me.cmdElimina.Size = New System.Drawing.Size(166, 20)
		Me.cmdElimina.TabIndex = 7
		Me.cmdElimina.Text = "Elimina"
		Me.cmdElimina.UseVisualStyleBackColor = True
		'
		'lblNomeInModifica
		'
		Me.lblNomeInModifica.BackColor = System.Drawing.Color.Transparent
		Me.lblNomeInModifica.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblNomeInModifica.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
		Me.lblNomeInModifica.Location = New System.Drawing.Point(3, -1)
		Me.lblNomeInModifica.Name = "lblNomeInModifica"
		Me.lblNomeInModifica.Size = New System.Drawing.Size(167, 23)
		Me.lblNomeInModifica.TabIndex = 6
		Me.lblNomeInModifica.Text = "Label2"
		Me.lblNomeInModifica.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		'
		'tmrSpostaScrittaTitolo
		'
		Me.tmrSpostaScrittaTitolo.Interval = 5000
		'
		'tmrEffettoImmagine
		'
		'
		'lblAggiornamentoCanzoni
		'
		Me.lblAggiornamentoCanzoni.AutoSize = True
		Me.lblAggiornamentoCanzoni.BackColor = System.Drawing.Color.Olive
		Me.lblAggiornamentoCanzoni.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.lblAggiornamentoCanzoni.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblAggiornamentoCanzoni.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
		Me.lblAggiornamentoCanzoni.Location = New System.Drawing.Point(297, 12)
		Me.lblAggiornamentoCanzoni.Name = "lblAggiornamentoCanzoni"
		Me.lblAggiornamentoCanzoni.Size = New System.Drawing.Size(30, 17)
		Me.lblAggiornamentoCanzoni.TabIndex = 8
		Me.lblAggiornamentoCanzoni.Text = " ***"
		Me.lblAggiornamentoCanzoni.Visible = False
		'
		'pnlFiltro
		'
		Me.pnlFiltro.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
		Me.pnlFiltro.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.pnlFiltro.Controls.Add(Me.cmdAnnullaFiltro)
		Me.pnlFiltro.Controls.Add(Me.cmdFiltro)
		Me.pnlFiltro.Controls.Add(Me.lblFiltro)
		Me.pnlFiltro.Location = New System.Drawing.Point(831, 475)
		Me.pnlFiltro.Name = "pnlFiltro"
		Me.pnlFiltro.Size = New System.Drawing.Size(175, 85)
		Me.pnlFiltro.TabIndex = 9
		Me.pnlFiltro.Visible = False
		'
		'cmdAnnullaFiltro
		'
		Me.cmdAnnullaFiltro.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.cmdAnnullaFiltro.Location = New System.Drawing.Point(4, 60)
		Me.cmdAnnullaFiltro.Name = "cmdAnnullaFiltro"
		Me.cmdAnnullaFiltro.Size = New System.Drawing.Size(166, 20)
		Me.cmdAnnullaFiltro.TabIndex = 9
		Me.cmdAnnullaFiltro.Text = "Annulla"
		Me.cmdAnnullaFiltro.UseVisualStyleBackColor = True
		'
		'cmdFiltro
		'
		Me.cmdFiltro.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.cmdFiltro.Location = New System.Drawing.Point(3, 34)
		Me.cmdFiltro.Name = "cmdFiltro"
		Me.cmdFiltro.Size = New System.Drawing.Size(166, 20)
		Me.cmdFiltro.TabIndex = 7
		Me.cmdFiltro.Text = "Filtra"
		Me.cmdFiltro.UseVisualStyleBackColor = True
		'
		'lblFiltro
		'
		Me.lblFiltro.BackColor = System.Drawing.Color.Transparent
		Me.lblFiltro.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblFiltro.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
		Me.lblFiltro.Location = New System.Drawing.Point(3, -1)
		Me.lblFiltro.Name = "lblFiltro"
		Me.lblFiltro.Size = New System.Drawing.Size(167, 28)
		Me.lblFiltro.TabIndex = 6
		Me.lblFiltro.Text = "Label2"
		Me.lblFiltro.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		'
		'tmrFadeOUT
		'
		'
		'pnlSpectrum2
		'
		Me.pnlSpectrum2.BackColor = System.Drawing.Color.Black
		Me.pnlSpectrum2.Location = New System.Drawing.Point(654, 49)
		Me.pnlSpectrum2.Name = "pnlSpectrum2"
		Me.pnlSpectrum2.Size = New System.Drawing.Size(60, 230)
		Me.pnlSpectrum2.TabIndex = 11
		Me.pnlSpectrum2.Visible = False
		'
		'tmrRefreshTesto
		'
		Me.tmrRefreshTesto.Interval = 3000
		'
		'lstTraduzione
		'
		Me.lstTraduzione.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lstTraduzione.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lstTraduzione.FormattingEnabled = True
		Me.lstTraduzione.HorizontalScrollbar = True
		Me.lstTraduzione.Location = New System.Drawing.Point(538, 440)
		Me.lstTraduzione.Name = "lstTraduzione"
		Me.lstTraduzione.Size = New System.Drawing.Size(244, 260)
		Me.lstTraduzione.TabIndex = 13
		'
		'tmrTesto
		'
		Me.tmrTesto.Interval = 1000
		'
		'picLingua
		'
		Me.picLingua.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
		Me.picLingua.Location = New System.Drawing.Point(249, 15)
		Me.picLingua.Name = "picLingua"
		Me.picLingua.Size = New System.Drawing.Size(30, 30)
		Me.picLingua.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
		Me.picLingua.TabIndex = 30
		Me.picLingua.TabStop = False
		'
		'tmrPartenza
		'
		'
		'lblTesti
		'
		Me.lblTesti.BackColor = System.Drawing.Color.Olive
		Me.lblTesti.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.lblTesti.Font = New System.Drawing.Font("Arial Rounded MT Bold", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblTesti.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
		Me.lblTesti.Location = New System.Drawing.Point(375, 477)
		Me.lblTesti.Name = "lblTesti"
		Me.lblTesti.Size = New System.Drawing.Size(30, 15)
		Me.lblTesti.TabIndex = 31
		Me.lblTesti.Text = " ***"
		Me.lblTesti.Visible = False
		'
		'pnlTuttoSchermo
		'
		Me.pnlTuttoSchermo.Location = New System.Drawing.Point(249, 64)
		Me.pnlTuttoSchermo.Name = "pnlTuttoSchermo"
		Me.pnlTuttoSchermo.Size = New System.Drawing.Size(112, 30)
		Me.pnlTuttoSchermo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
		Me.pnlTuttoSchermo.TabIndex = 37
		Me.pnlTuttoSchermo.TabStop = False
		'
		'tmrPrendeThumbs
		'
		Me.tmrPrendeThumbs.Interval = 1000
		'
		'pnlImmagineArtista
		'
		Me.pnlImmagineArtista.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
		Me.pnlImmagineArtista.Controls.Add(Me.cmdRicaricaMembri)
		Me.pnlImmagineArtista.Controls.Add(Me.pnlMembriInterno)
		Me.pnlImmagineArtista.Controls.Add(Me.pnlTestoInterno)
		Me.pnlImmagineArtista.Controls.Add(Me.cmdApreCartella)
		Me.pnlImmagineArtista.Controls.Add(Me.cmdRefreshtestoInterno)
		Me.pnlImmagineArtista.Controls.Add(Me.cmdTraduzione)
		Me.pnlImmagineArtista.Controls.Add(Me.cmdTesto)
		Me.pnlImmagineArtista.Controls.Add(Me.cmdSalva)
		Me.pnlImmagineArtista.Controls.Add(Me.cmdVisualizzaMembri)
		Me.pnlImmagineArtista.Controls.Add(Me.cmdEliminaImmagineArtista)
		Me.pnlImmagineArtista.Controls.Add(Me.lblNomeArtistaImm)
		Me.pnlImmagineArtista.Controls.Add(Me.picImmagineArtista)
		Me.pnlImmagineArtista.Controls.Add(Me.pnlSotto)
		Me.pnlImmagineArtista.Controls.Add(Me.lblNomeImmArtista)
		Me.pnlImmagineArtista.Location = New System.Drawing.Point(32, 475)
		Me.pnlImmagineArtista.Name = "pnlImmagineArtista"
		Me.pnlImmagineArtista.Size = New System.Drawing.Size(248, 100)
		Me.pnlImmagineArtista.TabIndex = 6
		'
		'cmdRicaricaMembri
		'
		Me.cmdRicaricaMembri.Font = New System.Drawing.Font("Verdana", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.cmdRicaricaMembri.Location = New System.Drawing.Point(214, 5)
		Me.cmdRicaricaMembri.Name = "cmdRicaricaMembri"
		Me.cmdRicaricaMembri.Size = New System.Drawing.Size(31, 17)
		Me.cmdRicaricaMembri.TabIndex = 100
		Me.cmdRicaricaMembri.Text = "RM"
		Me.cmdRicaricaMembri.UseVisualStyleBackColor = True
		'
		'pnlMembriInterno
		'
		Me.pnlMembriInterno.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.pnlMembriInterno.Location = New System.Drawing.Point(199, 66)
		Me.pnlMembriInterno.Name = "pnlMembriInterno"
		Me.pnlMembriInterno.Size = New System.Drawing.Size(46, 28)
		Me.pnlMembriInterno.TabIndex = 15
		'
		'pnlTestoInterno
		'
		Me.pnlTestoInterno.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.pnlTestoInterno.Location = New System.Drawing.Point(160, 35)
		Me.pnlTestoInterno.Name = "pnlTestoInterno"
		Me.pnlTestoInterno.Size = New System.Drawing.Size(46, 28)
		Me.pnlTestoInterno.TabIndex = 15
		'
		'cmdApreCartella
		'
		Me.cmdApreCartella.Font = New System.Drawing.Font("Verdana", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.cmdApreCartella.Location = New System.Drawing.Point(175, 5)
		Me.cmdApreCartella.Name = "cmdApreCartella"
		Me.cmdApreCartella.Size = New System.Drawing.Size(31, 17)
		Me.cmdApreCartella.TabIndex = 14
		Me.cmdApreCartella.Text = ">S"
		Me.cmdApreCartella.UseVisualStyleBackColor = True
		'
		'cmdRefreshtestoInterno
		'
		Me.cmdRefreshtestoInterno.Font = New System.Drawing.Font("Verdana", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.cmdRefreshtestoInterno.Location = New System.Drawing.Point(100, 5)
		Me.cmdRefreshtestoInterno.Name = "cmdRefreshtestoInterno"
		Me.cmdRefreshtestoInterno.Size = New System.Drawing.Size(29, 17)
		Me.cmdRefreshtestoInterno.TabIndex = 12
		Me.cmdRefreshtestoInterno.Text = "R"
		Me.cmdRefreshtestoInterno.UseVisualStyleBackColor = True
		'
		'cmdTraduzione
		'
		Me.cmdTraduzione.Font = New System.Drawing.Font("Verdana", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.cmdTraduzione.Location = New System.Drawing.Point(118, 5)
		Me.cmdTraduzione.Name = "cmdTraduzione"
		Me.cmdTraduzione.Size = New System.Drawing.Size(29, 17)
		Me.cmdTraduzione.TabIndex = 13
		Me.cmdTraduzione.Text = "*"
		Me.cmdTraduzione.UseVisualStyleBackColor = True
		'
		'cmdTesto
		'
		Me.cmdTesto.Font = New System.Drawing.Font("Verdana", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.cmdTesto.Location = New System.Drawing.Point(69, 5)
		Me.cmdTesto.Name = "cmdTesto"
		Me.cmdTesto.Size = New System.Drawing.Size(29, 17)
		Me.cmdTesto.TabIndex = 10
		Me.cmdTesto.Text = "T"
		Me.cmdTesto.UseVisualStyleBackColor = True
		'
		'cmdSalva
		'
		Me.cmdSalva.Font = New System.Drawing.Font("Verdana", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.cmdSalva.Location = New System.Drawing.Point(34, 3)
		Me.cmdSalva.Name = "cmdSalva"
		Me.cmdSalva.Size = New System.Drawing.Size(29, 17)
		Me.cmdSalva.TabIndex = 8
		Me.cmdSalva.Text = "S"
		Me.cmdSalva.UseVisualStyleBackColor = True
		'
		'cmdVisualizzaMembri
		'
		Me.cmdVisualizzaMembri.Font = New System.Drawing.Font("Verdana", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.cmdVisualizzaMembri.Location = New System.Drawing.Point(34, 3)
		Me.cmdVisualizzaMembri.Name = "cmdVisualizzaMembri"
		Me.cmdVisualizzaMembri.Size = New System.Drawing.Size(29, 17)
		Me.cmdVisualizzaMembri.TabIndex = 99
		Me.cmdVisualizzaMembri.Text = "M"
		Me.cmdVisualizzaMembri.UseVisualStyleBackColor = True
		'
		'cmdEliminaImmagineArtista
		'
		Me.cmdEliminaImmagineArtista.Font = New System.Drawing.Font("Verdana", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.cmdEliminaImmagineArtista.Location = New System.Drawing.Point(3, 3)
		Me.cmdEliminaImmagineArtista.Name = "cmdEliminaImmagineArtista"
		Me.cmdEliminaImmagineArtista.Size = New System.Drawing.Size(29, 17)
		Me.cmdEliminaImmagineArtista.TabIndex = 3
		Me.cmdEliminaImmagineArtista.Text = "D"
		Me.cmdEliminaImmagineArtista.UseVisualStyleBackColor = True
		'
		'lblNomeArtistaImm
		'
		Me.lblNomeArtistaImm.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
		Me.lblNomeArtistaImm.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.lblNomeArtistaImm.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblNomeArtistaImm.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
		Me.lblNomeArtistaImm.Location = New System.Drawing.Point(141, 12)
		Me.lblNomeArtistaImm.Name = "lblNomeArtistaImm"
		Me.lblNomeArtistaImm.Size = New System.Drawing.Size(65, 20)
		Me.lblNomeArtistaImm.TabIndex = 5
		Me.lblNomeArtistaImm.Text = "sss"
		Me.lblNomeArtistaImm.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		'
		'picImmagineArtista
		'
		Me.picImmagineArtista.Location = New System.Drawing.Point(17, 14)
		Me.picImmagineArtista.Name = "picImmagineArtista"
		Me.picImmagineArtista.Size = New System.Drawing.Size(131, 66)
		Me.picImmagineArtista.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
		Me.picImmagineArtista.TabIndex = 2
		Me.picImmagineArtista.TabStop = False
		'
		'pnlSotto
		'
		Me.pnlSotto.Location = New System.Drawing.Point(69, 34)
		Me.pnlSotto.Name = "pnlSotto"
		Me.pnlSotto.Size = New System.Drawing.Size(62, 32)
		Me.pnlSotto.TabIndex = 7
		Me.pnlSotto.Visible = False
		'
		'lblNomeImmArtista
		'
		Me.lblNomeImmArtista.AutoSize = True
		Me.lblNomeImmArtista.Location = New System.Drawing.Point(146, 66)
		Me.lblNomeImmArtista.Name = "lblNomeImmArtista"
		Me.lblNomeImmArtista.Size = New System.Drawing.Size(39, 13)
		Me.lblNomeImmArtista.TabIndex = 4
		Me.lblNomeImmArtista.Text = "Label1"
		Me.lblNomeImmArtista.Visible = False
		'
		'frmPlayer
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.BackColor = System.Drawing.Color.Black
		Me.ClientSize = New System.Drawing.Size(868, 670)
		Me.ControlBox = False
		Me.Controls.Add(Me.pnlTuttoSchermo)
		Me.Controls.Add(Me.pnlFinestra)
		Me.Controls.Add(Me.pnlImpostazioni)
		Me.Controls.Add(Me.pnlStelleInterno)
		Me.Controls.Add(Me.pnlTasti)
		Me.Controls.Add(Me.pnlImmagineArtista)
		Me.Controls.Add(Me.lblTesti)
		Me.Controls.Add(Me.lblFiltroImpostato)
		Me.Controls.Add(Me.picLingua)
		Me.Controls.Add(Me.cmdRefreshTesto)
		Me.Controls.Add(Me.pnlFiltro)
		Me.Controls.Add(Me.pnlModifiche)
		Me.Controls.Add(Me.pnlSpectrum2)
		Me.Controls.Add(Me.lblAggiornamentoCanzoni)
		Me.Controls.Add(Me.lstTesto)
		Me.Controls.Add(Me.pnlCanzoni)
		Me.Controls.Add(Me.pnlImmagine)
		Me.Controls.Add(Me.lstTraduzione)
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
		Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
		Me.Name = "frmPlayer"
		Me.pnlTasti.ResumeLayout(False)
		Me.pnlTasti.PerformLayout()
		CType(Me.BarraAvanzamentoInterna, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.picSettings, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.picPlay, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.picIndietro, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.picAvanti, System.ComponentModel.ISupportInitialize).EndInit()
		Me.pnlImmagine.ResumeLayout(False)
		Me.pnlStelle.ResumeLayout(False)
		CType(Me.picStelle7, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.picStelle6, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.picStelle1, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.picStelle2, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.picStelle3, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.picStelle4, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.picStelle5, System.ComponentModel.ISupportInitialize).EndInit()
		Me.pnlBarra.ResumeLayout(False)
		Me.pnlBarra.PerformLayout()
		CType(Me.BarraAvanzamento, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.picMP3, System.ComponentModel.ISupportInitialize).EndInit()
		Me.pnlCanzoni.ResumeLayout(False)
		Me.pnlImpostazioni.ResumeLayout(False)
		Me.pnlImpostazioniInterno.ResumeLayout(False)
		Me.pnlImpostazioniInterno.PerformLayout()
		Me.pnlAvanzamento.ResumeLayout(False)
		Me.pnlStelleInterno.ResumeLayout(False)
		CType(Me.picStelle7Interno, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.picStelle6Interno, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.picStelle1Interno, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.picStelle2Interno, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.picStelle3Interno, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.picStelle4Interno, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.picStelle5Interno, System.ComponentModel.ISupportInitialize).EndInit()
		Me.pnlFinestra.ResumeLayout(False)
		Me.pnlModifiche.ResumeLayout(False)
		Me.pnlFiltro.ResumeLayout(False)
		CType(Me.picLingua, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.pnlTuttoSchermo, System.ComponentModel.ISupportInitialize).EndInit()
		Me.pnlImmagineArtista.ResumeLayout(False)
		Me.pnlImmagineArtista.PerformLayout()
		CType(Me.picImmagineArtista, System.ComponentModel.ISupportInitialize).EndInit()
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub
	Friend WithEvents lstTesto As System.Windows.Forms.ListBox
	Friend WithEvents pnlTasti As System.Windows.Forms.Panel
	Friend WithEvents pnlImmagine As System.Windows.Forms.Panel
	Friend WithEvents picMP3 As System.Windows.Forms.PictureBox
	Friend WithEvents pnlCanzoni As System.Windows.Forms.Panel
	Friend WithEvents lstCanzone As System.Windows.Forms.ListBox
	Friend WithEvents lstAlbum As System.Windows.Forms.ListBox
	Friend WithEvents lstArtista As System.Windows.Forms.ListBox
	Friend WithEvents pnlImpostazioni As System.Windows.Forms.Panel
	Friend WithEvents cmdChiudeImpostazioni As System.Windows.Forms.Button
	Friend WithEvents lblNomeCanzone As System.Windows.Forms.Label
	Friend WithEvents chkScaricaLyric As System.Windows.Forms.CheckBox
	Friend WithEvents tmrVisualizzaImmArtista As System.Windows.Forms.Timer
	Friend WithEvents pnlImmagineArtista As DoubleBufferedPanels
	Friend WithEvents picImmagineArtista As System.Windows.Forms.PictureBox
	Friend WithEvents tmrCambioImmagine As System.Windows.Forms.Timer
	Friend WithEvents lblCanzone As System.Windows.Forms.Label
	Friend WithEvents lblAlbum As System.Windows.Forms.Label
	Friend WithEvents lblArtista As System.Windows.Forms.Label
	Friend WithEvents tmrNascondeBarra As System.Windows.Forms.Timer
	Friend WithEvents cmdEliminaImmagineArtista As System.Windows.Forms.Button
	Friend WithEvents lblNomeImmArtista As System.Windows.Forms.Label
	Friend WithEvents chkVisuaImmArtista As System.Windows.Forms.CheckBox
	Friend WithEvents pnlFinestra As System.Windows.Forms.Panel
	Friend WithEvents cmdMinimizzaForm As System.Windows.Forms.Button
	Friend WithEvents cmdChiudeForm As System.Windows.Forms.Button
	Friend WithEvents tmrCanzone As System.Windows.Forms.Timer
	Friend WithEvents pnlBarra As System.Windows.Forms.Panel
	Friend WithEvents lblTempoTotale As System.Windows.Forms.Label
	Friend WithEvents lblTempoPassato As System.Windows.Forms.Label
	Friend WithEvents BarraAvanzamento As System.Windows.Forms.TrackBar
	Friend WithEvents Label1 As System.Windows.Forms.Label
	Friend WithEvents chkUltime As System.Windows.Forms.CheckBox
	Friend WithEvents chkRandom As System.Windows.Forms.CheckBox
	Friend WithEvents picAvanti As System.Windows.Forms.PictureBox
	Friend WithEvents picIndietro As System.Windows.Forms.PictureBox
	Friend WithEvents picPlay As System.Windows.Forms.PictureBox
	Friend WithEvents picSettings As System.Windows.Forms.PictureBox
	Friend WithEvents chkWikipedia As System.Windows.Forms.CheckBox
	Friend WithEvents chkPartePlayer As System.Windows.Forms.CheckBox
	Friend WithEvents pnlModifiche As System.Windows.Forms.Panel
	Friend WithEvents lblNomeInModifica As System.Windows.Forms.Label
	Friend WithEvents cmdRinomina As System.Windows.Forms.Button
	Friend WithEvents cmdElimina As System.Windows.Forms.Button
	Friend WithEvents cmdAnnullaMod As System.Windows.Forms.Button
	Friend WithEvents tmrSpostaScrittaTitolo As System.Windows.Forms.Timer
	Friend WithEvents lblNomeArtistaImm As System.Windows.Forms.Label
	Friend WithEvents tmrEffettoImmagine As System.Windows.Forms.Timer
	Friend WithEvents lblAggiornamentoCanzoni As System.Windows.Forms.Label
	Friend WithEvents cmdAggiornaCanzoni As System.Windows.Forms.Button
	Friend WithEvents pnlFiltro As System.Windows.Forms.Panel
	Friend WithEvents cmdAnnullaFiltro As System.Windows.Forms.Button
	Friend WithEvents cmdFiltro As System.Windows.Forms.Button
	Friend WithEvents lblFiltro As System.Windows.Forms.Label
	Friend WithEvents lblFiltroImpostato As System.Windows.Forms.Label
	Friend WithEvents chkPrime As System.Windows.Forms.CheckBox
	Friend WithEvents tmrFadeOUT As System.Windows.Forms.Timer
	Friend WithEvents pnlSpectrum As System.Windows.Forms.Panel
	Friend WithEvents chkSpectrum As System.Windows.Forms.CheckBox
	Friend WithEvents pnlSpectrum2 As System.Windows.Forms.Panel
	Friend WithEvents Label2 As System.Windows.Forms.Label
	Friend WithEvents cmbSchedaAudio As System.Windows.Forms.ComboBox
	Friend WithEvents chkSpostaImmagini As System.Windows.Forms.CheckBox
	Friend WithEvents pnlSopra As System.Windows.Forms.Panel
	Friend WithEvents pnlSotto As System.Windows.Forms.Panel
	Friend WithEvents cmdPlaylist As System.Windows.Forms.Button
	Friend WithEvents pnlStelle As System.Windows.Forms.Panel
	Friend WithEvents picStelle1 As System.Windows.Forms.PictureBox
	Friend WithEvents picStelle2 As System.Windows.Forms.PictureBox
	Friend WithEvents picStelle3 As System.Windows.Forms.PictureBox
	Friend WithEvents picStelle4 As System.Windows.Forms.PictureBox
	Friend WithEvents picStelle5 As System.Windows.Forms.PictureBox
	Friend WithEvents cmbBellezza As System.Windows.Forms.ComboBox
	Friend WithEvents chkBellezza As System.Windows.Forms.CheckBox
	Friend WithEvents picStelle7 As System.Windows.Forms.PictureBox
	Friend WithEvents picStelle6 As System.Windows.Forms.PictureBox
	Friend WithEvents cmdFiltraTesto As System.Windows.Forms.Button
	Friend WithEvents txtFiltroTesto As System.Windows.Forms.TextBox
	Friend WithEvents chkFiltroTesto As System.Windows.Forms.CheckBox
	Friend WithEvents chkFiltroNome As System.Windows.Forms.CheckBox
	Friend WithEvents cmdRefreshTesto As System.Windows.Forms.Button
	Friend WithEvents tmrRefreshTesto As System.Windows.Forms.Timer
	Friend WithEvents cmdEstrai As System.Windows.Forms.Button
	Friend WithEvents pnlAvanzamento As System.Windows.Forms.Panel
	Friend WithEvents lblAvanzamento As System.Windows.Forms.Label
	Friend WithEvents lblAvanzamentoFile As System.Windows.Forms.Label
	Friend WithEvents chkPath As System.Windows.Forms.CheckBox
	Friend WithEvents cmdEliminaBrutte As System.Windows.Forms.Button
	Friend WithEvents chkRicercaSuTesto As System.Windows.Forms.CheckBox
	Friend WithEvents chkSuperiori As System.Windows.Forms.CheckBox
	Friend WithEvents chkRicordaAscoltate As System.Windows.Forms.CheckBox
	Friend WithEvents cmdEliminaVuote As System.Windows.Forms.Button
	Friend WithEvents cmdSalva As Button
	Friend WithEvents cmdVisualizzaMembri As Button
	Friend WithEvents cmdTesto As System.Windows.Forms.Button
	Friend WithEvents pnlStelleInterno As System.Windows.Forms.Panel
	Friend WithEvents picStelle7Interno As System.Windows.Forms.PictureBox
	Friend WithEvents picStelle6Interno As System.Windows.Forms.PictureBox
	Friend WithEvents picStelle1Interno As System.Windows.Forms.PictureBox
	Friend WithEvents picStelle2Interno As System.Windows.Forms.PictureBox
	Friend WithEvents picStelle3Interno As System.Windows.Forms.PictureBox
	Friend WithEvents picStelle4Interno As System.Windows.Forms.PictureBox
	Friend WithEvents picStelle5Interno As System.Windows.Forms.PictureBox
	Friend WithEvents cmdRefreshtestoInterno As System.Windows.Forms.Button
	Friend WithEvents lstTraduzione As System.Windows.Forms.ListBox
	Friend WithEvents tmrTesto As Timer
	Friend WithEvents picLingua As PictureBox
	Friend WithEvents cmdTraduzione As Button
	Friend WithEvents cmdApreCartella As System.Windows.Forms.Button
	Friend WithEvents tmrPartenza As System.Windows.Forms.Timer
	Friend WithEvents cmdGestioneTAG As System.Windows.Forms.Button
	Friend WithEvents pnlImpostazioniInterno As System.Windows.Forms.Panel
	Friend WithEvents cmdMassimizza As System.Windows.Forms.Button
	Friend WithEvents BarraAvanzamentoInterna As System.Windows.Forms.TrackBar
	Friend WithEvents lblTesti As System.Windows.Forms.Label
	Friend WithEvents cmdEliminaTesti As System.Windows.Forms.Button
	Friend WithEvents lblTempoTotaleInterno As System.Windows.Forms.Label
	Friend WithEvents lblTempoPassatoInterno As System.Windows.Forms.Label
	Friend WithEvents tmrSpostaYouTube As System.Windows.Forms.Timer
	Friend WithEvents tmrChiudePannelloMP As System.Windows.Forms.Timer
	Friend WithEvents pnlTuttoSchermo As System.Windows.Forms.PictureBox
	Friend WithEvents tmrPrendeThumbs As System.Windows.Forms.Timer
	Friend WithEvents cmdStatistiche As System.Windows.Forms.Button
	Friend WithEvents pnlTestoInterno As System.Windows.Forms.Panel
	Friend WithEvents pnlMembriInterno As System.Windows.Forms.Panel
	Friend WithEvents AxWindowsMediaPlayer2 As AxWMPLib.AxWindowsMediaPlayer
	Friend WithEvents cmdRicaricaMembri As Button
	Friend WithEvents cmdCompattaMP3 As Button
	Friend WithEvents cmdSistemaImmagini As Button
End Class
