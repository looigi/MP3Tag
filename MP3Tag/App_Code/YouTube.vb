Imports System.IO
Imports System.Net
Imports System.Text.RegularExpressions
Imports System.Threading
Imports Thumbnailer

Public Class YouTube
    Private QualeVideo As Integer
    Private qNomiYouTube As Integer
    Private NomiYouTube() As String
    Private Player1 As AxWMPLib.AxWindowsMediaPlayer
    Private chkVideo As CheckBox
    Private Artista As String
    Private Album As String
    Private PercorsoVideo As String
    Private Canzone As String
    Private NomeCartellaTemporanea As String = "VideoYouTube"
    Private trdYouTube As Thread
    Private VideoCaricato As Boolean
    Private picLucchetto As PictureBox
    Private Player11 As AxWMPLib.AxWindowsMediaPlayer
    Private bAvanti As PictureBox
    Private bIndietro As PictureBox
    Private pSalva As PictureBox
    Private pSuGiu As PictureBox
    Private pElimina As PictureBox
    Private lblTestiThread As Label
    Private instance As Form
    Private player As WMPLib.WindowsMediaPlayer
    Private LastNomeVideo As String
    Private tmrTP As System.Windows.Forms.Timer
    Private WithEvents myThumbnailer As ThumbnailGenerator
    Private pTemp As String
    Private pImmagini As String

    Private Delegate Sub DelegateAttivaTimerPT(ByVal enabled As Boolean)
    Private MethodDelegateAttivaTimerTP As New DelegateAttivaTimerPT(AddressOf AttivaTimerTP)

    Private Delegate Sub DelegateAddTextTesti(ByVal str As String)
    Private MethodDelegateAddTextTesti As New DelegateAddTextTesti(AddressOf AddTextTesti)

    Private Delegate Function DelegateStaSuonando() As Boolean
    Private MethodDelegateStaSuonando As New DelegateStaSuonando(AddressOf AudioStaSuonando)

    Private Delegate Sub DelegatePlay()
    Private MethodDelegatePlay As New DelegatePlay(AddressOf playPlayer)

    Private Delegate Sub DelegateStopy()
    Private MethodDelegateStop As New DelegatePlay(AddressOf stopPlayer)

    Private Delegate Sub DelegatePicSostituzione(ByVal enabled As Boolean)
    Private MethodDelegatePicSostituzione As New DelegatePicSostituzione(AddressOf EnableDisablePicSostituzione)

    Private Delegate Sub DelegateCambiaPS(ByVal i As String)
    Private MethodDelegateCambiaPS As New DelegateCambiaPS(AddressOf CambiaImmPS)

    Private Delegate Sub DelegateAbilitaPannello(enabled As Boolean)
    Private MethodDelegateAbilitaPannello As New DelegateAbilitaPannello(AddressOf AbilitaPannello)

    Private Delegate Sub DelegateAbilitaAvantiIndietro(enabled As Boolean)
    Private MethodDelegateAbilitaAvantiIndietro As New DelegateAbilitaAvantiIndietro(AddressOf AbilitaAvantiIndietro)

    Private Delegate Sub DelegateAbilitaSalva(enabled As Boolean)
    Private MethodDelegateAbilitaSalva As New DelegateAbilitaSalva(AddressOf AbilitaSalva)

    Private Delegate Sub DelegateAbilitaSuGiu(enabled As Boolean)
    Private MethodDelegateAbilitaSuGiu As New DelegateAbilitaSuGiu(AddressOf AbilitaSuGiu)

    Private Delegate Sub DelegateAbilitaElimina(enabled As Boolean)
    Private MethodDelegateAbilitaElimina As New DelegateAbilitaElimina(AddressOf AbilitaElimina)

    Private Delegate Sub DelegateAbilitaLucchetto(enabled As Boolean)
    Private MethodDelegateAbilitaLucchetto As New DelegateAbilitaLucchetto(AddressOf AbilitaLucchetto)

    Private Sub AttivaTimerTP(enabled As Boolean)
        tmrTP.enabled = True
    End Sub

    Private Sub AbilitaLucchetto(enabled As Boolean)
        picLucchetto.Visible = enabled
    End Sub

    Private Sub AbilitaSalva(enabled As Boolean)
        pSalva.Visible = enabled
    End Sub

    Private Sub AbilitaSuGiu(enabled As Boolean)
        pSuGiu.Visible = enabled
    End Sub

    Private Sub AbilitaElimina(enabled As Boolean)
        pElimina.Visible = enabled
    End Sub

    Private Sub AbilitaAvantiIndietro(enabled As Boolean)
        bAvanti.Visible = enabled
        bIndietro.Visible = enabled
    End Sub

    Private Sub AbilitaPannello(enabled As Boolean)
        StrutturaDati.pnlMediaPlayer.Visible = enabled
        StrutturaDati.pnlMediaPlayer.Enabled = enabled
    End Sub

    Private Sub playPlayer()
        Player11.Ctlcontrols.play()
    End Sub

    Private Sub stopPlayer()
        Player11.Ctlcontrols.pause()
    End Sub

    Private Function AudioStaSuonando()
        If player Is Nothing Then
            Return False
        Else
            If player.playState = WMPLib.WMPPlayState.wmppsPlaying Then
                Return True
            Else
                Return False
            End If
        End If
    End Function

    Private Sub CambiaImmPS(ByVal s As String)
        AggiungePictureBox(Player1, s)
    End Sub

    Private Sub EnableDisablePicSostituzione(ByVal enabled As Boolean)
        'pPicSost = New PictureBox
        'pPicSost.Left = 0 ' Player1.Left
        'pPicSost.Top = 0 'Player1.Top
        'pPicSost.Width = Player1.Width
        'pPicSost.Height = Player1.Height
        'pPicSost.Visible = enabled

        'Player1.Controls.Add(pPicSost)
    End Sub

    'Private Sub EnableDisableButton(ByVal enabled As Boolean)
    'bAvanti.Enabled = enabled
    'bIndietro.Enabled = enabled
    'End Sub

    Private Sub AddTextTesti(ByVal str As String)
        lblTestiThread.Text = str
    End Sub

    Public Sub New(fInstance As Form, p1 As AxWMPLib.AxWindowsMediaPlayer, c As CheckBox, _
                   llblNomeVideo As Label, bAva As PictureBox, bInd As PictureBox, _
                   pS As PictureBox, pSG As PictureBox, pE As PictureBox)
        Player1 = p1
        Player11 = p1
        chkVideo = c
        pSalva = pS
        pSuGiu = pSG
        pElimina = pE
        picLucchetto = StrutturaDati.PicNonCercareVideo
        tmrTP = frmPlayer.tmrPrendeThumbs

        lblTestiThread = llblNomeVideo
        instance = fInstance
        bAvanti = bAva
        bIndietro = bInd
        'pPicSost = pPs
    End Sub

    Public Sub PrendeVideo(sArtista As String, sAlbum As String, sCanzone As String)
        Artista = sArtista
        Album = sAlbum
        Canzone = sCanzone
        lblTestiThread.Text = ""
        PercorsoVideo = StrutturaDati.PathMP3 & "\" & Artista & "\" & Album & "\" & NomeCartellaTemporanea

        Dim gf As New GestioneFilesDirectory
        gf.CreaDirectoryDaPercorso(PercorsoVideo & "\")
        gf = Nothing

        PulisceCartellaDaFilesInutili()

        If YouTubeMostrato Then
            AcquisisceVideo()
        Else
            StrutturaDati.pnlMediaPlayer.Enabled = True
            NomiYouTube = Nothing
            ControllaAperturaChiusuraLucchetto()
        End If
    End Sub

    Public Sub AcquisisceVideo()
        If Artista = "" Then
            Exit Sub
        End If
        If chkVideo.Checked Then
            Dim gf As New GestioneFilesDirectory
            Dim sArtista As String = Artista
            sArtista = sArtista.Replace("%20", "+")
            sArtista = sArtista.Replace(" ", "+")
            If sArtista.Contains("-") Then
                sArtista = Mid(sArtista, sArtista.IndexOf("-") + 1, sArtista.Length)
            End If

            Dim sCanzone As String = Canzone
            sCanzone = sCanzone.Replace("%20", "+")
            sCanzone = sCanzone.Replace(" ", "+")
            If sCanzone.Contains("-") Then
                sCanzone = Mid(sCanzone, sCanzone.IndexOf("-") + 2, sCanzone.Length)
            End If
            If sCanzone <> "" Then
                sCanzone = sCanzone.Replace(gf.TornaEstensioneFileDaPath(sCanzone), "")

                If sCanzone.Contains("(") Then
                    sCanzone = Mid(sCanzone, 1, sCanzone.IndexOf("("))
                End If

                Dim StringaRicercaVideo As String = "https://www.google.it/search?q=" & sArtista & "+" & sCanzone & "&newwindow=1&source=lnms&tbm=vid&sa=X&ved=0ahUKEwiEv9Ki8prXAhVBuBQKHZmUCWIQ_AUICigB&biw=1920&bih=949"

                Dim gd As New Download
                Dim sNomeFile As String = Application.StartupPath & "\" & NomeCartellaTemporanea & "\Download_" & Now.Second & ".htm"
                Dim sCartella As String = Application.StartupPath & "\" & NomeCartellaTemporanea & "\"

                gf.CreaDirectoryDaPercorso(sCartella)

                gd.ImpostaValori(Nothing, Nothing, Nothing, Nothing, sNomeFile)
                Dim Ok As Boolean = gd.ScaricaPagina(StringaRicercaVideo)

                QualeVideo = -1
                If Ok Then
                    Dim Righe As String = gf.LeggeFileIntero(sNomeFile)
                    Dim a1 As Long
                    Dim Nomi As String = ""
                    Dim StringaDaRicercare As String = "https://img.youtube.com/vi/"
                    Dim Nome As String
                    qNomiYouTube = 0
                    Erase NomiYouTube

                    a1 = Righe.IndexOf(StringaDaRicercare)
                    While a1 > -1
                        Nome = Mid(Righe, a1 + StringaDaRicercare.Length + 1, Righe.Length)
                        Nome = Mid(Nome, 1, Nome.IndexOf("/"))

                        qNomiYouTube += 1
                        ReDim Preserve NomiYouTube(qNomiYouTube)
                        NomiYouTube(qNomiYouTube) = Nome
                        If QualeVideo = -1 Then
                            QualeVideo = 1
                        End If

                        Nomi &= Nome & "§"

                        Righe = Mid(Righe, a1 + StringaDaRicercare.Length + 1, Righe.Length)
                        a1 = Righe.IndexOf(StringaDaRicercare)
                    End While

                    Try
                        File.Delete(sNomeFile)
                    Catch ex As Exception

                    End Try
                End If

                If QualeVideo > -1 Then
                    StrutturaDati.pnlMediaPlayer.Visible = True
                    CaricaVideo()
                Else
                    AggiungePictureBox(Player1, "Immagini/erroreVideo.png")
                    StrutturaDati.pnlMediaPlayer.Visible = False
                End If
            End If
        End If
    End Sub

    Public Sub AvanzaVideo()
        QualeVideo += 1
        If QualeVideo > qNomiYouTube Then
            QualeVideo = 1
        End If

        CaricaVideo()
    End Sub

    Public Sub IndietreggiaVideo()
        QualeVideo -= 1
        If QualeVideo < 1 Then
            QualeVideo = qNomiYouTube
        End If

        CaricaVideo()
    End Sub

    Private Function CercaNomeVideo(VideoID As String) As String
        Dim NomeVideo As String = ""

        If Directory.Exists(PercorsoVideo) Then
            Dim gf As New GestioneFilesDirectory
            gf.CreaDirectoryDaPercorso(PercorsoVideo & "\")
            Dim di As New IO.DirectoryInfo(PercorsoVideo)
            Dim diar1 As IO.FileInfo() = di.GetFiles()
            Dim dra As IO.FileInfo

            For Each dra In diar1
                If dra.FullName.Contains(VideoID) Then
                    If FileLen(dra.FullName) = 0 Then
                        NomeVideo = "***ERASED***"
                    Else
                        NomeVideo = dra.FullName
                    End If
                    Exit For
                End If
            Next
        End If

        Return NomeVideo
    End Function

    Public Sub PlayButton()
        If Not VideoCaricato And Not StaSuonando() Then
            'StaSuonando = True
            CaricaVideo()
        End If

        Dim Ancora As Boolean = True

        Do While Ancora
            Try
                Player1.Ctlcontrols.play()
                Ancora = False
            Catch ex As Exception
                Thread.Sleep(500)
            End Try
        Loop

        'StaSuonando = True
    End Sub

    Public Sub PauseButton()
        Dim Ancora As Boolean = True

        Do While Ancora
            Try
                Player1.Ctlcontrols.pause()
                Ancora = False
            Catch ex As Exception
                Thread.Sleep(500)
            End Try
        Loop

        'StaSuonando = False
    End Sub

    Public Sub StopButton()
        Dim Ancora As Boolean = True

        Do While Ancora
            Try
                Player1.Ctlcontrols.stop()
                'Player1.URL = Application.StartupPath & "\Immagini\noVideo.png"
                Ancora = False
            Catch ex As Exception
                Thread.Sleep(500)
            End Try
        Loop

        'StaSuonando = False
    End Sub

    Private Sub ConverteVideo()
        If instance.InvokeRequired Then
            instance.Invoke(MethodDelegateCambiaPS, "Immagini/wait.jpg")
        End If

        If instance.InvokeRequired Then
            instance.Invoke(MethodDelegateAbilitaAvantiIndietro, False)
            instance.Invoke(MethodDelegateAbilitaLucchetto, False)
        End If

        ControllaAperturaChiusuraLucchetto()

        'If StrutturaDati.VideoLockati Then
        '    Exit Sub
        'End If

        If instance.InvokeRequired Then
            instance.Invoke(MethodDelegateAddTextTesti, "")
            'instance.Invoke(MethodDelegateEnableButton, False)
        Else
            lblTestiThread.Text = ""
            'bAvanti.Enabled = False
            'bIndietro.Enabled = False
        End If

        VideoCaricato = False

        Dim VideoID As String = NomiYouTube(QualeVideo)
        Dim NomeVideo As String = CercaNomeVideo(VideoID)
        Do While NomeVideo = "***ERASED***" Or NomeVideo = ""
            QualeVideo += 1
            If QualeVideo > qNomiYouTube Then
                NomeVideo = ""
                Exit Do
            End If
            VideoID = NomiYouTube(QualeVideo)
            NomeVideo = CercaNomeVideo(VideoID)
        Loop

        If NomeVideo = "" Then
            QualeVideo = 1
            VideoID = NomiYouTube(QualeVideo)
            NomeVideo = CercaNomeVideo(VideoID)
            Do While NomeVideo = "***ERASED***"
                QualeVideo += 1
                If QualeVideo > qNomiYouTube Then
                    NomeVideo = ""
                    Exit Do
                End If
                VideoID = NomiYouTube(QualeVideo)
                NomeVideo = CercaNomeVideo(VideoID)
                If NomeVideo <> "" And NomeVideo <> "***ERASED***" Then
                    Exit Do
                End If
            Loop
        End If

        If QualeVideo > qNomiYouTube Then
            If instance.InvokeRequired Then
                instance.Invoke(MethodDelegateAbilitaPannello, True)
            End If
            If instance.InvokeRequired Then
                instance.Invoke(MethodDelegateCambiaPS, "Immagini/noVideo.png")
            End If

            Exit Sub
        End If

        Dim gf As New GestioneFilesDirectory
        Dim gi As New GestioneImmagini

        Dim Ancora As Boolean = True

        'If instance.InvokeRequired Then
        '    instance.Invoke(MethodDelegateAbilitaLucchetto, False)
        'End If

        If instance.InvokeRequired Then
            instance.Invoke(MethodDelegateCambiaPS, "Immagini/wait.jpg")
        End If

        Dim staSuonando As Boolean

        If instance.InvokeRequired Then
            staSuonando = instance.Invoke(MethodDelegateStaSuonando)
        End If

        If NomeVideo = "" And staSuonando And Not StrutturaDati.VideoLockati Then
            If instance.InvokeRequired Then
                instance.Invoke(MethodDelegateCambiaPS, "Immagini/convert.png")
            End If

            Dim Url As String = "https://www.youtube.com/watch?v=" & VideoID ' & "&vq=hd720"

            Dim info As New ProcessStartInfo()
            info.FileName = Application.StartupPath & "\youtube-dl.exe"
            info.WorkingDirectory = PercorsoVideo
            ' info.Arguments = Url & " -w --id -f worstvideo --format mp4"
            info.Arguments = Url & " -w --id -f worstvideo --format mp4"
            info.WindowStyle = ProcessWindowStyle.Hidden
            info.CreateNoWindow = True

            Dim p As Process = Process.Start(info)
            p.WaitForExit()
            Dim ritorno As Integer = p.ExitCode

            NomeVideo = CercaNomeVideo(VideoID)

            'If NomeVideo <> "" Then
            '    Dim AppoNome As String = NomeVideo
            '    Dim Estensione As String = gf.TornaEstensioneFileDaPath(NomeVideo)
            '    NomeVideo = NomeVideo.Replace(Estensione, "")
            '    NomeVideo = NomeVideo & "_" & QualeVideo.ToString.Trim & Estensione
            '    Try
            '        File.Delete(NomeVideo)
            '    Catch ex As Exception

            '    End Try
            '    Rename(AppoNome, NomeVideo)
            'End If
        End If

        If NomeVideo <> "" Then
            Ancora = True

            If instance.InvokeRequired Then
                instance.Invoke(MethodDelegateCambiaPS, "Immagini/loadVideo.png")
            End If

            Dim c As Integer = 0
            Dim errore As Boolean = False

            Do While Ancora
                Try
                    If Not NomeVideo.ToUpper.Contains(".PART") Then
                        Player1.URL = NomeVideo
                        Player1.uiMode = "none"
                        Player1.stretchToFit = False
                        Player1.settings.volume = 0
                        'Player1.Ctlcontrols.pause()
                        'Player1.Ctlcontrols.currentPosition = 1
                    End If

                    StrutturaDati.NomeVideo = NomeVideo
                    Ancora = False
                Catch ex As Exception
                    c += 1
                    If c > 5 Then
                        errore = True
                        Exit Do
                    End If
                    Thread.Sleep(500)
                    If instance.InvokeRequired Then
                        instance.Invoke(MethodDelegateCambiaPS, "Immagini/erroreVideo.png")
                    End If
                End Try
            Loop

            'Dim ss As Boolean = StaSuonando
            If instance.InvokeRequired Then
                instance.Invoke(MethodDelegateCambiaPS, "")
            End If

            If instance.InvokeRequired Then
                instance.Invoke(MethodDelegatePlay)
            End If

            If Not staSuonando Then
                If instance.InvokeRequired Then
                    instance.Invoke(MethodDelegateStop)
                End If
            End If

            If errore Then
                VideoCaricato = False
            Else
                VideoCaricato = True
            End If
        Else
            Ancora = True
            If instance.InvokeRequired Then
                instance.Invoke(MethodDelegatePicSostituzione, True)
            End If
            If instance.InvokeRequired Then
                instance.Invoke(MethodDelegateCambiaPS, "Immagini/noVideo.png")
            End If
        End If

        If NomeVideo <> "" Then
            Dim dimens As String
            Dim d As Single = (FileLen(NomeVideo) / 1024 / 1024)
            d = Int(d * 100) / 100
            dimens = d.ToString

            If instance.InvokeRequired Then
                instance.Invoke(MethodDelegateAddTextTesti, "Mb. " & dimens & " - V. " & ContaVideoScaricati())
            Else
                lblTestiThread.Text = "Mb. " & dimens & "- V. " & ContaVideoScaricati()
            End If

            If instance.InvokeRequired Then
                instance.Invoke(MethodDelegatePicSostituzione, False)
            End If

            If instance.InvokeRequired Then
                instance.Invoke(MethodDelegateAbilitaSalva, True)
            End If
            If instance.InvokeRequired Then
                instance.Invoke(MethodDelegateAbilitaSuGiu, True)
            End If
            If instance.InvokeRequired Then
                instance.Invoke(MethodDelegateAbilitaElimina, True)
            End If

            If instance.InvokeRequired Then
                instance.Invoke(MethodDelegateAttivaTimerTP, True)
            End If
        Else
            If instance.InvokeRequired Then
                instance.Invoke(MethodDelegateAbilitaSalva, False)
            End If
            If instance.InvokeRequired Then
                instance.Invoke(MethodDelegateAbilitaSuGiu, False)
            End If
            If instance.InvokeRequired Then
                instance.Invoke(MethodDelegateAbilitaElimina, False)
            End If
        End If

        If instance.InvokeRequired Then
            instance.Invoke(MethodDelegateAbilitaPannello, True)
        End If

        LastNomeVideo = NomeVideo

        trdYouTube = Nothing
    End Sub

    Public Sub PrendeThumb()
        If LastNomeVideo <> "" And tmrTP.Enabled = False Then
            Dim gf As New GestioneFilesDirectory
            Dim PercorsoImmagini As String = PercorsoVideo.Replace(StrutturaDati.PathMP3, "")
            Dim Campi() As String = PercorsoImmagini.Split("\")
            PercorsoImmagini = StrutturaDati.PathMP3 & Campi(0) & "\" & Campi(1) & "\ZZZ-ImmaginiArtista"

            If Not File.Exists(PercorsoImmagini & "\" & gf.TornaNomeFileDaPath(LastNomeVideo).Replace(gf.TornaEstensioneFileDaPath(LastNomeVideo), "") & "_01.dat") Then
                Dim PercorsoTemp As String = Application.StartupPath & "\Appoggio\Buttami\"
                gf.CreaDirectoryDaPercorso(PercorsoTemp)
                gf.CreaDirectoryDaPercorso(PercorsoImmagini)

                PulisceCartellaFilesTemporanei(Mid(PercorsoTemp, 1, PercorsoTemp.Length - 1))

                Try
                    If myThumbnailer Is Nothing Then
                        myThumbnailer = New ThumbnailGenerator
                    End If

                    myThumbnailer.ReportsProgress = False

                    Dim ThumbSize As Size = Size.Empty

                    ThumbSize.Height = CInt(600)
                    ThumbSize.Width = CInt(800)

                    pTemp = PercorsoTemp
                    pImmagini = PercorsoImmagini

                    Dim MyDuration As String = GetDuration(LastNomeVideo)
                    Dim Secondi As Integer = 120

                    ' 00:04:03
                    If MyDuration <> "" Then
                        Dim t() As String = MyDuration.Split(":")
                        Secondi = Val(t(0)) * 60 * 60
                        Secondi += Val(t(1)) * 60
                        Secondi += Val(t(2))
                    End If

                    myThumbnailer.CreateThumbnailsToFile(LastNomeVideo, _
                                                         Mid(PercorsoTemp, 1, PercorsoTemp.Length - 1), _
                                                         TimeSpan.FromSeconds(CInt(10)), _
                                                         TimeSpan.FromSeconds(Secondi), _
                                                         CInt(10), _
                                                         ThumbSize.Width, _
                                                         ThumbSize.Height)

                Catch ex As Exception
                    'MessageBox.Show("An error has occured: " & ex.Message)
                End Try
            End If
        End If
    End Sub

    Private Sub myThumbnailer_ThumbnailCreationFailed(ByVal sender As Object, ByVal e As Thumbnailer.ThumbnailErrorEventArgs) Handles myThumbnailer.ThumbnailCreationFailed
        'MsgBox("Thumbnails Failed to create: " & e.Exception.Message)
    End Sub

    Private Sub myThumbnailer_ThumbnailProgressChanged(ByVal sender As Object, ByVal e As Thumbnailer.ThumbnailProgressEventArgs) Handles myThumbnailer.ThumbnailProgressChanged
    End Sub

    Private Sub myThumbnailer_ThumbnailsCreatedToDisk(ByVal sender As Object, ByVal e As Thumbnailer.ThumbnailsCreatedEventArgs(Of String)) Handles myThumbnailer.ThumbnailsCreatedToDisk
        Dim di As New IO.DirectoryInfo(pTemp)
        Dim diar1 As IO.FileInfo() = di.GetFiles()
        Dim dra As IO.FileInfo
        Dim gf As New GestioneFilesDirectory

        For Each dra In diar1
            Dim nf As String = gf.TornaNomeFileDaPath(dra.FullName).Replace(gf.TornaEstensioneFileDaPath(dra.FullName), "")
            Dim NuovoNome As String = pImmagini & "\" & gf.TornaNomeFileDaPath(LastNomeVideo).Replace(gf.TornaEstensioneFileDaPath(LastNomeVideo), "") & "_" & nf & ".dat"

            File.Copy(dra.FullName, NuovoNome)
            File.Delete(dra.FullName)
        Next
    End Sub

    Private Sub PulisceCartellaFilesTemporanei(Percorso As String)
        Dim di As New IO.DirectoryInfo(Percorso)
        Dim diar1 As IO.FileInfo() = di.GetFiles()
        Dim dra As IO.FileInfo
        Dim gf As New GestioneFilesDirectory

        For Each dra In diar1
            File.Delete(dra.FullName)
        Next
    End Sub

    Private Sub PulisceCartellaDaFilesInutili()
        If Directory.Exists(PercorsoVideo) Then
            Dim di As New IO.DirectoryInfo(PercorsoVideo)
            Dim diar1 As IO.FileInfo() = di.GetFiles()
            Dim dra As IO.FileInfo
            Dim gf As New GestioneFilesDirectory

            For Each dra In diar1
                If dra.FullName.ToUpper.Contains("THUMBS") Then
                    File.Delete(dra.FullName)
                End If
            Next
        End If
    End Sub

    Private Function ContaVideoScaricati() As String
        Dim q1 As Integer = 0
        Dim q2 As Integer = 0
        Dim gf As New GestioneFilesDirectory
        gf.CreaDirectoryDaPercorso(PercorsoVideo & "\")
        Dim di As New IO.DirectoryInfo(PercorsoVideo)
        Dim diar1 As IO.FileInfo() = di.GetFiles()
        Dim dra As IO.FileInfo
        Dim NomeVideo As String = ""

        For Each s As String In NomiYouTube
            If s <> "" Then
                For Each dra In diar1
                    If dra.FullName.Contains(s) Then
                        If FileLen(dra.FullName) = 0 Then
                            q2 += 1
                        Else
                            q1 += 1
                        End If
                    End If
                Next
            End If
        Next

        Return q1.ToString.Trim & " El. " & q2.ToString.Trim
    End Function

    Private Sub ControllaAperturaChiusuraLucchetto()
        Dim DB As New SQLSERVERCE
        Dim conn As Object = CreateObject("ADODB.Connection")
        Dim rec As Object = CreateObject("ADODB.Recordset")
        Dim Sql As String
        Dim r As New RoutineVarie
        DB.ImpostaNomeDB(PathDB)
        DB.LeggeImpostazioniDiBase()
        conn = DB.ApreDB()

        Dim Aperto As Boolean

        Sql = "Select * From PrendeVideo Where idCanzone=" & idCanzone
        rec = DB.LeggeQuery(conn, Sql)
        If rec.eof = False Then
            If rec("PrendeVideo").Value = "S" Then
                Aperto = True
            Else
                Aperto = False
            End If
        Else
            If ScaricaVideoSubito = "S" Then
                Aperto = True
            Else
                Aperto = False
            End If
            Sql = "Insert Into PrendeVideo Values (" & idCanzone & ", '" & ScaricaVideoSubito & "')"
            DB.EsegueSql(conn, Sql)
        End If
        rec.close()

        Dim q As Integer = 0
        Dim di As New IO.DirectoryInfo(PercorsoVideo)
        Dim diar1 As IO.FileInfo()
        Try
            diar1 = di.GetFiles()
        Catch ex As Exception
            diar1 = Nothing
        End Try

        If Not diar1 Is Nothing And Not NomiYouTube Is Nothing Then
            Dim dra As IO.FileInfo

            For Each s As String In NomiYouTube
                For Each dra In diar1
                    If s <> "" Then
                        If dra.FullName.Contains(s) Then
                            'If FileLen(dra.FullName) > 0 Then
                            q += 1
                            'End If
                        End If
                    End If
                Next
            Next
        End If

        If q < qNomiYouTube Then
            If instance.InvokeRequired Then
                instance.Invoke(MethodDelegateAbilitaLucchetto, True)
            End If

            Dim gi As New GestioneImmagini
            If Not Aperto Then
                StrutturaDati.PicNonCercareVideo.BackgroundImage = My.Resources.lucchettoChiuso ' Image.FromFile("Immagini/lucchettoChiuso.png")
                StrutturaDati.VideoLockati = True

                If instance.InvokeRequired Then
                    instance.Invoke(MethodDelegateAbilitaAvantiIndietro, False)
                End If
            Else
                StrutturaDati.PicNonCercareVideo.BackgroundImage = My.Resources.lucchettoAperto ' Image.FromFile("Immagini/lucchettoAperto.png")
                StrutturaDati.VideoLockati = False

                If instance.InvokeRequired Then
                    instance.Invoke(MethodDelegateAbilitaAvantiIndietro, True)
                End If
            End If
        Else
            If instance.InvokeRequired Then
                instance.Invoke(MethodDelegateAbilitaAvantiIndietro, False)
                instance.Invoke(MethodDelegateAbilitaLucchetto, False)
            End If

            StrutturaDati.PicNonCercareVideo.BackgroundImage = My.Resources.lucchettoChiuso ' Image.FromFile("Immagini/lucchettoChiuso.png")
        End If
    End Sub

    Public Sub DisabilitaVideo()
        StrutturaDati.PicNonCercareVideo.BackgroundImage = My.Resources.lucchettoChiuso ' Image.FromFile("Immagini/lucchettoChiuso.png")
        StrutturaDati.VideoLockati = True

        If instance.InvokeRequired Then
            instance.Invoke(MethodDelegateAbilitaElimina, False)
        Else
            pElimina.Visible = False
        End If

        bAvanti.Visible = False
        bIndietro.Visible = False

        Dim DB As New SQLSERVERCE
        Dim conn As Object = CreateObject("ADODB.Connection")
        Dim Sql As String
        Dim r As New RoutineVarie
        DB.ImpostaNomeDB(PathDB)
        DB.LeggeImpostazioniDiBase()
        conn = DB.ApreDB()

        Sql = "Update PrendeVideo Set PrendeVideo='N' Where idCanzone=" & idCanzone
        DB.EsegueSql(conn, Sql)
    End Sub

    Public Sub AbilitaVideo()
        StrutturaDati.PicNonCercareVideo.BackgroundImage = My.Resources.lucchettoAperto ' Image.FromFile("Immagini/lucchettoAperto.png")
        StrutturaDati.VideoLockati = False

        Dim bStaSuonando As Boolean

        If instance.InvokeRequired Then
            bStaSuonando = instance.Invoke(MethodDelegateStaSuonando)
        Else
            bStaSuonando = StaSuonando()
        End If

        If bStaSuonando Then
            If instance.InvokeRequired Then
                instance.Invoke(MethodDelegateAbilitaAvantiIndietro, True)
                If Player1.URL <> "" Then
                    instance.Invoke(MethodDelegateAbilitaElimina, True)
                End If
            Else
                bAvanti.Visible = True
                bIndietro.Visible = True
                If Player1.URL <> "" Then
                    pElimina.Visible = True
                End If
            End If
        End If

        Dim DB As New SQLSERVERCE
        Dim conn As Object = CreateObject("ADODB.Connection")
        Dim Sql As String
        Dim r As New RoutineVarie
        DB.ImpostaNomeDB(PathDB)
        DB.LeggeImpostazioniDiBase()
        conn = DB.ApreDB()

        Sql = "Update PrendeVideo Set PrendeVideo='S' Where idCanzone=" & idCanzone
        DB.EsegueSql(conn, Sql)
    End Sub

    Public Sub CaricaVideo()
        If Not trdYouTube Is Nothing Then
            trdYouTube.Abort()
            trdYouTube = Nothing
        End If

        If NomiYouTube Is Nothing Then
            AcquisisceVideo()
        Else
            player = frmPlayer.audioCorrente1

            trdYouTube = New Thread(AddressOf ConverteVideo)
            trdYouTube.IsBackground = True
            trdYouTube.Start()
        End If
    End Sub
End Class
