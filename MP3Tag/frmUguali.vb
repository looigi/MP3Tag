Imports System.IO

Public Class frmUguali
    Private Canzone1() As String
    Private Canzone2() As String
    Private Stato() As Integer
    Private Numero() As Integer
    Private qCanzoni As Integer
    Private Quale As Integer

    Private Sub frmUguali_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If ControllaSeCiSonoUguali() = False Then
            MsgBox("Nessun rilevamento")
            Me.Hide()
            Exit Sub
        End If

        LeggeRighe()
    End Sub

    Private Sub LeggeRighe()
        Dim gf As New GestioneFilesDirectory
        Dim DB As New SQLSERVERCE
        Dim conn As Object = CreateObject("ADODB.Connection")
        Dim rec As Object = CreateObject("ADODB.Recordset")
        Dim Sql As String
        DB.ImpostaNomeDB(PathDB)
        DB.LeggeImpostazioniDiBase()
        conn = DB.ApreDB()
        Dim Trovate As Boolean = False

        Erase Canzone1
        Erase Canzone2
        Erase Stato
        Erase Numero

        Sql = "Select * From Uguali"
        rec = DB.LeggeQuery(conn, Sql)
        Do Until rec.Eof
            Trovate = True

            ReDim Preserve Canzone1(qCanzoni)
            ReDim Preserve Canzone2(qCanzoni)
            ReDim Preserve Stato(qCanzoni)
            ReDim Preserve Numero(qCanzoni)
            Canzone1(qCanzoni) = rec("Prima").Value
            Canzone2(qCanzoni) = rec("Seconda").Value
            Stato(qCanzoni) = 0
            Numero(qCanzoni) = rec("idUguale").Value
            qCanzoni += 1

            rec.MoveNext()
        Loop
        rec.Close()

        conn.Close()
        DB = Nothing

        If Trovate = False Then
            Me.Hide()
            Exit Sub
        Else
            Quale = 1
            ScriveCanzoni()
        End If
    End Sub

    Private Function ControllaSeCiSonoUguali() As Boolean
        Dim DB As New SQLSERVERCE
        Dim conn As Object = CreateObject("ADODB.Connection")
        Dim rec As Object = CreateObject("ADODB.Recordset")
        Dim Sql As String
        DB.ImpostaNomeDB(PathDB)
        DB.LeggeImpostazioniDiBase()
        conn = DB.ApreDB()
        Dim Ritorno As Boolean = True

        Sql = "Select * From Uguali"
        rec = DB.LeggeQuery(conn, Sql)
        If rec.Eof = True Then
            Ritorno = False
        End If
        rec.Close()

        conn.Close()
        DB = Nothing

        Return Ritorno
    End Function

    Private Sub ScriveCanzoni()
        Dim gf As New GestioneFilesDirectory
        lblContatore.Text = Quale & "/" & qCanzoni

        If File.Exists(Canzone1(Quale)) = True Then
            lblPrimoDir.Text = gf.TornaNomeDirectoryDaPath(Canzone1(Quale))
            lblPrimoFile.Text = gf.TornaNomeFileDaPath(Canzone1(Quale))
            lblPrimoDime.Text = gf.TornaDimensioneFile(Canzone1(Quale))
            cmdEliminaRicorrenza1.Visible = True
        Else
            lblPrimoDir.Text = ""
            lblPrimoFile.Text = ""
            lblPrimoDime.Text = ""
            cmdEliminaRicorrenza1.Visible = False
        End If

        If File.Exists(Canzone1(Quale)) = True Then
            lblSecondoDir.Text = gf.TornaNomeDirectoryDaPath(Canzone2(Quale))
            lblSecondoFile.Text = gf.TornaNomeFileDaPath(Canzone2(Quale))
            lblSecondoDime.Text = gf.TornaDimensioneFile(Canzone1(Quale))
            cmdEliminaRicorrenza2.Visible = True
        Else
            lblSecondoDir.Text = ""
            lblSecondoFile.Text = ""
            lblSecondoDime.Text = ""
            cmdEliminaRicorrenza2.Visible = False
        End If

        gf = Nothing
        ScriveStato()
    End Sub

    Private Sub ScriveStato()
        Select Case Stato(Quale)
            Case 0
                lblStato.Text = ""
            Case 1
                lblStato.Text = "Eliminato 1"
            Case 2
                lblStato.Text = "Eliminato 2"
            Case 3
                lblStato.Text = "Elimina ricorrenza"
            Case 4
                lblStato.Text = "Elimina ricorrenza"
        End Select
    End Sub

    Private Sub cmdUscita_Click(sender As Object, e As EventArgs) Handles cmdUscita.Click
        frmMain.Show()
        Me.Close()
    End Sub

    Private Sub cmdAvanti_Click(sender As Object, e As EventArgs) Handles cmdAvanti.Click
        If Quale < qCanzoni Then
            Quale += 1
        Else
            Quale = 1
        End If

        ScriveCanzoni()
    End Sub

    Private Sub cmdIndietro_Click(sender As Object, e As EventArgs) Handles cmdIndietro.Click
        If Quale > 1 Then
            Quale -= 1
        Else
            Quale = qCanzoni
        End If

        ScriveCanzoni()
    End Sub

    Private Sub cmdElimina1_Click(sender As Object, e As EventArgs) Handles cmdElimina1.Click
        Stato(Quale) = 1

        cmdAvanti_Click(sender, e)
        ScriveCanzoni()
    End Sub

    Private Sub cmdElimina2_Click(sender As Object, e As EventArgs) Handles cmdElimina2.Click
        Stato(Quale) = 2

        cmdAvanti_Click(sender, e)
        ScriveCanzoni()
    End Sub

    Private Sub cmdAnnullaStato_Click(sender As Object, e As EventArgs) Handles cmdAnnullaStato.Click
        Stato(Quale) = 0

        ScriveCanzoni()
    End Sub

    Private Sub cmdAggiorna_Click(sender As Object, e As EventArgs) Handles cmdAggiorna.Click
        Dim gf As New GestioneFilesDirectory
        Dim DB As New SQLSERVERCE
        Dim conn As Object = CreateObject("ADODB.Connection")
        Dim rec As Object = CreateObject("ADODB.Recordset")
        Dim Sql As String
        DB.ImpostaNomeDB(PathDB)
        DB.LeggeImpostazioniDiBase()
        conn = DB.ApreDB()

        For i As Integer = 1 To Quale
            Select Case Stato(i)
                Case 1
                    gf.EliminaFileFisico(Canzone1(i))

                    Sql = "Delete From Uguali Where idUguale=" & Numero(i)
                    DB.EsegueSql(conn, Sql)
                Case 2
                    gf.EliminaFileFisico(Canzone2(i))

                    Sql = "Delete From Uguali Where idUguale=" & Numero(i)
                    DB.EsegueSql(conn, Sql)
                Case 3
                    Sql = "Delete From Uguali Where idUguale=" & Numero(i)
                    DB.EsegueSql(conn, Sql)
                Case 4
                    Sql = "Delete From Uguali Where idUguale=" & Numero(i)
                    DB.EsegueSql(conn, Sql)
            End Select
        Next

        conn.Close()
        DB = Nothing
        gf = Nothing

        LeggeRighe()

        MsgBox("Elaborazione effettuata")
    End Sub

    Private Sub cmdEliminaRicorrenza1_Click(sender As Object, e As EventArgs) Handles cmdEliminaRicorrenza1.Click
        Stato(Quale) = 3

        cmdAvanti_Click(sender, e)
        ScriveCanzoni()
    End Sub

    Private Sub cmdEliminaRicorrenza2_Click(sender As Object, e As EventArgs) Handles cmdEliminaRicorrenza2.Click
        Stato(Quale) = 4

        cmdAvanti_Click(sender, e)
        ScriveCanzoni()
    End Sub
End Class