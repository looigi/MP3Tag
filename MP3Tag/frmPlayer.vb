Imports System.IO
Imports System.Threading
Imports System.Runtime.InteropServices
Imports System.Drawing.Imaging

Public Class frmPlayer
    <DllImportAttribute("user32.dll")>
    Public Shared Function SendMessage(hWnd As IntPtr, Msg As Integer, wParam As Integer, lParam As Integer) As Integer
    End Function

    <DllImportAttribute("user32.dll")> Public Shared Function ReleaseCapture() As Boolean
    End Function

    Private NotifyIcon1 As NotifyIcon = New NotifyIcon
    Private contextMenu1 As System.Windows.Forms.ContextMenu = New System.Windows.Forms.ContextMenu
    Private menuItem1 As GestioneMenu
    Private menuItem2 As GestioneMenu
    Private menuItem3 As GestioneMenu
    Private menuItem4 As GestioneMenu
    Private menuItem5 As GestioneMenu
    Private menuItem6 As GestioneMenu
    Private menuItemSeparator As GestioneMenu
    Private isHidden As Boolean

    Private ValoreScritto As Integer = 0
    'Private PathMP3 As String
    Private DeviceAudio As String
    'Private Canzoni() As String
    'Private qCanzoni As Integer
    Private gf As New GestioneFilesDirectory
    Private gi As New GestioneImmagini
    Private gt As New getLyricsMP3_NEW
    Private Ascoltate() As Integer
    Private qAscoltate As Integer
    Private maxAscoltate As Integer
    Private Secondi As Integer = 0
    Private Const SecondiPerImmagine As Integer = 10
    Private Const SecondiPerFarScomparireIlPannello As Integer = 3
    Private SecondiPassatiPerFarScomparireIlPannello As Integer
    Private piat As PrendeImmagineArtistaThread = Nothing
    Public WithEvents audioCorrente1 As WMPLib.WindowsMediaPlayer
    Private frmWiki As frmWikipedia

    Private Const DimeBarraTasti As Integer = 8
    Private Const DimeBarraCanzoni As Integer = 30
    Private Const DimePannelloImmagine As Integer = 60
    Private Const DimeXPannelloImmagine As Integer = 45
    Private Const DimePannelloTesto As Integer = 49
    Private Const MinimaX As Integer = 314
    Private Const MinimaY As Integer = 306
    Private dPicX As Integer
    Private dPicY As Integer
    Private DimeX As Integer = 0
    Private DimeY As Integer = 0
    Private BordoFinestra As Integer = 5
    Private Const FiltroRicerca As String = "*.mp3;*.wma"
    Private Const LarghezzaFormWikipedia As Integer = 600

    Private DimeXPrimaDiMinimizzare As Integer = -1
    Private DimeYPrimaDiMinimizzare As Integer = -1

    Private StaPartendo As Boolean
    Private SecondiSuonati As Single
    Private SecondiTot(2) As String
    Private tMinuti As Integer
    Private tSecondi As Integer
    'Private trd As Thread
    'Private sa As New SpectrumAnalyzerII.FormAudioSpectrum
    'Private pnlSSpectrum As Panel
    'Private trdTesti As Thread

    Private maxCaratteriTesto As Integer
    Private maxRigheTesto As Integer
    Private TestoInternoOrig As String
    Private TestoInternoTrad As String

    Private LinguaOriginale As Boolean
    Private PuoResizare As Boolean = False
    Private Massimizzato As Boolean = False

    Private StaUscendo As Boolean

    'Private HaFinitoDiLeggereITesti As Boolean
    'Private lblTestiThread As Label
    Private instance As Form

    'Private Delegate Sub DelegateAddTextTesti(ByVal str As String)
    'Private MethodDelegateAddTextTesti As New DelegateAddTextTesti(AddressOf AddTextTesti)

    Private VisualizzatoPannelloMP As Boolean
    Private SecondiChiusuraPannelloMP As Integer = 0

    'Dim tmrStringeMP As System.Timers.Timer = Nothing
    'Dim SecondiPassatiPerStringereMP As Integer = 0

    Private LettCanzoni As LetturaCanzoni

    Private NonDiminuire As Boolean = False
    Private ContaNonDiminuire As Integer

    Private tmrCreaFileVideoVuoto As System.Timers.Timer = Nothing
    Private NomeFileDaCancellare As String

    Private StaCambiandoAutomaticamente As Boolean

    Private tmrFadePanel As System.Timers.Timer = Nothing

    Private ValoreFadePannello As Single = 1
    Private Delegate Sub DelegateNascondePannelloStart()
    Private MethodDelegateNascondePannelloStart As New DelegateNascondePannelloStart(AddressOf NascondePannelloStart)

    Private Delegate Sub DelegateSpostaPannello()
    Private MethodDelegateSpostaPannello As New DelegateSpostaPannello(AddressOf SpostaPannello)
    Private pnlTS As PictureBox

    Private passoX As Integer
    Private passoY As Integer

    Private ScrittaTestiVisibile As Boolean
    Private DoppioClickSuCanzone As Boolean = False

    Private ModalitaSpostamentoTesto As Integer = 1
    Private testoX As Integer = 3
    Private testoY As Integer = 30

    Private VecchiaVisibilitaPicSost As Boolean = True
    Private bIndietro As Boolean

    Private stf As Boolean = True ' Stretch to fit

    Private _mousedownWMP As Boolean
    Private _mouseposWMP As Point

    Private _mousedownTI As Boolean
    Private _mouseposTI As Point

    Private vecchiaPosPicX As Integer
    Private vecchiaPosPicY As Integer
    Private vecchiaPosDimX As Integer
    Private vecchiaPosDimY As Integer
    Private staFermandoImmagine As Boolean = False

    Private Sub SpostaPannello()
        pnlTS.Image = ChangeOpacity(pnlTS.Image, ValoreFadePannello)
        pnlTS.SizeMode = PictureBoxSizeMode.CenterImage

        'If pnlTS.Width > 0 Then pnlTS.Width -= passoX
        'If pnlTS.Height > 0 Then pnlTS.Height -= passoY
        'pnlTS.Left += (passoX / 2)
        'pnlTS.Top += (passoY / 2)
    End Sub

    Public Sub New()
        MyBase.New()

        InitializeComponent()

        MetteIconeNellaTray()
    End Sub

    Private Sub frmPlayer_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        pnlTuttoSchermo.Left = 0
        pnlTuttoSchermo.Top = 0
        pnlTuttoSchermo.Width = Me.Width
        pnlTuttoSchermo.Height = Me.Height
        pnlTuttoSchermo.Visible = True
        pnlTuttoSchermo.BackColor = Color.FromArgb(255, 25, 25, 25)
        pnlTuttoSchermo.Image = My.Resources.pleaseWait ' Image.FromFile("Immagini/pleaseWait.jpg")
        Application.DoEvents()

        CaricaTuttoAllInizio(sender, e)
    End Sub

    Private Sub CaricaTuttoAllInizio(Sender As Object, e As EventArgs)
        StaPartendo = True

        'If AxWindowsMediaPlayer1 Is Nothing Then
        '    AxWindowsMediaPlayer1 = New AxWMPLib.AxWindowsMediaPlayer
        '    Me.Controls.Add(AxWindowsMediaPlayer1)
        'End If

        StrutturaDati = New StrutturaCampivb
        StrutturaDati.lblAggiornamentoCanzoni = lblAggiornamentoCanzoni
        StrutturaDati.chkRandom = chkRandom
        StrutturaDati.chkUltime = chkUltime
        StrutturaDati.chkPrime = chkPrime
        StrutturaDati.lblTesti = lblTesti
        StrutturaDati.chkBellezza = chkBellezza
        StrutturaDati.cmbBellezza = cmbBellezza
        StrutturaDati.chkSuperiori = chkSuperiori
        StrutturaDati.chkFiltroTesto = chkFiltroTesto
        StrutturaDati.txtFiltroTesto = txtFiltroTesto
        StrutturaDati.chkFiltroNome = chkFiltroNome
        StrutturaDati.chkRicercaSuTesto = chkRicercaSuTesto
        StrutturaDati.chkRicordaAscoltate = chkRicordaAscoltate
        StrutturaDati.lblTempoPassato = lblTempoPassato
        StrutturaDati.lblTempoTotale = lblTempoTotale
        StrutturaDati.lblTempoPassatoInterno = lblTempoPassatoInterno
        StrutturaDati.lblTempoTotaleInterno = lblTempoTotaleInterno
        StrutturaDati.lblNomeCanzone = lblNomeCanzone
        StrutturaDati.PicMP3 = picMP3
        StrutturaDati.BarraAvanzamento = BarraAvanzamento
        StrutturaDati.BarraAvanzamentoInterna = BarraAvanzamentoInterna
        StrutturaDati.FiltroRicerca = ""
        StrutturaDati.QualeCanzoneStaSuonando = 0
        StrutturaDati.lstArtista = lstArtista
        StrutturaDati.lstAlbum = lstAlbum
        StrutturaDati.lstCanzone = lstCanzone
		'StrutturaDati.PicNonCercareVideo = picNonCercareVideo
		StrutturaDati.VideoLockati = False
        StrutturaDati.pnlBarra = pnlBarra
        StrutturaDati.pnlImmagine = pnlImmagine
        StrutturaDati.pnlImmagineArtista = pnlImmagineArtista
		'StrutturaDati.pnlMediaPlayer = pnlMediaPlayer
		'StrutturaDati.AxWindowsMediaPlayer1 = AxWindowsMediaPlayer1
		StrutturaDati.PathMP3 = GetSetting("MP3Tag", "Impostazioni", "PercorsoDestinazione", "")

        LettCanzoni = New LetturaCanzoni(Me)

        Me.Text = ""
        Me.ShowInTaskbar = True

        lstTesto.BackColor = Me.BackColor
        lstTesto.ForeColor = Color.Yellow

        lstTraduzione.BackColor = Me.BackColor
        lstTraduzione.ForeColor = Color.Green

        cmdVisualizzaMembri.Visible = False
        cmdRicaricaMembri.Visible = False

        'lstTestoInterno.BackColor = Color.FromArgb(50, 0, 0, 0)
        'lstTestoInterno.ForeColor = Color.FromArgb(50, 255, 0, 0)
        pnlTestoInterno.BackColor = Color.FromArgb(40, Color.Blue)
        pnltestointerno.ForeColor = Color.Yellow
        pnltestointerno.Left = 3
        pnltestointerno.Top = 30
        'pnltestointerno.Width = 200

        pnlImmagineArtista.Left = 0
        pnlImmagineArtista.Top = 0
        pnlImmagine.Left = 1
        pnlImmagine.Top = 1
        pnlCanzoni.Left = 1
        pnlTasti.Left = 1
        lstTesto.Top = 1
        lstArtista.Left = 0
        lstArtista.Top = 0
        lstAlbum.Top = 0
        lstCanzone.Top = 0
        picIndietro.Top = 1
        picIndietro.Left = 2
        picSettings.Top = 1
        picAvanti.Top = 1
        picPlay.Top = 1
        pnlImpostazioni.Visible = False
        pnlImmagineArtista.Visible = False
        lblArtista.Top = 1
        lblArtista.Left = 0
        lblAlbum.Top = 1
        lblCanzone.Top = 1
        lblAlbum.Left = 0
        lblArtista.Height = 13
        lblAlbum.Height = 13
        lblCanzone.Height = 13
        pnlFinestra.Top = 2
        pnlBarra.Left = 0
        pnlBarra.Height = 30
        lblTempoPassato.Left = 1
        lblTempoPassato.Top = 3
        lblTempoTotale.Left = 1
        lblTempoTotale.Top = 3
        BarraAvanzamento.Top = 0
        'cmdSposta.Visible = False
        cmdMassimizza.Visible = False
        pnlSopra.Left = 0
        pnlSopra.Top = 0
        pnlSotto.Left = 0
        lblNomeArtistaImm.Left = -4
        lblNomeArtistaImm.Top = 14
        lblNomeArtistaImm.BackColor = Color.FromArgb(145, Color.DarkGreen)
        lblNomeArtistaImm.ForeColor = Color.FromArgb(145, Color.GreenYellow)
        pnlStelleInterno.Visible = False
		'picYouTube.Visible = True

		pnlMembriInterno.BackColor = Color.FromArgb(40, Color.Blue)
        pnlMembriInterno.ForeColor = Color.Yellow
        pnlMembriInterno.Left = 5
        pnlMembriInterno.Top = lblNomeArtistaImm.Top + lblNomeArtistaImm.Height + 1

        'QualeAudioStaSuonando = 1
        inPausa = False

        picAvanti.BackgroundImage = My.Resources.avanti ' Image.FromFile("Immagini/Avanti.png")
        picIndietro.BackgroundImage = My.Resources.indietro ' Image.FromFile("Immagini/indietro.png")
        picSettings.BackgroundImage = My.Resources.impostazioni ' Image.FromFile("Immagini/impostazioni.png")

        tmrSpostaScrittaTitolo.Enabled = False
        picPlay.BackgroundImage = My.Resources.icona_PLAY ' Image.FromFile(Application.StartupPath & "\Immagini\icona_Play.png")

		'picAvantiMP.BackgroundImage = My.Resources.avanti ' Image.FromFile(Application.StartupPath & "\Immagini\Icone\icona_AVANTI.png")
		'picIndietroMP.BackgroundImage = My.Resources.indietro ' Image.FromFile(Application.StartupPath & "\Immagini\Icone\icona_INDIETRO.png")
		'picMeno.BackgroundImage = My.Resources.meno ' Image.FromFile(Application.StartupPath & "\Immagini\meno.png")
		'picPiu.BackgroundImage = My.Resources.piu ' Image.FromFile(Application.StartupPath & "\Immagini\piu.png")
		'picElimina.BackgroundImage = My.Resources.icona_ELIMINA_TAG ' Image.FromFile(Application.StartupPath & "\Immagini\icona_ELIMINA-TAG.png")
		'picSalvaVideo.BackgroundImage = My.Resources.icona_SALVA ' Image.FromFile(Application.StartupPath & "\Immagini\icona_SALVA.png")
		'picApreChiudeBarraMP.BackgroundImage = My.Resources.SuGiu ' Image.FromFile(Application.StartupPath & "\Immagini\SuGiu.png")

		Dim tt As New ToolTip()

        tt.SetToolTip(cmdEliminaImmagineArtista, "Elimina immagine")
        tt.SetToolTip(cmdSalva, "Salva immagine")
        tt.SetToolTip(cmdTesto, "Visualizza/Nasconde il testo")
        tt.SetToolTip(cmdRefreshtestoInterno, "Aggiorna il testo")
        tt.SetToolTip(cmdTraduzione, "Visualizza lingua originale/tradotta")
        tt.SetToolTip(cmdApreCartella, "Apre la cartella di salvataggio delle immagini")
        tt.SetToolTip(cmdMassimizza, "Allarga la finestra a tutto schermo")
        tt.SetToolTip(cmdMinimizzaForm, "Nasconde la finestra")
        tt.SetToolTip(cmdChiudeForm, "Esce dall'applicazione")
        tt.SetToolTip(cmdVisualizzaMembri, "Visualizza i membri del gruppo")
        tt.SetToolTip(cmdRicaricaMembri, "Ricarica i membri del gruppo")

		'tt.SetToolTip(picAvantiMP, "Visualizza il video successivo")
		'tt.SetToolTip(picIndietroMP, "Visualizza il video precedente")
		'tt.SetToolTip(picMeno, "Rimpicciolisce la schermata video")
		'tt.SetToolTip(picPiu, "Ingrandisce la schermata video")
		'tt.SetToolTip(picElimina, "Elimina il video selezionato")
		'tt.SetToolTip(picSalvaVideo, "Salva il video selezionato")
		'tt.SetToolTip(picApreChiudeBarraMP, "Visualizza o meno la barra MP")
		'tt.SetToolTip(picNonCercareVideo, "Permette o meno la ricerca di nuovi video")

		frmWiki = New frmWikipedia
        frmWiki.Visible = False

        Me.Cursor = Cursors.WaitCursor

        chkRandom.Checked = GetSetting("MP3Tag", "Impostazioni", "PlayerRandom", True)
        chkPrime.Checked = GetSetting("MP3Tag", "Impostazioni", "PlayerPrimeCanzoni", False)
        chkScaricaLyric.Checked = GetSetting("MP3Tag", "Impostazioni", "PlayerTesti", True)
        chkVisuaImmArtista.Checked = GetSetting("MP3Tag", "Impostazioni", "PlayerVisuaImm", True)
        chkUltime.Checked = GetSetting("MP3Tag", "Impostazioni", "PlayerUltimeCanzoni", False)
        chkWikipedia.Checked = GetSetting("MP3Tag", "Impostazioni", "Wikipedia", True)
        chkPartePlayer.Checked = GetSetting("MP3Tag", "Impostazioni", "PlayerDiretto", False)
        chkSpectrum.Checked = GetSetting("MP3Tag", "Impostazioni", "Spectrum", True)
        chkSpostaImmagini.Checked = GetSetting("MP3Tag", "Impostazioni", "SpostaImmagini", True)
        chkPath.Checked = GetSetting("MP3Tag", "Impostazioni", "CreaPath", True)
        chkSuperiori.Checked = GetSetting("MP3Tag", "Impostazioni", "Superiori", 1)
		'chkYouTube.Checked = GetSetting("MP3Tag", "Impostazioni", "VisualizzaYouTube", False)
		chkRicordaAscoltate.Checked = GetSetting("MP3Tag", "Impostazioni", "RicordaAscoltate", True)
        pnltestointerno.Visible = GetSetting("MP3Tag", "Impostazioni", "TestoVisibile", False)
        pnlMembriInterno.Visible = GetSetting("MP3Tag", "Impostazioni", "Membri", False)
        LinguaOriginale = GetSetting("MP3Tag", "Impostazioni", "Lingua", True)
		'YouTubeMostrato = GetSetting("MP3Tag", "Impostazioni", "YouTube", False)
		'PosizioneMP = GetSetting("MP3Tag", "Impostazioni", "PosMediaPlayer", "")
		PosizioneTI = GetSetting("MP3Tag", "Impostazioni", "PosTestoInterno", "")
		'If YouTubeMostrato Then
		'    chkYouTube.Checked = True
		'    chkScaricaSubito.Visible = True
		'Else
		'    chkYouTube.Checked = False
		'    chkScaricaSubito.Visible = False
		'End If
		'ScaricaVideoSubito = GetSetting("MP3Tag", "Impostazioni", "ScaricaSubitoVideo", "S")
		'If ScaricaVideoSubito = "N" Then
		'    chkScaricaSubito.Checked = False
		'Else
		'    chkScaricaSubito.Checked = True
		'End If
		'DimeWMP = GetSetting("MP3Tag", "Impostazioni", "DimensioniYT", 3)

		'pnlMediaPlayer.Visible = chkYouTube.Checked
		'pnlContMP.Visible = pnlMediaPlayer.Visible

		ImpostaLingua()

        cmbBellezza.Items.Clear()
        cmbBellezza.Items.Add("Mai Votate")
        cmbBellezza.Items.Add("1")
        cmbBellezza.Items.Add("2")
        cmbBellezza.Items.Add("3")
        cmbBellezza.Items.Add("4")
        cmbBellezza.Items.Add("5")
        cmbBellezza.Items.Add("6")
        cmbBellezza.Items.Add("7")
        Dim v As String = GetSetting("MP3Tag", "Impostazioni", "Bellezza", -1)
        Dim ValoreBellezza As Integer = IIf(v = "Mai Votate", 0, v)
        If ValoreBellezza > -1 Then
            If ValoreBellezza = 0 Then
                cmdEstrai.Enabled = False
                chkSuperiori.Enabled = False
                chkSuperiori.Checked = False
            Else
                cmdEstrai.Enabled = True
                chkSuperiori.Enabled = True
            End If
            chkBellezza.Checked = True
            'cmbBellezza.Enabled = True
            cmbBellezza.Text = IIf(ValoreBellezza = 0, "Mai Votate", ValoreBellezza)
            cmdEstrai.Enabled = True
            chkPath.Enabled = True
            chkSuperiori.Enabled = True
        Else
            'chkBellezza.Checked = False
            'cmbBellezza.Enabled = False
            'cmbBellezza.Text = "3"
            cmdEstrai.Enabled = False
            chkPath.Enabled = False
            chkSuperiori.Checked = False
            chkSuperiori.Enabled = False
        End If

        Dim FiltroTesto As String = GetSetting("MP3Tag", "Impostazioni", "FiltroTesto", "")
        chkFiltroNome.Checked = GetSetting("MP3Tag", "Impostazioni", "FiltroSoloNome", False)
        chkRicercaSuTesto.Checked = GetSetting("MP3Tag", "Impostazioni", "RicercaSuTesto", False)
        If FiltroTesto = "" Then
            txtFiltroTesto.Text = ""
            txtFiltroTesto.Enabled = False
            chkFiltroTesto.Checked = False
            chkFiltroNome.Enabled = False
            chkRicercaSuTesto.Enabled = False
        Else
            txtFiltroTesto.Text = FiltroTesto
            txtFiltroTesto.Enabled = True
            chkFiltroTesto.Checked = True
            chkFiltroNome.Enabled = True
            chkRicercaSuTesto.Enabled = True
        End If

        If chkPartePlayer.Checked = True Then
            frmMain.Hide()
        End If

        If GetSetting("MP3Tag", "Impostazioni", "Sposta", False) = False Then
            Me.Text = ""
            BordoFinestra = 5
        Else
            BordoFinestra = 30
        End If

        If chkBellezza.Checked = False And chkFiltroTesto.Checked = False Then
            Dim Appoggio As String

            gf.ScansionaDirectorySingola(StrutturaDati.PathMP3, FiltroRicerca)
            StrutturaDati.Canzoni = gf.RitornaFilesRilevati
            StrutturaDati.qCanzoni = gf.RitornaQuantiFilesRilevati

            For i As Integer = 1 To StrutturaDati.qCanzoni
                For k As Integer = 1 To StrutturaDati.qCanzoni
                    If StrutturaDati.Canzoni(i) > StrutturaDati.Canzoni(k) Then
                        Appoggio = StrutturaDati.Canzoni(i)
                        StrutturaDati.Canzoni(i) = StrutturaDati.Canzoni(k)
                        StrutturaDati.Canzoni(k) = Appoggio
                    End If
                Next
            Next
        Else
            LettCanzoni.CaricaTutteLeCanzoni(True, , False)
        End If
        VisualizzaLista(lstArtista)

        Erase Ascoltate
        qAscoltate = 0
        maxAscoltate = -1

        lblTempoPassato.Text = ""
        lblTempoTotale.Text = ""

        lblTempoPassatoInterno.Text = ""
        lblTempoTotaleInterno.Text = ""

        lblNomeCanzone.Text = ""
        picMP3.Image = Nothing
        BarraAvanzamento.Enabled = False
        BarraAvanzamentoInterna.Enabled = False

        If chkUltime.Checked = True Then
            OrdinaPerPrime(False)
        Else
            If chkPrime.Checked = True Then
                OrdinaPerPrime(True)
            Else
                If StrutturaDati.qCanzoni > 0 Then
                    StrutturaDati.QualeCanzoneStaSuonando = GetSetting("MP3Tag", "Impostazioni", "CanzoneCheSuona", 1) '- 1
                    If StrutturaDati.QualeCanzoneStaSuonando < 0 Then
                        StrutturaDati.QualeCanzoneStaSuonando = 0
                    End If
                    CaricaCanzone()
                End If
            End If
        End If

        If GetSetting("MP3Tag", "Impostazioni", "Filtro", "***") <> "" Then
            lblFiltro.Text = GetSetting("MP3Tag", "Impostazioni", "Filtro", "***")
            Call cmdFiltro_Click(Sender, e)
        End If

        PuoResizare = False
        chkSpectrum.Checked = False

        Me.Cursor = Cursors.Default

        tmrVisualizzaImmArtista.Enabled = True

        LettCanzoni.LeggeCanzoniInBackground()

        tmrPartenza.Enabled = True

        instance = Me

		'Dim g As New GestioneImmagini
		'picYouTube.Image = My.Resources.youtube ' g.CaricaImmagineSenzaLockarla(Application.StartupPath & "\Immagini\youtube.png")
		'g = Nothing

		'If Not chkYouTube.Checked Then
		'          picYouTube.Visible = False
		'          YouTubeMostrato = False
		'          AxWindowsMediaPlayer1.Visible = False
		'      End If

		Dim gl As New getLyricsMP3_NEW
        gl.ScaricaTestiInBackground(instance)

        StaUscendo = False

		'AxWindowsMediaPlayer1.uiMode = "none"
		'AxWindowsMediaPlayer1.stretchToFit = stf
		'AxWindowsMediaPlayer1.settings.volume = 0

		'AccendeSpegnePannelloVideo()

		'YouTubeClass = New YouTube(instance, AxWindowsMediaPlayer1, chkYouTube, lblNomeVideo, picAvantiMP, picIndietroMP, picSalvaVideo, picApreChiudeBarraMP, picElimina)

		'MetteTogliePannelloYouTube()

		'PrendeVideo(AxWindowsMediaPlayer1, lstArtista.Text.Trim, lstAlbum.Text, lstCanzone.Text)

		pnlTS = pnlTuttoSchermo

        passoX = pnlTuttoSchermo.Width / (1 / 0.05)
        passoY = pnlTuttoSchermo.Height / (1 / 0.05)

		'If Not YouTubeMostrato Then
		'    pnlMediaPlayer.Visible = False
		'End If

		tmrFadePanel = New System.Timers.Timer(100)
        AddHandler tmrFadePanel.Elapsed, AddressOf SfumaPannello
        tmrFadePanel.Start()
    End Sub

    Private Function ChangeOpacity(ByVal img As Image, ByVal opacityvalue As Single) As Bitmap
        Dim bmp As New Bitmap(img.Width, img.Height)
        Dim graphics__1 As Graphics = Graphics.FromImage(bmp)
        Dim colormatrix As New ColorMatrix
        colormatrix.Matrix33 = opacityvalue
        Dim imgAttribute As New ImageAttributes

        imgAttribute.SetColorMatrix(colormatrix, ColorMatrixFlag.[Default], ColorAdjustType.Bitmap)
        graphics__1.DrawImage(img, New Rectangle(0, 0, bmp.Width, bmp.Height), 0, 0, img.Width, img.Height, _
         GraphicsUnit.Pixel, imgAttribute)
        graphics__1.Dispose()

        Return bmp
    End Function

    Private Sub NascondePannelloStart()
        pnlTS.Visible = False
    End Sub

    Private Sub SfumaPannello()
        ValoreFadePannello -= 0.05
        If ValoreFadePannello >= 0 Then
            If instance.InvokeRequired Then
                instance.Invoke(MethodDelegateSpostaPannello)
            End If
            Application.DoEvents()
        Else
            tmrFadePanel.Enabled = False
            tmrFadePanel = Nothing
            If instance.InvokeRequired Then
                instance.Invoke(MethodDelegateNascondePannelloStart)
            End If
        End If
    End Sub

    Private Sub MetteIconeNellaTray()
        'menuItem1 = New GestioneMenu("Verdana", 12, "Play", "Immagini\Icone\icona_play.png", 24, New EventHandler(AddressOf menuPlay), Nothing)
        'menuItem2 = New GestioneMenu("Verdana", 12, "Prossimo Brano", "Immagini\Icone\icona_Avanti.png", 24, New EventHandler(AddressOf ProssimoBrano), Nothing)
        'menuItem3 = New GestioneMenu("Verdana", 12, "Brano Precedente", "Immagini\Icone\icona_Indietro.png", 24, New EventHandler(AddressOf BranoPrecedente), Nothing)
        'menuItem4 = New GestioneMenu("Verdana", 12, "Nasconde Maschera", "Immagini\Icone\no_visualizzato_tondo.png", 24, New EventHandler(AddressOf NascondeMostra), Nothing)
        'menuItem5 = New GestioneMenu("Verdana", 12, "Resetta posizione", "Immagini\Icone\icona_refresh.png", 24, New EventHandler(AddressOf ResettaMaschera), Nothing)
        'menuItem6 = New GestioneMenu("Verdana", 12, "Uscita", "Immagini\Icone\icona_uscita.png", 24, New EventHandler(AddressOf Uscita), Nothing)

        menuItem1 = New GestioneMenu("Verdana", 12, "Play", My.Resources.icona_PLAY, 24, New EventHandler(AddressOf menuPlay), Nothing)
        menuItem2 = New GestioneMenu("Verdana", 12, "Prossimo Brano", My.Resources.avanti, 24, New EventHandler(AddressOf ProssimoBrano), Nothing)
        menuItem3 = New GestioneMenu("Verdana", 12, "Brano Precedente", My.Resources.indietro, 24, New EventHandler(AddressOf BranoPrecedente), Nothing)
        menuItem4 = New GestioneMenu("Verdana", 12, "Nasconde Maschera", My.Resources.visualizzato_tondo, 24, New EventHandler(AddressOf NascondeMostra), Nothing)
        menuItem5 = New GestioneMenu("Verdana", 12, "Resetta posizione", My.Resources.icona_REFRESH, 24, New EventHandler(AddressOf ResettaMaschera), Nothing)
        menuItem6 = New GestioneMenu("Verdana", 12, "Uscita", My.Resources.icona_USCITA, 24, New EventHandler(AddressOf Uscita), Nothing)
        menuItemSeparator = New GestioneMenu("Verdana", 12, "-", "", 0, Nothing, Nothing)

        contextMenu1.MenuItems.AddRange(New System.Windows.Forms.MenuItem() _
                            {menuItem1, menuItemSeparator, menuItem2, menuItem3, menuItem4, menuItem5, menuItemSeparator, menuItem6})

        NotifyIcon1.Icon = My.Resources.pause ' New Icon("Immagini\Icone\pause.ico")
        NotifyIcon1.Text = "MP3Tag"
        NotifyIcon1.ContextMenu = Me.contextMenu1
        NotifyIcon1.Visible = True

        isHidden = False
    End Sub

    Private Sub ResettaMaschera(Sender As Object, e As EventArgs) ' Handles menuItem1.Click
        If MsgBox("Si è sicuri di voler reimpostare i valori predefiniti per la maschera?", vbYesNo + vbInformation + vbDefaultButton2) = vbYes Then
            SaveSetting("MP3Tag", "Impostazioni", "PlayerDimeX", 650)
            SaveSetting("MP3Tag", "Impostazioni", "PlayerDimeY", 450)
            SaveSetting("MP3Tag", "Impostazioni", "PlayerPosX", 10)
            SaveSetting("MP3Tag", "Impostazioni", "PlayerPosY", 10)

            Me.Width = GetSetting("MP3Tag", "Impostazioni", "PlayerDimeX", 650)
            Me.Height = GetSetting("MP3Tag", "Impostazioni", "PlayerDimeY", 450)
            Me.Height += BordoFinestra
            Me.Left = GetSetting("MP3Tag", "Impostazioni", "PlayerPosX", 10)
            Me.Top = GetSetting("MP3Tag", "Impostazioni", "PlayerPosY", 10)

            PuoResizare = True
            ImpostaTastiInterni()
            ImpostaSchermata()

            If pnlTuttoSchermo.Visible = True Then
                pnlTuttoSchermo.Left = 0
                pnlTuttoSchermo.Top = 0
                pnlTuttoSchermo.Width = Me.Width
                pnlTuttoSchermo.Height = Me.Height
                'pnlTuttoSchermo.SizeMode = PictureBoxSizeMode.Zoom
                Application.DoEvents()
            End If
        End If
    End Sub

    Private Sub Uscita(Sender As Object, e As EventArgs) 'Handles menuItem2.Click
        SalvaPosizioneForm()

        StaUscendo = True
        If StaSuonando() = True Then
            SfumaInUscita()
        Else
            ChiudeTutto()
        End If
    End Sub

    Private Sub NascondeMostra(Sender As Object, e As EventArgs) 'Handles menuItem7.Click
        If menuItem4.LeggeTesto = "Nasconde Maschera" Then
            Me.Left = -1000
            Me.Top = -1000
            Me.Width = 0
            Me.Height = 0

            isHidden = True

            menuItem4.ImpostaTesto("Visualizza maschera")
            menuItem4.ImpostaImmagineDaImage(My.Resources.visualizzato_tondo, 24)
            ' menuItem4.ImpostaImmagine("Immagini\Icone\visualizzato_tondo.png", 24)
        Else
            Me.Width = GetSetting("MP3Tag", "Impostazioni", "PlayerDimeX", 650)
            Me.Height = GetSetting("MP3Tag", "Impostazioni", "PlayerDimeY", 450)
            Me.Left = GetSetting("MP3Tag", "Impostazioni", "PlayerPosX", 10)
            Me.Top = GetSetting("MP3Tag", "Impostazioni", "PlayerPosY", 10)

            If pnlTuttoSchermo.Visible = True Then
                pnlTuttoSchermo.Left = 0
                pnlTuttoSchermo.Top = 0
                pnlTuttoSchermo.Width = Me.Width
                pnlTuttoSchermo.Height = Me.Height
                'pnlTuttoSchermo.SizeMode = PictureBoxSizeMode.Zoom
                Application.DoEvents()
            End If

            isHidden = False

            menuItem4.ImpostaTesto("Nasconde Maschera")
            menuItem4.ImpostaImmagineDaImage(My.Resources.visualizzato_tondo, 24)
            'menuItem4.ImpostaImmagine("Immagini\Icone\no_visualizzato_tondo.png", 24)
        End If
    End Sub

    Private Sub menuPlay(Sender As Object, e As EventArgs) 'Handles 'menuItem8.Click
        Call cmdPlay_Click(Sender, e)
    End Sub

    Private Sub ProssimoBrano(Sender As Object, e As EventArgs) 'Handles 'menuItem4.Click
        Call cmdAvanti_Click(Sender, e)
    End Sub

    Private Sub BranoPrecedente(Sender As Object, e As EventArgs) 'Handles 'menuItem5.Click
        Call cmdIndietro_Click(Sender, e)
    End Sub

    Private Sub ApreCartellaSalvataggi(sender As Object, e As EventArgs) Handles cmdApreCartella.Click
        Process.Start("explorer.exe", Application.StartupPath & "\ImmaginiSalvate\")
    End Sub

    Private Sub VisualizzaLista(QualeLista As ListBox)
        'Me.Cursor = Cursors.WaitCursor

        Dim Appoggio As String
        Dim Ok As Boolean

        QualeLista.Items.Clear()
        For i As Integer = 1 To StrutturaDati.qCanzoni
            Appoggio = StrutturaDati.Canzoni(i).Replace(StrutturaDati.PathMP3 & "\", "")
            If Appoggio.IndexOf("\") > -1 Then
                Appoggio = Mid(Appoggio, 1, Appoggio.IndexOf("\"))
            End If
            Ok = True
            For k As Integer = 0 To QualeLista.Items.Count - 1
                If Appoggio = QualeLista.Items(k) Then
                    Ok = False
                    Exit For
                End If
            Next
            If Ok = True Then
                QualeLista.Items.Add(Appoggio)
            End If
        Next

        lstAlbum.Items.Clear()
        lstCanzone.Items.Clear()
    End Sub

    Private Sub AzzeraControlliBarra()
        'tmrCanzone.Enabled = False
        SecondiSuonati = 0

        BarraAvanzamento.Minimum = 0
        BarraAvanzamento.Maximum = 9999
        BarraAvanzamento.Value = 0

        BarraAvanzamentoInterna.Minimum = 0
        BarraAvanzamentoInterna.Maximum = 9999
        BarraAvanzamentoInterna.Value = 0

        lblTempoPassato.Text = "00:00"
        lblTempoTotale.Text = LettCanzoni.PrendeTempoTotaleCanzone()

        lblTempoPassatoInterno.Text = "00:00"
        lblTempoTotaleInterno.Text = lblTempoTotale.Text

        If lblTempoTotale.Text <> "" Then
            Dim Minuti As Integer = Val(Mid(lblTempoTotale.Text, 1, lblTempoTotale.Text.IndexOf(":")))
            Dim Secondi As Integer = Val(Mid(lblTempoTotale.Text, lblTempoTotale.Text.IndexOf(":") + 2, 2))
            Dim SecTot As Integer = (Minuti * 60) + Secondi
            BarraAvanzamento.Maximum = SecTot
            BarraAvanzamentoInterna.Maximum = SecTot
        End If
    End Sub

    Private Sub ScaricaTestoCanzone(sNomeSong As String, artista As String, album As String, canzone As String, Forza As Boolean)
        Dim NomeSong As String = sNomeSong

        lstTesto.Items.Clear()
        pnlTestoInterno.Controls.Clear()
        pnlMembriInterno.Controls.Clear()
        lstTraduzione.Items.Clear()
        pnlTestoInterno.Visible = False

        gt = New getLyricsMP3_NEW
        gt.RitornaTestoCanzone(artista, NomeSong, lstTesto, chkScaricaLyric.Checked, artista & "\" & album & "\" & canzone, Forza, pnlTestoInterno, Me.Height, lstTraduzione, pnlMembriInterno)

        pnlTestoInterno.Visible = GetSetting("MP3Tag", "Impostazioni", "TestoVisibile", False)
        pnlMembriInterno.Visible = GetSetting("MP3Tag", "Impostazioni", "Membri", False)

        tmrTesto.Enabled = True
    End Sub

    Private Sub FineLettura() Handles tmrTesto.Tick
        Dim maxLength As Integer = 0

        If gt.getFinitoThread Then
            tmrTesto.Enabled = False

            Dim TestoRitorno As String = gt.getTesto
            Dim TestoRitornoTradotto As String = gt.getTestoTradotto

            ' maxCaratteriTesto = 0
            maxRigheTesto = 0

            lstTesto.Items.Clear()
            pnlTestoInterno.Controls.Clear()
            lstTraduzione.Items.Clear()

            If TestoRitorno <> "" Then
                Dim r() As String = {}
                Dim qr As Integer = 0
                'Dim a1 As Integer
                Dim maxColonne As Integer = 60
                'Dim Testo As String

                'a1 = TestoRitorno.IndexOf("§")
                'While a1 > -1
                '    Testo = Mid(TestoRitorno, 1, a1)
                '    If Testo.Length <= maxColonne Then
                '        ReDim Preserve r(qr)
                '        r(qr) = Mid(TestoRitorno, 1, a1)
                '        qr += 1
                '    Else
                Dim c As Integer = 0
                'Dim inizio As Integer = 1
                'Dim fine As Integer
                'Dim Riga As String

                '        If Testo.Length > maxColonne Then
                'Dim ii As Integer = 1

                For i As Integer = 1 To TestoRitorno.Length
                    c += 1
                    If c >= maxColonne Then
                        While Mid(TestoRitorno, i, 1) <> " " And Mid(TestoRitorno, i, 1) <> "." And Mid(TestoRitorno, i, 1) <> "," And Mid(TestoRitorno, i, 1) <> "§"
                            i -= 1
                        End While
                        TestoRitorno = Mid(TestoRitorno, 1, i) & "§" & Mid(TestoRitorno, i + 1, TestoRitorno.Length)
                        c = 0
                    Else
                        If Mid(TestoRitorno, i, 1) = "§" Then
                            c = 0
                        End If
                    End If
                Next

                r = TestoRitorno.Split("§")

                Dim l As New Label
                l.Left = 7
                l.BackColor = Color.Transparent
                l.Top = 7
                l.Font = New Font("Arial", 8)
                l.AutoSize = True
                If l.Width > maxLength Then
                    maxLength = l.Width
                End If

                For i As Integer = 0 To r.Length - 1
                    lstTesto.Items.Add(r(i).Replace("%20", " "))
                    l.Text &= r(i).Replace("%20", " ") & vbCrLf
                    If r(i).Length > maxCaratteriTesto Then
                        maxCaratteriTesto = r(i).Length
                    End If
                    maxRigheTesto += 14
                Next
                pnlTestoInterno.Controls.Add(l)

                If r.Length - 1 < 5 And lstTesto.Items.Count > 2 Then
                    If pnlTestoInterno.Text.ToUpper.IndexOf("NESSUN TESTO") = -1 Then
                        Dim ll As New Label
                        ll.BackColor = Color.Transparent
                        ll.Left = 7
                        ll.Top = 7
                        ll.Font = New Font("Arial", 8)
                        ll.AutoSize = True
                        'll.Text = Mid(ll.Text, 1, ll.Text.Length - 4)
                        ll.Text += "Nessun testo rilevato"
                        If ll.Width > maxLength Then
                            maxLength = ll.Width
                        End If
                        pnlTestoInterno.Controls.Add(ll)

                        maxRigheTesto -= 14

                        'lstTesto.Items(3) = "Nessun testo rilevato"
                    End If
                    maxCaratteriTesto *= 2
                End If
            End If

            lstTesto.Items.Add("")
            lstTesto.Items.Add("")
            lstTesto.Items.Add("")

            If TestoRitornoTradotto <> "" Then
                Dim r() As String = TestoRitornoTradotto.Split("§")

                Try
                    For i As Integer = 0 To r.Length - 1
                        lstTraduzione.Items.Add(r(i).Replace("%20", " "))
                    Next

                    If r.Length - 1 < 5 And lstTraduzione.Items.Count > 2 Then
                        lstTraduzione.Items(3) = "Nessun testo rilevato"
                    End If
                Catch ex As Exception

                End Try
            End If

            TestoInternoOrig = TestoRitorno
            TestoInternoTrad = TestoRitornoTradotto

            pnlTestoInterno.Width = (maxLength * 2) + 20 ' maxCaratteriTesto * 8
            pnlTestoInterno.Height = (maxRigheTesto + 20) 
            'If pnlTestoInterno.Height > DimeX * 5 / 6 Then
            '    pnlTestoInterno.Height = DimeY * 5 / 6
            'End If

            gt = Nothing

            pnlTestoInterno.Visible = GetSetting("MP3Tag", "Impostazioni", "TestoVisibile", False)
            pnlMembriInterno.Visible = GetSetting("MP3Tag", "Impostazioni", "Membri", False)

            ScriveMembri()
        End If
    End Sub

    Private Sub CaricaCanzone(Optional Indietro As Boolean = False, Optional bCarica As Boolean = True, Optional SalvaNumero As Boolean = True)
        Indietro = bIndietro

        If StrutturaDati.QualeCanzoneStaSuonando < StrutturaDati.Canzoni.Length Then
            pnlModifiche.Visible = False

            If piat Is Nothing = False Then
                piat.EsceFuori()
            End If

            AzzeraControlliBarra()

            If StaSuonando() = True Then
                If bCarica = True Then
                    SfumaInUscita()
                End If
            End If

            If StrutturaDati.QualeCanzoneStaSuonando > StrutturaDati.Canzoni.Length - 1 Or StrutturaDati.QualeCanzoneStaSuonando = 0 Then
                StrutturaDati.QualeCanzoneStaSuonando = 1
            End If

            LettCanzoni.ImpostaListe()

            Dim artista As String = lstArtista.Text.Trim
            Dim album As String = lstAlbum.Text
            If Mid(album, 5, 1) <> "-" Then
                album = "0000-" & album
            End If
            Dim canzone As String = lstCanzone.Text
            If Mid(canzone, 3, 1) <> "-" Then
                canzone = "00-" & canzone
            End If

            Dim r As New RoutineVarie
            Dim Traccia As String = ""
            Dim sss As String = StrutturaDati.Canzoni(StrutturaDati.QualeCanzoneStaSuonando)
            Dim NomeSong As String = gf.TornaNomeFileDaPath(sss.Replace(gf.TornaEstensioneFileDaPath(sss), ""))
            Dim origNomeSong As String = NomeSong
            If NomeSong.IndexOf("-") > -1 Then
                Traccia = Mid(NomeSong, 1, NomeSong.IndexOf("-"))
                NomeSong = Mid(NomeSong, NomeSong.IndexOf("-") + 2, NomeSong.Length)
                If Traccia = "00" Or Traccia = "" Then Traccia = "" Else Traccia = "Traccia " & Traccia
            End If
            Dim sAlbum As String = album
            Dim sAnno As String = ""
            If sAlbum.IndexOf("-") > -1 Then
                sAnno = Mid(sAlbum, 1, sAlbum.IndexOf("-")) & " "
                sAlbum = Mid(sAlbum, sAlbum.IndexOf("-") + 2, sAlbum.Length)
                If sAnno = "0000 " Then sAnno = ""
            End If
            Try
                lblNomeCanzone.Text = artista & ": " & NomeSong & " (" & sAnno & sAlbum & ") " & " " & Traccia & vbCrLf & FileDateTime(StrutturaDati.Canzoni(StrutturaDati.QualeCanzoneStaSuonando)) & _
                    " Kb. " & r.FormattaNumero(FileLen(StrutturaDati.Canzoni(StrutturaDati.QualeCanzoneStaSuonando)), False)
            Catch ex As Exception

            End Try

            LettCanzoni.PrendeDatiCanzone(artista, album, canzone, StrutturaDati.Canzoni(StrutturaDati.QualeCanzoneStaSuonando))

            ScaricaTestoCanzone(NomeSong, artista, album, canzone, False)

            If SalvaNumero Then
                SaveSetting("MP3Tag", "Impostazioni", "CanzoneCheSuona", StrutturaDati.QualeCanzoneStaSuonando)
            End If

            Dim cart As String = StrutturaDati.PathMP3 & "\" & lstArtista.Text & "\" & album & "\Cover_" & artista & ".jpg"

            If File.Exists(cart) = True Then
                picMP3.Image = Image.FromFile(cart)
                DimeImmMP3 = gi.RitornaDimensioneImmagine(cart).Split("x")
            Else
                picMP3.Image = My.Resources.Sconosciuto ' Image.FromFile("Immagini/Sconosciuto.jpg")
                Dim d As SizeF = My.Resources.Sconosciuto.PhysicalDimension
                Dim s As String = d.Width.ToString & "x" & d.Height.ToString ' gi.RitornaDimensioneImmagine("Immagini\icona_CLOUD_512x512.png")
                DimeImmMP3 = s.Split("x") ' gi.RitornaDimensioneImmagine("Immagini/Sconosciuto.jpg").Split("x")
            End If

            Dim Ritorno() As String = {}

            If DimeImmMP3 Is Nothing = False Then
                Ritorno = gi.CentraImmagineNelPannello(pnlImmagine.Width, pnlImmagine.Height - BarraAvanzamento.Height - 2, DimeImmMP3(0), DimeImmMP3(1)).Split("x")
                dPicX = Ritorno(0)
                dPicY = Ritorno(1)
            End If

            picMP3.Width = dPicX
            picMP3.Height = dPicY - 20
            picMP3.Top = ((pnlImmagine.Height / 2) - (picMP3.Height / 2)) - 5
            picMP3.Left = (pnlImmagine.Width / 2) - (picMP3.Width / 2)

			'If Not pnlImmagineArtista.Visible Then
			'    AxWindowsMediaPlayer1.Left = picMP3.Left
			'    AxWindowsMediaPlayer1.Top = picMP3.Top
			'    AxWindowsMediaPlayer1.Width = picMP3.Width + 5
			'    AxWindowsMediaPlayer1.Height = picMP3.Height + 5
			'Else
			'    AxWindowsMediaPlayer1.Width = pnlImmagineArtista.Width / DimeWMP
			'    AxWindowsMediaPlayer1.Height = pnlImmagineArtista.Height / DimeWMP

			'    AxWindowsMediaPlayer1.Left = (pnlImmagineArtista.Width / 2) - (AxWindowsMediaPlayer1.Width / 2)
			'    AxWindowsMediaPlayer1.Top = (pnlImmagineArtista.Height / 2) - (AxWindowsMediaPlayer1.Height / 2) ' pnlImmagineArtista.Height - AxWindowsMediaPlayer1.Height - 30
			'End If

			'picSostituzioneMP.Left = AxWindowsMediaPlayer1.Left
			'picSostituzioneMP.Top = AxWindowsMediaPlayer1.Top
			'picSostituzioneMP.Width = AxWindowsMediaPlayer1.Width
			'picSostituzioneMP.Height = AxWindowsMediaPlayer1.Height

			'AccendeSpegnePannelloVideo()

			If Indietro = False Then
                qAscoltate += 1
                If qAscoltate > maxAscoltate Then
                    ReDim Preserve Ascoltate(qAscoltate)
                    maxAscoltate = qAscoltate
                End If
                Ascoltate(qAscoltate) = StrutturaDati.QualeCanzoneStaSuonando
            End If

            'Try
            'If pnlImmagineArtista.Visible Then
            'picImmagineArtista.Image = Nothing
            'picImmagineArtista.BackColor = Color.Empty
            'picImmagineArtista.Invalidate()
            'picImmagineArtista.Refresh()
            'Application.DoEvents()
            'End If
            'Catch ex As Exception

            'End Try

            If piat Is Nothing = False Then
                piat = Nothing
            End If

            If tmrCambioImmagine.Enabled = True Then
                piat = New PrendeImmagineArtistaThread
                piat.ImpostaCampi(tmrCambioImmagine, picImmagineArtista, lstArtista, lblNomeImmArtista, pnlImmagineArtista,
                                  cmdEliminaImmagineArtista, pnlTasti, tmrSpostaScrittaTitolo, tmrEffettoImmagine, pnlSopra, pnlSotto,
                                  lstCanzone, pnlSpectrum2, cmdSalva, cmdTesto, cmdRefreshtestoInterno, pnlStelleInterno, cmdTraduzione,
                                  cmdApreCartella, lblNomeArtistaImm, lblFiltroImpostato)
                piat.PrendeImmagineArtista(lstArtista.Text)
            End If

            If chkWikipedia.Checked = True Then
                frmWiki.ImpostaArtista(lstArtista.Text)
            End If

            Dim QuanteStelle As Integer = LettCanzoni.RitornaQuanteStelleCanzone()
            Dim Ascoltata As Integer = LettCanzoni.RitornaAscoltata()

            lblNomeCanzone.Text += " - Ascoltata: " & Ascoltata & " " & IIf(Ascoltata = 1, "Volta", "Volte")

            PrendeInformazioniMP3(Ascoltata, QuanteStelle)

            CaricaStelle(QuanteStelle)

            PulisceAlbumART()

            CambiaImmagine()

            r = Nothing
        End If
    End Sub

    Private Sub PulisceAlbumART()
        Dim Album As String = lstAlbum.Text

        If Directory.Exists(StrutturaDati.PathMP3 & "\" & lstArtista.Text & "\" & Album) = True Then
        Else
            If Mid(Album, 5, 1) <> "-" Then
                Album = "0000-" & Album
            End If
        End If

        Dim NomeCanzone As String = lstArtista.Text & "\" & Album ' & "\" & Canzone
        NomeCanzone = NomeCanzone.Replace("''", "'")

        Dim Files() As String = {}
        Dim Este As String

        Try
            Files = Directory.GetFiles(StrutturaDati.PathMP3 & "\" & NomeCanzone)
        Catch ex As Exception

        End Try
        If Files.Length > 0 Then
            For k As Integer = 0 To Files.Length - 1
                If Files(k).IndexOf("Cover_") = -1 Then
                    Este = gf.TornaEstensioneFileDaPath(Files(k)).ToUpper.Trim
                    If Este = ".JPG" Or Este = ".JPEG" Then
                        File.SetAttributes(Files(k), FileAttributes.Normal)
                        Try
                            Kill(Files(k))
                        Catch ex As Exception
                            'Stop
                        End Try
                    End If
                End If
            Next
        End If
    End Sub

    Private Sub PrendeInformazioniMP3(Ascoltata As Integer, Bellezza As Integer)
        Erase ValoriDaScrivere

        qValoriDaScrivere = 0
        ReDim Preserve ValoriDaScrivere(qValoriDaScrivere)
        ValoriDaScrivere(qValoriDaScrivere) = "Artista: " & lstArtista.Text

        Dim Album As String = lstAlbum.Text
        If Mid(Album, 5, 1) = "-" Then
            qValoriDaScrivere += 1
            ReDim Preserve ValoriDaScrivere(qValoriDaScrivere)
            ValoriDaScrivere(qValoriDaScrivere) = "Anno: " & Mid(Album, 1, Album.IndexOf("-"))

            Album = Mid(Album, 6, Album.Length)
        End If
        qValoriDaScrivere += 1
        ReDim Preserve ValoriDaScrivere(qValoriDaScrivere)
        ValoriDaScrivere(qValoriDaScrivere) = "Album: " & Album

        Dim Canzone As String = lstCanzone.Text
        If Canzone <> "" Then
            If Canzone.IndexOf("-") > -1 Then
                qValoriDaScrivere += 1
                ReDim Preserve ValoriDaScrivere(qValoriDaScrivere)
                ValoriDaScrivere(qValoriDaScrivere) = "Traccia: " & Mid(Canzone, 1, Canzone.IndexOf("-"))

                Canzone = Mid(Canzone, Canzone.IndexOf("-") + 2, Canzone.Length)
            End If
            qValoriDaScrivere += 1
            ReDim Preserve ValoriDaScrivere(qValoriDaScrivere)
            ValoriDaScrivere(qValoriDaScrivere) = "Titolo: " & Canzone.Replace(gf.TornaEstensioneFileDaPath(Canzone), "")

            qValoriDaScrivere += 1
            ReDim Preserve ValoriDaScrivere(qValoriDaScrivere)
            ValoriDaScrivere(qValoriDaScrivere) = "Ascoltata: " & Ascoltata & " " & IIf(Ascoltata = 1, "Volta", "Volte")

            qValoriDaScrivere += 1
            ReDim Preserve ValoriDaScrivere(qValoriDaScrivere)
            If Bellezza = 0 Then
                ValoriDaScrivere(qValoriDaScrivere) = "Bellezza: Mai votato"
            Else
                ValoriDaScrivere(qValoriDaScrivere) = "Bellezza: " & Bellezza
            End If
        End If

        ValoreScritto = 0

        Dim Tags As TagLib.File
        Dim m As New MP3Tag

        Tags = m.TornaTagDaMP3(Canzone)
        If Tags Is Nothing = False Then
            ControllaTagELoAggiunge(Tags.Tag.BeatsPerMinute, "Battute al minuto: ")
            ControllaTagELoAggiunge(Tags.Tag.Comment, "Commenti: ")
            ControllaTagELoAggiunge(Tags.Tag.Copyright, "Copyright: ")
            ControllaTagELoAggiunge(Tags.Tag.FirstGenre, "Genere: ")
            ControllaTagELoAggiunge(Tags.Tag.FirstPerformer, "Performer: ")
        End If
        m = Nothing
        Tags = Nothing

        ScriveValori()
    End Sub

    Private Sub ControllaTagELoAggiunge(Cosa As String, Desc As String)
        If Cosa.Trim <> "" Then
            qValoriDaScrivere += 1
            ReDim Preserve ValoriDaScrivere(qValoriDaScrivere)
            ValoriDaScrivere(qValoriDaScrivere) = Desc & Cosa
        End If
    End Sub

    Private Sub PrendeImmagineMP3(NomeCanzone As String)
        Dim m As New MP3Tag
        Dim i As Image = m.MostraImmagineMP3(NomeCanzone)
        picMP3.Image = i
        i = Nothing
        m = Nothing
    End Sub

    Private Sub CaricaStelle(QuanteStelle As Integer)
        Dim p(7) As PictureBox
        p(1) = picStelle1
        p(2) = picStelle2
        p(3) = picStelle3
        p(4) = picStelle4
        p(5) = picStelle5
        p(6) = picStelle6
        p(7) = picStelle7

        Dim pi(7) As PictureBox
        pi(1) = picStelle1Interno
        pi(2) = picStelle2Interno
        pi(3) = picStelle3Interno
        pi(4) = picStelle4Interno
        pi(5) = picStelle5Interno
        pi(6) = picStelle6Interno
        pi(7) = picStelle7Interno

        For i As Integer = 1 To QuanteStelle ' - 1
            p(i).Image = My.Resources.preferito ' gi.CaricaImmagineSenzaLockarla("Immagini/preferito.png")
            pi(i).Image = My.Resources.preferito ' gi.CaricaImmagineSenzaLockarla("Immagini/preferito.png")
        Next
        For i As Integer = QuanteStelle + 1 To 7
            p(i).Image = My.Resources.preferito_vuoto ' gi.CaricaImmagineSenzaLockarla("Immagini/preferito_vuoto.png")
            pi(i).Image = My.Resources.preferito_vuoto ' gi.CaricaImmagineSenzaLockarla("Immagini/preferito_vuoto.png")
        Next
    End Sub

    Private Sub ImpostaListaTesto(lst As ListBox)
        lst.Top = 3
        lst.Left = pnlImmagine.Left + pnlImmagine.Width + 10
        lst.Width = CInt(DimeX * DimePannelloTesto / 100)

        If chkSpectrum.Checked = True Then
            lst.Height = pnlImmagine.Height * 3 / 4
        Else
            lst.Height = pnlImmagine.Height
        End If

        picLingua.Left = lst.Left + lst.Width - picLingua.Width - 20
        picLingua.Top = lst.Top
    End Sub

    Private Sub ImpostaSchermata()
        If PuoResizare = False Then
            Exit Sub
        End If

        If DimeXPrimaDiMinimizzare > -1 Or DimeYPrimaDiMinimizzare > -1 Then
            Me.Width = DimeXPrimaDiMinimizzare
            Me.Height = DimeYPrimaDiMinimizzare

            DimeXPrimaDiMinimizzare = -1
            DimeYPrimaDiMinimizzare = -1
        End If

        DimeX = Me.Width
        DimeY = Me.Height - BordoFinestra

        If Not pnlImmagineArtista.Visible Then
            pnlImmagine.Width = DimeX * DimeXPannelloImmagine / 100
            pnlImmagine.Height = DimeY * DimePannelloImmagine / 100

            Dim Ritorno() As String = {}

            If DimeImmMP3 Is Nothing = False Then
                Ritorno = gi.CentraImmagineNelPannello(pnlImmagine.Width, pnlImmagine.Height - BarraAvanzamento.Height - 2, DimeImmMP3(0), DimeImmMP3(1)).Split("x")
                dPicX = Ritorno(0)
                dPicY = Ritorno(1)
            End If

            pnlBarra.Width = pnlImmagine.Width
            picMP3.Width = dPicX
            picMP3.Height = dPicY - 20
            picMP3.Top = ((pnlImmagine.Height / 2) - (picMP3.Height / 2)) - 5
            picMP3.Left = (pnlImmagine.Width / 2) - (picMP3.Width / 2)
            pnlBarra.Top = pnlImmagine.Height - 37
            pnlBarra.Height = 20

            lblTempoPassato.Width = pnlBarra.Width * 20 / 100
            BarraAvanzamento.Left = lblTempoPassato.Width + 1
            BarraAvanzamento.Width = pnlBarra.Width * 59 / 100
            lblTempoTotale.Width = pnlBarra.Width * 20 / 100
            lblTempoTotale.Left = BarraAvanzamento.Left + BarraAvanzamento.Width + 1

            If LinguaOriginale Then
                ImpostaListaTesto(lstTesto)
            Else
                ImpostaListaTesto(lstTraduzione)
            End If

            If chkSpectrum.Checked = True Then
                If LinguaOriginale Then
                    pnlCanzoni.Top = lstTesto.Top + lstTesto.Height + pnlSpectrum2.Height
                Else
                    pnlCanzoni.Top = lstTraduzione.Top + lstTraduzione.Height + pnlSpectrum2.Height
                End If
            Else
                If LinguaOriginale Then
                    pnlCanzoni.Top = lstTesto.Top + lstTesto.Height
                Else
                    pnlCanzoni.Top = lstTraduzione.Top + lstTraduzione.Height
                End If
            End If
            pnlCanzoni.Width = DimeX - 2
            pnlCanzoni.Height = Int(DimeY * DimeBarraCanzoni / 100)

            ' Oggetti all'interno del pannello Canzoni
            lstArtista.Width = DimeX * 32 / 100
            lstArtista.Height = pnlCanzoni.Height - lblArtista.Height - 3
            lstArtista.Top = lblArtista.Height + 1 ' ((pnlCanzoni.Height / 2) - (lstArtista.Height / 2)) + lblArtista.Height + 1

            lblArtista.Width = lstArtista.Width

            lstAlbum.Left = lstArtista.Left + lstArtista.Width + 1
            lstAlbum.Width = lstArtista.Width
            lstAlbum.Height = lstArtista.Height
            lstAlbum.Top = lstArtista.Top

            lblAlbum.Left = lstAlbum.Left
            lblAlbum.Width = lstAlbum.Width

            lstCanzone.Left = lstAlbum.Left + lstAlbum.Width + 1
            lstCanzone.Width = lstArtista.Width
            lstCanzone.Height = lstArtista.Height
            lstCanzone.Top = lstArtista.Top

            lblCanzone.Left = lstCanzone.Left
            lblCanzone.Width = lstCanzone.Width

            If DimeImmArtista Is Nothing = False Then
                Ritorno = gi.CentraImmagineNelPannello(pnlImmagineArtista.Width, pnlImmagineArtista.Height, DimeImmArtista(0), DimeImmArtista(1)).Split("x")
                dPicX = Ritorno(0)
                dPicY = Ritorno(1) + 20
            End If

            pnlStelle.Top = 2
            pnlStelle.Left = pnlImmagine.Width - 2 - pnlStelle.Width

			'If Not chkYouTube.Checked Then
			'    picYouTube.Visible = False
			'    AxWindowsMediaPlayer1.Visible = False
			'Else
			'    picYouTube.Left = 20
			'    picYouTube.Top = lblNomeArtistaImm.Top + 2
			'    picYouTube.Height = pnlStelle.Height

			'    'If AxWindowsMediaPlayer1.Visible = True Then
			'    '    AxWindowsMediaPlayer1.Left = picMP3.Left
			'    '    AxWindowsMediaPlayer1.Top = picMP3.Top + 37
			'    '    AxWindowsMediaPlayer1.Width = picMP3.Width + 5
			'    '    AxWindowsMediaPlayer1.Height = picMP3.Height - 35
			'    'End If
			'End If

		Else
            pnlStelleInterno.Top = lblNomeArtistaImm.Top + lblNomeArtistaImm.Height + 1
            pnlStelleInterno.Left = (Me.Width / 2) - (pnlStelleInterno.Width / 2)

			'If Not chkYouTube.Checked Then
			'    picYouTube.Visible = False
			'    AxWindowsMediaPlayer1.Visible = False
			'Else
			'    picYouTube.Left = 10
			'    picYouTube.Top = pnlStelleInterno.Top
			'    picYouTube.Height = pnlStelleInterno.Height

			'    'If AxWindowsMediaPlayer1.Visible = True Then
			'    'AxWindowsMediaPlayer1.Width = pnlImmagineArtista.Width / DimeWMP
			'    'AxWindowsMediaPlayer1.Height = (pnlImmagineArtista.Height / DimeWMP) - 30

			'    'AxWindowsMediaPlayer1.Left = (pnlImmagineArtista.Width / 2) - (AxWindowsMediaPlayer1.Width / 2)
			'    'AxWindowsMediaPlayer1.Top = (pnlImmagineArtista.Height / 2) - (AxWindowsMediaPlayer1.Height / 2) ' pnlImmagineArtista.Height - AxWindowsMediaPlayer1.Height - 30

			'    'If AxWindowsMediaPlayer1.Width > pnlImmagineArtista.Width - 40 Or AxWindowsMediaPlayer1.Height > pnlImmagineArtista.Height - 40 Then
			'    '    AxWindowsMediaPlayer1.Left = 10
			'    '    AxWindowsMediaPlayer1.Width = pnlImmagineArtista.Width - 30
			'    '    AxWindowsMediaPlayer1.Height = pnlImmagineArtista.Height - 40
			'    '    AxWindowsMediaPlayer1.Top = 20
			'    'End If
			'    'End If
			'End If

			If PosizioneTI = "" Then
                pnltestointerno.Left = ((pnlImmagineArtista.Width / 2) - (pnltestointerno.Width / 2))
                pnltestointerno.Top = ((pnlImmagineArtista.Height / 2) - (pnltestointerno.Height / 2))

                PosizioneTI = pnltestointerno.Top.ToString & ";" & pnltestointerno.Left & ";"
                SaveSetting("MP3Tag", "Impostazioni", "PosTestoInterno", PosizioneTI)
            Else
                Dim p() As String = PosizioneTI.Split(";")

                pnltestointerno.Left = p(1) '  ((pnlImmagineArtista.Width / 2) - (AxWindowsMediaPlayer1.Width / 2))
                pnltestointerno.Top = p(0) ' ((pnlImmagineArtista.Height / 2) - (AxWindowsMediaPlayer1.Height / 2))
            End If
        End If

		'AccendeSpegnePannelloVideo()

		'picSostituzioneMP.Left = AxWindowsMediaPlayer1.Left
		'picSostituzioneMP.Top = AxWindowsMediaPlayer1.Top
		'picSostituzioneMP.Width = AxWindowsMediaPlayer1.Width
		'picSostituzioneMP.Height = AxWindowsMediaPlayer1.Height

		'picNonCercareVideo.Left = AxWindowsMediaPlayer1.Left + 2
		'picNonCercareVideo.Top = (AxWindowsMediaPlayer1.Top + AxWindowsMediaPlayer1.Height) - picNonCercareVideo.Height - 2

		'MetteTogliePannelloYouTube()

		If StaVisualizzandoImmagineArtista = True Then
            pnlSpectrum2.Top = pnlTasti.Top
            pnlSpectrum2.Left = 0
            pnlSpectrum2.Width = Me.Width - 10
            pnlSpectrum2.Height = (Me.Height - pnlTasti.Top) - 16
        Else
            If LinguaOriginale Then
                pnlSpectrum2.Left = lstTesto.Left
                pnlSpectrum2.Width = lstTesto.Width
                pnlSpectrum2.Height = pnlImmagine.Height * 1 / 4
                pnlSpectrum2.Top = lstTesto.Top + lstTesto.Height
            Else
                pnlSpectrum2.Left = lstTraduzione.Left
                pnlSpectrum2.Width = lstTraduzione.Width
                pnlSpectrum2.Height = pnlImmagine.Height * 1 / 4
                pnlSpectrum2.Top = lstTraduzione.Top + lstTraduzione.Height
            End If
        End If

        pnlTasti.Top = Me.Height - 85 'pnlCanzoni.Top + pnlCanzoni.Height ' + 7
        pnlTasti.Height = 100 ' Me.Height - pnlTasti.Top ' DimeY - (pnlImmagine.Height + pnlCanzoni.Height) + DimeBarraTasti  ' + 40
        pnlTasti.Width = DimeX - 2

        ' Tasti all'interno del pannello Tasti
        picIndietro.Height = pnlTasti.Height - 35
        picIndietro.Width = picIndietro.Height
        'If picIndietro.Height > 55 Or picIndietro.Width > 55 Then picIndietro.Height = 55 : picIndietro.Width = 55
        'If picIndietro.Height > DimeY - (pnlImmagine.Height + pnlCanzoni.Height) - 10 Then
        '    picIndietro.Height = DimeY - (pnlImmagine.Height + pnlCanzoni.Height) - 10
        '    picIndietro.Width = DimeY - (pnlImmagine.Height + pnlCanzoni.Height) - 10
        'End If
        picIndietro.Top = 1 ' ((pnlTasti.Height / 2) - (picIndietro.Height / 2)) - 5

        picPlay.Left = picIndietro.Left + picIndietro.Width + 5
        picPlay.Height = picIndietro.Height
        picPlay.Width = picIndietro.Width
        picPlay.Top = picIndietro.Top

        picSettings.Height = picIndietro.Height
        picSettings.Width = picIndietro.Width
        picSettings.Top = picIndietro.Top
        picSettings.Left = picPlay.Left + picPlay.Width + 5

        picAvanti.Height = picIndietro.Height
        picAvanti.Width = picIndietro.Width
        picAvanti.Top = picIndietro.Top
        picAvanti.Left = DimeX - picAvanti.Width - 20

        ' Anche se non si vede setto il pannello delle impostazioni
        If pnlImpostazioni.Visible Then
            pnlImpostazioni.Top = -1
            pnlImpostazioni.Left = -1
            pnlImpostazioni.Width = Me.Width - 1 '(BordoFinestra + 20)
            pnlImpostazioni.Height = Me.Height - 1 ' (BordoFinestra + 20)
        End If

        ' e quello delle immagini
        pnlImmagineArtista.Width = DimeX
        pnlImmagineArtista.Height = DimeY + 20

        pnlSopra.Width = picImmagineArtista.Width
        pnlSopra.Height = pnlImmagineArtista.Height / 2
        pnlSopra.Left = picImmagineArtista.Left

        pnlSotto.Top = pnlImmagineArtista.Height / 2
        pnlSotto.Width = picImmagineArtista.Width
        pnlSotto.Height = pnlImmagineArtista.Height / 2
        pnlSotto.Left = picImmagineArtista.Left

        picImmagineArtista.Width = dPicX
        picImmagineArtista.Height = dPicY
        'pnlImmagineArtista.Height = pnlTasti.Top
        picImmagineArtista.Top = (pnlImmagineArtista.Height / 2) - (picImmagineArtista.Height / 2)
        picImmagineArtista.Left = (pnlImmagineArtista.Width / 2) - (picImmagineArtista.Width / 2)

        lblNomeCanzone.Left = picSettings.Left + picSettings.Width + 5
        lblNomeCanzone.Width = (picAvanti.Left - lblNomeCanzone.Left) - 10
        'lblNomeCanzone.Height = picIndietro.Height
        lblNomeCanzone.Top = 1

        'lblNomeArtistaImm.Left = 5 '  cmdEliminaImmagineArtista.Left + cmdEliminaImmagineArtista.Width + 5
        'lblNomeArtistaImm.Top = 5
        lblNomeArtistaImm.Width = Me.Width + 8

        pnlFinestra.Width = 10
        pnlFinestra.Height = 10
        pnlFinestra.Left = (DimeX - pnlFinestra.Width) - 20

        If frmWiki Is Nothing = False Then
            If frmWiki.Visible = False Then
                If chkWikipedia.Checked = True Then
                    frmWiki.Left = Me.Left + Me.Width + 10
                    frmWiki.Top = Me.Top
                    frmWiki.Height = Me.Height
                    frmWiki.Width = LarghezzaFormWikipedia
                    frmWiki.Show()
                    frmWiki.Visible = True
                End If
            End If
        End If

        lblAggiornamentoCanzoni.Left = 2 ' (Me.Width / 2) - (lblAggiornamentoCanzoni.Width / 2)
        lblAggiornamentoCanzoni.Top = 2 ' (Me.Height / 2) - (lblAggiornamentoCanzoni.Height / 2)

        If DimeImmArtista Is Nothing = False Then
            PassoEffettoX = pnlImmagineArtista.Width / 257
            PassoEffettoY = pnlImmagineArtista.Height / 247
        End If

        If lblFiltroImpostato.Text.Trim <> "***" Then
            If pnlImmagineArtista.Visible Then
                lblFiltroImpostato.Width = pnlStelleInterno.Width * 2
                lblFiltroImpostato.Left = (pnlImmagineArtista.Width / 2) - (lblFiltroImpostato.Width / 2) ' (Me.Width / 2) - (lblFiltroImpostato.Width / 2) ' BarraAvanzamento.Left ' (Me.Width / 2) - (lblFiltroImpostato.Width / 2)
                lblFiltroImpostato.Top = pnlStelleInterno.Top + pnlStelleInterno.Height + 5 ' Me.Height - lblFiltroImpostato.Height - 3
            Else
                lblFiltroImpostato.Left = picMP3.Left + 2 ' BarraAvanzamento.Left ' (Me.Width / 2) - (lblFiltroImpostato.Width / 2)
                lblFiltroImpostato.Width = picMP3.Width - 4
                lblFiltroImpostato.Top = picMP3.Top + picMP3.Height - lblFiltroImpostato.Height - 2 ' pnlBarra.Top - lblFiltroImpostato.Height - 3
            End If
            'Dim t As Integer = (lblFiltroImpostato.Width / (lblFiltroImpostato.Text.Length - 2)) ' * 3
            'Dim f As New Font("Arial", t)
            'lblFiltroImpostato.Font = f
        Else
            lblFiltroImpostato.Top = -100
            lblFiltroImpostato.Visible = False
        End If

        lblTesti.Left = lstTesto.Left + 2
        lblTesti.Width = lstTesto.Width - 30
        lblTesti.Top = (lstTesto.Top + lstTesto.Height) - lblTesti.Height - 2

        If pnlImmagineArtista.Visible Then
            ImpostaTastiInterni()

            'pnltestointerno.Width = maxCaratteriTesto * 5
            'pnltestointerno.Height = (maxRigheTesto + 1) * 12
            'If pnltestointerno.Height > Me.Height * 5 / 6 Then
            '    pnltestointerno.Height = Me.Height * 5 / 6
            'End If

            If BarraAvanzamentoInterna.Visible = False Then
                BarraAvanzamentoInterna.Visible = True
                lblTempoPassatoInterno.Visible = True
                lblTempoTotaleInterno.Visible = True
            End If

            lblTempoPassatoInterno.Left = picSettings.Left + picSettings.Width + 10
            lblTempoPassatoInterno.Top = (picSettings.Top + picSettings.Height) - lblTempoPassatoInterno.Height '- 10

            lblTempoTotaleInterno.Left = picAvanti.Left - lblTempoTotaleInterno.Width - 10
            lblTempoTotaleInterno.Top = lblTempoPassatoInterno.Top

            Dim diff As Integer = lblTempoTotaleInterno.Left - (lblTempoPassatoInterno.Left + lblTempoPassatoInterno.Width + 10)
            BarraAvanzamentoInterna.Width = diff
            BarraAvanzamentoInterna.Left = (lblTempoPassatoInterno.Left + lblTempoPassatoInterno.Width + 10)
            BarraAvanzamentoInterna.Top = pnlTasti.Height - BarraAvanzamento.Height - 8
            BarraAvanzamentoInterna.Height = 30
        Else
            BarraAvanzamentoInterna.Visible = False
            lblTempoPassatoInterno.Visible = False
            lblTempoTotaleInterno.Visible = False
        End If

    End Sub

    Private Sub ImpostaTastiInterni()
        cmdEliminaImmagineArtista.Left = 5
        cmdEliminaImmagineArtista.Top = lblNomeArtistaImm.top+1

        cmdSalva.Left = cmdEliminaImmagineArtista.Width + cmdEliminaImmagineArtista.Left + 2
        cmdSalva.Top = cmdEliminaImmagineArtista.Top

        cmdApreCartella.Left = cmdSalva.Left + cmdSalva.Width + 2
        cmdApreCartella.Top = cmdEliminaImmagineArtista.Top

        cmdTesto.Left = cmdApreCartella.Left + cmdApreCartella.Width + 2
        cmdTesto.Top = cmdEliminaImmagineArtista.Top

        cmdRefreshtestoInterno.Left = cmdTesto.Left + cmdTesto.Width + 2
        cmdRefreshtestoInterno.Top = cmdEliminaImmagineArtista.Top

        cmdTraduzione.Left = cmdRefreshtestoInterno.Left + cmdRefreshtestoInterno.Width + 2
        cmdTraduzione.Top = cmdEliminaImmagineArtista.Top

        cmdVisualizzaMembri.Left = cmdTraduzione.Width + cmdTraduzione.Left + 2
        cmdVisualizzaMembri.Top = cmdEliminaImmagineArtista.Top

        cmdRicaricaMembri.Left = cmdVisualizzaMembri.Width + cmdVisualizzaMembri.Left + 2
        cmdRicaricaMembri.Top = cmdEliminaImmagineArtista.Top
    End Sub

    Private Sub frmPlayer_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint
        'Dim g As Graphics = e.Graphics
        'Dim pen As New Pen(Color.White, 2.0)
        'g.DrawRectangle(pen, New Rectangle(picMP3.Location, picMP3.Size))
        'pen.Dispose()
    End Sub

    Private Sub frmPlayer_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        If PuoResizare Then
            If Me.Height < MinimaY Then Me.Height = MinimaY
            If Me.Width < MinimaX Then Me.Width = MinimaX

            ImpostaSchermata()

            If pnlTuttoSchermo.Visible = True Then
                pnlTuttoSchermo.Left = 0
                pnlTuttoSchermo.Top = 0
                pnlTuttoSchermo.Width = Me.Width
                pnlTuttoSchermo.Height = Me.Height
                'pnlTuttoSchermo.SizeMode = PictureBoxSizeMode.Zoom
                Application.DoEvents()
            End If
        End If
    End Sub

    Private Sub cmdImpostazioni_Click(sender As Object, e As EventArgs) Handles picSettings.Click
        ScrittaTestiVisibile = lblTesti.Visible
        lblTesti.Visible = False
        pnlImpostazioni.Visible = True
        pnlSpectrum2.Visible = False
        ImpostaSchermata()

        pnlImpostazioniInterno.Left = (pnlImpostazioni.Width / 2) - (pnlImpostazioniInterno.Width / 2)
        pnlImpostazioniInterno.Top = (pnlImpostazioni.Height / 2) - (pnlImpostazioniInterno.Height / 2)
        cmdChiudeImpostazioni.Left = (pnlImpostazioniInterno.Width - 20) - cmdChiudeImpostazioni.Width

        pnlAvanzamento.Left = -2
        pnlAvanzamento.Width = pnlImpostazioniInterno.Width + 4
        pnlAvanzamento.Top = (pnlImpostazioniInterno.Height / 2) - (pnlAvanzamento.Height / 2)

        lblAvanzamento.Left = 0
        lblAvanzamento.Width = pnlImpostazioniInterno.Width - 2
        lblAvanzamentoFile.Left = 0
        lblAvanzamentoFile.Width = pnlImpostazioniInterno.Width - 2

        lblFiltroImpostato.Visible = False

        cmdChiudeImpostazioni.Top = 10
    End Sub

    Private Sub cmdChiudeImpostazioni_Click(sender As Object, e As EventArgs) Handles cmdChiudeImpostazioni.Click
        lblTesti.Visible = ScrittaTestiVisibile
        pnlImpostazioni.Visible = False

        If lblFiltroImpostato.Text <> "***" And lblFiltroImpostato.Text <> "" Then
            lblFiltroImpostato.Visible = True
        End If

        If chkSpectrum.Checked = True Then
            pnlSpectrum2.Visible = True
        End If
    End Sub

    Private Sub PulisceAmbientePerCanzoneSuccessiva()
		'If pnlImmagineArtista.Visible Then
		'    pnlMediaPlayer.Visible = False
		'Else
		'    pnlMediaPlayer.Enabled = False
		'End If

		'If Not YouTubeClass Is Nothing Then
		'          YouTubeClass.StopButton()
		'      End If
		StrutturaDati.NomeVideo = ""
		'AxWindowsMediaPlayer1.URL = ""
		'AxWindowsMediaPlayer1.close()
		'lblNomeVideo.Text = ""
		If pnlImmagineArtista.Visible Then
            pnlImmagineArtista.BackgroundImage = My.Resources.pleaseWait ' Image.FromFile("Immagini/pleaseWait.jpg")
            picImmagineArtista.Image = My.Resources.pleaseWait ' Image.FromFile("Immagini/pleaseWait.jpg")
            ImmagineVisualizzata = picImmagineArtista.Image
        End If
        Application.DoEvents()
		'picSostituzioneMP.BackgroundImage = Image.FromFile("Immagini/pleaseWait.jpg")
		'picSostituzioneMP.Visible = True
		'Application.DoEvents()

		'AccendeSpegnePannelloVideo()
	End Sub

    Public Sub AvantiCanzone()
        If DoppioClickSuCanzone Then Exit Sub

        PulisceAmbientePerCanzoneSuccessiva()

        If qAscoltate < maxAscoltate Then
            StrutturaDati.QualeCanzoneStaSuonando = Ascoltate(qAscoltate + 1)
        Else
            Dim Ancora As Boolean = True
            Dim Valore As String = cmbBellezza.SelectedItem

            Do While Ancora
                If chkRandom.Checked = True Then
                    Dim x As Integer
                    Randomize()
                    x = Int(Rnd(1) * StrutturaDati.qCanzoni)
                    If x = 0 Then x = StrutturaDati.qCanzoni

                    StrutturaDati.QualeCanzoneStaSuonando = x
                Else
                    If StrutturaDati.QualeCanzoneStaSuonando < StrutturaDati.qCanzoni Then
                        StrutturaDati.QualeCanzoneStaSuonando += 1
                    Else
                        StrutturaDati.QualeCanzoneStaSuonando = 1
                    End If
                End If
                Ancora = False

                If chkBellezza.Checked = True Then
                    If Valore = "Mai Votate" Then
                        Dim Canzone As String = StrutturaDati.Canzoni(StrutturaDati.QualeCanzoneStaSuonando)
                        Dim bellezza As Integer = LettCanzoni.RitornaQuanteStelleCanzoneSenzaCaricarla(Canzone)
                        If bellezza > 0 Then
                            Ancora = True
                        End If
                    End If
                End If
            Loop
        End If

        inPausa = False

        If StaSuonando() Or StaCambiandoAutomaticamente Then
            Dim Campi() As String = StrutturaDati.Canzoni(StrutturaDati.QualeCanzoneStaSuonando).Split("\")

			Try
				Dim c As String = Campi(5)
				c = c.Replace(gf.TornaEstensioneFileDaPath(c), "")
				If c.Contains("-") Then c = Mid(c, c.IndexOf("-") + 2, c.Length)

				Dim a As String = Campi(4)
				Dim an As String = ""
				If a.Contains("-") Then
					an = Mid(a, 1, a.IndexOf("-"))
					a = Mid(a, a.IndexOf("-") + 2, a.Length)
				End If

				lblNomeCanzone.Text = "Prossimo brano: " & vbCrLf & Campi(3) & ": " & c & " - Album " & a & " (" & an & ")"
			Catch ex As Exception
				Dim campi2() As String = StrutturaDati.Canzoni(StrutturaDati.QualeCanzoneStaSuonando).Split("\")
				lblNomeCanzone.Text = "Prossimo brano: " & campi2(2) & " " & campi2(4)
			End Try
            Application.DoEvents()

            bIndietro = False

            SfumaInEntrata()
        Else
            CaricaCanzone()

			'PrendeVideo(AxWindowsMediaPlayer1, lstArtista.Text.Trim, lstAlbum.Text, lstCanzone.Text)

			pnlTestoInterno.Visible = GetSetting("MP3Tag", "Impostazioni", "TestoVisibile", False)
        End If
    End Sub

    Private Sub cmdAvanti_Click(sender As Object, e As EventArgs) Handles picAvanti.Click
        DoppioClickSuCanzone = False

        Avanticanzone()
    End Sub

    Private Sub IndietroCanzone()
        If DoppioClickSuCanzone Then Exit Sub

        PulisceAmbientePerCanzoneSuccessiva()

        If qAscoltate > 1 Then
            qAscoltate -= 1
            StrutturaDati.QualeCanzoneStaSuonando = Ascoltate(qAscoltate)
        Else
        End If

        inPausa = False

        If StaSuonando() Then
            Dim Campi() As String = StrutturaDati.Canzoni(StrutturaDati.QualeCanzoneStaSuonando).Split("\")

            Try
                Dim c As String = Campi(5)
                c = c.Replace(gf.TornaEstensioneFileDaPath(c), "")
                If c.Contains("-") Then c = Mid(c, c.IndexOf("-") + 2, c.Length)

                Dim a As String = Campi(4)
                Dim an As String = ""
                If a.Contains("-") Then
                    an = Mid(a, 1, a.IndexOf("-"))
                    a = Mid(a, a.IndexOf("-") + 2, a.Length)
                End If

                lblNomeCanzone.Text = "Brano precedente: " & vbCrLf & Campi(3) & ": " & c & " - Album " & a & " (" & an & ")"
            Catch ex As Exception
                lblNomeCanzone.Text = "Brano precedente: " & vbCrLf & gf.TornaNomeFileDaPath(StrutturaDati.Canzoni(StrutturaDati.QualeCanzoneStaSuonando))
            End Try
            Application.DoEvents()

            bIndietro = True
            SfumaInEntrata()
        Else
            CaricaCanzone(True)

			'PrendeVideo(AxWindowsMediaPlayer1, lstArtista.Text.Trim, lstAlbum.Text, lstCanzone.Text)

			pnlTestoInterno.Visible = GetSetting("MP3Tag", "Impostazioni", "TestoVisibile", False)
        End If
    End Sub

    Private Sub cmdIndietro_Click(sender As Object, e As EventArgs) Handles picIndietro.Click
        DoppioClickSuCanzone = False

        IndietroCanzone()
    End Sub

    Private Sub chkScaricaLyric_CheckedChanged(sender As Object, e As EventArgs) Handles chkScaricaLyric.Click
        SaveSetting("MP3Tag", "Impostazioni", "PlayerTesti", chkScaricaLyric.Checked)
    End Sub

    Private Sub cmdPlay_Click(sender As Object, e As EventArgs) Handles picPlay.Click
        If StaSuonando() = False Then
            menuItem1.ImpostaImmagineDaImage(My.Resources.icona_STOP, 24)
            ' menuItem1.ImpostaImmagine("Immagini\Icone\icona_stop.png", 24)
            menuItem1.ImpostaTesto("Stop")
            picPlay.BackgroundImage = My.Resources.icona_pausa ' Image.FromFile(Application.StartupPath & "\Immagini\icona_pausa.png")
            Application.DoEvents()
            'NotifyIcon1.Icon = New Icon("Immagini\Icone\play.ico")
            tmrCanzone.Enabled = True
            If inPausa = False Then
                DisabilitaControlli()

                SfumaInEntrata()
            Else
                'sa.FaiPartireTimer()
                'If QualeAudioStaSuonando = 2 Then
                audioCorrente1.controls.play()
                '    Else
                '    audioCorrente2.controls.play()
                'End If
                inPausa = False
                'StaSuonando = True
            End If
        Else
            menuItem1.ImpostaImmagineDaImage(My.Resources.icona_PLAY, 24)
            ' menuItem1.ImpostaImmagine("Immagini\Icone\icona_play.png", 24)
            menuItem1.ImpostaTesto("Play")
            'NotifyIcon1.Icon = New Icon("Immagini\Icone\pause.ico")
            'sa.FermaTimer()
            picPlay.BackgroundImage = My.Resources.icona_PLAY ' Image.FromFile(Application.StartupPath & "\Immagini\icona_Play.png")
            tmrCanzone.Enabled = False
            'If QualeAudioStaSuonando = 2 Then
            audioCorrente1.controls.pause()
            'Else
            '    audioCorrente2.controls.pause()
            'End If
            'StaSuonando = False
            inPausa = True

			'YouTubeClass.PauseButton()
		End If
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles tmrVisualizzaImmArtista.Tick
        If chkVisuaImmArtista.Checked = True And StaSuonando() = True Then
            Secondi += 1
            If Secondi >= SecondiPerImmagine Then
                Secondi = 0

                'posXYouTube = AxWindowsMediaPlayer1.Left
                'posYYouTube = AxWindowsMediaPlayer1.Top
                ' tmrSpostaYouTube.Enabled = True

                pnlImmagineArtista.Left = 0
                pnlImmagineArtista.Top = 0
                pnlImmagineArtista.Width = DimeX
                pnlImmagineArtista.Height = DimeY

                If pnlImmagineArtista.Width > pnlImmagineArtista.Height Then
                    dPicX = pnlImmagineArtista.Height
                    dPicY = pnlImmagineArtista.Height * (pnlImmagineArtista.Width / pnlImmagineArtista.Height)
                Else
                    dPicX = pnlImmagineArtista.Width
                    dPicY = pnlImmagineArtista.Height * (pnlImmagineArtista.Width / pnlImmagineArtista.Height)
                End If
                If dPicX > pnlImmagineArtista.Width Then dPicX = pnlImmagineArtista.Width
                If dPicY > pnlImmagineArtista.Height Then dPicY = pnlImmagineArtista.Height

                picImmagineArtista.Width = dPicX
                picImmagineArtista.Height = dPicY
                picImmagineArtista.Top = (pnlImmagineArtista.Height / 2) - (picImmagineArtista.Height / 2)
                picImmagineArtista.Left = (pnlImmagineArtista.Width / 2) - (picImmagineArtista.Width / 2)

                piat = New PrendeImmagineArtistaThread
                piat.ImpostaCampi(tmrCambioImmagine, picImmagineArtista, lstArtista, lblNomeImmArtista, pnlImmagineArtista,
                                  cmdEliminaImmagineArtista, pnlTasti, tmrSpostaScrittaTitolo, tmrEffettoImmagine, pnlSopra, pnlSotto, lstCanzone,
                                  pnlSpectrum2, cmdSalva, cmdTesto, cmdRefreshtestoInterno, pnlStelleInterno, cmdTraduzione, cmdApreCartella,
                                  lblNomeArtistaImm, lblFiltroImpostato)

                tmrVisualizzaImmArtista.Enabled = False
                tmrCambioImmagine.Enabled = True

                pnltestointerno.Visible = GetSetting("MP3Tag", "Impostazioni", "TestoVisibile", False)
                CambiaImmagine()

                ' Visualizzazione spectrum in basso
                'StaVisualizzandoImmagineArtista = True

                'If chkSpectrum.Checked = True Then
                '    pnlSpectrum2.Controls.Remove(pnlSSpectrum)
                '    pnlSSpectrum.Dispose()
                '    pnlSSpectrum = Nothing

                '    pnlImmagineArtista.Visible = True
                '    picImmagineArtista.Image = Nothing

                '    pnlTasti.Visible = False

                '    ImpostaSchermata()

                '    pnlTasti.BringToFront()

                '    RimettePannello()
                'End If
                ' Visualizzazione spectrum in basso

                'pnlImmagineArtista.Height = pnlTasti.Top
                ImpostaSchermata()

                If lblFiltroImpostato.Text.Trim <> "***" Then
                    lblFiltroImpostato.Width = pnlStelleInterno.Width * 2
                    lblFiltroImpostato.Left = (pnlImmagineArtista.Width / 2) - (lblFiltroImpostato.Width / 2) ' (Me.Width / 2) - (lblFiltroImpostato.Width / 2) ' BarraAvanzamento.Left ' (Me.Width / 2) - (lblFiltroImpostato.Width / 2)
                    lblFiltroImpostato.Top = pnlStelleInterno.Top + pnlStelleInterno.Height + 5 ' Me.Height - lblFiltroImpostato.Height - 3
                Else
                    lblFiltroImpostato.Top = -100
                    lblFiltroImpostato.Visible = False
                End If

                ScrittaTestiVisibile = lblTesti.Visible
                lblTesti.Visible = False
				'picYouTube.Visible = False

				'AccendeSpegnePannelloVideo()
			End If
        End If
    End Sub

    Private presentePannelloMembri As Boolean
    Private presentePannelloTesto As Boolean

    Private Sub picImmagineArtistaDown_Click(sender As Object, e As MouseEventArgs) Handles picImmagineArtista.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Right Then
            If Not staFermandoImmagine Then
                staFermandoImmagine = True

                vecchiaPosPicX = picImmagineArtista.Left
                vecchiaPosPicY = picImmagineArtista.Top
                vecchiaPosDimX = picImmagineArtista.Width
                vecchiaPosDimY = picImmagineArtista.Height

                picImmagineArtista.Left = 0
                picImmagineArtista.Top = 0
                picImmagineArtista.Width = DimeX - 16
                picImmagineArtista.Height = DimeY - 11

                FaScomparireBarra()

                gi.RuotaImmagine(picImmagineArtista, ImmagineVisualizzata, 0)

                tmrEffettoImmagine.Enabled = False
                tmrCambioImmagine.Enabled = False
                tmrNascondeBarra.Enabled = False

                If pnlMembriInterno.Visible = True Then
                    presentePannelloMembri = True
                    pnlMembriInterno.Visible = False
                Else
                    presentePannelloMembri = False
                End If

                If pnlTestoInterno.Visible = True Then
                    presentePannelloTesto = True
                    pnlTestoInterno.Visible = False
                Else
                    presentePannelloTesto = False
                End If
            End If
        Else
            EsciForaDaPnlImmagineArtista()
        End If
    End Sub

    Private Sub picImmagineArtistaUp_Click(sender As Object, e As MouseEventArgs) Handles picImmagineArtista.MouseUp
        If staFermandoImmagine Then
            picImmagineArtista.Left = vecchiaPosPicX
            picImmagineArtista.Top = vecchiaPosPicY
            picImmagineArtista.Width = vecchiaPosDimX
            picImmagineArtista.Height = vecchiaPosDimY

            tmrEffettoImmagine.Enabled = True
            tmrCambioImmagine.Enabled = True
            tmrNascondeBarra.Enabled = True

            staFermandoImmagine = False

            If presentePannelloMembri Then
                pnlMembriInterno.Visible =true
            End If

            If presentePannelloTesto Then
                pnlTestoInterno.Visible = True
            End If
        End If
    End Sub

    Private Sub EsciForaDaPnlImmagineArtista()
        picLingua.Visible = True
        pnlImmagineArtista.Visible = False
        tmrVisualizzaImmArtista.Enabled = True
        tmrCambioImmagine.Enabled = False
        tmrNascondeBarra.Enabled = False
        tmrSpostaScrittaTitolo.Enabled = False
        tmrEffettoImmagine.Enabled = False
        piat = Nothing
        Secondi = 0
        pnlStelleInterno.Visible = False
		'If chkYouTube.Checked Then
		'    picYouTube.Visible = True
		'End If
		lblTesti.Visible = ScrittaTestiVisibile

        ImpostaSchermata()

		'AccendeSpegnePannelloVideo()
	End Sub

    Private Sub RitornaAPlayerDaImmagine(sender As Object, e As EventArgs) Handles pnlImmagineArtista.Click, pnlSopra.Click, pnlSotto.Click
        EsciForaDaPnlImmagineArtista()
    End Sub

    Private Sub lstAlbum_MouseDown(sender As Object, e As MouseEventArgs) Handles lstAlbum.MouseDown
        If e.Button = MouseButtons.Right Then
            Dim index As Integer = lstAlbum.IndexFromPoint(New Point(e.X, e.Y))
            If index >= 0 Then
                lstAlbum.SelectedItem = lstAlbum.Items(index)

                Dim Album As String = lstAlbum.Text
                If Mid(Album, 5, 1) <> "-" Then
                    Album = "0000-" & Album
                End If

                lblFiltro.Text = lstArtista.Text & "^" & Album

                pnlFiltro.Left = pnlCanzoni.Left + lstAlbum.Left + e.Location.X
                pnlFiltro.Top = pnlCanzoni.Top + lstAlbum.Top + e.Location.Y

                If pnlFiltro.Left + pnlFiltro.Width + 20 > Me.Width Then
                    pnlFiltro.Left = Me.Width - pnlFiltro.Width - 20
                End If
                If pnlFiltro.Top + pnlFiltro.Height + 20 > Me.Height Then
                    pnlFiltro.Top = Me.Height - pnlFiltro.Height - 20
                End If

                pnlFiltro.Visible = True
            End If
        End If
    End Sub

    Private Sub lstArtista_MouseDown(sender As Object, e As MouseEventArgs) Handles lstArtista.MouseDown
        If e.Button = MouseButtons.Right Then
            Dim index As Integer = lstArtista.IndexFromPoint(New Point(e.X, e.Y))
            If index >= 0 Then
                lstArtista.SelectedItem = lstArtista.Items(index)

                Dim Artista As String = lstArtista.Text

                lblFiltro.Text = Artista

                pnlFiltro.Left = pnlCanzoni.Left + lstArtista.Left + e.Location.X
                pnlFiltro.Top = pnlCanzoni.Top + lstArtista.Top + e.Location.Y

                If pnlFiltro.Left + pnlFiltro.Width + 20 > Me.Width Then
                    pnlFiltro.Left = Me.Width - pnlFiltro.Width - 20
                End If
                If pnlFiltro.Top + pnlFiltro.Height + 20 > Me.Height Then
                    pnlFiltro.Top = Me.Height - pnlFiltro.Height - 20
                End If

                pnlFiltro.Visible = True
            End If
        End If
    End Sub

    Private Sub picAvanti_MouseEnter(sender As Object, e As EventArgs) Handles picAvanti.MouseEnter
        picAvanti.BackgroundImage = My.Resources.avanti_flip
    End Sub

    Private Sub picAvanti_MouseLeave(sender As Object, e As EventArgs) Handles picAvanti.MouseLeave
        picAvanti.BackgroundImage = My.Resources.avanti
    End Sub

    Private Sub picSettings_MouseEnter(sender As Object, e As EventArgs) Handles picSettings.MouseEnter
        picSettings.BackgroundImage = My.Resources.impostazioni_flip ' Image.FromFile("Immagini/impostazioni_flip.png")
    End Sub

    Private Sub picSettings_MouseLeave(sender As Object, e As EventArgs) Handles picSettings.MouseLeave
        picSettings.BackgroundImage = My.Resources.impostazioni ' Image.FromFile("Immagini/impostazioni.png")
    End Sub

    Private Sub picIndietro_MouseEnter(sender As Object, e As EventArgs) Handles picIndietro.MouseEnter
        picIndietro.BackgroundImage = My.Resources.indietro_flip ' Image.FromFile("Immagini/indietro_flip.png")
    End Sub

    Private Sub picIndietro_MouseLeave(sender As Object, e As EventArgs) Handles picIndietro.MouseLeave
        picIndietro.BackgroundImage = My.Resources.indietro ' Image.FromFile("Immagini/indietro.png")
    End Sub

    Private Sub picPlay_MouseEnter(sender As Object, e As EventArgs) Handles picPlay.MouseEnter
        If StaSuonando() = True Then
            picPlay.BackgroundImage = My.Resources.icona_pausa_flip ' Image.FromFile("Immagini\icona_pausa_flip.png")
        Else
            picPlay.BackgroundImage = My.Resources.icona_play_flip ' Image.FromFile("Immagini\icona_play_flip.png")
        End If
    End Sub

    Private Sub picPlay_MouseLeave(sender As Object, e As EventArgs) Handles picPlay.MouseLeave
        If StaSuonando() = True Then
            picPlay.BackgroundImage = My.Resources.icona_pausa ' Image.FromFile("Immagini\icona_pausa.png")
        Else
            picPlay.BackgroundImage = My.Resources.icona_PLAY ' Image.FromFile("Immagini\icona_play.png")
        End If
    End Sub

    Private Sub AzzeraSecondi(sender As Object, e As MouseEventArgs) Handles _
        pnlImmagine.MouseMove, lstTesto.MouseMove, pnlCanzoni.MouseMove, pnlTasti.MouseMove, picAvanti.MouseMove,
        picIndietro.MouseMove, picSettings.MouseMove, picPlay.MouseMove, lblNomeCanzone.MouseMove, picMP3.MouseMove,
        pnlImmagine.MouseMove, lstTesto.MouseMove, lstAlbum.MouseMove, lstArtista.MouseMove, lstCanzone.MouseMove,
        lblAlbum.MouseMove, lblArtista.MouseMove, lblCanzone.MouseMove, pnlBarra.MouseMove

        Secondi = 0
        SecondiPassatiPerFarScomparireIlPannello = 0

        If pnlFinestra.Width > 10 Then
            pnlFinestra.Width = 10
            pnlFinestra.Height = 10
            pnlFinestra.Left = (DimeX - pnlFinestra.Width) - 20

            cmdChiudeForm.Visible = False
            cmdMinimizzaForm.Visible = False
            'cmdSposta.Visible = False
            cmdMassimizza.Visible = False
        End If

        If tmrCambioImmagine.Enabled = False And tmrVisualizzaImmArtista.Enabled = False Then
            tmrVisualizzaImmArtista.Enabled = True
        End If
    End Sub

    Private Sub CambiaImmagine()
        If piat Is Nothing = False Then
            If lstArtista.Text <> "" Then
                If lstArtista.Text.IndexOf("ZZZ-") > -1 Then
                    picImmagineArtista.Image = My.Resources.Sconosciuto ' Image.FromFile("Immagini/Sconosciuto.jpg") ' gi.CaricaImmagineSenzaLockarla("Immagini/Sconosciuto.jpg")
                    ImmagineVisualizzata = picImmagineArtista.Image
                Else
                    piat.PrendeImmagineArtista(lstArtista.Text)
                End If
            End If
        Else
            piat = New PrendeImmagineArtistaThread
            piat.ImpostaCampi(tmrCambioImmagine, picImmagineArtista, lstArtista, lblNomeImmArtista, pnlImmagineArtista,
                              cmdEliminaImmagineArtista, pnlTasti, tmrSpostaScrittaTitolo, tmrEffettoImmagine, pnlSopra, pnlSotto,
                              lstCanzone, pnlSpectrum2, cmdSalva, cmdTesto, cmdRefreshtestoInterno, pnlStelleInterno, cmdTraduzione,
                              cmdApreCartella, lblNomeArtistaImm, lblFiltroImpostato)
            ' picImmagineArtista.Image = gi.CaricaImmagineSenzaLockarla("Immagini/Sconosciuto.jpg")
        End If

        picLingua.Visible = False
    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles tmrCambioImmagine.Tick
        CambiaImmagine()
    End Sub

	Private Sub pnlImmagineArtista_MouseMove1(sender As Object, e As MouseEventArgs) Handles pnlImmagineArtista.MouseMove, picImmagineArtista.MouseMove,
		pnlSopra.MouseMove, pnlSotto.MouseMove, pnlSpectrum2.MouseMove, pnlTestoInterno.MouseMove ', pnlMediaPlayer.MouseMove

		If Not staFermandoImmagine Then
			If Not pnlTasti.Visible Then
				pnlTasti.Visible = True
				lblNomeArtistaImm.Visible = True
				cmdEliminaImmagineArtista.Visible = True
				cmdSalva.Visible = True
				cmdVisualizzaMembri.Visible = True
				cmdRicaricaMembri.Visible = True
				cmdTesto.Visible = True
				cmdTraduzione.Visible = True
				cmdApreCartella.Visible = True
				lblFiltroImpostato.Visible = True
				pnlStelleInterno.Visible = True
				pnlStelleInterno.Top = lblNomeArtistaImm.Top + lblNomeArtistaImm.Height + 1
				pnlStelleInterno.Left = (Me.Width / 2) - (pnlStelleInterno.Width / 2)
				cmdRefreshtestoInterno.Visible = True
				tmrNascondeBarra.Enabled = True
				picLingua.Visible = False
				'If chkYouTube.Checked Then
				'	picYouTube.Visible = True
				'End If
			End If

			SecondiPassatiPerFarScomparireIlPannello = 0
		End If
	End Sub

	Private Sub Timer3_Tick(sender As Object, e As EventArgs) Handles tmrNascondeBarra.Tick
        SecondiPassatiPerFarScomparireIlPannello += 1
        If SecondiPassatiPerFarScomparireIlPannello >= SecondiPerFarScomparireIlPannello Then
            FaScomparireBarra()
        End If
    End Sub

    Private Sub FaScomparireBarra()
        cmdEliminaImmagineArtista.Visible = False
        lblFiltroImpostato.Visible = False
        cmdSalva.Visible = False
        cmdVisualizzaMembri.Visible = False
        cmdRicaricaMembri.Visible = False
        cmdTesto.Visible = False
        pnlStelleInterno.Visible = False
        cmdRefreshtestoInterno.Visible = False
        pnlTasti.Visible = False
        tmrNascondeBarra.Enabled = False
        cmdTraduzione.Visible = False
        lblNomeArtistaImm.Visible = False
        Try
            cmdApreCartella.Visible = False
        Catch ex As Exception

        End Try
		'picYouTube.Visible = False
	End Sub

    Private Sub cmdEliminaImmagineArtista_Click(sender As Object, e As EventArgs) Handles cmdEliminaImmagineArtista.Click
        If MsgBox("Si vuole eliminare l'immagine corrente?", vbYesNo + vbDefaultButton1 + vbInformation) = vbYes Then
			'Try
			'    Kill(lblNomeImmArtista.Text & ".DEL")
			'Catch ex As Exception

			'End Try
			Dim filetto As String = lblNomeImmArtista.Text
			filetto = filetto.Replace(StrutturaDati.PathMP3 & "\", "")
			Dim este As String = gf.TornaEstensioneFileDaPath(filetto)
			filetto = filetto.Replace(este, "")
			Dim DB As New SQLSERVERCE
			Dim conn As Object = CreateObject("ADODB.Connection")
			Dim rec As Object = CreateObject("ADODB.Recordset")
			Dim Sql As String = ""
			DB.ImpostaNomeDB(PathDB)
			DB.LeggeImpostazioniDiBase()
			conn = DB.ApreDB()
			Sql = "Insert Into ImmaginiEliminate Values ('" & filetto.Replace("'", "''") & "')"
			DB.EsegueSql(conn, Sql)
			conn.Close()
			DB = Nothing

			'gf.CreaAggiornaFile(lblNomeImmArtista.Text & ".DEL", "IMMAGINE ELIMINATA")
			gf.EliminaFileFisico(lblNomeImmArtista.Text)

            gi.PuliscePictureBox(picImmagineArtista)

            piat.PrendeImmagineArtista(lstArtista.Text)
        End If
    End Sub

    Public Sub lstAlbum_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstAlbum.Click
        Dim Album As String = lstAlbum.Text

        If Album <> "" Then
            If Directory.Exists(StrutturaDati.PathMP3 & "\" & lstArtista.Text & "\" & Album) = True Then
            Else
                If Mid(Album, 5, 1) <> "-" Then
                    Album = "0000-" & Album
                End If
                If Directory.Exists(StrutturaDati.PathMP3 & "\" & lstArtista.Text & "\" & Album) = True Then
                Else
                    Stop
                End If
            End If

            Dim sCanzoni() As String = {}
            Dim qCanzoni As Integer = -1

            If chkBellezza.Checked = False And chkFiltroTesto.Checked = False Then
                gf.ScansionaDirectorySingola(StrutturaDati.PathMP3 & "\" & lstArtista.Text & "\" & Album, FiltroRicerca)
                sCanzoni = gf.RitornaFilesRilevati
                qCanzoni = gf.RitornaQuantiFilesRilevati
            Else
                sCanzoni = StrutturaDati.Canzoni
                qCanzoni = StrutturaDati.Canzoni.Length - 1
                lstAlbum.Items.Clear()
                Dim art As String
                Dim ok As Boolean
                For i As Integer = 1 To qCanzoni
                    If sCanzoni(i).IndexOf(lstArtista.Text & "\") > -1 Then
                        ok = True
                        art = sCanzoni(i).Replace(StrutturaDati.PathMP3 & "\" & lstArtista.Text & "\", "")
                        art = Mid(art, 1, art.IndexOf("\"))
                        For k As Integer = 0 To lstAlbum.Items.Count - 1
                            If lstAlbum.Items(k) = art Then
                                ok = False
                                Exit For
                            End If
                        Next
                        If ok = True Then
                            lstAlbum.Items.Add(art)
                        End If
                    End If
                Next
            End If

            If lstAlbum.Text = "" Then
                For i As Integer = 0 To lstAlbum.Items.Count - 1
                    If Album = lstAlbum.Items(i) Then
                        lstAlbum.SelectedIndex = i
                        Exit For
                    End If
                Next
            End If

            Dim Nome As String

            lstCanzone.Items.Clear()
            For i As Integer = 1 To qCanzoni
                If sCanzoni(i).IndexOf(Album & "\") > -1 And sCanzoni(i).IndexOf(lstArtista.Text & "\") > -1 Then
                    Nome = sCanzoni(i).Replace(StrutturaDati.PathMP3 & "\" & lstArtista.Text & "\" & Album & "\", "")
                    If Mid(Nome, 1, 3) = "00-" Then
                        Nome = Mid(Nome, 4, Nome.Length)
                    End If
                    Nome = Nome.Trim
                    If Mid(Nome, 1, 1) = "-" Then
                        Nome = Mid(Nome, 2, Nome.Length)
                    End If
                    lstCanzone.Items.Add(Nome)
                End If
            Next
        End If
    End Sub

    Private Sub lstArtista_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstArtista.Click
        Dim sCanzoni() As String = {}
        Dim qCanzoni As Integer = -1
        Dim Ok As Boolean

        If chkBellezza.Checked = False And chkFiltroTesto.Checked = False Then
            gf.ScansionaDirectorySingola(StrutturaDati.PathMP3 & "\" & lstArtista.Text, FiltroRicerca)
            sCanzoni = gf.RitornaFilesRilevati
            qCanzoni = gf.RitornaQuantiFilesRilevati
        Else
            Dim appo As String = lstArtista.Text
            Dim art As String

            sCanzoni = StrutturaDati.Canzoni
            qCanzoni = StrutturaDati.Canzoni.Length - 1
            lstArtista.Items.Clear()

            For i As Integer = 1 To qCanzoni
                'If sCanzoni(i).IndexOf(lstArtista.Text) > -1 Then
                Ok = True
                art = sCanzoni(i).Replace(StrutturaDati.PathMP3 & "\", "")
                art = Mid(art, 1, art.IndexOf("\"))
                For k As Integer = 0 To lstArtista.Items.Count - 1
                    If lstArtista.Items(k) = art Then
                        Ok = False
                        Exit For
                    End If
                Next
                If Ok = True Then
                    lstArtista.Items.Add(art)
                End If
                'End If
            Next

            lstArtista.Text = appo
        End If

        Dim Nome As String

        lstAlbum.Items.Clear()
        For i As Integer = 1 To qCanzoni
            If sCanzoni(i).IndexOf(lstArtista.Text & "\") > -1 Then
                Nome = sCanzoni(i).Replace(StrutturaDati.PathMP3 & "\" & lstArtista.Text & "\", "")
                If Nome.IndexOf("ZZZ-ImmaginiArtista") = -1 Then
                    Nome = Mid(Nome, 1, Nome.IndexOf("\"))
                    Ok = True
                    If Mid(Nome, 1, 5) = "0000-" Then
                        Nome = Mid(Nome, 6, Nome.Length)
                    End If
                    If Mid(Nome, 1).Trim = "-" Then
                        Nome = Mid(Nome, 2, Nome.Length)
                    End If
                    For k As Integer = 0 To lstAlbum.Items.Count - 1
                        If Nome = lstAlbum.Items(k) Then
                            Ok = False
                            Exit For
                        End If
                    Next
                    If Ok = True Then
                        If Nome.Length > 2 Then
                            lstAlbum.Items.Add(Nome)
                        End If
                    End If
                End If
            End If
        Next

        lstCanzone.Items.Clear()
    End Sub

    Private Sub lstCanzone_DoubleClick(sender As Object, e As EventArgs) Handles lstCanzone.DoubleClick
        Dim NomeCanzone As String = lstCanzone.Text
        Dim NomeAlbum As String = lstAlbum.Text
        Dim NomeArtista As String = StrutturaDati.PathMP3 & "\" & lstArtista.Text & "\"

        'Me.Cursor = Cursors.WaitCursor

        For i As Integer = 1 To StrutturaDati.qCanzoni
            If StrutturaDati.Canzoni(i).IndexOf(NomeCanzone) > -1 And StrutturaDati.Canzoni(i).IndexOf(NomeAlbum) > -1 And StrutturaDati.Canzoni(i).IndexOf(NomeArtista) > -1 Then
                DoppioClickSuCanzone = True

                StrutturaDati.QualeCanzoneStaSuonando = i

                Dim s As Boolean = StaSuonando()

                If StaSuonando() = True Then
                    SfumaInUscita()
                End If

                CaricaCanzone()

                If s = True Then
                    'StaSuonando = True
                    SfumaInEntrata()
					'Else
					'    PrendeVideo(AxWindowsMediaPlayer1, lstArtista.Text.Trim, lstAlbum.Text, lstCanzone.Text)
				End If

                Exit For
            End If
        Next

        'Me.Cursor = Cursors.Default
    End Sub

    Private Sub pnlFinestra_MouseMove(sender As Object, e As MouseEventArgs) Handles pnlFinestra.MouseMove
        pnlFinestra.Width = 94
        pnlFinestra.Height = 31
        pnlFinestra.Left = (DimeX - pnlFinestra.Width) - 20

        cmdChiudeForm.Visible = True
        cmdMinimizzaForm.Visible = True
        'cmdSposta.Visible = True
        cmdMassimizza.Visible = True
    End Sub

    Private Sub cmdChiudeForm_Click(sender As Object, e As EventArgs) Handles cmdChiudeForm.Click
        SalvaPosizioneForm()

        'If Not trdTesti Is Nothing Then
        '    trdTesti.Abort()
        '    trdTesti = Nothing
        'End If

        StaUscendo = True
        If StaSuonando() = True Then
            SfumaInEntrata()
        Else
            ChiudeTutto()
        End If
    End Sub

    Private Sub cmdMinimizzaForm_Click(sender As Object, e As EventArgs) Handles cmdMinimizzaForm.Click
        DimeXPrimaDiMinimizzare = DimeX
        DimeYPrimaDiMinimizzare = DimeY

        Me.WindowState = System.Windows.Forms.FormWindowState.Minimized

        pnlFinestra.Width = 10
        pnlFinestra.Height = 10
        pnlFinestra.Left = (DimeX - pnlFinestra.Width) - 20

        cmdChiudeForm.Visible = False
        cmdMinimizzaForm.Visible = False
        'cmdSposta.Visible = False
        cmdMassimizza.Visible = True
    End Sub

    Private Sub tmrCanzone_Tick(sender As Object, e As EventArgs) Handles tmrCanzone.Tick
        SecondiSuonati += 0.5

        tMinuti = 0
        tSecondi = SecondiSuonati
        Do While tSecondi > 59
            tSecondi -= 60
            tMinuti += 1
        Loop

        If tSecondi > 10 And Not HaGiaScrittoAscoltataSulDB Then
            SalvaCanzoneAscoltata()
        End If

        lblTempoPassato.Text = Format(tMinuti, "00") & ":" & Format(tSecondi, "00")
        If SecondiSuonati <= BarraAvanzamento.Maximum Then
            BarraAvanzamento.Value = Int(SecondiSuonati)
            BarraAvanzamentoInterna.Value = BarraAvanzamento.Value
        Else
            If DoppioClickSuCanzone = False Then
                tmrCanzone.Enabled = False
                StaCambiandoAutomaticamente = True
                cmdAvanti_Click(sender, e)
            Else
                DoppioClickSuCanzone = False
            End If
        End If

        lblTempoPassatoInterno.Text = lblTempoPassato.Text
    End Sub

    Private Sub chkVisuaImmArtista_Click(sender As Object, e As EventArgs) Handles chkVisuaImmArtista.Click
        SaveSetting("MP3Tag", "Impostazioni", "PlayerVisuaImm", chkVisuaImmArtista.Checked)
    End Sub

    Private Sub OrdinaPerPrime(Optional Contrario As Boolean = False)
        Me.Cursor = Cursors.WaitCursor
        Dim DB As New SQLSERVERCE
        Dim conn As Object = CreateObject("ADODB.Connection")
        Dim rec As Object = CreateObject("ADODB.Recordset")
        Dim Sql As String
        Dim r As New RoutineVarie
        DB.ImpostaNomeDB(PathDB)
        DB.LeggeImpostazioniDiBase()
        conn = DB.ApreDB()

        Erase StrutturaDati.Canzoni
        StrutturaDati.qCanzoni = 0

        Dim Altro2 As String = ""
        If chkBellezza.Checked = True Then
            Dim Valore As String = cmbBellezza.Text
            If Valore = "Mai Votate" Then Valore = "0"

            If Valore > 0 Then
                If chkSuperiori.Checked = True Then
                    Altro2 = "Where Bellezza>=" & Valore
                Else
                    Altro2 = "Where Bellezza=" & Valore
                End If
            Else
                Altro2 = "Where Bellezza Is Null"
            End If
        End If
        If chkFiltroTesto.Checked = True And txtFiltroTesto.Text <> "" Then
            If Altro2 <> "" Then Altro2 += " And " Else Altro2 = "Where "
            If chkFiltroNome.Checked = True Then
                Altro2 += "(SUBSTRING(Canzone, 1, CHARINDEX('.', Canzone) - 1) Like '%" & r.SistemaTestoPerDB(txtFiltroTesto.Text) & "%')"
            Else
                Altro2 += "(Artista Like '%" & r.SistemaTestoPerDB(txtFiltroTesto.Text) & "%' Or Album Like '%" & r.SistemaTestoPerDB(txtFiltroTesto.Text) & "%' Or SUBSTRING(Canzone, 1, CHARINDEX('.', Canzone) - 1) Like '%" & r.SistemaTestoPerDB(txtFiltroTesto.Text) & "%')"
            End If
            'If chkRicercaSuTesto.Checked = True And txtFiltroTesto.Text <> "" Then
            '    Altro2 += "Union All SELECT B.Canzone, B.Testo  " & _
            '        "FROM ListaCanzone2 AS A INNER JOIN " & _
            '        "Testi AS B ON A.Artista + '\' + A.Album + '\' + A.Canzone = B.Canzone " & _
            '        "WHERE (B.Testo LIKE '%" & r.SistemaTestoPerDB(txtFiltroTesto.Text) & "%')"
            'End If
        End If

        'If chkRicercaSuTesto.Checked = True And txtFiltroTesto.Text <> "" Then
        '    Sql = "Select Count(*) From (Select A.Canzone, A.Artista From ListaCanzone2 " & Altro2 & ") C"
        'Else
        Sql = "Select Count(*) From ListaCanzone2 " & Altro2
        'End If
        rec = DB.LeggeQuery(conn, Sql)
        StrutturaDati.qCanzoni = rec(0).value
        ReDim StrutturaDati.Canzoni(StrutturaDati.qCanzoni)
        rec.Close()

        Dim p As Integer = 0
        Dim Altro As String

        If Contrario = False Then
            Altro = "Desc"
        Else
            Altro = ""
        End If

        Sql = "Select A.Artista+'\'+A.Album+'\' As Canzone, A.Canzone As Testo, Ascoltate From ListaCanzone2 " & Altro2 & " Order By "
        If chkRicordaAscoltate.Checked = True Then
            Sql += " Ascoltate, "
        End If
        Sql += " Datella " & Altro
        rec = DB.LeggeQuery(conn, Sql)
        Do Until rec.eof
            p += 1
            StrutturaDati.Canzoni(p) = StrutturaDati.PathMP3 & "\" & rec("Canzone").Value & rec("Testo").Value

            rec.MoveNext()
        Loop
        rec.Close()

        conn.Close()
        DB = Nothing
        Me.Cursor = Cursors.Default

        StrutturaDati.QualeCanzoneStaSuonando = 1
        AvantiCanzone()
        CaricaCanzone()
    End Sub

    Private Sub chkUltime_CheckedChanged(sender As Object, e As EventArgs) Handles chkUltime.Click
        SaveSetting("MP3Tag", "Impostazioni", "PlayerUltimeCanzoni", chkUltime.Checked)
        If chkUltime.Checked = True Then
            chkRandom.Checked = False
            SaveSetting("MP3Tag", "Impostazioni", "PlayerRandom", chkRandom.Checked)
            chkPrime.Checked = False
            SaveSetting("MP3Tag", "Impostazioni", "PlayerPrimeCanzoni", chkPrime.Checked)
            chkRicercaSuTesto.Checked = False
            SaveSetting("MP3Tag", "Impostazioni", "RicercaSuTesto", chkRicercaSuTesto.Checked)

            OrdinaPerPrime(False)
        End If
    End Sub

    Private Sub chkRandom_CheckedChanged(sender As Object, e As EventArgs) Handles chkRandom.Click
        SaveSetting("MP3Tag", "Impostazioni", "PlayerRandom", chkRandom.Checked)
        If chkRandom.Checked = True Then
            chkUltime.Checked = False
            SaveSetting("MP3Tag", "Impostazioni", "PlayerUltimeCanzoni", chkUltime.Checked)
            chkPrime.Checked = False
            SaveSetting("MP3Tag", "Impostazioni", "PlayerPrimeCanzoni", chkPrime.Checked)
        End If
    End Sub

    Private Sub chkWikipedia_Click(sender As Object, e As EventArgs) Handles chkWikipedia.Click
        SaveSetting("MP3Tag", "Impostazioni", "Wikipedia", chkWikipedia.Checked)

        If chkWikipedia.Checked = True Then
            ChiusuraWikipediaNONTramiteTasto = True
            Try
                frmWiki.Close()
            Catch ex As Exception

            End Try
            ChiusuraWikipediaNONTramiteTasto = False

            frmWiki = New frmWikipedia
            frmWiki.Left = Me.Left + Me.Width + 10
            frmWiki.Top = Me.Top
            frmWiki.Height = Me.Height
            frmWiki.Width = LarghezzaFormWikipedia
            frmWiki.ImpostaArtista(lstArtista.Text)
            frmWiki.Show()
            frmWiki.Visible = True
        Else
            frmWiki.Visible = False
        End If
    End Sub

    Private Sub chkPartePlayer_Click(sender As Object, e As EventArgs) Handles chkPartePlayer.Click
        SaveSetting("MP3Tag", "Impostazioni", "PlayerDiretto", chkPartePlayer.Checked)
    End Sub

    Private Sub chkSA_Click(sender As Object, e As EventArgs) Handles chkSpectrum.Click
        'If chkSpectrum.Checked = True Then
        '    pnlSpectrum2.Visible = True

        '    sa = New SpectrumAnalyzerII.FormAudioSpectrum
        '    Dim h As IntPtr = Me.Handle

        '    sa.Inizializza(pnlSSpectrum, h)
        'Else
        '    pnlSpectrum2.Visible = False

        '    sa = Nothing
        'End If

        'ImpostaSchermata()

        'SaveSetting("MP3Tag", "Impostazioni", "Spectrum", chkSpectrum.Checked)
    End Sub

    Private Sub lstCanzone_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lstCanzone.MouseDown
        If e.Button = MouseButtons.Right Then
            Dim index As Integer = lstCanzone.IndexFromPoint(New Point(e.X, e.Y))
            If index >= 0 Then
                lstCanzone.SelectedItem = lstCanzone.Items(index)

                lblNomeInModifica.Text = lstCanzone.Text

                pnlModifiche.Left = pnlCanzoni.Left + lstCanzone.Left + e.Location.X
                pnlModifiche.Top = pnlCanzoni.Top + lstCanzone.Top + e.Location.Y

                If pnlModifiche.Left + pnlModifiche.Width + 20 > Me.Width Then
                    pnlModifiche.Left = Me.Width - pnlModifiche.Width - 20
                End If
                If pnlModifiche.Top + pnlModifiche.Height + 20 > Me.Height Then
                    pnlModifiche.Top = Me.Height - pnlModifiche.Height - 20
                End If

                pnlModifiche.Visible = True
            End If
        End If
    End Sub

    Private Sub cmdAnnullaMod_Click(sender As Object, e As EventArgs) Handles cmdAnnullaMod.Click
        pnlModifiche.Visible = False
    End Sub

    Private Sub cmdRinomina_Click(sender As Object, e As EventArgs) Handles cmdRinomina.Click
        pnlModifiche.Visible = False

        Dim VecchioNome As String = lstCanzone.Text
        Dim Estensione As String = gf.TornaEstensioneFileDaPath(VecchioNome)
        Dim Traccia As String = "00"

        VecchioNome = VecchioNome.Replace(Estensione, "")
        If VecchioNome.IndexOf("-") > -1 Then
            Traccia = Mid(VecchioNome, 1, VecchioNome.IndexOf("-"))
            VecchioNome = Mid(VecchioNome, VecchioNome.IndexOf("-") + 2, VecchioNome.Length)
        End If

        Dim NuovoNome As String = InputBox("Nuovo nome", "Rinomina MP3", VecchioNome)

        Dim Anno As String = "0000"
        Dim Album As String = lstAlbum.Text
        If Mid(Album, 5, 1) = "-" Then
            Album = Mid(Album, 6, Album.Length)
        End If
        If Mid(Album, 5, 1) <> "-" Then
            Album = "0000-" & Album
        Else
            Anno = Mid(Album, 1, Album.IndexOf("-"))
        End If
        Dim Canzone As String = lstCanzone.Text
        If Canzone.IndexOf("-") = -1 Then
            Canzone = "00-" & Canzone
        End If

        Dim NomeDaModificare As String = StrutturaDati.PathMP3 & "\" & lstArtista.Text & "\" & Album & "\" & Canzone

        If NomeDaModificare = StrutturaDati.Canzoni(StrutturaDati.QualeCanzoneStaSuonando) Then
            MsgBox("Impossibile rinominare il brano." & vbCrLf & "Attualmente è in esecuzione")
            Exit Sub
        End If

        If NuovoNome <> "" And NuovoNome <> lstCanzone.Text Then
            Dim NomeModificato As String = StrutturaDati.PathMP3 & "\" & lstArtista.Text & "\" & Album & "\" & Traccia & "-" & NuovoNome & Estensione
            ImpostaTagCanzone(NomeDaModificare, NuovoNome, lstArtista.Text, Album, Anno, Traccia)

            Try
                Rename(NomeDaModificare, NomeModificato)

                LettCanzoni.LeggeCanzoniThread("RINFRESCALISTA", sender, e)
            Catch ex As Exception
                MsgBox("Errore nella rinomina: " & ex.Message)
            End Try

            'If StaSuonando = True Then
            '    cmdPlay_Click(sender, e)
            'End If
        End If
    End Sub

    Private Sub ImpostaTagCanzone(NuovoNomeFile As String, Titolo As String, Artista As String, Album As String, Anno As String, Traccia As String)
        'Me.Cursor = Cursors.WaitCursor

        Dim m As New MP3Tag
        m.ImpostaTag(NuovoNomeFile, Titolo, Album, Artista, Anno, Traccia)
        m = Nothing

        'Me.Cursor = Cursors.Default
    End Sub

    Private Sub cmdElimina_Click(sender As Object, e As EventArgs) Handles cmdElimina.Click
        pnlModifiche.Visible = False

        Dim Anno As String = "0000"
        Dim Album As String = lstAlbum.Text
        If Mid(Album, 5, 1) <> "-" Then
            Album = "0000-" & Album
        Else
            Anno = Mid(Album, 1, Album.IndexOf("-"))
        End If
        Dim Canzone As String = lstCanzone.Text
        If Canzone.IndexOf("-") = -1 Then
            Canzone = "00-" & Canzone
        End If
        Dim NomeDaModificare As String = StrutturaDati.PathMP3 & "\" & lstArtista.Text & "\" & Album & "\" & Canzone

        If NomeDaModificare = StrutturaDati.Canzoni(StrutturaDati.QualeCanzoneStaSuonando) Then
            MsgBox("Impossibile eliminare il brano." & vbCrLf & "Attualmente è in esecuzione")
            Exit Sub
        End If

        If MsgBox("Si vuole eliminare la canzone" & vbCrLf & vbCrLf & Canzone, vbYesNo + vbInformation + vbDefaultButton2) = vbYes Then
            'If StaSuonando = True Then
            '    cmdPlay_Click(sender, e)
            'End If

            If File.Exists(NomeDaModificare) Then
                File.SetAttributes(NomeDaModificare, FileAttributes.Normal)
                gf.EliminaFileFisico(NomeDaModificare)
            End If

            LettCanzoni.LeggeCanzoniThread("RINFRESCALISTADOPOELIMINA", sender, e)
        End If
    End Sub

    Private Sub ScriveValori()
        lblNomeArtistaImm.Text = ValoriDaScrivere(ValoreScritto) + "     "
        ValoreScritto += 1
        If ValoreScritto > qValoriDaScrivere Then
            ValoreScritto = 0
        End If
    End Sub

    Private Sub tmrSpostaScrittaTitolo_Tick(sender As Object, e As EventArgs) Handles tmrSpostaScrittaTitolo.Tick
        ScriveValori()
    End Sub

    Private Sub BarraAvanzamento_Scroll(sender As Object, e As EventArgs) Handles BarraAvanzamento.Scroll
        'If QualeAudioStaSuonando = 2 Then
        If audioCorrente1 Is Nothing = False Then
            audioCorrente1.controls.currentPosition = BarraAvanzamento.Value
        End If
        'Else
        'If audioCorrente2 Is Nothing = False Then
        '    audioCorrente2.controls.currentPosition = BarraAvanzamento.Value
        'End If
        'End If
        SecondiSuonati = BarraAvanzamento.Value
        BarraAvanzamentoInterna.Value = BarraAvanzamento.Value
    End Sub

    Private Sub BarraAvanzamentoInterna_Scroll(sender As Object, e As EventArgs) Handles BarraAvanzamentoInterna.Scroll
        'If QualeAudioStaSuonando = 2 Then
        If audioCorrente1 Is Nothing = False Then
            audioCorrente1.controls.currentPosition = BarraAvanzamentoInterna.Value
        End If
        'Else
        'If audioCorrente2 Is Nothing = False Then
        '    audioCorrente2.controls.currentPosition = BarraAvanzamentoInterna.Value
        'End If
        'End If
        SecondiSuonati = BarraAvanzamentoInterna.Value
        BarraAvanzamento.Value = BarraAvanzamentoInterna.Value
    End Sub

    'Private posXYouTube As Integer
    'Private posYYouTube As Integer
    'Private SpostamentoYouTube As Integer = 3

    Private Sub SpostaYouTube()
        'If pnlImmagineArtista.Visible = False Then
        '    Exit Sub
        'End If

        'Select Case SpostamentoYouTube
        '    Case 1
        '        posXYouTube += 3
        '        posYYouTube += 3

        '        If posXYouTube + AxWindowsMediaPlayer1.Width + 30 > pnlImmagineArtista.Width Then
        '            SpostamentoYouTube = 2
        '        End If
        '        If posYYouTube + AxWindowsMediaPlayer1.Height + 30 > pnlTasti.Top Then
        '            SpostamentoYouTube = 3
        '        End If
        '    Case 2
        '        posXYouTube -= 3
        '        posYYouTube += 3

        '        If posXYouTube < 10 Then
        '            SpostamentoYouTube = 1
        '        End If
        '        If posYYouTube + AxWindowsMediaPlayer1.Height + 30 > pnlTasti.Top Then
        '            SpostamentoYouTube = 4
        '        End If
        '    Case 3
        '        posXYouTube += 3
        '        posYYouTube -= 3

        '        If posXYouTube + AxWindowsMediaPlayer1.Width + 30 > pnlImmagineArtista.Width Then
        '            SpostamentoYouTube = 4
        '        End If
        '        If posYYouTube < pnlStelle.Top + pnlStelle.Height + 30 Then
        '            SpostamentoYouTube = 1
        '        End If
        '    Case 4
        '        posXYouTube -= 3
        '        posYYouTube -= 3

        '        If posXYouTube < 10 Then
        '            SpostamentoYouTube = 3
        '        End If
        '        If posYYouTube < pnlStelle.Top + pnlStelle.Height + 10 Then
        '            SpostamentoYouTube = 2
        '        End If
        'End Select

        'AxWindowsMediaPlayer1.Top = posYYouTube
        'AxWindowsMediaPlayer1.Left = posXYouTube
    End Sub

    Private Sub tmrEffettoImmagine_Tick(sender As Object, e As EventArgs) Handles tmrEffettoImmagine.Tick
        If pnlImmagineArtista.Visible = False Then
            Secondi = 0
            Exit Sub
        End If

        If ImmagineVisualizzata Is Nothing Then Exit Sub

        Dim gi As New GestioneImmagini

        'If picImmagineArtista.Visible = False Then
        DimePicMinX = CInt(ImmagineVisualizzata.Width / 1.5)
        DimePicMinY = CInt(ImmagineVisualizzata.Height / 1.5)

        DimePicMaxX = CInt(ImmagineVisualizzata.Width * 1.2)
        DimePicMaxY = CInt(ImmagineVisualizzata.Height * 1.2)

        PosMinX = 0 - (ImmagineVisualizzata.Width - CInt(ImmagineVisualizzata.Width / 1.5))
        PosMinY = 0 - (ImmagineVisualizzata.Height - CInt(ImmagineVisualizzata.Height / 1.5))

        PosMaxX = pnlImmagineArtista.Width - CInt(ImmagineVisualizzata.Width / 1.5)
        PosMaxY = pnlImmagineArtista.Height - CInt(ImmagineVisualizzata.Height / 1.5)

        tmrEffettoImmagine.Enabled = False
        If chkSpostaImmagini.Checked = True Then
            Passo += 1
            If Passo > QuantiPassi Then
                'Dim ArrivoX As Integer = (Me.Width / 2) - (DimeImmArtista(0) / 2)
                'Dim ArrivoY As Integer = (Me.Height / 2) - (DimeImmArtista(1) / 2)
                'Dim Ancora As Boolean = True
                'Dim qn As Integer = 0
                'Dim passo As Integer = 4

                'Do While Ancora
                '    qn = 0
                '    If Rotazione > 0 Then
                '        Rotazione -= passo
                '        picImmagineArtista.Image = RotateImage(ImmagineVisualizzata, Rotaz)
                '    Else
                '        qn += 1
                '    End If

                '    If picImmagineArtista.Left > ArrivoX Then
                '        picImmagineArtista.Left -= passo
                '        If picImmagineArtista.Left < ArrivoX Then picImmagineArtista.Left = ArrivoX
                '    Else
                '        If picImmagineArtista.Left < ArrivoX Then
                '            picImmagineArtista.Left += passo
                '            If picImmagineArtista.Left > ArrivoX Then picImmagineArtista.Left = ArrivoX
                '        Else
                '            qn += 1
                '        End If
                '    End If

                '    If picImmagineArtista.Top > ArrivoY Then
                '        picImmagineArtista.Top -= passo
                '        If picImmagineArtista.Top < ArrivoY Then picImmagineArtista.Top = ArrivoY
                '    Else
                '        If picImmagineArtista.Top < ArrivoY Then
                '            picImmagineArtista.Top += passo
                '            If picImmagineArtista.Top > ArrivoY Then picImmagineArtista.Top = ArrivoY
                '        Else
                '            qn += 1
                '        End If
                '    End If

                '    If picImmagineArtista.Width > DimeImmArtista(0) Then
                '        picImmagineArtista.Width -= passo
                '        If picImmagineArtista.Width < DimeImmArtista(0) Then picImmagineArtista.Width = DimeImmArtista(0)
                '    Else
                '        If picImmagineArtista.Width < DimeImmArtista(0) Then
                '            picImmagineArtista.Width += passo
                '            If picImmagineArtista.Width > DimeImmArtista(0) Then picImmagineArtista.Width = DimeImmArtista(0)
                '        Else
                '            qn += 1
                '        End If
                '    End If

                '    If picImmagineArtista.Height > DimeImmArtista(1) Then
                '        picImmagineArtista.Height -= passo
                '        If picImmagineArtista.Height < DimeImmArtista(1) Then picImmagineArtista.Height = DimeImmArtista(1)
                '    Else
                '        If picImmagineArtista.Height < DimeImmArtista(1) Then
                '            picImmagineArtista.Height += passo
                '            If picImmagineArtista.Height > DimeImmArtista(1) Then picImmagineArtista.Height = DimeImmArtista(1)
                '        Else
                '            qn += 1
                '        End If
                '    End If

                '    If qn = 5 Then
                '        Ancora = False
                '    End If
                'Loop

                Randomize()
                Dim q As Integer = Int(Rnd(1) * 9)
                Do While q = QualeEffettoImmagine
                    q = Int(Rnd(1) * 9)
                Loop
                If q = 0 Then q = 9

                Randomize()
                Dim r As Integer = Int(Rnd(1) * 6)
                Do While r = Rotazione
                    r = Int(Rnd(1) * 6)
                Loop
                If r = 0 Then r = 2

                Randomize()
                PassRotaz = Rnd(0) * 3

                Randomize()
                QuantiPassi = ((Int(Rnd(1) * 3) + 1) * 57) + 100
                Passo = 0

                QualeEffettoImmagine = q
                Rotazione = r

                'Rotaz = 0
            End If

            Select Case QualeEffettoImmagine
                Case 1
                    ' Rimpicciolimento
                    If picImmagineArtista.Width > DimePicMinX Then
                        picImmagineArtista.Width -= (PassoEffettoX * 1.7)
                    Else
                        Passo = QuantiPassi
                    End If
                    If picImmagineArtista.Height > DimePicMinY Then
                        picImmagineArtista.Height -= PassoEffettoY
                    Else
                        Passo = QuantiPassi
                    End If

                    If picImmagineArtista.Left < PosMaxX Then
                        picImmagineArtista.Left += (PassoEffettoX * 1.7)
                    Else
                        Passo = QuantiPassi
                    End If
                    If picImmagineArtista.Top < PosMaxY Then
                        picImmagineArtista.Top += (PassoEffettoY * 1.7)
                    Else
                        Passo = QuantiPassi
                    End If
                Case 2
                    ' Ingrandimento
                    If picImmagineArtista.Width < DimePicMaxX Then
                        picImmagineArtista.Width += PassoEffettoX
                    Else
                        Passo = QuantiPassi
                    End If
                    If picImmagineArtista.Height < DimePicMaxY Then
                        picImmagineArtista.Height += PassoEffettoY
                    Else
                        Passo = QuantiPassi
                    End If

                    If picImmagineArtista.Left > PosMinX Then
                        picImmagineArtista.Left -= PassoEffettoX
                    Else
                        Passo = QuantiPassi
                    End If
                    If picImmagineArtista.Top > PosMinY Then
                        picImmagineArtista.Top -= PassoEffettoY
                    Else
                        Passo = QuantiPassi
                    End If
                Case 3
                    If picImmagineArtista.Top < PosMaxY Then
                        picImmagineArtista.Top += 2
                    Else
                        Passo = QuantiPassi
                    End If
                    If picImmagineArtista.Left < PosMaxX Then
                        picImmagineArtista.Left += 2
                    Else
                        Passo = QuantiPassi
                    End If
                Case 4
                    If picImmagineArtista.Width < DimePicMaxX Then
                        picImmagineArtista.Width += PassoEffettoX
                    Else
                        Passo = QuantiPassi
                    End If
                    If picImmagineArtista.Height > DimePicMinY Then
                        picImmagineArtista.Height -= PassoEffettoY
                    Else
                        Passo = QuantiPassi
                    End If
                Case 5
                    If picImmagineArtista.Width < DimePicMaxX Then
                        picImmagineArtista.Width += PassoEffettoX
                    Else
                        Passo = QuantiPassi
                    End If
                    If picImmagineArtista.Height < DimePicMaxY Then
                        picImmagineArtista.Height += PassoEffettoY
                    Else
                        Passo = QuantiPassi
                    End If
                    If picImmagineArtista.Top > PosMinY Then
                        picImmagineArtista.Top -= 2
                    Else
                        Passo = QuantiPassi
                    End If
                    If picImmagineArtista.Left > PosMinX Then
                        picImmagineArtista.Left -= 2
                    Else
                        Passo = QuantiPassi
                    End If
                Case 6
                    If picImmagineArtista.Width < DimePicMaxX Then
                        picImmagineArtista.Width += PassoEffettoX
                    Else
                        Passo = QuantiPassi
                    End If
                    If picImmagineArtista.Height > DimePicMinY Then
                        picImmagineArtista.Height -= PassoEffettoY
                    Else
                        Passo = QuantiPassi
                    End If
                    If picImmagineArtista.Top < PosMaxY Then
                        picImmagineArtista.Top += 2
                    Else
                        Passo = QuantiPassi
                    End If
                    If picImmagineArtista.Left > PosMinX Then
                        picImmagineArtista.Left -= 2
                    Else
                        Passo = QuantiPassi
                    End If
                Case 7
                    If picImmagineArtista.Top > PosMinY Then
                        picImmagineArtista.Top -= 2
                    Else
                        Passo = QuantiPassi
                    End If
                    If picImmagineArtista.Left < PosMaxX Then
                        picImmagineArtista.Left += 2
                    Else
                        Passo = QuantiPassi
                    End If
                Case 8
                    If picImmagineArtista.Top < PosMaxY Then
                        picImmagineArtista.Top += 2
                    Else
                        Passo = QuantiPassi
                    End If
                    If picImmagineArtista.Left > PosMinX Then
                        picImmagineArtista.Left -= 2
                    Else
                        Passo = QuantiPassi
                    End If
                Case 9
                    If picImmagineArtista.Top > PosMinY Then
                        picImmagineArtista.Top -= 2
                    Else
                        Passo = QuantiPassi
                    End If
                    If picImmagineArtista.Left > PosMinX Then
                        picImmagineArtista.Left -= 2
                    Else
                        Passo = QuantiPassi
                    End If
            End Select

            If ImmagineVisualizzata Is Nothing = False Then
                Select Case Rotazione
                    Case 1
                        Rotaz += PassRotaz
                        If Rotaz > 360 Then Rotaz = 0
                        gi.RuotaImmagine(picImmagineArtista, ImmagineVisualizzata, Rotaz)
                    Case 3
                        Rotaz -= PassRotaz
                        If Rotaz < 0 Then Rotaz = 360
                        gi.RuotaImmagine(picImmagineArtista, ImmagineVisualizzata, Rotaz)
                    Case Else
                        If FattaRotazione = False Then
                            FattaRotazione = True
                            'RuotaImmagine(picImmagineArtista, ImmagineVisualizzata, Rotaz, picImmagineArtista.Left, picImmagineArtista.Top)
                            'Else
                            '    If FattaRotazione Then
                            '        If Rotaz > 0 Then Rotaz -= PassRotaz Else Rotaz += PassRotaz
                            '        If Rotaz = 0 Then
                            '            FattaRotazione = False
                            '        End If
                            '        picImmagineArtista.Image = RotateImage(ImmagineVisualizzata, Rotaz)
                            '    End If
                        End If
                End Select
            End If
            'picImmagineArtista.SizeMode = PictureBoxSizeMode.StretchImage

            'If pnltestointerno.Visible = True Then
            '    Select Case ModalitaSpostamentoTesto
            '        Case 1
            '            ' Giu / Destra
            '            testoX += 1
            '            testoY += 1

            '            If testoX + pnltestointerno.Width + 25 > Me.Width Then
            '                ModalitaSpostamentoTesto = 3
            '            End If
            '            If testoY + pnltestointerno.Height + 35 > Me.Height Then
            '                ModalitaSpostamentoTesto = 2
            '            End If
            '        Case 2
            '            ' Su / Destra
            '            testoX += 1
            '            testoY -= 1

            '            If testoX + pnltestointerno.Width + 25 > Me.Width Then
            '                ModalitaSpostamentoTesto = 4
            '            End If
            '            If testoY < 3 Then
            '                ModalitaSpostamentoTesto = 1
            '            End If
            '        Case 3
            '            ' Giu / Sinistra
            '            testoX -= 1
            '            testoY += 1

            '            If testoX < 3 Then
            '                ModalitaSpostamentoTesto = 1
            '            End If
            '            If testoY + pnltestointerno.Height + 35 > Me.Height Then
            '                ModalitaSpostamentoTesto = 4
            '            End If
            '        Case 4
            '            ' Su / Sinistra
            '            testoX -= 1
            '            testoY -= 1

            '            If testoX < 3 Then
            '                ModalitaSpostamentoTesto = 2
            '            End If
            '            If testoY < 3 Then
            '                ModalitaSpostamentoTesto = 3
            '            End If
            '    End Select

            '    pnltestointerno.Left = testoX
            '    pnltestointerno.Top = testoY
            '    pnltestointerno.Refresh()
            'End If
            tmrEffettoImmagine.Enabled = True
        End If
    End Sub

    'Private Sub tmrThread_Tick(sender As Object, e As EventArgs) Handles tmrThread.Tick
    '    If trd.IsAlive = False Then
    '        lblAggiornamentoCanzoni.Visible = False
    '        tmrThread.Enabled = False
    '        chkRandom.Enabled = True
    '        chkUltime.Enabled = True
    '        chkPrime.Enabled = True
    '    End If
    '    Application.DoEvents()
    'End Sub

    Private Sub cmdAggiornaCanzoni_Click(sender As Object, e As EventArgs) Handles cmdAggiornaCanzoni.Click
        'Dim DB As New SQLSERVERCE
        'Dim conn As Object = CreateObject("ADODB.Connection")
        'Dim rec As Object = CreateObject("ADODB.Recordset")
        'Dim Sql As String
        'DB.ImpostaNomeDB(PathDB)
        'DB.LeggeImpostazioniDiBase()
        'conn = DB.ApreDB()

        'Sql = "Truncate Table ListaCanzone2"
        'DB.EsegueSql(conn, Sql)

        'conn.Close()
        'DB = Nothing

        pnlImpostazioni.Visible = False

        LettCanzoni.LeggeCanzoniInBackground()
    End Sub

    Private Sub cmdAnnullaFiltro_Click(sender As Object, e As EventArgs) Handles cmdAnnullaFiltro.Click
        pnlFiltro.Visible = False
    End Sub

    Private Sub lblFiltroImpostato_Click(sender As Object, e As EventArgs) Handles lblFiltroImpostato.DoubleClick
        If MsgBox("Si vuole eliminare il filtro?", vbYesNo + vbInformation + vbDefaultButton2) = vbYes Then
            'Dim AppoStaSuonando As Boolean = StaSuonando

            SaveSetting("MP3Tag", "Impostazioni", "Filtro", "")
            lblFiltroImpostato.Text = "***"

            'chkRandom.Enabled = True
            chkUltime.Enabled = True
            chkPrime.Enabled = True

            Dim s As Boolean = StaSuonando()

            If StaSuonando() = True Then
                SfumaInUscita()
            End If

            If s = True Then
                'StaSuonando = True
                SfumaInEntrata()
            End If

            LettCanzoni.CaricaTutteLeCanzoni(False)

            CaricaCanzone()

            chkFiltroNome.Enabled = True
            chkRicercaSuTesto.Checked = True
            chkFiltroTesto.Enabled = True
            cmdFiltro.Enabled = True
            txtFiltroTesto.Enabled = True
            chkBellezza.Enabled = True
            cmbBellezza.Enabled = True
            lblFiltroImpostato.Visible = False

            'StaSuonando = AppoStaSuonando
        End If
    End Sub

    Private Sub cmdFiltro_Click(sender As Object, e As EventArgs) Handles cmdFiltro.Click
        Me.Cursor = Cursors.WaitCursor

        'Dim AppoStaSuonando As Boolean = StaSuonando
        Dim DB As New SQLSERVERCE
        Dim conn As Object = CreateObject("ADODB.Connection")
        Dim rec As Object = CreateObject("ADODB.Recordset")
        Dim Sql As String
        Dim r As New RoutineVarie
        DB.ImpostaNomeDB(PathDB)
        DB.LeggeImpostazioniDiBase()
        conn = DB.ApreDB()

        Erase StrutturaDati.Canzoni
        StrutturaDati.qCanzoni = 0

        Dim Campi() As String = lblFiltro.Text.Split("^")
        Dim Titolo As String

        If lblFiltro.Text.IndexOf("^") = -1 Then
            Sql = "Select Count(*) From ListaCanzone2 Where Artista='" & r.SistemaTestoPerDB(Campi(0)) & "'"
            Titolo = "ARTISTA: "
        Else
            Sql = "Select Count(*) From ListaCanzone2 Where Artista='" & r.SistemaTestoPerDB(Campi(0)) & "' And Album='" & r.SistemaTestoPerDB(Campi(1)) & "'"
            Titolo = "ALBUM: "
        End If
        rec = DB.LeggeQuery(conn, Sql)
        StrutturaDati.qCanzoni = rec(0).value
        ReDim StrutturaDati.Canzoni(StrutturaDati.qCanzoni)
        rec.Close()

        Dim p As Integer = 0

        If lblFiltro.Text.IndexOf("^") = -1 Then
            Sql = "Select * From ListaCanzone2 Where Artista='" & r.SistemaTestoPerDB(Campi(0)) & "'"
        Else
            Sql = "Select * From ListaCanzone2 Where Artista='" & r.SistemaTestoPerDB(Campi(0)) & "' And Album='" & r.SistemaTestoPerDB(Campi(1)) & "'"
        End If
        If chkRicordaAscoltate.Checked = True Then
            Sql += " Order By Ascoltata"
        End If

        rec = DB.LeggeQuery(conn, Sql)
        Do Until rec.eof
            p += 1
            StrutturaDati.Canzoni(p) = StrutturaDati.PathMP3 & "\" & rec("Artista").Value & "\" & rec("Album").Value & "\" & rec("Canzone").Value

            rec.MoveNext()
        Loop
        rec.Close()

        conn.Close()
        DB = Nothing
        Me.Cursor = Cursors.Default

        If lblFiltro.Text.IndexOf("^") = -1 Then
            lblFiltroImpostato.Text = Titolo & Campi(0) & " (" & StrutturaDati.qCanzoni & ")"
        Else
            lblFiltroImpostato.Text = Titolo & Campi(1) & " (" & StrutturaDati.qCanzoni & ")"
        End If

        Dim tt As ToolTip = New ToolTip()
        tt.SetToolTip(lblFiltroImpostato, "Fare doppio click per eliminare il filtro")

        lblFiltroImpostato.Visible = True

        SaveSetting("MP3Tag", "Impostazioni", "Filtro", lblFiltro.Text)
        pnlFiltro.Visible = False

        'chkRandom.Enabled = False
        chkUltime.Enabled = False
        chkPrime.Enabled = False

        If StrutturaDati.qCanzoni > 0 Then
            AvantiCanzone()
        End If
        CaricaCanzone()

        chkFiltroNome.Enabled = False
        chkRicercaSuTesto.Checked = False
        chkFiltroTesto.Enabled = False
        cmdFiltro.Enabled = False
        txtFiltroTesto.Enabled = False
        'chkBellezza.Enabled = False
        'cmbBellezza.Enabled = False

        ImpostaSchermata()
        'StaSuonando = AppoStaSuonando
    End Sub

    Private Sub chkPrime_Click(sender As Object, e As EventArgs) Handles chkPrime.Click
        SaveSetting("MP3Tag", "Impostazioni", "PlayerPrimeCanzoni", chkPrime.Checked)
        If chkPrime.Checked = True Then
            chkUltime.Checked = False
            SaveSetting("MP3Tag", "Impostazioni", "PlayerUltimeCanzoni", chkUltime.Checked)
            chkRandom.Checked = False
            SaveSetting("MP3Tag", "Impostazioni", "PlayerRandom", chkRandom.Checked)

            OrdinaPerPrime(True)
        End If
    End Sub

    Private Sub ChiudeTutto()
        If chkWikipedia.Checked = True Then
            ChiusuraWikipediaNONTramiteTasto = True
            Try
                frmWiki.Close()
            Catch ex As Exception

            End Try
            ChiusuraWikipediaNONTramiteTasto = False
        End If

        NotifyIcon1.Visible = False

        If chkPartePlayer.Checked = True Then
            End
        Else
            frmMain.Timer1.Enabled = False
            Me.Hide()
            frmMain.Show()
        End If
    End Sub

    Private Sub tmrFade_Tick(sender As Object, e As EventArgs) Handles tmrFadeOUT.Tick
        If StaSuonando() Or StaCambiandoAutomaticamente Then
            If audioCorrente1 Is Nothing = False Then
                If NonDiminuire Then
                    If audioCorrente1.settings.volume < 15 Then
                        audioCorrente1.settings.volume = 15
                    End If
                    ContaNonDiminuire += 1
                    If ContaNonDiminuire > 5 Then
                        NonDiminuire = False
                    End If
                Else
                    audioCorrente1.settings.volume -= TempoFade
                End If
                Application.DoEvents()

                If audioCorrente1.settings.volume <= 0 Then
                    If StaUscendo Then
                        ChiudeTutto()
                    Else
                        If Not File.Exists(StrutturaDati.Canzoni(StrutturaDati.QualeCanzoneStaSuonando)) Then
                            If StaSuonando() Then
                                Call cmdPlay_Click(sender, e)
                            End If
                            MsgBox("Canzone inesistente: " & vbCrLf & vbCrLf & StrutturaDati.Canzoni(StrutturaDati.QualeCanzoneStaSuonando), vbInformation)
                        Else
                            tmrFadeOUT.Enabled = False
                            tmrCanzone.Enabled = True
                            If pnlImmagineArtista.Visible Then
                                picImmagineArtista.Image = My.Resources.pleaseWait ' Image.FromFile("Immagini/wait.jpg") ' gi.CaricaImmagineSenzaLockarla("Immagini\wait.jpg")
                                pnlImmagineArtista.BackgroundImage = My.Resources.pleaseWait ' Image.FromFile("Immagini/wait.jpg") '  gi.CaricaImmagineSenzaLockarla("Immagini\wait.jpg")
                                ImmagineVisualizzata = picImmagineArtista.Image
                                Application.DoEvents()
                            End If
                            'tmrEffettoImmagine.Enabled = False

                            Try
                                picAvanti.Enabled = False
                                picIndietro.Enabled = False
                                lstCanzone.Enabled = False
                            Catch ex As Exception

                            End Try

                            audioCorrente1 = New WMPLib.WindowsMediaPlayer
                            audioCorrente1.URL = StrutturaDati.Canzoni(StrutturaDati.QualeCanzoneStaSuonando)
                            audioCorrente1.settings.volume = 100
                            audioCorrente1.controls.play()

                            AbilitaControlli()

                            CaricaCanzone()

							'If (StaSuonando() Or StaCambiandoAutomaticamente) Then
							'    PrendeVideo(AxWindowsMediaPlayer1, lstArtista.Text.Trim, lstAlbum.Text, lstCanzone.Text)
							'    'Else
							'    '    If YouTubeMostrato Then
							'    '        pnlMediaPlayer.Visible = True
							'    '    End If
							'End If

							pnlTestoInterno.Visible = GetSetting("MP3Tag", "Impostazioni", "TestoVisibile", False)

                            lstCanzone.Enabled = True
                            picIndietro.Enabled = True
                            picAvanti.Enabled = True

							'If (StaSuonando() Or StaCambiandoAutomaticamente) And YouTubeMostrato Then
							'    YouTubeClass.PlayButton()
							'End If

							'If chkSpostaImmagini.Checked Then
							'    tmrEffettoImmagine.Enabled = True
							'End If

							StaCambiandoAutomaticamente = False

                            HaGiaScrittoAscoltataSulDB = False
                        End If
                    End If
                End If
            Else
            End If
        Else
            HaGiaScrittoAscoltataSulDB = False

            Try
                audioCorrente1 = New WMPLib.WindowsMediaPlayer
                audioCorrente1.URL = StrutturaDati.Canzoni(StrutturaDati.QualeCanzoneStaSuonando)
                audioCorrente1.settings.volume = 100
                audioCorrente1.controls.play()

                AbilitaControlli()

                tmrFadeOUT.Enabled = False

				'PrendeVideo(AxWindowsMediaPlayer1, lstArtista.Text.Trim, lstAlbum.Text, lstCanzone.Text)
			Catch ex As Exception
                tmrFadeOUT.Enabled = False
                MsgBox("Errore nel caricamento del brano: " & vbCrLf & vbCrLf & ex.Message)
            End Try
        End If
    End Sub

    Private Sub SfumaInUscita()
    End Sub

    Private Sub AbilitaControlli()
        'picPlay.Enabled = True
        ' ''picAvanti.Enabled = True
        ' ''picIndietro.Enabled = True
        'picSettings.Enabled = True
        'lstCanzone.Enabled = True
        BarraAvanzamento.Enabled = True
        BarraAvanzamentoInterna.Enabled = True
    End Sub

    Private Sub DisabilitaControlli()
        'picPlay.Enabled = False
        ' ''picAvanti.Enabled = False
        ' ''picIndietro.Enabled = False
        'picSettings.Enabled = False
        'lstCanzone.Enabled = False
        BarraAvanzamento.Enabled = False
        BarraAvanzamentoInterna.Enabled = False
    End Sub

    Private Sub SfumaInEntrata()
        NonDiminuire = True
        ContaNonDiminuire = 0

        If tmrFadeOUT.Enabled Then
        Else
            'If pnlImmagineArtista.Visible Then
            '    picImmagineArtista.Image = Nothing
            '    pnlImmagineArtista.BackgroundImage = Nothing
            'End If

            tmrEffettoImmagine.Enabled = False

            tmrFadeOUT.Enabled = True
        End If
    End Sub

    Private Sub SalvaPosizioneForm()
        If Not isHidden Then
            SaveSetting("MP3Tag", "Impostazioni", "PlayerDimeX", DimeX)
            SaveSetting("MP3Tag", "Impostazioni", "PlayerDimeY", DimeY)
            SaveSetting("MP3Tag", "Impostazioni", "PlayerPosX", Me.Left)
            SaveSetting("MP3Tag", "Impostazioni", "PlayerPosY", Me.Top)
        End If
    End Sub

    Private Sub frmPlayer_ResizeEnd(sender As Object, e As EventArgs) Handles Me.ResizeEnd
        If PuoResizare Then
            SalvaPosizioneForm()
        End If
    End Sub

    Private Sub cmbSchedaAudio_Click(sender As Object, e As EventArgs) Handles cmbSchedaAudio.Click
    End Sub

    Private Sub chkSpostaImmagini_Click(sender As Object, e As EventArgs) Handles chkSpostaImmagini.Click
        SaveSetting("MP3Tag", "Impostazioni", "SpostaImmagini", chkSpostaImmagini.Checked)
    End Sub

    Private Sub cmbSchedaAudio_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbSchedaAudio.SelectedIndexChanged
        'If pnlSSpectrum Is Nothing = False Then
        'DeviceAudio = cmbSchedaAudio.Text
        'SaveSetting("MP3Tag", "Impostazioni", "DeviceAudio", DeviceAudio)
        'sa.ImpostaDevice(DeviceAudio)

        'Dim h As IntPtr = Me.Handle

        'sa.Inizializza(pnlSSpectrum, h)

        'ImpostaSchermata()
        'End If
    End Sub

    Private Sub ScriveQuanteStelleCanzone(Bellezza As Integer)
        If lstCanzone.Text = "" Or lstAlbum.Text = "" Or lstArtista.Text = "" Or idCanzone = -1 Then
            If idCanzone = -1 Then
                MsgBox("Indice canzone non valido: " & idCanzone)
            End If
            Exit Sub
        End If

        'Me.Cursor = Cursors.WaitCursor
        Dim r As New RoutineVarie
        Dim DB As New SQLSERVERCE
        Dim conn As Object = CreateObject("ADODB.Connection")
        Dim rec As Object = CreateObject("ADODB.Recordset")
        Dim Sql As String
        DB.ImpostaNomeDB(PathDB)
        DB.LeggeImpostazioniDiBase()
        conn = DB.ApreDB()
        Dim Ritorno As Integer = 0

        Sql = "Update ListaCanzone2 Set Bellezza=" & Bellezza & " Where " &
             "idCanzone=" & idCanzone

        DB.EsegueSql(conn, Sql)

        conn.Close()
        DB = Nothing
        'Me.Cursor = Cursors.Default
    End Sub

    Private Sub picStelle1_Click(sender As Object, e As EventArgs) Handles picStelle1.Click, picStelle1Interno.Click
        ScriveQuanteStelleCanzone(1)
        CaricaStelle(1)
    End Sub

    Private Sub picStelle2_Click(sender As Object, e As EventArgs) Handles picStelle2.Click, picStelle2Interno.Click
        ScriveQuanteStelleCanzone(2)
        CaricaStelle(2)
    End Sub

    Private Sub picStelle3_Click(sender As Object, e As EventArgs) Handles picStelle3.Click, picStelle3Interno.Click
        ScriveQuanteStelleCanzone(3)
        CaricaStelle(3)
    End Sub

    Private Sub picStelle4_Click(sender As Object, e As EventArgs) Handles picStelle4.Click, picStelle4Interno.Click
        ScriveQuanteStelleCanzone(4)
        CaricaStelle(4)
    End Sub

    Private Sub picStelle5_Click(sender As Object, e As EventArgs) Handles picStelle5.Click, picStelle5Interno.Click
        ScriveQuanteStelleCanzone(5)
        CaricaStelle(5)
    End Sub

    Private Sub picStelle6_Click(sender As Object, e As EventArgs) Handles picStelle6.Click, picStelle6Interno.Click
        ScriveQuanteStelleCanzone(6)
        CaricaStelle(6)
    End Sub

    Private Sub picStelle7_Click(sender As Object, e As EventArgs) Handles picStelle7.Click, picStelle7Interno.Click
        ScriveQuanteStelleCanzone(7)
        CaricaStelle(7)
    End Sub

    Private Sub chkBellezza_Click(sender As Object, e As EventArgs) Handles chkBellezza.Click
        Dim Valore As String

        If chkBellezza.Checked = True Then
            Valore = cmbBellezza.Text
        Else
            Valore = -1
        End If

        SaveSetting("MP3Tag", "Impostazioni", "Bellezza", Valore)

        If chkBellezza.Checked = True Then
            cmbBellezza.Enabled = True
            cmdEstrai.Enabled = True
            chkPath.Enabled = True
            chkSuperiori.Enabled = True
        Else
            cmbBellezza.Enabled = False
            cmdEstrai.Enabled = False
            chkPath.Enabled = False
            chkSuperiori.Enabled = False
        End If

        Me.Cursor = Cursors.WaitCursor

        If StaSuonando() Then
            picPlay.BackgroundImage = Image.FromFile(Application.StartupPath & "\Immagini\icona_Play.png")
            tmrCanzone.Enabled = False
            'If QualeAudioStaSuonando = 2 Then
            audioCorrente1.controls.pause()
            'Else
            '    audioCorrente2.controls.pause()
            'End If
            'StaSuonando = False
            inPausa = True
        End If

        LettCanzoni.CaricaTutteLeCanzoni(True)
        VisualizzaLista(lstArtista)

        AbilitaControlli()

        MsgBox("Canzoni rilevate: " & StrutturaDati.qCanzoni, vbInformation)

        Me.Cursor = Cursors.Default
    End Sub

    Private Sub cmbBellezza_Click(sender As Object, e As EventArgs) Handles cmbBellezza.SelectionChangeCommitted
        Dim Valore As String = cmbBellezza.SelectedItem
        If Valore = "Mai Votate" Then
            Valore = "0"
            cmdEstrai.Enabled = False
            chkSuperiori.Enabled = False
            chkSuperiori.Checked = False
        Else
            cmdEstrai.Enabled = True
            chkSuperiori.Enabled = True
        End If

        Me.Cursor = Cursors.WaitCursor

        SaveSetting("MP3Tag", "Impostazioni", "Bellezza", Valore)

        If StaSuonando() Then
            picPlay.BackgroundImage = Image.FromFile(Application.StartupPath & "\Immagini\icona_Play.png")
            tmrCanzone.Enabled = False
            'If QualeAudioStaSuonando = 2 Then
            audioCorrente1.controls.pause()
            'Else
            '    audioCorrente2.controls.pause()
            'End If
            'StaSuonando = False
            inPausa = True
        End If

        LettCanzoni.CaricaTutteLeCanzoni(True)
        VisualizzaLista(lstArtista)

        AbilitaControlli()

        Me.Cursor = Cursors.Default
    End Sub

    Private Sub chkFiltroTesto_Click(sender As Object, e As EventArgs) Handles chkFiltroTesto.Click
        Me.Cursor = Cursors.WaitCursor

        If chkFiltroTesto.Checked = False Then
            txtFiltroTesto.Text = ""
            txtFiltroTesto.Enabled = False
            cmdFiltraTesto.Enabled = False
            chkFiltroNome.Enabled = False
            chkRicercaSuTesto.Checked = False
        Else
            txtFiltroTesto.Enabled = True
            cmdFiltraTesto.Enabled = True
            chkFiltroNome.Enabled = True
            chkRicercaSuTesto.Checked = True
        End If

        SaveSetting("MP3Tag", "Impostazioni", "FiltroTesto", txtFiltroTesto.Text)

        LettCanzoni.CaricaTutteLeCanzoni(True)
        VisualizzaLista(lstArtista)

        MsgBox("Canzoni rilevate: " & StrutturaDati.qCanzoni, vbInformation)

        Me.Cursor = Cursors.Default
    End Sub

    Private Sub cmdFiltraTesto_Click(sender As Object, e As EventArgs) Handles cmdFiltraTesto.Click
        Me.Cursor = Cursors.WaitCursor

        SaveSetting("MP3Tag", "Impostazioni", "FiltroTesto", txtFiltroTesto.Text)

        LettCanzoni.CaricaTutteLeCanzoni(True)
        VisualizzaLista(lstArtista)

        AbilitaControlli()

        MsgBox("Canzoni rilevate: " & StrutturaDati.qCanzoni, vbInformation)

        Me.Cursor = Cursors.Default
    End Sub

    Private Sub chkFiltroNome_Click(sender As Object, e As EventArgs) Handles chkFiltroNome.Click
        Me.Cursor = Cursors.WaitCursor

        SaveSetting("MP3Tag", "Impostazioni", "FiltroSoloNome", chkFiltroNome.Checked)

        LettCanzoni.CaricaTutteLeCanzoni(True)
        VisualizzaLista(lstArtista)

        AbilitaControlli()

        Me.Cursor = Cursors.Default
    End Sub

    Private Sub cmdRefreshTesto_Click(sender As Object, e As EventArgs) Handles cmdRefreshTesto.Click, cmdRefreshtestoInterno.Click
        Dim NomeSong As String = gf.TornaNomeFileDaPath(StrutturaDati.Canzoni(StrutturaDati.QualeCanzoneStaSuonando)).Replace(gf.TornaEstensioneFileDaPath(StrutturaDati.Canzoni(StrutturaDati.QualeCanzoneStaSuonando)), "")
        If NomeSong.IndexOf("-") > -1 Then
            NomeSong = Mid(NomeSong, NomeSong.IndexOf("-") + 2, NomeSong.Length)
        End If

        Dim artista As String = lstArtista.Text.Trim
        Dim album As String = lstAlbum.Text
        If Mid(album, 5, 1) <> "-" Then
            album = "0000-" & album
        End If
        Dim canzone As String = lstCanzone.Text
        If Mid(canzone, 3, 1) <> "-" Then
            canzone = "00-" & canzone
        End If

        'Try

        'Catch ex As Exception

        'End Try
        tmrRefreshTesto.Enabled = False

        Dim Ancora As Boolean = True

        Do While Ancora
            Try
                cmdRefreshTesto.Visible = False
                Ancora = False
            Catch ex As Exception
                Thread.Sleep(100)
            End Try
        Loop

        Testo = ""
        TestoTradotto = ""

        ScaricaTestoCanzone(NomeSong, artista, album, canzone, True)
    End Sub

    Private Sub lstTesto_MouseClick(sender As Object, e As MouseEventArgs) Handles lstTesto.MouseDown
        If e.Button = MouseButtons.Right Then
            cmdRefreshTesto.Visible = True
            cmdRefreshTesto.Left = lstTesto.Left + 2
            cmdRefreshTesto.Top = lstTesto.Top + 2

            tmrRefreshTesto.Enabled = True
        End If
    End Sub

    Private Sub tmrRefreshTesto_Tick(sender As Object, e As EventArgs) Handles tmrRefreshTesto.Tick
        cmdRefreshTesto.Visible = False
        tmrRefreshTesto.Enabled = False
    End Sub

    Private Sub cmdEstrai_Click(sender As Object, e As EventArgs) Handles cmdEstrai.Click
        If chkBellezza.Checked = False Then
            MsgBox("Selezionare un filtro per bellezza")
            Exit Sub
        End If

        Dim gf As New GestioneFilesDirectory
        Dim VecchioPercorso As String = GetSetting("MP3Tag", "Impostazioni", "VecchioPath", Application.StartupPath)
        Dim Percorso As String = gf.SceltaDirectory(VecchioPercorso)

        If Percorso <> "" Then
            SaveSetting("MP3Tag", "Impostazioni", "VecchioPath", Percorso)

            pnlAvanzamento.Visible = True
            'pnlAvanzamento.Left = 0
            'pnlAvanzamento.Width = pnlImpostazioniInterno.Width
            'pnlAvanzamento.Top = (pnlImpostazioniInterno.Height / 2) - (pnlAvanzamento.Height / 2)

            'lblAvanzamento.Left = 0
            'lblAvanzamento.Width = pnlImpostazioniInterno.Width - 2
            'lblAvanzamentoFile.Left = 0
            'lblAvanzamentoFile.Width = pnlImpostazioniInterno.Width - 2

            lblAvanzamento.Text = ""
            lblAvanzamentoFile.Text = ""

            pnlImpostazioni.Enabled = False

            Dim Nome As String
            Dim sPercorso As String

            Me.Cursor = Cursors.WaitCursor
            For i As Integer = 1 To StrutturaDati.qCanzoni
                lblAvanzamento.Text = i & "/" & StrutturaDati.qCanzoni
                lblAvanzamentoFile.Text = gf.TornaNomeFileDaPath(StrutturaDati.Canzoni(i))
                Application.DoEvents()

                sPercorso = gf.TornaNomeDirectoryDaPath(StrutturaDati.Canzoni(i))
                sPercorso = sPercorso.Replace(StrutturaDati.PathMP3 & "\", "")

                If chkPath.Checked = True Then
                    sPercorso = Percorso & "\" & sPercorso & "\"
                    gf.CreaDirectoryDaPercorso(sPercorso)
                Else
                    sPercorso = Percorso & "\"
                End If

                Nome = sPercorso & gf.TornaNomeFileDaPath(StrutturaDati.Canzoni(i))

                If File.Exists(Nome) = False And File.Exists(StrutturaDati.Canzoni(i)) = True Then
                    File.Copy(StrutturaDati.Canzoni(i), Nome)
                End If

            Next
            Me.Cursor = Cursors.Default

            pnlImpostazioni.Enabled = True
            pnlAvanzamento.Visible = False

            MsgBox("Canzoni copiate")
        End If
    End Sub

    Private Sub chkPath_Click(sender As Object, e As EventArgs) Handles chkPath.Click
        SaveSetting("MP3Tag", "Impostazioni", "CreaPath", chkPath.Checked)
    End Sub

    Private Sub cmdEliminaBrutte_Click(sender As Object, e As EventArgs) Handles cmdEliminaBrutte.Click
        If MsgBox("Si vogliono eliminare le canzoni con voto minore di 5?", vbYesNo + vbDefaultButton2 + vbInformation) = vbNo Then
            Exit Sub
        End If

        pnlImpostazioni.Enabled = False
        pnlAvanzamento.Visible = True

        pnlAvanzamento.Left = -5
        pnlAvanzamento.Width = pnlImpostazioniInterno.Width + 5
        pnlAvanzamento.Top = (pnlImpostazioniInterno.Height / 2) - (pnlAvanzamento.Height / 2)

        lblAvanzamento.Text = ""
        lblAvanzamentoFile.Text = ""

        Dim DB As New SQLSERVERCE
        Dim conn As Object = CreateObject("ADODB.Connection")
        Dim rec As Object = CreateObject("ADODB.Recordset")
        Dim Sql As String
        Dim Brano As String = ""
        Dim Brani As Integer = 0
        Dim Quale As Integer = 0
        Dim Errori As Integer = 0
        Dim Inesistenti As Integer = 0
        Dim r As New RoutineVarie
        DB.ImpostaNomeDB(PathDB)
        DB.LeggeImpostazioniDiBase()
        conn = DB.ApreDB()

        Sql = "Select Artista, Album, Canzone As Brano From ListaCanzone2 Where Bellezza<5 And Bellezza>0"
        rec = DB.LeggeQuery(conn, Sql)
        Do Until rec.Eof
            Brani += 1

            rec.MoveNext()
        Loop
        If Brani > 0 Then rec.MoveFirst()
        Do Until rec.Eof
            Dim Artista As String = rec("Artista").Value
            Dim Album As String = rec("Album").Value
            'If Album.Contains("-") Then
            '    Album = Mid(Album, Album.IndexOf("-") + 2, Album.Length)
            'End If
            Brano = rec("Brano").Value
            'If Brano.Contains("-") Then
            '    Brano = Mid(Brano, Brano.IndexOf("-") + 2, Brano.Length)
            'End If

            Brano = StrutturaDati.PathMP3 & "\" & Artista & "\" & Album & "\" & Brano
            Brano = Brano.Replace("''", "'")
            Quale += 1

            lblAvanzamento.Text = Quale & "/" & Brani & " - Errori: " & Errori & " - Inesist.: " & Inesistenti
            lblAvanzamentoFile.Text = gf.TornaNomeFileDaPath(Brano)
            Application.DoEvents()

            If File.Exists(Brano) = True Then
                Try
                    File.SetAttributes(Brano, FileAttributes.Normal)
                    File.Delete(Brano)
                Catch ex As Exception
                    Errori += 1
                End Try
            Else
                Quale += 1
                Inesistenti += 1
            End If

            rec.MoveNext()
        Loop
        rec.Close()

        lblAvanzamentoFile.Text = ""
        Application.DoEvents()

        Sql = "Delete From ListaCanzone2 Where Bellezza<5"
        DB.EsegueSql(conn, Sql)

        conn.Close()
        DB = Nothing

        EliminaCartelleVuote(FiltroRicerca, lblAvanzamento, lblAvanzamentoFile)
        'EliminaVociSulDbNulle()

        pnlAvanzamento.Visible = False
        pnlImpostazioni.Enabled = True

        MsgBox("Canzoni eliminate")
    End Sub

    Private Sub chkRicercaSuTesto_CheckedChanged(sender As Object, e As EventArgs) Handles chkRicercaSuTesto.Click
        Me.Cursor = Cursors.WaitCursor

        SaveSetting("MP3Tag", "Impostazioni", "RicercaSuTesto", chkRicercaSuTesto.Checked)

        LettCanzoni.CaricaTutteLeCanzoni(True)
        VisualizzaLista(lstArtista)

        AbilitaControlli()

        Me.Cursor = Cursors.Default
    End Sub

    Private Sub chkSuperiori_Click(sender As Object, e As EventArgs) Handles chkSuperiori.Click
        Dim Valore As String

        If chkBellezza.Checked = True Then
            Valore = "1"
        Else
            Valore = "0"
        End If

        SaveSetting("MP3Tag", "Impostazioni", "Superiori", Valore)

        Me.Cursor = Cursors.WaitCursor

        If StaSuonando() Then
            picPlay.BackgroundImage = Image.FromFile(Application.StartupPath & "\Immagini\icona_Play.png")
            tmrCanzone.Enabled = False
            'If QualeAudioStaSuonando = 2 Then
            audioCorrente1.controls.pause()
            'Else
            '    audioCorrente2.controls.pause()
            'End If
            'StaSuonando = False
            inPausa = True
        End If

        LettCanzoni.CaricaTutteLeCanzoni(True)
        VisualizzaLista(lstArtista)

        AbilitaControlli()

        MsgBox("Canzoni rilevate: " & StrutturaDati.qCanzoni, vbInformation)

        Me.Cursor = Cursors.Default
    End Sub

    Private Sub chkRandomIntell_CheckedChanged(sender As Object, e As EventArgs) Handles chkRicordaAscoltate.CheckedChanged
        SaveSetting("MP3Tag", "Impostazioni", "RicordaAscoltate", chkRicordaAscoltate.Checked)
    End Sub

    Private Sub cmdEliminaVuote_Click(sender As Object, e As EventArgs) Handles cmdEliminaVuote.Click
        If MsgBox("Si vuole ffettuare la pulizia completa ?" & vbCrLf & vbCrLf & "Cartelle vuote" & vbCrLf & "AlbumArt e altre immagini", vbYesNo + vbDefaultButton2) = vbYes Then
            pnlImpostazioni.Enabled = False
            pnlAvanzamento.Visible = True

            pnlAvanzamento.Left = -5
            pnlAvanzamento.Width = pnlImpostazioniInterno.Width + 5
            pnlAvanzamento.Top = (pnlImpostazioniInterno.Height / 2) - (pnlAvanzamento.Height / 2)

            lblAvanzamento.Left = 1
            lblAvanzamento.Width = pnlAvanzamento.Width - 2
            lblAvanzamentoFile.Left = 1
            lblAvanzamentoFile.Width = pnlAvanzamento.Width - 2

            lblAvanzamento.Text = ""
            lblAvanzamentoFile.Text = ""

            EliminaAlbumArt()
            EliminaCartelleVuote(FiltroRicerca, lblAvanzamento, lblAvanzamentoFile)
            'EliminaVociSulDbNulle()

            lblAvanzamento.Text = ""
            lblAvanzamentoFile.Text = ""
            pnlAvanzamento.Visible = False
            pnlImpostazioni.Enabled = True

            MsgBox("Pulizia completa effettuata")
        End If
    End Sub

    Private Sub EliminaAlbumArt()
        Dim gf As New GestioneFilesDirectory

        gf.ScansionaDirectorySingola(StrutturaDati.PathMP3, "")
        Dim Cartelle() As String = gf.RitornaDirectoryRilevate
        Dim qCartelle As Integer = gf.RitornaQuanteDirectoryRilevate

        For i As Integer = 1 To qCartelle
            lblAvanzamento.Text = "Controllo " & Cartelle(i).Replace(StrutturaDati.PathMP3 & "\", "") & " " & i & "/" & qCartelle
            Application.DoEvents()

            Dim c As String = Cartelle(i)
            Dim Files As String() = Directory.GetFiles(c)

            If Files.Length > 0 Then
                For Each nf As String In Files
                    Dim nft As String = nf.ToUpper.Trim
                    If nft = "FOLDER.JPG" Or (nft.Contains("ALBUMART") And nft.Contains(".JPG")) Then
                        gf.ImpostaAttributiFile(nf, FileAttribute.Normal)
                        Try
                            File.Delete(nf)
                        Catch ex As Exception

                        End Try
                    End If
                Next
            End If
        Next i
    End Sub

    Public Shared Function RemoveAttribute(ByVal attributes As FileAttributes, ByVal attributesToRemove As FileAttributes) As FileAttributes
        Return attributes And (Not attributesToRemove)
    End Function

    Private Sub cmdSalva_Click(sender As Object, e As EventArgs) Handles cmdSalva.Click
        Dim Nome As String = gf.TornaNomeFileDaPath(lblNomeImmArtista.Text).Replace(".dat", "")

        Try
            MkDir(Application.StartupPath & "\ImmaginiSalvate")
        Catch ex As Exception

        End Try

        Nome = gf.NomeFileEsistente(Nome)

        If ControllaSeEStataSalvataUnaImmagine(lblNomeImmArtista.Text & "\" & Nome) Then
            MsgBox("Immagine già salvata")
            Exit Sub
        End If

        'If File.Exists(Application.StartupPath & "\ImmaginiSalvate.Txt") Then
        '    Dim Salvate As String = gf.LeggeFileIntero(Application.StartupPath & "\ImmaginiSalvate.Txt")
        '    If Salvate.IndexOf(lblNomeImmArtista.Text & "\" & Nome) > -1 Then
        '        MsgBox("Immagine già salvata")
        '        Exit Sub
        '    End If
        'End If

        Dim gi As New GestioneImmagini
        Dim Estensione As String = gf.TornaEstensioneFileDaPath(Nome)

        If Not Estensione.ToUpper.Contains(".JPG") And Not Estensione.ToUpper.Contains(".JPEG") Then
            Dim immagine As Image = gi.CaricaImmagineSenzaLockarla(lblNomeImmArtista.Text)
            Dim nomefile As String = gf.TornaNomeFileDaPath(lblNomeImmArtista.Text.Replace(".dat", ""))
            nomefile = nomefile.Replace(Estensione, "")
            If Estensione = "" Then Estensione = ".jpg"
            Dim pathfile As String = gf.TornaNomeDirectoryDaPath(lblNomeImmArtista.Text)
            gi.SalvaImmagineDaPictureBox(pathfile & "\Conv_" & nomefile & Estensione, immagine)
            Nome = pathfile & "\Conv_" & nomefile & Estensione
        Else
            Nome = lblNomeImmArtista.Text
        End If

        FileCopy(Nome, Application.StartupPath & "\ImmaginiSalvate\" & gf.TornaNomeFileDaPath(Nome).Replace(".dat", ""))

        If Nome.ToUpper.Contains("CONV_") Then
            Try
                Kill(Nome)
            Catch ex As Exception

            End Try
        End If

        Dim info() As String = {lstArtista.Text, Nome}
        gi.ScriveTag("MP3TAG", Application.StartupPath & "\ImmaginiSalvate\" & gf.TornaNomeFileDaPath(Nome).Replace(".dat", ""), "MP3Tag", info)
        gi = Nothing

        'gf.ApreFileDiTestoPerScrittura(Application.StartupPath & "\ImmaginiSalvate.Txt")
        'gf.ScriveTestoSuFileAperto(lblNomeImmArtista.Text & "\" & Nome)
        'gf.ChiudeFileDiTestoDopoScrittura()

        ScriveImmagineSalvataSuDB(lblNomeImmArtista.Text & "\" & Nome)

        MsgBox("Immagine salvata")
    End Sub

    Private Sub cmdTesto_Click(sender As Object, e As EventArgs) Handles cmdTesto.Click
        If pnlTestoInterno.Visible = True Then
            pnlTestoInterno.Visible = False
        Else
            pnlTestoInterno.Visible = True
        End If

        SaveSetting("MP3Tag", "Impostazioni", "TestoVisibile", pnlTestoInterno.Visible)
    End Sub

    Private Sub picLingua_Click(sender As Object, e As EventArgs) Handles picLingua.Click, cmdTraduzione.Click
        If LinguaOriginale Then
            LinguaOriginale = False
        Else
            LinguaOriginale = True
        End If
        SaveSetting("MP3Tag", "Impostazioni", "Lingua", LinguaOriginale)
        ImpostaLingua()
    End Sub

    Private Function PrendeTesto(Cosa As String) As String
        Dim Ritorno As String = ""

        If Cosa <> "" Then
            maxCaratteriTesto = 0
            maxRigheTesto = 0

            Dim r() As String = Cosa.Split("§")

            For i As Integer = 0 To r.Length - 1
                Ritorno += r(i) & vbCrLf
                If r(i).Length > maxCaratteriTesto Then
                    maxCaratteriTesto = r(i).Length
                End If
                maxRigheTesto += 1
            Next

            If r.Length - 1 < 5 Then
                Ritorno = Mid(Ritorno, 1, Ritorno.Length - 4)
                Ritorno += "Nessun testo rilevato"
                maxCaratteriTesto *= 3
                maxRigheTesto -= 1
            End If
        End If

        Return Ritorno
    End Function

    Private Sub ImpostaLingua()
        Dim g As New GestioneImmagini

        If LinguaOriginale Then
            picLingua.Image = My.Resources.inglese ' g.CaricaImmagineSenzaLockarla(Application.StartupPath & "\Immagini\Inglese.png")
            lstTesto.Visible = True
            lstTraduzione.Visible = False

            Dim l As New Label
            l.BackColor = Color.Transparent
            l.Left = 7
            l.Top = 7
            l.Font = New Font("Arial", 8)
            l.AutoSize = True

            l.Text = PrendeTesto(TestoInternoOrig)
            l.ForeColor = Color.Yellow

            pnlTestoInterno.Controls.Clear()
            pnlTestoInterno.Controls.Add(l)
        Else
            picLingua.Image = My.Resources.italiano ' g.CaricaImmagineSenzaLockarla(Application.StartupPath & "\Immagini\Italiano.png")
            lstTesto.Visible = False
            lstTraduzione.Visible = True

            Dim l As New Label
            l.BackColor = Color.Transparent
            l.Left = 7
            l.Top = 7
            l.Font = New Font("Arial", 8)
            l.AutoSize = True

            l.Text = PrendeTesto(TestoInternoTrad)
            l.ForeColor = Color.Azure

            pnlTestoInterno.Controls.Clear()
            pnlTestoInterno.Controls.Add(l)
        End If
        g = Nothing

        ImpostaSchermata()
    End Sub

    Private Sub tmrPartenza_Tick(sender As Object, e As EventArgs) Handles tmrPartenza.Tick
        tmrPartenza.Enabled = False

        Me.Width = GetSetting("MP3Tag", "Impostazioni", "PlayerDimeX", 650)
        Me.Height = GetSetting("MP3Tag", "Impostazioni", "PlayerDimeY", 450)
        Me.Height += BordoFinestra
        Me.Left = GetSetting("MP3Tag", "Impostazioni", "PlayerPosX", 10)
        'If Me.Left < 0 Then Me.Left = 0
        Me.Top = GetSetting("MP3Tag", "Impostazioni", "PlayerPosY", 10)
        'If Me.Top < 0 Then Me.Top = 0

        PuoResizare = True
        ImpostaTastiInterni()
        ImpostaSchermata()

        If pnlTuttoSchermo.Visible = True Then
            pnlTuttoSchermo.Left = 0
            pnlTuttoSchermo.Top = 0
            pnlTuttoSchermo.Width = Me.Width
            pnlTuttoSchermo.Height = Me.Height
            'pnlTuttoSchermo.SizeMode = PictureBoxSizeMode.Zoom
            Application.DoEvents()
        End If
    End Sub

    Private Sub frmMain_MouseDown(sender As Object, e As MouseEventArgs) Handles picMP3.MouseDown,
        pnlTasti.MouseDown, lblNomeArtistaImm.MouseDown

        Const WM_NCLBUTTONDOWN As Integer = &HA1
        Const HT_CAPTION As Integer = &H2

        If e.Button = MouseButtons.Left Then
            ReleaseCapture()
            SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0)
        End If
    End Sub

    Private Sub cmdGestioneTAG_Click(sender As Object, e As EventArgs) Handles cmdGestioneTAG.Click
        frmConTAG.ImpostaPercorso(StrutturaDati.PathMP3)
        frmConTAG.ImpostaArtista(lstArtista.Text, lstAlbum.Text, lstCanzone.Text)
        frmConTAG.DaDoveVengo("PLAYER")
        frmConTAG.Show()

        pnlImpostazioni.Visible = False

        If chkSpectrum.Checked = True Then
            pnlSpectrum2.Visible = True
        End If
    End Sub

    Private Sub cmdMassimizza_Click(sender As Object, e As EventArgs) Handles cmdMassimizza.Click
        Dim tt As New ToolTip()

        If Massimizzato Then
            tt.SetToolTip(cmdMassimizza, "Allarga la finestra a tutto schermo")
            cmdMassimizza.Text = "/\"
            Massimizzato = False
            Me.TopMost = False
            Me.WindowState = FormWindowState.Normal
        Else
            tt.SetToolTip(cmdMassimizza, "Ripristina la finestra")
            Me.TopMost = True
            Me.WindowState = FormWindowState.Maximized
            Massimizzato = True
            cmdMassimizza.Text = "_"
        End If
    End Sub

    Private Sub cmdEliminaTesti_Click(sender As Object, e As EventArgs) Handles cmdEliminaTesti.Click
        If MsgBox("Vuoi eliminare tutti i testi delle canzoni?", vbYesNo + vbInformation + vbDefaultButton2) = vbYes Then
            Dim DB As SQLSERVERCE
            Dim r As New RoutineVarie
            Dim conn As Object = CreateObject("ADODB.Connection")
            Dim Rec As Object = CreateObject("ADODB.Recordset")
            Dim Sql As String = ""
            DB = New SQLSERVERCE
            DB.ImpostaNomeDB(PathDB)
            DB.LeggeImpostazioniDiBase()
            conn = DB.ApreDB()

            Sql = "Update ListaCanzone2 Set Testo='', TestoTradotto=''"
            DB.EsegueSql(conn, Sql)

            'If Not trdTesti Is Nothing Then
            '    trdTesti.Abort()
            '    trdTesti = Nothing
            'End If

            'trdTesti = New Thread(AddressOf ScaricaTestiInBackground)
            'trdTesti.IsBackground = True
            'trdTesti.Start()

            'HaFinitoDiLeggereITesti = False
            ''QuanteTraduzioniHaSaltato = 0
            'lblTesti.Visible = True
            'tmrAttesaFineLetturaTesti.Enabled = True

            Dim gl As New getLyricsMP3_NEW
            gl.ScaricaTestiInBackground(instance)

            pnlImpostazioni.Visible = False
        End If
    End Sub

	'Private Sub MetteTogliePannelloYouTube()
	'    If YouTubeMostrato Then
	'        'If pnlMediaPlayer.Visible = False Then
	'        '    pnlMediaPlayer.Visible = True
	'        'End If

	'        If pnlImmagineArtista.Visible Then
	'            picPiu.Visible = True
	'            picMeno.Visible = True

	'            picIndietroMP.Height = pnlMediaPlayer.Height - 6
	'            picIndietroMP.Width = picIndietroMP.Height
	'            picIndietroMP.Left = 2
	'            picIndietroMP.Top = 2

	'            picMeno.Height = pnlMediaPlayer.Height - 6
	'            picMeno.Width = picMeno.Height
	'            picMeno.Left = picIndietroMP.Left + picIndietroMP.Width + 3
	'            picMeno.Top = 2

	'            picApreChiudeBarraMP.Height = pnlMediaPlayer.Height - 6
	'            picApreChiudeBarraMP.Width = picMeno.Height
	'            picApreChiudeBarraMP.Left = picMeno.Left + picMeno.Width + 3
	'            picApreChiudeBarraMP.Top = 2

	'            picNonCercareVideo.Height = pnlMediaPlayer.Height - 6
	'            picNonCercareVideo.Width = picMeno.Height
	'            picNonCercareVideo.Left = picApreChiudeBarraMP.Left + picApreChiudeBarraMP.Width + 3
	'            picNonCercareVideo.Top = 2

	'            picSalvaVideo.Height = pnlMediaPlayer.Height - 6
	'            picSalvaVideo.Width = picMeno.Height
	'            picSalvaVideo.Left = picNonCercareVideo.Left + picNonCercareVideo.Width + 3
	'            picSalvaVideo.Top = 2

	'            '----------------------------

	'            picAvantiMP.Height = pnlMediaPlayer.Height - 6
	'            picAvantiMP.Width = picAvantiMP.Height
	'            picAvantiMP.Left = pnlMediaPlayer.Width - picAvantiMP.Width - 3
	'            picAvantiMP.Top = 2

	'            picPiu.Height = pnlMediaPlayer.Height - 6
	'            picPiu.Width = picAvantiMP.Height
	'            picPiu.Left = picAvantiMP.Left - picPiu.Width - 3
	'            picPiu.Top = 2

	'            picElimina.Height = pnlMediaPlayer.Height - 6
	'            picElimina.Width = picAvantiMP.Height
	'            picElimina.Left = picPiu.Left - picElimina.Width - 3
	'            picElimina.Top = 2
	'        Else
	'            picPiu.Visible = False
	'            picMeno.Visible = False

	'            picIndietroMP.Left = 2
	'            picIndietroMP.Top = 2
	'            picIndietroMP.Height = pnlMediaPlayer.Height - 6
	'            picIndietroMP.Width = picIndietroMP.Height

	'            picApreChiudeBarraMP.Height = pnlMediaPlayer.Height - 6
	'            picApreChiudeBarraMP.Width = pnlMediaPlayer.Height - 6
	'            picApreChiudeBarraMP.Left = picIndietroMP.Left + picApreChiudeBarraMP.Width + 3
	'            picApreChiudeBarraMP.Top = 2

	'            picSalvaVideo.Height = pnlMediaPlayer.Height - 6
	'            picSalvaVideo.Width = pnlMediaPlayer.Height - 6
	'            picSalvaVideo.Left = picApreChiudeBarraMP.Left + picApreChiudeBarraMP.Width + 3
	'            picSalvaVideo.Top = 2

	'            picNonCercareVideo.Left = picSalvaVideo.Left + picSalvaVideo.Width + 3
	'            picNonCercareVideo.Top = 2
	'            picNonCercareVideo.Height = pnlMediaPlayer.Height - 6
	'            picNonCercareVideo.Width = picIndietroMP.Height

	'            picAvantiMP.Height = pnlMediaPlayer.Height - 6
	'            picAvantiMP.Width = picAvantiMP.Height
	'            picAvantiMP.Left = pnlMediaPlayer.Width - picAvantiMP.Width - 3
	'            picAvantiMP.Top = 2

	'            picElimina.Height = pnlMediaPlayer.Height - 6
	'            picElimina.Width = picAvantiMP.Height
	'            picElimina.Left = picAvantiMP.Left - picElimina.Width - 3
	'            picElimina.Top = 2
	'        End If

	'        lblNomeVideo.Width = picElimina.Left - (picSalvaVideo.Left + picSalvaVideo.Width)
	'        lblNomeVideo.Left = (picSalvaVideo.Left + picSalvaVideo.Width)
	'        lblNomeVideo.Top = (pnlMediaPlayer.Height / 2) - (lblNomeVideo.Height / 2)

	'        pnlMediaPlayer.BackColor = Color.FromArgb(25, 64, 64, 64)
	'        'picAvantiMP.Visible = False
	'        'picIndietroMP.Visible = False
	'        'picMeno.Visible = False
	'        'picPiu.Visible = False
	'        'picElimina.Visible = False
	'        'picSalvaVideo.Visible = False
	'        'picNonCercareVideo.Visible = False
	'        'picApreChiudeBarraMP.Visible = False
	'    Else
	'        'If pnlMediaPlayer.Visible = True Then
	'        '    pnlMediaPlayer.Visible = False
	'        'End If
	'    End If

	'    VisualizzatoPannelloMP = False
	'End Sub

	'Private Sub AccendeSpegnePannelloVideo()
	'       AxWindowsMediaPlayer1.Visible = YouTubeMostrato

	'       If AxWindowsMediaPlayer1.Visible = True Then
	'           If Not pnlImmagineArtista.Visible Then
	'               pnlContMP.Left = pnlImmagine.Left + 6
	'               pnlContMP.Top = pnlStelle.Top + pnlStelle.Height + 5
	'               pnlContMP.Width = pnlImmagine.Width - 7
	'               pnlContMP.Height = pnlBarra.Top - pnlContMP.Top - 5

	'               pnlMediaPlayer.Left = pnlContMP.Left + 2
	'               pnlMediaPlayer.Height = 36
	'               pnlMediaPlayer.Width = pnlContMP.Width - 4
	'               pnlMediaPlayer.Top = pnlContMP.Top + 1

	'               AxWindowsMediaPlayer1.Left = pnlContMP.Left + 2
	'               AxWindowsMediaPlayer1.Top = 38
	'               AxWindowsMediaPlayer1.Width = pnlContMP.Width - 4
	'               AxWindowsMediaPlayer1.Height = pnlContMP.Height '- 37
	'           Else
	'               pnlContMP.Width = (pnlImmagineArtista.Width / DimeWMP)
	'               pnlContMP.Height = (pnlImmagineArtista.Height / DimeWMP)

	'               If PosizioneMP = "" Then
	'                   pnlContMP.Left = ((pnlImmagineArtista.Width / 2) - (pnlContMP.Width / 2))
	'                   pnlContMP.Top = ((pnlImmagineArtista.Height / 2) - (pnlContMP.Height / 2))

	'                   PosizioneMP = pnlContMP.Top.ToString & ";" & pnlContMP.Left & ";"
	'                   SaveSetting("MP3Tag", "Impostazioni", "PosMediaPlayer", PosizioneMP)
	'               Else
	'                   Dim p() As String = PosizioneMP.Split(";")

	'                   pnlContMP.Left = p(1) '  ((pnlImmagineArtista.Width / 2) - (AxWindowsMediaPlayer1.Width / 2))
	'                   pnlContMP.Top = p(0) ' ((pnlImmagineArtista.Height / 2) - (AxWindowsMediaPlayer1.Height / 2))
	'               End If

	'               AxWindowsMediaPlayer1.Left = pnlContMP.Left + 2
	'               AxWindowsMediaPlayer1.Top = pnlContMP.Top + 2
	'               AxWindowsMediaPlayer1.Width = pnlContMP.Width - 5
	'               AxWindowsMediaPlayer1.Height = pnlContMP.Height - 4

	'               'AxWindowsMediaPlayer1.Left = 100
	'               'AxWindowsMediaPlayer1.Top = 100
	'               'AxWindowsMediaPlayer1.Width = 100
	'               'AxWindowsMediaPlayer1.Height = 100

	'               If AxWindowsMediaPlayer1.Width > pnlImmagineArtista.Width - 40 Or AxWindowsMediaPlayer1.Height > pnlImmagineArtista.Height - 40 Then
	'                   AxWindowsMediaPlayer1.Left = 0
	'                   AxWindowsMediaPlayer1.Width = pnlImmagineArtista.Width - 15
	'                   AxWindowsMediaPlayer1.Height = pnlImmagineArtista.Height - 55
	'                   AxWindowsMediaPlayer1.Top = 26

	'                   pnlMediaPlayer.Left = AxWindowsMediaPlayer1.Left
	'                   pnlMediaPlayer.Height = 25
	'                   pnlMediaPlayer.Width = AxWindowsMediaPlayer1.Width
	'                   pnlMediaPlayer.Top = 0
	'               Else
	'                   pnlMediaPlayer.Width = (pnlImmagineArtista.Width / DimeWMP)
	'                   pnlMediaPlayer.Left = pnlContMP.Left

	'                   pnlMediaPlayer.Top = pnlContMP.Top - 40
	'                   pnlMediaPlayer.Height = 35
	'               End If
	'           End If

	'           AxWindowsMediaPlayer1.stretchToFit = stf

	'           MetteTogliePannelloYouTube()

	'           AdattaPictureBox()
	'       End If
	'   End Sub

	'Private Sub picYoutTube_Click(sender As Object, e As EventArgs)
	'	If YouTubeMostrato Then
	'		YouTubeMostrato = False
	'		pnlContMP.Visible = False
	'		VecchiaVisibilitaPicSost = pnlMediaPlayer.Visible
	'		pnlMediaPlayer.Visible = False
	'		chkYouTube.Checked = False
	'		chkScaricaSubito.Checked = False
	'		chkScaricaSubito.Visible = False
	'		If Not YouTubeClass Is Nothing Then
	'			YouTubeClass.StopButton()
	'		End If
	'	Else
	'		YouTubeMostrato = True
	'		instance = Me
	'		lblNomeVideo.Text = ""
	'		pnlMediaPlayer.Visible = VecchiaVisibilitaPicSost
	'		pnlContMP.Visible = True
	'		chkYouTube.Checked = True
	'		chkScaricaSubito.Visible = True

	'		If AxWindowsMediaPlayer1.URL = "" And StrutturaDati.NomeVideo = "" Then
	'			Dim artista As String = lstArtista.Text
	'			Dim album As String = lstAlbum.Text
	'			If Mid(album, 5, 1) <> "-" Then
	'				album = "0000-" & album
	'			End If
	'			Dim canzone As String = lstCanzone.Text
	'			If Mid(canzone, 3, 1) <> "-" Then
	'				canzone = "00-" & canzone
	'			End If

	'			PrendeVideo(AxWindowsMediaPlayer1, artista, album, canzone)
	'		End If
	'	End If

	'	AccendeSpegnePannelloVideo()

	'	SaveSetting("MP3Tag", "Impostazioni", "YouTube", YouTubeMostrato)
	'End Sub

	'Private Sub chkYouTube_Click(sender As Object, e As EventArgs) Handles chkYouTube.Click
	'       SaveSetting("MP3Tag", "Impostazioni", "VisualizzaYouTube", chkYouTube.Checked)

	'       If chkYouTube.Checked Then
	'           AxWindowsMediaPlayer1.uiMode = "none"
	'           AxWindowsMediaPlayer1.stretchToFit = stf
	'           AxWindowsMediaPlayer1.settings.volume = 0
	'           YouTubeMostrato = GetSetting("MP3Tag", "Impostazioni", "YouTube", False)
	'           Call picYoutTube_Click(sender, e)
	'           YouTubeClass = New YouTube(instance, AxWindowsMediaPlayer1, chkYouTube, lblNomeVideo, picAvantiMP, picIndietroMP, picSalvaVideo, picApreChiudeBarraMP, picElimina)
	'           picYouTube.Visible = True

	'           If Not pPicSost Is Nothing Then
	'               pPicSost.Visible = True
	'           End If

	'           If pnlMediaPlayer.Visible = False Then
	'               pnlMediaPlayer.Visible = True
	'           End If

	'           chkScaricaSubito.Visible = True
	'       Else
	'           YouTubeMostrato = False
	'           'Call picYoutTube_Click(sender, e)
	'           YouTubeClass = Nothing
	'           AxWindowsMediaPlayer1.Visible = False
	'           picYouTube.Visible = False
	'           pnlMediaPlayer.Visible = False
	'           picYouTube.Visible = False
	'           pPicSost.Visible = False
	'           picMP3.Visible = True

	'           chkScaricaSubito.Visible = False
	'           ScaricaVideoSubito = "N"
	'           SaveSetting("MP3Tag", "Impostazioni", "ScaricaSubitoVideo", "N")
	'       End If

	'       ImpostaSchermata()
	'       'MetteTogliePannelloYouTube()
	'   End Sub

	'   Private Sub chkScaricaSubito_Click(sender As Object, e As EventArgs) Handles chkScaricaSubito.Click
	'       If chkScaricaSubito.Checked Then
	'           ScaricaVideoSubito = "S"
	'           SaveSetting("MP3Tag", "Impostazioni", "ScaricaSubitoVideo", "S")
	'       Else
	'           ScaricaVideoSubito = "N"
	'           SaveSetting("MP3Tag", "Impostazioni", "ScaricaSubitoVideo", "N")
	'       End If
	'   End Sub

	'Private Sub tmrSpostaYouTube_Tick(sender As Object, e As EventArgs) Handles tmrSpostaYouTube.Tick
	'    SpostaYouTube()
	'End Sub

	'Private Sub picIndietroMP_Click(sender As Object, e As EventArgs) Handles picIndietroMP.Click
	'       YouTubeClass.IndietreggiaVideo()
	'   End Sub

	'Private Sub picAvantiMP_Click(sender As Object, e As EventArgs) Handles picAvantiMP.Click
	'       YouTubeClass.AvanzaVideo()
	'   End Sub

	'Private Sub picMeno_Click(sender As Object, e As EventArgs) Handles picMeno.Click
	'       DimeWMP += 0.5

	'       AccendeSpegnePannelloVideo()

	'       SaveSetting("MP3Tag", "Impostazioni", "DimensioniYT", DimeWMP)
	'   End Sub

	'Private Sub picPiu_Click(sender As Object, e As EventArgs) Handles picPiu.Click
	'       If DimeWMP > 0.5 Then
	'           DimeWMP -= 0.5

	'           AccendeSpegnePannelloVideo()

	'           SaveSetting("MP3Tag", "Impostazioni", "DimensioniYT", DimeWMP)
	'       End If
	'   End Sub

	'Private Sub picElimina_Click(sender As Object, e As EventArgs) Handles picElimina.Click
	'       If MsgBox("Si vuole eliminare il video corrente ?", vbYesNo + vbInformation) = vbYes Then
	'           Dim NomeFile As String = StrutturaDati.NomeVideo
	'           If NomeFile <> "" Then
	'               NomeFileDaCancellare = NomeFile & ".del"

	'               YouTubeClass.PauseButton()

	'               YouTubeClass.StopButton()

	'               AggiungePictureBox(AxWindowsMediaPlayer1, "Immagini/noVideo.png")

	'               Try
	'                   File.Delete(NomeFile)
	'               Catch ex As Exception

	'               End Try

	'               'D:\Looigi\MP3\Xandria\2014-Sacrificium  (limited Edition) Cd 2\VideoYouTube\OTTEGBCG188.mp4
	'               Dim gf As New GestioneFilesDirectory
	'               Dim Percorso As String = gf.TornaNomeDirectoryDaPath(NomeFile).Replace(StrutturaDati.PathMP3, "") ' Xandria\2014-Sacrificium  (limited Edition) Cd 2\VideoYouTube
	'               Dim NomeVideo As String = gf.TornaNomeFileDaPath(NomeFile).Replace(gf.TornaEstensioneFileDaPath(NomeFile), "") ' OTTEGBCG188
	'               Dim Campi() As String = Percorso.Split("\")
	'               Dim PercorsoImmagini As String = StrutturaDati.PathMP3 & Campi(0) & "\" & Campi(1) & "\ZZZ-ImmaginiArtista"

	'               Dim di As New IO.DirectoryInfo(PercorsoImmagini)
	'               Dim diar1 As IO.FileInfo() = di.GetFiles()
	'               Dim dra As IO.FileInfo

	'               For Each dra In diar1
	'                   If dra.FullName.Contains(NomeVideo) Then
	'                       File.Delete(dra.FullName)
	'                   End If
	'               Next

	'               tmrCreaFileVideoVuoto = New System.Timers.Timer(2000)
	'               AddHandler tmrCreaFileVideoVuoto.Elapsed, AddressOf CreaFileVideoVuoto
	'               tmrCreaFileVideoVuoto.Start()

	'               lblNomeVideo.Text = ""

	'               StrutturaDati.NomeVideo = ""
	'               AxWindowsMediaPlayer1.URL = ""
	'               picElimina.Visible = False
	'               picSalvaVideo.Visible = False
	'               picApreChiudeBarraMP.Visible = False
	'           End If
	'       End If
	'   End Sub

	'Private Sub CreaFileVideoVuoto()
	'       tmrCreaFileVideoVuoto.Enabled = False

	'       Dim gf As New GestioneFilesDirectory
	'       gf.CreaAggiornaFile(NomeFileDaCancellare, "")
	'       gf = Nothing

	'       If Not File.Exists(NomeFileDaCancellare) Then
	'           tmrCreaFileVideoVuoto.Enabled = True
	'       Else
	'           tmrCreaFileVideoVuoto = Nothing
	'       End If
	'   End Sub

	'Private Sub picSalvaVideo_Click(sender As Object, e As EventArgs) Handles picSalvaVideo.Click
	'	Dim Nome As String = lstArtista.Text & "-" & lstCanzone.Text ' Mid(lblNomeVideo.Text, 1, lblNomeVideo.Text.IndexOf(" "))
	'	Nome = Nome.Replace(gf.TornaEstensioneFileDaPath(Nome), "")

	'	Try
	'		MkDir(Application.StartupPath & "\ImmaginiSalvate")
	'	Catch ex As Exception

	'	End Try

	'	Try
	'		MkDir(Application.StartupPath & "\ImmaginiSalvate\Video")
	'	Catch ex As Exception

	'	End Try

	'	'Nome = gf.NomeFileEsistente(Nome)

	'	If ControllaSeEStataSalvataUnaImmagine(Nome) Then
	'		MsgBox("Video già salvato")
	'		Exit Sub
	'	End If

	'	'If File.Exists(Application.StartupPath & "\ImmaginiSalvate.Txt") Then
	'	'    Dim Salvate As String = gf.LeggeFileIntero(Application.StartupPath & "\ImmaginiSalvate.Txt")
	'	'    If Salvate.IndexOf(lblNomeImmArtista.Text & "\" & Nome) > -1 Then
	'	'        MsgBox("Immagine già salvata")
	'	'        Exit Sub
	'	'    End If
	'	'End If

	'	Dim Estensione As String = gf.TornaEstensioneFileDaPath(AxWindowsMediaPlayer1.URL)
	'	FileCopy(AxWindowsMediaPlayer1.URL, Application.StartupPath & "\ImmaginiSalvate\Video\" & Nome & Estensione)

	'	'gf.ApreFileDiTestoPerScrittura(Application.StartupPath & "\ImmaginiSalvate.Txt")
	'	'gf.ScriveTestoSuFileAperto(lblNomeImmArtista.Text & "\" & Nome)
	'	'gf.ChiudeFileDiTestoDopoScrittura()

	'	ScriveImmagineSalvataSuDB(Nome)

	'	MsgBox("Video salvato")
	'End Sub

	'Private Sub picNonCercareVideo_Click(sender As Object, e As EventArgs) Handles picNonCercareVideo.Click
	'       If StrutturaDati.VideoLockati Then
	'           YouTubeClass.AbilitaVideo()
	'       Else
	'           YouTubeClass.DisabilitaVideo()
	'       End If
	'   End Sub

	'   Private Sub picApreChiudeBarraMP_Click(sender As Object, e As EventArgs) Handles picApreChiudeBarraMP.Click
	'       If AxWindowsMediaPlayer1.uiMode = "none" Then
	'           AxWindowsMediaPlayer1.uiMode = "full"
	'       Else
	'           AxWindowsMediaPlayer1.uiMode = "none"
	'       End If
	'   End Sub

	'   Private Sub tmrPrendeThumbs_Tick(sender As Object, e As EventArgs) Handles tmrPrendeThumbs.Tick
	'       tmrPrendeThumbs.Enabled = False

	'       YouTubeClass.PrendeThumb()
	'   End Sub

	'   Private Sub pnlMediaPlayer_Move(sender As Object, e As MouseEventArgs) Handles pnlMediaPlayer.MouseDown
	'       If pnlImmagineArtista.Visible Then
	'           _mousedownWMP = True
	'           _mouseposWMP = New Point(e.X, e.Y)
	'       End If
	'   End Sub

	'   Private Sub pnlMediaPlayer_MouseMove(sender As Object, e As MouseEventArgs) Handles pnlMediaPlayer.MouseMove
	'       If pnlImmagineArtista.Visible Then
	'           If _mousedownWMP Then
	'               pnlMediaPlayer.Location = PointToClient(pnlMediaPlayer.PointToScreen(New Point(e.X -
	'               _mouseposWMP.X, e.Y - _mouseposWMP.Y)))
	'               pnlContMP.Location = PointToClient(pnlMediaPlayer.PointToScreen(New Point(e.X -
	'               _mouseposWMP.X, (e.Y - _mouseposWMP.Y) + 40)))
	'               AxWindowsMediaPlayer1.Location = PointToClient(pnlMediaPlayer.PointToScreen(New Point(e.X -
	'               _mouseposWMP.X + 1, (e.Y - _mouseposWMP.Y) + 41)))
	'           End If
	'       End If
	'   End Sub

	'   Private Sub pnlMediaPlayer_MouseUp(sender As Object, e As MouseEventArgs) Handles pnlMediaPlayer.MouseUp
	'       If pnlImmagineArtista.Visible Then
	'           Dim Pos As String = (pnlMediaPlayer.Top + 40).ToString & ";" & pnlMediaPlayer.Left.ToString & ";"
	'           PosizioneMP = Pos
	'           SaveSetting("MP3Tag", "Impostazioni", "PosMediaPlayer", Pos)
	'           _mousedownWMP = False

	'           pnlTestoInterno.Left = 100
	'           pnlTestoInterno.Top = 100
	'           pnlTestoInterno.Height = 100
	'           pnlTestoInterno.Width = 100
	'       End If
	'   End Sub

	Private Sub cmdStatistiche_Click(sender As Object, e As EventArgs) Handles cmdStatistiche.Click
        frmStatistiche.Show()
    End Sub

    Private Sub pnlTestoInterno_Move(sender As Object, e As MouseEventArgs) Handles pnlTestoInterno.MouseDown
        If pnlImmagineArtista.Visible Then
            _mousedownTI = True
            _mouseposTI = New Point(e.X, e.Y)
        End If
    End Sub

    Private Sub pnlTestoInterno_MouseMove(sender As Object, e As MouseEventArgs) Handles pnlTestoInterno.MouseMove
        If pnlImmagineArtista.Visible Then
            If _mousedownTI Then
                pnlTestoInterno.Location = PointToClient(pnlTestoInterno.PointToScreen(New Point(e.X -
                _mouseposTI.X, e.Y - _mouseposTI.Y)))
            End If
        End If
    End Sub

    Private Sub pnlTestoInterno_MouseLeave(sender As Object, e As EventArgs) Handles pnlTestoInterno.MouseLeave
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub pnlTestoInterno_MouseUp(sender As Object, e As MouseEventArgs) Handles pnlTestoInterno.MouseUp
        If pnlImmagineArtista.Visible Then
            Dim Pos As String = pnlTestoInterno.Top.ToString & ";" & pnlTestoInterno.Left.ToString & ";"
            PosizioneTI = Pos
            SaveSetting("MP3Tag", "Impostazioni", "PosTestoInterno", Pos)
            _mousedownTI = False
        End If
    End Sub

    Private sizePnlMembri As Integer

    Private Sub AggiungeScritteMembriPannello(Altezza As Integer, Cosa As String)
        Dim l As New Label
        l.Left = 2
        l.BackColor = Color.Transparent
        l.Top = Altezza
        l.Font = New Font("Arial", 8)
        l.AutoSize = True

        l.Text &= Cosa & vbCrLf

        pnlMembriInterno.Controls.Add(l)

        If sizePnlMembri < l.Width + 10 Then
            sizePnlMembri = l.Width + 10
        End If
        pnlMembriInterno.Height = Altezza + 20
        pnlMembriInterno.Width = sizepnlmembri
    End Sub

    Private Sub ScriveMembri()
        Dim Passo As Integer = 15
        Dim Altezza As Integer = 2
        Dim trattino As String
        Dim t1 As Boolean
        Dim t2 As Boolean

        sizePnlMembri = 0

        pnlMembriInterno.Controls.Clear()
        pnlMembriInterno.Width = 0
        pnlMembriInterno.Height = 0

        If Membri <> "" Then
            Dim c() As String = Membri.Split("§")

            AggiungeScritteMembriPannello(Altezza, "Membri gruppo " & lstArtista.text & ":")
            Altezza += Passo
            AggiungeScritteMembriPannello(Altezza, "")
            Altezza += Passo

            For Each memb As String In c
                If memb <> "" Then
                    Dim cc() As String = memb.Split(";")

                    If cc(2) = "S" Then
                        If cc(1) <> "" Then
                            trattino = " - " : t1 = False : t2 = False
                            If Mid(cc(1).Trim, 1, 1) = "-" Then trattino = "" : t1 = True
                            If Mid(cc(0).Trim, cc(0).Trim.Length, 1) = "-" Then trattino = "" : t2 = True
                            If t1 And t2 Then
                                cc(1) = Mid(cc(1).Trim, 2, cc(1).Length)
                            End If

                            AggiungeScritteMembriPannello(Altezza, "Attuale: " & cc(0) & trattino & cc(1))
                        Else
                            AggiungeScritteMembriPannello(Altezza, "Attuale: " & cc(0))
                        End If
                    Else
                        If cc(1) <> "" Then
                            trattino = " - " : t1 = False : t2 = False
                            If Mid(cc(1).Trim, 1, 1) = "-" Then trattino = "" : t1 = True
                            If Mid(cc(0).Trim, cc(0).Trim.Length, 1) = "-" Then trattino = "" : t2 = True
                            If t1 And t2 Then
                                cc(1) = Mid(cc(1).Trim, 2, cc(1).Length)
                            End If

                            AggiungeScritteMembriPannello(Altezza, "Passato: " & cc(0) & trattino & cc(1))
                        Else
                            AggiungeScritteMembriPannello(Altezza, "Passato: " & cc(0))
                        End If
                    End If
                    Altezza += Passo
                End If
            Next
        Else
            AggiungeScritteMembriPannello(Altezza, "Membri " & lstArtista.Text & ":")
            Altezza += Passo
            AggiungeScritteMembriPannello(Altezza, "")
            Altezza += Passo
            AggiungeScritteMembriPannello(Altezza, "Sconosciuti")
            Altezza += Passo
        End If
    End Sub

    Private Sub cmdVisualizzaMembri_Click(sender As Object, e As EventArgs) Handles cmdVisualizzaMembri.Click
        If pnlImmagineArtista.Visible Then
            If pnlMembriInterno.Visible Then
                pnlMembriInterno.Visible = False
                SaveSetting("MP3Tag", "Impostazioni", "Membri", False)
            Else
                pnlMembriInterno.Visible = True
                SaveSetting("MP3Tag", "Impostazioni", "Membri", True)
                pnlMembriInterno.Left = 5
                pnlMembriInterno.Top = lblNomeArtistaImm.top + lblNomeArtistaImm.Height + 1
                ScriveMembri()
            End If
        End If
    End Sub

    Private Sub cmdRicaricaMembri_Click(sender As Object, e As EventArgs) Handles cmdRicaricaMembri.Click
        Dim g As New getLyricsMP3_NEW
        g.PrendeMembriBand(lstArtista.Text, True)
        g = Nothing

        ScriveMembri()
    End Sub

    Private Sub pnlMembriInterno_MouseDown(sender As Object, e As MouseEventArgs) Handles pnlMembriInterno.MouseDown
        If pnlImmagineArtista.Visible Then
            _mousedownWMP = True
            _mouseposWMP = New Point(e.X, e.Y)
        End If
    End Sub

    Private Sub pnlMembriInterno_MouseMove(sender As Object, e As MouseEventArgs) Handles pnlMembriInterno.MouseMove
        If pnlImmagineArtista.Visible Then
            If _mousedownWMP Then
                pnlMembriInterno.Location = PointToClient(pnlMembriInterno.PointToScreen(New Point(e.X -
                _mouseposWMP.X, e.Y - _mouseposWMP.Y)))
            End If
        End If
    End Sub

    Private Sub pnlMembriInterno_MouseUp(sender As Object, e As MouseEventArgs) Handles pnlMembriInterno.MouseUp
        If pnlImmagineArtista.Visible Then
            _mousedownWMP = False
        End If
    End Sub

    Private Sub pnlStelleInterno_MouseDown(sender As Object, e As MouseEventArgs) Handles pnlStelleInterno.MouseDown, picStelle1Interno.MouseDown, picStelle2Interno.MouseDown _
        , picStelle3Interno.MouseDown, picStelle4Interno.MouseDown, picStelle5Interno.MouseDown, picStelle6Interno.MouseDown, picStelle7Interno.MouseDown
        If pnlImmagineArtista.Visible Then
            _mousedownWMP = True
            _mouseposWMP = New Point(e.X, e.Y)
        End If
    End Sub

    Private Sub pnlStelleInterno_MouseMove(sender As Object, e As MouseEventArgs) Handles pnlStelleInterno.MouseMove, picStelle1Interno.MouseMove, picStelle2Interno.MouseMove _
        , picStelle3Interno.MouseMove, picStelle4Interno.MouseMove, picStelle5Interno.MouseMove, picStelle6Interno.MouseMove, picStelle7Interno.MouseMove
        If pnlImmagineArtista.Visible Then
            If _mousedownWMP Then
                pnlStelleInterno.Location = PointToClient(pnlStelleInterno.PointToScreen(New Point(e.X -
                _mouseposWMP.X, e.Y - _mouseposWMP.Y)))
            End If
        End If
    End Sub

    Private Sub pnlStelleInterno_MouseUp(sender As Object, e As MouseEventArgs) Handles pnlStelleInterno.MouseUp, picStelle1Interno.MouseUp, picStelle2Interno.MouseUp _
        , picStelle3Interno.MouseUp, picStelle4Interno.MouseUp, picStelle5Interno.MouseUp, picStelle6Interno.MouseUp, picStelle7Interno.MouseUp
        If pnlImmagineArtista.Visible Then
            _mousedownWMP = False
        End If
    End Sub

End Class