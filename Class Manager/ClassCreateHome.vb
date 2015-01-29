Imports System.Data.SQLite


Public Class ClassCreateHome


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim PrelimWeight As Integer = TextBox3.Text
        Dim MidtermWeight As Integer = TextBox4.Text
        Dim FinalWeight As Integer = TextBox5.Text
        Dim PassingMark As Integer = TextBox6.Text
        Dim QuizWeight As Integer = TextBox7.Text
        Dim ClassStandingWeight As Integer = TextBox8.Text
        Dim AttendanceWeight As Integer = TextBox9.Text
        Dim PeriodicalExamWeight As Integer = TextBox10.Text

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
                    SQLSTR = "INSERT INTO MasterClasslist (Name, Desc, PrelimWeight, MidtermWeight, FinalWeight, PassingMark, QuizWeight, ClassStandingWeight, AttendanceWeight, PeriodicalExamWeight) VALUES ('" & TextBox1.Text & "', '" & RichTextBox1.Text & "', '" & PrelimWeight & "' , '" & MidtermWeight & "' , '" & FinalWeight & "' , '" & PassingMark & "', '" & QuizWeight & "' , '" & ClassStandingWeight & "' , '" & AttendanceWeight & "' , '" & PeriodicalExamWeight & "')"
                    alterDB()
                    Dim querystring As String = "SELECT ClassID FROM MasterClasslist WHERE Name = ('" & TextBox1.Text & "')"
                    Dim command As New SQLiteCommand(querystring, SQLCONN)
                    Dim reader As SQLiteDataReader = command.ExecuteReader
                    While reader.Read
                        TextBox2.Text = reader.GetValue(0)
                    End While
                    reader.Close()
                    SQLSTR = "CREATE TABLE '" & TextBox2.Text & "' (StudentID INTEGER NOT NULL UNIQUE, FirstName TEXT, LastName TEXT, Q1 INTEGER, Q2 INTEGER, Q3 INTEGER, Q4 INTEGER, Q5 INTEGER, Q6 INTEGER, S1 INTEGER, S2 INTEGER, S3 INTEGER, A1 INTEGER, A2 INTEGER, A3 INTEGER, PrelimExam INTEGER, MidtermExam INTEGER, FinalExam INTEGER, PrelimTotal INTEGER, MidtermTotal INTEGER, FinalTotal INTEGER)"
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