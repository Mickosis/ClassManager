Imports System.Data.SQLite
Imports iTextSharp.text.pdf
Imports iTextSharp.text
Imports System.IO


Public Class AddGrades
    Dim DS As New DataSet()

    Public Sub AddGrades()
        Dim ClassIntl = TextBox1.Text
        DBConn()
        SQLSTR = "SELECT * FROM '" & ClassIntl & "' ORDER BY LastName, StudentID"
        readDB()
        ListView1.Clear()
        ListView1.GridLines = True
        ListView1.FullRowSelect = True
        ListView1.View = View.Details
        ListView1.MultiSelect = False
        ListView1.Columns.Add("StudentID", 80)
        ListView1.Columns.Add("First Name", 80)
        ListView1.Columns.Add("Last Name", 80)
        ListView1.Columns.Add("Prelim", 50)
        ListView1.Columns.Add("Midterm", 50)
        ListView1.Columns.Add("Final", 50)
        ListView1.Columns.Add("Semestral", 80)
        While (SQLDR.Read())
            With ListView1.Items.Add(SQLDR("StudentID"))
                .subitems.add(SQLDR("FirstName"))
                .subitems.add(SQLDR("LastName"))
                .subitems.add(SQLDR("pGrade"))
                .subitems.add(SQLDR("mGrade"))
                .subitems.add(SQLDR("fGrade"))
                .subitems.add(SQLDR("semGrade"))
            End With
        End While
        SQLDR.Dispose()
        SQLCONN.Close()

        'Get Admin weights first!!
        Dim pWeight As Integer
        Dim mWeight As Integer
        Dim fWeight As Integer
        DBConn()
        Dim querystring As String = "SELECT PrelimWeight, MidtermWeight, FinalWeight FROM GlobalGrades"
        Dim command As New SQLiteCommand(querystring, SQLCONN)
        Dim reader As SQLiteDataReader = command.ExecuteReader
        While reader.Read
            pWeight = reader.GetValue(0)
            mWeight = reader.GetValue(1)
            fWeight = reader.GetValue(2)
        End While
        reader.Close()

        Dim lv As ListViewItem
        For Each lv In ListView1.Items
            Dim pWeighted As Double = pWeight / 100
            Dim mWeighted As Double = mWeight / 100
            Dim fWeighted As Double = fWeight / 100
            Dim pGrade As Double = lv.SubItems(3).Text * pWeighted
            Dim mGrade As Double = lv.SubItems(4).Text * mWeighted
            Dim fGrade As Double = lv.SubItems(5).Text * fWeighted

            Dim semGrade As Integer = pGrade + mGrade + fGrade
            lv.SubItems(6).Text = semGrade

            DBConn()
            SQLSTR = "UPDATE '" & ClassIntl & "' SET semGrade = '" & semGrade & "' WHERE StudentID = '" & lv.SubItems(0).Text & "'"
            alterDB()
        Next
        SQLDR.Dispose()
        SQLCONN.Close()

        DS.Clear()
        Dim con = New SQLiteConnection("Data Source = C:\Mickosis\Class Manager\ClassRecords.db")
        con.Open()
        Dim Sql As String = "SELECT * FROM '" & ClassIntl & "' ORDER BY LastName"
        Dim da = New SQLiteDataAdapter(Sql, con)
        da.Fill(DS, "SubjectsList")
        DataGridView1.DataSource = DS.Tables("SubjectsList").DefaultView
        With DataGridView1
            .RowHeadersVisible = False
            .Columns(0).HeaderCell.Value = "Student ID"
            .Columns(1).HeaderCell.Value = "First Name"
            .Columns(2).HeaderCell.Value = "Last Name"
            .Columns(3).HeaderCell.Value = "Prelim Quiz"
            .Columns(4).HeaderCell.Value = "Prelim Attendance"
            .Columns(5).HeaderCell.Value = "Prelim Recitation"
            .Columns(6).HeaderCell.Value = "Prelim Project"
            .Columns(7).HeaderCell.Value = "Prelim Homework"
            .Columns(8).HeaderCell.Value = "Prelim Others"
            .Columns(9).HeaderCell.Value = "Prelim Exam"
            .Columns(10).HeaderCell.Value = "Midterm Quiz"
            .Columns(11).HeaderCell.Value = "Midterm Attendance"
            .Columns(12).HeaderCell.Value = "Midterm Recitation"
            .Columns(13).HeaderCell.Value = "Midterm Project"
            .Columns(14).HeaderCell.Value = "Midterm Homework"
            .Columns(15).HeaderCell.Value = "Midterm Others"
            .Columns(16).HeaderCell.Value = "Midterm Exam"
            .Columns(17).HeaderCell.Value = "Final Quiz"
            .Columns(18).HeaderCell.Value = "Final Attendance"
            .Columns(19).HeaderCell.Value = "Final Recitation"
            .Columns(20).HeaderCell.Value = "Final Project"
            .Columns(21).HeaderCell.Value = "Final Homework"
            .Columns(22).HeaderCell.Value = "Final Others"
            .Columns(23).HeaderCell.Value = "Final Exam"
            .Columns(24).HeaderCell.Value = "Prelim Grade"
            .Columns(25).HeaderCell.Value = "Midterm Grade"
            .Columns(26).HeaderCell.Value = "Final Grade"
            .Columns(27).HeaderCell.Value = "Semestral Grade"
        End With
        DataGridView1.Sort(DataGridView1.Columns(0), System.ComponentModel.ListSortDirection.Ascending)
        con.Close()
    End Sub

    Private Sub HomeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles HomeToolStripMenuItem.Click
        Me.Hide()
        UpdateClass.Show()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim ClassIntl = TextBox1.Text
        Me.Hide()
        ClassCreateHomeAddStudents.TextBox4.Text = ClassIntl
        ClassCreateHomeAddStudents.Show()
    End Sub

    Private Sub Add_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button4.MouseHover

        Button4.Image = My.Resources.importdbasepressed

    End Sub

    Private Sub Add_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button4.MouseLeave

        Button4.Image = My.Resources.importdbase
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Dim ClassIntl = TextBox1.Text
        'Get Admin weights first!!
        Dim pWeight As Integer
        Dim mWeight As Integer
        Dim fWeight As Integer
        DBConn()
        Dim querystring As String = "SELECT PrelimWeight, MidtermWeight, FinalWeight FROM GlobalGrades"
        Dim command As New SQLiteCommand(querystring, SQLCONN)
        Dim reader As SQLiteDataReader = command.ExecuteReader
        While reader.Read
            pWeight = reader.GetValue(0)
            mWeight = reader.GetValue(1)
            fWeight = reader.GetValue(2)
        End While
        reader.Close()

        Dim lv As ListViewItem
        For Each lv In ListView1.Items
            Dim pWeighted As Double = pWeight / 100
            Dim mWeighted As Double = mWeight / 100
            Dim fWeighted As Double = fWeight / 100
            Dim pGrade As Double = lv.SubItems(3).Text * pWeighted
            Dim mGrade As Double = lv.SubItems(4).Text * mWeighted
            Dim fGrade As Double = lv.SubItems(5).Text * fWeighted

            Dim semGrade As Integer = pGrade + mGrade + fGrade
            lv.SubItems(6).Text = semGrade

            DBConn()
            SQLSTR = "UPDATE '" & ClassIntl & "' SET semGrade = '" & semGrade & "' WHERE StudentID = '" & lv.SubItems(0).Text & "'"
            alterDB()
        Next
        SQLDR.Dispose()
        SQLCONN.Close()
    End Sub

    Private Sub Calculate_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button5.MouseHover

        Button5.Image = My.Resources.importdbasepressed

    End Sub

    Private Sub Calculate_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button5.MouseLeave

        Button5.Image = My.Resources.importdbase
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim ClassIntl = TextBox1.Text
        AddPrelimGrades.TextBox1.Text = ClassIntl
        Me.Hide()
        AddPrelimGrades.LoadGrades()
        AddPrelimGrades.Show()
    End Sub

    Private Sub Prelim_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.MouseHover

        Button1.Image = My.Resources.importdbasepressed

    End Sub

    Private Sub Prelim_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.MouseLeave

        Button1.Image = My.Resources.importdbase
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim ClassIntl = TextBox1.Text
        AddMidtermGrades.TextBox1.Text = ClassIntl
        Me.Hide()
        AddMidtermGrades.LoadGrades()
        AddMidtermGrades.Show()
    End Sub

    Private Sub Nidterm_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button2.MouseHover

        Button2.Image = My.Resources.importdbasepressed

    End Sub

    Private Sub Midterm_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button2.MouseLeave

        Button2.Image = My.Resources.importdbase
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim ClassIntl = TextBox1.Text
        AddFinalGrades.TextBox1.Text = ClassIntl
        Me.Hide()
        AddFinalGrades.LoadGrades()
        AddFinalGrades.Show()
    End Sub

    Private Sub Finals_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button3.MouseHover

        Button3.Image = My.Resources.importdbasepressed

    End Sub

    Private Sub Finals_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button3.MouseLeave

        Button3.Image = My.Resources.importdbase
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        If MessageBox.Show("Do you want to exit?", "Class Manager", _
       MessageBoxButtons.YesNo, MessageBoxIcon.Warning) _
       = DialogResult.Yes Then
            Application.Exit()
        End If
    End Sub

    Private Sub MenuStrip1_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles MenuStrip1.ItemClicked

    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        'ExportPDF.Label1.Text = StudentToolStripMenuItem.Text
        'ExportPDF.TextBox1.Text = TextBox1.Text
        'ExportPDF.Show()
        'ExportPDF.LoadGrades()
        'Me.Hide()

        Dim pdfTable As New PdfPTable(DataGridView1.ColumnCount)

        'Add Title of PDF
        Dim cell1 As New PdfPCell(New Phrase(StudentToolStripMenuItem.Text))
        cell1.Colspan = 28
        cell1.Border = 0
        cell1.HorizontalAlignment = 1
        pdfTable.AddCell(cell1)

        'Creating iTextSharp Table from the DataTable data
        pdfTable.DefaultCell.Padding = 3
        pdfTable.WidthPercentage = 100
        pdfTable.HorizontalAlignment = Element.ALIGN_LEFT
        pdfTable.DefaultCell.BorderWidth = 1


        'Adding Header row
        For Each column As DataGridViewColumn In DataGridView1.Columns
            Dim cell As New PdfPCell(New Phrase(column.HeaderText))
            cell.BackgroundColor = New iTextSharp.text.BaseColor(240, 240, 240)
            pdfTable.AddCell(cell)
        Next

        'Adding DataRow
        For Each row As DataGridViewRow In DataGridView1.Rows
            If row.IsNewRow = False Then
                For Each cell As DataGridViewCell In row.Cells
                    pdfTable.AddCell(cell.Value.ToString())
                Next
            End If
        Next

        'Exporting to PDF
        Dim folderPath As String = "C:\Mickosis\Class Manager\PDFs\"
        If Not Directory.Exists(folderPath) Then
            Directory.CreateDirectory(folderPath)
        End If
        Using stream As New FileStream(folderPath & StudentToolStripMenuItem.Text & ".pdf", FileMode.Create)
            Dim pdfDoc As New Document(PageSize.A4.Rotate, 5.0F, 5.0F, 5.0F, 5.0F)
            PdfWriter.GetInstance(pdfDoc, stream)
            pdfDoc.Open()
            pdfDoc.Add(pdfTable)
            pdfDoc.Close()
            stream.Close()
        End Using

        MsgBox("PDF Created", , msgboxtitle)


    End Sub

    Private Sub AddGrades_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class





