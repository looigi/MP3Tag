Imports System.IO
Imports System.Threading

Public Class getLyricsMP3_NEW
    Private trd As Thread

    Private Artista As String
    Private Titolo As String
    Private lstTesto As ListBox
    Private ScaricaTestoSeNonLoTrova As Boolean
    Private NomeCanzone As String
    Private ForzaCancellatura As Boolean
    Private lstTestoInterno As Panel
    Private lstMembriInterno As Panel
    Private DimeYSchermo As Integer
    Private lstTraduzione As ListBox
    Private TestoRitorno As String
    Private TestoRitornoTradotto As String
    Private FinitoThread As Boolean

    Private HaFinitoDiLeggereITesti As Boolean
    Private lblTestiThread As Label

    Private trdTesti As Thread

    Private instance As Form

    Private Delegate Sub DelegateAddTextTesti(ByVal str As String)
    Private MethodDelegateAddTextTesti As New DelegateAddTextTesti(AddressOf AddTextTesti)

    Private Delegate Sub DelegateTextTestiVisible(ByVal en As Boolean)
    Private MethodDelegateTextTestiVisible As New DelegateTextTestiVisible(AddressOf VisibleTextTesti)

    Private tmrAttesaFineLetturaTesti As System.Timers.Timer = Nothing

    Public Sub ScaricaTestiInBackground(inst As Form)
        instance = inst

        StrutturaDati.lblTesti.Visible = True
        StrutturaDati.lblTesti.Text = ""
        If lblTestiThread Is Nothing Then
            lblTestiThread = StrutturaDati.lblTesti
        End If

        trdTesti = New Thread(AddressOf ScaricaTestiInBackgroundCodice)
        trdTesti.IsBackground = True
        trdTesti.Start()

        HaFinitoDiLeggereITesti = False

        tmrAttesaFineLetturaTesti = New System.Timers.Timer(1000)
        AddHandler tmrAttesaFineLetturaTesti.Elapsed, AddressOf TermineLettura
        tmrAttesaFineLetturaTesti.Start()
    End Sub

    Private Async Sub TermineLettura(sender As Object, e As EventArgs)
        Await Task.Run(Sub()
                           If instance.InvokeRequired Then
                               instance.Invoke(MethodDelegateTextTestiVisible, False)
                           End If

                           tmrAttesaFineLetturaTesti = Nothing
                       End Sub)
    End Sub

    Private Sub VisibleTextTesti(ByVal e As Boolean)
        lblTestiThread.Visible = e
    End Sub

    Private Sub AddTextTesti(ByVal str As String)
        lblTestiThread.Text = str
    End Sub

    Private Sub ScaricaTestiInBackgroundCodice()
        If instance.InvokeRequired Then
            instance.Invoke(MethodDelegateAddTextTesti, "")
        End If

        Dim Album As String
        Dim Artista As String
        Dim Canzone As String
        Dim Campi() As String
        Dim sCanzone As String
        Dim sAlbum As String

        Dim DB As New SQLSERVERCE
        Dim conn As Object = CreateObject("ADODB.Connection")
        Dim rec As Object = CreateObject("ADODB.Recordset")
        Dim Sql As String
        Dim r As New RoutineVarie
        DB.ImpostaNomeDB(PathDB)
        DB.LeggeImpostazioniDiBase()
        conn = DB.ApreDB()

        Dim Canzoni() As String = {}
        Dim qCanzone As Long = 0

        Sql = "Select * From ListaCanzone2 Where Testo='' Or Testo Is Null"
        rec = DB.LeggeQuery(conn, Sql)
        Do Until rec.eof
            ReDim Preserve Canzoni(qCanzone)
            Canzoni(qCanzone) = rec("Artista").Value & "\" & rec("Album").Value & "\" & rec("Canzone").Value
            qCanzone += 1

            rec.movenext()
        Loop
        rec.Close()
        conn = Nothing

        If qCanzone > 0 Then
            For i As Integer = 1 To qCanzone - 1
                Canzone = Canzoni(i).Replace(StrutturaDati.PathMP3 & "\", "")
                Campi = Canzone.Split("\")

                Artista = Campi(0)
                Album = Campi(1)
                Canzone = Campi(2)

                If instance.InvokeRequired Then
                    sCanzone = Canzone
                    sAlbum = Album

                    Do While sCanzone.Contains("-")
                        sCanzone = Mid(sCanzone, sCanzone.IndexOf("-") + 2, sCanzone.Length)
                    Loop
                    If sCanzone.Contains(".") Then
                        sCanzone = Mid(sCanzone, 1, sCanzone.IndexOf("."))
                    End If
                    Do While sAlbum.Contains("-")
                        sAlbum = Mid(sAlbum, sAlbum.IndexOf("-") + 2, sAlbum.Length)
                    Loop

                    instance.Invoke(MethodDelegateAddTextTesti, "Testo: " & i & "/" & qCanzone & ": " & sCanzone & " (" & sAlbum & " - " & Artista & ")")
                End If

                RitornaTestoCanzoneInBackGround(Artista, Album, Canzone)
            Next
        End If

        HaFinitoDiLeggereITesti = True
    End Sub

    Private Function AccorpaApici(Cosa As String) As String
        Dim Appo As String = Cosa

        Do While Appo.IndexOf("a'") > -1
            Appo = Appo.Replace("a'", "à")
        Loop
        Do While Appo.IndexOf("e'") > -1
            Appo = Appo.Replace("e'", "è")
        Loop
        Do While Appo.IndexOf("i'") > -1
            Appo = Appo.Replace("i'", "ì")
        Loop
        Do While Appo.IndexOf("o'") > -1
            Appo = Appo.Replace("o'", "ò")
        Loop
        Do While Appo.IndexOf("u'") > -1
            Appo = Appo.Replace("u'", "ù")
        Loop
        Appo = Appo.Replace(" ", "%20")

        Return Appo
    End Function

    Public Function getTesto() As String
        Return TestoRitorno
    End Function

    Public Function getTestoTradotto() As String
        Return TestoRitornoTradotto
    End Function

    Public Function getFinitoThread() As Boolean
        Return FinitoThread
    End Function

    Public Sub RitornaTestoCanzoneInBackGround(pArtista As String, pAlbum As String, pCanzone As String)
        ElaboraInBackGround(pArtista, pAlbum, pCanzone)
    End Sub

    Public Sub RitornaTestoCanzone(pArtista As String, pTitolo As String, plstTesto As ListBox, pScaricaTestoSeNonLoTrova As Boolean,
                                   pNomeCanzone As String, pForzaCancellatura As Boolean, plstTestoInterno As Panel, pdimeYSchermo As Integer,
                                   plstTraduzione As ListBox, pnlMembriInterno As Panel)
        Artista = pArtista
        Titolo = pTitolo
        lstTesto = plstTesto
        ScaricaTestoSeNonLoTrova = pScaricaTestoSeNonLoTrova
        NomeCanzone = pNomeCanzone
        ForzaCancellatura = pForzaCancellatura
        lstTestoInterno = plstTestoInterno
        DimeYSchermo = pdimeYSchermo
        lstTraduzione = plstTraduzione
        lstMembriInterno = pnlMembriInterno

        TestoRitorno = ""
        TestoRitornoTradotto = ""

        FinitoThread = False

        trd = New Thread(AddressOf Elabora)
        trd.IsBackground = True
        trd.Start()
    End Sub

    Private Function NessunTestoRilevato() As String
        Dim t As String = ""


        'If t.Length > MaxCaratteri Then
        '    MaxCaratteri = t.Length
        'End If
        'NumeroRighe = 5

        Return t
        t += Artista.ToUpper.Trim & "§"
        t += Titolo.ToUpper.Trim & "§§"
        t += "Nessun testo rilevato"
    End Function

    Private Function Sistema(Cosa As String) As String
        Dim Cosa2 As String = Cosa

        Cosa2 = SistemaRicorsivo(Cosa2, "a")
        Cosa2 = SistemaRicorsivo(Cosa2, "i")
        Cosa2 = SistemaRicorsivo(Cosa2, "span")
        Cosa2 = SistemaRicorsivo(Cosa2, "img")
        Cosa2 = SistemaRicorsivo(Cosa2, "noscript")
        Cosa2 = SistemaRicorsivo(Cosa2, "small")

        Cosa2 = Cosa2.Replace("<li>", "")
        Cosa2 = Cosa2.Replace("</li>", "§")
        Cosa2 = Cosa2.Replace("<b>", "")
        Cosa2 = Cosa2.Replace("</b>", ";")
        Cosa2 = Cosa2.Replace("— ", "")
        'Cosa2 = Cosa2.Replace("- ", "")
        Cosa2 = Cosa2.Replace(">", "")
        Cosa2 = Cosa2.Replace("<", "")
        Do While Mid(Cosa2.Trim, 1, 1) = "-" Or Mid(Cosa2, 1, 1) = "–" Or Mid(Cosa2, 1, 1) = "—"
            Cosa2 = Cosa2.Trim
            Cosa2 = Mid(Cosa2, 2, Cosa2.Length)
        Loop

        Return Cosa2
    End Function

    Private Function SistemaRicorsivo(Cosa1 As String, Cosa As String) As String
        Dim Cosa2 As String = Cosa1

        Do While Cosa2.IndexOf("<" & Cosa) > -1
            Dim inizio As Integer = Cosa2.IndexOf("<" & Cosa)
            Dim fine As Integer = Mid(Cosa2, inizio + 2, Cosa2.Length).IndexOf(">")

            Cosa2 = Mid(Cosa2, 1, inizio) & Mid(Cosa2, inizio + fine + 2, Cosa2.Length)
        Loop

        Cosa2 = Cosa2.Replace("</" & Cosa & ">", "")

        Return Cosa2
    End Function

    Public Sub PrendeMembriBand(Artista As String, Optional PerForza As Boolean = False)
        Dim sNomeFile As String = Application.StartupPath & "\Appoggio\Membri_" & Now.Second & ".xml"
        Dim Ok As Boolean = True
        Dim DB As SQLSERVERCE
        Dim r As New RoutineVarie
        Dim conn As Object = CreateObject("ADODB.Connection")
        Dim Rec As Object = CreateObject("ADODB.Recordset")
        Dim Sql As String = ""
        DB = New SQLSERVERCE
        DB.ImpostaNomeDB(PathDB)
        DB.LeggeImpostazioniDiBase()
        conn = DB.ApreDB()

        Dim sArtista As String = Artista
        Dim sTitolo As String = Titolo
        sArtista = sArtista.Replace(" ", "%20").Replace("'", "%27")
        Dim Url As String = "http://lyrics.wikia.com/wiki/" & sArtista

        Dim art As String = sArtista
        Dim membro As String
        Dim durata As String

        Membri = ""

        If Not PerForza Then
            If art.Length > 50 Then art = Mid(art, 1, 50)
            Sql = "Select * From Members Where Gruppo='" & r.SistemaTestoPerDB(art) & "' Order By Progressivo"
            Rec = DB.LeggeQuery(conn, Sql)
            If Not Rec.Eof Then
                Ok = False
                Do Until Rec.Eof
                    Membri &= Rec("Membro").Value & ";" & Rec("Durata").Value & ";" & Rec("Attuale").Value & ";§"

                    Rec.MoveNext
                Loop
            Else
                Ok = True
            End If
            Rec.Close()
        End If

        If Ok Or PerForza Then
            Dim gd As New Download

            gd.ImpostaValori(TipoCollegamento, Utenza, Password, Dominio, sNomeFile)
            gd.CreaEPulisceCartellaDiLavoro()

            If File.Exists(sNomeFile) = False Then
                Ok = False
                For i As Integer = 1 To 5
                    Try
                        Kill(sNomeFile)
                    Catch ex As Exception

                    End Try
                    Ok = gd.ScaricaPagina(Url)
                    If File.Exists(sNomeFile) = True Then
                        If FileLen(sNomeFile) > 0 Then
                            Ok = True
                            Exit For
                        End If
                    End If
                Next
            End If

            If Ok Then
                Dim gf As New GestioneFilesDirectory
                Dim Filetto As String

                art = r.SistemaTestoPerDB(sArtista.Trim)
                If art.Length > 50 Then art = Mid(art, 1, 50)
                Sql = "Delete From Members Where Gruppo='" & art & "'"
                DB.EsegueSql(conn, Sql)

                Try
                    Filetto = gf.LeggeFileIntero(sNomeFile)
                Catch ex As Exception
                    Filetto = ""
                End Try

                Dim Filetto2 As String = ""
                Dim Filetto3 As String = ""

                If Filetto.IndexOf("<b>Band members:</b>") > -1 Then
                    Filetto2 = Mid(Filetto, Filetto.IndexOf("<b>Band members:</b>"), Filetto.Length)
                    If Filetto2.IndexOf("<ul>") > -1 Then
                        Filetto2 = Mid(Filetto2, Filetto2.IndexOf("<ul>") + 5, Filetto2.Length)
                        Filetto2 = Mid(Filetto2, 1, Filetto2.IndexOf("</ul>"))
                    End If
                    If Filetto.IndexOf("<b>Former members:</b>") > -1 Then
                        Filetto3 = Mid(Filetto, Filetto.IndexOf("<b>Former members:</b>"), Filetto.Length)
                        If Filetto3.IndexOf("<ul>") > -1 Then
                            Filetto3 = Mid(Filetto3, Filetto3.IndexOf("<ul>") + 5, Filetto3.Length)
                            Filetto3 = Mid(Filetto3, 1, Filetto3.IndexOf("</ul>"))
                        End If
                    End If
                End If

                If Filetto2 <> "" Then
                    Filetto2 = Sistema(Filetto2)
                End If
                If Filetto3 <> "" Then
                    Filetto3 = Sistema(Filetto3)
                End If

                If Filetto2 <> "" Or Filetto3 <> "" Then
                    Dim conta As Integer = 0

                    For Each a As String In Filetto2.Split("§")
                        If a <> "" Then
                            Dim c() As String = a.Split(";")

                            art = r.SistemaTestoPerDB(sArtista.Trim.Replace(";", ""))
                            membro = r.SistemaTestoPerDB(c(0).Trim.Replace(";", ""))
                            If c.Length > 1 Then
                                durata = r.SistemaTestoPerDB(c(1).Trim.Replace(";", ""))
                            Else
                                durata = ""
                            End If

                            membro = membro.Replace("  ", " ")
                            durata = durata.Replace("  ", " ")

                            If art.Length > 50 Then art = Mid(art, 1, 50)
                            If membro.Length > 50 Then membro = Mid(membro, 1, 50)
                            If durata.Length > 30 Then durata = Mid(durata, 1, 30)

                            If membro.ToUpper.IndexOf(durata.ToUpper.Trim) > -1 Then
                                durata = ""
                            End If

                            conta += 1
                            Sql = "Insert Into Members Values(" &
                                    "'" & art & "', " &
                                    " " & conta & ", " &
                                    "'" & membro & "', " &
                                    "'" & durata & "', " &
                                    "'S'" &
                                    ")"
                            DB.EsegueSql(conn, Sql)

                            If c.Length > 1 Then
                                Membri &= c(0).Replace("  ", " ") & ";" & c(1).Replace("  ", " ") & ";S;§"
                            Else
                                Membri &= c(0).Replace("  ", " ") & ";;S;§"
                            End If
                        End If
                    Next

                    For Each a As String In Filetto3.Split("§")
                        If a <> "" Then
                            Dim c() As String = a.Split(";")

                            art = r.SistemaTestoPerDB(sArtista.Trim.Replace(";", ""))
                            membro = r.SistemaTestoPerDB(c(0).Trim.Replace(";", ""))
                            If c.Length > 1 Then
                                durata = r.SistemaTestoPerDB(c(1).Trim.Replace(";", ""))
                            Else
                                durata = ""
                            End If

                            membro = membro.Replace("  ", " ")
                            durata = durata.Replace("  ", " ")

                            If art.Length > 50 Then art = Mid(art, 1, 50)
                            If membro.Length > 50 Then membro = Mid(membro, 1, 50)
                            If durata.Length > 30 Then durata = Mid(durata, 1, 30)

                            If membro.ToUpper.IndexOf(durata.ToUpper.Trim) > -1 Then
                                durata = ""
                            End If

                            If Filetto2.ToUpper.IndexOf(membro.ToUpper.Trim) = -1 Then

                                conta += 1
                                Sql = "Insert Into Members Values(" &
                                    "'" & art & "', " &
                                    " " & conta & ", " &
                                    "'" & membro & "', " &
                                    "'" & durata & "', " &
                                    "'N'" &
                                    ")"
                                DB.EsegueSql(conn, Sql)

                                If c.Length > 1 Then
                                    Membri &= c(0).Replace("  ", " ") & ";" & c(1).Replace("  ", " ") & ";N;§"
                                Else
                                    Membri &= c(0).Replace("  ", " ") & ";;N;§"
                                End If
                            End If
                        End If
                    Next
                Else
                    Sql = "Insert Into Members Values(" &
                                    "'" & art & "', " &
                                    " " & 1 & ", " &
                                    "'Nessuno', " &
                                    "'', " &
                                    "'S'" &
                                    ")"
                    DB.EsegueSql(conn, Sql)
                End If
            End If
        End If

        If Membri <> "" Then
            Dim c() As String = Membri.Split("§")
            Dim trattino As String
            Dim t1 As Boolean
            Dim t2 As Boolean

            For Each memb As String In c
                If memb <> "" Then
                    Dim cc() As String = memb.Split(";")

                    qValoriDaScrivere += 1
                    ReDim Preserve ValoriDaScrivere(qValoriDaScrivere)
                    If cc(2) = "S" Then
                        If cc(1) <> "" Then
                            trattino = " - " : t1 = False : t2 = False
                            If Mid(cc(1).Trim, 1, 1) = "-" Then trattino = "" : t1 = True
                            If Mid(cc(0).Trim, cc(0).Trim.Length, 1) = "-" Then trattino = "" : t2 = True
                            If t1 And t2 Then
                                cc(1) = Mid(cc(1).Trim, 2, cc(1).Length)
                            End If

                            ValoriDaScrivere(qValoriDaScrivere) = "Membro attuale: " & cc(0) & trattino & cc(1)
                        Else
                            ValoriDaScrivere(qValoriDaScrivere) = "Membro attuale: " & cc(0)
                        End If
                    Else
                        If cc(1) <> "" Then
                            trattino = " - "
                            trattino = " - " : t1 = False : t2 = False
                            If Mid(cc(1).Trim, 1, 1) = "-" Then trattino = "" : t1 = True
                            If Mid(cc(0).Trim, cc(0).Trim.Length, 1) = "-" Then trattino = "" : t2 = True
                            If t1 And t2 Then
                                cc(1) = Mid(cc(1).Trim, 2, cc(1).Length)
                            End If

                            ValoriDaScrivere(qValoriDaScrivere) = "Membro passato: " & cc(0) & trattino & cc(1)
                        Else
                            ValoriDaScrivere(qValoriDaScrivere) = "Membro passato: " & cc(0)
                        End If
                    End If
                End If
            Next
        End If
    End Sub

    Private Sub Elabora()
        Dim sNomeFile As String = Application.StartupPath & "\Appoggio\Testo_" & Now.Second & ".xml"
        Dim Ok As Boolean = True
        Dim DB As SQLSERVERCE
        Dim r As New RoutineVarie
        Dim conn As Object = CreateObject("ADODB.Connection")
        Dim Rec As Object = CreateObject("ADODB.Recordset")
        Dim Sql As String = ""
        DB = New SQLSERVERCE
        DB.ImpostaNomeDB(PathDB)
        DB.LeggeImpostazioniDiBase()
        conn = DB.ApreDB()

        If Testo <> "" Then
            Dim Righe() As String = Testo.Split("§")

            For i As Integer = 0 To Righe.Length - 1
                TestoRitorno += Righe(i) & "§"
            Next
        Else
            If ScaricaTestoSeNonLoTrova = True Then
                Dim sArtista As String = Artista
                Dim sTitolo As String = Titolo
                sArtista = sArtista.Replace(" ", "%20").Replace("'", "%27")
                sTitolo = sTitolo.Replace(" ", "%20").Replace("'", "%27")
                Dim Url As String = "http://lyrics.wikia.com/wiki/" & sArtista & ":" & sTitolo

                Dim gd As New Download

                gd.ImpostaValori(TipoCollegamento, Utenza, Password, Dominio, sNomeFile)
                gd.CreaEPulisceCartellaDiLavoro()
                Ok = gd.ScaricaPagina(Url)

                If Ok = False Then
                    If Titolo.IndexOf("'") > -1 Then
                        Dim TitoloApicettato As String = AccorpaApici(Titolo)
                        Dim ArtistaApicettato As String = AccorpaApici(Artista)

                        Url = "http://lyrics.wikia.com/wiki/" & ArtistaApicettato & ":" & TitoloApicettato

                        Ok = gd.ScaricaPagina(Url)
                    End If
                Else
                    If File.Exists(sNomeFile) = True Then
                        If FileLen(sNomeFile) = 0 Then
                            Ok = False
                            For i As Integer = 1 To 5
                                Try
                                    Kill(sNomeFile)
                                Catch ex As Exception

                                End Try
                                Ok = gd.ScaricaPagina(Url)
                                If File.Exists(sNomeFile) = True Then
                                    If FileLen(sNomeFile) > 0 Then
                                        Ok = True
                                        Exit For
                                    End If
                                End If
                            Next
                        End If
                    End If
                End If

                If Ok = False Then
                    TestoRitorno = NessunTestoRilevato()
                Else
                    Dim NomeArtista As String = ""
                    Dim gf As New GestioneFilesDirectory

                    If File.Exists(sNomeFile) = True Then
                        Dim Filetto As String

                        Try
                            Filetto = gf.LeggeFileIntero(sNomeFile)
                        Catch ex As Exception
                            Filetto = ""
                        End Try

                        If Filetto.IndexOf("<b>Did you mean ") > -1 Then
                            Dim NomePagina As String
                            NomePagina = Mid(Filetto, Filetto.IndexOf("<b>Did you mean ") + 1, Filetto.Length)
                            NomePagina = Mid(NomePagina, 1, NomePagina.IndexOf("</b> "))
                            NomePagina = Mid(NomePagina, NomePagina.IndexOf("href=" & Chr(34)) + 7, NomePagina.Length)
                            NomePagina = "http://lyrics.wikia.com" & Mid(NomePagina, 1, NomePagina.IndexOf(Chr(34)))

                            gd.CreaEPulisceCartellaDiLavoro()
                            Ok = gd.ScaricaPagina(NomePagina)

                            If Ok = False Then

                                TestoRitorno = NessunTestoRilevato()
                            Else
                                If File.Exists(sNomeFile) = True Then
                                    Filetto = gf.LeggeFileIntero(sNomeFile)
                                Else
                                    Filetto = ""

                                    TestoRitorno = NessunTestoRilevato()
                                End If
                            End If
                        Else
                            If Filetto.Contains("<ul class=""redirectText"">") Then
                                Dim NomePagina As String = Filetto

                                NomePagina = Mid(NomePagina, NomePagina.IndexOf("<ul class=""redirectText"">") + 26, NomePagina.Length)
                                NomePagina = Mid(NomePagina, NomePagina.IndexOf("<a href=""") + 10, NomePagina.Length)
                                NomePagina = Mid(NomePagina, 1, NomePagina.IndexOf(Chr(34)))
                                NomePagina = "http://lyrics.wikia.com" & NomePagina

                                gd.CreaEPulisceCartellaDiLavoro()
                                Ok = gd.ScaricaPagina(NomePagina)
                                Thread.Sleep(500)

                                If Ok = False Then
                                    TestoRitorno = NessunTestoRilevato()
                                Else
                                    If File.Exists(sNomeFile) = True Then
                                        Filetto = gf.LeggeFileIntero(sNomeFile)
                                        If Filetto = "" Then
                                            For i As Integer = 1 To 5
                                                Thread.Sleep(1000)

                                                Ok = gd.ScaricaPagina(NomePagina)
                                                If Not Ok Then
                                                    TestoRitorno = NessunTestoRilevato()
                                                    Filetto = ""
                                                    Exit For
                                                Else
                                                    If File.Exists(sNomeFile) Then
                                                        Filetto = gf.LeggeFileIntero(sNomeFile)
                                                        If Filetto <> "" Then
                                                            Exit For
                                                        End If
                                                    End If
                                                End If
                                            Next
                                        End If
                                    Else
                                        Filetto = ""

                                        TestoRitorno = Artista.ToUpper.Trim & "§"
                                        TestoRitorno += sTitolo.ToUpper.Trim & "§§"
                                        TestoRitorno += "Nessun testo rilevato"
                                    End If
                                End If
                                'Else
                                '    Filetto = ""
                            End If
                        End If

                        If Filetto <> "" Then
                            Dim Inizio As Integer = Filetto.IndexOf("<div class='lyricbox'>")
                            If Inizio > -1 Then
                                Filetto = Mid(Filetto, Inizio + 1, Filetto.Length)
                                Filetto = Mid(Filetto, Filetto.IndexOf(">") + 2, Filetto.Length)
                                Filetto = Mid(Filetto, 1, Filetto.IndexOf("<div class='lyricsbreak'>"))

                                Dim AppoggioCaratteri() As String = {}
                                Dim c As String

                                AppoggioCaratteri = Filetto.Split(";")

                                For i As Integer = 0 To AppoggioCaratteri.Length - 1
                                    If AppoggioCaratteri(i) <> "" Then
                                        If AppoggioCaratteri(i).IndexOf("<br />") = -1 Then
                                            If AppoggioCaratteri(i).IndexOf("<span") > -1 Then
                                                AppoggioCaratteri(i) = Mid(AppoggioCaratteri(i), AppoggioCaratteri(i).IndexOf("/span>") + 7, AppoggioCaratteri(i).Length)
                                            End If
                                            c = AppoggioCaratteri(i).Replace("&#", "").Replace("<b>", "").Replace("</b>", "")
                                            If c <> "" Then
                                                Try
                                                    TestoRitorno += Chr(c)
                                                Catch ex As Exception
                                                    TestoRitorno += "?"
                                                End Try
                                            End If
                                        Else
                                            TestoRitorno += "§"
                                            Try
                                                TestoRitorno += Chr(AppoggioCaratteri(i).Replace("&#", "").Replace("<br />", ""))
                                            Catch ex As Exception
                                                TestoRitorno += "?"
                                            End Try
                                        End If
                                    End If
                                Next

                                TestoRitorno = sArtista.ToUpper & "§" & Titolo.ToUpper & "§§" & TestoRitorno

                                If TestoRitorno = "" Then
                                    TestoRitorno = NessunTestoRilevato()
                                End If
                            Else
                                TestoRitorno = NessunTestoRilevato()
                            End If
                        End If
                    Else
                        TestoRitorno = NessunTestoRilevato()
                    End If
                End If

                If TestoRitorno = "" Then
                    TestoRitorno += Artista.ToUpper.Trim & "§"
                    TestoRitorno += Titolo.ToUpper.Trim & "§§"
                    TestoRitorno += "Nessun testo rilevato"
                Else
                    If TestoRitorno.ToUpper.IndexOf(Artista.ToUpper) = -1 And TestoRitorno.ToUpper.IndexOf(Titolo.ToUpper) = -1 Then
                        TestoRitorno = Artista.ToUpper.Trim & "§" & Titolo.ToUpper.Trim & "§§" & TestoRitorno
                    End If
                End If

                Sql = "Update ListaCanzone2 Set Testo='" & r.SistemaTestoPerDB(TestoRitorno) & "' Where idCanzone=" & idCanzone
                DB.EsegueSql(conn, Sql)
            Else
                TestoRitorno = ""
            End If
        End If

        ' Traduttore
        If TestoRitorno.IndexOf("Nessun testo") = -1 And TestoRitorno <> "" Then
            Dim rit As String = ""

            If TestoTradotto <> "" Then
                rit = TestoTradotto
            Else
                Try
                    Dim t As New YandexTranslate.YandexTranslator
                    Dim Titolone As String = ""
                    rit = t.translate(TestoRitorno.Replace(";", ""), "trnsl.1.1.20170415T165222Z.de2fde86333c7b9e.04188d1030d55d077f57f6efb3b577d8998ae360", "it")
                    If rit.IndexOf("§§") > -1 Then
                        Titolone = rit.Substring(0, rit.IndexOf("§§"))
                        rit = MetteMaiuscoleInizioRiga(rit.Replace(Titolone, ""))
                        Titolone = Titolone.ToUpper
                        rit = Titolone & rit
                    Else
                        rit = MetteMaiuscoleInizioRiga(rit)
                    End If

                    Sql = "Update ListaCanzone2 Set TestoTradotto='" & r.SistemaTestoPerDB(rit) & "' Where idCanzone=" & idCanzone
                    DB.EsegueSql(conn, Sql)
                Catch ex As Exception

                End Try
            End If

            TestoRitornoTradotto = rit
        End If
        ' Traduttore

        PrendeMembriBand(Artista)

        FinitoThread = True
    End Sub

    Private Sub ElaboraInBackGround(Artista As String, Album As String, Canzone As String)
        Dim sNomeFile As String = Application.StartupPath & "\Appoggio\Testo_Automatico_" & Now.Second & ".xml"
        Dim Ok As Boolean = True
        Dim CeTesto As Boolean = False
        Dim CeTestoTradotto As Boolean = False
        Dim DB As SQLSERVERCE
        Dim r As New RoutineVarie
        Dim conn As Object = CreateObject("ADODB.Connection")
        Dim Rec As Object = CreateObject("ADODB.Recordset")
        Dim Sql As String = ""
        DB = New SQLSERVERCE
        DB.ImpostaNomeDB(PathDB)
        DB.LeggeImpostazioniDiBase()
        conn = DB.ApreDB()

        Dim idCanzone As Integer

        TestoRitorno = ""

        Sql = "Select * From ListaCanzone2 Where Album='" & r.SistemaTestoPerDB(Album) & "' And Artista='" & r.SistemaTestoPerDB(Artista) & "' And Canzone='" & r.SistemaTestoPerDB(Canzone) & "'"
        Rec = DB.LeggeQuery(conn, Sql)
        If Not Rec.Eof Then
            idCanzone = Rec(0).Value
            If "" & Rec("Testo").Value.ToString <> "" Then
                CeTesto = True
                TestoRitorno = Rec("Testo").Value.ToString
            End If
            If "" & Rec("TestoTradotto").Value.ToString <> "" Then
                CeTestoTradotto = True
            End If
        Else
            Ok = True
        End If
        Rec.Close()

        If Not Ok Then
            Exit Sub
        End If

        Dim sArtista As String = Artista
        Dim sTitolo As String = Canzone

        sArtista = sArtista.Replace(" ", "%20").Replace("'", "%27")
        sTitolo = sTitolo.Replace(" ", "%20").Replace("'", "%27")

        If sArtista.Contains("-") Then
            sArtista = Mid(sArtista, sArtista.IndexOf("-") + 2, sArtista.Length)
        End If
        If sTitolo.Contains("-") Then
            sTitolo = Mid(sTitolo, sTitolo.IndexOf("-") + 2, sTitolo.Length)
        End If
        If (sTitolo.Contains(".")) Then
            sTitolo = Mid(sTitolo, 1, sTitolo.IndexOf("."))
        End If
        If (sTitolo.Contains("(")) Then
            sTitolo = Mid(sTitolo, 1, sTitolo.IndexOf("("))
        End If

        If Not CeTesto Then
            Dim Url As String = "http://lyrics.wikia.com/wiki/" & sArtista & ":" & sTitolo

            Dim gd As New Download

            gd.ImpostaValori(TipoCollegamento, Utenza, Password, Dominio, sNomeFile)
            gd.CreaEPulisceCartellaDiLavoro()
            Ok = gd.ScaricaPagina(Url)

            If Ok = False Then
                If Titolo Is Nothing Then Titolo = ""
                If Titolo.IndexOf("'") > -1 Then
                    Dim TitoloApicettato As String = AccorpaApici(Titolo)
                    Dim ArtistaApicettato As String = AccorpaApici(Artista)

                    Url = "http://lyrics.wikia.com/wiki/" & ArtistaApicettato & ":" & TitoloApicettato

                    Ok = gd.ScaricaPagina(Url)
                End If
            Else
                If File.Exists(sNomeFile) = True Then
                    If FileLen(sNomeFile) = 0 Then
                        Ok = False
                        For i As Integer = 1 To 5
                            Try
                                Kill(sNomeFile)
                            Catch ex As Exception

                            End Try
                            Ok = gd.ScaricaPagina(Url)
                            If File.Exists(sNomeFile) = True Then
                                If FileLen(sNomeFile) > 0 Then
                                    Ok = True
                                    Exit For
                                End If
                            End If
                        Next
                    End If
                End If
            End If

            Dim sCanzone As String = Canzone

            If sCanzone.Contains("-") Then
                sCanzone = Mid(sCanzone, sCanzone.IndexOf("-") + 2, sCanzone.Length)
            End If
            If sCanzone.Contains(".") Then
                sCanzone = Mid(sCanzone, 1, sCanzone.IndexOf("."))
            End If
            If sCanzone.Contains("(") Then
                sCanzone = Mid(sCanzone, 1, sCanzone.IndexOf("("))
            End If

            If Ok = False Then
                TestoRitorno = Artista.ToUpper.Trim & "§"
                TestoRitorno += sCanzone.ToUpper.Trim & "§§"
                TestoRitorno += "Nessun testo rilevato"
            Else
                Dim NomeArtista As String = ""
                Dim gf As New GestioneFilesDirectory

                If File.Exists(sNomeFile) = True Then
                    Dim Filetto As String

                    Try
                        Filetto = gf.LeggeFileIntero(sNomeFile)
                    Catch ex As Exception
                        Filetto = ""
                    End Try

                    If Filetto.IndexOf("<b>Did you mean ") > -1 Then
                        Dim NomePagina As String
                        NomePagina = Mid(Filetto, Filetto.IndexOf("<b>Did you mean ") + 1, Filetto.Length)
                        NomePagina = Mid(NomePagina, 1, NomePagina.IndexOf("</b> "))
                        NomePagina = Mid(NomePagina, NomePagina.IndexOf("href=" & Chr(34)) + 7, NomePagina.Length)
                        NomePagina = "http://lyrics.wikia.com" & Mid(NomePagina, 1, NomePagina.IndexOf(Chr(34)))

                        gd.CreaEPulisceCartellaDiLavoro()
                        Ok = gd.ScaricaPagina(NomePagina)
                        Thread.Sleep(500)

                        If Ok = False Then
                            TestoRitorno = NessunTestoRilevato()
                        Else
                            If File.Exists(sNomeFile) = True Then
                                Filetto = gf.LeggeFileIntero(sNomeFile)
                                If Filetto = "" Then
                                    For i As Integer = 1 To 5
                                        Thread.Sleep(1000)

                                        Ok = gd.ScaricaPagina(NomePagina)
                                        If Not Ok Then
                                            TestoRitorno = NessunTestoRilevato()
                                            Filetto = ""
                                            Exit For
                                        Else
                                            If File.Exists(sNomeFile) Then
                                                Filetto = gf.LeggeFileIntero(sNomeFile)
                                                If Filetto <> "" Then
                                                    Exit For
                                                End If
                                            End If
                                        End If
                                    Next
                                End If
                            Else
                                Filetto = ""

                                TestoRitorno = Artista.ToUpper.Trim & "§"
                                TestoRitorno += sCanzone.ToUpper.Trim & "§§"
                                TestoRitorno += "Nessun testo rilevato"
                            End If
                        End If
                    Else
                        If Filetto.Contains("<ul class=""redirectText"">") Then
                            Dim NomePagina As String = Filetto

                            NomePagina = Mid(NomePagina, NomePagina.IndexOf("<ul class=""redirectText"">") + 26, NomePagina.Length)
                            NomePagina = Mid(NomePagina, NomePagina.IndexOf("<a href=""") + 10, NomePagina.Length)
                            NomePagina = Mid(NomePagina, 1, NomePagina.IndexOf(Chr(34)))
                            NomePagina = "http://lyrics.wikia.com" & NomePagina

                            gd.CreaEPulisceCartellaDiLavoro()
                            Ok = gd.ScaricaPagina(NomePagina)
                            Thread.Sleep(500)

                            If Ok = False Then
                                TestoRitorno = NessunTestoRilevato()
                            Else
                                If File.Exists(sNomeFile) = True Then
                                    Filetto = gf.LeggeFileIntero(sNomeFile)
                                    If Filetto = "" Then
                                        For i As Integer = 1 To 5
                                            Thread.Sleep(1000)

                                            Ok = gd.ScaricaPagina(NomePagina)
                                            If Not Ok Then
                                                TestoRitorno = NessunTestoRilevato()
                                                Filetto = ""
                                                Exit For
                                            Else
                                                If File.Exists(sNomeFile) Then
                                                    Filetto = gf.LeggeFileIntero(sNomeFile)
                                                    If Filetto <> "" Then
                                                        Exit For
                                                    End If
                                                End If
                                            End If
                                        Next
                                    End If
                                Else
                                    Filetto = ""

                                    TestoRitorno = Artista.ToUpper.Trim & "§"
                                    TestoRitorno += sCanzone.ToUpper.Trim & "§§"
                                    TestoRitorno += "Nessun testo rilevato"
                                End If
                            End If
                            'Else
                            '    Filetto = ""
                        End If
                    End If

                    If Filetto = "" Then
                        TestoRitorno += Artista.ToUpper.Trim & "§"
                        TestoRitorno += sCanzone.ToUpper.Trim & "§§"
                        TestoRitorno += "Nessun testo rilevato"
                    Else
                        Dim Inizio As Integer = Filetto.IndexOf("<div class='lyricbox'>")
                        If Inizio > -1 Then
                            Filetto = Mid(Filetto, Inizio + 1, Filetto.Length)
                            Filetto = Mid(Filetto, Filetto.IndexOf(">") + 2, Filetto.Length)
                            Filetto = Mid(Filetto, 1, Filetto.IndexOf("<div class='lyricsbreak'>"))

                            Dim AppoggioCaratteri() As String = {}
                            Dim c As String

                            AppoggioCaratteri = Filetto.Split(";")
                            TestoRitorno = ""
                            Dim quanti As Integer = AppoggioCaratteri.Length - 1
                            Dim c1 As Long = 0

                            Do While c1 <= quanti
                                If AppoggioCaratteri(c1) <> "" Then
                                    If AppoggioCaratteri(c1).IndexOf("<br />") = -1 Then
                                        If AppoggioCaratteri(c1).IndexOf("<span") > -1 Then
                                            AppoggioCaratteri(c1) = Mid(AppoggioCaratteri(c1), AppoggioCaratteri(c1).IndexOf("/span>") + 7, AppoggioCaratteri(c1).Length)
                                        End If
                                        c = AppoggioCaratteri(c1).Replace("&#", "").Replace("<b>", "").Replace("</b>", "").Replace("<i>", "").Replace("</i>", "")
                                        If c <> "" And IsNumeric(c) And c.Length < 4 Then
                                            Try
                                                TestoRitorno += Chr(c)
                                            Catch ex As Exception
                                                TestoRitorno += "?"
                                            End Try
                                        Else
                                            TestoRitorno += "?"
                                        End If
                                    Else
                                        TestoRitorno += "§"
                                        AppoggioCaratteri(c1) = AppoggioCaratteri(c1).Replace("<br />", "")
                                        c = AppoggioCaratteri(c1).Replace("&#", "").Replace("<b>", "").Replace("</b>", "").Replace("<i>", "").Replace("</i>", "")
                                        If c <> "" And IsNumeric(c) And c.Length < 4 Then
                                            Try
                                                TestoRitorno += Chr(c)
                                            Catch ex As Exception
                                                TestoRitorno += "?"
                                            End Try
                                        Else
                                            TestoRitorno += "?"
                                        End If
                                    End If
                                Else
                                    ' Stop
                                End If
                                c1 += 1
                            Loop
                            'If TestoRitorno.Length < 400 And quanti > 0 Then Stop

                            TestoRitorno = sArtista.ToUpper & "§" & sCanzone.ToUpper & "§§" & TestoRitorno

                            If TestoRitorno = "" Then
                                TestoRitorno += Artista.ToUpper.Trim & "§"
                                TestoRitorno += sCanzone.ToUpper.Trim & "§§"
                                TestoRitorno += "Nessun testo rilevato"
                            End If
                        End If
                    End If
                Else
                    TestoRitorno += Artista.ToUpper.Trim & "§"
                    TestoRitorno += sCanzone.ToUpper.Trim & "§§"
                    TestoRitorno += "Nessun testo rilevato"
                End If
            End If

            'If TestoRitorno.ToUpper.IndexOf(Artista.ToUpper) = -1 And TestoRitorno.ToUpper.IndexOf(Canzone.ToUpper) = -1 Then
            '    TestoRitorno = Artista.ToUpper.Trim & "§" & sCanzone.ToUpper.Trim & "§§" & TestoRitorno
            'End If

            If TestoRitorno = "" Then
                TestoRitorno += Artista.ToUpper.Trim & "§"
                TestoRitorno += sCanzone.ToUpper.Trim & "§§"
                TestoRitorno += "Nessun testo rilevato"
            End If

            Dim tt As String = r.SistemaTestoPerDB(TestoRitorno)
            If tt.Length > 4000 Then
                tt = Mid(tt, 1, 3997) & "..."
            End If
            Sql = "Update ListaCanzone2 Set Testo='" & tt & "' Where idCanzone=" & idCanzone
            DB.EsegueSql(conn, Sql)

            If Not CeTestoTradotto Then
                ' Traduttore
                TestoTradotto = ""

                If TestoRitorno <> "" Then
                    Dim rit As String = ""

                    Try
                        Dim t As New YandexTranslate.YandexTranslator
                        Dim Titolone As String = ""
                        rit = t.translate(TestoRitorno.Replace(";", ""), "trnsl.1.1.20170415T165222Z.de2fde86333c7b9e.04188d1030d55d077f57f6efb3b577d8998ae360", "it")
                        If rit.IndexOf("§§") > -1 Then
                            Titolone = rit.Substring(0, rit.IndexOf("§§"))
                            rit = MetteMaiuscoleInizioRiga(rit.Replace(Titolone, ""))
                            Titolone = Titolone.ToUpper
                            rit = Titolone & rit
                        Else
                            rit = MetteMaiuscoleInizioRiga(rit)
                        End If

                        Sql = "Update ListaCanzone2 Set TestoTradotto='" & r.SistemaTestoPerDB(rit) & "' Where idCanzone=" & idCanzone
                        DB.EsegueSql(conn, Sql)

                        'AzzeraContatore += 1
                        'If AzzeraContatore > 5 Then
                        '    QuanteTraduzioniHaSaltato = 0
                        'End If
                    Catch ex As Exception
                        'QuanteTraduzioniHaSaltato += 1
                    End Try
                End If
            End If
            ' Traduttore
        End If

        ' PrendeMembriBand(sArtista)
    End Sub

    'Private AzzeraContatore As Integer = 0

    Private Function MetteMaiuscoleInizioRiga(Cosa As String) As String
        Dim Ritorno As String = ""
        Dim Campi() As String = Cosa.Split("§")

        For i As Integer = 0 To Campi.Length - 1
            Campi(i) = Campi(i).Trim
            Campi(i) = Mid(Campi(i), 1, 1).ToUpper & Mid(Campi(i), 2, Campi(i).Length)
            Ritorno &= Campi(i) & "§"
        Next

        Return Ritorno
    End Function
End Class
