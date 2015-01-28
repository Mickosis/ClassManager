Imports System.Data.SQLite


Public Class ClassCreateHome


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim PrelimWeight As Integer = TextBox3.Text
        Dim MidtermWeight As Integer = TextBox4.Text
        Dim FinalWeight As Integer = TextBox5.Text
        Dim PassingMark As Integer = TextBox6.Text
        If PrelimWeight + MidtermWeight + FinalWeight < 100 Then
            MsgBox("Weights must total to 100")
        ElseIf PrelimWeight + MidtermWeight + FinalWeight > 100 Then
            MsgBox("Weights must not exceed 100")
        Else
            Dim confirm As DialogResult = MsgBox("Are all information correct?", MsgBoxStyle.YesNo, msgboxtitle)
            If confirm = Windows.Forms.DialogResult.Yes Then
                If TextBox1.Text = "" Then
                    MsgBox("Please choose a name for your class", MsgBoxStyle.OkOnly, msgboxtitle)
                Else
                    DBConn()
                    SQLSTR = "INSERT INTO MasterClasslist (Name, Desc, PrelimWeight, MidtermWeight, FinalWeight, PassingMark) VALUES ('" & TextBox1.Text & "', '" & RichTextBox1.Text & "', '" & PrelimWeight & "' , '" & MidtermWeight & "' , '" & FinalWeight & "' , '" & PassingMark & "')"
                    alterDB()
                    Dim querystring As String = "SELECT ClassID FROM MasterClasslist WHERE Name = ('" & TextBox1.Text & "')"
                    Dim command As New SQLiteCommand(querystring, SQLCONN)
                    Dim reader As SQLiteDataReader = command.ExecuteReader
                    While reader.Read
                        TextBox2.Text = reader.GetValue(0)
                    End While
                    reader.Close()
                    SQLSTR = "CREATE TABLE '" & TextBox2.Text & "' (StudentID INTEGER NOT NULL UNIQUE, FirstName TEXT, LastName TEXT, Prelim INTEGER, Midterms INTEGER, Finals INTEGER)"
                    alterDB()
                    MsgBox("Class created!", , msgboxtitle)
                    ClassCreateHomeAddStudents.TextBox4.Text = TextBox2.Text
                    ClassCreateHomeAddStudents.Show()
                    Me.Hide()
                End If
            End If
        End If
    End Sub

End Class