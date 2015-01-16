Imports System.Data.SQLite


Public Class ClassCreateHome


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim confirm As DialogResult = MsgBox("Are all information correct?", MsgBoxStyle.YesNo, msgboxtitle)
        If confirm = Windows.Forms.DialogResult.Yes Then
            If TextBox1.Text = "" Then
                MsgBox("Student Number Missing", MsgBoxStyle.OkOnly, msgboxtitle)
            Else
                Try
                    DBConn()
                    SQLSTR = "INSERT INTO MasterClasslist (Name, Desc) VALUES ('" & TextBox1.Text & "', '" & RichTextBox1.Text & "')"
                    alterDB()
                    Dim querystring As String = "SELECT ClassID FROM MasterClasslist WHERE Name = ('" & TextBox1.Text & "')"
                    Dim command As New SQLiteCommand(querystring, SQLCONN)
                    Dim reader As SQLiteDataReader = command.ExecuteReader
                    While reader.Read
                        'Console.WriteLine(reader(0))
                        TextBox2.Text = reader.GetValue(0)
                    End While
                    reader.Close()
                    SQLSTR = "CREATE TABLE '" & TextBox2.Text & "' (StudentID INT NOT NULL UNIQUE, FirstName TEXT, LastName TEXT, Prelim INTEGER, Midterms INTEGER, FINALS INTEGER)"
                    alterDB()
                    MsgBox("Class created!", , msgboxtitle)
                    ClassCreateHomeAddStudents.TextBox4.Text = TextBox2.Text

                    ClassCreateHomeAddStudents.Show()
                    Me.Close()

                Catch ex As Exception
                    MessageBox.Show(ex.ToString)
                End Try
            End If
        End If
    End Sub
End Class