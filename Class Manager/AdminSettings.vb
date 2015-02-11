Imports System.Data.SQLite

Public Class AdminSettings

    Private Sub AdminSettings_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DBConn()
        Dim querystring As String = "SELECT * FROM GlobalGrades"
        Dim command As New SQLiteCommand(querystring, SQLCONN)
        Dim reader As SQLiteDataReader = command.ExecuteReader
        While reader.Read
            TextBox1.Text = reader.GetValue(0)
            TextBox2.Text = reader.GetValue(1)
            TextBox3.Text = reader.GetValue(2)
            TextBox4.Text = reader.GetValue(3)
            TextBox5.Text = reader.GetValue(4)
            TextBox6.Text = reader.GetValue(5)
            TextBox7.Text = reader.GetValue(6)
            TextBox8.Text = reader.GetValue(7)
        End While
        reader.Close()
    End Sub

    Private Sub TextBox_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox1.KeyPress, TextBox2.KeyPress, TextBox3.KeyPress, TextBox4.KeyPress, TextBox5.KeyPress, TextBox6.KeyPress, TextBox6.KeyPress, TextBox7.KeyPress, TextBox8.KeyPress
        If Asc(e.KeyChar) <> 13 AndAlso Asc(e.KeyChar) <> 8 AndAlso Not IsNumeric(e.KeyChar) Then
            MessageBox.Show("Please enter numbers only")
            e.Handled = True
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        'Textbox Fields
        Dim PMTotalCS As Integer = TextBox1.Text
        Dim PMExam As Integer = TextBox2.Text
        Dim FTotalCS As Integer = TextBox3.Text
        Dim FExam As Integer = TextBox4.Text
        Dim PrelimWeight As Integer = TextBox5.Text
        Dim MidtermWeight As Integer = TextBox6.Text
        Dim FinalWeight As Integer = TextBox7.Text
        Dim PassingMark As Integer = TextBox8.Text

        'Computations for If/Else
        Dim PMFinalComputeGrade As Integer = PMTotalCS + PMExam
        Dim FFinalComputeGrade As Integer = FTotalCS + FExam
        Dim GradingSystem As Integer = PrelimWeight + MidtermWeight + FinalWeight

        'Button Click Validates
        'Total Period Grades
        If PMFinalComputeGrade > 100 Then
            MsgBox("Prelim/Midterm computation must not exceed 100%, current is " & PMFinalComputeGrade)
        ElseIf PMFinalComputeGrade < 100 Then
            MsgBox("Prelim/Midterm computation must be equal to 100%, current is " & PMFinalComputeGrade)
        ElseIf FFinalComputeGrade > 100 Then
            MsgBox("Finals computation must not exceed 100%, current is " & FFinalComputeGrade)
        ElseIf FFinalComputeGrade < 100 Then
            MsgBox("Finals computation must be equal to 100%, current is " & FFinalComputeGrade)
            'Semestral Weights
        ElseIf GradingSystem > 100 Then
            MsgBox("Semestral computation must not exced 100%, current is " & GradingSystem)
        ElseIf GradingSystem < 100 Then
            MsgBox("Semestral computation must be equal too 100%, current is " & GradingSystem)
        ElseIf PassingMark > 100 Then
            MsgBox("Passing grade must not exceed 100%")
        ElseIf PassingMark = 0 Then
            MsgBox("Passing grade must not be 0%")
        Else
            DBConn()
            SQLSTR = "UPDATE GlobalGrades SET PMTotalCS = '" & PMTotalCS & "', PMExam = '" & PMExam & "', FTotalCS = '" & FTotalCS & "', FExam = '" & FExam & "', PrelimWeight = '" & PrelimWeight & "', MidtermWeight = '" & MidtermWeight & "', FinalWeight = '" & FinalWeight & "', PassingMark = '" & PassingMark & "'"
            alterDB()
            SQLCONN.Close()
            SQLDR.Dispose()
            MsgBox("Update successful!", , msgboxtitle)
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If TextBox9.Text = TextBox10.Text Then
            DBConn()
            SQLSTR = "UPDATE LoginCredentials SET password = '" & TextBox10.Text & "' WHERE username = 'adamson'"
            alterDB()
            SQLCONN.Close()
            SQLDR.Dispose()
            MsgBox("Password change succesfully! Please login again", , msgboxtitle)
            TextBox9.Clear()
            TextBox10.Clear()
            Me.Hide()
            AdminControlLogin.Show()
        Else
            MsgBox("Passwords does not match")
            TextBox9.Clear()
            TextBox10.Clear()
        End If

    End Sub
End Class