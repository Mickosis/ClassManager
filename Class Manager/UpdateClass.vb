Imports System.Data.SQLite

Public Class UpdateClass

    Private Sub UpdateClass_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated

        DBConn()
        SQLSTR = "SELECT * FROM MasterClasslist"
        readDB()
        ListView1.GridLines = True
        ListView1.FullRowSelect = True
        ListView1.View = View.Details
        ListView1.Clear()
        ListView1.MultiSelect = False
        ListView1.Columns.Add("ClassID", 80)
        ListView1.Columns.Add("Name", 80)
        ListView1.Columns.Add("Desc", 320)
        While (SQLDR.Read())
            With ListView1.Items.Add(SQLDR("ClassID"))
                .subitems.add(SQLDR("Name"))
                .subitems.add(SQLDR("Desc"))
            End With
        End While
        SQLDR.Dispose()
        SQLCONN.Close()
        DelClass.Enabled = False

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Selected.Click
        If Not ListView1.SelectedItems.Count = 0 Then
            With ListView1.SelectedItems.Item(0)
                AddGrades.TextBox1.Text = .SubItems(0).Text
                AddGrades.StudentToolStripMenuItem.Text = .SubItems(1).Text
            End With
            Me.Hide()
            AddGrades.AddGrades()
            AddGrades.Show()
        End If
    End Sub

    Private Sub ListView1_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListView1.DoubleClick
        If Not ListView1.SelectedItems.Count = 0 Then
            With ListView1.SelectedItems.Item(0)
                AddGrades.TextBox1.Text = .SubItems(0).Text
                AddGrades.StudentToolStripMenuItem.Text = .SubItems(1).Text
            End With
            Me.Hide()
            AddGrades.AddGrades()
            AddGrades.Show()
        End If
    End Sub

    Private Sub Selected_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles Selected.MouseHover

        Selected.Image = My.Resources.Browse_and_Update_pressed

    End Sub
    Private Sub Selected_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Selected.MouseLeave

        Selected.Image = My.Resources.Browse_and_Update

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles DelClass.Click
        If Not ListView1.SelectedItems.Count = 0 Then
            With ListView1.SelectedItems.Item(0)
                Dim DeleteNumber As String = .SubItems(0).Text
                Dim Result = MsgBox("Are you sure you want to delete class?", MessageBoxButtons.YesNo, msgboxtitle)
                DBConn()
                If Result = DialogResult.Yes Then
                    SQLSTR = "DELETE FROM MasterClasslist WHERE ClassID = '" & DeleteNumber & "'"
                    alterDB()
                    SQLSTR = "DROP TABLE '" & DeleteNumber & "'"
                    alterDB()
                    MsgBox("Class deleted succesfully!", , msgboxtitle)
                    ListView1.Refresh()
                End If
            End With
        End If

    End Sub

    Private Sub Create_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles DelClass.MouseHover

        DelClass.Image = My.Resources.Browse_and_Update_pressed

    End Sub
    Private Sub Create_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles DelClass.MouseLeave

        DelClass.Image = My.Resources.Browse_and_Update

    End Sub

    Private Sub ListView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListView1.SelectedIndexChanged
        If ListView1.SelectedItems.Count = 1 Then
            DelClass.Enabled = True
        ElseIf ListView1.SelectedItems.Count = 0 Then
            DelClass.Enabled = False

        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Close_Click(sender As Object, e As EventArgs) Handles Close.Click
        If MessageBox.Show("Do you want to exit?", "Class Manager", _
       MessageBoxButtons.YesNo, MessageBoxIcon.Warning) _
       = DialogResult.Yes Then
            Application.Exit()
        End If
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub HomeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles HomeToolStripMenuItem.Click
        Me.Hide()

        ClassHome.Show()

    End Sub
End Class