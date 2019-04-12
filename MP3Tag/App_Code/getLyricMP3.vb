Imports System.Xml
Imports System.IO

Public Class getLyricMP3
    Private Function RitornaTestoCanzone(Artista As String, Titolo As String)
        Dim sArtista As String = Artista
        Dim sTitolo As String = Titolo
        sArtista = sArtista.Replace(" ", "%20")
        sTitolo = sTitolo.Replace(" ", "%20")
        Dim Url As String = "http://api.chartlyrics.com/apiv1.asmx/SearchLyricDirect?artist=" & sArtista & "&song=" & sTitolo
        Dim Ritorno As String = ""
        Dim sourceCode As String
        Dim gf As New GestioneFilesDirectory
        Dim sNomeFile As String = Application.StartupPath & "\Appoggio\Testo.xml"
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

        If TipoCollegamento.trim.toupper = "PROXY" Then
            Dim request As System.Net.HttpWebRequest = System.Net.HttpWebRequest.Create(Url)
            request.Proxy.Credentials = New System.Net.NetworkCredential(Utenza, Password, Dominio)
            request.Timeout = 7000
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
                My.Computer.Network.DownloadFile(Url, sNomeFile)
            Catch ex As Exception
                Ok = False
            End Try
        End If

        If Ok = False Then
            Return ""
        End If

        Dim NomeCanzone As String = ""
        Dim NomeArtista As String = ""

        If File.Exists(sNomeFile) = True Then
            Dim reader As XmlTextReader = New XmlTextReader(sNomeFile)
            Dim PrendiTesto As Boolean = False
            Dim PrendiNome As Boolean = False
            Dim PrendiArtista As Boolean = False

            Do While (reader.Read())
                Select Case reader.NodeType
                    Case XmlNodeType.Element 'Display beginning of element.
                        'Console.Write("<" + reader.Name)
                        If reader.Name = "Lyric" Then
                            PrendiTesto = True
                        End If
                        If reader.Name = "LyricSong" Then
                            PrendiNome = True
                        End If
                        If reader.Name = "LyricArtist" Then
                            PrendiArtista = True
                        End If
                        If reader.HasAttributes Then 'If attributes exist
                            While reader.MoveToNextAttribute()
                                'Display attribute name and value.
                                'Console.Write(" {0}='{1}'", reader.Name, reader.Value)
                            End While
                        End If
                        'Console.WriteLine(">")
                    Case XmlNodeType.Text 'Display the text in each element.
                        ' Console.WriteLine(reader.Value)
                        If PrendiTesto = True Then
                            Ritorno = reader.Value
                        End If
                        If PrendiNome = True Then
                            NomeCanzone = reader.Value
                        End If
                        If PrendiArtista = True Then
                            NomeArtista = reader.Value
                        End If
                    Case XmlNodeType.EndElement 'Display end of element.
                        'Console.Write("</" + reader.Name)
                        'Console.WriteLine(">")
                        If PrendiTesto = True Then
                            PrendiTesto = False
                        End If
                        If PrendiNome = True Then
                            PrendiNome = False
                        End If
                        If PrendiArtista = True Then
                            PrendiArtista = False
                        End If
                End Select
            Loop
            'Console.ReadLine()
        End If

        If Ritorno <> "" Then
            NomeCanzone = SistemaNome(NomeCanzone)
            NomeArtista = SistemaNome(NomeArtista)

            Dim NomeCanzoneP As String = SistemaNome(Titolo)
            Dim NomeArtistaP As String = SistemaNome(Artista)

            If NomeCanzone = NomeCanzoneP And (NomeArtista = NomeArtistaP Or NomeArtista.IndexOf(NomeArtistaP) > -1) Then
                Ritorno = Ritorno.Replace(Chr(13) & Chr(10), "§")
            Else
                Ritorno = RitornaTestoCanzoneNonDiretto(Artista, Titolo)
                If Ritorno = "" Then
                    'Stop
                End If
            End If
        End If

        Return Ritorno
    End Function

    Private Function RitornaTestoCanzoneNonDiretto(Artista As String, Titolo As String)
        Dim sArtista As String = Artista
        Dim sTitolo As String = Titolo
        sArtista = sArtista.Replace(" ", "%20")
        sTitolo = sTitolo.Replace(" ", "%20")
        Dim Url As String = "http://api.chartlyrics.com/apiv1.asmx/SearchLyric?artist=" & sArtista & "&song=" & sTitolo
        Dim Ritorno As String = ""
        Dim sourceCode As String
        Dim gf As New GestioneFilesDirectory
        Dim sNomeFile As String = Application.StartupPath & "\Appoggio\Testo.xml"
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

        If TipoCollegamento.trim.toupper = "PROXY" Then
            Dim request As System.Net.HttpWebRequest = System.Net.HttpWebRequest.Create(Url)
            request.Proxy.Credentials = New System.Net.NetworkCredential(Utenza, Password, Dominio)
            request.Timeout = 7000
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
                My.Computer.Network.DownloadFile(Url, sNomeFile)
            Catch ex As Exception
                Ok = False
            End Try
        End If

        If Ok = False Then
            Return ""
        End If

        If File.Exists(sNomeFile) = True Then
            Dim reader As XmlTextReader = New XmlTextReader(sNomeFile)
            Dim PrendiNome As Boolean = False
            Dim PrendiArtista As Boolean = False
            Dim PrendiId As Boolean = False
            Dim PrendiCS As Boolean = False
            Dim NomeCanzone As String = ""
            Dim NomeArtista As String = ""
            Dim Id As String = ""
            Dim CS As String = ""

            Do While (reader.Read())
                Select Case reader.NodeType
                    Case XmlNodeType.Element 'Display beginning of element.
                        If reader.Name = "Song" Then
                            PrendiNome = True
                        End If
                        If reader.Name = "LyricChecksum" Then
                            PrendiCS = True
                        End If
                        If reader.Name = "LyricId" Then
                            PrendiId = True
                        End If
                        If reader.Name = "Artist" Then
                            PrendiArtista = True
                        End If
                        If reader.HasAttributes Then 'If attributes exist
                            While reader.MoveToNextAttribute()
                                Dim nodo As String = reader.Name
                            End While
                        End If
                    Case XmlNodeType.Text 'Display the text in each element.
                        If PrendiNome = True Then
                            NomeCanzone = reader.Value
                        End If
                        If PrendiArtista = True Then
                            NomeArtista = reader.Value
                        End If
                        If PrendiId = True Then
                            Id = reader.Value
                        End If
                        If PrendiCS = True Then
                            CS = reader.Value
                        End If
                    Case XmlNodeType.EndElement 'Display end of element.
                        If PrendiNome = True Then
                            PrendiNome = False
                        End If
                        If PrendiArtista = True Then
                            PrendiArtista = False
                        End If
                        If PrendiId = True Then
                            PrendiId = False
                        End If
                        If PrendiCS = True Then
                            PrendiCS = False
                        End If
                End Select
                If NomeArtista <> "" And NomeCanzone <> "" Then
                    NomeCanzone = SistemaNome(NomeCanzone)
                    NomeArtista = SistemaNome(NomeArtista)

                    Dim NomeCanzoneP As String = SistemaNome(Titolo)
                    Dim NomeArtistaP As String = SistemaNome(Artista)

                    If NomeCanzone = NomeCanzoneP And (NomeArtista = NomeArtistaP Or NomeArtista.IndexOf(NomeArtistaP) > -1) Then
                        Ritorno = ScaricaTestoTramiteID(Id, CS)
                        If Ritorno <> "" Then
                            Ritorno = Ritorno.Replace(Chr(13) & Chr(10), "§")
                            Exit Do
                        End If
                    End If

                    NomeArtista = ""
                    NomeCanzone = ""
                End If
            Loop
        End If

        Return Ritorno
    End Function

    Private Function ScaricaTestoTramiteID(Id As String, Cs As String) As String
        Dim Url As String = "http://api.chartlyrics.com/apiv1.asmx/GetLyric?LyricId=" & Id & "&LyricChecksum=" & Cs
        Dim Ritorno As String = ""
        Dim sourceCode As String
        Dim gf As New GestioneFilesDirectory
        Dim sNomeFile As String = Application.StartupPath & "\Appoggio\Testo.xml"
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

        If TipoCollegamento.trim.toupper = "PROXY" Then
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
                My.Computer.Network.DownloadFile(Url, sNomeFile)
            Catch ex As Exception
                Ok = False
            End Try
        End If

        If Ok = False Then
            Return ""
        End If

        If File.Exists(sNomeFile) = True Then
            Dim reader As XmlTextReader = New XmlTextReader(sNomeFile)
            Dim PrendiTesto As Boolean = False

            Do While (reader.Read())
                Select Case reader.NodeType
                    Case XmlNodeType.Element 'Display beginning of element.
                        'Console.Write("<" + reader.Name)
                        If reader.Name = "Lyric" Then
                            PrendiTesto = True
                        End If
                        If reader.HasAttributes Then 'If attributes exist
                            While reader.MoveToNextAttribute()
                                'Display attribute name and value.
                                'Console.Write(" {0}='{1}'", reader.Name, reader.Value)
                            End While
                        End If
                        'Console.WriteLine(">")
                    Case XmlNodeType.Text 'Display the text in each element.
                        ' Console.WriteLine(reader.Value)
                        If PrendiTesto = True Then
                            Ritorno = reader.Value
                        End If
                    Case XmlNodeType.EndElement 'Display end of element.
                        'Console.Write("</" + reader.Name)
                        'Console.WriteLine(">")
                        If PrendiTesto = True Then
                            PrendiTesto = False
                        End If
                End Select
            Loop
            'Console.ReadLine()
        End If

        Return Ritorno
    End Function

    Private Function SistemaNome(Nome As String) As String
        Dim Nometto As String = Nome
        Dim nc1 As String = ""
        Dim c As Integer

        Nometto = Nometto.Replace("%20", "")
        Nometto = Nometto.Replace("&", "AND")
        'If Nometto.IndexOf("(") > -1 Then
        '    Nometto = Mid(Nometto, 1, Nometto.IndexOf("("))
        'End If
        'If Nometto.IndexOf("[") > -1 Then
        '    Nometto = Mid(Nometto, 1, Nometto.IndexOf("["))
        'End If        
        For i As Integer = 1 To Nometto.Length
            c = Asc(Mid(Nometto, i, 1))
            If (c > 64 And c < 123) Or (c >= Asc("0") And c <= Asc("9")) Then
                nc1 += Mid(Nometto, i, 1).ToUpper
            End If
        Next

        Return nc1
    End Function

    Public Sub ScaricaTestoDellaCanzone(NomeCanzone As String, lstCanzone As ListBox, lstArtista As ListBox, lstTesto As ListBox)
        NomeCanzone = NomeCanzone.Replace("'", "''")

        Dim DB As SQLSERVERCE
        Dim conn As Object = CreateObject("ADODB.Connection")
        Dim Rec As Object = CreateObject("ADODB.Recordset")
        Dim Sql As String = ""
        DB = New SQLSERVERCE
        DB.ImpostaNomeDB(PathDB)
        DB.LeggeImpostazioniDiBase()
        conn = DB.ApreDB()

        'Sql = "Select * From Testi Where Canzone='" & NomeCanzone & "'"
        'Rec = DB.LeggeQuery(conn, Sql)
        If Testo = "" Then
            Dim Canzone As String = lstCanzone.Text
            If Canzone.IndexOf("-") > -1 Then
                Canzone = Mid(Canzone, Canzone.IndexOf("-") + 2, Canzone.Length)
            End If
            Dim gf As New GestioneFilesDirectory
            Canzone = Canzone.Replace(gf.TornaEstensioneFileDaPath(Canzone), "")

            Dim TestoCanzone As String = RitornaTestoCanzone(lstArtista.Text, Canzone)

            lstTesto.Items.Clear()
            If TestoCanzone <> "" Then
                Dim Righe() As String = TestoCanzone.Split("§")

                For i As Integer = 0 To Righe.Length - 1
                    lstTesto.Items.Add(Righe(i))
                Next
            Else
                TestoCanzone = "Nessun testo rilevato"

                lstTesto.Items.Add(TestoCanzone)
            End If

            'Sql = "Insert Into Testi Values (" & _
            '    "'" & NomeCanzone & "', " & _
            '    "'" & TestoCanzone.Replace("'", "''") & "' " & _
            '    ")"
            Sql = "Update ListaCanzone2 Set Testo='" & TestoCanzone.Replace("'", "''") & "' Where idCanzone=" & idCanzone
            DB.EsegueSql(conn, Sql)
        End If
        'Rec.Close()
        conn.Close()
        DB = Nothing
    End Sub

    Public Sub RitornaTestoCanzone(NomeCanzone As String, lstTesto As ListBox, ScaricaTestoSeNonLoTrova As Boolean, PathMP3 As String)
        NomeCanzone = NomeCanzone.Replace("'", "''")

        Dim DB As SQLSERVERCE
        Dim conn As Object = CreateObject("ADODB.Connection")
        Dim Rec As Object = CreateObject("ADODB.Recordset")
        Dim Sql As String = ""
        DB = New SQLSERVERCE
        DB.ImpostaNomeDB(PathDB)
        DB.LeggeImpostazioniDiBase()
        conn = DB.ApreDB()
        Sql = "Select * From Testi Where Canzone='" & NomeCanzone & "'"
        Rec = DB.LeggeQuery(conn, Sql)
        If Rec.Eof = False Then
            Dim Righe() As String = Rec("Testo").Value.ToString.Split("§")

            lstTesto.Items.Clear()
            For i As Integer = 0 To Righe.Length - 1
                lstTesto.Items.Add(Righe(i))
            Next
        Else
            If ScaricaTestoSeNonLoTrova = True Then
                Dim gf As New GestioneFilesDirectory
                Dim Canzone As String = NomeCanzone
                Canzone = gf.TornaNomeFileDaPath(Canzone)
                If Canzone.IndexOf("-") > -1 Then
                    Canzone = Mid(Canzone, Canzone.IndexOf("-") + 2, Canzone.Length)
                End If
                Canzone = Canzone.Replace(gf.TornaEstensioneFileDaPath(Canzone), "")
                Dim Campi() As String = NomeCanzone.Replace(PathMP3 & "\", "").Split("\")
                Dim Artista As String = Campi(0)

                Artista = Artista.Replace("_", " ")
                Artista = Artista.Replace(" ", "%20")
                Artista = Artista.Replace("''", "'")

                If Canzone.IndexOf("(") > -1 Then
                    Canzone = Mid(Canzone, 1, Canzone.IndexOf("("))
                End If
                Canzone = Canzone.Replace("_", " ")
                Canzone = Canzone.Replace(" ", "%20")
                Canzone = Canzone.Replace("''", "'")
                Dim TestoCanzone As String = RitornaTestoCanzone(Artista, Canzone)

                lstTesto.Items.Clear()
                If TestoCanzone <> "" Then
                    Dim Righe() As String = TestoCanzone.Split("§")

                    For i As Integer = 0 To Righe.Length - 1
                        lstTesto.Items.Add(Righe(i))
                    Next
                Else
                    TestoCanzone = "Nessun testo rilevato"

                    lstTesto.Items.Add(TestoCanzone)
                End If

                Sql = "Insert Into Testi Values (" & _
                    "'" & NomeCanzone & "', " & _
                    "'" & TestoCanzone.Replace("'", "''") & "' " & _
                    ")"
                DB.EsegueSql(conn, Sql)
            End If
        End If
        Rec.Close()
        conn.Close()
        DB = Nothing
    End Sub

End Class
