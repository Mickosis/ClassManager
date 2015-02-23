Imports System.IO
Imports System.Data
Imports System.Reflection
Imports iTextSharp.text
Imports iTextSharp.text.pdf
Imports System.Data.SQLite

Public Class ExportPDF
    Dim DS As New DataSet()

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Dim pdfTable As New PdfPTable(DataGridView1.ColumnCount)

        'Add Title of PDF
        Dim cell1 As New PdfPCell(New Phrase(Label1.Text))
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
        Using stream As New FileStream(folderPath & Label1.Text & ".pdf", FileMode.Create)
            Dim pdfDoc As New Document(PageSize.A4, 10.0F, 10.0F, 10.0F, 0.0F)
            PdfWriter.GetInstance(pdfDoc, stream)
            pdfDoc.Open()
            pdfDoc.Add(pdfTable)
            pdfDoc.Close()
            stream.Close()
        End Using
    End Sub

    Private Sub ExportPDF_Load(sender As Object, e As EventArgs) Handles MyBase.Load
     


    End Sub


    Public Sub LoadGrades()

        DS.Clear()
        Dim ClassIntl As Integer = TextBox1.Text
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


    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Hide()
        AddGrades.AddGrades()
        AddGrades.Show()

    End Sub
End Class