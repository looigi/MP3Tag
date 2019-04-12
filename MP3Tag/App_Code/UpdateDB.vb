Imports System.IO

Public Class UpdateDB
    Public VersioneDBApplicazione As Integer = 4

    Public Sub ControllaAggiornamentoDB()
        If File.Exists(PathDB) Then
            Dim DB As New SQLSERVERCE
            Dim conn As Object = CreateObject("ADODB.Connection")
            Dim rec As Object = CreateObject("ADODB.Recordset")
            Dim Sql As String
            DB.ImpostaNomeDB(PathDB)
            DB.LeggeImpostazioniDiBase()
            conn = DB.ApreDB()

            Sql = "Select * From Traduzioni"
            rec = DB.LeggeQuery(conn, Sql)
            If rec Is Nothing = True Then
                Sql = "Create Table Traduzioni (Canzone nvarchar(400) Not Null, Testo nvarchar(4000), CONSTRAINT PK_Traduzioni PRIMARY KEY(Canzone))"
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

            Sql = "Select * From VersioneDB"
            rec = DB.LeggeQuery(conn, Sql)
            If rec Is Nothing = True Then
                Sql = "Create Table VersioneDB (Versione int)"
            Else
                Sql = ""
            End If
            Try
                rec.Close()
            Catch ex As Exception

            End Try

            If Sql <> "" Then
                DB.EsegueSql(conn, Sql)

                Sql = "Insert Into VersioneDB Values(-1)"
                DB.EsegueSql(conn, Sql)
            End If

            EsegueAggiornamentoDB(DB, conn)

            conn.Close()
            DB = Nothing
        End If
    End Sub

    Private Sub EsegueAggiornamentoDB(DB As SQLSERVERCE, Conn As Object)
        Dim rec As Object = CreateObject("ADODB.Recordset")
        Dim Sql As String
        Dim VersioneDB As Integer = 0

        Sql = "Select Versione From VersioneDB"
        rec = DB.LeggeQuery(Conn, Sql)
        If Not rec Is Nothing Then
            If rec.eof Then
                VersioneDB = 0
            Else
                VersioneDB = rec(0).value
            End If
            rec.close()
        End If

        If VersioneDB < VersioneDBApplicazione Then
            If VersioneDB = 1 Then
                Sql = "Create Table PrendeVideo (idCanzone Integer, PrendeVideo nvarchar(1))"
                DB.EsegueSql(Conn, Sql)
            End If
            If VersioneDB = 2 Then
                Sql = "Create Table Ascoltate (idCanzone Integer, DataOra nvarchar(20))"
                DB.EsegueSql(Conn, Sql)
            End If
            If VersioneDB = 3 Then
                Sql = "Create Table Members (Gruppo nvarchar(50), Progressivo Integer, Membro nvarchar(50), Durata nvarchar(30), Attuale nvarchar(1))"
                DB.EsegueSql(Conn, Sql)
            End If

            Sql = "Update VersioneDB Set Versione=" & VersioneDBApplicazione
            DB.EsegueSql(Conn, Sql)
        End If
    End Sub
End Class
