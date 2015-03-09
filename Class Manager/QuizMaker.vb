Imports System
Imports System.IO
Imports iTextSharp
Imports iTextSharp.text.pdf
Imports iTextSharp.text

Public Class QuizMaker

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Dim SaveFileDialog1 As New SaveFileDialog()

        SaveFileDialog1.Title = "Choose where to save your quiz"
        SaveFileDialog1.Filter = "PDF Files(*.pdf)|*.pdf"

        ' Create Document class object and set its size to letter and give space left, right, Top, Bottom Margin
        Dim doc As New Document(iTextSharp.text.PageSize.A4)
        ' Using Savefiledialog
        SaveFileDialog1.ShowDialog()
        If SaveFileDialog1.FileName = "" Then
            RichTextBox1.Focus()
        Else
            Try
                Dim wri As PdfWriter = PdfWriter.GetInstance(doc, New FileStream(SaveFileDialog1.FileName, FileMode.Create))

                wri.StrictImageSequence = True

                ' Open Document to write
                doc.Open()

                'Make a new image object
                Dim ImagePath = "C:\Mickosis\Class Manager\Logo.jpg"
                Dim Img = iTextSharp.text.Image.GetInstance(ImagePath)
                Img.SetAbsolutePosition(464, 710)
                wri.DirectContent.AddImage(Img)

                Dim ImagePath1 = "C:\Mickosis\Class Manager\AdU.jpg"
                Dim Img1 = iTextSharp.text.Image.GetInstance(ImagePath1)
                Img1.SetAbsolutePosition(29, 710)
                wri.DirectContent.AddImage(Img1)

                Dim linespacing As Single = 1.0F

                Dim p6 As New Paragraph
                ' setting line spacing between paragraph to 1.
                p6.Font = FontFactory.GetFont("ARIAL", 9.0F)
                p6.Alignment = Element.ALIGN_CENTER
                ' Adding RichTextBox to Paragraph
                p6.Add(" ")
                ' Adding Paragraph to Document
                doc.Add(p6)
                doc.Add(Chunk.NEWLINE)

                ' Declaring p1 as Paragraph
                Dim p2 As New Paragraph
                ' setting line spacing between paragraph to 1.
                p2.Font = FontFactory.GetFont("ARIAL", 9.0F)
                p2.Alignment = Element.ALIGN_CENTER
                ' Adding RichTextBox to Paragraph
                p2.Add("Adamson University")
                ' Adding Paragraph to Document
                doc.Add(p2)

                ' Declaring p1 as Paragraph
                Dim p3 As New Paragraph
                ' setting line spacing between paragraph to 1.
                p3.Font = FontFactory.GetFont("ARIAL", 9.0F)
                ' Adding RichTextBox to Paragraph
                p3.Alignment = Element.ALIGN_CENTER
                p3.Add("IT&M Department")
                ' Adding Paragraph to Document
                doc.Add(p3)

                doc.Add(Chunk.NEWLINE)
                doc.Add(Chunk.NEWLINE)
                doc.Add(Chunk.NEWLINE)

                ' Declaring p4 as Paragraph
                Dim p4 As New Paragraph
                ' setting line spacing between paragraph to 1.
                ' Setting font for Paragraph to arial
                p4.Font = FontFactory.GetFont("ARIAL", 9.0F)
                ' Adding RichTextBox to Paragraph
                p4.Add("Name:____________________________________________________                     Score:______/______")
                ' Adding Paragraph to Document
                doc.Add(p4)
                doc.Add(Chunk.NEWLINE)

                ' Declaring p4 as Paragraph
                Dim p5 As New Paragraph
                ' setting line spacing between paragraph to 1.
                ' Setting font for Paragraph to arial
                p5.Font = FontFactory.GetFont("ARIAL", 9.0F)
                ' Adding RichTextBox to Paragraph
                p5.Add("Subject:___________________________________________________                     Professor:__________________________")
                ' Adding Paragraph to Document
                doc.Add(p5)
                doc.Add(Chunk.NEWLINE)
                doc.Add(Chunk.NEWLINE)

                ' Declaring p1 as Paragraph
                Dim p1 As New Paragraph
                ' setting line spacing between paragraph to 1.
                ' Setting font for Paragraph to arial
                p1.Font = FontFactory.GetFont("ARIAL", 9.0F)
                ' Adding RichTextBox to Paragraph
                p1.Add(RichTextBox1.Text)
                ' Adding Paragraph to Document
                doc.Add(p1)

                ' Document Closing
                doc.Close()

            Catch docEx As DocumentException
                MessageBox.Show(docEx.Message)
                ' handle IO exception
            Catch ioEx As IOException
                ' hahndle other exception if occurs
                MessageBox.Show(ioEx.Message)
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            Finally
                'Close document and writer
                doc.Close()
                Process.Start(SaveFileDialog1.FileName)
            End Try
        End If

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        If ComboBox1.Text = "Identification" Then
            RichTextBox1.Focus()
            Button1.Enabled = True
            RichTextBox1.Text = "Identify the item being asked. Write before the number." + Environment.NewLine + Environment.NewLine + "__________________1. Question Here" + Environment.NewLine + Environment.NewLine + "__________________2. Question Here" + Environment.NewLine + Environment.NewLine + "__________________3. Question Here" + Environment.NewLine + Environment.NewLine + "__________________4. Question Here" + Environment.NewLine + Environment.NewLine + "__________________5. Question Here" + Environment.NewLine + Environment.NewLine + "__________________6. Question Here" + Environment.NewLine + Environment.NewLine + "__________________7. Question Here" + Environment.NewLine + Environment.NewLine + "__________________8. Question Here" + Environment.NewLine + Environment.NewLine + "__________________9. Question Here" + Environment.NewLine + Environment.NewLine + "__________________10. Question Here"

        ElseIf ComboBox1.Text = "Multiple Choice" Then
            RichTextBox1.Focus()
            Button1.Enabled = True
            RichTextBox1.Text = "Identify and select from the given answers below. Write the letters only." + Environment.NewLine + Environment.NewLine + "_____1. Question Here" + Environment.NewLine + "A.           B.          C.          D." + Environment.NewLine + "_____2. Question Here" + Environment.NewLine + "A.           B.          C.          D." + Environment.NewLine + "_____3. Question Here" + Environment.NewLine + "A.           B.          C.          D." + Environment.NewLine + "_____4. Question Here" + Environment.NewLine + "A.           B.          C.          D." + Environment.NewLine + "_____5. Question Here" + Environment.NewLine + "A.           B.          C.          D." + Environment.NewLine + "_____6. Question Here" + Environment.NewLine + "A.           B.          C.          D." + Environment.NewLine + "_____7. Question Here" + Environment.NewLine + "A.           B.          C.          D." + Environment.NewLine + "_____8. Question Here" + Environment.NewLine + "A.           B.          C.          D." + Environment.NewLine + "_____9. Question Here" + Environment.NewLine + "A.           B.          C.          D." + Environment.NewLine + "_____10. Question Here" + Environment.NewLine + "A.           B.          C.          D."
        ElseIf ComboBox1.Text = "True or False" Then
            RichTextBox1.Focus()
            Button1.Enabled = True
            RichTextBox1.Text = "Read each item carefully. Write T if the statement is True, otherwise F if False." + Environment.NewLine + Environment.NewLine + "_____1. Question Here" + Environment.NewLine + Environment.NewLine + "_____2. Question Here" + Environment.NewLine + Environment.NewLine + "_____3. Question Here" + Environment.NewLine + Environment.NewLine + "_____4. Question Here" + Environment.NewLine + Environment.NewLine + "_____5. Question Here" + Environment.NewLine + Environment.NewLine + "_____6. Question Here" + Environment.NewLine + Environment.NewLine + "_____7. Question Here" + Environment.NewLine + Environment.NewLine + "_____8. Question Here" + Environment.NewLine + Environment.NewLine + "_____9. Question Here" + Environment.NewLine + Environment.NewLine + "_____10. Question Here" + Environment.NewLine + Environment.NewLine
        Else
            Button1.Enabled = False
        End If
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

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
End Class