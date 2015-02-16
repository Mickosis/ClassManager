Imports System.Data.SQLite


Public Class ClassCreateHome


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Create.Click
        If TextBox1.Text = "" Then
            MsgBox("Please choose a name for your class", MsgBoxStyle.OkOnly, msgboxtitle)
        Else
            DBConn()
            SQLSTR = "INSERT INTO MasterClasslist (Name, Desc) VALUES ('" & TextBox1.Text & "', '" & RichTextBox1.Text & "')"
            alterDB()
            Dim querystring As String = "SELECT ClassID FROM MasterClasslist WHERE Name = ('" & TextBox1.Text & "')"
            Dim command As New SQLiteCommand(querystring, SQLCONN)
            Dim reader As SQLiteDataReader = command.ExecuteReader
            While reader.Read
                TextBox2.Text = reader.GetValue(0)
            End While
            reader.Close()
            SQLSTR = "CREATE TABLE '" & TextBox2.Text & "' (StudentID INTEGER NOT NULL UNIQUE, FirstName TEXT, LastName TEXT, pQuiz INTEGER DEFAULT 0, pAttend INTEGER DEFAULT 0, pRecite INTEGER DEFAULT 0, pProject INTEGER DEFAULT 0, pHomework INTEGER DEFAULT 0, pOthers INTEGER DEFAULT 0, pExam INTEGER DEFAULT 0, mQuiz INTEGER DEFAULT 0, mAttend INTEGER DEFAULT 0, mRecite INTEGER DEFAULT 0, mProject INTEGER DEFAULT 0, mHomework INTEGER DEFAULT 0, mOthers INTEGER DEFAULT 0, mExam INTEGER DEFAULT 0, fQuiz INTEGER DEFAULT 0, fAttend INTEGER DEFAULT 0, fRecite INTEGER DEFAULT 0, fProject INTEGER DEFAULT 0, fHomework INTEGER DEFAULT 0, fOthers INTEGER DEFAULT 0, fExam INTEGER DEFAULT 0, pGrade INTEGER DEFAULT 0, mGrade INTEGER DEFAULT 0, fGrade  INTEGER DEFAULT 0, semGrade INTEGER DEFAULT 0)"
            alterDB()
            MsgBox("Class created!", , msgboxtitle)
            ClassCreateHomeAddStudents.TextBox4.Text = TextBox2.Text
            ClassCreateHomeAddStudents.Show()
            Me.Hide()
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