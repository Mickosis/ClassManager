<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class StudentsHome
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(StudentsHome))
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.HomeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.StudentToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ListView1 = New System.Windows.Forms.ListView()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Update = New System.Windows.Forms.Button()
        Me.Email = New System.Windows.Forms.Button()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        Me.TextBox4 = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Search = New System.Windows.Forms.Button()
        Me.Close = New System.Windows.Forms.Button()
        Me.Import = New System.Windows.Forms.Button()
        Me.AddStudent = New System.Windows.Forms.Button()
        Me.MenuStrip1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.BackColor = System.Drawing.Color.RoyalBlue
        Me.MenuStrip1.Font = New System.Drawing.Font("Segoe UI", 16.0!)
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.HomeToolStripMenuItem, Me.StudentToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(834, 53)
        Me.MenuStrip1.TabIndex = 7
        Me.MenuStrip1.Text = "Student"
        '
        'HomeToolStripMenuItem
        '
        Me.HomeToolStripMenuItem.Image = Global.Class_Manager.My.Resources.Resources.arrow
        Me.HomeToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.HomeToolStripMenuItem.Name = "HomeToolStripMenuItem"
        Me.HomeToolStripMenuItem.Size = New System.Drawing.Size(112, 49)
        Me.HomeToolStripMenuItem.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal
        Me.HomeToolStripMenuItem.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay
        '
        'StudentToolStripMenuItem
        '
        Me.StudentToolStripMenuItem.Name = "StudentToolStripMenuItem"
        Me.StudentToolStripMenuItem.Size = New System.Drawing.Size(100, 49)
        Me.StudentToolStripMenuItem.Text = "Student"
        '
        'ListView1
        '
        Me.ListView1.Location = New System.Drawing.Point(28, 209)
        Me.ListView1.Name = "ListView1"
        Me.ListView1.Size = New System.Drawing.Size(536, 259)
        Me.ListView1.TabIndex = 8
        Me.ListView1.UseCompatibleStateImageBehavior = False
        '
        'PictureBox1
        '
        Me.PictureBox1.Location = New System.Drawing.Point(618, 67)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(160, 161)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 9
        Me.PictureBox1.TabStop = False
        '
        'Update
        '
        Me.Update.FlatAppearance.BorderSize = 0
        Me.Update.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent
        Me.Update.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.Update.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.Update.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Update.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Update.Image = CType(resources.GetObject("Update.Image"), System.Drawing.Image)
        Me.Update.Location = New System.Drawing.Point(597, 280)
        Me.Update.Name = "Update"
        Me.Update.Size = New System.Drawing.Size(209, 39)
        Me.Update.TabIndex = 10
        Me.Update.Text = "Update"
        Me.Update.UseVisualStyleBackColor = True
        '
        'Email
        '
        Me.Email.FlatAppearance.BorderSize = 0
        Me.Email.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent
        Me.Email.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.Email.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.Email.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Email.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Email.Image = CType(resources.GetObject("Email.Image"), System.Drawing.Image)
        Me.Email.Location = New System.Drawing.Point(597, 325)
        Me.Email.Name = "Email"
        Me.Email.Size = New System.Drawing.Size(209, 39)
        Me.Email.TabIndex = 11
        Me.Email.Text = "Contact E-mail"
        Me.Email.UseVisualStyleBackColor = True
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(570, 292)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(10, 20)
        Me.TextBox1.TabIndex = 12
        Me.TextBox1.Visible = False
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(61, 4)
        '
        'TextBox2
        '
        Me.TextBox2.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox2.Location = New System.Drawing.Point(195, 70)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(166, 29)
        Me.TextBox2.TabIndex = 15
        '
        'TextBox3
        '
        Me.TextBox3.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox3.Location = New System.Drawing.Point(195, 113)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(166, 29)
        Me.TextBox3.TabIndex = 16
        '
        'TextBox4
        '
        Me.TextBox4.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox4.Location = New System.Drawing.Point(195, 154)
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.Size = New System.Drawing.Size(166, 29)
        Me.TextBox4.TabIndex = 17
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(27, 70)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(104, 25)
        Me.Label1.TabIndex = 18
        Me.Label1.Text = "Student ID:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(25, 113)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(106, 25)
        Me.Label2.TabIndex = 19
        Me.Label2.Text = "First Name:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(25, 154)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(104, 25)
        Me.Label3.TabIndex = 20
        Me.Label3.Text = "Last Name:"
        '
        'Search
        '
        Me.Search.FlatAppearance.BorderSize = 0
        Me.Search.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.Search.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.Search.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Search.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Search.Image = Global.Class_Manager.My.Resources.Resources.okay
        Me.Search.Location = New System.Drawing.Point(453, 62)
        Me.Search.Name = "Search"
        Me.Search.Size = New System.Drawing.Size(111, 38)
        Me.Search.TabIndex = 21
        Me.Search.Text = "Search"
        Me.Search.UseVisualStyleBackColor = True
        '
        'Close
        '
        Me.Close.BackColor = System.Drawing.Color.RoyalBlue
        Me.Close.FlatAppearance.BorderSize = 0
        Me.Close.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.Close.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.Close.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Close.Image = Global.Class_Manager.My.Resources.Resources.CloseButton
        Me.Close.Location = New System.Drawing.Point(779, 0)
        Me.Close.Name = "Close"
        Me.Close.Size = New System.Drawing.Size(55, 53)
        Me.Close.TabIndex = 22
        Me.Close.UseVisualStyleBackColor = False
        '
        'Import
        '
        Me.Import.FlatAppearance.BorderSize = 0
        Me.Import.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent
        Me.Import.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.Import.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.Import.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Import.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Import.Image = CType(resources.GetObject("Import.Image"), System.Drawing.Image)
        Me.Import.Location = New System.Drawing.Point(597, 370)
        Me.Import.Name = "Import"
        Me.Import.Size = New System.Drawing.Size(209, 39)
        Me.Import.TabIndex = 23
        Me.Import.Text = "Import Excel File"
        Me.Import.UseVisualStyleBackColor = True
        '
        'AddStudent
        '
        Me.AddStudent.FlatAppearance.BorderSize = 0
        Me.AddStudent.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent
        Me.AddStudent.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.AddStudent.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.AddStudent.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.AddStudent.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AddStudent.Image = CType(resources.GetObject("AddStudent.Image"), System.Drawing.Image)
        Me.AddStudent.Location = New System.Drawing.Point(597, 235)
        Me.AddStudent.Name = "AddStudent"
        Me.AddStudent.Size = New System.Drawing.Size(209, 39)
        Me.AddStudent.TabIndex = 24
        Me.AddStudent.Text = "Add Student"
        Me.AddStudent.UseVisualStyleBackColor = True
        '
        'StudentsHome
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.ClientSize = New System.Drawing.Size(834, 480)
        Me.Controls.Add(Me.AddStudent)
        Me.Controls.Add(Me.Import)
        Me.Controls.Add(Me.Close)
        Me.Controls.Add(Me.Search)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TextBox4)
        Me.Controls.Add(Me.TextBox3)
        Me.Controls.Add(Me.TextBox2)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.Email)
        Me.Controls.Add(Me.Update)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.ListView1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "StudentsHome"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "View Student List"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents HomeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents StudentToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ListView1 As System.Windows.Forms.ListView
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Update As System.Windows.Forms.Button
    Friend WithEvents Email As System.Windows.Forms.Button
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox3 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox4 As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Search As System.Windows.Forms.Button
    Friend WithEvents Close As System.Windows.Forms.Button
    Friend WithEvents Import As System.Windows.Forms.Button
    Friend WithEvents AddStudent As System.Windows.Forms.Button
End Class
