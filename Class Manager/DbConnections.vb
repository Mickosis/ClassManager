Imports System.Data
Imports System.Data.SQLite

Module DbConnections
    Public SQLCONN As New SQLiteConnection
    Public SQLCMD As New SQLiteCommand
    Public SQLDA As New SQLiteDataAdapter
    Public SQLDR As SQLiteDataReader
    Public SQLSTR As String
    Public msgboxtitle = ""


    Public Sub DBConn()
        If SQLCONN.State = ConnectionState.Open Then SQLCONN.Close()

        Try
            SQLCONN = New SQLiteConnection("Data Source=ClassRecords.db")
            SQLCONN.Open()
        Catch ex As SQLiteException
            MsgBox("An exception occurred:" & ex.Message)
        End Try

    End Sub

    Public Sub alterDB()
        SQLCMD.CommandText = SQLSTR
        SQLCMD.Connection = SQLCONN
        SQLCMD.ExecuteNonQuery()
    End Sub

    Public Sub readDB()
        SQLCMD.CommandText = SQLSTR
        SQLCMD.Connection = SQLCONN
        SQLDA.SelectCommand = SQLCMD
        SQLDR = SQLCMD.ExecuteReader()
    End Sub

End Module
