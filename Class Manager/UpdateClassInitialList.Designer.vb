<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UpdateClassInitialList
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(UpdateClassInitialList))
        Me.ListView1 = New System.Windows.Forms.ListView()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Students = New System.Windows.Forms.Button()
        Me.Grade = New System.Windows.Forms.Button()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.HomeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.StudentToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Close = New System.Windows.Forms.Button()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ListView1
        '
        Me.ListView1.Location = New System.Drawing.Point(23, 82)
        Me.ListView1.Name = "ListView1"
        Me.ListView1.Size = New System.Drawing.Size(341, 266)
        Me.ListView1.TabIndex = 0
        Me.ListView1.UseCompatibleStateImageBehavior = False
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(196, 393)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(10, 20)
        Me.TextBox1.TabIndex = 1
        Me.TextBox1.Visible = False
        '
        'Students
        '
        Me.Students.FlatAppearance.BorderSize = 0
        Me.Students.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent
        Me.Students.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.Students.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.Students.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Students.Font = New System.Drawing.Font("Segoe UI Light", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Students.Image = CType(resources.GetObject("Students.Image"), System.Drawing.Image)
        Me.Students.Location = New System.Drawing.Point(250, 354)
        Me.Students.Name = "Students"
        Me.Students.Size = New System.Drawing.Size(120, 44)
        Me.Students.TabIndex = 2
        Me.Students.Text = "Add Students"
        Me.Students.UseVisualStyleBackColor = True
        '
        'Grade
        '
        Me.Grade.FlatAppearance.BorderSize = 0
        Me.Grade.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent
        Me.Grade.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.Grade.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.Grade.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Grade.Font = New System.Drawing.Font("Segoe UI Light", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Grade.Image = CType(resources.GetObject("Grade.Image"), System.Drawing.Image)
        Me.Grade.Location = New System.Drawing.Point(23, 355)
        Me.Grade.Name = "Grade"
        Me.Grade.Size = New System.Drawing.Size(120, 44)
        Me.Grade.TabIndex = 3
        Me.Grade.Text = "Add Grades"
        Me.Grade.UseVisualStyleBackColor = True
        '
        'MenuStrip1
        '
        Me.MenuStrip1.BackColor = System.Drawing.Color.Firebrick
        Me.MenuStrip1.Font = New System.Drawing.Font("Segoe UI", 16.0!)
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.HomeToolStripMenuItem, Me.StudentToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(382, 53)
        Me.MenuStrip1.TabIndex = 14
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
        Me.StudentToolStripMenuItem.Size = New System.Drawing.Size(150, 49)
        Me.StudentToolStripMenuItem.Text = "Update Class"
        '
        'Close
        '
        Me.Close.BackColor = System.Drawing.Color.Firebrick
        Me.Close.FlatAppearance.BorderSize = 0
        Me.Close.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.Close.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.Close.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Close.Image = Global.Class_Manager.My.Resources.Resources.CloseButton
        Me.Close.Location = New System.Drawing.Point(327, 0)
        Me.Close.Name = "Close"
        Me.Close.Size = New System.Drawing.Size(55, 53)
        Me.Close.TabIndex = 25
        Me.Close.UseVisualStyleBackColor = False
        '
        'UpdateClassInitialList
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.ClientSize = New System.Drawing.Size(382, 412)
        Me.Controls.Add(Me.Close)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.Grade)
        Me.Controls.Add(Me.Students)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.ListView1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "UpdateClassInitialList"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "UpdateClassInitialList"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ListView1 As System.Windows.Forms.ListView
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Students As System.Windows.Forms.Button
    Friend WithEvents Grade As System.Windows.Forms.Button
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents HomeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents StudentToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Close As System.Windows.Forms.Button
End Class
