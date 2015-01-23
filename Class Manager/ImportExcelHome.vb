Imports System.Data.OleDb
Imports System.Data.SqlClient

Public Class ImportExcelHome

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Using FileDialog As New OpenFileDialog
            FileDialog.Title = "Select your Excel file"
            FileDialog.Filter = "Excel Files|*.xls;*.xlsx;*.xlsm"
            If FileDialog.ShowDialog() = DialogResult.OK Then
                TextBox1.Text = FileDialog.FileName()
                Button2.Enabled = True

            End If
        End Using
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
    End Sub

    Private Sub HomeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles HomeToolStripMenuItem.Click
        Me.Hide()
        Home.Show()

    End Sub

    Private Sub ViewStudentsListToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ViewStudentsListToolStripMenuItem.Click
        Me.Hide()
        StudentsHome.Show()

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click

    End Sub

    Private Sub StudentRecords1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Button2.Enabled = False

    End Sub

    Private Sub AddAStudentToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddAStudentToolStripMenuItem.Click
        Me.Hide()
        AddAStudent.Show()

    End Sub
End Class
