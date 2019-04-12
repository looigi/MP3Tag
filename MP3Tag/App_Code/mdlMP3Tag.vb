Imports System.IO

Module mdlMP3Tag
    Public TipoCollegamento As String
    Public Utenza As String
    Public Password As String
    Public Dominio As String
    Public Contatore As Integer
    Public pics(50) As PictureBox
    Public picsArtista() As PictureBox
    Public qImmaginiBox As Integer
    Public qImmaginiArtistaBox As Integer
    Public PathDB As String
    Public ChiusuraWikipediaNONTramiteTasto As Boolean
    Public DimeImmMP3() As String
    Public DimeImmArtista() As Integer
    Public QualeEffettoImmagine As Integer = -1
    Public Rotazione As Integer
    Public PassoEffettoX As Integer = 5
    Public PassoEffettoY As Integer = 5
    Public ContaEffetto As Integer
    Public VecchioNomeImmagine As String
    Public inPausa As Boolean = False
    'Public QualeAudioStaSuonando As Integer
    Public Const TempoFade As Integer = 6
    Public StaVisualizzandoImmagineArtista As Boolean = False
    Public ImmagineVisualizzata As Bitmap
    Public Rotaz As Single = -1
    Public PassRotaz As Single = -1
    Public QuantiPassi As Integer = -1
    Public Passo As Integer
    Public FattaRotazione As Boolean
    Public DimePicMinX As Integer
    Public DimePicMinY As Integer
    Public DimePicMaxX As Integer
    Public DimePicMaxY As Integer
    Public PosMinX As Integer
    Public PosMinY As Integer
    Public PosMaxX As Integer
    Public PosMaxY As Integer
    Public QualeCanzoneDeveSuonare As Integer

    Public idCanzone As Integer
    Public Testo As String
    Public TestoTradotto As String
    Public Bellezza As Integer

    Public StrutturaDati As StrutturaCampivb

    Public YouTubeClass As YouTube
    Public YouTubeMostrato As Boolean
    Public ScaricaVideoSubito As String
    Public DimeWMP As Single

    Public pPicSost As PictureBox
    Public PosizioneMP As String
    Public PosizioneTI As String

    Public HaGiaScrittoAscoltataSulDB As Boolean = True

    Public Membri As String
    Public ValoriDaScrivere() As String
    Public qValoriDaScrivere As Integer

    Public Function StaSuonando() As Boolean
        Dim bStaSuonando As Boolean

        If frmPlayer.audioCorrente1 Is Nothing Then
            bStaSuonando = False
        Else
            If frmPlayer.audioCorrente1.playState = WMPLib.WMPPlayState.wmppsPlaying Then
                bStaSuonando = True
            Else
                bStaSuonando = False
            End If
        End If

        Return bStaSuonando
    End Function

    Public Function ControllaSeEStataSalvataUnaImmagine(Immagine As String) As Boolean
        Dim Ok As Boolean = False

        Dim DB As New SQLSERVERCE
        Dim conn As Object = CreateObject("ADODB.Connection")
        Dim rec As Object = CreateObject("ADODB.Recordset")
        Dim Sql As String
        Dim r As New RoutineVarie
        DB.ImpostaNomeDB(PathDB)
        DB.LeggeImpostazioniDiBase()
        conn = DB.ApreDB()

        Sql = "Select * From ImmaginiSalvate Where Immagine='" & r.SistemaTestoPerDB(Immagine) & "'"
        rec = DB.LeggeQuery(conn, Sql)
        If Not rec.eof Then
            Ok = True
        End If
        rec.close()

        Return Ok
    End Function

    Public Sub ScriveImmagineSalvataSuDB(Immagine As String)
        Dim DB As New SQLSERVERCE
        Dim conn As Object = CreateObject("ADODB.Connection")
        Dim Sql As String
        Dim r As New RoutineVarie
        DB.ImpostaNomeDB(PathDB)
        DB.LeggeImpostazioniDiBase()
        conn = DB.ApreDB()

        Sql = "Insert Into ImmaginiSalvate Values ('" & r.SistemaTestoPerDB(Immagine) & "')"
        DB.EsegueSql(conn, Sql)
    End Sub

    Public Sub PrendeVideo(Player As AxWMPLib.AxWindowsMediaPlayer, sArtista As String, sAlbum As String, sCanzone As String)
        'If YouTubeMostrato Then
        Player.URL = ""

        Dim artista As String = sArtista
        Dim album As String = sAlbum
        If Mid(album, 5, 1) <> "-" Then
            album = "0000-" & album
        End If
        Dim canzone As String = sCanzone
        If Mid(canzone, 3, 1) <> "-" Then
            canzone = "00-" & canzone
        End If

        If Not YouTubeClass Is Nothing Then
            YouTubeClass.PrendeVideo(artista, album, canzone)
        End If
        'End If
    End Sub

    Public Function ControllaNomeFisico(NomeCanzone As String, lstCanzone As String, lstAlbum As String) As String
        Dim NomeCanzoneRitorno As String = ""
        Dim gf As New GestioneFilesDirectory

        If File.Exists(StrutturaDati.PathMP3 & "\" & NomeCanzone) = False Then
            Dim c As String = lstCanzone
            Dim a As String = lstAlbum

            If c.IndexOf("-") > -1 Then
                If IsNumeric(Mid(c, 1, c.IndexOf("-") - 1)) = True Then
                    c = Mid(c, c.IndexOf("-") + 2, c.Length)
                End If
            End If
            c = c.Replace(gf.TornaEstensioneFileDaPath(c), "")
            If a.IndexOf("-") > -1 Then
                If IsNumeric(Mid(a, 1, a.IndexOf("-") - 1)) = True Then
                    a = Mid(a, a.IndexOf("-") + 2, a.Length)
                End If
            End If

            For i As Integer = 1 To StrutturaDati.qCanzoni
                If StrutturaDati.Canzoni(i).IndexOf(c) > -1 And StrutturaDati.Canzoni(i).IndexOf(a) > -1 Then
                    NomeCanzoneRitorno = StrutturaDati.Canzoni(i)
                    NomeCanzoneRitorno = NomeCanzoneRitorno.Replace(StrutturaDati.PathMP3 & "\", "")
                    NomeCanzoneRitorno = NomeCanzoneRitorno.Replace("'", "''")
                    Exit For
                End If
            Next
        End If
        If NomeCanzoneRitorno = "" Then
            NomeCanzoneRitorno = NomeCanzone
        End If

        Return NomeCanzoneRitorno
    End Function

    Public Sub EliminaCartelleVuote(FiltroRicerca As String, lblAvanzamento As Label, lblAvanzamentoFile As Label)
        Dim gf As New GestioneFilesDirectory

        gf.ScansionaDirectorySingola(StrutturaDati.PathMP3, "")
        Dim Cartelle() As String = gf.RitornaDirectoryRilevate
        Dim qCartelle As Integer = gf.RitornaQuanteDirectoryRilevate
        Dim Appoggio As String = ""

        For i As Integer = 1 To qCartelle
            For k As Integer = i + 1 To qCartelle
                If Cartelle(i).Length < Cartelle(k).Length Then
                    Appoggio = Cartelle(i)
                    Cartelle(i) = Cartelle(k)
                    Cartelle(k) = Appoggio
                End If
            Next
        Next

        Dim Files() As String
        Dim Este As String
        Dim Ok As Boolean
        Dim CiSonoMP3 As Boolean

        For i As Integer = 1 To qCartelle
            lblAvanzamento.Text = "Controllo " & Cartelle(i).Replace(StrutturaDati.PathMP3 & "\", "") & " " & i & "/" & qCartelle
            Application.DoEvents()

            Dim c As String = Cartelle(i)
            'If c.ToUpper.Contains("\ELIO") Then Stop

            If c.IndexOf("ImmaginiArtista") = -1 And Not c.ToUpper.Contains("YOUTUBE") Then
                'Per avere informazioni sui file
                'Files = Directory.GetDirectories(c)
                'If Files.Length > 0 Then
                Files = Directory.GetFiles(c)
                If Files.Length > 0 Then
                    Ok = True
                    CiSonoMP3 = False
                    For k As Integer = 0 To Files.Length - 1
                        If Not CiSonoMP3 And Files(k).ToUpper.Contains(".MP3") Or Files(k).ToUpper.Contains(".WMA") Then
                            CiSonoMP3 = True
                            Ok = False
                            ' Exit For
                        Else
                            If Files(k).Contains("Thumbs.db") Then
                                File.SetAttributes(Files(k), FileAttributes.Normal)
                                Try
                                    Kill(Files(k))
                                Catch ex As Exception
                                    'Stop
                                End Try
                            End If
                        End If
                    Next
                    If Not CiSonoMP3 Then
                        For k As Integer = 0 To Files.Length - 1
                            'If Files(k).IndexOf("Cover_") = -1 Then
                            Este = gf.TornaEstensioneFileDaPath(Files(k)).ToUpper.Trim
                            If Este = ".JPG" Or Este = ".JPEG" Or Files(k).ToUpper.Contains("DESKTOP.") Or Files(k).ToUpper.Contains("THUMBS.") Then
                                lblAvanzamentoFile.Text = Files(k).Replace(StrutturaDati.PathMP3 & "\", "")
                                Application.DoEvents()

                                File.SetAttributes(Files(k), FileAttributes.Normal)
                                Try
                                    Kill(Files(k))
                                Catch ex As Exception
                                    'Stop
                                End Try
                            End If
                            'Else
                            '    'If Files.Length = 1 Then
                            '    'If Files(0).IndexOf("Cover_") > -1 Then
                            '    File.SetAttributes(Files(0), FileAttributes.Normal)
                            '            Try
                            '                Kill(Files(0))
                            '            Catch ex As Exception
                            '                'Stop
                            '            End Try
                            '        End If
                            ''End If
                            ''End If
                        Next
                    End If
                    If Not CiSonoMP3 And Not c.ToUpper.Contains("YOUTUBE") And Not c.ToUpper.Contains("IMMAGINIARTISTA") Then
                        'Stop
                        EliminaCartella(c)
                    End If
                    'If Ok = True Then
                    '    Try
                    '        RmDir(c)
                    '    Catch ex As Exception

                    '    End Try
                    'End If
                Else
                    ' Nessun file nella cartella
                    'Stop
                    EliminaCartella(c)
                End If
                'Else
                '    ' Nessuna cartella nella cartella
                '    Stop
                'End If
            End If
        Next
    End Sub

    Private Sub EliminaCartella(Cartella As String)
        Dim gf As New GestioneFilesDirectory
        gf.ScansionaDirectorySingola(Cartella)
        Dim filetti() = gf.RitornaFilesRilevati
        Dim qFiletti As Integer = gf.RitornaQuantiFilesRilevati
        Dim cartellette() = gf.RitornaDirectoryRilevate
        Dim qCartellette As Integer = gf.RitornaQuanteDirectoryRilevate
        Dim appoggio As String
        Dim nonEliminare As Boolean = False

        For i As Integer = 1 To qFiletti
            If filetti(i) <> "" Then
                If filetti(i).ToUpper.Contains(".MP3") Or filetti(i).ToUpper.Contains(".WMA") Then
                    nonEliminare = True
                    Exit For
                End If
            End If
        Next

        If Not nonEliminare Then
            For i As Integer = 1 To qFiletti
                If filetti(i) <> "" Then
                    File.Delete(filetti(i))
                End If
            Next

            For i As Integer = 1 To qCartellette
                For k As Integer = 1 To qCartellette
                    If cartellette(i) > cartellette(k) Then
                        appoggio = cartellette(i)
                        cartellette(i) = cartellette(k)
                        cartellette(k) = appoggio
                    End If
                Next
            Next

            Dim ancora As Boolean = True

            While ancora
                ancora = False
                For i As Integer = 1 To qCartellette
                    Try
                        RmDir(cartellette(i))
                    Catch ex As Exception
                        '                        If Not ex.Message.Contains(
                        If File.Exists(cartellette(i) & "\Thumbs.db") Then
                            File.Delete(cartellette(i) & "\Thumbs.db")
                        End If
                        If File.Exists(cartellette(i) & "\desktop.ini") Then
                            File.Delete(cartellette(i) & "\desktop.ini")
                        End If
                        ancora = True
                    End Try
                Next
            End While
        End If

        gf = Nothing
    End Sub

    Public Function GetDuration(ByVal MovieFullPath As String) As String
        If File.Exists(MovieFullPath) Then
            Dim objShell As Object = CreateObject("Shell.Application")
            Dim objFolder As Object = _
               objShell.Namespace(Path.GetDirectoryName(MovieFullPath))
            For Each strFileName In objFolder.Items
                If strFileName.Name = Path.GetFileName(MovieFullPath) Then
                    Dim Ritorno As String

                    Ritorno = objFolder.GetDetailsOf(strFileName, 21).ToString
                    If Ritorno = "" Then
                        Ritorno = objFolder.GetDetailsOf(strFileName, 36).ToString
                        If Ritorno = "" Then
                            Ritorno = objFolder.GetDetailsOf(strFileName, 27).ToString
                            If Ritorno = "" Then
                                Ritorno = objFolder.GetDetailsOf(strFileName, 28).ToString
                            End If
                        End If
                    End If

                    Return Ritorno
                    Exit For
                    Exit Function
                End If
            Next
            Return ""
        Else
            Return ""
        End If
    End Function

    Public Sub AggiungePictureBox(Player1 As AxWMPLib.AxWindowsMediaPlayer, s As String)
        pPicSost = New PictureBox

        AdattaPictureBox()

        pPicSost.BackgroundImageLayout = ImageLayout.Stretch
        pPicSost.BorderStyle = BorderStyle.FixedSingle
        pPicSost.Visible = True

        Player1.Controls.Clear()
        Player1.Controls.Add(pPicSost)

        Dim imageRes As Image = Nothing

        Select Case s
            Case "Immagini/convert.png"
                imageRes = My.Resources.convert
            Case "Immagini/erroreVideo.png"
                imageRes = My.Resources.erroreVideo
            Case "Immagini/loadVideo.png", "Immagini/pleaseWait.jpg", "Immagini/wait.jpg"
                imageRes = My.Resources.pleaseWait
            Case "Immagini/noVideo.png"
                imageRes = My.Resources.noVideo
        End Select

        If s = "" Then
            pPicSost.BackgroundImage = Nothing
        Else
            pPicSost.BackgroundImage = imageRes ' Image.FromFile(s)
        End If
        pPicSost.BringToFront()
        pPicSost.Refresh()

        Player1.URL = ""
        Player1.Refresh()
    End Sub

    Public Sub AdattaPictureBox()
        If Not pPicSost Is Nothing Then
            If StrutturaDati.pnlImmagineArtista.Visible Then
                pPicSost.Left = 0
                pPicSost.Top = 0
                pPicSost.Height = StrutturaDati.AxWindowsMediaPlayer1.Height '- 2
                pPicSost.Width = StrutturaDati.AxWindowsMediaPlayer1.Width
            Else
                pPicSost.Left = 0 '  StrutturaDati.pnlImmagine.Left '- 2
                pPicSost.Top = 35
                pPicSost.Height = StrutturaDati.pnlBarra.Top - 80
                pPicSost.Width = StrutturaDati.AxWindowsMediaPlayer1.Width
            End If

            pPicSost.BackgroundImageLayout = ImageLayout.Stretch
        End If
    End Sub

    Public Sub SalvaCanzoneAscoltata()
        Dim DB As SQLSERVERCE
        Dim conn As Object = CreateObject("ADODB.Connection")
        Dim Rec As Object = CreateObject("ADODB.Recordset")
        Dim Sql As String = ""
        DB = New SQLSERVERCE
        DB.ImpostaNomeDB(PathDB)
        DB.LeggeImpostazioniDiBase()
        conn = DB.ApreDB()

        Dim a As String = Now.Year.ToString
        Dim m As String = Now.Month.ToString
        Dim g As String = Now.Day.ToString
        Dim h As String = Now.Hour.ToString
        Dim mm As String = Now.Minute.ToString
        Dim s As String = Now.Second.ToString

        If m.Length = 1 Then m = "0" & m
        If g.Length = 1 Then g = "0" & g
        If h.Length = 1 Then h = "0" & h
        If mm.Length = 1 Then mm = "0" & mm
        If s.Length = 1 Then s = "0" & s

        Dim DataOra As String = a & "-" & m & "-" & g & " " & h & ":" & mm & ":" & s

        Sql = "Insert Into Ascoltate Values (" & idCanzone & ", '" & DataOra & "')"
        DB.EsegueSql(conn, Sql)

        conn.Close()
        DB = Nothing

        HaGiaScrittoAscoltataSulDB = True
    End Sub

End Module
