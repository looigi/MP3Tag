Imports System.IO

Public Class frmSettaggi

    Private StaModificando As Boolean = False

    Private Sub frmSettaggi_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ImpostaMaschera()
        LeggeAlias()
    End Sub

    Private Sub LeggeAlias()
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
            lstCompleti.Items.Clear()
            Do Until rec.Eof
                lstCompleti.Items.Add(rec("idAlias").Value & ";" & rec("Cartella").Value & ";" & rec("Diventa").Value & ";")

                rec.MoveNext()
            Loop
            rec.Close()

            Sql = "Select * From AliasCartelleContenuto"
            rec = DB.LeggeQuery(conn, Sql)
            lstContenuto.Items.Clear()
            Do Until rec.Eof
                lstContenuto.Items.Add(rec("idContenuto").Value & ";" & rec("Contenuto").Value & ";" & rec("Destinazione").Value & ";")

                rec.MoveNext()
            Loop
            rec.Close()

            conn.Close()
            DB = Nothing
        End If

        lblAlias1.Text = ""
        lblAlias2.Text = ""
    End Sub

    Private Sub ImpostaMaschera()
        If TipoCollegamento.Trim.ToUpper = "PROXY" Then
            optProxy.Checked = True
            optNormale.Checked = False
            Panel1.Enabled = True
        Else
            optProxy.Checked = False
            optNormale.Checked = True
            Panel1.Enabled = False
        End If

        txtUtenza.Text = Utenza
        txtPassword.Text = Password
        txtDominio.Text = Dominio
    End Sub

    Private Sub optProxy_Click(sender As Object, e As EventArgs) Handles optProxy.Click
        optNormale.Checked = False
        Panel1.Enabled = True
        TipoCollegamento = "PROXY"

        SaveSetting("MP3Tag", "Settaggi", "TipoCollegamento", "Proxy")
    End Sub

    Private Sub optNormale_Click(sender As Object, e As EventArgs) Handles optNormale.Click
        optProxy.Checked = False
        Panel1.Enabled = False
        TipoCollegamento = "Normale"

        SaveSetting("MP3Tag", "Settaggi", "TipoCollegamento", "Normale")
    End Sub

    Private Sub cmdSalva_Click(sender As Object, e As EventArgs) Handles cmdSalva.Click
        SaveSetting("MP3Tag", "Settaggi", "Utenza", txtUtenza.Text)
        SaveSetting("MP3Tag", "Settaggi", "Password", txtPassword.Text)
        SaveSetting("MP3Tag", "Settaggi", "Dominio", txtDominio.Text)

        Utenza = txtUtenza.Text
        Password = txtPassword.Text
        Dominio = txtDominio.Text

        MsgBox("Dati salvati")
    End Sub

    Private Sub lstCompleti_Click(sender As Object, e As EventArgs) Handles lstCompleti.Click
        Dim Campi() As String = lstCompleti.Text.Split(";")

        lblAlias1.Text = Campi(0)
        txtCartella.Text = Campi(1)
        txtDiventa.Text = Campi(2)
    End Sub

    Private Sub lstContenuto_Click(sender As Object, e As EventArgs) Handles lstContenuto.Click
        Dim Campi() As String = lstContenuto.Text.Split(";")

        lblAlias2.Text = Campi(0)
        txtContenuto.Text = Campi(1)
        txtDestinazione.Text = Campi(2)
    End Sub

    Private Sub cmdPulisce1_Click(sender As Object, e As EventArgs) Handles cmdPulisce1.Click
        lblAlias1.Text = ""
        txtCartella.Text = ""
        txtDiventa.Text = ""
    End Sub

    Private Sub cmdPulisce2_Click(sender As Object, e As EventArgs) Handles cmdPulisce2.Click
        lblAlias2.Text = ""
        txtContenuto.Text = ""
        txtDestinazione.Text = ""
    End Sub

    Private Sub cmdSalva1_Click(sender As Object, e As EventArgs) Handles cmdSalva1.Click
        Dim DB As New SQLSERVERCE
        Dim conn As Object = CreateObject("ADODB.Connection")
        Dim rec As Object = CreateObject("ADODB.Recordset")
        Dim Sql As String
        Dim Numero As Integer
        DB.ImpostaNomeDB(PathDB)
        DB.LeggeImpostazioniDiBase()
        conn = DB.ApreDB()

        If lblAlias1.Text = "" Then
            Sql = "Select Max(idAlias)+1 From AliasCartelle"
            rec = DB.LeggeQuery(conn, Sql)
            If rec(0).Value Is DBNull.Value = True Then
                Numero = 1
            Else
                Numero = rec(0).Value
            End If
            rec.Close()

            Sql = "Insert Into AliasCartelle Values (" & Numero & ",'" & txtCartella.Text.Replace("'", "''") & "', '" & txtDiventa.Text.Replace("'", "''") & "')"
        Else
            Sql = "Update AliasCartelle Set Cartella='" & txtCartella.Text.Replace("'", "''") & "', Diventa='" & txtDiventa.Text.Replace("'", "''") & "' Where idAlias=" & lblAlias1.Text
        End If
        DB.EsegueSql(conn, Sql)

        conn.Close()
        DB = Nothing

        lblAlias1.Text = ""
        txtCartella.Text = ""
        txtDiventa.Text = ""

        LeggeAlias()
    End Sub

    Private Sub cmdSalva2_Click(sender As Object, e As EventArgs) Handles cmdSalva2.Click
        Dim DB As New SQLSERVERCE
        Dim conn As Object = CreateObject("ADODB.Connection")
        Dim rec As Object = CreateObject("ADODB.Recordset")
        Dim Sql As String
        Dim Numero As Integer
        DB.ImpostaNomeDB(PathDB)
        DB.LeggeImpostazioniDiBase()
        conn = DB.ApreDB()

        If lblAlias2.Text = "" Then
            Sql = "Select Max(idContenuto)+1 From AliasCartelleContenuto"
            rec = DB.LeggeQuery(conn, Sql)
            If rec(0).Value Is DBNull.Value = True Then
                Numero = 1
            Else
                Numero = rec(0).Value
            End If
            rec.Close()

            Sql = "Insert Into AliasCartelleContenuto Values (" & Numero & ",'" & txtContenuto.Text.Replace("'", "''") & "', '" & txtDestinazione.Text.Replace("'", "''") & "')"
        Else
            Sql = "Update AliasCartelleContenuto Set Contenuto='" & txtContenuto.Text.Replace("'", "''") & "', Destinazione='" & txtDestinazione.Text.Replace("'", "''") & "' Where idContenuto=" & lblAlias2.Text
        End If
        DB.EsegueSql(conn, Sql)

        conn.Close()
        DB = Nothing

        lblAlias2.Text = ""
        txtContenuto.Text = ""
        txtDestinazione.Text = ""

        LeggeAlias()
    End Sub

	Private Sub cmdEliminaRemoti_Click(sender As Object, e As EventArgs) Handles cmdEliminaRemoti.Click
		Dim s As New ServiceReference1.looWPlayerSoapClient

		s.EliminaListaCanzoniDaEliminare()

		MsgBox("Lista canzoni eliminata", vbInformation)
	End Sub
End Class