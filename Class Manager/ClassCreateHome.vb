Imports System.Data.SQLite


Public Class ClassCreateHome


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Create.Click
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
        ElseIf QuizWeight + ClassStandingWeight + AttendanceWeight + PeriodicalExamWeight < 100 Then
            MsgBox("Weights must total to 100")
        ElseIf QuizWeight + ClassStandingWeight + AttendanceWeight + PeriodicalExamWeight > 100 Then
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
                    SQLSTR = "CREATE TABLE '" & TextBox2.Text & "' (StudentID INTEGER NOT NULL UNIQUE, FirstName TEXT, LastName TEXT, Q1 INTEGER DEFAULT 0, Q2 INTEGER DEFAULT 0, Q3 INTEGER DEFAULT 0, Q4 INTEGER DEFAULT 0, Q5 INTEGER DEFAULT 0, Q6 INTEGER DEFAULT 0, S1 INTEGER DEFAULT 0, S2 INTEGER DEFAULT 0, S3 INTEGER DEFAULT 0, A1 INTEGER DEFAULT 0, A2 INTEGER DEFAULT 0, A3 INTEGER DEFAULT 0, PrelimExam INTEGER DEFAULT 0, MidtermExam INTEGER DEFAULT 0, FinalExam INTEGER DEFAULT 0, PrelimTotal INTEGER DEFAULT 0, MidtermTotal INTEGER DEFAULT 0, FinalTotal INTEGER DEFAULT 0, FinalFinal INTEGER DEFAULT 0)"
                    alterDB()
                    MsgBox("Class created!", , msgboxtitle)
                    ClassCreateHomeAddStudents.TextBox4.Text = TextBox2.Text
                    ClassCreateHomeAddStudents.Show()
                    Me.Hide()
                End If
            End If
        End If
    End Sub

    Private Sub Create_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles Create.MouseHover

        Create.Image = My.Resources.Browse_and_Update_pressed

    End Sub
    Private Sub Create_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Create.MouseLeave

        Create.Image = My.Resources.Browse_and_Update

    End Sub

    Private Sub Close_Click(sender As Object, e As EventArgs) Handles Close.Click
        If MessageBox.Show("Do you want to exit?", "Class Manager", _
       MessageBoxButtons.YesNo, MessageBoxIcon.Warning) _
       = DialogResult.Yes Then
            Application.Exit()
        End If
    End Sub

    Private Sub HomeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles HomeToolStripMenuItem.Click
        Me.Hide()
        ClassHome.Show()

    End Sub
End Class