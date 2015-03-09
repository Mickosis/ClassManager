Imports System.Data.SQLite
Imports iTextSharp.text.pdf
Imports iTextSharp.text
Imports System.IO


Public Class AddGrades
    Dim Checker2 As String
    Public Sub AddGrades()
        Dim ClassIntl = TextBox1.Text
        DBConn()
        SQLSTR = "SELECT StudentID, FirstName, LastName, pGrade, mGrade, fGrade, semGrade, remarks FROM '" & ClassIntl & "' ORDER BY LastName, StudentID"
        readDB()
        ListView1.Clear()
        ListView1.GridLines = True
        ListView1.FullRowSelect = True
        ListView1.View = View.Details
        ListView1.MultiSelect = False
        ListView1.Columns.Add("StudentID", 80)
        ListView1.Columns.Add("First Name", 80)
        ListView1.Columns.Add("Last Name", 90)
        ListView1.Columns.Add("Prelim", 40)
        ListView1.Columns.Add("Midterm", 40)
        ListView1.Columns.Add("Final", 40)
        ListView1.Columns.Add("Semestral", 40)
        ListView1.Columns.Add("Remarks", 45)
        While (SQLDR.Read())
            With ListView1.Items.Add(SQLDR("StudentID"))
                .subitems.add(SQLDR("FirstName"))
                .subitems.add(SQLDR("LastName"))
                .subitems.add(SQLDR("pGrade"))
                .subitems.add(SQLDR("mGrade"))
                .subitems.add(SQLDR("fGrade"))
                .subitems.add(SQLDR("semGrade"))
                .subitems.add(SQLDR("remarks"))
            End With
        End While
        SQLDR.Dispose()
        SQLCONN.Close()

        'Get Admin weights first!!
        Dim pWeight As Double
        Dim mWeight As Double
        Dim fWeight As Double
        Dim passMark As Double
        DBConn()
        Dim querystring As String = "SELECT PrelimWeight, MidtermWeight, FinalWeight, PassingMark FROM GlobalGrades"
        Dim command As New SQLiteCommand(querystring, SQLCONN)
        Dim reader As SQLiteDataReader = command.ExecuteReader
        While reader.Read
            pWeight = reader.GetValue(0)
            mWeight = reader.GetValue(1)
            fWeight = reader.GetValue(2)
            passMark = reader.GetValue(3)
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

            Dim semGrade As Double = pGrade + mGrade + fGrade
            lv.SubItems(6).Text = semGrade

            If lv.SubItems(6).Text >= passMark Then
                lv.SubItems(7).Text = "PASSED"
            Else
                lv.SubItems(7).Text = "FAILED"
            End If

            DBConn()
            SQLSTR = "UPDATE '" & ClassIntl & "' SET semGrade = '" & semGrade & "', remarks = '" & lv.SubItems(7).Text & "' WHERE StudentID = '" & lv.SubItems(0).Text & "'"
            alterDB()

            If (lv.SubItems(7).Text = "FAILED") Then
                lv.UseItemStyleForSubItems = False
                lv.SubItems(7).ForeColor = Color.Red
            End If

        Next
        SQLDR.Dispose()
        SQLCONN.Close()

        'Check Seat Plan
        Dim checker As String
        DBConn()
        Dim querystringseat As String = "SELECT Lab, SeatPlan FROM MasterClasslist WHERE ClassID = '" & ClassIntl & "'"
        Dim commandseat As New SQLiteCommand(querystringseat, SQLCONN)
        Dim readerseat As SQLiteDataReader = commandseat.ExecuteReader
        While readerseat.Read
            checker = readerseat.GetValue(0)
            Checker2 = readerseat.GetValue(1)
            If checker = "withlab" Then
                ComboBox1.Enabled = True
            Else
                ComboBox1.SelectedIndex = 0
                ComboBox1.Enabled = False
            End If
        End While
        readerseat.Close()
        SQLDR.Dispose()
        SQLCONN.Close()

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

        Dim ClassIntl = TextBox1.Text

        'Semestral Grades
        Dim DS As New DataSet()
        DS.Clear()
        Dim con = New SQLiteConnection("Data Source = C:\Mickosis\ClassRecords")
        con.Open()
        Dim Sql As String = "SELECT StudentID, LastName, FirstName, pGrade, mGrade, fGrade, semGrade, remarks FROM '" & ClassIntl & "' ORDER BY LastName, StudentID"
        Dim da = New SQLiteDataAdapter(Sql, con)
        da.Fill(DS, "GeneralGrades")
        DataGridView1.DataSource = DS.Tables("GeneralGrades").DefaultView
        With DataGridView1
            .RowHeadersVisible = False
            .Columns(0).HeaderCell.Value = "Student ID"
            .Columns(1).HeaderCell.Value = "Last Name"
            .Columns(2).HeaderCell.Value = "First Name"
            .Columns(3).HeaderCell.Value = "Prelim Grade"
            .Columns(4).HeaderCell.Value = "Midterm Grade"
            .Columns(5).HeaderCell.Value = "Final Grade"
            .Columns(6).HeaderCell.Value = "Semestral Grade"
            .Columns(7).HeaderCell.Value = "Remarks"
        End With
        con.Close()

        'Prelims
        Dim DS1 As New DataSet()
        DS1.Clear()
        con.Open()
        Dim Sql1 As String = "SELECT LastName, FirstName, pQuiz, pAttend, pRecite, pProject, pHomework, pOthers, pExam, pGrade FROM '" & ClassIntl & "' ORDER BY LastName"
        Dim da1 = New SQLiteDataAdapter(Sql1, con)
        da1.Fill(DS1, "PrelimGrades")
        DataGridView2.DataSource = DS1.Tables("PrelimGrades").DefaultView
        With DataGridView2
            .RowHeadersVisible = False
            .Columns(0).HeaderCell.Value = "Last Name"
            .Columns(1).HeaderCell.Value = "First Name"
            .Columns(2).HeaderCell.Value = "Quiz"
            .Columns(3).HeaderCell.Value = "Attendance"
            .Columns(4).HeaderCell.Value = "Recitation"
            .Columns(5).HeaderCell.Value = "Project"
            .Columns(6).HeaderCell.Value = "Homework"
            .Columns(7).HeaderCell.Value = "Activities"
            .Columns(8).HeaderCell.Value = "Exam"
            .Columns(9).HeaderCell.Value = "Prelim Grade"
        End With
        con.Close()

        'Midterms
        Dim DS2 As New DataSet()
        DS2.Clear()
        con.Open()
        Dim Sql2 As String = "SELECT LastName, FirstName, mQuiz, mAttend, mRecite, mProject, mHomework, mOthers, mExam, mGrade FROM '" & ClassIntl & "' ORDER BY LastName"
        Dim da2 = New SQLiteDataAdapter(Sql2, con)
        da2.Fill(DS2, "MidtermGrades")
        DataGridView3.DataSource = DS2.Tables("MidtermGrades").DefaultView
        With DataGridView3
            .RowHeadersVisible = False
            .Columns(0).HeaderCell.Value = "Last Name"
            .Columns(1).HeaderCell.Value = "First Name"
            .Columns(2).HeaderCell.Value = "Quiz"
            .Columns(3).HeaderCell.Value = "Attendance"
            .Columns(4).HeaderCell.Value = "Recitation"
            .Columns(5).HeaderCell.Value = "Project"
            .Columns(6).HeaderCell.Value = "Homework"
            .Columns(7).HeaderCell.Value = "Activities"
            .Columns(8).HeaderCell.Value = "Exam"
            .Columns(9).HeaderCell.Value = "Midterm Grade"
        End With
        con.Close()

        'Finals
        Dim DS3 As New DataSet()
        DS3.Clear()
        con.Open()
        Dim Sql3 As String = "SELECT LastName, FirstName, fQuiz, fAttend, fRecite, fProject, fHomework, fOthers, fExam, fGrade FROM '" & ClassIntl & "' ORDER BY LastName"
        Dim da3 = New SQLiteDataAdapter(Sql3, con)
        da3.Fill(DS3, "FinalGrades")
        DataGridView4.DataSource = DS3.Tables("FinalGrades").DefaultView
        With DataGridView4
            .RowHeadersVisible = False
            .Columns(0).HeaderCell.Value = "Last Name"
            .Columns(1).HeaderCell.Value = "First Name"
            .Columns(2).HeaderCell.Value = "Quiz"
            .Columns(3).HeaderCell.Value = "Attendance"
            .Columns(4).HeaderCell.Value = "Recitation"
            .Columns(5).HeaderCell.Value = "Project"
            .Columns(6).HeaderCell.Value = "Homework"
            .Columns(7).HeaderCell.Value = "Activities"
            .Columns(8).HeaderCell.Value = "Exam"
            .Columns(9).HeaderCell.Value = "Final Grade"
        End With
        con.Close()

        Try
            Dim pdfTable As New PdfPTable(DataGridView1.ColumnCount)

            'Add Title of PDF
            Dim cell1 As New PdfPCell(New Phrase(StudentToolStripMenuItem.Text + ", " + ToolStripMenuItem1.Text))
            cell1.Colspan = 8
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

            'Prelims
            Dim pdfTable1 As New PdfPTable(DataGridView2.ColumnCount)

            'Add Title of PDF
            Dim cell2 As New PdfPCell(New Phrase(StudentToolStripMenuItem.Text + ", " + ToolStripMenuItem1.Text + " Prelim Grades"))
            cell2.Colspan = 11
            cell2.Border = 0
            cell2.HorizontalAlignment = 1
            pdfTable1.AddCell(cell2)

            'Creating iTextSharp Table from the DataTable data
            pdfTable1.DefaultCell.Padding = 3
            pdfTable1.WidthPercentage = 100
            pdfTable1.HorizontalAlignment = Element.ALIGN_LEFT
            pdfTable1.DefaultCell.BorderWidth = 1

            'Adding Header row
            For Each column As DataGridViewColumn In DataGridView2.Columns
                Dim cell As New PdfPCell(New Phrase(column.HeaderText))
                cell.BackgroundColor = New iTextSharp.text.BaseColor(240, 240, 240)
                pdfTable1.AddCell(cell)
            Next

            'Adding DataRow
            For Each row As DataGridViewRow In DataGridView2.Rows
                If row.IsNewRow = False Then
                    For Each cell As DataGridViewCell In row.Cells
                        pdfTable1.AddCell(cell.Value.ToString())
                    Next
                End If
            Next

            'Midterms
            Dim pdfTable2 As New PdfPTable(DataGridView3.ColumnCount)

            'Add Title of PDF
            Dim cell3 As New PdfPCell(New Phrase(StudentToolStripMenuItem.Text + ", " + ToolStripMenuItem1.Text + " Midterm Grades"))
            cell3.Colspan = 11
            cell3.Border = 0
            cell3.HorizontalAlignment = 1
            pdfTable2.AddCell(cell3)

            'Creating iTextSharp Table from the DataTable data
            pdfTable2.DefaultCell.Padding = 3
            pdfTable2.WidthPercentage = 100
            pdfTable2.HorizontalAlignment = Element.ALIGN_LEFT
            pdfTable2.DefaultCell.BorderWidth = 1


            'Adding Header row
            For Each column As DataGridViewColumn In DataGridView3.Columns
                Dim cell As New PdfPCell(New Phrase(column.HeaderText))
                cell.BackgroundColor = New iTextSharp.text.BaseColor(240, 240, 240)
                pdfTable2.AddCell(cell)
            Next

            'Adding DataRow
            For Each row As DataGridViewRow In DataGridView3.Rows
                If row.IsNewRow = False Then
                    For Each cell As DataGridViewCell In row.Cells
                        pdfTable2.AddCell(cell.Value.ToString())
                    Next
                End If
            Next

            'Finals
            Dim pdfTable3 As New PdfPTable(DataGridView4.ColumnCount)

            'Add Title of PDF
            Dim cell4 As New PdfPCell(New Phrase(StudentToolStripMenuItem.Text + ", " + ToolStripMenuItem1.Text + " Final Grades"))
            cell4.Colspan = 11
            cell4.Border = 0
            cell4.HorizontalAlignment = 1
            pdfTable3.AddCell(cell4)

            'Creating iTextSharp Table from the DataTable data
            pdfTable3.DefaultCell.Padding = 3
            pdfTable3.WidthPercentage = 100
            pdfTable3.HorizontalAlignment = Element.ALIGN_LEFT
            pdfTable3.DefaultCell.BorderWidth = 1


            'Adding Header row
            For Each column As DataGridViewColumn In DataGridView4.Columns
                Dim cell As New PdfPCell(New Phrase(column.HeaderText))
                cell.BackgroundColor = New iTextSharp.text.BaseColor(240, 240, 240)
                pdfTable3.AddCell(cell)
            Next

            'Adding DataRow
            For Each row As DataGridViewRow In DataGridView4.Rows
                If row.IsNewRow = False Then
                    For Each cell As DataGridViewCell In row.Cells
                        pdfTable3.AddCell(cell.Value.ToString())
                    Next
                End If
            Next


            'Exporting to PDF
            Dim folderPath As String = "C:\Mickosis\Class Manager\PDFs\"
            If Not Directory.Exists(folderPath) Then
                Directory.CreateDirectory(folderPath)
            End If
            Using stream As New FileStream(folderPath & StudentToolStripMenuItem.Text & ".pdf", FileMode.Create)
                Dim pdfDoc As New Document(PageSize.A4, 5.0F, 5.0F, 5.0F, 5.0F)
                PdfWriter.GetInstance(pdfDoc, stream)
                pdfDoc.Open()
                pdfDoc.Add(pdfTable)
                pdfDoc.NewPage()
                pdfDoc.Add(pdfTable1)
                pdfDoc.NewPage()
                pdfDoc.Add(pdfTable2)
                pdfDoc.NewPage()
                pdfDoc.Add(pdfTable3)
                pdfDoc.Close()
                stream.Close()
            End Using

            MsgBox("PDF Created!", , msgboxtitle)

            Dim FileName As String = folderPath & StudentToolStripMenuItem.Text & ".pdf"
            Process.Start(FileName)


        Catch ex As Exception
            MsgBox("PDF file is in use, please close any programs first then try again.")
        End Try

    End Sub

    Private Sub Add8_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button8.MouseHover

        Button8.Image = My.Resources.importdbasepressed

    End Sub

    Private Sub Add8_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button8.MouseLeave

        Button8.Image = My.Resources.importdbase
    End Sub

    Private Sub AddGrades_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If ComboBox1.Items.Count > 0 Then
            ComboBox1.SelectedIndex = 0
        End If
    End Sub

    Private Sub ListView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListView1.SelectedIndexChanged

    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Dim Checker As String
        Dim ClassIntl = TextBox1.Text
        SeatPlanLab.TextBox1.Text = ClassIntl
        SeatPlanCorner.TextBox1.Text = ClassIntl
        SeatPlanNotCorner.TextBox1.Text = ClassIntl
        Me.Hide()
        Checker = ComboBox1.SelectedItem.ToString
        'MessageBox.Show(Checker)
        'DBConn()
        'SQLSTR = "SELECT SeatPlan FROM MasterClasslist WHERE ClassID = '" & ClassIntl & "'"
        'readDB()
        'While (SQLDR.Read())
        'Checker2 = SQLDR("SeatPlan")
        If Checker = "Lab" Then
            SeatPlanLab.Arrangement()
            SeatPlanLab.Show()
        Else
            If Checker2 = "corner" Then
                SeatPlanCorner.Arrangement()
                SeatPlanCorner.Show()
            Else
                SeatPlanNotCorner.Arrangement()
                SeatPlanNotCorner.Show()
            End If
        End If
        'End While
        'SQLDR.Dispose()
        'SQLCONN.Close()
    End Sub

    Private Sub Add9_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button5.MouseHover

        Button5.Image = My.Resources.importdbasepressed

    End Sub

    Private Sub Add9_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button5.MouseLeave

        Button5.Image = My.Resources.importdbase
    End Sub


    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
    End Sub
End Class





