Imports System.Data.OleDb
Imports System.Data.SqlClient
Imports System.Data.SQLite

Public Class ImportExcelHome

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

    Private Sub HomeToolStripMenuItem_Click(sender As Object, e As EventArgs)
        Me.Hide()
        Home.Show()

    End Sub

    Private Sub ViewStudentsListToolStripMenuItem_Click(sender As Object, e As EventArgs)
        Me.Hide()
        StudentsHome.Show()

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles ImportDbase.Click
        Dim ExcelString As String
        Dim ExcelConn As SQLiteConnection = New SQLiteConnection("Data Source=ClassRecords.db")
        Dim Ex As New SQLiteCommand



        For Each item As DataGridViewRow In DataGridView1.Rows
            Dim StudentID As Integer : StudentID = CInt(item.Cells(0).Value)
            Dim FirstName As String : FirstName = item.Cells(1).Value
            Dim LastName As String : LastName = item.Cells(2).Value
            Dim DefaultPhoto As String = "C:\Users\Miguel\Desktop\Class Manager\Class Manager\Resources\Default.png"
            Dim DefaultEmail As String = "temp@temp.com"
            ExcelString = "INSERT INTO MasterStudents (StudentID, FirstName, LastName, ContactNumber, EmailAddress, Path) VALUES ('" & StudentID & "', '" & FirstName & "', '" & LastName & "', 0, '" & DefaultEmail & "', '" & DefaultPhoto & "')"
            ExcelConn.Open()
            Ex.CommandText = ExcelString
            Ex.Connection = ExcelConn
            Ex.ExecuteNonQuery()
            ExcelConn.Close()
        Next
        MsgBox("Students added!", , msgboxtitle)
        ExcelConn.Close()
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
