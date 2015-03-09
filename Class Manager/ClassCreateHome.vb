﻿Imports System.Data.SQLite


Public Class ClassCreateHome


    Dim Lec As String
    Dim Lab As String

    Private Sub TextBox_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox1.KeyPress

        If Asc(e.KeyChar) <> 13 AndAlso Asc(e.KeyChar) <> 8 AndAlso Not IsNumeric(e.KeyChar) Then
            MessageBox.Show("Please enter numbers only")
            e.Handled = True
        End If

    End Sub

    Private Sub ComboBoxUpper(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles ComboBox1.KeyPress

        If Char.IsLower(e.KeyChar) Then

            'Convert to uppercase, and put at the caret position in the TextBox.
            ComboBox1.SelectedText = Char.ToUpper(e.KeyChar)

            e.Handled = True
        End If

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Create.Click
        Try
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

            If TextBox1.Text = "" Then
                MsgBox("Please enter your subject number", , msgboxtitle)
                TextBox1.Focus()
            ElseIf ComboBox1.SelectedItem = Nothing Then
                MsgBox("Please select a subject from the list", , msgboxtitle)
                ComboBox1.Text = ""
                ComboBox1.Focus()
            ElseIf RichTextBox1.Text = "" Then
                MsgBox("Please add a description on your class! (Example: Schedule)", , msgboxtitle)
                RichTextBox1.Focus()
            Else
                DBConn()
                SQLSTR = "INSERT INTO MasterClasslist (ClassID, Name, Desc, SeatPlan, Lab) VALUES ('" & TextBox1.Text & "', '" & ComboBox1.Text & "', '" & RichTextBox1.Text & "', '" & Lec & "', '" & Lab & "' )"
                alterDB()
                Dim querystring As String = "SELECT ClassID FROM MasterClasslist WHERE Name = ('" & TextBox1.Text & "')"
                Dim command As New SQLiteCommand(querystring, SQLCONN)
                Dim reader As SQLiteDataReader = command.ExecuteReader
                While reader.Read
                    TextBox2.Text = reader.GetValue(0)
                End While
                reader.Close()
                SQLSTR = "CREATE TABLE '" & TextBox1.Text & "' (StudentID INTEGER NOT NULL UNIQUE, FirstName TEXT, LastName TEXT, pQuiz INTEGER DEFAULT 0, pQuizRaw INTEGER DEFAULT 0, pAttend INTEGER DEFAULT 0, pAttendRaw INTEGER DEFAULT 0, pRecite INTEGER DEFAULT 0, pReciteRaw INTEGER DEFAULT 0, pProject INTEGER DEFAULT 0, pProjectRaw INTEGER DEFAULT 0, pHomework INTEGER DEFAULT 0, pHomeworkRaw INTEGER DEFAULT 0, pOthers INTEGER DEFAULT 0, pOthersRaw INTEGER DEFAULT 0, pExam INTEGER DEFAULT 0, pExamRaw INTEGER DEFAULT 0, mQuiz INTEGER DEFAULT 0, mQuizRaw INTEGER DEFAULT 0, mAttend INTEGER DEFAULT 0, mAttendRaw INTEGER DEFAULT 0, mRecite INTEGER DEFAULT 0, mReciteRaw INTEGER DEFAULT 0, mProject INTEGER DEFAULT 0, mProjectRaw INTEGER DEFAULT 0, mHomework INTEGER DEFAULT 0, mHomeworkRaw INTEGER DEFAULT 0, mOthers INTEGER DEFAULT 0, mOthersRaw INTEGER DEFAULT 0, mExam INTEGER DEFAULT 0, mExamRaw INTEGER DEFAULT 0, fQuiz INTEGER DEFAULT 0, fQuizRaw INTEGER DEFAULT 0, fAttend INTEGER DEFAULT 0, fAttendRaw INTEGER DEFAULT 0, fRecite INTEGER DEFAULT 0, fReciteRaw INTEGER DEFAULT 0, fProject INTEGER DEFAULT 0, fProjectRaw INTEGER DEFAULT 0, fHomework INTEGER DEFAULT 0, fHomeworkRaw INTEGER DEFAULT 0, fOthers INTEGER DEFAULT 0, fOthersRaw INTEGER DEFAULT 0, fExam INTEGER DEFAULT 0, fExamRaw INTEGER DEFAULT 0, pGrade INTEGER DEFAULT 0, mGrade INTEGER DEFAULT 0, fGrade INTEGER DEFAULT 0, semGrade INTEGER DEFAULT 0, remarks TEXT DEFAULT FAILED)"
                alterDB()
                MsgBox("Class created!", , msgboxtitle)
                ClassCreateHomeAddStudents.TextBox4.Text = TextBox1.Text
                ClassCreateHomeAddStudents.Show()
                Me.Hide()
                SQLDR.Dispose()
                SQLCONN.Close()

                AddGrades.StudentToolStripMenuItem.Text = TextBox1.Text + " " + ComboBox1.Text
                AddGrades.ToolStripMenuItem1.Text = RichTextBox1.Text

            End If
        Catch ex As SQLiteException
            MsgBox(ex.ToString)
        End Try

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

        ClassHome.Show()
        Me.Hide()

    End Sub

    Private Sub ClassCreateHome_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class