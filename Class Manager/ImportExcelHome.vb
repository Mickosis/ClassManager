Imports System.Data.OleDb
Imports System.Data.SqlClient
Imports System.Data.SQLite

Public Class ImportExcelHome

    Public Sub ClearShitOut()
        TextBox1.Clear()
        DataGridView1.Columns.Clear()
        TextBox2.Clear()
        RichTextBox1.Clear()

    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Browse.Click
        Using FileDialog As New OpenFileDialog
            FileDialog.Title = "Select your Excel file"
            FileDialog.Filter = "Excel Files|*.xls;*.xlsx;*.xlsm"
            If FileDialog.ShowDialog() = DialogResult.OK Then
                TextBox1.Text = FileDialog.FileName()
                Button2.Enabled = True

            End If
        End Using
    End Sub

    Private Sub Browse_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles Browse.MouseHover

        Browse.Image = My.Resources.browseimportpressed

    End Sub
    Private Sub Browse_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Browse.MouseLeave

        Browse.Image = My.Resources.browseimport


    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim conn As OleDbConnection
        Dim dta As OleDbDataAdapter
        Dim dts As DataSet
        Dim excel As String
        Dim OpenFileDialog As New OpenFileDialog
        excel = TextBox1.Text

        conn = New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + excel + ";Extended Properties=Excel 12.0;")
        dta = New OleDbDataAdapter("Select * From [Sheet1$]", conn)
        dts = New DataSet
        dta.Fill(dts, "[Sheet1$]")
        DataGridView1.DataSource = dts
        DataGridView1.DataMember = "[Sheet1$]"
        conn.Close()

        With DataGridView1
            .RowHeadersVisible = False
            .Columns(0).HeaderCell.Value = "Student ID"
            .Columns(1).HeaderCell.Value = "First Name"
            .Columns(2).HeaderCell.Value = "Last Name"
        End With

    End Sub

    Private Sub Browse2_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button2.MouseHover

        Button2.Image = My.Resources.browseimportpressed

    End Sub
    Private Sub Browse2_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button2.MouseLeave

        Button2.Image = My.Resources.browseimport


    End Sub

    Private Sub HomeToolStripMenuItem_Click(sender As Object, e As EventArgs)
        Me.Hide()
        Home.Show()

    End Sub

    Private Sub ViewStudentsListToolStripMenuItem_Click(sender As Object, e As EventArgs)
        Me.Hide()
        StudentsHome.Show()

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles ImportDbase.Click
        Dim Lab As String
        Dim Lec As String

        If CheckBox1.Checked Then
            Lab = "withlab"
        Else
            Lab = "without"
        End If

        If CheckBox2.Checked Then
            Lec = "corner"
        Else
            Lec = "notcorner"
        End If

        Try
            Dim ExcelString As String
            Dim ExcelConn As SQLiteConnection = New SQLiteConnection("Data Source=C:\Mickosis\Class Manager\ClassRecords.db")
            Dim Ex As New SQLiteCommand
            If TextBox2.Text = "" Then
                Dim thepath As String = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)

                For Each item As DataGridViewRow In DataGridView1.Rows
                    Dim StudentID As Integer : StudentID = CInt(item.Cells(0).Value)
                    Dim FirstName As String : FirstName = item.Cells(1).Value
                    Dim LastName As String : LastName = item.Cells(2).Value
                    Dim DefaultPhoto As String = thepath + "\Class Manager\Class Manager\Resources\Default.png"
                    Dim DefaultEmail As String = "temp@temp.com"
                    ExcelString = "INSERT INTO MasterStudents (StudentID, FirstName, LastName, ContactNumber, EmailAddress, Path) VALUES ('" & StudentID & "', '" & FirstName & "', '" & LastName & "', 0, '" & DefaultEmail & "', '" & DefaultPhoto & "')"
                    ExcelConn.Open()
                    Ex.CommandText = ExcelString
                    Ex.Connection = ExcelConn
                    Ex.ExecuteNonQuery()
                    ExcelConn.Close()
                Next
                ExcelConn.Close()
                MsgBox("Import Sucessful!")
                Me.Hide()
                StudentsHome.LoadGrades()
                StudentsHome.Show()
            Else
                If RichTextBox1.Text = "" Then
                    MsgBox("Please add a description on your class! (Example: Schedule)", , msgboxtitle)
                    RichTextBox1.Focus()
                Else
                    Dim thepath As String = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
                    For Each item As DataGridViewRow In DataGridView1.Rows
                        Dim StudentID As Integer : StudentID = CInt(item.Cells(0).Value)
                        Dim FirstName As String : FirstName = item.Cells(1).Value
                        Dim LastName As String : LastName = item.Cells(2).Value
                        Dim DefaultPhoto As String = thepath + "\Class Manager\Class Manager\Resources\Default.png"
                        Dim DefaultEmail As String = "temp@temp.com"
                        ExcelString = "INSERT INTO MasterStudents (StudentID, FirstName, LastName, ContactNumber, EmailAddress, Path) VALUES ('" & StudentID & "', '" & FirstName & "', '" & LastName & "', 0, '" & DefaultEmail & "', '" & DefaultPhoto & "')"
                        ExcelConn.Open()
                        Ex.CommandText = ExcelString
                        Ex.Connection = ExcelConn
                        Ex.ExecuteNonQuery()
                        ExcelConn.Close()
                    Next
                    ExcelConn.Close()
                    DBConn()
                    SQLSTR = "INSERT INTO MasterClasslist (Name, Desc, SeatPlan, Lab) VALUES ('" & TextBox2.Text & "', '" & RichTextBox1.Text & "', '" & Lec & "', '" & Lab & "')"
                    alterDB()
                    Dim querystring As String = "SELECT ClassID FROM MasterClasslist WHERE Name = ('" & TextBox2.Text & "')"
                    Dim command As New SQLiteCommand(querystring, SQLCONN)
                    Dim reader As SQLiteDataReader = command.ExecuteReader
                    While reader.Read
                        TextBox3.Text = reader.GetValue(0)
                    End While
                    reader.Close()
                    SQLSTR = "CREATE TABLE '" & TextBox3.Text & "' (StudentID INTEGER NOT NULL UNIQUE, FirstName TEXT, LastName TEXT, pQuiz INTEGER DEFAULT 0, pQuizRaw INTEGER DEFAULT 0, pAttend INTEGER DEFAULT 0, pAttendRaw INTEGER DEFAULT 0, pRecite INTEGER DEFAULT 0, pReciteRaw INTEGER DEFAULT 0, pProject INTEGER DEFAULT 0, pProjectRaw INTEGER DEFAULT 0, pHomework INTEGER DEFAULT 0, pHomeworkRaw INTEGER DEFAULT 0, pOthers INTEGER DEFAULT 0, pOthersRaw INTEGER DEFAULT 0, pExam INTEGER DEFAULT 0, pExamRaw INTEGER DEFAULT 0, mQuiz INTEGER DEFAULT 0, mQuizRaw INTEGER DEFAULT 0, mAttend INTEGER DEFAULT 0, mAttendRaw INTEGER DEFAULT 0, mRecite INTEGER DEFAULT 0, mReciteRaw INTEGER DEFAULT 0, mProject INTEGER DEFAULT 0, mProjectRaw INTEGER DEFAULT 0, mHomework INTEGER DEFAULT 0, mHomeworkRaw INTEGER DEFAULT 0, mOthers INTEGER DEFAULT 0, mOthersRaw INTEGER DEFAULT 0, mExam INTEGER DEFAULT 0, mExamRaw INTEGER DEFAULT 0, fQuiz INTEGER DEFAULT 0, fQuizRaw INTEGER DEFAULT 0, fAttend INTEGER DEFAULT 0, fAttendRaw INTEGER DEFAULT 0, fRecite INTEGER DEFAULT 0, fReciteRaw INTEGER DEFAULT 0, fProject INTEGER DEFAULT 0, fProjectRaw INTEGER DEFAULT 0, fHomework INTEGER DEFAULT 0, fHomeworkRaw INTEGER DEFAULT 0, fOthers INTEGER DEFAULT 0, fOthersRaw INTEGER DEFAULT 0, fExam INTEGER DEFAULT 0, fExamRaw INTEGER DEFAULT 0, pGrade INTEGER DEFAULT 0, mGrade INTEGER DEFAULT 0, fGrade INTEGER DEFAULT 0, semGrade INTEGER DEFAULT 0)"
                    alterDB()

                    For Each item As DataGridViewRow In DataGridView1.Rows
                        Dim StudentID As Integer : StudentID = CInt(item.Cells(0).Value)
                        Dim FirstName As String : FirstName = item.Cells(1).Value
                        Dim LastName As String : LastName = item.Cells(2).Value
                        ExcelString = "INSERT INTO '" & TextBox3.Text & "' (StudentID, FirstName, LastName) VALUES ('" & StudentID & "', '" & FirstName & "', '" & LastName & "')"
                        ExcelConn.Open()
                        Ex.CommandText = ExcelString
                        Ex.Connection = ExcelConn
                        Ex.ExecuteNonQuery()
                        ExcelConn.Close()
                    Next
                    MsgBox("Import and Class Creation Succesful!")
                    AddGrades.TextBox1.Text = TextBox3.Text
                    AddGrades.StudentToolStripMenuItem.Text = TextBox2.Text
                    AddGrades.ToolStripMenuItem1.Text = RichTextBox1.Text
                    SQLDR.Dispose()
                    SQLCONN.Close()
                    Me.Hide()
                    AddGrades.AddGrades()
                    AddGrades.Show()
                End If
            End If
        Catch ex As SQLiteException
            If ex.ErrorCode = 2627 Then
                MsgBox("A student in the Excel file is already in our database. Please add them to the class manually.")
            End If
        End Try

    End Sub

    Private Sub Add_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles ImportDbase.MouseHover

        ImportDbase.Image = My.Resources.importdbasepressed

    End Sub
    Private Sub Add_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles ImportDbase.MouseLeave

        ImportDbase.Image = My.Resources.importdbase


    End Sub

    Private Sub StudentRecords1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Button2.Enabled = False

    End Sub

    Private Sub AddAStudentToolStripMenuItem_Click(sender As Object, e As EventArgs)
        Me.Hide()
        AddAStudent.Show()

    End Sub

    Private Sub Close_Click(sender As Object, e As EventArgs) Handles Close.Click
        If MessageBox.Show("Do you want to exit?", "Class Manager", _
     MessageBoxButtons.YesNo, MessageBoxIcon.Warning) _
     = DialogResult.Yes Then
            Application.Exit()
        End If
    End Sub

    Private Sub HomeToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles HomeToolStripMenuItem.Click
        Me.Hide()
        StudentsHome.Show()
    End Sub
End Class
