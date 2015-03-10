Imports System.Data.SQLite

Public Class SeatPlanCorner

    Public Sub Arrangement()
        Dim ClassID = TextBox1.Text
        Dim count As Integer
        count = 1
        DBConn()
        Dim querystring As String = "SELECT LastName FROM '" & ClassID & "' ORDER BY LastName "
        Dim command As New SQLiteCommand(querystring, SQLCONN)
        Dim reader As SQLiteDataReader = command.ExecuteReader
        While reader.Read
            Dim labels = "Label" & count.ToString
            Me.Controls(labels).Text = reader.GetValue(0)
            count += 1

            If count > 45 Then
                Exit While
            End If
        End While
        reader.Close()
        SQLDR.Dispose()
        SQLCONN.Close()
    End Sub

    Private Sub HomeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles HomeToolStripMenuItem.Click

        AddGrades.Show()
        Me.Hide()
    End Sub

    Private Sub PictureBox4_Click(sender As Object, e As EventArgs) Handles PictureBox4.Click

    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        If MessageBox.Show("Do you want to exit?", "Class Manager", _
       MessageBoxButtons.YesNo, MessageBoxIcon.Warning) _
       = DialogResult.Yes Then
            Application.Exit()
        End If
    End Sub



  
    Private Sub Label41_Click(sender As Object, e As EventArgs) Handles Label60.Click

    End Sub


    Private Sub SeatPlanCorner_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim ClassID = TextBox1.Text
        Dim count As Integer
        count = 1
        DBConn()
        Dim querystring As String = "SELECT LastName FROM '" & ClassID & "' ORDER BY RANDOM() "
        Dim command As New SQLiteCommand(querystring, SQLCONN)
        Dim reader As SQLiteDataReader = command.ExecuteReader
        While reader.Read
            Dim labels = "Label" & count.ToString
            Me.Controls(labels).Text = reader.GetValue(0)
            count += 1

            If count > 45 Then
                Exit While
            End If
        End While
        reader.Close()
        SQLDR.Dispose()
        SQLCONN.Close()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim ClassID = TextBox1.Text
        Dim count As Integer
        count = 1
        DBConn()
        Dim querystring As String = "SELECT LastName FROM '" & ClassID & "' ORDER BY LastName "
        Dim command As New SQLiteCommand(querystring, SQLCONN)
        Dim reader As SQLiteDataReader = command.ExecuteReader
        While reader.Read
            Dim labels = "Label" & count.ToString
            Me.Controls(labels).Text = reader.GetValue(0)
            count += 1

            If count > 45 Then
                Exit While
            End If
        End While
        reader.Close()
        SQLDR.Dispose()
        SQLCONN.Close()
    End Sub
End Class