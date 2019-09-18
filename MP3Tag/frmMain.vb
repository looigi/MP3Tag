Imports System.Xml.XPath
Imports System.Xml
Imports System.Net
Imports System.IO
Imports System.Text
Imports System.Text.RegularExpressions
Imports System.Runtime.InteropServices
Imports Thumbnailer

Public Class frmMain
    Private qAliasCompleti As Integer
    Private AliasCompleti() As String
    Private qAliasParziali As Integer
    Private AliasParziali() As String

    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        PathDB = Application.StartupPath & "\DB\MP3Tag.sdf"

        chkUguali.Checked = GetSetting("MP3Tag", "Impostazioni", "Uguali", True)
        chkSposta.Checked = GetSetting("MP3Tag", "Impostazioni", "Smista", True)

        lblPathOrigine.Text = GetSetting("MP3Tag", "Impostazioni", "PercorsoOrigine", "")
        lblPathDestinazione.Text = GetSetting("MP3Tag", "Impostazioni", "PercorsoDestinazione", "")

        Utenza = GetSetting("MP3Tag", "Settaggi", "Utenza", "")
        Password = GetSetting("MP3Tag", "Settaggi", "Password", "")
        Dominio = GetSetting("MP3Tag", "Settaggi", "Dominio", "")
        TipoCollegamento = GetSetting("MP3Tag", "Settaggi", "TipoCollegamento", "Normale")

        Dim Player As Boolean = GetSetting("MP3Tag", "Impostazioni", "PlayerDiretto", False)

        Dim tt As New ToolTip()

        tt.SetToolTip(picUguali, "Apre la maschera di gestione degli MP3 uguali")
        tt.SetToolTip(picSenzaTag, "Apre la maschera di gestione degli MP3 senza TAG")
        tt.SetToolTip(picConTAG, "Apre la maschera di gestione degli MP3 con i TAG")
        tt.SetToolTip(picSettings, "Apre la maschera di gestione delle impostazioni")
        tt.SetToolTip(picPlayer, "Apre la maschera del Player MP3")
        tt.SetToolTip(picEsegue, "Esegue la routine di sistemazione")

        lblAggiornamento.Text = ""
        lblCopiati.Text = ""
        LeggeFiles()

        Dim u As UpdateDB = New UpdateDB
        u.ControllaAggiornamentoDB()

        CreaTabellaImmaginiSalvateSeNonEsiste()
        ControllaAttivazionePulsanteEsegue()
        ControllaSeCiSonoUguali()

        If Player = True Then
            Timer1.Enabled = True
        End If
    End Sub

    Private Sub CreaTabellaImmaginiSalvateSeNonEsiste()
        If File.Exists(PathDB) Then
            Dim Creata As Boolean = False
            Dim DB As New SQLSERVERCE
            Dim conn As Object = CreateObject("ADODB.Connection")
            Dim rec As Object = CreateObject("ADODB.Recordset")
            Dim Sql As String
            DB.ImpostaNomeDB(PathDB)
            DB.LeggeImpostazioniDiBase()
            conn = DB.ApreDB()

            Sql = "Select * From ImmaginiSalvate"
            rec = DB.LeggeQuery(conn, Sql)
            If rec Is Nothing = True Then
                Sql = "Create Table ImmaginiSalvate (Immagine nvarchar(255) Not Null, CONSTRAINT PK_ImmaginiSalvate PRIMARY KEY(Immagine))"
                Creata = True
            Else
                Sql = ""
            End If
            Try
                rec.Close()
            Catch ex As Exception

            End Try

            If Sql <> "" Then
                DB.EsegueSql(conn, Sql)
            End If

            If File.Exists(Application.StartupPath & "\ImmaginiSalvate.Txt") Then
                Dim gf As New GestioneFilesDirectory
                Dim r As New RoutineVarie
                Dim DiscoPath As String = Mid(lblPathOrigine.Text, 1, 2)
                Dim Salvate As String = gf.LeggeFileIntero(Application.StartupPath & "\ImmaginiSalvate.Txt")
                Dim Righe() As String = Salvate.Split(DiscoPath)
                For Each Rr As String In Righe
                    If Rr <> "" Then
                        Sql = "Insert Into ImmaginiSalvate Values ('" & r.SistemaTestoPerDB(Mid(DiscoPath, 1, 1) & Rr) & "')"
                        DB.EsegueSql(conn, Sql)
                    End If
                Next
                gf.EliminaFileFisico(Application.StartupPath & "\ImmaginiSalvate.Txt")
            End If

            conn.Close()
            DB = Nothing
        End If
    End Sub

    Private Sub ControllaSeCiSonoUguali()
        If File.Exists(PathDB) Then
            Dim DB As New SQLSERVERCE
            Dim conn As Object = CreateObject("ADODB.Connection")
            Dim rec As Object = CreateObject("ADODB.Recordset")
            Dim Sql As String
            DB.ImpostaNomeDB(PathDB)
            DB.LeggeImpostazioniDiBase()
            conn = DB.ApreDB()

            Sql = "Select * From Uguali"
            rec = DB.LeggeQuery(conn, Sql)
            If rec.Eof = True Then
                picUguali.Visible = False
            Else
                picUguali.Visible = True
            End If
            rec.Close()

            conn.Close()
            DB = Nothing
        End If
    End Sub

    Private Sub LeggeFiles()
        If File.Exists(PathDB) Then
            Dim DB As New SQLSERVERCE
            Dim conn As Object = CreateObject("ADODB.Connection")
            Dim rec As Object = CreateObject("ADODB.Recordset")
            Dim Sql As String
            DB.ImpostaNomeDB(PathDB)
            DB.LeggeImpostazioniDiBase()
            conn = DB.ApreDB()

            Sql = "Select * From AliasCartelle"
            rec = DB.LeggeQuery(conn, Sql)
            Do Until rec.Eof
                ReDim Preserve AliasCompleti(qAliasCompleti)
                AliasCompleti(qAliasCompleti) = rec("Cartella").Value & ";" & rec("Diventa").Value
                qAliasCompleti += 1

                rec.MoveNext()
            Loop
            rec.Close()

            Sql = "Select * From AliasCartelleContenuto"
            rec = DB.LeggeQuery(conn, Sql)
            Do Until rec.Eof
                ReDim Preserve AliasParziali(qAliasParziali)
                AliasParziali(qAliasParziali) = rec("Contenuto").Value & ";" & rec("Destinazione").Value
                qAliasParziali += 1

                rec.MoveNext()
            Loop
            rec.Close()

            conn.Close()
            DB = Nothing
        Else
            MsgBox("Path DB non trovato: " & vbCrLf & vbCrLf & PathDB)
            End
        End If
    End Sub

    Private Sub cmdEsegue_Click(sender As Object, e As EventArgs) Handles picEsegue.Click
        Me.Cursor = Cursors.WaitCursor

        pnlOperazioni.Visible = True

        If chkSposta.Checked = True Then
            SmistaMP3()
        End If

        If chkUguali.Checked = True Then
            ControllaUguali()
        End If

        lblCopiati.Text = ""

        Dim gf As New GestioneFilesDirectory
        lblAggiornamento.Text = "Pulizia cartelle vuote origine"
        gf.PulisceCartelleVuote(lblPathOrigine.Text)

        lblAggiornamento.Text = "Pulizia cartelle vuote destinazione"
        gf.PulisceCartelleVuote(lblPathDestinazione.Text)

        lblAggiornamento.Text = "Creazione cartella origine"
        gf.CreaDirectoryDaPercorso(lblPathOrigine.Text & "\")
        gf = Nothing

        lblAggiornamento.Text = ""
        lblCopiati.Text = ""

        pnlOperazioni.Visible = False

        Me.Cursor = Cursors.Default

        MsgBox("Elaborazione completata")
    End Sub

    Private Sub SmistaMP3()
        Dim gf As New GestioneFilesDirectory
        Dim m As New MP3Tag

        gf.ScansionaDirectorySingola(lblPathOrigine.Text, "", lblAggiornamento)
        Dim Filetti() As String = gf.RitornaFilesRilevati
        Dim qFiles As Integer = gf.RitornaQuantiFilesRilevati

        Dim Tags As TagLib.File
        Dim title As String = ""
        Dim album As String = ""
        Dim length As String = ""
        Dim traccia As String = ""
        Dim anno As String = ""
        Dim artista As String = ""
        Dim estensione As String = ""
        Dim pathDest As String
        Dim spostati As Integer = 0
        Dim skippati As Integer = 0
        Dim wma As Integer = 0
        Dim dire() As String
        Dim qd As Integer
        Dim album2 As String
        Dim modificato As Boolean

        For i As Integer = 1 To qFiles
            estensione = gf.TornaEstensioneFileDaPath(Filetti(i))

            Select Case estensione.ToUpper.Trim
                Case ".MP3", ".WMA"
                    If Filetti(i).Length > 60 Then
                        lblAggiornamento.Text = Mid(Filetti(i), 1, 27) & "..." & Mid(Filetti(i), Filetti(i).Length - 26, 27)
                    Else
                        lblAggiornamento.Text = Filetti(i)
                    End If
                    Application.DoEvents()

                    title = ""
                    album = ""
                    length = ""
                    traccia = ""
                    anno = ""
                    artista = ""

                    Tags = m.TornaTagDaMP3(Filetti(i))

                    If Tags Is Nothing = True Then
                        ' Tag non presente. Tento di scriverli
                        RiempieICampiDalNomeDelFile(Filetti(i), artista, album, traccia, title, anno)

                        m.ImpostaTag(Filetti(i), title, album, artista, anno, traccia)
                    Else
                        title = Tags.Tag.Title
                        album = Tags.Tag.Album
                        length = Tags.Properties.Duration.ToString()
                        traccia = Tags.Tag.Track
                        anno = Tags.Tag.Year
                        artista = m.TornaArtista(Tags)

                        If artista = "" Or album = "" Or traccia = "" Or traccia = "0" Or title = "" Then
                            RiempieICampiDalNomeDelFile(Filetti(i), artista, album, traccia, title, anno)

                            m.ImpostaTag(Filetti(i), title, album, artista, anno, traccia)
                        End If
                    End If

                    If artista = "" Or artista Is Nothing Then
                        artista = "ZZZ-SenzaTAG"
                    End If
                    If album = "" Or album Is Nothing Then
                        album = "Album sconosciuto"
                    End If

                    If artista <> "" And album <> "" Then
                        artista = m.SistemaNomeFile(artista, True)
                        album = m.SistemaNomeFile(album, True)

                        For k As Integer = anno.Length + 1 To 4
                            anno = "0" & anno
                        Next

                        modificato = False
                        If anno = "0000" Then
                            ' Controlla se già esiste il nome del disco
                            pathDest = lblPathDestinazione.Text & "\" & artista
                            If Directory.Exists(pathDest) = True Then
                                gf.ScansionaDirectorySingola(pathDest)
                                dire = gf.RitornaDirectoryRilevate
                                qd = gf.RitornaQuanteDirectoryRilevate
                                For k As Integer = 2 To qd
                                    album2 = gf.TornaNomeFileDaPath(dire(k))
                                    If album2.IndexOf(album) > -1 Then
                                        If Mid(album2, 1, 5) <> "0000-" Then
                                            album = album2
                                            anno = Mid(album, 1, 4)
                                            modificato = True
                                            Exit For
                                        Else
                                            'If anno <> "" Then
                                            '    album = anno & "-" & album
                                            '    modificato = True
                                            '    Exit For
                                            'Else
                                            'Stop
                                            'End If
                                        End If
                                    End If
                                Next
                            End If
                            ' Controlla se già esiste il nome del disco
                        End If

                        traccia = Format(Val(traccia), "00")
                        title = m.SistemaNomeFile(title, False)

                        Dim artista2 As String = ImpostaAlias(artista)

                        If artista2 <> artista Then
                            artista = artista2

                            m.ImpostaTag(Filetti(i), title, album, artista, anno, traccia)
                        End If

                        If anno <> "0000" Then
                            If modificato = True Then
                                pathDest = lblPathDestinazione.Text & "\" & artista & "\" & album & "\"
                            Else
                                pathDest = lblPathDestinazione.Text & "\" & artista & "\" & anno & "-" & album & "\"
                            End If
                        Else
                            If modificato = True Then
                                pathDest = lblPathDestinazione.Text & "\" & artista & "\" & album & "\"
                            Else
                                pathDest = lblPathDestinazione.Text & "\" & artista & "\0000-" & album & "\"
                            End If
                        End If
                        pathDest = pathDest.Replace(" - ", "-")
                        pathDest = pathDest.Replace("- ", "-")
                        pathDest = pathDest.Replace(" -", "-")

                        gf.CreaDirectoryDaPercorso(pathDest)

                        pathDest += traccia & "-" & title & estensione
                        If File.Exists(pathDest) = False Then
                            spostati += 1

                            lblCopiati.Text = "Elab.: " & i & "/" & qFiles & " - Spostati: " & spostati & " - Skippati: " & skippati & " - WMA:" & wma
                            Application.DoEvents()

                            FileCopy(Filetti(i), pathDest)

                            gf.EliminaFileFisico(Filetti(i))
                        Else
                            gf.EliminaFileFisico(Filetti(i))
                        End If
                    Else
                        ' Artista e album sconosciuto... Non dovrebbe mai entrare qui dentro
                        skippati += 1

                        lblCopiati.Text = "Spostati: " & spostati & " - Skippati: " & skippati & " - WMA: " & wma
                        Application.DoEvents()

                        pathDest = lblPathDestinazione.Text & "\ZZZ-SenzaTAG\" & Filetti(i).Replace(lblPathOrigine.Text & "\", "")
                        gf.CreaDirectoryDaPercorso(gf.TornaNomeDirectoryDaPath(pathDest))
                        FileCopy(Filetti(i), pathDest)

                        gf.EliminaFileFisico(Filetti(i))
                    End If
                    'Case ".WMA"
                    '    wma += 1

                    '    lblCopiati.Text = "Spostati: " & spostati & " - Skippati: " & skippati & " - WMA: " & wma
                    '    Application.DoEvents()

                    '    pathDest = lblPathDestinazione.Text & "\ZZZ-WMA\" & Filetti(i).Replace(lblPathOrigine.Text & "\", "")
                    '    gf.CreaDirectoryDaPercorso(gf.TornaNomeDirectoryDaPath(pathDest) & "\")
                    '    FileCopy(Filetti(i), pathDest)
                    '    gf.EliminaFileFisico(Filetti(i))
            End Select
        Next

        gf = Nothing
    End Sub

    Private Sub ControllaUguali()
        Dim DB As New SQLSERVERCE
        Dim conn As Object = CreateObject("ADODB.Connection")
        Dim Sql As String
        DB.ImpostaNomeDB(PathDB)
        DB.LeggeImpostazioniDiBase()
        conn = DB.ApreDB()

        Sql = "Delete From Uguali"
        DB.EsegueSql(conn, Sql)

        Dim gf As New GestioneFilesDirectory
        gf.ScansionaDirectorySingola(lblPathDestinazione.Text & "\")
        Dim Filetti() As String = gf.RitornaFilesRilevati
        Dim qFiles As Integer = gf.RitornaQuantiFilesRilevati
        Dim PrimoNome As String = ""
        Dim SecondoNome As String = ""
        Dim Rilevati As Integer = 0

        lblAggiornamento.Text = "Controlla uguali"
        Application.DoEvents()

        'gf.ApreFileDiTestoPerScrittura(Application.StartupPath & "\Uguali.txt")

        For i As Integer = 1 To qFiles
            PrimoNome = gf.TornaNomeFileDaPath(Filetti(i))
            PrimoNome = Mid(PrimoNome, 1, PrimoNome.IndexOf(".")).Trim.ToUpper
            If PrimoNome.IndexOf("-") > -1 Then
                PrimoNome = Mid(PrimoNome, PrimoNome.IndexOf("-") + 2, PrimoNome.Length)
            End If

            lblCopiati.Text = "Controllo: " & i & "/" & qFiles & " - Rilevati: " & Rilevati
            Application.DoEvents()

            For k As Integer = i + 1 To qFiles
                SecondoNome = gf.TornaNomeFileDaPath(Filetti(k))
                SecondoNome = Mid(SecondoNome, 1, SecondoNome.IndexOf(".")).Trim.ToUpper
                If SecondoNome.IndexOf("-") > -1 Then
                    SecondoNome = Mid(SecondoNome, SecondoNome.IndexOf("-") + 2, SecondoNome.Length)
                End If

                If PrimoNome = SecondoNome Then
                    Rilevati += 1

                    Sql = "Insert Into Uguali Values (" &
                        " " & Rilevati & ", " &
                        "'" & Filetti(i).Replace("'", "''") & "', " &
                        "'" & Filetti(k).Replace("'", "''") & "' " &
                        ")"
                    DB.EsegueSql(conn, Sql)
                End If
            Next
        Next

        conn.Close()

        If Rilevati > 0 Then
            picUguali.Visible = True
        Else
            picUguali.Visible = False
        End If

        DB = Nothing
        gf = Nothing
    End Sub

    Private Sub RiempieICampiDalNomeDelFile(NomeFiletto As String, ByRef artista As String, ByRef album As String, ByRef traccia As String, ByRef title As String, ByRef anno As String)
        Dim p() As String = NomeFiletto.Replace(lblPathOrigine.Text & "\", "").Split("\")

        If p.Length > 2 Then
            If artista = "" Then
                If p(0) <> "" Then
                    artista = p(0)
                End If
            End If
            If album = "" Then
                If p(1) <> "" Then
                    album = p(1)
                    If Mid(album, 5, 1) = "-" Then
                        anno = Mid(album, 1, album.IndexOf("-"))
                        album = Mid(album, 6, album.Length)
                    Else
                        anno = "0000"
                    End If
                End If
            End If
            If traccia = "" Or traccia = "0" Then
                traccia = p(2)
                If traccia.IndexOf("-") > -1 Or traccia.IndexOf(".") > -1 Then
                    If traccia.IndexOf("-") > -1 Then
                        traccia = Mid(traccia, 1, traccia.IndexOf("-"))
                    Else
                        traccia = Mid(traccia, 1, traccia.IndexOf("."))
                    End If
                    traccia = traccia.Trim
                Else
                    traccia = "00"
                End If
            End If
            If title = "" Then
                title = p(2)
                If title.IndexOf("-") > -1 Then
                    title = Mid(title, title.IndexOf("-") + 2, title.Length)
                End If
                If title.IndexOf(".") > -1 Then
                    title = Mid(title, 1, title.IndexOf("."))
                End If
            End If
        End If
    End Sub

    Private Function ImpostaAlias(Nome As String) As String
        Dim Ritorno As String = Nome
        Dim Campi() As String

        For i As Integer = 0 To qAliasCompleti - 1
            Campi = AliasCompleti(i).Split(";")
            If Ritorno.Trim.ToUpper = Campi(0).Trim.ToUpper Then
                Ritorno = Campi(1)
                Exit For
            End If
        Next

        For i As Integer = 0 To qAliasParziali - 1
            Campi = AliasParziali(i).Split(";")
            If Ritorno.Trim.ToUpper.IndexOf(Campi(0).Trim.ToUpper) > -1 Then
                Ritorno = Campi(1)
                Exit For
            End If
        Next

        Return Ritorno
    End Function


    Private Sub ControllaAttivazionePulsanteEsegue()
        picEsegue.Enabled = True
        If lblPathDestinazione.Text = "" Or lblPathOrigine.Text = "" Then
            picEsegue.Enabled = False
        Else
            If lblPathDestinazione.Text = lblPathOrigine.Text Then
                picEsegue.Enabled = False
            End If
        End If
    End Sub

    'MsgBox(FindArtistId("Firehouse"))

    'Public Function FindArtistId(ByVal name As String) As String
    '    Try
    '        Dim uri As String = String.Format(" http://musicbrainz.org/ws/2/artist?query={0}&type=xml", name)
    '        Dim doc As XPathDocument = New XPathDocument(uri)
    '        Dim nav As XPathNavigator = doc.CreateNavigator()
    '        Dim nsmgr As XmlNamespaceManager = New XmlNamespaceManager(nav.NameTable)
    '        nsmgr.AddNamespace("mb", "http://musicbrainz.org/ns/mmd-1.0#")
    '        Dim xpath As String = String.Format("//mb:artist[mb:name=""{0}""]", name) 'The artist name is case-sensitive!
    '        Dim ni As XPathNodeIterator = nav.Select(xpath, nsmgr)
    '        If ni.MoveNext() Then Return Nothing
    '        Dim current As XPathNavigator = ni.Current
    '        Return current.GetAttribute("id", nsmgr.DefaultNamespace)
    '    Catch wex As WebException
    '        MessageBox.Show(String.Format("A communication error occurred ({0}). The MusicBrainz server might be down.", wex.Status), "Couldn't resolve artist name")
    '        Return Nothing
    '    Catch ex As Exception
    '        MessageBox.Show(String.Format("An error occurred ({0}). The error may have been caused by bad data from the MusicBrainz server.", ex.Message), "Couldn't resolve artist name")
    '        Return Nothing
    '    End Try
    'End Function

    Private Sub cmdSceglieOrigine_Click(sender As Object, e As EventArgs) Handles cmdSceglieOrigine.Click
        If (FolderBrowserDialog1.ShowDialog() = DialogResult.OK) Then
            Dim Percorso As String = FolderBrowserDialog1.SelectedPath
            lblPathOrigine.Text = Percorso
            SaveSetting("MP3Tag", "Impostazioni", "PercorsoOrigine", Percorso)

            ControllaAttivazionePulsanteEsegue()
        End If
    End Sub

    Private Sub cmdSceglieDest_Click(sender As Object, e As EventArgs) Handles cmdSceglieDest.Click
        If (FolderBrowserDialog1.ShowDialog() = DialogResult.OK) Then
            Dim Percorso As String = FolderBrowserDialog1.SelectedPath
            lblPathDestinazione.Text = Percorso
            SaveSetting("MP3Tag", "Impostazioni", "PercorsoDestinazione", Percorso)

            ControllaAttivazionePulsanteEsegue()
        End If
    End Sub

    Private Sub chkUguali_CheckedChanged(sender As Object, e As EventArgs) Handles chkUguali.CheckedChanged
        SaveSetting("MP3Tag", "Impostazioni", "Uguali", chkUguali.Checked)
    End Sub

    Private Sub chkSposta_CheckedChanged(sender As Object, e As EventArgs) Handles chkSposta.CheckedChanged
        SaveSetting("MP3Tag", "Impostazioni", "Smista", chkSposta.Checked)
    End Sub

    Private Sub cmdUguali_Click(sender As Object, e As EventArgs) Handles picUguali.Click
        frmUguali.Show()
        Me.Hide()
    End Sub

    Private Sub cmdSenzaTAG_Click(sender As Object, e As EventArgs) Handles picSenzaTag.Click
        frmSenzaTAG.ImpostaPercorso(lblPathDestinazione.Text)
        frmSenzaTAG.Show()
        Me.Hide()
    End Sub

    Private Sub cmdGestioneSistemati_Click(sender As Object, e As EventArgs) Handles picConTAG.Click
        frmConTAG.ImpostaPercorso(lblPathDestinazione.Text)
        frmConTAG.DaDoveVengo("MAIN")
        frmConTAG.Show()
        Me.Hide()
    End Sub

    Private Sub cmdPlay_Click(sender As Object, e As EventArgs) Handles picPlayer.Click
        frmPlayer.Show()
        Me.Hide()
    End Sub

    Private Sub cmdImpostazioni_Click(sender As Object, e As EventArgs) Handles picSettings.Click
        frmSettaggi.Show()
    End Sub

    Private Sub picUscita_Click(sender As Object, e As EventArgs) Handles picUscita.Click
        End
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Call cmdPlay_Click(sender, e)
    End Sub

	'Private Declare Function mciSendString Lib "winmm.dll" Alias "mciSendStringA" (ByVal lpstrCommand As String, ByVal lpstrReturnString As String, ByVal uReturnLength As Long, ByVal hwndCallback As Long) As Long

	Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
		'Dim DB As New SQLSERVERCE
		'Dim conn As Object = CreateObject("ADODB.Connection")
		'Dim rec As Object = CreateObject("ADODB.Recordset")
		''Dim rec2 As Object = CreateObject("ADODB.Recordset")
		'Dim Sql As String
		Dim gf As New GestioneFilesDirectory
		''Dim Canzone As String = ""
		''Dim Bellezza As String = ""
		'DB.ImpostaNomeDB(PathDB)
		'DB.LeggeImpostazioniDiBase()
		'conn = DB.ApreDB()

		'Sql = "Delete From ImmaginiEliminate"
		'DB.EsegueSql(conn, Sql)

		gf.ScansionaDirectorySingola(lblPathDestinazione.Text)
		Dim filetti() As String = gf.RitornaFilesRilevati
		Dim qf As Integer = gf.RitornaQuantiFilesRilevati

		For i As Integer = 1 To qf
			Dim filetto As String = filetti(i)
			'	filetto = filetto.Replace(lblPathDestinazione.Text & "\", "")
			If filetto.ToUpper.EndsWith(".DAT") Then
				Dim este As String = gf.TornaEstensioneFileDaPath(filetto)
				If este.Length < 5 Then
					filetto = filetto.Replace(este, "")
				End If

				If Not File.Exists(filetto) Then
					If Not filetto.ToUpper.Contains(".JPG") Then
						filetto &= ".jpg"
					End If
					File.Copy(filetti(i), filetto)
				Else
					Dim nomefile As String = gf.TornaNomeFileDaPath(filetto)
					Dim cart As String = gf.TornaNomeDirectoryDaPath(filetto)

					filetto = cart & "\" & Now.Second & "_" & nomefile & ".jpg"
					File.Copy(filetti(i), filetto)
				End If
				File.Delete(filetti(i))
				'		este = gf.TornaEstensioneFileDaPath(filetto)
				'		filetto = filetto.Replace(este, "")

				'		Sql = "Insert Into ImmaginiEliminate Values ('" & filetto.Replace("'", "''") & "')"
				'		DB.EsegueSql(conn, Sql)

				'		File.Delete(filetti(i))
			Else
				If Not filetto.Contains(".") Then
					If Not File.Exists(filetto & ".jpg") Then
						filetto &= ".jpg"
					Else
						filetto &= "_" & Now.Second & ".jpg"
					End If
					File.Copy(filetti(i), filetto)
					File.Delete(filetti(i))
				End If
			End If
		Next

		'Sql = "Select * From ListaCanzone2 Where Testo is null"
		'rec = DB.LeggeQuery(conn, Sql)
		'Do Until rec.Eof
		'    Canzone = Replace(rec("Artista").Value, "'", "''") & "\" & Replace(rec("Album").Value, "'", "''") & "\" & Replace(rec("Canzone").Value, "'", "''")
		'    Sql = "Select * From Testi Where Canzone='" & Canzone & "'"
		'    rec2 = DB.LeggeQuery(conn, Sql)
		'    If Not rec2.Eof Then
		'        Bellezza = rec2("Testo").Value

		'        Sql = "Update ListaCanzone2 Set Testo='" & Bellezza.Replace("'", "''") & "' Where idCanzone=" & rec("idCanzone").Value
		'        DB.EsegueSql(conn, Sql)
		'    End If
		'    rec2.Close()

		'    Sql = "Select * From Traduzioni Where Canzone='" & Canzone & "'"
		'    rec2 = DB.LeggeQuery(conn, Sql)
		'    If Not rec2.Eof Then
		'        Bellezza = rec2("Testo").Value

		'        Sql = "Update ListaCanzone2 Set TestoTradotto='" & Bellezza.Replace("'", "''") & "' Where idCanzone=" & rec("idCanzone").Value
		'        DB.EsegueSql(conn, Sql)
		'    End If
		'    rec2.Close()

		'    rec.MoveNext()
		'Loop
		'rec.Close()

		'conn.Close()
		'DB = Nothing

		'Panel1.Visible = True
		'Dim v As New Video(Application.StartupPath & "\VideoYouTube\322dPZSs6No.mp4")
		'v.Owner = Panel1
		'v.Play()

		'AxMediaPlayer1.FileName = "C:\movie1.avi"
		'AxMediaPlayer1.Play()
		'AxMediaPlayer1.ShowControls = False
		'AxMediaPlayer1.AllowChangeDisplaySize = False
		'AxMediaPlayer1.EnableContextMenu = False
		'AxMediaPlayer1.ClickToPlay = False
		'AxMediaPlayer1.SendKeyboardEvents = False

		'Dim filename As String = Application.StartupPath & "\VideoYouTube\322dPZSs6No.avi"
		'Dim retVal As Integer

		'filename = Chr(34) & filename & Chr(34)

		'retVal = mciSendString("open mpegvideo!" & filename & " alias myMovie parent " & Me.Handle.ToInt32 & " style child", vbNullString, 128, IntPtr.Zero)
		'retVal = mciSendString("put movie window at 0 0 50 50", 0, 128, 0)
		'retVal = mciSendString("play myMovie", vbNullString, 128, IntPtr.Zero)
	End Sub
End Class
