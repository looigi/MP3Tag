Imports System.Threading
Imports System.IO

Public Class LetturaCanzoni
    Private instance As Form
    Private tmrLetturaCanzoni As System.Timers.Timer = Nothing
    Private trd As Thread

    Private Delegate Sub DelegatePulisce()
    Private MethodDelegatePulisce As New DelegatePulisce(AddressOf PulisceCampi)
    Private llblAggiornamentoCanzoni As Label
    Private cchkRandom As CheckBox
    Private cchkUltime As CheckBox
    Private cchkPrime As CheckBox

    Private Sub PulisceCampi()
        llblAggiornamentoCanzoni.Visible = False
        'cchkRandom.Enabled = True
        cchkUltime.Enabled = True
        cchkPrime.Enabled = True
    End Sub

    Public Sub New(inst As Form)
        instance = inst
    End Sub

    Public Sub LeggeCanzoniInBackground()
        'tmrLetturaCanzoni = New System.Timers.Timer(1000)
        'AddHandler tmrLetturaCanzoni.Elapsed, AddressOf tmrThread_Tick
        'tmrLetturaCanzoni.Start()

        StrutturaDati.lblAggiornamentoCanzoni.Visible = True
        'StrutturaDati.chkRandom.Enabled = False
        StrutturaDati.chkUltime.Enabled = False
        StrutturaDati.chkPrime.Enabled = False

        llblAggiornamentoCanzoni = StrutturaDati.lblAggiornamentoCanzoni
        cchkRandom = StrutturaDati.chkRandom
        cchkUltime = StrutturaDati.chkUltime
        cchkPrime = StrutturaDati.chkPrime

        'trd = New Thread(AddressOf LeggeCanzoniThread)
        'trd.IsBackground = True
        'trd.Start()

        LeggeCanzoniThread()
    End Sub

    'Private Sub tmrThread_Tick(sender As Object, e As EventArgs)
    '    If trd.IsAlive = False Then
    '        If instance.InvokeRequired Then
    '            instance.Invoke(MethodDelegatePulisce)
    '        End If

    '        tmrLetturaCanzoni = Nothing
    '    End If
    '    Application.DoEvents()
    'End Sub

    Public Sub LeggeCanzoniThread(Optional Cosa As String = "", Optional sender As Object = Nothing, Optional e As EventArgs = Nothing)
        Dim DB As New SQLSERVERCE
        Dim conn As Object = CreateObject("ADODB.Connection")
        Dim rec As Object = CreateObject("ADODB.Recordset")
        Dim Sql As String
        DB.ImpostaNomeDB(PathDB)
        DB.LeggeImpostazioniDiBase()
        conn = DB.ApreDB()

        Dim gf As New GestioneFilesDirectory
        Dim r As New RoutineVarie

        gf.ScansionaDirectorySingola(StrutturaDati.PathMP3, StrutturaDati.FiltroRicerca)

        Dim Filetti() As String = gf.RitornaFilesRilevati
        Dim qFiles As Integer = gf.RitornaQuantiFilesRilevati
        Dim NomeCartella As String = ""
        Dim NomeFile As String = ""
        Dim Campi() As String = {}
        Dim Datella As Date
        Dim sDatella As String = ""
        Dim f As FileInfo = Nothing

        If Cosa <> "" Then
            Erase StrutturaDati.Canzoni
            StrutturaDati.qCanzoni = qFiles
            ReDim StrutturaDati.Canzoni(StrutturaDati.qCanzoni)
        End If

        Dim conta As Integer = 0

        Sql = "Select max(idCanzone)+1 From ListaCanzone2"
        rec = DB.LeggeQuery(conn, Sql)
        If rec(0).Value Is DBNull.Value Then
            conta = 1
        Else
            conta = rec(0).Value
        End If
        'rec.Close()

        For i As Integer = 1 To qFiles
            Campi = Filetti(i).Replace(StrutturaDati.PathMP3 & "\", "").Split("\")

            If (Filetti(i).ToUpper.Contains(".MP3") Or Filetti(i).ToUpper.Contains(".WMA")) And File.Exists(Filetti(i)) Then
                Datella = FileDateTime(Filetti(i))
                f = New FileInfo(Filetti(i))
                Datella = f.CreationTime
                sDatella = r.ConverteDataPerDB(Datella)

                Sql = "Select * From ListaCanzone2 Where Artista='" & r.SistemaTestoPerDB(Campi(0)) & "' And Album='" & r.SistemaTestoPerDB(Campi(1)) & "' And Canzone='" & r.SistemaTestoPerDB(Campi(2)) & "'"
                rec = DB.LeggeQuery(conn, Sql)
                If rec.Eof Then
                    Try
                        Sql = "Insert Into ListaCanzone2 Values (" &
                            " " & conta & ", " &
                            "'" & r.SistemaTestoPerDB(Campi(0)) & "', " &
                            "'" & r.SistemaTestoPerDB(Campi(1)) & "', " &
                            "'" & r.SistemaTestoPerDB(Campi(2)) & "', " &
                            " " & sDatella & ", " &
                            "0, " &
                            "0, " &
                            "'', " &
                            "'')"
                        DB.EsegueSql(conn, Sql)

                        conta += 1
                    Catch ex As Exception
                        Cosa = ""
                    End Try
                End If
                ' rec.Close()

                If Cosa <> "" Then
                    ReDim Preserve StrutturaDati.Canzoni(i)
                    StrutturaDati.Canzoni(i) = Filetti(i)
                End If
            End If

            Application.DoEvents()
        Next

        Dim Canzone As String = ""

        Sql = "Select * From ListaCanzone2"
        rec = DB.LeggeQuery(conn, Sql)
        Do Until rec.Eof
            Canzone = StrutturaDati.PathMP3 & "\" & rec("Artista").Value & "\" & rec("Album").Value & "\" & rec("Canzone").Value
            If Not File.Exists(Canzone) Then
                Sql = "Delete From ListaCanzone2 Where idCanzone=" & rec("idCanzone").Value
                DB.EsegueSql(conn, Sql)
            End If

            rec.MoveNext()
        Loop
        ' rec.Close()

        conn.Close()
        DB = Nothing

        If Cosa <> "" Then
            CaricaTutteLeCanzoni(False, False)
        End If

        If Cosa = "RINFRESCALISTA" Then
            Call frmPlayer.lstAlbum_SelectedIndexChanged(sender, e)
        End If

        llblAggiornamentoCanzoni.Visible = False
        'cchkRandom.Enabled = True
        cchkUltime.Enabled = True
        cchkPrime.Enabled = True
    End Sub

    Public Sub CaricaTutteLeCanzoni(NonAvanzare As Boolean, Optional bCaricaCanzone As Boolean = True, Optional SalvaUltima As Boolean = True)
        instance.Cursor = Cursors.WaitCursor
        Dim DB As New SQLSERVERCE
        Dim conn As Object = CreateObject("ADODB.Connection")
        Dim rec As Object = CreateObject("ADODB.Recordset")
        Dim Sql As String
        Dim r As New RoutineVarie
        DB.ImpostaNomeDB(PathDB)
        DB.LeggeImpostazioniDiBase()
        conn = DB.ApreDB()

        Erase StrutturaDati.Canzoni
        StrutturaDati.qCanzoni = 0

        Dim Altro2 As String = ""

        If StrutturaDati.chkBellezza.Checked = True Then
            Dim Valore As String = StrutturaDati.cmbBellezza.SelectedItem
            If Valore = "Mai Votate" Then Valore = "0"

            If Valore > 0 Then
                If StrutturaDati.chkSuperiori.Checked = True Then
                    Altro2 = "Where Bellezza>=" & Valore
                Else
                    Altro2 = "Where Bellezza=" & Valore
                End If
            Else
                Altro2 = "Where (Bellezza Is Null Or Bellezza=0)"
            End If
        End If
        If StrutturaDati.chkFiltroTesto.Checked = True And StrutturaDati.txtFiltroTesto.Text <> "" Then
            If Altro2 <> "" Then Altro2 += " And " Else Altro2 = "Where "
            If StrutturaDati.chkFiltroNome.Checked = True Then
                Altro2 += "(SUBSTRING(Canzone, 1, CHARINDEX('.', Canzone) - 1) Like '%" & r.SistemaTestoPerDB(StrutturaDati.txtFiltroTesto.Text) & "%')"
            Else
                Altro2 += "(Artista Like '%" & r.SistemaTestoPerDB(StrutturaDati.txtFiltroTesto.Text) & "%' Or Album Like '%" & r.SistemaTestoPerDB(StrutturaDati.txtFiltroTesto.Text) & "%' Or SUBSTRING(Canzone, 1, CHARINDEX('.', Canzone) - 1) Like '%" & r.SistemaTestoPerDB(StrutturaDati.txtFiltroTesto.Text) & "%')"
            End If
            If StrutturaDati.chkRicercaSuTesto.Checked = True And StrutturaDati.txtFiltroTesto.Text <> "" Then
                Altro2 += " Union All SELECT Artista+'\'+Album+'\' As Artista, Canzone, Ascoltata, Bellezza " &
                    "FROM ListaCanzone2 " &
                    "WHERE (Testo LIKE '%" & r.SistemaTestoPerDB(StrutturaDati.txtFiltroTesto.Text) & "%') "
                If StrutturaDati.chkBellezza.Checked = True Then
                    Dim Valore As String = StrutturaDati.cmbBellezza.SelectedItem
                    If Valore = "Mai Votate" Then Valore = "0"

                    If Valore > 0 Then
                        If StrutturaDati.chkSuperiori.Checked = True Then
                            Altro2 += "And Bellezza>=" & Valore
                        Else
                            Altro2 += "And Bellezza=" & Valore
                        End If
                    Else
                        Altro2 += "And (Bellezza Is Null Or Bellezza=0)"
                    End If
                End If
            End If
        Else
        End If

        If StrutturaDati.chkRicercaSuTesto.Checked = True And StrutturaDati.txtFiltroTesto.Text <> "" Then
            Sql = "Select Count(*) From (Select Artista+'\'+Album+'\' As Artista, Canzone, Ascoltata, Bellezza From ListaCanzone2 " & Altro2 & ") C"
        Else
            Sql = "Select Count(*) From ListaCanzone2 " & Altro2
        End If
        rec = DB.LeggeQuery(conn, Sql)
        StrutturaDati.qCanzoni = rec(0).value
        ReDim StrutturaDati.Canzoni(StrutturaDati.qCanzoni)
        rec.Close()

        Dim p As Integer = 0

        Sql = "Select Artista+'\'+Album+'\' As Artista, Canzone, Ascoltata, Bellezza From ListaCanzone2 " & Altro2 & ""
        If StrutturaDati.chkRicordaAscoltate.Checked = True Then
            Sql = "Select * From (" & Sql & ") Aa Order By Aa.Artista, Aa.Canzone, Aa.Ascoltata"
        End If

        rec = DB.LeggeQuery(conn, Sql)
        Do Until rec.eof
            p += 1
            StrutturaDati.Canzoni(p) = StrutturaDati.PathMP3 & "\" & rec("Artista").Value & rec("Canzone").Value

            rec.MoveNext()
        Loop
        rec.Close()

        conn.Close()
        DB = Nothing
        instance.Cursor = Cursors.Default

        If NonAvanzare = False And SalvaUltima = True Then
            frmPlayer.Avanticanzone()
        End If

        StrutturaDati.lblTempoPassato.Text = ""
        StrutturaDati.lblTempoTotale.Text = ""

        StrutturaDati.lblTempoPassatoInterno.Text = ""
        StrutturaDati.lblTempoTotaleInterno.Text = ""

        StrutturaDati.lblNomeCanzone.Text = ""
        StrutturaDati.PicMP3.Image = Nothing
        StrutturaDati.BarraAvanzamento.Enabled = False
        StrutturaDati.BarraAvanzamentoInterna.Enabled = False
    End Sub

    Public Sub ImpostaListe()
        If StrutturaDati.QualeCanzoneStaSuonando < StrutturaDati.Canzoni.Length Then
            Dim gf As New GestioneFilesDirectory
            Dim Campi() As String = StrutturaDati.Canzoni(StrutturaDati.QualeCanzoneStaSuonando).Replace(StrutturaDati.PathMP3 & "\", "").Split("\")
            Dim Nome As String
            Dim Ok As Boolean

            Dim Artista() As String = {}
            Dim qArtista As Integer = -1

            If StrutturaDati.chkBellezza.Checked = True Or StrutturaDati.chkFiltroTesto.Checked = True Then
                Artista = StrutturaDati.Canzoni
                qArtista = StrutturaDati.Canzoni.Length - 1
                StrutturaDati.lstArtista.Items.Clear()
                Dim art As String
                For i As Integer = 1 To qArtista
                    art = Artista(i).Replace(StrutturaDati.PathMP3 & "\", "")
                    art = Mid(art, 1, art.IndexOf("\"))
                    Ok = True
                    For k As Integer = 0 To StrutturaDati.lstArtista.Items.Count - 1
                        If StrutturaDati.lstArtista.Items(k) = art Then
                            Ok = False
                            Exit For
                        End If
                    Next
                    If Ok = True Then
                        StrutturaDati.lstArtista.Items.Add(art)
                    End If
                Next
            End If

            For i As Integer = 0 To StrutturaDati.lstArtista.Items.Count - 1
                If StrutturaDati.lstArtista.Items(i) = Campi(0) Then
                    StrutturaDati.lstArtista.SelectedIndex = i
                    Exit For
                End If
            Next

            Dim Album() As String = {}
            Dim qAlbum As Integer = -1

            If StrutturaDati.chkBellezza.Checked = False And StrutturaDati.chkFiltroTesto.Checked = False Then
                gf.ScansionaDirectorySingola(StrutturaDati.PathMP3 & "\" & StrutturaDati.lstArtista.Text, StrutturaDati.FiltroRicerca)
                Album = gf.RitornaFilesRilevati
                qAlbum = gf.RitornaQuantiFilesRilevati
            Else
                Album = StrutturaDati.Canzoni
                qAlbum = StrutturaDati.Canzoni.Length - 1
            End If

            StrutturaDati.lstAlbum.Items.Clear()
            For i As Integer = 1 To qAlbum
                If Album(i).IndexOf(StrutturaDati.lstArtista.Text) > -1 Then
                    Nome = Album(i).Replace(StrutturaDati.PathMP3 & "\" & StrutturaDati.lstArtista.Text & "\", "")
                    Nome = Mid(Nome, 1, Nome.IndexOf("\"))
                    If Nome.Length > 2 Then
                        Ok = True
                        If Mid(Nome, 1, 5) = "0000-" Then
                            Nome = Mid(Nome, 6, Nome.Length)
                        End If
                        If Mid(Nome, 1).Trim = "-" Then
                            Nome = Mid(Nome, 2, Nome.Length)
                        End If
                        For k As Integer = 0 To StrutturaDati.lstAlbum.Items.Count - 1
                            If StrutturaDati.lstAlbum.Items(k) = Nome Then
                                Ok = False
                                Exit For
                            End If
                        Next
                        If Ok = True Then
                            StrutturaDati.lstAlbum.Items.Add(Nome.Trim)
                        End If
                    End If
                End If
            Next

            Dim NomeAlbumVero As String = ""
            Dim A As String

            For i As Integer = 0 To StrutturaDati.lstAlbum.Items.Count - 1
                A = StrutturaDati.lstAlbum.Items(i)
                If A.IndexOf("-") = -1 Then
                    A = "0000-" & A
                Else
                    Dim appo As String = Mid(A, 1, A.IndexOf("-"))
                    If IsNumeric(appo) = False Then
                        A = "0000-" & A
                    End If
                End If
                If Campi(1) = A Then
                    NomeAlbumVero = Campi(1)
                    StrutturaDati.lstAlbum.SelectedIndex = i
                    Exit For
                End If
            Next
            If NomeAlbumVero = "" Then
                If StrutturaDati.lstAlbum.Items.Count > 0 Then
                    NomeAlbumVero = StrutturaDati.lstAlbum.Items(0)
                    If NomeAlbumVero.IndexOf("-") = -1 Then
                        NomeAlbumVero = "0000-" & NomeAlbumVero
                    Else
                        Dim appo As String = Mid(NomeAlbumVero, 1, NomeAlbumVero.IndexOf("-"))
                        If IsNumeric(appo) = False Then
                            NomeAlbumVero = "0000-" & NomeAlbumVero
                        End If
                    End If
                End If
            End If

            Dim Canzonine() As String = {}
            Dim qCanzonine As Integer = -1

            If StrutturaDati.chkBellezza.Checked = False And StrutturaDati.chkFiltroTesto.Checked = False Then
                gf.ScansionaDirectorySingola(StrutturaDati.PathMP3 & "\" & StrutturaDati.lstArtista.Text & "\" & NomeAlbumVero, StrutturaDati.FiltroRicerca)
                Canzonine = gf.RitornaFilesRilevati
                qCanzonine = gf.RitornaQuantiFilesRilevati
            Else
                Canzonine = StrutturaDati.Canzoni
                qCanzonine = StrutturaDati.Canzoni.Length - 1
            End If

            StrutturaDati.lstCanzone.Items.Clear()
            For i As Integer = 1 To qCanzonine
                If Canzonine(i).IndexOf(StrutturaDati.lstArtista.Text) > -1 And Canzonine(i).IndexOf(NomeAlbumVero & "\") > -1 Then
                    Nome = Canzonine(i).Replace(StrutturaDati.PathMP3 & "\" & StrutturaDati.lstArtista.Text & "\" & NomeAlbumVero & "\", "")
                    Ok = True
                    If Mid(Nome, 1, 3) = "00-" Then
                        Nome = Mid(Nome, 4, Nome.Length)
                    End If
                    Nome = Nome.Trim
                    If Mid(Nome, 1, 1) = "-" Then
                        Nome = Mid(Nome, 2, Nome.Length)
                    End If
                    For k As Integer = 0 To StrutturaDati.lstCanzone.Items.Count - 1
                        If StrutturaDati.lstCanzone.Items(k) = Nome Then
                            Ok = False
                            Exit For
                        End If
                    Next
                    If Ok = True Then
                        StrutturaDati.lstCanzone.Items.Add(Nome.Trim)
                    End If
                End If
            Next

            For i As Integer = 0 To StrutturaDati.lstCanzone.Items.Count - 1
                If Campi(2).IndexOf(StrutturaDati.lstCanzone.Items(i)) > -1 Then
                    StrutturaDati.lstCanzone.SelectedIndex = i
                    Exit For
                End If
            Next
        End If
    End Sub

    Public Function RitornaAscoltata() As Integer
        'Me.Cursor = Cursors.WaitCursor
        Dim r As New RoutineVarie
        Dim DB As New SQLSERVERCE
        Dim conn As Object = CreateObject("ADODB.Connection")
        Dim rec As Object = CreateObject("ADODB.Recordset")
        Dim Sql As String
        DB.ImpostaNomeDB(PathDB)
        DB.LeggeImpostazioniDiBase()
        conn = DB.ApreDB()
        Dim Ritorno As Integer = 0

        Dim Album As String = StrutturaDati.lstAlbum.Text
        If Mid(Album, 5, 1) <> "-" Then
            Album = "0000-" & Album
        End If
        Dim Canzone As String = StrutturaDati.lstCanzone.Text
        If Canzone.IndexOf("-") = -1 Then Canzone = "00-" & Canzone

        Sql = "Select Ascoltata From ListaCanzone2 Where idCanzone=" & idCanzone
        rec = DB.LeggeQuery(conn, Sql)
        If rec.Eof = False Then
            If rec("Ascoltata").Value Is DBNull.Value = False Then
                Ritorno = rec("Ascoltata").Value
            Else
                Ritorno = 0
            End If
        Else
            Ritorno = 0
        End If
        rec.Close()

        Ritorno += 1
        Sql = "Update ListaCanzone2 Set Ascoltata=" & Ritorno & " Where idCanzone=" & idCanzone
        DB.EsegueSql(conn, Sql)

        conn.Close()

        DB = Nothing
        'Me.Cursor = Cursors.Default

        Return Ritorno
    End Function

    Public Sub PrendeDatiCanzone(Artista As String, Album As String, Canzone As String, PathCanzone As String)
        Dim DB As SQLSERVERCE
        Dim r As New RoutineVarie
        Dim conn As Object = CreateObject("ADODB.Connection")
        Dim Rec As Object = CreateObject("ADODB.Recordset")
        Dim Sql As String = ""
        DB = New SQLSERVERCE
        DB.ImpostaNomeDB(PathDB)
        DB.LeggeImpostazioniDiBase()
        conn = DB.ApreDB()

        Sql = "Select * From ListaCanzone2 Where Artista='" & r.SistemaTestoPerDB(Artista) & "' And Album='" & r.SistemaTestoPerDB(Album) & "' And Canzone='" & r.SistemaTestoPerDB(Canzone) & "'"
        Rec = DB.LeggeQuery(conn, Sql)
        If Not Rec.Eof Then
            Sql = ""
            idCanzone = Rec("idCanzone").Value
            Testo = "" & Rec("Testo").Value
            If "" & Rec("Bellezza").Value <> "" Then
                Bellezza = Val("" & Rec("Bellezza").Value)
            Else
                Bellezza = 0
            End If
            TestoTradotto = "" & Rec("TestoTradotto").Value
            Rec.Close()
        Else
            idCanzone = -1
            Testo = ""
            Bellezza = 0
            TestoTradotto = ""
            Rec.Close()

            Dim Conta As Integer

            Sql = "Select max(idCanzone)+1 From ListaCanzone2"
            Rec = DB.LeggeQuery(conn, Sql)
            If Rec(0).Value Is DBNull.Value Then
                Conta = 1
            Else
                Conta = Rec(0).Value
            End If
            Rec.Close()

            Dim Datella As Date
            Dim f As FileInfo = New FileInfo(PathCanzone)
            Datella = f.CreationTime
            Dim sDatella As String = r.ConverteDataPerDB(Datella)

            Sql = "Insert Into ListaCanzone2 Values (" &
                " " & Conta & ", " &
                "'" & r.SistemaTestoPerDB(Artista) & "', " &
                "'" & r.SistemaTestoPerDB(Album) & "', " &
                "'" & r.SistemaTestoPerDB(Canzone) & "', " &
                " " & sDatella & ", " &
                "0, " &
                "0, " &
                "'', " &
                "'')"
        End If

        If Sql <> "" Then
            DB.EsegueSql(conn, Sql)
        End If

        conn.Close()
        DB = Nothing
    End Sub

    Public Function RitornaQuanteStelleCanzoneSenzaCaricarla(sCanzone As String) As Integer
        'Me.Cursor = Cursors.WaitCursor
        Dim r As New RoutineVarie
        Dim DB As New SQLSERVERCE
        Dim conn As Object = CreateObject("ADODB.Connection")
        Dim rec As Object = CreateObject("ADODB.Recordset")
        Dim Sql As String
        DB.ImpostaNomeDB(PathDB)
        DB.LeggeImpostazioniDiBase()
        conn = DB.ApreDB()
        Dim Ritorno As Integer = 0

        Dim NomeCanzone As String = sCanzone
        NomeCanzone = NomeCanzone.Replace(StrutturaDati.PathMP3 & "\", "")

        Dim Campi() As String = NomeCanzone.Split("\")
        Dim Artista As String = Campi(0)
        Dim Album As String = Campi(1)
        If Mid(Album, 5, 1) <> "-" Then
            Album = "0000-" & Album
        End If
        Dim Canzone As String = Campi(2)
        If Canzone.IndexOf("-") = -1 Then Canzone = "00-" & Canzone

        NomeCanzone = Artista & "\" & Album & "\" & Canzone
        NomeCanzone = NomeCanzone.Replace("'", "''")

        Sql = "Select * From ListaCanzone2 Where Canzone='" & r.SistemaTestoPerDB(NomeCanzone) & "'"
        rec = DB.LeggeQuery(conn, Sql)
        If rec.Eof = False Then
            If rec("Bellezza").Value Is DBNull.Value = False Then
                Ritorno = rec("Bellezza").Value
            End If
        Else
            rec.Close()

            NomeCanzone = StrutturaDati.lstArtista.Text & "\" & Album & "\" & Canzone

            Sql = "Select * From ListaCanzone2 Where Canzone='" & r.SistemaTestoPerDB(NomeCanzone) & "'"
            rec = DB.LeggeQuery(conn, Sql)
            If rec.eof = False Then
                If rec("Bellezza").Value Is DBNull.Value = False Then
                    Ritorno = rec("Bellezza").Value
                End If
            End If
        End If
        rec.Close()
        conn.Close()

        DB = Nothing
        'Me.Cursor = Cursors.Default

        Return Ritorno
    End Function

    Public Function RitornaQuanteStelleCanzone() As Integer
        Return Bellezza
    End Function

    Public Function PrendeTempoTotaleCanzone()
        Dim Duration As String = ""
        Dim CeTag As Boolean

        Dim Tags As TagLib.File
        Dim m As New MP3Tag

        If StrutturaDati.QualeCanzoneStaSuonando > StrutturaDati.Canzoni.Length - 1 Then
            StrutturaDati.QualeCanzoneStaSuonando = 1
        End If

        Tags = m.TornaTagDaMP3(StrutturaDati.Canzoni(StrutturaDati.QualeCanzoneStaSuonando))
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

End Class
