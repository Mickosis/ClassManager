Imports System.Data.SQLite

Public Class ImportExport

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If TextBox2.Text = "" Then
            My.Computer.FileSystem.CopyFile("ClassRecords.db", "C:\Users\Mico\Desktop\ClassRecords.db",
Microsoft.VisualBasic.FileIO.UIOption.AllDialogs,
Microsoft.VisualBasic.FileIO.UICancelOption.DoNothing)
            MsgBox("Export Success!")
            Process.Start("C:\Users\Mico\Desktop\")
        Else
            My.Computer.FileSystem.CopyFile("ClassRecords.db", "C:\Users\Mico\Desktop\" + TextBox2.Text + ".db",
Microsoft.VisualBasic.FileIO.UIOption.AllDialogs,
Microsoft.VisualBasic.FileIO.UICancelOption.DoNothing)
            MsgBox("Export Success!")
            Process.Start("C:\Users\Mico\Desktop\")
        End If

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        My.Computer.FileSystem.CopyFile(
    TextBox1.Text,
    "C:\Users\Mico\Desktop\Class Manager\Class Manager\bin\Debug\ClassRecords.db",
    Microsoft.VisualBasic.FileIO.UIOption.AllDialogs,
    Microsoft.VisualBasic.FileIO.UICancelOption.DoNothing)
        MsgBox("Import Success!")
        Process.Start("C:\Users\Mico\Desktop\Class Manager\Class Manager\bin\Debug\")
        Me.Hide()
        Home.Activate()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Using FileDialog As New OpenFileDialog
            FileDialog.Title = "Select database to import"
            FileDialog.Filter = "Class Manager Files|*.db"
            If FileDialog.ShowDialog() = DialogResult.OK Then
                TextBox1.Text = FileDialog.FileName()
                Button1.Enabled = True
            End If
        End Using
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim SQLitecreate As New SQLiteConnection
        Dim SQLitecommand As New SQLiteCommand
        SQLiteConnection.CreateFile("C:\Users\Mico\Desktop\ClassRecords.db")
        SQLitecreate = New SQLiteConnection("Data Source=C:\Users\Mico\Desktop\ClassRecords.db")
        SQLitecommand.Connection = SQLitecreate
        SQLitecreate.Open()
        Dim TableCreate As String = "CREATE TABLE MasterStudents (StudentID INTEGER NOT NULL UNIQUE PRIMARY KEY, FirstName TEXT NOT NULL, LastName TEXT NOT NULL, ContactNumber INTEGER, EmailAddress TEXT, Path TEXT)"
            SQLitecommand.CommandText = TableCreate
            SQLitecommand.ExecuteNonQuery()
            Dim TableCreate2 As String = "CREATE TABLE MasterClasslist (ClassID INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT UNIQUE, Name NOT NULL, Desc TEXT, PrelimWeight INTEGER, MidtermWeight INTEGER, FinalWeight INTEGER, PassingMark INTEGER, QuizWeight INTEGER, ClassStandingWeight INTEGER, Attendance WEIGHT INTEGER, PeriodicalExamWeight INTEGER)"
            SQLitecommand.CommandText = TableCreate2
        SQLitecommand.ExecuteNonQuery()
        SQLitecreate.Close()
        Dim confirm As DialogResult = MsgBox("Would you like to import new database?", MsgBoxStyle.YesNo, msgboxtitle)
        If confirm = Windows.Forms.DialogResult.Yes Then
            My.Computer.FileSystem.CopyFile(
"C:\Users\Mico\Desktop\ClassRecords.db",
"C:\Users\Mico\Desktop\Class Manager\Class Manager\bin\Debug\ClassRecords.db",
Microsoft.VisualBasic.FileIO.UIOption.AllDialogs,
Microsoft.VisualBasic.FileIO.UICancelOption.DoNothing)
            MsgBox("Import Success!")
            My.Computer.FileSystem.DeleteFile("C:\Users\Mico\Desktop\ClassRecords.db")
            Me.Hide()
            Home.Activate()
        End If

    End Sub
End Class