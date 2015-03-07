Imports System.Data.SQLite
Imports System.IO

Public Class Edit_Total_Scores
    Private Sub TextBox_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox2.KeyPress, TextBox3.KeyPress, TextBox4.KeyPress, TextBox5.KeyPress, TextBox6.KeyPress, TextBox7.KeyPress, TextBox8.KeyPress
        If Asc(e.KeyChar) <> 13 AndAlso Asc(e.KeyChar) <> 8 AndAlso Not IsNumeric(e.KeyChar) Then
            MessageBox.Show("Please enter whole numbers only")
            e.Handled = True
        End If
    End Sub
    Private Sub Edit_Total_Scores_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub HomeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles HomeToolStripMenuItem.Click
        Me.Hide()

    End Sub

    Private Sub Update_Click(sender As Object, e As EventArgs) Handles Update.Click
        Dim ClassIntl = TextBox1.Text
        If TextBox2.Text = "" Then
            TextBox2.Text = 0
        ElseIf TextBox3.Text = "" Then
            TextBox3.Text = 0
        ElseIf TextBox4.Text = "" Then
            TextBox4.Text = 0
        ElseIf TextBox5.Text = "" Then
            TextBox5.Text = 0
        ElseIf TextBox6.Text = "" Then
            TextBox6.Text = 0
        ElseIf TextBox7.Text = "" Then
            TextBox7.Text = 0
        ElseIf TextBox8.Text = "" Then
            TextBox8.Text = 0
        Else
            If (AddPrelimGrades.Visible) Then
                DBConn()
                SQLSTR = "UPDATE MasterClasslist SET pQuizTotal = '" & TextBox2.Text & "', pAttendTotal = '" & TextBox3.Text & "', pReciteTotal = '" & TextBox4.Text & "', pProjectTotal = '" & TextBox5.Text & "', pHomeworkTotal = '" & TextBox6.Text & "', pOthersTotal = '" & TextBox7.Text & "', pExamTotal = '" & TextBox8.Text & "' WHERE ClassID = '" & ClassIntl & "'"
                alterDB()

                DBConn()
                Dim querystring2 As String = "SELECT pQuizTotal, pAttendTotal, pReciteTotal, pProjectTotal, pHomeworkTotal, pOthersTotal, pExamTotal FROM MasterClasslist WHERE ClassID = '" & ClassIntl & "'"
                Dim command2 As New SQLiteCommand(querystring2, SQLCONN)
                Dim reader2 As SQLiteDataReader = command2.ExecuteReader
                While reader2.Read
                    AddPrelimGrades.Label13.Text = reader2.GetValue(0)
                    AddPrelimGrades.Label14.Text = reader2.GetValue(1)
                    AddPrelimGrades.Label15.Text = reader2.GetValue(2)
                    AddPrelimGrades.Label16.Text = reader2.GetValue(3)
                    AddPrelimGrades.Label17.Text = reader2.GetValue(4)
                    AddPrelimGrades.Label18.Text = reader2.GetValue(5)
                    AddPrelimGrades.Label26.Text = reader2.GetValue(6)

                    GradeMe.Label21.Text = reader2.GetValue(0)
                    GradeMe.Label22.Text = reader2.GetValue(1)
                    GradeMe.Label23.Text = reader2.GetValue(2)
                    GradeMe.Label24.Text = reader2.GetValue(3)
                    GradeMe.Label25.Text = reader2.GetValue(4)
                    GradeMe.Label26.Text = reader2.GetValue(5)
                    GradeMe.Label27.Text = reader2.GetValue(6)
                End While
                reader2.Close()

                SQLDR.Dispose()
                SQLCONN.Close()
                Me.Hide()

            ElseIf (AddMidtermGrades.Visible) Then
                DBConn()
                SQLSTR = "UPDATE MasterClasslist SET mQuizTotal = '" & TextBox2.Text & "', mAttendTotal = '" & TextBox3.Text & "', mReciteTotal = '" & TextBox4.Text & "', mProjectTotal = '" & TextBox5.Text & "', mHomeworkTotal = '" & TextBox6.Text & "', mOthersTotal = '" & TextBox7.Text & "', mExamTotal = '" & TextBox8.Text & "' WHERE ClassID = '" & ClassIntl & "'"
                alterDB()

                DBConn()

                Dim querystring2 As String = "SELECT mQuizTotal, mAttendTotal, mReciteTotal, mProjectTotal, mHomeworkTotal, mOthersTotal, mExamTotal FROM MasterClasslist WHERE ClassID = '" & ClassIntl & "'"
                Dim command2 As New SQLiteCommand(querystring2, SQLCONN)
                Dim reader2 As SQLiteDataReader = command2.ExecuteReader
                While reader2.Read
                    AddMidtermGrades.Label13.Text = reader2.GetValue(0)
                    AddMidtermGrades.Label14.Text = reader2.GetValue(1)
                    AddMidtermGrades.Label15.Text = reader2.GetValue(2)
                    AddMidtermGrades.Label16.Text = reader2.GetValue(3)
                    AddMidtermGrades.Label17.Text = reader2.GetValue(4)
                    AddMidtermGrades.Label18.Text = reader2.GetValue(5)
                    AddMidtermGrades.Label26.Text = reader2.GetValue(6)

                    GradeMe.Label21.Text = reader2.GetValue(0)
                    GradeMe.Label22.Text = reader2.GetValue(1)
                    GradeMe.Label23.Text = reader2.GetValue(2)
                    GradeMe.Label24.Text = reader2.GetValue(3)
                    GradeMe.Label25.Text = reader2.GetValue(4)
                    GradeMe.Label26.Text = reader2.GetValue(5)
                    GradeMe.Label27.Text = reader2.GetValue(6)
                End While
                reader2.Close()

                SQLDR.Dispose()
                SQLCONN.Close()
                Me.Hide()

            ElseIf (AddFinalGrades.Visible) Then
                DBConn()
                SQLSTR = "UPDATE MasterClasslist SET fQuizTotal = '" & TextBox2.Text & "', fAttendTotal = '" & TextBox3.Text & "', fReciteTotal = '" & TextBox4.Text & "', fProjectTotal = '" & TextBox5.Text & "', fHomeworkTotal = '" & TextBox6.Text & "', fOthersTotal = '" & TextBox7.Text & "', fExamTotal = '" & TextBox8.Text & "' WHERE ClassID = '" & ClassIntl & "'"
                alterDB()

                DBConn()

                Dim querystring2 As String = "SELECT fQuizTotal, fAttendTotal, fReciteTotal, fProjectTotal, fHomeworkTotal, fOthersTotal, fExamTotal FROM MasterClasslist WHERE ClassID = '" & ClassIntl & "'"
                Dim command2 As New SQLiteCommand(querystring2, SQLCONN)
                Dim reader2 As SQLiteDataReader = command2.ExecuteReader
                While reader2.Read
                    AddFinalGrades.Label13.Text = reader2.GetValue(0)
                    AddFinalGrades.Label14.Text = reader2.GetValue(1)
                    AddFinalGrades.Label15.Text = reader2.GetValue(2)
                    AddFinalGrades.Label16.Text = reader2.GetValue(3)
                    AddFinalGrades.Label17.Text = reader2.GetValue(4)
                    AddFinalGrades.Label18.Text = reader2.GetValue(5)
                    AddFinalGrades.Label26.Text = reader2.GetValue(6)

                    GradeMe.Label21.Text = reader2.GetValue(0)
                    GradeMe.Label22.Text = reader2.GetValue(1)
                    GradeMe.Label23.Text = reader2.GetValue(2)
                    GradeMe.Label24.Text = reader2.GetValue(3)
                    GradeMe.Label25.Text = reader2.GetValue(4)
                    GradeMe.Label26.Text = reader2.GetValue(5)
                    GradeMe.Label27.Text = reader2.GetValue(6)
                End While
                reader2.Close()

                SQLDR.Dispose()
                SQLCONN.Close()
                Me.Hide()
            End If
        End If

    End Sub
    Private Sub Btn2MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles Update.MouseHover

        Update.Image = My.Resources.addbrowsepressed

    End Sub

    Private Sub Btn2MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Update.MouseLeave

        Update.Image = My.Resources.addbrowse
    End Sub

    Private Sub TextBox8_TextChanged(sender As Object, e As EventArgs) Handles TextBox8.TextChanged

    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        If MessageBox.Show("Do you want to exit?", "Class Manager", _
       MessageBoxButtons.YesNo, MessageBoxIcon.Warning) _
       = DialogResult.Yes Then
            Application.Exit()
        End If
    End Sub
End Class