Imports System.IO

Public Class frmStatistiche
    Private y As Integer

    Private Sub ScriveOperazione(Cosa As String)
        lblOperazione.Text = Cosa
        Application.DoEvents()
    End Sub

    Private Sub frmStatistiche_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ScriveOperazione("")
    End Sub

    Private Sub CaricaStatistiche()
        Me.Cursor = Cursors.WaitCursor

        ScriveOperazione("Lettura canzoni")

        Dim gf As New GestioneFilesDirectory
        gf.ScansionaDirectorySingola(StrutturaDati.PathMP3)
        Dim Canzoni() As String = gf.RitornaFilesRilevati
        Dim qCanzoni As Integer = gf.RitornaQuantiFilesRilevati
        Dim qDirectory As Integer = gf.RitornaQuanteDirectoryRilevate
        Dim Ascoltata(qCanzoni) As Integer
        Dim Bellezza(7) As Integer

        ProgressBar1.Minimum = 0
        ProgressBar1.Maximum = qCanzoni

        Dim TotaleBytes As Long = 0
        Dim TotaleSecondi As Long = 0
        Dim TotaleParole As Long = 0
        Dim qImmagini As Integer = 0
        Dim qVideo As Integer = 0
        Dim qImmEliminate As Integer = 0

        Dim Giorni As Integer = 0
        Dim Ore As Integer = 0
        Dim Minuti As Integer = 0
        Dim Durata As String
        Dim Secondi As Integer = 0
        Dim Ok As Boolean
        Dim Lunghezza As Long
        Dim Artista As String, Album As String, Traccia As String, Anno As String, Titolo As String
        Dim idCanzone As Integer
        Dim Testo As String
        Dim t() As String
        Dim Appoggio As String = ""
        Dim AppoggioValore As Integer
        Dim appArrotondamento As Double
        Dim r1 As New RoutineVarie

        Dim Artisti() As String = {}
        Dim TotSecondiArtista() As Long = {}
        Dim QuanteCanzoniArtista() As Integer = {}
        Dim TotBytesArtista() As Long = {}
        Dim qArtisti As Integer = 0

        Dim Parole() As String = {}
        Dim TotParole() As Integer = {}
        Dim qParole As Integer = 0

        Dim MP3Rotti() As String = {}
        Dim qMp3Rotti As Integer = 0

        Dim DB As SQLSERVERCE
        Dim conn As Object = CreateObject("ADODB.Connection")
        Dim Rec As Object = CreateObject("ADODB.Recordset")
        Dim Sql As String = ""
        DB = New SQLSERVERCE
        DB.ImpostaNomeDB(PathDB)
        DB.LeggeImpostazioniDiBase()
        conn = DB.ApreDB()

        pnlStatistiche.Enabled = False

        ScriveOperazione("Lettura statistiche")

        For ii As Integer = 1 To qCanzoni
            ProgressBar1.Value = ii

            Dim s As String = Canzoni(ii)

            If s <> "" Then
                If s.ToUpper.Contains(".MP3") Or s.ToUpper.Contains(".WMA") Then
                    Try
                        Lunghezza = FileLen(s)
                    Catch ex As Exception
                        Lunghezza = -1
                    End Try

                    If Lunghezza = -1 Then
                        qMp3Rotti += 1
                        ReDim Preserve MP3Rotti(qMp3Rotti)
                        MP3Rotti(qMp3Rotti) = s & ";Lunghezza;"
                    End If

                    TotaleBytes += Lunghezza

                    Durata = PrendeTempoTotaleCanzone(s)
                    If Durata <> "" Then
                        Dim tm() As String = Durata.Split(":")
                        Secondi = Val(tm(0)) * 60
                        Secondi += Val(tm(1))

                        TotaleSecondi += Secondi
                    Else
                        Secondi = 0

                        qMp3Rotti += 1
                        ReDim Preserve MP3Rotti(qMp3Rotti)
                        MP3Rotti(qMp3Rotti) = s & ";Secondi;"
                    End If

                    Dim Tags As TagLib.File
                    Dim m As New MP3Tag

                    Tags = m.TornaTagDaMP3(s)

                    If Tags Is Nothing = False Then
                        Artista = m.TornaArtista(Tags)
                        Album = Tags.Tag.Album
                        Traccia = Tags.Tag.Track
                        Anno = Tags.Tag.Year
                        Titolo = Tags.Tag.Title
                    Else
                        Artista = ""
                        Album = ""
                        Traccia = ""
                        Anno = ""
                        Titolo = ""

                        qMp3Rotti += 1
                        ReDim Preserve MP3Rotti(qMp3Rotti)
                        MP3Rotti(qMp3Rotti) = s & ";TAG;"
                    End If

                    m = Nothing

                    ' Conta le canzoni per artisti
                    Ok = True
                    For i As Integer = 1 To qArtisti
                        If Artista <> "" Then
                            If Artisti(i) = Artista.ToUpper Then
                                TotSecondiArtista(i) += Secondi
                                QuanteCanzoniArtista(i) += 1
                                TotBytesArtista(i) += Lunghezza
                                Ok = False
                                Exit For
                            End If
                        End If
                    Next
                    If Ok Then
                        If Artista <> "" Then
                            qArtisti += 1
                            ReDim Preserve Artisti(qArtisti)
                            ReDim Preserve TotSecondiArtista(qArtisti)
                            ReDim Preserve QuanteCanzoniArtista(qArtisti)
                            ReDim Preserve TotBytesArtista(qArtisti)

                            Artisti(qArtisti) = Artista.ToUpper
                            TotSecondiArtista(qArtisti) += Secondi
                            QuanteCanzoniArtista(qArtisti) += 1
                            TotBytesArtista(qArtisti) += Lunghezza
                        End If
                    End If
                    ' Conta le canzoni per artisti

                    Dim ss As String = s.Replace(StrutturaDati.PathMP3 & "\", "")

                    t = ss.Split("\")

                    Dim sAnno As String = ""
                    Dim sTraccia As String = ""

                    If t(1).Contains("-") Then
                        sAnno = Mid(t(1), 1, t(1).IndexOf("-"))
                        t(1) = Mid(t(1), t(1).IndexOf("-") + 2, t(1).Length)
                    End If
                    If t(2).Contains("-") Then
                        sTraccia = Mid(t(2), 1, t(2).IndexOf("-"))
                        t(2) = Mid(t(2), t(2).IndexOf("-") + 2, t(2).Length)
                    End If

                    Sql = "Select * From ListaCanzone2 Where " &
                        "Album='" & r1.SistemaTestoPerDB(t(1)) & "' And " &
                        "Artista='" & r1.SistemaTestoPerDB(t(0)) & "' And " &
                        "Canzone='" & r1.SistemaTestoPerDB(t(2)) & "' And " &
                        "Anno=" & sAnno & " And " &
                        "Traccia=" & sTraccia
                    Rec = DB.LeggeQuery(conn, Sql)
                    If Not Rec.Eof Then
                        idCanzone = Rec(0).Value
                    End If
                    Rec.Close()

                    ' Prende le parole dei testi
                    Sql = "Select Testo, Ascoltata, Bellezza From ListaCanzone2 Where idCanzone=" & idCanzone
                    Rec = DB.LeggeQuery(conn, Sql)
                    If Not Rec.Eof Then
                        Testo = Rec(0).Value.ToString.Replace("%20", " ")
                        Ascoltata(ii) = Rec(1).Value
                        Bellezza(Rec(2).Value) += 1
                    Else
                        Testo = ""
                        Ascoltata(ii) = 0
                    End If
                    Rec.Close()

                    Testo = Testo.Replace("§", " ")
                    If Not Testo.ToUpper.Contains("NESSUN") And Not Testo.ToUpper.Contains("TESTO") And Not Testo.ToUpper.Contains("RILEVATO") And Testo.Length > 2 Then
                        t = Testo.Split(" ")
                        For Each tt As String In t
                            If tt.Trim <> "" And Not IsNumeric(tt) Then
                                Ok = True
                                For i As Integer = 1 To qParole
                                    If Parole(i) = tt.ToUpper Then
                                        TotParole(i) += 1
                                        Ok = False
                                        Exit For
                                    End If
                                Next

                                If Ok Then
                                    TotaleParole += 1

                                    qParole += 1
                                    ReDim Preserve Parole(qParole)
                                    ReDim Preserve TotParole(qParole)
                                    Parole(qParole) = tt.ToUpper
                                    TotParole(qParole) = 1
                                End If
                            End If
                        Next
                    End If
                    ' Prende le parole dei testi
                Else
                    If s.ToUpper.Contains("DESKTOP.INI") Or s.ToUpper.Contains("THUMBS") Then
                        Try
                            File.Delete(s)
                        Catch ex As Exception

                        End Try
                    Else
                        If s.ToUpper.Contains(".JPG") Or s.ToUpper.Contains(".BMP") Or s.ToUpper.Contains(".PNG") Or s.ToUpper.Contains(".GIF") Or s.ToUpper.Contains(".DAT") Then
                            qImmagini += 1
                        Else
                            If s.ToUpper.Contains(".MP4") Or s.ToUpper.Contains(".WEBM") Then
                                qVideo += 1
                            Else
                                If s.ToUpper.Contains(".DEL") Then
                                    qImmEliminate += 1
                                Else
                                    Stop
                                End If
                            End If
                        End If
                    End If
                End If
            End If
        Next

        ' Ordina i risultati delle parole
        If qParole > 0 Then
            ScriveOperazione("Ordinamento parole")
            ProgressBar1.Maximum = qParole

            For i As Integer = 1 To qParole
                ProgressBar1.Value = i
                For k As Integer = 1 To qParole
                    If TotParole(i) > TotParole(k) Then
                        Appoggio = Parole(i)
                        Parole(i) = Parole(k)
                        Parole(k) = Appoggio

                        AppoggioValore = TotParole(i)
                        TotParole(i) = TotParole(k)
                        TotParole(k) = AppoggioValore
                    End If
                Next
            Next
        End If
        ' Ordina i risultati delle parole

        ' Ordina i risultati delle ascoltate
        ScriveOperazione("Ordinamento ascoltate")
        ProgressBar1.Maximum = qCanzoni

        Dim qCanzoni2 As Integer = qCanzoni
        Dim Canzoni2() As String = Canzoni

        For i As Integer = 1 To qCanzoni2
            ProgressBar1.Value = i
            For k As Integer = 1 To qCanzoni2
                If Ascoltata(i) > Ascoltata(k) Then
                    Appoggio = Canzoni2(i)
                    Canzoni2(i) = Canzoni2(k)
                    Canzoni2(k) = Appoggio

                    AppoggioValore = Ascoltata(i)
                    Ascoltata(i) = Ascoltata(k)
                    Ascoltata(k) = AppoggioValore
                End If
            Next
        Next
        ' Ordina i risultati delle ascoltate

        y = 5

        pnlStatistiche.Controls.Clear()

        pnlStatistiche.Controls.Add(CreaLabel("Numero canzoni: " & r1.FormattaNumero(qCanzoni, False)))
        pnlStatistiche.Controls.Add(CreaLabel("Numero directory: " & r1.FormattaNumero(qDirectory, False)))
        pnlStatistiche.Controls.Add(CreaLabel("Numero immagini: " & r1.FormattaNumero(qImmagini, False)))
        pnlStatistiche.Controls.Add(CreaLabel("Numero immagini eliminate: " & r1.FormattaNumero(qImmEliminate, False)))
        pnlStatistiche.Controls.Add(CreaLabel("Numero video: " & r1.FormattaNumero(qVideo, False)))

        appArrotondamento = TotaleBytes / 1024 / 1024
        appArrotondamento = Int(appArrotondamento * 100) / 100
        pnlStatistiche.Controls.Add(CreaLabel("Totale MBytes: " & r1.FormattaNumero(appArrotondamento, True)))

        While TotaleSecondi > 59
            Minuti += 1
            If Minuti > 59 Then
                Minuti -= 60
                Ore += 1
                If Ore > 23 Then
                    Giorni += 1
                    Ore -= 24
                End If
            End If
            TotaleSecondi -= 60
        End While
        pnlStatistiche.Controls.Add(CreaLabel("Totale tempo: " & Format(Giorni, "00") & ":" & Format(Ore, "00") & ":" & Format(Minuti, "00") & ":" & Format(TotaleSecondi, "00")))

        y += 5
        For i As Integer = 0 To 7
            pnlStatistiche.Controls.Add(CreaLabel("Bellezza " & i & ": " & r1.FormattaNumero(Bellezza(i), False)))
        Next

        y += 5
        pnlStatistiche.Controls.Add(CreaLabel("Canzoni più ascoltate:"))
        For i As Integer = 1 To 20
            Dim c() As String = Canzoni2(i).Replace(StrutturaDati.PathMP3 & "\", "").Split("\")
            c(2) = c(2).Replace(gf.TornaEstensioneFileDaPath(c(2)), "")
            pnlStatistiche.Controls.Add(CreaLabel(c(0) & " " & c(1) & " " & c(2) & ": " & r1.FormattaNumero(Ascoltata(i), False), 50))
        Next

        y += 5
        pnlStatistiche.Controls.Add(CreaLabel("Numero artisti: " & r1.FormattaNumero(qArtisti, False)))

        For i As Integer = 1 To qArtisti
            appArrotondamento = TotBytesArtista(i) / 1024 / 1024
            appArrotondamento = Int(appArrotondamento * 100) / 100

            Minuti = 0
            Ore = 0
            Giorni = 0

            While TotSecondiArtista(i) > 59
                Minuti += 1
                If Minuti > 59 Then
                    Minuti -= 60
                    Ore += 1
                    If Ore > 23 Then
                        Giorni += 1
                        Ore -= 24
                    End If
                End If
                TotSecondiArtista(i) -= 60
            End While

            pnlStatistiche.Controls.Add(CreaLabel(Artisti(i) & ": Canzoni " & r1.FormattaNumero(QuanteCanzoniArtista(i), False) & " - " & _
                                     "MBytes: " & appArrotondamento.ToString & " - " & _
                                     "Tempo: " & Format(Giorni, "00") & ":" & Format(Ore, "00") & ":" & Format(Minuti, "00") & ":" & Format(TotaleSecondi, "00"), 50))
        Next

        y += 5
        pnlStatistiche.Controls.Add(CreaLabel("Numero parole nei testi: " & r1.FormattaNumero(qParole, False)))

        If qParole > 0 Then
            For i As Integer = 1 To 20
                pnlStatistiche.Controls.Add(CreaLabel(Parole(i) & ": " & r1.FormattaNumero(TotParole(i), False), 50))
            Next
        End If

        y += 5
        pnlStatistiche.Controls.Add(CreaLabel("Numero mp3 con problemi: " & r1.FormattaNumero(qMp3Rotti, False)))
        For i As Integer = 1 To qMp3Rotti
            t = MP3Rotti(i).Split(";")
            pnlStatistiche.Controls.Add(CreaLabel(t(0) & ": " & t(1), 50))
        Next

        pnlStatistiche.Enabled = True
        cmdEsegue.Enabled = True
        cmdChiude.Enabled = True

        ScriveOperazione("")

        Me.Cursor = Cursors.Default
    End Sub

    Private Function CreaLabel(Testo As String, Optional x As Integer = 10) As Label
        Dim l As Label
        Dim Fontino As New Font("Courier New", 10, FontStyle.Regular)

        l = New Label
        l.AutoSize = True
        l.Left = x
        l.Top = y
        l.Font = fontino
        ' l.Width = pnlStatistiche.Width - (x * 2)
        l.Text = Testo
        Application.DoEvents()

        y += 25

        Return l
    End Function

    Private Function PrendeTempoTotaleCanzone(Canzone As String)
        Dim Duration As String = ""
        Dim CeTag As Boolean

        Dim Tags As TagLib.File
        Dim m As New MP3Tag

        Tags = m.TornaTagDaMP3(Canzone)
        If Tags Is Nothing = False Then
            Duration = Tags.Properties.Duration.ToString()
            If Duration.IndexOf(".") > -1 Then
                Duration = Mid(Duration, 1, Duration.IndexOf("."))
            End If
            Duration = Mid(Duration, 4, Duration.Length)
            CeTag = True
        End If

        Return Duration
    End Function

    Private Sub cmdEsegue_Click(sender As Object, e As EventArgs) Handles cmdEsegue.Click
        cmdEsegue.Enabled = False
        cmdChiude.Enabled = False

        CaricaStatistiche()
    End Sub

    Private Sub cmdChiude_Click(sender As Object, e As EventArgs) Handles cmdChiude.Click
        Me.Close()
    End Sub
End Class