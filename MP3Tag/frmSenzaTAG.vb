Public Class frmSenzaTAG
    Private Filetti() As String
    Private qFiletti As Integer
    Private Quale As Integer = 0
    Private Percorso As String
    Private StaSuonando As Boolean = False
    Private audio As AudioFile

    Public Sub ImpostaPercorso(sPercorso As String)
        Percorso = sPercorso
    End Sub

    Private Sub frmSenzaTAG_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Quale = 1
        LeggeCanzoni()
    End Sub

    Private Sub LeggeCanzoni()
        Dim gf As New GestioneFilesDirectory
        gf.ScansionaDirectorySingola(Percorso & "\ZZZ-SenzaTAG\")
        Filetti = gf.RitornaFilesRilevati
        qFiletti = gf.RitornaQuantiFilesRilevati
        gf = Nothing
        If Quale > qFiletti Then
            Quale = 1
        End If
        ScriveCanzone()
    End Sub

    Private Sub ScriveCanzone()
        Dim gf As New GestioneFilesDirectory

        lblContatore.Text = Quale & "/" & qFiletti
        lblDirFile.Text = gf.TornaNomeDirectoryDaPath(Filetti(Quale))
        lblNomeFile.Text = gf.TornaNomeFileDaPath(Filetti(Quale))

        Dim Tags As TagLib.File
        Dim m As New MP3Tag

        Tags = m.TornaTagDaMP3(Filetti(Quale))

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

        ControllaSuono()
    End Sub

    Private Sub ControllaSuono()
        If StaSuonando = True Then
            StaSuonando = False
            audio.Stop()
            audio = Nothing
        End If
    End Sub

    Private Sub cmdIndietro_Click(sender As Object, e As EventArgs) Handles cmdIndietro.Click
        If Quale > 1 Then
            Quale -= 1
        Else
            Quale = qFiletti
        End If

        ScriveCanzone()
    End Sub

    Private Sub cmdAvanti_Click(sender As Object, e As EventArgs) Handles cmdAvanti.Click
        If Quale < qFiletti Then
            Quale += 1
        Else
            Quale = 1
        End If

        ScriveCanzone()
    End Sub

    Private Sub cmdImposta_Click(sender As Object, e As EventArgs) Handles cmdImposta.Click
        ControllaSuono()

        Dim m As New MP3Tag
        m.ImpostaTag(Filetti(Quale), txtTitolo.Text, txtAlbum.Text, txtArtista.Text, txtAnno.Text, txtTraccia.Text)
        m = Nothing

        For k As Integer = txtAnno.Text.Length + 1 To 4
            txtAnno.Text = "0" & txtAnno.Text
        Next

        Dim gf As New GestioneFilesDirectory
        Dim estensione As String = gf.TornaEstensioneFileDaPath(Filetti(Quale))
        Dim pathDest As String = Percorso & "\" & txtArtista.Text & "\" & txtAnno.Text & "-" & txtAlbum.Text & "\"
        gf.CreaDirectoryDaPercorso(pathDest)
        If txtTraccia.Text.Length = 1 Then txtTraccia.Text = "0" & txtTraccia.Text
        pathDest += txtTraccia.Text & "-" & txtTitolo.Text & estensione
        FileCopy(Filetti(Quale), pathDest)
        gf.EliminaFileFisico(Filetti(Quale))
        gf = Nothing

        LeggeCanzoni()

        MsgBox("Tag Impostato")
    End Sub

    Private Sub cmdUscita_Click(sender As Object, e As EventArgs) Handles cmdUscita.Click
        ControllaSuono()

        frmMain.Show()
        Me.Close()
    End Sub

    Private Sub cmdPlay_Click(sender As Object, e As EventArgs) Handles cmdPlay.Click
        If StaSuonando = False Then
            StaSuonando = True
            audio = New AudioFile(Filetti(Quale))
            audio.Play()
        Else
            StaSuonando = False
            audio.Stop()
            audio = Nothing
        End If
    End Sub

    Private Sub cmdElimina_Click(sender As Object, e As EventArgs) Handles cmdElimina.Click
        Dim gf As New GestioneFilesDirectory
        gf.EliminaFileFisico(Filetti(Quale))
        gf = Nothing

        LeggeCanzoni()

        MsgBox("Canzone eliminata")
    End Sub
End Class
