Imports System.IO
Imports System.Threading

Public Class frmConTAG
    Private Percorso As String
    Private DaDove As String
    Private ArtistaPassato As String
    Private AlbumPassato As String
    Private CanzonePassata As String
    Private trd As Thread
    Private instance As Form
    Private idPic As Integer
    Private idCanzone As Integer = -1

    Public Sub ImpostaPercorso(sPercorso As String)
        Percorso = sPercorso
    End Sub

    Public Sub DaDoveVengo(sDaDove As String)
        DaDove = sDaDove
    End Sub

    Public Sub ImpostaArtista(Artista As String, Album As String, Canzone As String)
        ArtistaPassato = Artista
        AlbumPassato = Album
        CanzonePassata = Canzone
    End Sub

    Private Sub frmConTAG_Disposed(sender As Object, e As EventArgs) Handles Me.Disposed
        If DaDove = "MAIN" Then
            frmMain.Show()
        End If
        Me.Close()
    End Sub

    'Private Sub frmConTAG_Deactivate(sender As Object, e As EventArgs) Handles Me.Deactivate
    'If Not NonUscire Then
    '    If DaDove = "MAIN" Then
    '        frmMain.Show()
    '    End If
    '    Me.Close()
    'End If
    'End Sub

    Private Sub frmConTAG_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' NonUscire = True
        Me.Height = 475
        instance = Me
        pnlImmagine.Visible = False
        chkNomeAlbum.Checked = GetSetting("MP3Tag", "Impostazioni", "NomeAlbumURL", True)
        chkArtista.Checked = GetSetting("MP3Tag", "Impostazioni", "NomeArtistaURL", True)
        pnlAzioni.Visible = False
        lblSelezione.Text = ""
        lblTipologia.Text = ""

        LeggeArtisti()

        If ArtistaPassato <> "" Then
            For i As Integer = 0 To lstArtista.Items.Count - 1
                If lstArtista.Items(i) = ArtistaPassato Then
                    lstArtista.SelectedIndex = i
                    Exit For
                End If
            Next

            For i As Integer = 0 To lstAlbum.Items.Count - 1
                If lstAlbum.Items(i) = AlbumPassato Then
                    lstAlbum.SelectedIndex = i
                    Exit For
                End If
            Next

            For i As Integer = 0 To lstCanzone.Items.Count - 1
                If lstCanzone.Items(i) = CanzonePassata Then
                    lstCanzone.SelectedIndex = i
                    Exit For
                End If
            Next
        End If
        ' NonUscire = False
    End Sub

    Private Sub VisualizzaLista()
        Dim QualeLista As ListBox = Lista
        Dim PercorsoAttuale As String = PercorsoImm

        Me.Cursor = Cursors.WaitCursor

        Dim gf As New GestioneFilesDirectory
        gf.ScansionaDirectorySingola(PercorsoAttuale)
        Dim Filetti() As String = gf.RitornaFilesRilevati
        Dim qFiles As Integer = gf.RitornaQuantiFilesRilevati
        gf = Nothing

        Dim Appoggio As String
        Dim Ok As Boolean

        For i As Integer = 1 To qFiles
            For k As Integer = i + 1 To qFiles
                If Filetti(i) > Filetti(k) Then
                    Appoggio = Filetti(i)
                    Filetti(i) = Filetti(k)
                    Filetti(k) = Appoggio
                End If
            Next
        Next

        QualeLista.Items.Clear()
        For i As Integer = 1 To qFiles
            If Filetti(i).IndexOf("ZZZ-SenzaTAG") = -1 And Filetti(i).IndexOf("ZZZ-WMA") = -1 And (Filetti(i).ToUpper.IndexOf(".MP3") > -1 Or Filetti(i).ToUpper.IndexOf(".WMA") > -1) Then
                Appoggio = Filetti(i).Replace(PercorsoAttuale & "\", "")
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
            End If
        Next

        PulisceCampi()

        Me.Cursor = Cursors.Default
    End Sub

    Private Sub PulisceCampi()
        lblDirFile.Text = ""
        lblNomeFile.Text = ""
        txtAlbum.Text = ""
        txtArtista.Text = ""
        txtAnno.Text = ""
        txtTitolo.Text = ""
        txtTraccia.Text = ""

        txtTitolo.Enabled = True
        txtTraccia.Enabled = True

        cmdImposta.Enabled = False

        picImmagineMP3.Image = Nothing
        picImmagineMP3.Enabled = False
        cmdImpostaAlbum.Enabled = False
        cmdElimina.Enabled = False
        cmdDownload.Enabled = False
        cmdEliminaTesto.Enabled = False
        cmdDownloadImmArtista.Enabled = False

        ChiudiPannelloImmagini()
    End Sub

    Private Sub LeggeArtisti()
        Lista = lstArtista
        PercorsoImm = Percorso
        VisualizzaLista()

        lstAlbum.Items.Clear()
        lstTesto.Items.Clear()
        lstCanzone.Items.Clear()
    End Sub

    Private Sub lstArtista_MouseDown(sender As Object, e As MouseEventArgs) Handles lstArtista.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Right Then
            Dim lb As ListBox = CType(sender, ListBox)
            Dim pt As New Point(e.X, e.Y)
            Dim index As Integer = lb.IndexFromPoint(pt)

            If index >= 0 Then
                lblSelezione.Text = lb.Items(index).ToString()
                lstArtista.SelectedIndex = index
                lblTipologia.Text = "ARTISTA"
                pnlAzioni.Left = lstArtista.Left + e.X + 10
                pnlAzioni.Top = lstArtista.Top + e.Y + 10
                pnlAzioni.Visible = True
            End If
        End If
    End Sub

    Private Lista As ListBox
    Private PercorsoImm As String

    Private Sub lstArtista_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstArtista.SelectedIndexChanged
        ChiudePannelloAzioni()
        CaricaAlbumDaArtista()
    End Sub

    Private Sub CaricaAlbumDaArtista()
        Lista = lstAlbum
        PercorsoImm = Percorso & "\" & lstArtista.Text
        VisualizzaLista()

        CaricaImmaginiArtistaInPannello()

        lstCanzone.Items.Clear()
        lstTesto.Items.Clear()

        cmdDownloadImmArtista.Enabled = True
    End Sub

    Private Sub lstAlbum_MouseDown(sender As Object, e As MouseEventArgs) Handles lstAlbum.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Right Then
            Dim lb As ListBox = CType(sender, ListBox)
            Dim pt As New Point(e.X, e.Y)
            Dim index As Integer = lb.IndexFromPoint(pt)

            If index >= 0 Then
                lblSelezione.Text = lb.Items(index).ToString()
                lstAlbum.SelectedIndex = index
                lblTipologia.Text = "ALBUM"
                pnlAzioni.Left = lstAlbum.Left + e.X + 10
                pnlAzioni.Top = lstAlbum.Top + e.Y + 10
                pnlAzioni.Visible = True
            End If
        End If
    End Sub

    Private Sub lstAlbum_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstAlbum.SelectedIndexChanged
        ChiudePannelloAzioni()
        CaricaCanzoniDaAlbum()
    End Sub

    Private Sub CaricaCanzoniDaAlbum()
        Lista = lstCanzone
        PercorsoImm = Percorso & "\" & lstArtista.Text & "\" & lstAlbum.Text
        VisualizzaLista()

        If lstAlbum.Text.IndexOf("-") > -1 Then
            txtAnno.Text = Mid(lstAlbum.Text, 1, lstAlbum.Text.IndexOf("-"))
            txtAlbum.Text = Mid(lstAlbum.Text, lstAlbum.Text.IndexOf("-") + 2, lstAlbum.Text.Length)
        Else
            txtAlbum.Text = lstAlbum.Text
            txtAnno.Text = ""
        End If

        txtArtista.Text = lstArtista.Text
        txtTraccia.Text = ""
        txtTitolo.Text = ""
        txtTitolo.Enabled = False
        txtTraccia.Enabled = False
        cmdImposta.Enabled = True
        picImmagineMP3.Image = Nothing
        picImmagineMP3.Enabled = True
        cmdImpostaAlbum.Enabled = False
        cmdElimina.Enabled = False
        cmdDownload.Enabled = True
        cmdEliminaTesto.Enabled = False

        Dim artista As String = lstArtista.Text.Trim
        If File.Exists(Percorso & "\" & lstArtista.Text & "\" & lstAlbum.Text & "\Cover_" & artista & ".jpg") = True Then
            Dim fs As System.IO.FileStream
            fs = New System.IO.FileStream(Percorso & "\" & lstArtista.Text & "\" & lstAlbum.Text & "\Cover_" & artista & ".jpg",
                 IO.FileMode.Open, IO.FileAccess.Read)
            picImmagineMP3.Image = System.Drawing.Image.FromStream(fs)
            fs.Close()
        End If

        cmdImposta.Text = "Imposta TAG album"
    End Sub

    Private Sub ScriveCanzone(Canzone As String)
        Dim gf As New GestioneFilesDirectory

        lblDirFile.Text = gf.TornaNomeDirectoryDaPath(Canzone)
        lblNomeFile.Text = gf.TornaNomeFileDaPath(Canzone)

        Dim Tags As TagLib.File
        Dim m As New MP3Tag

        Tags = m.TornaTagDaMP3(Canzone)

        If Tags Is Nothing = False Then
            txtArtista.Text = m.TornaArtista(Tags)
            txtAlbum.Text = Tags.Tag.Album
            txtTraccia.Text = Tags.Tag.Track
            txtAnno.Text = Tags.Tag.Year
            txtTitolo.Text = Tags.Tag.Title
        Else
            txtArtista.Text = ""
            txtAlbum.Text = ""
            txtTraccia.Text = ""
            txtAnno.Text = ""
            txtTitolo.Text = ""
        End If

        m = Nothing
        gf = Nothing
    End Sub

    Private Sub lstCanzone_MouseDown(sender As Object, e As MouseEventArgs) Handles lstCanzone.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Right Then
            Dim lb As ListBox = CType(sender, ListBox)
            Dim pt As New Point(e.X, e.Y)
            Dim index As Integer = lb.IndexFromPoint(pt)

            If index >= 0 Then
                lblSelezione.Text = lb.Items(index).ToString()
                lstCanzone.SelectedIndex = index
                lblTipologia.Text = "CANZONE"
                pnlAzioni.Left = lstCanzone.Left + e.X + 10
                pnlAzioni.Top = lstCanzone.Top + e.Y + 10
                pnlAzioni.Visible = True
            End If
        End If
    End Sub

    Private Sub lstCanzone_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstCanzone.SelectedIndexChanged
        ChiudePannelloAzioni()
        ScriveCanzone(Percorso & "\" & lstArtista.Text & "\" & lstAlbum.Text & "\" & lstCanzone.Text)
        cmdImposta.Text = "Imposta TAG canzone"
        txtTitolo.Enabled = True
        txtTraccia.Enabled = True
        cmdImposta.Enabled = True

        If lstCanzone.Text <> "" Then
            Dim m As New MP3Tag
            Dim i As Image = m.MostraImmagineMP3(Percorso & "\" & lstArtista.Text & "\" & lstAlbum.Text & "\" & lstCanzone.Text)
            picImmagineMP3.Image = i
            i = Nothing
            m = Nothing

            cmdImpostaAlbum.Enabled = True
        Else
            picImmagineMP3.Image = Nothing
            cmdImpostaAlbum.Enabled = False
        End If

        PrendeTestoCanzone()

        cmdDownload.Enabled = True
        cmdElimina.Enabled = True
        picImmagineMP3.Enabled = True
        cmdEliminaTesto.Enabled = True

        CaricaStelle(RitornaQuanteStelleCanzoneSenzaCaricarla(Percorso & "\" & lstArtista.Text & "\" & lstAlbum.Text & "\" & lstCanzone.Text))
        pnlStelle.Visible = True
    End Sub

    Private Sub CaricaStelle(QuanteStelle As Integer)
        Dim gi As New GestioneImmagini
        Dim p(7) As PictureBox
        p(1) = picStelle1
        p(2) = picStelle2
        p(3) = picStelle3
        p(4) = picStelle4
        p(5) = picStelle5
        p(6) = picStelle6
        p(7) = picStelle7

        For i As Integer = 1 To QuanteStelle ' - 1
            p(i).Image = gi.CaricaImmagineSenzaLockarla("Immagini/preferito.png")
        Next
        For i As Integer = QuanteStelle + 1 To 7
            p(i).Image = gi.CaricaImmagineSenzaLockarla("Immagini/preferito_vuoto.png")
        Next
        gi = Nothing
    End Sub

    Private Function RitornaQuanteStelleCanzoneSenzaCaricarla(sCanzone As String) As Integer
        Me.Cursor = Cursors.WaitCursor
        Dim r As New RoutineVarie
        Dim DB As New SQLSERVERCE
        Dim conn As Object = CreateObject("ADODB.Connection")
        Dim rec As Object = CreateObject("ADODB.Recordset")
        Dim Sql As String
        DB.ImpostaNomeDB(PathDB)
        DB.LeggeImpostazioniDiBase()
        conn = DB.ApreDB()

        Dim Ritorno As Integer = 0

        Sql = "Select Bellezza From ListaCanzone2 Where idCanzone=" & idCanzone
        rec = DB.LeggeQuery(conn, Sql)
        If Not rec.eof Then
            Ritorno = rec(0).Value
        End If
        rec.Close()
        conn.Close()

        DB = Nothing
        Me.Cursor = Cursors.Default

        Return Ritorno
    End Function

    Private Sub picStelle1_Click(sender As Object, e As EventArgs) Handles picStelle1.Click
        ScriveQuanteStelleCanzone(1)
        CaricaStelle(1)
    End Sub

    Private Sub picStelle2_Click(sender As Object, e As EventArgs) Handles picStelle2.Click
        ScriveQuanteStelleCanzone(2)
        CaricaStelle(2)
    End Sub

    Private Sub picStelle3_Click(sender As Object, e As EventArgs) Handles picStelle3.Click
        ScriveQuanteStelleCanzone(3)
        CaricaStelle(3)
    End Sub

    Private Sub picStelle4_Click(sender As Object, e As EventArgs) Handles picStelle4.Click
        ScriveQuanteStelleCanzone(4)
        CaricaStelle(4)
    End Sub

    Private Sub picStelle5_Click(sender As Object, e As EventArgs) Handles picStelle5.Click
        ScriveQuanteStelleCanzone(5)
        CaricaStelle(5)
    End Sub

    Private Sub picStelle6_Click(sender As Object, e As EventArgs) Handles picStelle6.Click
        ScriveQuanteStelleCanzone(6)
        CaricaStelle(6)
    End Sub

    Private Sub picStelle7_Click(sender As Object, e As EventArgs) Handles picStelle7.Click
        ScriveQuanteStelleCanzone(7)
        CaricaStelle(7)
    End Sub

    Private Sub ScriveQuanteStelleCanzone(Bellezza As Integer)
        If lstCanzone.Text = "" Or lstAlbum.Text = "" Or lstArtista.Text = "" Then
            Exit Sub
        End If

        Me.Cursor = Cursors.WaitCursor
        Dim r As New RoutineVarie
        Dim DB As New SQLSERVERCE
        Dim conn As Object = CreateObject("ADODB.Connection")
        Dim rec As Object = CreateObject("ADODB.Recordset")
        Dim Sql As String
        DB.ImpostaNomeDB(PathDB)
        DB.LeggeImpostazioniDiBase()
        conn = DB.ApreDB()
        Dim Ritorno As Integer = 0

        Dim Album As String = lstAlbum.Text
        If Mid(Album, 5, 1) <> "-" Then
            Album = "0000-" & Album
        End If
        Dim Canzone As String = lstCanzone.Text
        If Canzone.IndexOf("-") = -1 Then Canzone = "00-" & Canzone

        Dim NomeCanzone As String = lstArtista.Text & "\" & Album & "\" & Canzone
        NomeCanzone = NomeCanzone.Replace("'", "''")

        Dim idCanzone As Integer

        Sql = "Select * From ListaCanzone2 Where Album='" & r.SistemaTestoPerDB(lstAlbum.Text) & "' And Artista='" & r.SistemaTestoPerDB(lstArtista.Text) & "' And Canzone='" & r.SistemaTestoPerDB(lstCanzone.Text) & "'"
        rec = DB.LeggeQuery(conn, Sql)
        If Not rec.Eof Then
            idCanzone = rec(0).Value
        End If
        rec.Close()

        Sql = "Update ListaCanzone2 Set Bellezza=" & Bellezza & " Where idCanzone=" & idCanzone
        'Sql = "Select * From Bellezza Where idCanzone='" & r.SistemaTestoPerDB(NomeCanzone) & "'"
        'rec = DB.LeggeQuery(conn, Sql)
        'If rec.Eof = True Then
        '    Sql = "Insert Into Bellezza Values (" &
        '         "'" & r.SistemaTestoPerDB(NomeCanzone) & "', " &
        '         " " & Bellezza & ")"
        'Else
        '    Sql = "Update Bellezza Set Bellezza=" & Bellezza & " Where " &
        '         "Canzone='" & r.SistemaTestoPerDB(NomeCanzone) & "'"
        'End If
        'rec.Close()

        DB.EsegueSql(conn, Sql)

        conn.Close()
        DB = Nothing
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub ImpostaTagCanzone(sender As Object, e As EventArgs)
        Me.Cursor = Cursors.WaitCursor

        Dim NomeFile As String = lblDirFile.Text & "\" & lblNomeFile.Text

        Dim m As New MP3Tag
        m.ImpostaTag(NomeFile, txtTitolo.Text, txtAlbum.Text, txtArtista.Text, txtAnno.Text, txtTraccia.Text)
        m = Nothing

        For k As Integer = txtAnno.Text.Length + 1 To 4
            txtAnno.Text = "0" & txtAnno.Text
        Next

        Dim gf As New GestioneFilesDirectory
        Dim estensione As String = gf.TornaEstensioneFileDaPath(NomeFile)
        Dim pathDest As String = Percorso & "\" & txtArtista.Text & "\" & txtAnno.Text & "-" & txtAlbum.Text & "\"
        gf.CreaDirectoryDaPercorso(pathDest)
        If txtTraccia.Text.Length = 1 Then txtTraccia.Text = "0" & txtTraccia.Text
        pathDest += txtTraccia.Text & "-" & txtTitolo.Text & estensione
        Try
            FileCopy(NomeFile, pathDest)
            gf.EliminaFileFisico(NomeFile)
        Catch ex As Exception

        End Try
        gf = Nothing

        lstArtista_SelectedIndexChanged(sender, e)

        Me.Cursor = Cursors.Default
        ' NonUscire = True
        MsgBox("Tag Impostato e canzone spostata")
        ' NonUscire = False
    End Sub

    Private Sub ImpostaTagAlbum(sender As Object, e As EventArgs)
        ScriveTagPerAlbum(lstAlbum.Text)

        ' NonUscire = True
        MsgBox("Impostati Tag Album")
        ' NonUscire = False
    End Sub

    Private Sub ScriveTagPerAlbum(NomeAlbum As String)
        ' NonUscire = True
        Me.Cursor = Cursors.WaitCursor

        Dim gf As New GestioneFilesDirectory
        Dim m As New MP3Tag
        gf.ScansionaDirectorySingola(Percorso & "\" & lstArtista.Text & "\" & NomeAlbum, "*.mp3;*.wma")
        Dim Filetti() As String = gf.RitornaFilesRilevati
        Dim qFiles As Integer = gf.RitornaQuantiFilesRilevati
        Dim Tags As TagLib.File
        Dim Artista As String
        Dim Album As String
        Dim Traccia As String
        Dim Anno As String
        Dim Titolo As String

        For i As Integer = 1 To qFiles
            Tags = m.TornaTagDaMP3(Filetti(i))

            If Tags Is Nothing = False Then
                Artista = m.TornaArtista(Tags)
                Album = txtAlbum.Text
                Traccia = Tags.Tag.Track
                Anno = txtAnno.Text
                Titolo = Tags.Tag.Title
            Else
                Artista = ""
                Album = txtAlbum.Text
                Traccia = ""
                Anno = txtAnno.Text
                Titolo = ""
            End If
            For k As Integer = Anno.Length + 1 To 4
                Anno = "0" & Anno
            Next

            If Artista <> "" Then
                If Artista.IndexOf("ZZZ-SenzaTAG") > -1 Then
                    Artista = lstArtista.Text

                    If Titolo.IndexOf("-") > -1 Then
                        Titolo = Mid(Titolo, Titolo.IndexOf("-") + 2, Titolo.Length)
                        Titolo = Titolo.Trim
                        Titolo = Mid(Titolo, 1, 1).ToUpper & Mid(Titolo, 2, Titolo.Length)
                    End If
                End If
            End If

            Dim sAlbum As String = NomeAlbum
            If sAlbum.IndexOf("-") > -1 Then
                sAlbum = Mid(sAlbum, sAlbum.IndexOf("-") + 2, sAlbum.Length)
            End If
            m.ImpostaTag(Filetti(i), Titolo, sAlbum, Artista, Anno, Traccia)
        Next

        gf.PulisceCartelleVuote(Percorso & "\" & lstArtista.Text)

        m = Nothing
        gf = Nothing

        ' lstArtista_SelectedIndexChanged(sender, e)
        CaricaAlbumDaArtista()

        Me.Cursor = Cursors.Default
        ' NonUscire = False
    End Sub

    Private Sub ScriveTagPerArtista(NomeArtista As String)
        Me.Cursor = Cursors.WaitCursor

        Dim gf As New GestioneFilesDirectory
        Dim m As New MP3Tag
        gf.ScansionaDirectorySingola(Percorso & "\" & NomeArtista, "*.mp3;*.wma")
        Dim Directory() As String = gf.RitornaDirectoryRilevate
        Dim qDir As Integer = gf.RitornaQuanteDirectoryRilevate
        Dim Tags As TagLib.File
        Dim Artista As String
        Dim Album As String
        Dim Traccia As String
        Dim Anno As String
        Dim Titolo As String

        For kk As Integer = 1 To qDir
            If Percorso & "\" & NomeArtista <> Directory(kk) And Directory(kk).IndexOf("ZZZ-") = -1 Then
                gf.ScansionaDirectorySingola(Directory(kk), "*.mp3;*.wma")
                Dim Filetti() As String = gf.RitornaFilesRilevati
                Dim qFiles As Integer = gf.RitornaQuantiFilesRilevati

                For i As Integer = 1 To qFiles
                    Tags = m.TornaTagDaMP3(Filetti(i))

                    Dim NomeAlbum As String = gf.TornaNomeFileDaPath(Directory(kk))
                    Dim AnnoAlbum As String = ""
                    If NomeAlbum.IndexOf("-") > -1 Then
                        AnnoAlbum = Mid(NomeAlbum, 1, NomeAlbum.IndexOf("-"))
                        NomeAlbum = Mid(NomeAlbum, NomeAlbum.IndexOf("-") + 2, NomeAlbum.Length)
                    End If
                    If Tags Is Nothing = False Then
                        Artista = NomeArtista
                        Album = NomeAlbum
                        Traccia = Tags.Tag.Track
                        Anno = AnnoAlbum
                        Titolo = Tags.Tag.Title
                    Else
                        Artista = NomeArtista
                        Album = NomeAlbum
                        Traccia = ""
                        Anno = AnnoAlbum
                        Titolo = ""
                    End If
                    For k As Integer = AnnoAlbum.Length + 1 To 4
                        AnnoAlbum = "0" & AnnoAlbum
                    Next

                    m.ImpostaTag(Filetti(i), Titolo, Album, NomeArtista, Anno, Traccia)
                Next
            End If
        Next

        gf.PulisceCartelleVuote(Percorso & "\" & NomeArtista)

        m = Nothing
        gf = Nothing

        LeggeArtisti()

        Me.Cursor = Cursors.Default
    End Sub

    Private Sub cmdImposta_Click(sender As Object, e As EventArgs) Handles cmdImposta.Click
        ChiudePannelloAzioni()

        If cmdImposta.Text.ToUpper.IndexOf("ALBUM") > -1 Then
            ImpostaTagAlbum(sender, e)
        Else
            ImpostaTagCanzone(sender, e)
        End If
    End Sub

    Private Sub picImmagineMP3_Click(sender As Object, e As EventArgs) Handles picImmagineMP3.Click
        ChiudePannelloAzioni()

        pnlScelta.Visible = True
    End Sub

    Private Sub CambiaImmagineACanzone()
        If OpenFileDialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            Me.Cursor = Cursors.WaitCursor
            Dim Immagine As String = OpenFileDialog1.FileName
            Dim gi As New GestioneImmagini
            gi.Ridimensiona(Immagine, Application.StartupPath & "\Appoggio.jpg", 100, 100)
            gi = Nothing

            Dim fs As System.IO.FileStream
            fs = New System.IO.FileStream(Immagine,
                 IO.FileMode.Open, IO.FileAccess.Read)
            picImmagineMP3.Image = System.Drawing.Image.FromStream(fs)
            fs.Close()

            Dim m As New MP3Tag
            m.SalvaImmagineMP3(Percorso & "\" & lstArtista.Text & "\" & lstAlbum.Text & "\" & lstCanzone.Text, Application.StartupPath & "\Appoggio.jpg")
            m = Nothing

            Try
                Kill(Application.StartupPath & "\Appoggio.jpg")
            Catch ex As Exception

            End Try
            Me.Cursor = Cursors.Default
        End If
    End Sub

    Private Sub CambiaImmagineAdAlbum()
        If OpenFileDialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            Me.Cursor = Cursors.WaitCursor
            Dim Immagine As String = OpenFileDialog1.FileName
            Dim gi As New GestioneImmagini
            Dim artista As String = lstArtista.Text.Trim
            gi.Ridimensiona(Immagine, Percorso & "\" & lstArtista.Text & "\" & lstAlbum.Text & "\Cover_" & artista & "_PICC.jpg", 100, 100)
            gi = Nothing

            Dim fs As System.IO.FileStream
            fs = New System.IO.FileStream(Immagine,
                 IO.FileMode.Open, IO.FileAccess.Read)
            picImmagineMP3.Image = System.Drawing.Image.FromStream(fs)
            fs.Close()

            Dim gf As New GestioneFilesDirectory
            Dim m As New MP3Tag
            gf.ScansionaDirectorySingola(Percorso & "\" & lstArtista.Text & "\" & lstAlbum.Text)
            Dim Filetti() As String = gf.RitornaFilesRilevati
            Dim qFiles As Integer = gf.RitornaQuantiFilesRilevati
            For i As Integer = 1 To qFiles
                m.SalvaImmagineMP3(Filetti(i), Percorso & "\" & lstArtista.Text & "\" & lstAlbum.Text & "\Cover_" & artista & "_PICC.jpg")
            Next
            m = Nothing
            gf.EliminaFileFisico(Percorso & "\" & lstArtista.Text & "\" & lstAlbum.Text & "\Cover_" & artista & "_PICC.jpg")
            gf.EliminaFileFisico(Percorso & "\" & lstArtista.Text & "\" & lstAlbum.Text & "\Cover_" & artista & ".jpg")
            Rename(Immagine, Percorso & "\" & lstArtista.Text & "\" & lstAlbum.Text & "\Cover_" & artista & ".jpg")

            Me.Cursor = Cursors.Default
        End If
    End Sub

    Private Sub cmdImpostaImmagine_Click(sender As Object, e As EventArgs) Handles cmdImpostaImmagine.Click
        If cmdImposta.Text.ToUpper.IndexOf("ALBUM") > -1 Then
            CambiaImmagineAdAlbum()
        Else
            CambiaImmagineACanzone()
        End If

        pnlScelta.Visible = False
    End Sub

    Private Sub cmdImpostaAlbum_Click(sender As Object, e As EventArgs) Handles cmdImpostaAlbum.Click
        Me.Cursor = Cursors.WaitCursor
        Dim m As New MP3Tag
        Dim i As Image = m.MostraImmagineMP3(Percorso & "\" & lstArtista.Text & "\" & lstAlbum.Text & "\" & lstCanzone.Text)
        i.Save(Application.StartupPath & "\Appoggio.jpg")
        i = Nothing

        Dim gf As New GestioneFilesDirectory
        Dim gi As New GestioneImmagini
        gi.Ridimensiona(Application.StartupPath & "\Appoggio.jpg", Application.StartupPath & "\Appoggio_1.jpg", 100, 100)
        gf.EliminaFileFisico(Application.StartupPath & "\Appoggio.jpg")
        Rename(Application.StartupPath & "\Appoggio_1.jpg", Application.StartupPath & "\Appoggio.jpg")
        gf.ScansionaDirectorySingola(Percorso & "\" & lstArtista.Text & "\" & lstAlbum.Text)
        Dim Filetti() As String = gf.RitornaFilesRilevati
        Dim qFiles As Integer = gf.RitornaQuantiFilesRilevati
        For ii As Integer = 1 To qFiles
            m.SalvaImmagineMP3(Filetti(ii), Application.StartupPath & "\Appoggio.jpg")
        Next
        m = Nothing

        Dim artista As String = lstArtista.Text
        Try
            Kill(Percorso & "\" & lstArtista.Text & "\" & lstAlbum.Text & "\Cover_" & artista & ".jpg")
        Catch ex As Exception

        End Try

        Try
            Rename(Application.StartupPath & "\Appoggio.jpg", Percorso & "\" & lstArtista.Text & "\" & lstAlbum.Text & "\Cover_" & artista & ".jpg")
        Catch ex As Exception

        End Try

        Me.Cursor = Cursors.Default

        pnlScelta.Visible = False
    End Sub

    Private Sub cmdChiudePannello_Click(sender As Object, e As EventArgs) Handles cmdChiudePannello.Click
        pnlScelta.Visible = False
    End Sub

    Private Sub cmdElimina_Click(sender As Object, e As EventArgs) Handles cmdElimina.Click
        ChiudePannelloAzioni()

        ' NonUscire = True
        If MsgBox("Vuoi eliminare la canzone?", vbYesNo + vbInformation + vbDefaultButton2) = vbYes Then
            Try
                Kill(Percorso & "\" & lstArtista.Text & "\" & lstAlbum.Text & "\" & lstCanzone.Text)
            Catch ex As Exception

            End Try

            MsgBox("Canzone eliminata")
        End If
        ' NonUscire = False
    End Sub

    Private Sub cmdDownload_Click(sender As Object, e As EventArgs) Handles cmdDownload.Click
        Me.Cursor = Cursors.WaitCursor

        pnlScelta.Visible = False
        Contatore = 0
        Dim sNomeFile As String = Application.StartupPath & "\Appoggio\Index.htm"
        Dim Album As String = ""
        Dim Anno As String = ""

        If chkNomeAlbum.Checked = True Then
            Album = lstAlbum.Text
            If Mid(Album, 5, 1) <> "-" Then
                Anno = "+" & Mid(Album, 1, Album.IndexOf("-"))
                Album = "+" & Mid(Album, 6, Album.Length)
            Else
                Album = "+" & Album
            End If
        Else
            Album = ""
            Anno = ""
        End If
        Album = Album.Replace("&", "")
        Album = Album.Replace("  ", " ")
        If Anno = "+0000" Then Anno = ""

        For i As Integer = 1 To qImmaginiBox
            pics(i).Image = Nothing
            pics(i).Dispose()
            pics(i) = Nothing
        Next

        Dim Artista As String = ""
        If chkArtista.Checked = True Then
            Artista = lstArtista.Text
        Else
            Artista = ""
        End If
        Artista = Artista.Replace("&", "")
        Artista = Artista.Replace("  ", " ")

        qImmaginiBox = 0

        Dim Url As String = ""
        ' Url = "https://it.images.search.yahoo.com/search/images?p=" & Artista.Replace(" ", "%20") & Album.Replace(" ", "%20") & Anno & "&fr=yfp-t-909&fr2=piv-web"
        ' Url = "https://it.images.search.yahoo.com/search/images?p=" & Artista.Replace(" ", "%20") & Album.Replace(" ", "%20") & "&fr=yfp-t-909&fr2=piv-web&imgsz=large"
        Url = "https://www.bing.com/images/search?q=" & Artista.Replace(" ", "%20") & Album.Replace(" ", "%20") & "&qs=n&form=QBLH&scope=images&sp=-1&pq=" & Artista.Replace(" ", "%20") & Album.Replace(" ", "%20") & "&sc=8-5&sk=&cvid=C713FE68173A4CD3993A58C7F868EDE4"

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

        Dim sourceCode As String

        If TipoCollegamento.Trim.ToUpper = "PROXY" Then
            Dim request As System.Net.HttpWebRequest = System.Net.HttpWebRequest.Create(Url)
            request.Proxy.Credentials = New System.Net.NetworkCredential(Utenza, Password, Dominio)
            Dim response As System.Net.HttpWebResponse = request.GetResponse()
            Application.DoEvents()
            Dim sr As System.IO.StreamReader = New System.IO.StreamReader(response.GetResponseStream())
            Application.DoEvents()
            sourceCode = sr.ReadToEnd()
            sr.Close()
            response.Close()
            request = Nothing

            gf.CreaAggiornaFile(sNomeFile, sourceCode)
        Else
            My.Computer.Network.DownloadFile(
                Url,
                sNomeFile)
        End If

        sourceCode = gf.LeggeFileIntero(sNomeFile)

        Dim a As Long
        Dim Appoggio As String
        Dim Inizio As Long
        Dim Fine As Long
        Dim Scaricate As Integer = 0
        Dim Cambia As String

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
            If Appoggio.ToUpper.IndexOf(".HTM") = -1 Then
                If Mid(Appoggio, 1, 4).ToUpper = "HTTP" And Appoggio.IndexOf("yimg.com") = -1 And Appoggio.ToUpper.IndexOf("YAHOO") = -1 Then
                    Contatore += 1
                    Scaricate += ScaricaFileDaPagina(Appoggio, "IMMAGINI")
                    If Contatore >= 10 Then
                        Exit Do
                    End If
                End If
            End If

            sourceCode = sourceCode.Replace(Cambia, "")

            a = ControllaSeCiSonoImmagini(sourceCode)
        Loop

        gf = Nothing

        If Contatore = 0 Then
            ' NonUscire = True
            MsgBox("Nessuna copertina rilevata")
            ' NonUscire = False
        Else
            Me.Height = 683
            CaricaImmaginiAlbum()
        End If

        Me.Cursor = Cursors.Default
    End Sub

    Private Sub ClickImmagine(sender As Object, e As EventArgs)
        Me.Cursor = Cursors.WaitCursor
        Dim p As PictureBox = DirectCast(sender, PictureBox)
        'Try
        '    Kill(Application.StartupPath & "\Appoggio\AlbumDown.jpg")
        'Catch ex As Exception

        'End Try
        'p.Image.Save(Application.StartupPath & "\Appoggio\AlbumDown.jpg")
        'Dim Immagine As String = Application.StartupPath & "\Appoggio\AlbumDown.jpg"
        Dim Immagine As String = Application.StartupPath & "\Appoggio\" & p.Name
        Dim gi As New GestioneImmagini
        Dim artista As String = lstArtista.Text
        gi.Ridimensiona(Immagine, Percorso & "\" & lstArtista.Text & "\" & lstAlbum.Text & "\Cover_" & artista & "_PICC.jpg", 100, 100)
        gi = Nothing

        Dim fs As System.IO.FileStream
        fs = New System.IO.FileStream(Immagine,
             IO.FileMode.Open, IO.FileAccess.Read)
        picImmagineMP3.Image = System.Drawing.Image.FromStream(fs)
        fs.Close()

        Dim gf As New GestioneFilesDirectory
        Dim m As New MP3Tag
        gf.ScansionaDirectorySingola(Percorso & "\" & lstArtista.Text & "\" & lstAlbum.Text)
        Dim Filetti() As String = gf.RitornaFilesRilevati
        Dim qFiles As Integer = gf.RitornaQuantiFilesRilevati
        For i As Integer = 1 To qFiles
            m.SalvaImmagineMP3(Filetti(i), Percorso & "\" & lstArtista.Text & "\" & lstAlbum.Text & "\Cover_" & artista & "_PICC.jpg")
        Next
        m = Nothing
        gf.EliminaFileFisico(Percorso & "\" & lstArtista.Text & "\" & lstAlbum.Text & "\Cover_" & artista & "_PICC.jpg")
        gf.EliminaFileFisico(Percorso & "\" & lstArtista.Text & "\" & lstAlbum.Text & "\Cover_" & artista & ".jpg")
        Rename(Immagine, Percorso & "\" & lstArtista.Text & "\" & lstAlbum.Text & "\Cover_" & artista & ".jpg")
        Me.Cursor = Cursors.Default

        ChiudiPannelloImmagini()

        ' NonUscire = True
        MsgBox("Immagine impostata")
        ' NonUscire = False
    End Sub

    Private Sub ChiudiPannelloImmagini()
        Me.Height = 475

        For i As Integer = 1 To qImmaginiBox
            pics(i).Image = Nothing
            pics(i).Dispose()
            pics(i) = Nothing
        Next

        qImmaginiBox = 0
    End Sub

    Private Sub CaricaImmaginiAlbum()
        Dim gf As New GestioneFilesDirectory
        gf.ScansionaDirectorySingola(Application.StartupPath & "\Appoggio")
        Dim Filetti() As String = gf.RitornaFilesRilevati
        qImmaginiBox = gf.RitornaQuantiFilesRilevati
        Dim Dime1 As Long
        Dim Dime2 As Long
        Dim Appoggio As String
        For i As Integer = 1 To qImmaginiBox
            Dime1 = FileLen(Filetti(i))
            For k As Integer = i + 1 To qImmaginiBox
                Dime2 = FileLen(Filetti(i))
                If Dime1 > Dime2 Then
                    Appoggio = Filetti(i)
                    Filetti(i) = Filetti(k)
                    Filetti(k) = Appoggio
                End If
            Next
        Next
        Dim x As Integer = 10
        Dim dimeX As Integer = 160
        Dim fs As System.IO.FileStream = Nothing
        Dim tt As New ToolTip()
        Dim gi As New GestioneImmagini
        Dim ok As Boolean
        For i As Integer = 1 To qImmaginiBox
            pics(i) = New PictureBox
            pics(i).Left = x
            pics(i).Top = 10
            pics(i).Width = dimeX
            pics(i).Height = dimeX
            ok = True
            Try
                fs = New System.IO.FileStream(Filetti(i),
                     IO.FileMode.Open, IO.FileAccess.Read)
                pics(i).Image = System.Drawing.Image.FromStream(fs)
                fs.Close()
            Catch ex As Exception
                ok = False
            End Try
            Try
                fs.Close()
            Catch ex As Exception

            End Try
            If ok = True Then
                pics(i).Name = gf.TornaNomeFileDaPath(Filetti(i))
                pics(i).SizeMode = PictureBoxSizeMode.StretchImage
                pics(i).BorderStyle = BorderStyle.FixedSingle
                tt.SetToolTip(pics(i), "Kb. " & FileLen(Filetti(i)) & vbCrLf & gi.RitornaDimensioneImmagine(Filetti(i)))
                AddHandler pics(i).Click, AddressOf ClickImmagine
                pnlImmagini.Controls.Add(pics(i))
                x += (dimeX + 10)
            Else
                gf.EliminaFileFisico(Filetti(i))
            End If
        Next
        gf = Nothing
        gi = Nothing
    End Sub

    Private Function ScaricaFileDaPagina(sUrl As String, Modalita As String, Optional NomePassato As String = "") As Integer
        Dim Url As String = sUrl
        Dim Ritorno As Integer = 0

        Url = Mid(Url, 1, Url.Length)
        Url = Url.Replace("\", "/")

        Dim Direct As String = Url
        Direct = Mid(Direct, 8, Direct.Length)
        For i As Integer = 1 To Direct.Length - 1
            If Mid(Direct, i, 1) = "\" Or Mid(Direct, i, 1) = "/" Then
                Direct = Mid(Direct, 1, i - 1)
                Exit For
            End If
        Next

        Dim NomeFile As String
        If NomePassato = "" Then
            NomeFile = Contatore & ".jpg"
        Else
            NomeFile = NomePassato
        End If

        Dim gf As New GestioneFilesDirectory
        Dim sNomeFile As String

        If Modalita = "FILES" Then
            sNomeFile = "Links\FilesVari\" & NomeFile
        Else
            sNomeFile = "Appoggio\" & NomeFile
        End If

        gf = Nothing

        sNomeFile = sNomeFile.Replace("+", "_")

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
            Else
                My.Computer.Network.DownloadFile(
                    Url,
                    sNomeFile)
                Application.DoEvents()
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

    Private Function SistemaNome(Nome As String, Sito As String) As String
        Dim Ritorno As String
        Dim sNome As String = Nome
        Dim sSito As String = Sito
        Dim a As Integer
        Dim Quanti As Integer = 0
        Dim tot As Integer = 0

        ' Conta i '../'
        a = sNome.IndexOf("../")
        Do While a > -1
            Quanti += 1

            sNome = Mid(sNome, a + 3, sNome.Length)

            a = sNome.IndexOf("../")
        Loop
        If Mid(sNome, 1, 1) = "/" Then
            sNome = Mid(sNome, 2, sNome.Length)
        End If

        For i As Integer = sSito.Length To 1 Step -1
            If Mid(sSito, i, 1) = "/" Then
                tot += 1
                If tot = Quanti Then
                    sSito = Mid(sSito, 1, i)
                    Exit For
                End If
            End If
        Next

        Ritorno = sSito & sNome

        Return Ritorno
    End Function

    Private Sub cmdChiudePnlImmagini_Click(sender As Object, e As EventArgs) Handles cmdChiudePnlImmagini.Click
        ChiudiPannelloImmagini()
    End Sub

    Private Sub chkNomeAlbum_CheckedChanged(sender As Object, e As EventArgs) Handles chkNomeAlbum.CheckedChanged
        SaveSetting("MP3Tag", "Impostazioni", "NomeAlbumURL", chkNomeAlbum.Checked)
    End Sub

    Private Sub chkArtista_CheckedChanged(sender As Object, e As EventArgs) Handles chkArtista.CheckedChanged
        SaveSetting("MP3Tag", "Impostazioni", "NomeArtistaURL", chkArtista.Checked)
    End Sub

    Private Sub PrendeTestoCanzone()
        Dim NomeCanzone As String = lstArtista.Text & "\" & lstAlbum.Text & "\" & lstCanzone.Text
        NomeCanzone = NomeCanzone.Replace("'", "''")

        Dim DB As SQLSERVERCE
        Dim conn As Object = CreateObject("ADODB.Connection")
        Dim Rec As Object = CreateObject("ADODB.Recordset")
        Dim Sql As String = ""
        DB = New SQLSERVERCE
        DB.ImpostaNomeDB(PathDB)
        DB.LeggeImpostazioniDiBase()
        conn = DB.ApreDB()
        Dim r As New RoutineVarie

        Sql = "Select * From ListaCanzone2 Where Album='" & r.SistemaTestoPerDB(lstAlbum.Text) & "' And Artista='" & r.SistemaTestoPerDB(lstArtista.Text) & "' And Canzone='" & r.SistemaTestoPerDB(lstCanzone.Text) & "'"
        Rec = DB.LeggeQuery(conn, Sql)
        If Not Rec.Eof Then
            idCanzone = Rec(0).Value
        End If
        Rec.Close()

        If idCanzone <> -1 Then
            Sql = "Select * From ListaCanzone2 Where idCanzone=" & idCanzone
            Rec = DB.LeggeQuery(conn, Sql)
            If Not Rec.Eof Then
                Dim Righe() As String = Rec("Testo").Value.ToString.Split("§")

                lstTesto.Items.Clear()
                For i As Integer = 0 To Righe.Length - 1
                    lstTesto.Items.Add(Righe(i).Replace("%20", " "))
                Next
            Else
                lstTesto.Items.Clear()

                Dim g As New getLyricMP3
                g.ScaricaTestoDellaCanzone(NomeCanzone, lstCanzone, lstArtista, lstTesto)
                g = Nothing
            End If
            'Rec.Close()
        Else
            lstTesto.Items.Clear()
        End If
        conn.Close()
        DB = Nothing
    End Sub

    Private Sub cmdEliminaTesto_Click(sender As Object, e As EventArgs) Handles cmdEliminaTesto.Click
        ChiudePannelloAzioni()

        Dim NomeCanzone As String = lstArtista.Text & "\" & lstAlbum.Text & "\" & lstCanzone.Text
        NomeCanzone = NomeCanzone.Replace("'", "''")

        Dim DB As SQLSERVERCE
        Dim conn As Object = CreateObject("ADODB.Connection")
        Dim Rec As Object = CreateObject("ADODB.Recordset")
        Dim Sql As String = ""
        DB = New SQLSERVERCE
        DB.ImpostaNomeDB(PathDB)
        DB.LeggeImpostazioniDiBase()
        conn = DB.ApreDB()
        Sql = "Delete From Testi Where Canzone='" & NomeCanzone & "'"
        DB.EsegueSql(conn, Sql)
        lstTesto.Items.Clear()
        conn.Close()
        DB = Nothing

        ' NonUscire = True
        MsgBox("Testo eliminato")
        ' NonUscire = False
    End Sub

    Private Sub cmdDownloadImmArtista_Click(sender As Object, e As EventArgs) Handles cmdDownloadImmArtista.Click
        ChiudePannelloAzioni()

        Me.Cursor = Cursors.WaitCursor

        pnlScelta.Visible = False
        Contatore = 0
        Dim sNomeFile As String = Application.StartupPath & "\Appoggio\Index.htm"

        For i As Integer = 1 To qImmaginiBox
            pics(i).Image = Nothing
            pics(i).Dispose()
            pics(i) = Nothing
        Next

        Dim Artista As String = ""
        If chkArtista.Checked = True Then
            Artista = lstArtista.Text
        Else
            Artista = ""
        End If
        Artista = Artista.Replace("&", "")
        Artista = Artista.Replace("  ", " ")

        qImmaginiBox = 0

        Dim Url As String = ""
        ' Url = "https://it.images.search.yahoo.com/search/images?p=" & Artista.Replace(" ", "%20") & "%20band&imgsz=large&fr2=p%3As%2Cv%3Ai&.bcrumb=ywvpviT5Bpe&save=0"
        Url = "https://www.bing.com/images/search?q=" & Artista.Replace(" ", "%20") & "%20band&qs=n&form=QBLH&scope=images&sp=-1&pq=" & Artista.Replace(" ", "%20") & "%20band&sc=8-5&sk=&cvid=C713FE68173A4CD3993A58C7F868EDE4"

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

        Dim sourceCode As String

        If TipoCollegamento.ToUpper.Trim = "PROXY" Then
            Dim request As System.Net.HttpWebRequest = System.Net.HttpWebRequest.Create(Url)
            request.Proxy.Credentials = New System.Net.NetworkCredential(Utenza, Password, Dominio)
            Dim response As System.Net.HttpWebResponse = request.GetResponse()
            Application.DoEvents()
            Dim sr As System.IO.StreamReader = New System.IO.StreamReader(response.GetResponseStream())
            Application.DoEvents()
            sourceCode = sr.ReadToEnd()
            sr.Close()
            response.Close()
            request = Nothing

            gf.CreaAggiornaFile(sNomeFile, sourceCode)
        Else
            My.Computer.Network.DownloadFile(
                Url,
                sNomeFile)
        End If

        sourceCode = gf.LeggeFileIntero(sNomeFile)

        Dim a As Long
        Dim Appoggio As String
        Dim Inizio As Long
        Dim Fine As Long
        Dim Scaricate As Integer = 0
        Dim Cambia As String

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
            If Appoggio.ToUpper.IndexOf(".HTM") = -1 Then
                If Mid(Appoggio, 1, 4).ToUpper = "HTTP" And Appoggio.IndexOf("yimg.com") = -1 And Appoggio.ToUpper.IndexOf("YAHOO") = -1 Then
                    Dim NomeImm As String = Appoggio
                    For i As Integer = NomeImm.Length To 1 Step -1
                        If Mid(NomeImm, i, 1) = "\" Or Mid(NomeImm, i, 1) = "/" Then
                            NomeImm = Mid(NomeImm, i + 1, NomeImm.Length)
                            Exit For
                        End If
                    Next
                    Contatore += 1
                    Scaricate += ScaricaFileDaPagina(Appoggio, "IMMAGINI", NomeImm)
                    If Contatore >= 10 Then
                        Exit Do
                    End If
                End If
            End If

            sourceCode = sourceCode.Replace(Cambia, "")

            a = ControllaSeCiSonoImmagini(sourceCode)
        Loop

        gf = Nothing

        If Contatore = 0 Then
            ' NonUscire = True
            MsgBox("Nessuna immagine dell'artista rilevata")
            ' NonUscire = False
        Else
            Me.Height = 683
            CaricaImmaginiArtista()
        End If

        Me.Cursor = Cursors.Default
    End Sub

    Private Sub CaricaImmaginiArtista()
        Dim gf As New GestioneFilesDirectory
        gf.ScansionaDirectorySingola(Application.StartupPath & "\Appoggio")
        Dim Filetti() As String = gf.RitornaFilesRilevati
        qImmaginiBox = gf.RitornaQuantiFilesRilevati
        Dim Dime1 As Long
        Dim Dime2 As Long
        Dim Appoggio As String
        For i As Integer = 1 To qImmaginiBox
            Dime1 = FileLen(Filetti(i))
            For k As Integer = i + 1 To qImmaginiBox
                Dime2 = FileLen(Filetti(i))
                If Dime1 > Dime2 Then
                    Appoggio = Filetti(i)
                    Filetti(i) = Filetti(k)
                    Filetti(k) = Appoggio
                End If
            Next
        Next
        Dim x As Integer = 10
        Dim dimeX As Integer = 160
        Dim fs As System.IO.FileStream = Nothing
        Dim tt As New ToolTip()
        Dim gi As New GestioneImmagini
        Dim ok As Boolean
        For i As Integer = 1 To qImmaginiBox
            pics(i) = New PictureBox
            pics(i).Left = x
            pics(i).Top = 10
            pics(i).Width = dimeX
            pics(i).Height = dimeX
            ok = True
            Try
                fs = New System.IO.FileStream(Filetti(i),
                     IO.FileMode.Open, IO.FileAccess.Read)
                pics(i).Image = System.Drawing.Image.FromStream(fs)
                fs.Close()
            Catch ex As Exception
                ok = False
            End Try
            Try
                fs.Close()
            Catch ex As Exception

            End Try
            If ok = True Then
                pics(i).Name = gf.TornaNomeFileDaPath(Filetti(i))
                pics(i).SizeMode = PictureBoxSizeMode.StretchImage
                pics(i).BorderStyle = BorderStyle.FixedSingle
                tt.SetToolTip(pics(i), "Kb. " & FileLen(Filetti(i)) & vbCrLf & gi.RitornaDimensioneImmagine(Filetti(i)))
                AddHandler pics(i).Click, AddressOf ClickImmaginePerArtista
                pnlImmagini.Controls.Add(pics(i))
                x += (dimeX + 10)
            Else
                Try
                    pics(i).Image.Dispose()
                    pics(i).Image = Nothing
                Catch ex As Exception

                End Try
                gf.CreaAggiornaFile(Filetti(i) & ".DEL", "IMMAGINE ELIMINATA")
                gf.EliminaFileFisico(Filetti(i))
            End If
        Next
        gf = Nothing
        gi = Nothing
    End Sub

    Private Sub ClickImmaginePerArtista(sender As Object, e As EventArgs)
        Me.Cursor = Cursors.WaitCursor

        Dim gf As New GestioneFilesDirectory
        Dim p As PictureBox = DirectCast(sender, PictureBox)
        Dim Immagine As String = Application.StartupPath & "\Appoggio\" & p.Name
        Dim CartellaDestinazione As String = Percorso & "\" & lstArtista.Text & "\ZZZ-ImmaginiArtista"
        gf.CreaDirectoryDaPercorso(Percorso & "\" & lstArtista.Text & "\ZZZ-ImmaginiArtista\")
        Dim Estensione As String = gf.TornaEstensioneFileDaPath(Immagine)
        Dim NomeFile As String = gf.TornaNomeFileDaPath(Immagine.Replace(Estensione, "")) & ".dat"

        Try
            FileCopy(Immagine, CartellaDestinazione & "\" & NomeFile)
        Catch ex As Exception

        End Try

        CaricaImmaginiArtistaInPannello()

        Me.Cursor = Cursors.Default

        ' NonUscire = True
        MsgBox("Immagine salvata per l'artista")
        ' NonUscire = False
    End Sub

    Private Sub CaricaImmaginiArtistaInPannello()
        If Not trd Is Nothing Then
            trd.Abort()
            trd = Nothing
        End If

        NomeArtista = lstArtista.Text
        pnlImm = pnlImms
        pnlImm.Controls.Clear()

        trd = New Thread(AddressOf CaricaImmaginiThread)
        trd.IsBackground = True
        trd.Start()
    End Sub

    Private NomeArtista As String
    Private pnlImm As Panel

    Private Delegate Sub DelegateAggiungeOggetto(ByVal oggetto As PictureBox)
    Private MethodDelegateAggiungeOggetto As New DelegateAggiungeOggetto(AddressOf AggiungeOggettoAPannello)

    Private Delegate Sub DelegateAbilitaPannello(ByVal enabled As Boolean)
    Private MethodDelegateAbilitaPannello As New DelegateAbilitaPannello(AddressOf AbilitaPannello)

    Private Sub AbilitaPannello(enabled As Boolean)
        pnlImm.Enabled = enabled
    End Sub

    Private Sub AggiungeOggettoAPannello(oggetto As PictureBox)
        pnlImm.Controls.Add(oggetto)
    End Sub

    Private Sub CaricaImmaginiThread()
        If instance.InvokeRequired Then
            instance.Invoke(MethodDelegateAbilitaPannello, False)
        End If

        ' NonUscire = True
        For i As Integer = 0 To qImmaginiArtistaBox
            Try
                picsArtista(i).Image = Nothing
                picsArtista(i).Dispose()
                picsArtista(i) = Nothing
            Catch ex As Exception

            End Try
        Next

        qImmaginiArtistaBox = 0

        Dim gf As New GestioneFilesDirectory
        gf.CreaDirectoryDaPercorso(Percorso & "\" & NomeArtista & "\ZZZ-ImmaginiArtista\")
        gf.ScansionaDirectorySingola(Percorso & "\" & NomeArtista & "\ZZZ-ImmaginiArtista", "*.dat")
        Dim Filetti() As String = gf.RitornaFilesRilevati
        qImmaginiArtistaBox = gf.RitornaQuantiFilesRilevati
        Dim Dime1 As Long
        Dim Dime2 As Long
        Dim Appoggio As String
        For i As Integer = 1 To qImmaginiArtistaBox
            Dime1 = FileLen(Filetti(i))
            For k As Integer = i + 1 To qImmaginiArtistaBox
                Dime2 = FileLen(Filetti(i))
                If Dime1 > Dime2 Then
                    Appoggio = Filetti(i)
                    Filetti(i) = Filetti(k)
                    Filetti(k) = Appoggio
                End If
            Next
        Next
        Dim x As Integer = 3
        Dim y As Integer = 3
        Dim dimeX As Integer = 70
        Dim fs As System.IO.FileStream = Nothing
        Dim tt As New ToolTip()
        Dim gi As New GestioneImmagini
        Dim r As New RoutineVarie
        Dim ok As Boolean
        Dim q As Integer = 0
        Erase picsArtista

        For i As Integer = 1 To qImmaginiArtistaBox
            If Filetti(i).ToUpper.IndexOf(".DEL") = -1 Then
                Dim p As New PictureBox
                ok = True
                Try
                    fs = New System.IO.FileStream(Filetti(i),
                         IO.FileMode.Open, IO.FileAccess.Read)
                    p.Image = System.Drawing.Image.FromStream(fs)
                    fs.Close()
                Catch ex As Exception
                    ok = False
                End Try
                Try
                    fs.Close()
                Catch ex As Exception

                End Try
                If ok = True Then
                    q += 1
                    ReDim Preserve picsArtista(q)
                    picsArtista(q) = p
                    picsArtista(q).Tag = q
                    picsArtista(q).Left = x
                    picsArtista(q).Top = y
                    picsArtista(q).Width = dimeX
                    picsArtista(q).Height = dimeX
                    picsArtista(q).Name = gf.TornaNomeFileDaPath(Filetti(i))
                    picsArtista(q).SizeMode = PictureBoxSizeMode.StretchImage
                    picsArtista(q).BorderStyle = BorderStyle.FixedSingle
                    tt.SetToolTip(picsArtista(q), "Kb. " & r.FormattaNumero(FileLen(Filetti(i)), False) & vbCrLf & gi.RitornaDimensioneImmagine(Filetti(i)))
                    AddHandler picsArtista(q).Click, AddressOf GestisceImmagineArtista

                    If instance.InvokeRequired Then
                        instance.Invoke(MethodDelegateAggiungeOggetto, picsArtista(q))
                    End If

                    ' pnlImms.Controls.Add(picsArtista(q))

                    x += (dimeX + 3)
                    If x + dimeX > pnlImms.Width Then
                        x = 3
                        y += dimeX + 3
                    End If
                Else
                    Try
                        Kill(Filetti(i) & ".DEL")
                    Catch ex As Exception

                    End Try

                    Try
                        Rename(Filetti(i), Filetti(i) & ".DEL")
                    Catch ex As Exception

                    End Try
                End If
            End If
        Next
        gf = Nothing
        gi = Nothing
        r = Nothing
        ' NonUscire = False

        If instance.InvokeRequired Then
            instance.Invoke(MethodDelegateAbilitaPannello, True)
        End If

        trd = Nothing
    End Sub

    Private Sub GestisceImmagineArtista(sender As Object, e As EventArgs)
        ' NonUscire = True
        ChiudePannelloAzioni()

        Dim p As PictureBox = DirectCast(sender, PictureBox)
        Dim gf As New GestioneFilesDirectory
        gf.CreaDirectoryDaPercorso(Percorso & "\" & lstArtista.Text & "\ZZZ-ImmaginiArtista\")
        Dim Immagine As String = Percorso & "\" & lstArtista.Text & "\ZZZ-ImmaginiArtista\" & p.Name
        If File.Exists(Immagine) Then
            Dim r As New RoutineVarie
            Dim gi As New GestioneImmagini
            Dim fs As System.IO.FileStream

            lblNomeImmNascosto.Text = Immagine
            idPic = p.Tag

            fs = New System.IO.FileStream(Immagine,
                 IO.FileMode.Open, IO.FileAccess.Read)
            picImmagine.Image = System.Drawing.Image.FromStream(fs)
            fs.Close()
            lblInfoPIC.Text = "Kb. " & r.FormattaNumero(FileLen(Immagine), False) & " " & gi.RitornaDimensioneImmagine(Immagine)

            pnlImmagine.Visible = True
        End If
        ' NonUscire = False
    End Sub

    Private Sub cmdChiudPImm_Click(sender As Object, e As EventArgs) Handles cmdChiudPImm.Click
        pnlImmagine.Visible = False
    End Sub

    Private Sub cmdEliminaPic_Click(sender As Object, e As EventArgs) Handles cmdEliminaPic.Click
        ' NonUscire = True
        If MsgBox("Si vuole eliminare l'immagine selezionata?", vbYesNo + vbInformation + vbDefaultButton2) = vbYes Then
            Try
                Kill(lblNomeImmNascosto.Text & ".DEL")
            Catch ex As Exception

            End Try
            picImmagine.Image = Nothing

            Try
                Kill(lblNomeImmNascosto.Text)
            Catch ex As Exception

            End Try

            Dim gf As New GestioneFilesDirectory
            gf.CreaAggiornaFile(lblNomeImmNascosto.Text & ".DEL", "*")
            gf = Nothing

            pnlImmagine.Visible = False
            picsArtista(idPic).Image.Dispose()
            picsArtista(idPic).Enabled = False
            'CaricaImmaginiArtistaInPannello()
        End If
        ' NonUscire = False
    End Sub

    Private Sub cmdSalva_Click(sender As Object, e As EventArgs) Handles cmdSalva.Click
        Dim gf As New GestioneFilesDirectory
        'Dim Nome As String = gf.TornaNomeFileDaPath(lblNomeImmNascosto.Text).Replace(".dat", "")

        'Try
        '    MkDir(Application.StartupPath & "\ImmaginiSalvate")
        'Catch ex As Exception

        'End Try

        'Nome = gf.NomeFileEsistente(Nome)
        'FileCopy(lblNomeImmNascosto.Text, Application.StartupPath & "\ImmaginiSalvate\" & Nome)

        '' NonUscire = True
        'MsgBox("Immagine salvata")
        '' NonUscire = False

        Dim Nome As String = gf.TornaNomeFileDaPath(lblNomeImmNascosto.Text).Replace(".dat", "")

        Try
            MkDir(Application.StartupPath & "\ImmaginiSalvate")
        Catch ex As Exception

        End Try

        Nome = gf.NomeFileEsistente(Nome)

        If ControllaSeEStataSalvataUnaImmagine(lblNomeImmNascosto.Text & "\" & Nome) Then
            MsgBox("Immagine già salvata")
            Exit Sub
        End If

        'If File.Exists(Application.StartupPath & "\ImmaginiSalvate.Txt") Then
        '    Dim Salvate As String = gf.LeggeFileIntero(Application.StartupPath & "\ImmaginiSalvate.Txt")
        '    If Salvate.IndexOf(lblNomeImmNascosto.Text & "\" & Nome) > -1 Then
        '        MsgBox("Immagine già salvata")
        '        Exit Sub
        '    End If
        'End If

        Dim gi As New GestioneImmagini
        Dim Estensione As String = gf.TornaEstensioneFileDaPath(Nome)

        If Not Estensione.ToUpper.Contains(".JPG") And Not Estensione.ToUpper.Contains(".JPEG") Then
            Dim immagine As Image = gi.CaricaImmagineSenzaLockarla(lblNomeImmNascosto.Text)
            Dim nomefile As String = gf.TornaNomeFileDaPath(lblNomeImmNascosto.Text.Replace(".dat", ""))
            nomefile = nomefile.Replace(Estensione, "")
            If Estensione = "" Then Estensione = ".jpg"
            Dim pathfile As String = gf.TornaNomeDirectoryDaPath(lblNomeImmNascosto.Text)
            gi.SalvaImmagineDaPictureBox(pathfile & "\Conv_" & nomefile & Estensione, immagine)
            Nome = pathfile & "\Conv_" & nomefile & Estensione
        Else
            Nome = lblNomeImmNascosto.Text
        End If

        FileCopy(Nome, Application.StartupPath & "\ImmaginiSalvate\" & gf.TornaNomeFileDaPath(Nome).Replace(".dat", ""))

        If Nome.ToUpper.Contains("CONV_") Then
            Try
                Kill(Nome)
            Catch ex As Exception

            End Try
        End If

        Dim info() As String = {lstArtista.Text, gf.TornaNomeFileDaPath(Nome).Replace(gf.TornaEstensioneFileDaPath(Nome), "")}
        gi.ScriveTag("MP3TAG", Application.StartupPath & "\ImmaginiSalvate\" & gf.TornaNomeFileDaPath(Nome).Replace(".dat", ""), "MP3Tag", info)
        gi = Nothing

        'gf.ApreFileDiTestoPerScrittura(Application.StartupPath & "\ImmaginiSalvate.Txt")
        'gf.ScriveTestoSuFileAperto(lblNomeImmNascosto.Text & "\" & Nome)
        'gf.ChiudeFileDiTestoDopoScrittura()

        ScriveImmagineSalvataSuDB(lblNomeImmNascosto.Text & "\" & Nome)

        MsgBox("Immagine salvata")
    End Sub

    Private Sub cmdChiudeAzioni_Click(sender As Object, e As EventArgs) Handles cmdChiudeAzioni.Click
        ChiudePannelloAzioni()
    End Sub

    Private Sub ChiudePannelloAzioni()
        pnlAzioni.Visible = False
        lblSelezione.Text = ""
        lblTipologia.Text = ""
        pnlStelle.Visible = False
    End Sub

    Private Sub cmdCancella_Click(sender As Object, e As EventArgs) Handles cmdCancella.Click
        Select Case lblTipologia.Text
            Case "ARTISTA"
                EliminaArtista()
            Case "ALBUM"
                EliminaAlbum()
            Case "CANZONE"
                EliminaCanzone()
        End Select

        ChiudePannelloAzioni()
    End Sub

    Private Sub EliminaArtista()
        Dim Nome As String = Percorso & "\" & lblSelezione.Text

        ' NonUscire = True
        If MsgBox("Si vuole eliminare l'artista " & vbCrLf & vbCrLf & "Artista: " & lblSelezione.Text, vbYesNo + MsgBoxStyle.DefaultButton2) = vbYes Then
            Me.Cursor = Cursors.WaitCursor
            Dim gf As New GestioneFilesDirectory
            gf.ScansionaDirectorySingola(Nome)
            Dim Filetti() As String = gf.RitornaFilesRilevati
            Dim qFiles As Integer = gf.RitornaQuantiFilesRilevati
            gf = Nothing

            For i As Integer = 1 To qFiles
                Try
                    Kill(Filetti(i))
                Catch ex As Exception
                    Me.Cursor = Cursors.Default
                    MsgBox("ERRORE: " & ex.Message)
                End Try
            Next

            LeggeArtisti()

            Me.Cursor = Cursors.Default
            MsgBox("Artista eliminato")
        End If
        ' NonUscire = False
    End Sub

    Private Sub EliminaAlbum()
        Dim Nome As String = Percorso & "\" & lstArtista.Text & "\" & lblSelezione.Text

        ' NonUscire = True
        If MsgBox("Si vuole eliminare l'album " & vbCrLf & vbCrLf & "Artista: " & lstArtista.Text & vbCrLf & "Album: " & lblSelezione.Text, vbYesNo + MsgBoxStyle.DefaultButton2) = vbYes Then
            Me.Cursor = Cursors.WaitCursor
            Dim gf As New GestioneFilesDirectory
            gf.ScansionaDirectorySingola(Nome)
            Dim Filetti() As String = gf.RitornaFilesRilevati
            Dim qFiles As Integer = gf.RitornaQuantiFilesRilevati
            gf = Nothing

            For i As Integer = 1 To qFiles
                Try
                    Kill(Filetti(i))
                Catch ex As Exception
                    Me.Cursor = Cursors.Default
                    MsgBox("ERRORE: " & ex.Message)
                End Try
            Next

            CaricaAlbumDaArtista()

            Me.Cursor = Cursors.Default
            MsgBox("Album eliminato")
        End If
        ' NonUscire = False
    End Sub

    Private Sub EliminaCanzone()
        Dim Nome As String = Percorso & "\" & lstArtista.Text & "\" & lstAlbum.Text & "\" & lblSelezione.Text

        ' NonUscire = True
        If MsgBox("Si vuole eliminare la canzone " & vbCrLf & vbCrLf & "Artista: " & lstArtista.Text & vbCrLf & "Album: " & lstAlbum.Text & vbCrLf & "Canzone: " & lblSelezione.Text, vbYesNo + MsgBoxStyle.DefaultButton2) = vbYes Then
            Me.Cursor = Cursors.WaitCursor
            Try
                Kill(Nome)
            Catch ex As Exception
                Me.Cursor = Cursors.Default
                MsgBox("ERRORE: " & ex.Message)
                Exit Sub
            End Try

            CaricaCanzoniDaAlbum()

            Me.Cursor = Cursors.Default
            MsgBox("Canzone eliminata")
        End If
        ' NonUscire = False
    End Sub

    Private Sub cmdRinomina_Click(sender As Object, e As EventArgs) Handles cmdRinomina.Click
        Select Case lblTipologia.Text
            Case "ARTISTA"
                RinominaArtista()
            Case "ALBUM"
                RinominaAlbum()
            Case "CANZONE"
                RinominaCanzone()
        End Select

        ChiudePannelloAzioni()
    End Sub

    Private Sub RinominaArtista()
        ' NonUscire = True
        Dim Nome As String = Percorso & "\" & lblSelezione.Text
        Dim gf As New GestioneFilesDirectory
        Dim Estensione As String = gf.TornaEstensioneFileDaPath(lblSelezione.Text)
        Dim Numero As String = ""
        If lblSelezione.Text.IndexOf("-") > -1 Then
            Numero = Mid(lblSelezione.Text, 1, lblSelezione.Text.IndexOf("-") + 1)
        End If
        Dim Testo As String = lblSelezione.Text
        If Estensione <> "" Then
            Testo = Testo.Replace(Estensione, "")
        End If
        If Numero <> "" Then
            Testo = Testo.Replace(Numero, "")
        End If
        Dim NuovoNome As String = InputBox("Nuovo nome artista", "MP3Tag", Testo)
        If NuovoNome = "" Then
            Exit Sub
        End If
        Dim SoloNomeNuovo As String = Numero & NuovoNome & Estensione
        NuovoNome = Percorso & "\" & Numero & NuovoNome & Estensione

        Me.Cursor = Cursors.WaitCursor
        Try
            My.Computer.FileSystem.RenameDirectory(Nome, SoloNomeNuovo)
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            ' NonUscire = True
            MsgBox("ERRORE: " & ex.Message)
            ' NonUscire = False
            Exit Sub
        End Try

        ScriveTagPerArtista(SoloNomeNuovo)

        Me.Cursor = Cursors.Default

        MsgBox("Artista rinominato")
        ' NonUscire = False
    End Sub

    Private Sub RinominaAlbum()
        ' NonUscire = True
        Dim Nome As String = Percorso & "\" & lstArtista.Text & "\" & lblSelezione.Text
        Dim gf As New GestioneFilesDirectory
        Dim Estensione As String = gf.TornaEstensioneFileDaPath(lblSelezione.Text)
        Dim Numero As String = ""
        If lblSelezione.Text.IndexOf("-") > -1 Then
            Numero = Mid(lblSelezione.Text, 1, lblSelezione.Text.IndexOf("-") + 1)
        End If
        Dim Testo As String = lblSelezione.Text
        If Estensione <> "" Then
            Testo = Testo.Replace(Estensione, "")
        End If
        If Numero <> "" Then
            Testo = Testo.Replace(Numero, "")
        End If
        Dim NuovoNome As String = InputBox("Nuovo nome album", "MP3Tag", Testo)
        If NuovoNome = "" Then
            Exit Sub
        End If
        Dim SoloNomeNuovo As String = Numero & NuovoNome & Estensione
        NuovoNome = Percorso & "\" & lstArtista.Text & "\" & lstAlbum.Text & "\" & Numero & NuovoNome & Estensione

        Me.Cursor = Cursors.WaitCursor
        Try
            My.Computer.FileSystem.RenameDirectory(Nome, SoloNomeNuovo)
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            ' NonUscire = True
            MsgBox("ERRORE: " & ex.Message)
            ' NonUscire = False
            Exit Sub
        End Try

        ScriveTagPerAlbum(SoloNomeNuovo)

        Me.Cursor = Cursors.Default

        MsgBox("Album rinominato")
        ' NonUscire = False
    End Sub

    Private Sub RinominaCanzone()
        ' NonUscire = True
        Dim Nome As String = Percorso & "\" & lstArtista.Text & "\" & lstAlbum.Text & "\" & lblSelezione.Text
        Dim gf As New GestioneFilesDirectory
        Dim Estensione As String = gf.TornaEstensioneFileDaPath(lblSelezione.Text)
        Dim Numero As String = ""
        If lblSelezione.Text.IndexOf("-") > -1 Then
            Numero = Mid(lblSelezione.Text, 1, lblSelezione.Text.IndexOf("-") + 1)
        End If
        Dim Testo As String = lblSelezione.Text
        If Estensione <> "" Then
            Testo = Testo.Replace(Estensione, "")
        End If
        If Numero <> "" Then
            Testo = Testo.Replace(Numero, "")
        End If
        Dim NuovoNome As String = InputBox("Nuovo nome canzone", "MP3Tag", Testo)
        If NuovoNome = "" Then
            Exit Sub
        End If
        NuovoNome = Percorso & "\" & lstArtista.Text & "\" & lstAlbum.Text & "\" & Numero & NuovoNome & Estensione

        Me.Cursor = Cursors.WaitCursor
        Try
            Rename(Nome, NuovoNome)
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            ' NonUscire = True
            MsgBox("ERRORE: " & ex.Message)
            ' NonUscire = False
            Exit Sub
        End Try

        CaricaCanzoniDaAlbum()

        Me.Cursor = Cursors.Default

        MsgBox("Canzone rinominata")
        ' NonUscire = False
    End Sub

    Private Sub pnlImmagine_Paint(sender As Object, e As PaintEventArgs) Handles pnlImmagine.Paint

    End Sub

    Private Sub cmdConverteMP3_Click(sender As Object, e As EventArgs) Handles cmdConverteMP3.Click
        If lstCanzone.Text = "" Then
            MsgBox("Selezionare un brano", vbInformation)
            Exit Sub
        End If

        Me.Enabled = False

        Dim gf As New GestioneFilesDirectory
        Dim NomeBrano As String = Percorso & "\" & lstArtista.Text & "\" & lstAlbum.Text & "\" & lstCanzone.Text
        Dim estensione As String = ".mp3"
        If NomeBrano.ToUpper.Contains(".MP3") Then
            estensione = ".ppp"
        End If
        Dim NomeConvertito As String = Percorso & "\" & lstArtista.Text & "\" & lstAlbum.Text & "\" & lstCanzone.Text.Replace(gf.TornaEstensioneFileDaPath(lstCanzone.Text), "") & estensione
        Dim info As New ProcessStartInfo()
        info.FileName = Application.StartupPath & "\ffmpeg.exe"
        info.WorkingDirectory = Percorso & "\" & lstArtista.Text & "\" & lstAlbum.Text
        ' ffmpeg -i input.wav -vn -ar 44100 -ac 2 -ab 192k -f mp3 output.mp3
        info.Arguments = "-i " & Chr(34) & NomeBrano & Chr(34) & " -vn -ar 44100 -ac 2 -ab 192k -f mp3 " & Chr(34) & NomeConvertito & Chr(34)
        info.WindowStyle = ProcessWindowStyle.Normal
        'info.CreateNoWindow = True

        Dim p As Process = Process.Start(info)
        p.WaitForExit()
        Dim ritorno As Integer = p.ExitCode

        If File.Exists(NomeConvertito) Then
            Dim Tags As TagLib.File
            Dim m As New MP3Tag

            Dim Artista As String, Album As String, Traccia As String, Anno As String, Titolo As String

            Tags = m.TornaTagDaMP3(NomeBrano)

            If Tags Is Nothing = False Then
                artista = m.TornaArtista(Tags)
                Album = Tags.Tag.Album
                traccia = Tags.Tag.Track
                Anno = Tags.Tag.Year
                titolo = Tags.Tag.Title
            Else
                Artista = ""
                Album = ""
                Traccia = ""
                Anno = ""
                Titolo = ""
            End If

            m = Nothing

            File.Delete(NomeBrano)
            File.Copy(NomeConvertito, NomeBrano)
            File.Delete(NomeConvertito)

            m = New MP3Tag
            m.ImpostaTag(NomeBrano, Titolo, Album, Artista, Anno, Traccia)
            m = Nothing
        End If

        Me.Enabled = True
    End Sub
End Class