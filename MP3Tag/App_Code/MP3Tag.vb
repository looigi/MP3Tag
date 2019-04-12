Option Infer On

Imports System.IO

Public Class MP3Tag
    Public Function TornaTagDaMP3(Filetto As String) As TagLib.File
        Dim file As TagLib.File = Nothing

        Try
            file = TagLib.File.Create(Filetto)
        Catch ex As Exception

        End Try

        Return file
    End Function

    Public Sub ImpostaTag(NomeFile As String, Titolo As String, Album As String, Artista As String, Anno As String, Traccia As String)
        ' Scrittura tag
        Try
            Dim mp3 As TagLib.File = TagLib.File.Create(NomeFile)

            mp3.Tag.Track = Traccia
            mp3.Tag.Title = Titolo
            mp3.Tag.Album = Album
            mp3.Tag.Year = Anno
            mp3.Tag.Performers = New String() {Artista}
            mp3.Tag.AlbumArtists = New String() {Artista}
            mp3.Save()
            mp3.Dispose()
        Catch ex As Exception

        End Try
    End Sub

    Public Function MostraImmagineMP3(filepath As String) As Image
        Dim file As TagLib.File = Nothing
        Dim Immagine As Image = Nothing
        Try
            file = TagLib.File.Create(filepath)
        Catch ex As Exception

        End Try
        If file Is Nothing = False Then
            If file.Tag.Pictures.Length >= 1 Then
                Dim bin = DirectCast(file.Tag.Pictures(0).Data.Data, Byte())
                Try
                    Immagine = Image.FromStream(New MemoryStream(bin)).GetThumbnailImage(100, 100, Nothing, System.IntPtr.Zero)
                Catch ex As Exception

                End Try
            End If
        End If

        Return Immagine
    End Function

    Public Sub SalvaImmagineMP3(strFilePath As String, Immagine As String)
        TagLib.Id3v2.Tag.DefaultVersion = 3
        TagLib.Id3v2.Tag.ForceDefaultVersion = True

        Try
            Dim mp3 As TagLib.File = TagLib.File.Create(strFilePath)
            Dim picture As TagLib.Picture = New TagLib.Picture(Immagine)
            Dim albumCoverPictFrame As New TagLib.Id3v2.AttachedPictureFrame(picture)
            albumCoverPictFrame.MimeType = System.Net.Mime.MediaTypeNames.Image.Jpeg
            albumCoverPictFrame.Type = TagLib.PictureType.FrontCover
            Dim pictFrames() As TagLib.IPicture = {albumCoverPictFrame}
            mp3.Tag.Pictures = pictFrames 'set the pictures in the tag
            mp3.Save()

        Catch ex As Exception

        End Try
    End Sub

    Public Function TornaArtista(Tags As TagLib.File) As String
        Dim artista As String = ""

        If artista = "" Then
            If Tags.Tag.AlbumArtists.Length > 0 Then
                For k As Integer = 0 To Tags.Tag.AlbumArtists.Length - 1
                    artista += Tags.Tag.AlbumArtists(k) & " "
                Next
                artista = artista.Trim
            Else
                artista = Tags.Tag.FirstPerformer
            End If
        End If
        If artista <> "" Then
            If artista.Length < 3 Then
                If Tags.Tag.JoinedPerformers <> "" Then
                    Dim artista2 As String = Tags.Tag.JoinedPerformers.Replace(";", "").Trim

                    If artista2.Length > artista.Length Then
                        artista = artista2
                    End If
                End If
            End If
        End If

        Return artista
    End Function

    Public Function SistemaNomeFile(Nome As String, AncheSpazio As Boolean) As String
        Dim Ritorno As String = Nome

        If Ritorno <> "ZZZ-SenzaTAG" And Ritorno <> "" Then
            Ritorno = Ritorno.Replace("/", "_")
            Ritorno = Ritorno.Replace("?", "_")
            Ritorno = Ritorno.Replace("*", "_")
            Ritorno = Ritorno.Replace("+", "_")
            Ritorno = Ritorno.Replace("\", "_")
            Ritorno = Ritorno.Replace(":", "_")
            Ritorno = Ritorno.Replace(" - ", "-")
            Ritorno = Ritorno.Replace(Chr(34), "_")

            If AncheSpazio = True Then
                Dim c As String

                Ritorno = Ritorno.ToLower
                c = Mid(Ritorno, 1, 1).ToUpper
                Ritorno = c & Mid(Ritorno, 2, Ritorno.Length)
                For i As Integer = 1 To Ritorno.Length
                    If Mid(Ritorno, i, 1) = " " Or Mid(Ritorno, i, 1) = "," Or Mid(Ritorno, i, 1) = "." Then
                        If i + 1 < Ritorno.Length Then
                            c = Mid(Ritorno, i + 1, 1).ToUpper
                            Ritorno = Mid(Ritorno, 1, i) & c & Mid(Ritorno, i + 2, Ritorno.Length)
                        End If
                    End If
                Next
            End If
        End If

        Return Ritorno
    End Function
End Class
