Imports System.Data.SQLite

Public Class ImportExport

    Public thepath As String = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Export.Click
        My.Computer.FileSystem.CopyFile("C:\Mickosis\Class Manager\ClassRecords.db", thepath + "\ClassRecords.db",
Microsoft.VisualBasic.FileIO.UIOption.AllDialogs,
Microsoft.VisualBasic.FileIO.UICancelOption.DoNothing)
        MsgBox("Export Success!")
        Process.Start(thepath)

    End Sub

    Private Sub Export_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles Export.MouseHover

        Export.Image = My.Resources.addbrowsepressed

    End Sub
    Private Sub Export_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Export.MouseLeave

        Export.Image = My.Resources.addbrowse


    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Import.Click
        My.Computer.FileSystem.CopyFile(
    TextBox1.Text,
    "C:\Mickosis\Class Manager\ClassRecords.db",
    Microsoft.VisualBasic.FileIO.UIOption.AllDialogs,
    Microsoft.VisualBasic.FileIO.UICancelOption.DoNothing)
        MsgBox("Import Success!")
        Me.Hide()
        Home.Show()

    End Sub


    Private Sub Import_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles Import.MouseHover

        Import.Image = My.Resources.addbrowsepressed

    End Sub
    Private Sub Import_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Import.MouseLeave

        Import.Image = My.Resources.addbrowse


    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Browse.Click
        Using FileDialog As New OpenFileDialog
            FileDialog.Title = "Select database to import"
            FileDialog.Filter = "Class Manager Files|*.db"
            If FileDialog.ShowDialog() = DialogResult.OK Then
                TextBox1.Text = FileDialog.FileName()
                Import.Enabled = True
            End If
        End Using
    End Sub

    Private Sub Browse_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles Browse.MouseHover

        Browse.Image = My.Resources.addbrowsepressed

    End Sub
    Private Sub Browse_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Browse.MouseLeave

        Browse.Image = My.Resources.addbrowse


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
        Home.Show()

    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        Dim SQLitecreate As New SQLiteConnection
        Dim SQLitecommand As New SQLiteCommand
        SQLiteConnection.CreateFile(thepath + "\ClassRecords.db")
        SQLitecreate = New SQLiteConnection("Data Source=" + thepath + "\ClassRecords.db")
        SQLitecommand.Connection = SQLitecreate
        SQLitecreate.Open()
        Dim TableCreate As String = "CREATE TABLE MasterStudents (StudentID INTEGER NOT NULL UNIQUE PRIMARY KEY, FirstName TEXT NOT NULL, LastName TEXT NOT NULL, ContactNumber INTEGER, EmailAddress TEXT, Path TEXT)"
        SQLitecommand.CommandText = TableCreate
        SQLitecommand.ExecuteNonQuery()
        Dim TableCreate2 As String = "CREATE TABLE MasterClasslist (ClassID INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT UNIQUE, Name TEXT NOT NULL, Desc TEXT NOT NULL, pQuiz INTEGER DEFAULT 40, pAttend INTEGER DEFAULT 5, pRecite INTEGER DEFAULT 10, pProject INTEGER DEFAULT 20, pHomework INTEGER DEFAULT 20, pOthers INTEGER DEFAULT 5, mQuiz INTEGER DEFAULT 40, mAttend INTEGER DEFAULT 5, mRecite INTEGER DEFAULT 10, mProject INTEGER DEFAULT 20, mHomework INTEGER DEFAULT 20, mOthers INTEGER DEFAULT 5, fQuiz INTEGER DEFAULT 40, fAttend INTEGER DEFAULT 5, fRecite INTEGER DEFAULT 10, fProject INTEGER DEFAULT 20, fHomework INTEGER DEFAULT 20, fOthers INTEGER DEFAULT 5)"
        SQLitecommand.CommandText = TableCreate2
        SQLitecommand.ExecuteNonQuery()
        Dim TableCreate3 As String = "CREATE TABLE LoginCredentials (username TEXT DEFAULT adamson, password TEXT DEFAULT adamson)"
        SQLitecommand.CommandText = TableCreate3
        SQLitecommand.ExecuteNonQuery()
        Dim TableCreate4 As String = "CREATE TABLE GlobalGrades (PMTotalCS INTEGER DEFAULT 60, PMExam INTEGER DEFAULT 40, FTotalCS INTEGER DEFAULT 50, FExam INTEGER DEFAULT 50, PrelimWeight INTEGER DEFAULT 30, MidtermWeight INTEGER DEFAULT 30, FinalWeight INTEGER DEFAULT 40, PassingMark INTEGER DEFAULT 70)"
        SQLitecommand.CommandText = TableCreate4
        SQLitecommand.ExecuteNonQuery()
        Dim TableCreate5 As String = "INSERT INTO LoginCredentials (username, password) VALUES ('adamson', 'adamson')"
        SQLitecommand.CommandText = TableCreate5
        SQLitecommand.ExecuteNonQuery()
        Dim TableCreate6 As String = "INSERT INTO GlobalGrades VALUES (60, 40, 50, 50, 30 ,30 ,40, 70)"
        SQLitecommand.CommandText = TableCreate6
        SQLitecommand.ExecuteNonQuery()
        SQLitecreate.Close()
        Dim confirm As DialogResult = MsgBox("Would you like to import new database?", MsgBoxStyle.YesNo, msgboxtitle)
        If confirm = Windows.Forms.DialogResult.Yes Then
            My.Computer.FileSystem.CopyFile(
thepath + "\ClassRecords.db",
"C:\Mickosis\Class Manager\ClassRecords.db",
Microsoft.VisualBasic.FileIO.UIOption.AllDialogs,
Microsoft.VisualBasic.FileIO.UICancelOption.DoNothing)
            MsgBox("Import Success!")
            SQLitecreate.Close()
            SQLitecreate.Dispose()
        End If
    End Sub

    Private Sub Create_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.MouseHover

        Button1.Image = My.Resources.addbrowsepressed

    End Sub
    Private Sub Create_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.MouseLeave

        Button1.Image = My.Resources.addbrowse


    End Sub
End Class