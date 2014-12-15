Imports System.Data
Imports System.Data.SqlClient

Module DbConnections
    Public SQLCONN As New SqlConnection
    Public SQLCMD As New SqlCommand
    Public SQLDA As New SqlDataAdapter
    Public SQLDR As SqlDataReader
    Public SQLSTR As String
    Public msgboxtitle = ""

    Public Sub DBConn()
        If SQLCONN.State = ConnectionState.Open Then SQLCONN.Close()
        Try
            SQLCONN = New SqlConnection("Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Miguel Rigunay\Desktop\Class Manager\Class Manager\ClassRecords.mdf;Integrated Security=True")
            SQLCONN.Open()
        Catch ex As Exception
            MsgBox("CONNECTION UNSUCCESSFUL", MsgBoxStyle.Critical, msgboxtitle)
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
