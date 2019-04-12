Imports System.IO
Imports System.Threading
Imports System.Drawing.Imaging
Imports System.Drawing.Drawing2D

Public Class PrendeImmagineArtistaThread
    Private gf As New GestioneFilesDirectory
    Private gi As New GestioneImmagini
    Private TimerEsterno As System.Windows.Forms.Timer
    Private TimerSpostaScritta As System.Windows.Forms.Timer
    Private TimerEffettoImmagine As System.Windows.Forms.Timer
    Private picImmagineArtista As PictureBox
    Private lstArtista As ListBox
    Private lstCanzone As ListBox
    Private lblNomeImmArtista As Label
    Private pnlImmagineArtista As Panel
    Private pnlSopra As Panel
    Private pnlSotto As Panel
    Private lblNomeArtistaImm As Label
    Private pnlSpectrum As Panel
    Private cmdEliminaImmagineArtista As Button
    Private cmdSalva As Button
    Private cmdApreCartella As Button
    Private cmdTesto As Button
    Private lblFiltroImpostato As Label
    Private pnlTasti As Panel
    Private pnlStelle As Panel
    Private cmdRefreshTestoInterno As Button
    Private trd As Thread
    Private GiaPresenti() As String
    Private qGiaPresenti As Integer
    Private QualeImmagine As Integer
    Private StaScaricando As Boolean
    Private EsceDalCiclo As Boolean
    Private cmdTraduzione As Button

    Public Sub ImpostaCampi(tmr As System.Windows.Forms.Timer, pic As PictureBox, lst As ListBox, lbl As Label, pnl As Panel,
                            but As Button, pnl2 As Panel, tmrSS As System.Windows.Forms.Timer, tmrEI As System.Windows.Forms.Timer, pso As Panel,
                            psot As Panel, lstC As ListBox, pnlss As Panel, cmdS As Button, cmdT As Button, cmdRTI As Button, pnlS As Panel,
                            cmdTraduz As Button, cmdApre As Button, lblNAI As Label, lblFI As Label)
        TimerEsterno = tmr
        picImmagineArtista = pic
        lstArtista = lst
        lblNomeImmArtista = lbl
        pnlImmagineArtista = pnl
        cmdEliminaImmagineArtista = but
        pnlTasti = pnl2
        cmdTesto = cmdT
        QualeImmagine = -1
        EsceDalCiclo = False
        TimerSpostaScritta = tmrSS
        TimerEffettoImmagine = tmrEI
        pnlSopra = pso
        pnlSotto = psot
        lstCanzone = lstC
        pnlSpectrum = pnlss
        cmdRefreshTestoInterno = cmdRTI
        cmdSalva = cmdS
        pnlStelle = pnlS
        cmdTraduzione = cmdTraduz
        cmdApreCartella = cmdApre
        lblNomeArtistaImm = lblNAI
        lblFiltroImpostato = lblFI

        LeggeImmagini(lstArtista.Text)
    End Sub

    Public Sub EsceFuori()
        EsceDalCiclo = True
    End Sub

    Private Sub LeggeImmagini(lstArtista As String)
        gf.CreaDirectoryDaPercorso(StrutturaDati.PathMP3 & "\" & lstArtista & "\ZZZ-ImmaginiArtista\")
        gf.ScansionaDirectorySingola(StrutturaDati.PathMP3 & "\" & lstArtista & "\ZZZ-ImmaginiArtista\", "*.dat")

        GiaPresenti = gf.RitornaFilesRilevati
        qGiaPresenti = gf.RitornaQuantiFilesRilevati

        Dim g() As String = {}
        Dim q As Integer = 0
        For i As Integer = 1 To qGiaPresenti
            If GiaPresenti(i).ToUpper.IndexOf(".DEL") = -1 Then
                q += 1
                ReDim Preserve g(q)
                g(q) = GiaPresenti(i)
            End If
        Next

        GiaPresenti = g
        qGiaPresenti = q

        If qGiaPresenti > 0 And QualeImmagine = -1 Then
            Randomize()
            QualeImmagine = Int(Rnd(1) * qGiaPresenti)
            If QualeImmagine = 0 Then QualeImmagine = qGiaPresenti
        End If
    End Sub

    Private Sub ScaricaImmagineArtistaInThread()
        StaScaricando = True

        If pnlImmagineArtista.Visible = False Then
            picImmagineArtista.Visible = True
            pnlImmagineArtista.Visible = True
            cmdEliminaImmagineArtista.Visible = False
            cmdSalva.Visible = False
            pnlStelle.Visible = False
            pnlTasti.Visible = False
            lblFiltroImpostato.Visible = False
            cmdTesto.Visible = False
            lblNomeArtistaImm.Visible = False
            cmdTraduzione.Visible = False
            cmdApreCartella.Visible = False
            cmdRefreshTestoInterno.Visible = False
        End If

        'Dim fs As System.IO.FileStream = Nothing
        'fs = New System.IO.FileStream("Immagini\icona_CLOUD_512x512.png", IO.FileMode.Open, IO.FileAccess.Read)

        picImmagineArtista.Image = My.Resources.icona_CLOUD_512x512 ' gi.CaricaImmagineSenzaLockarla("Immagini\icona_CLOUD_512x512.png")
        Dim d As SizeF = My.Resources.icona_CLOUD_512x512.PhysicalDimension
        Dim s As String = d.Width.ToString & "x" & d.Height.ToString ' gi.RitornaDimensioneImmagine("Immagini\icona_CLOUD_512x512.png")
        ReDim DimeImmArtista(2)
        DimeImmArtista(0) = Val(Mid(s, 1, s.IndexOf("x")))
        DimeImmArtista(1) = Val(Mid(s, s.IndexOf("x") + 2, s.Length))

        Dim Ritorno() As String = gi.CentraImmagineNelPannello(pnlImmagineArtista.Width, pnlImmagineArtista.Height, DimeImmArtista(0), DimeImmArtista(1)).Split("x")
        picImmagineArtista.Width = Ritorno(0)
        picImmagineArtista.Height = Ritorno(1)
        picImmagineArtista.Top = (pnlImmagineArtista.Height / 2) - (picImmagineArtista.Height / 2)
        picImmagineArtista.Left = (pnlImmagineArtista.Width / 2) - (picImmagineArtista.Width / 2)
        picImmagineArtista.Visible = True
        TimerEffettoImmagine.Enabled = False
        QualeEffettoImmagine = -1
        ImmagineVisualizzata = Nothing

        CambiaColoreSfondo(False)

        'fs.Close()
        'fs = Nothing

        VecchioNomeImmagine = ""

        picImmagineArtista.Refresh()
        picImmagineArtista.BackColor = Color.Transparent
        Application.DoEvents()
        trd = New Thread(AddressOf ScaricaImmagineArtista)
        trd.IsBackground = True

        Dim Canzone As String = lstCanzone.Text
        If Canzone.IndexOf("-") > -1 Then Canzone = Mid(Canzone, Canzone.IndexOf("-") + 2, Canzone.Length)
        If Canzone.IndexOf(".") > -1 Then Canzone = Mid(Canzone, 1, Canzone.IndexOf("."))

        Dim sMembri As String = ""
        If Membri <> "" Then
            Dim c() As String = Membri.Split("§")
            For Each cc As String In c
                If cc <> "" Then
                    Dim ccc() As String = cc.Split(";")
                    If ccc(0) <> "" Then
                        sMembri &= ccc(0) & "^"
                    End If
                End If
            Next
        End If
        Dim cosa As String
        If sMembri <> "" Then
            cosa = lstArtista.Text & "%20band^" & sMembri & "^" & Canzone
        Else
            cosa = lstArtista.Text & "%20band^" & Canzone
        End If

        trd.Start(cosa)
    End Sub

    Private Sub ScaricaImmagineArtista(CosaCercare As String)
        Dim sCosaCercare() As String = CosaCercare.Split("^")
        Dim NomeDirectory As String = sCosaCercare(0).Replace("%20band", "")
        Dim xx As Integer

        Randomize()
        Try
            xx = Int(Rnd(1) * sCosaCercare.Length) ' - 1
        Catch ex As Exception
            xx = 1
        End Try

        If sCosaCercare(xx) <> "" And Not sCosaCercare(xx).ToUpper.Contains("NESSUNO") Then
            Dim sourceCode As String
            Dim sNomeFile As String = Application.StartupPath & "\Appoggio\Index.htm"
            Dim Url As String = "https://www.bing.com/images/search?q=" & sCosaCercare(xx).Replace(" ", "%20") & "&qs=n&form=QBLH&scope=images&sp=-1&pq=" & sCosaCercare(xx).Replace(" ", "%20") & "&sc=8-5&sk=&cvid=C713FE68173A4CD3993A58C7F868EDE4"

            Dim gf As New GestioneFilesDirectory
            gf.CreaDirectoryDaPercorso(gf.TornaNomeDirectoryDaPath(sNomeFile) & "\")
            gf.ScansionaDirectorySingola(gf.TornaNomeDirectoryDaPath(sNomeFile) & "\")
            Dim Filetti() As String = gf.RitornaFilesRilevati
            Dim qFiles As Integer = gf.RitornaQuantiFilesRilevati
            For i As Integer = 1 To qFiles
                gf.EliminaFileFisico(Filetti(i))
            Next
            If File.Exists(sNomeFile) = True Then
                Dim Conta As Integer = 1
                Dim Estensione As String = gf.TornaEstensioneFileDaPath(sNomeFile)

                sNomeFile = sNomeFile.Replace(Estensione, "")

                Do While File.Exists(sNomeFile & Format(Conta, "00") & Estensione) = True
                    Conta += 1
                Loop

                sNomeFile = sNomeFile & Format(Conta, "00") & Estensione
            End If

            Dim Ok As Boolean = True

            If TipoCollegamento.ToUpper.Trim = "PROXY" Then
                Dim request As System.Net.HttpWebRequest = System.Net.HttpWebRequest.Create(Url)
                request.Proxy.Credentials = New System.Net.NetworkCredential(Utenza, Password, Dominio)
                Try
                    Dim response As System.Net.HttpWebResponse = request.GetResponse()
                    Application.DoEvents()
                    Dim sr As System.IO.StreamReader = New System.IO.StreamReader(response.GetResponseStream())
                    Application.DoEvents()
                    sourceCode = sr.ReadToEnd()
                    sr.Close()
                    response.Close()
                    request = Nothing

                    gf.CreaAggiornaFile(sNomeFile, sourceCode)
                Catch ex As Exception
                    Ok = False
                End Try
            Else
                Try
                    My.Computer.Network.DownloadFile(
                        Url,
                        sNomeFile)
                Catch ex As Exception
                    Ok = False
                End Try
            End If

            If Ok = True Then
                sourceCode = gf.LeggeFileIntero(sNomeFile)

                Dim a As Long
                Dim Appoggio As String
                Dim Inizio As Long
                Dim Fine As Long
                Dim Scaricate As Integer = 0
                Dim Cambia As String
                Dim Fatto As Boolean = False

                ' Immagini
                Contatore = 0
                a = ControllaSeCiSonoImmagini(sourceCode)
                Do While a > -1
                    Appoggio = Mid(sourceCode, a, sourceCode.Length)
                    For i As Long = a To 1 Step -1
                        If Mid(sourceCode, i, 1) = Chr(34) Or Mid(sourceCode, i, 1) = "'" Or Mid(sourceCode, i, 1) = " " Then
                            Inizio = i
                            Exit For
                        End If
                    Next
                    For i As Long = a To sourceCode.Length - 1
                        If Mid(sourceCode, i, 1) = Chr(34) Or Mid(sourceCode, i, 1) = "'" Or Mid(sourceCode, i, 1) = " " Then
                            Fine = i + 1
                            Exit For
                        End If
                    Next
                    Appoggio = Mid(sourceCode, Inizio, Fine - Inizio)
                    Cambia = Appoggio
                    Appoggio = Appoggio.Replace("\/", "\")
                    Appoggio = Appoggio.Replace(Chr(34), "").Trim
                    If Appoggio.IndexOf("(") > -1 Then
                        Appoggio = Mid(Appoggio, Appoggio.IndexOf("(") + 2, Appoggio.Length)
                    End If
                    If Appoggio.IndexOf(")") > -1 Then
                        Appoggio = Mid(Appoggio, 1, Appoggio.IndexOf(")"))
                    End If
                    If Appoggio.ToUpper.IndexOf(".HTM") = -1 Then
                        If Mid(Appoggio, 1, 4).ToUpper = "HTTP" And Appoggio.IndexOf("yimg.com") = -1 And Appoggio.ToUpper.IndexOf("YAHOO") = -1 Then
                            Dim NomeImm As String = Appoggio
                            For i As Integer = NomeImm.Length To 1 Step -1
                                If Mid(NomeImm, i, 1) = "\" Or Mid(NomeImm, i, 1) = "/" Then
                                    NomeImm = Mid(NomeImm, i + 1, NomeImm.Length)
                                    Exit For
                                End If
                            Next

                            Dim nomeImmSolo As String = NomeImm
                            For i As Integer = nomeImmSolo.Length To 1 Step -1
                                If Mid(nomeImmSolo, i, 1) = "." Then
                                    nomeImmSolo = Mid(nomeImmSolo, 1, i - 1)
                                    Exit For
                                End If
                            Next

                            NomeImm = StrutturaDati.PathMP3 & "\" & NomeDirectory & "\ZZZ-ImmaginiArtista\" & NomeImm & ".dat"

                            gf.ScansionaDirectorySingola(StrutturaDati.PathMP3 & "\" & NomeDirectory)
                            Dim Esistenti() As String = gf.RitornaFilesRilevati
                            Dim qEsistenti As Integer = gf.RitornaQuantiFilesRilevati
                            Dim Ok2 As Boolean = True

                            For i As Integer = 1 To qEsistenti
                                If Esistenti(i).ToUpper.IndexOf(nomeImmSolo.ToUpper.Trim) > -1 Then
                                    Ok2 = False
                                    Exit For
                                End If
                            Next

                            If Ok2 = True Then
                                If ScaricaFileDaPagina(Appoggio, "IMMAGINI", NomeImm) = 1 Then
                                    Fatto = True
                                    Exit Do
                                End If
                            End If
                        End If
                    End If

                    sourceCode = sourceCode.Replace(Cambia, "")

                    a = ControllaSeCiSonoImmagini(sourceCode)
                Loop

                gf = Nothing

                If Fatto = False Then
                    gi.PuliscePictureBox(picImmagineArtista)
                End If

                If EsceDalCiclo = False Then
                    LeggeImmagini(NomeDirectory)
                Else
                    StaScaricando = False
                    Exit Sub
                End If
            End If
        Else
        End If

        StaScaricando = False
    End Sub

    Private Function ScaricaFileDaPagina(sUrl As String, Modalita As String, NomePassato As String) As Integer
        Dim Url As String = sUrl
        Dim Ritorno As Integer = 0

        Url = Mid(Url, 1, Url.Length)
        Url = Url.Replace("\", "/")

        Dim sNomeFile As String = NomePassato.Replace("+", "_")

        Dim NomeSito As String = Url

        Try
            If TipoCollegamento.Trim.ToUpper = "PROXY" Then
                Dim request As System.Net.HttpWebRequest = System.Net.HttpWebRequest.Create(Url)
                request.Proxy.Credentials = New System.Net.NetworkCredential(Utenza, Password, Dominio)
                request.Timeout = 7000
                Dim response As System.Net.HttpWebResponse = request.GetResponse()
                Application.DoEvents()
                Dim g As System.Drawing.Image = System.Drawing.Image.FromStream(response.GetResponseStream)
                Application.DoEvents()
                g.Save(sNomeFile)
                g.Dispose()
                'g = Nothing
                response.Close()
                response = Nothing
                request = Nothing

                Ritorno = 1
            Else
                My.Computer.Network.DownloadFile(
                    Url,
                    sNomeFile)
                Application.DoEvents()

                Ritorno = 1
            End If
        Catch ex As Exception
            Application.DoEvents()
        End Try

        Return Ritorno
    End Function

    Private Function ControllaSeCiSonoImmagini(Cosa As String) As Long
        Dim Ritorno As Long = -1
        Dim FilesImmagini() As String = {".JPG", ".JPEG", ".PNG", ".BMP", ".GIF", ".PCX"}

        For i As Integer = 0 To FilesImmagini.Length - 1
            If Cosa.ToUpper.IndexOf(FilesImmagini(i)) > -1 Then
                Ritorno = Cosa.ToUpper.IndexOf(FilesImmagini(i))
                Exit For
            End If
        Next

        Return Ritorno
    End Function

    Public Sub PrendeImmagineArtista(lstArtista As String)
        TimerEsterno.Enabled = False

        If qGiaPresenti > 0 Then
            Dim x As Integer
            Randomize()
            x = Int(Rnd(1) * 10)
            If x = 3 Then
                If StaScaricando = False Then
                    ScaricaImmagineArtistaInThread()
                End If
            Else
                VisualizzaImmagineArtista(lstArtista)
            End If
        Else
            If StaScaricando = False Then
                ScaricaImmagineArtistaInThread()
            End If
        End If

        TimerEsterno.Enabled = True
    End Sub

    Private Sub CambiaColoreSfondo(Colorato As Boolean)
        'pnlSopra.Width = picImmagineArtista.Width + 1
        'pnlSopra.Height = pnlImmagineArtista.Height / 2
        'pnlSopra.Left = picImmagineArtista.Left - 1

        'pnlSotto.Top = (pnlImmagineArtista.Height / 2) - 5
        'pnlSotto.Width = picImmagineArtista.Width + 1
        'pnlSotto.Height = (pnlImmagineArtista.Height / 2) + 10
        'pnlSotto.Left = picImmagineArtista.Left - 1

        Dim AppoImage As Image = picImmagineArtista.Image

        ImpostaCampiColori(AppoImage, pnlSopra, True, Colorato)
        ImpostaCampiColori(AppoImage, pnlSotto, False, Colorato)

        PrendeColoreSfondo(AppoImage, pnlImmagineArtista)
    End Sub

    Private Sub PrendeColoreSfondo(BM As Bitmap, pnlPannello As Panel)
        'Dim c As Color = BM.GetPixel(1, BM.Height / 2)

        'pnlPannello.BackColor = c
        'pnlSpectrum.BackColor = c

        If QualeImmagine <> -1 And QualeImmagine < GiaPresenti.Length Then
            Dim Immagine As String = GiaPresenti(QualeImmagine)

            If Immagine Is Nothing = False Then
                Try
                    Dim fs As System.IO.FileStream = Nothing
                    fs = New System.IO.FileStream(Immagine, IO.FileMode.Open, IO.FileAccess.Read)
                    Dim imm As Image = Nothing
                    Dim imm2 As Image = Nothing
                    Try
                        imm = System.Drawing.Image.FromStream(fs)
                    Catch ex As Exception

                    End Try
                    fs.Close()

                    pnlPannello.BackgroundImage = gi.CambiaOpacitaImmagine(imm, 0.27)

                Catch ex As Exception
                    pnlPannello.BackgroundImage = Nothing
                End Try
            Else
                pnlPannello.BackgroundImage = Nothing
            End If
        End If
    End Sub

    Private Sub ImpostaCampiColori(BM As Bitmap, pnlPannello As Panel, Sopra As Boolean, Colorato As Boolean)
        'Dim Quanti As Integer = 130
        'Dim c(Quanti) As Color
        'Dim p(Quanti) As Single
        'Dim conta As Integer = 0
        'Dim passo As Integer = Int(BM.Width / Quanti)
        'Dim Altezza As Integer
        'If Sopra = True Then
        '    Altezza = 1
        'Else
        '    Altezza = BM.Height - 1
        'End If
        'For i As Integer = 0 To BM.Width - 1 Step passo
        '    p(conta) = i / BM.Width
        '    If Colorato = True Then
        '        c(conta) = BM.GetPixel(i, Altezza)
        '    Else
        '        c(conta) = Color.Black
        '    End If
        '    conta += 1
        '    If conta > Quanti Then conta = Quanti
        'Next
        'p(0) = 0
        'c(0) = BM.GetPixel(0, Altezza)
        'c(Quanti) = BM.GetPixel(BM.Width - 1, Altezza)
        'p(Quanti) = 1

        'Dim rect As New Rectangle(New Point(0, 0), pnlPannello.Size)
        'Dim image As New Bitmap(pnlPannello.Width, pnlPannello.Height)
        'Dim gr As Graphics = Graphics.FromImage(image)

        'Using br As New LinearGradientBrush( _
        '    rect, Color.Blue, Color.White, 0.0F)
        '    ' Create a ColorBlend object. Note that you
        '    ' must initialize it before you save it in the
        '    ' brush's InterpolationColors property.
        '    Dim ColorBlend As New ColorBlend()
        '    ColorBlend.Colors = c
        '    ColorBlend.Positions = p
        '    br.InterpolationColors = ColorBlend

        '    gr.FillRectangle(br, rect)
        '    gr.DrawRectangle(Pens.Black, rect)
        'End Using

        'gr.Dispose()

        'pnlPannello.BackgroundImage = image
    End Sub

    Private Sub VisualizzaImmagineArtista(lstArtista As String)
        Dim gi As New GestioneImmagini
        Dim Ritorno() As Integer = {}
        Dim Immagine As String = ""

        TimerEffettoImmagine.Enabled = False

Ancora:
        If qGiaPresenti > 0 Then
            Dim Ok As Boolean = False

            Do While Not Ok
                Ok = True

                QualeImmagine += 1
                If QualeImmagine > qGiaPresenti Then
                    If qGiaPresenti < 11 Then
                        If StaScaricando = False Then
                            QualeImmagine = 0

                            ScaricaImmagineArtistaInThread()

                            Exit Sub
                        Else
                            QualeImmagine = 1
                        End If
                    Else
                        QualeImmagine = 1
                    End If
                End If

                Immagine = GiaPresenti(QualeImmagine)
                Dim fs As System.IO.FileStream = Nothing

                pnlImmagineArtista.BackgroundImage = Nothing

                If picImmagineArtista.Image Is Nothing = False And VecchioNomeImmagine <> "" And ImmagineVisualizzata Is Nothing Then
                    ' Fade out
                    'If File.Exists(VecchioNomeImmagine) = True Then
                    'If  = False And picImmagineArtista.Image Is Nothing = False Then
                    'fs = New System.IO.FileStream(VecchioNomeImmagine, IO.FileMode.Open, IO.FileAccess.Read)
                    Dim imm As Image = picImmagineArtista.Image
                    'Dim imm2 As Image = Nothing
                    'Try
                    '    'imm = System.Drawing.Image.FromStream(fs)
                    '    imm2 = gi.RitagliaBordoDaImmagine(imm, 10)
                    'Catch ex As Exception

                    'End Try
                    'fs.Close()

                    If imm Is Nothing = False Then
                        'Try
                        '    picImmagineArtista.Image = gi.CambiaOpacitaImmagine(imm2, 1)

                        '    'CambiaColoreSfondo(False)
                        Try
                            For i As Single = 1 To 0 Step -0.03
                                picImmagineArtista.Image = gi.CambiaOpacitaImmagine(imm, i)
                                Application.DoEvents()
                                'If VecchiaAscoltata <> QualeCanzoneStaSuonando And VecchiaAscoltata <> -1 Then
                                '    Exit For
                                'End If
                            Next
                            picImmagineArtista.Image = gi.CambiaOpacitaImmagine(imm, 0)
                            picImmagineArtista.Image.Dispose()
                        Catch ex As Exception

                        End Try
                        'picImmagineArtista.Width = 0
                        'picImmagineArtista.Height = 0
                        'Catch ex As Exception
                        '    gf.EliminaFileFisico(VecchioNomeImmagine)
                        'End Try
                        ' Fade out
                    End If
                    'End If
                End If

                If QualeEffettoImmagine = -1 Then
                    Randomize()
                    Dim q As Integer = Int(Rnd(1) * 9)
                    Do While q = QualeEffettoImmagine
                        q = Int(Rnd(1) * 9)
                    Loop
                    If q = 0 Then q = 9

                    QualeEffettoImmagine = q
                End If

                If Rotazione = -1 Then
                    Randomize()
                    Dim r As Integer = Int(Rnd(1) * 6)
                    Do While r = Rotazione
                        r = Int(Rnd(1) * 6)
                    Loop
                    If r = 0 Then r = 2

                    Rotazione = r
                End If

                If PassRotaz = -1 Then
                    Randomize()
                    PassRotaz = Rnd(0) * 3
                End If

                If QuantiPassi = -1 Then
                    Randomize()
                    QuantiPassi = ((Int(Rnd(1) * 3) + 1) * 57) + 100
                    Passo = 0
                End If

                If File.Exists(Immagine) = True Then
                    Dim MessoBordo As Boolean = False

                    Dim s As Integer = gf.TornaDimensioneFile(Immagine)
                    If s < 1024 Then
                        gf.CreaAggiornaFile(Immagine & ".DEL", "IMMAGINE ELIMINATA")
                        gf.EliminaFileFisico(Immagine)
                        Ok = False
                    Else
                        Dim Imag As Bitmap = Nothing

                        'fs = New System.IO.FileStream(Immagine, IO.FileMode.Open, IO.FileAccess.Read)
                        'Dim imm As Image = Nothing
                        'Try
                        '    imm = System.Drawing.Image.FromStream(fs)
                        'Catch ex As Exception
                        '    imm = Nothing
                        'End Try
                        'fs.Close()

                        ' picImmagineArtista.Image = gi.CaricaImmagineSenzaLockarla(Immagine)
                        Dim img As Image = Nothing
                        picImmagineArtista.Image = Nothing
                        Try
                            img = New Bitmap(Immagine)
                            picImmagineArtista.Image = New Bitmap(img)
                            img.Dispose()
                        Catch ex As Exception
                            gf.CreaAggiornaFile(Immagine & ".DEL", "IMMAGINE ELIMINATA")
                        End Try
                        If picImmagineArtista.Image Is Nothing Then
                            Ok = False
                        Else
                            Try
                                Kill(Application.StartupPath & "\Appoggio.jpg")
                            Catch ex As Exception

                            End Try

                            If gi Is Nothing Then
                                gi = New GestioneImmagini
                            End If

                            Try
                                gi.SalvaImmagineDaPictureBox(Application.StartupPath & "\Appoggio.jpg", picImmagineArtista.Image, 1024, 768)

                                Randomize()
                                Dim x As Integer = Int(Rnd(1) * 15)
                                Select Case x
                                    Case 3, 4
                                        gi.ConverteImmaginInBN(Application.StartupPath & "\Appoggio.jpg", Application.StartupPath & "\AppoggioBN.jpg")
                                        Kill(Application.StartupPath & "\Appoggio.jpg")
                                        Rename(Application.StartupPath & "\AppoggioBN.jpg", Application.StartupPath & "\Appoggio.jpg")
                                    Case 5
                                        MessoBordo = True
                                        gi.ConverteImmaginInBN(Application.StartupPath & "\Appoggio.jpg", Application.StartupPath & "\AppoggioBN.jpg")
                                        Kill(Application.StartupPath & "\Appoggio.jpg")
                                        Rename(Application.StartupPath & "\AppoggioBN.jpg", Application.StartupPath & "\Appoggio.jpg")

                                        gi.MetteCorniceAImmagine(Application.StartupPath & "\Appoggio.jpg", Application.StartupPath & "\AppoggioCORN.jpg")
                                        Kill(Application.StartupPath & "\Appoggio.jpg")
                                        Rename(Application.StartupPath & "\AppoggioCORN.jpg", Application.StartupPath & "\Appoggio.jpg")
                                    Case 1, 2, 6, 9, 11, 12, 13, 14
                                        MessoBordo = True
                                        gi.MetteCorniceAImmagine(Application.StartupPath & "\Appoggio.jpg", Application.StartupPath & "\AppoggioCORN.jpg")
                                        Kill(Application.StartupPath & "\Appoggio.jpg")
                                        Rename(Application.StartupPath & "\AppoggioCORN.jpg", Application.StartupPath & "\Appoggio.jpg")
                                End Select
                            Catch ex As Exception

                            End Try
                            Try
                                Dim img2 As Image = New Bitmap(Application.StartupPath & "\Appoggio.jpg")
                                Imag = New Bitmap(img2)
                                img2.Dispose()
                            Catch ex As Exception
                                Stop
                            End Try

                            If Imag Is Nothing = False Then
                                Rotaz = 0

                                ' If imm Is Nothing = False Then

                                'Try
                                'Imag = gi.CambiaOpacitaImmagine(Imag, 0)
                                ReDim DimeImmArtista(2)
                                DimeImmArtista(0) = Imag.Width
                                DimeImmArtista(1) = Imag.Height

                                'DimeImmArtista(0) = Imag.Width
                                'DimeImmArtista(1) = Imag.Height

                                'Dim sDimeImmArtista As String = gi.RitornaDimensioneImmagine(Immagine) ' (picImmagineArtista.Image.Width & "x" & picImmagineArtista.Image.Height).Split("x")
                                'If sDimeImmArtista <> "" And sDimeImmArtista.IndexOf("ERRORE") = -1 And sDimeImmArtista <> "1x1" Then
                                '    Dim a1 As Integer = sDimeImmArtista.IndexOf("x")
                                '    ReDim DimeImmArtista(2)
                                '    DimeImmArtista(0) = Mid(sDimeImmArtista, 1, a1)
                                '    DimeImmArtista(1) = Mid(sDimeImmArtista, a1 + 2, sDimeImmArtista.Length)
                                '    ' DimeImmArtista = sDimeImmArtista.Split("x")
                                'Else
                                '    Erase DimeImmArtista
                                'End If
                                'Catch ex As Exception
                                'Erase DimeImmArtista

                                ' gf.EliminaFileFisico(Immagine)
                                'End Try

                                'If DimeImmArtista Is Nothing = False Then
                                'If DimeImmArtista(0) > 1024 Or DimeImmArtista(1) > 768 Then
                                '    Imag.Dispose()

                                '    Dim sRitorno As String = gi.CentraImmagineNelPannello(1024, 768, DimeImmArtista(0), DimeImmArtista(1))
                                '    Dim a1 As Integer = sRitorno.IndexOf("x")
                                '    ReDim Ritorno(2)
                                '    Ritorno(0) = Val(Mid(sRitorno, 1, a1))
                                '    Ritorno(1) = Val(Mid(sRitorno, a1 + 2, sRitorno.Length))

                                '    DimeImmArtista = Ritorno

                                '    gi.Ridimensiona(Immagine, Immagine & ".RID", DimeImmArtista(0), DimeImmArtista(1))
                                '    gf.EliminaFileFisico(Immagine)
                                '    Rename(Immagine & ".RID", Immagine)

                                '    Imag = Image.FromFile(Immagine)
                                '    'fs = New System.IO.FileStream(Immagine, IO.FileMode.Open, IO.FileAccess.Read)
                                '    'imm = System.Drawing.Image.FromStream(fs)
                                '    ''imm2 = gi.RitagliaBordoDaImmagine(imm, 10)
                                '    'fs.Close()
                                'End If

                                'Ritorno = gi.CentraImmagineNelPannello(pnlImmagineArtista.Width, pnlImmagineArtista.Height, DimeImmArtista(0), DimeImmArtista(1)).Split("x")
                                'picImmagineArtista.Width = Ritorno(0)
                                'picImmagineArtista.Height = Ritorno(1)

                                'Select Case QualeEffettoImmagine
                                '    Case 1
                                '        Try
                                '            picImmagineArtista.Width *= 1.6
                                '            picImmagineArtista.Height *= 1.6
                                '        Catch ex As Exception

                                '        End Try
                                'End Select

                                'picImmagineArtista.Top = (pnlImmagineArtista.Height / 2) - (picImmagineArtista.Height / 2)
                                'picImmagineArtista.Left = ((pnlImmagineArtista.Width / 2) - (picImmagineArtista.Width / 2)) - 8

                                'picImmagineArtista.Visible = False
                                'picImmagineArtista.Image = gi.CambiaOpacitaImmagine(imm2, 1)
                                'picImmagineArtista.Image = gi.CambiaOpacitaImmagine(imm2, 0)
                                'picImmagineArtista.Visible = True

                                'picImmagineArtista.Width = DimeImmArtista(0)
                                'picImmagineArtista.Height = DimeImmArtista(1)

                                'Imag = DisegnaLineeSuBordo(Imag)

                                Dim bm_out As New Bitmap(DimeImmArtista(0), DimeImmArtista(1))
                                bm_out.MakeTransparent(Color.Black)
                                Dim gr As Graphics = Graphics.FromImage(bm_out)
                                gr.DrawImage(Imag, New Point(0, 0))
                                gr.Dispose()

                                'bm_out.Save("D:\Looigi\VB.Net\Miei\Form\MP3Tag\MP3Tag\bin\1.jpg")
                                If MessoBordo = False Then
                                    bm_out = DisegnaLineeSuBordo(bm_out)
                                End If

                                'bm_out.Save("D:\Looigi\VB.Net\Miei\Form\MP3Tag\MP3Tag\bin\2.jpg")

                                'picImmagineArtista.Image = bm_out
                                ImmagineVisualizzata = bm_out ' 
                                'picImmagineArtista.Image = bm_out

                                'picImmagineArtista.SizeMode = PictureBoxSizeMode.StretchImage
                                'picImmagineArtista.Width = bm_out.Width
                                'picImmagineArtista.Height = bm_out.Height
                                picImmagineArtista.Image = bm_out

                                CambiaColoreSfondo(True)

                                ' Fade in
                                For ii As Single = 0 To 1 Step 0.03
                                    picImmagineArtista.Image = gi.CambiaOpacitaImmagine(bm_out, ii)
                                    Application.DoEvents()
                                    'If VecchiaAscoltata <> QualeCanzoneStaSuonando And VecchiaAscoltata <> -1 Then
                                    '    Exit For
                                    'End If
                                Next
                                ' Fade in

                                'gf.CreaAggiornaFile("D:\Looigi\VB.Net\Miei\Form\MP3Tag\MP3Tag\bin\size.txt", DimeImmArtista(0) & "-" & DimeImmArtista(1) & vbCrLf & vbCrLf & picImmagineArtista.Width & "-" & picImmagineArtista.Height)
                                'Else
                                '    Ok = False
                                'End If
                            Else
                                Ok = False
                            End If
                        End If
                    End If
                Else
                    Ok = False
                End If

                'Try
                '    fs.Close()
                'Catch ex As Exception

                'End Try
            Loop

            'If Ok = False Then
            '    picImmagineArtista.Image = Image.FromFile("Immagini/Sconosciuto.jpg")
            '    VecchioNomeImmagine = ""
            '    DimeImmArtista = gi.RitornaDimensioneImmagine("Immagini/Sconosciuto.jpg").Split("x") ' (picImmagineArtista.Image.Width & "x" & picImmagineArtista.Image.Height).Split("x")
            '    Ritorno = gi.CentraImmagineNelPannello(pnlImmagineArtista.Width, pnlImmagineArtista.Height, DimeImmArtista(0), DimeImmArtista(1)).Split("x")
            '    picImmagineArtista.Width = Ritorno(0)
            '    picImmagineArtista.Height = Ritorno(1)
            '    picImmagineArtista.Top = (pnlImmagineArtista.Height / 2) - (picImmagineArtista.Height / 2)
            '    picImmagineArtista.Left = ((pnlImmagineArtista.Width / 2) - (picImmagineArtista.Width / 2)) - 8
            '    QualeEffettoImmagine = 0

            '    CambiaColoreSfondo(True)
            'End If

            'picImmagineArtista.Image = DisegnaLineeSuBordo(picImmagineArtista.Image)

            If DimeImmArtista Is Nothing = False Then
                PassoEffettoX = 5 ' pnlImmagineArtista.Width / 257
                PassoEffettoY = 5 ' pnlImmagineArtista.Width / 247
            End If

            VecchioNomeImmagine = Immagine

            If TimerEffettoImmagine.Enabled = False Then
                TimerEffettoImmagine.Enabled = True
            End If

            ContaEffetto = 0

            lblNomeImmArtista.Text = Immagine

            TimerSpostaScritta.Enabled = True

            'picImmagineArtista.Visible = True
            pnlImmagineArtista.Visible = True
            cmdEliminaImmagineArtista.Visible = False
            cmdSalva.Visible = False
            lblFiltroImpostato.Visible = False
            lblNomeArtistaImm.Visible = False
            pnlStelle.Visible = False
            cmdTesto.Visible = False
            pnlTasti.Visible = False
            cmdTraduzione.Visible = False
            Dim Ancora As Boolean = True

            Do While Ancora
                Try
                    cmdApreCartella.Visible = False
                    Ancora = False
                Catch ex As Exception
                    Thread.Sleep(100)
                End Try
            Loop

            Ancora = True

            While Ancora
                Try
                    cmdRefreshTestoInterno.Visible = False
                    Ancora = False
                Catch ex As Exception
                    Thread.Sleep(100)
                End Try
            End While

            picImmagineArtista.BackColor = Color.Transparent

            'picImmagineArtista.Parent = pnlImmagineArtista
            FattaRotazione = False
            'If Rotazione = 1 Or Rotazione = 3 Then
            'End If
        End If

        'If VecchiaAscoltata <> QualeCanzoneStaSuonando Then
        '    VecchiaAscoltata = QualeCanzoneStaSuonando
        'End If

        gi = Nothing

        If ImmagineVisualizzata Is Nothing = True Then
            GoTo ancora
        End If
    End Sub

    Private Function DisegnaLineeSuBordo(imm As Bitmap) As Bitmap
        Dim bm_out As New Bitmap(imm.Width, imm.Height)
        Dim DimeX As Integer = bm_out.Width
        Dim DimeY As Integer = bm_out.Height
        Dim QuanteRighe As Integer = DimeX / 27
        Dim Passo As Integer = Int(255 / (QuanteRighe + 1))
        Dim Sfumatura As Integer = 255
        bm_out.MakeTransparent(Color.Black)
        Dim gr As Graphics = Graphics.FromImage(bm_out)
        Dim p1 As Pen
        Dim p As Point = New Point(0, 0)

        gr.DrawImage(imm, p)
        For i As Integer = 0 To QuanteRighe
            p1 = New Pen(Color.FromArgb(Sfumatura, Color.Black))
            Sfumatura -= Passo

            gr.DrawLine(p1, i + 1, i, DimeX - i - 1, i)
            gr.DrawLine(p1, i, i, i, DimeY - i)

            gr.DrawLine(p1, i + 1, DimeY - i, DimeX - i - 1, DimeY - i)
            gr.DrawLine(p1, DimeX - i, i, DimeX - i, DimeY - i)
        Next
        gr.Dispose()

        Return bm_out
    End Function
End Class
