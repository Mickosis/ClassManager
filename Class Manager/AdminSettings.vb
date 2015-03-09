Imports System.Data.SQLite

Public Class AdminSettings
    Public thepath As String = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)

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
            AdminControlLogin.Show()
            Me.Hide()
        Else
            MsgBox("Passwords does not match")
            TextBox9.Clear()
            TextBox10.Clear()
        End If

    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        If MessageBox.Show("Do you want to exit?", "Class Manager", _
       MessageBoxButtons.YesNo, MessageBoxIcon.Warning) _
       = DialogResult.Yes Then
            Application.Exit()
        End If
    End Sub

    Private Sub HomeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles HomeToolStripMenuItem.Click
        ClassHome.Show()
        Me.Hide()

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click

        Dim SQLitecreate As New SQLiteConnection
        Dim SQLitecommand As New SQLiteCommand
        SQLiteConnection.CreateFile(thepath + "\ClassRecords")
        SQLitecreate = New SQLiteConnection("Data Source=" + thepath + "\ClassRecords")
        SQLitecommand.Connection = SQLitecreate
        SQLitecreate.Open()
        Dim TableCreate As String = "CREATE TABLE MasterStudents (StudentID INTEGER NOT NULL UNIQUE PRIMARY KEY, FirstName TEXT NOT NULL, LastName TEXT NOT NULL, ContactNumber INTEGER, EmailAddress TEXT, Path TEXT)"
        SQLitecommand.CommandText = TableCreate
        SQLitecommand.ExecuteNonQuery()
        Dim TableCreate2 As String = "CREATE TABLE MasterClasslist (ClassID INTEGER NOT NULL PRIMARY KEY UNIQUE, Name TEXT NOT NULL, Desc TEXT NOT NULL, pQuiz INTEGER DEFAULT 30, pQuizTotal INTEGER DEFAULT 0, pAttend INTEGER DEFAULT 5, pAttendTotal INTEGER DEFAULT 0, pRecite INTEGER DEFAULT 5, pReciteTotal INTEGER DEFAULT 0, pProject INTEGER DEFAULT 20, pProjectTotal INTEGER DEFAULT 0, pHomework INTEGER DEFAULT 10, pHomeworkTotal INTEGER DEFAULT 0, pOthers INTEGER DEFAULT 30, pOthersTotal INTEGER DEFAULT 0, pExamTotal INTEGER DEFAULT 0, mQuiz INTEGER DEFAULT 30, mQuizTotal INTEGER DEFAULT 0, mAttend INTEGER DEFAULT 5, mAttendTotal INTEGER DEFAULT 0, mRecite INTEGER DEFAULT 5, mReciteTotal INTEGER DEFAULT 0, mProject INTEGER DEFAULT 20, mProjectTotal INTEGER DEFAULT 0, mHomework INTEGER DEFAULT 10, mHomeworkTotal INTEGER DEFAULT 0, mOthers INTEGER DEFAULT 30, mOthersTotal INTEGER DEFAULT 0, mExamTotal INTEGER DEFAULT 0, fQuiz INTEGER DEFAULT 30, fQuizTotal INTEGER DEFAULT 0, fAttend INTEGER DEFAULT 5, fAttendTotal INTEGER DEFAULT 0, fRecite INTEGER DEFAULT 5, fReciteTotal INTEGER DEFAULT 0, fProject INTEGER DEFAULT 20, fProjectTotal INTEGER DEFAULT 0, fHomework INTEGER DEFAULT 10, fHomeworkTotal INTEGER DEFAULT 0, fOthers INTEGER DEFAULT 30, fOthersTotal INTEGER DEFAULT 0, fExamTotal INTEGER DEFAULT 0, SeatPlan TEXT, Lab TEXT)"
        SQLitecommand.CommandText = TableCreate2
        SQLitecommand.ExecuteNonQuery()
        Dim TableCreate3 As String = "CREATE TABLE LoginCredentials (IndexID INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT UNIQUE, username TEXT DEFAULT adamson, password TEXT DEFAULT adamson)"
        SQLitecommand.CommandText = TableCreate3
        SQLitecommand.ExecuteNonQuery()
        Dim TableCreate4 As String = "CREATE TABLE GlobalGrades (PMTotalCS INTEGER DEFAULT 60, PMExam INTEGER DEFAULT 40, FTotalCS INTEGER DEFAULT 50, FExam INTEGER DEFAULT 50, PrelimWeight INTEGER DEFAULT 30, MidtermWeight INTEGER DEFAULT 30, FinalWeight INTEGER DEFAULT 40, PassingMark INTEGER DEFAULT 70)"
        SQLitecommand.CommandText = TableCreate4
        SQLitecommand.ExecuteNonQuery()
        Dim TableCreate5 As String = "INSERT INTO LoginCredentials (username, password) VALUES ('admin', 'adamson')"
        SQLitecommand.CommandText = TableCreate5
        SQLitecommand.ExecuteNonQuery()
        Dim TableCreate6 As String = "INSERT INTO LoginCredentials (username, password) VALUES ('sample@gmail.com', 'adamson')"
        SQLitecommand.CommandText = TableCreate6
        SQLitecommand.ExecuteNonQuery()
        Dim TableCreate7 As String = "INSERT INTO GlobalGrades VALUES (60, 40, 50, 50, 30 ,30 ,40, 70)"
        SQLitecommand.CommandText = TableCreate7
        SQLitecommand.ExecuteNonQuery()
        SQLitecreate.Close()
        My.Computer.FileSystem.CopyFile(
thepath + "\ClassRecords",
"C:\Mickosis\ClassRecords",
Microsoft.VisualBasic.FileIO.UIOption.AllDialogs,
Microsoft.VisualBasic.FileIO.UICancelOption.DoNothing)
        SQLitecreate.Close()
        SQLitecreate.Dispose()
        SQLitecommand.Dispose()

        Dim FileToDelete As String

        FileToDelete = thepath + "\ClassRecords"

        If System.IO.File.Exists(FileToDelete) = True Then
            System.IO.File.Delete(FileToDelete)
        End If

        MsgBox("Import Success!")
    End Sub
End Class