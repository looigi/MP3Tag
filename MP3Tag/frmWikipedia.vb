Public Class frmWikipedia
    Public Sub ImpostaArtista(NomeArtista As String)
        Dim IndirizzoItaliano As String = "https://it.wikipedia.org/w/index.php?title="
        Dim Artista As String = NomeArtista

        Me.Text = NomeArtista

        Artista = Artista.Replace(" ", "_")

        WebBrowser1.Navigate(IndirizzoItaliano & Artista & "&printable=yes")
    End Sub

    Private Sub frmWikipedia_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If ChiusuraWikipediaNONTramiteTasto = False Then
            SaveSetting("MP3Tag", "Impostazioni", "Wikipedia", False)
            frmPlayer.chkWikipedia.Checked = False
        End If
    End Sub

    Private Sub frmWikipedia_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class