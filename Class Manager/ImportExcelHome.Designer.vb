<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ImportExcelHome
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ImportExcelHome))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Browse = New System.Windows.Forms.Button()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.ImportDbase = New System.Windows.Forms.Button()
        Me.StudentToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HomeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.Close = New System.Windows.Forms.Button()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI Light", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(25, 76)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(155, 21)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "Import your Excel File:"
        '
        'TextBox1
        '
        Me.TextBox1.Font = New System.Drawing.Font("Segoe UI Light", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox1.Location = New System.Drawing.Point(28, 117)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(169, 29)
        Me.TextBox1.TabIndex = 10
        '
        'Browse
        '
        Me.Browse.FlatAppearance.BorderSize = 0
        Me.Browse.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent
        Me.Browse.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.Browse.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.Browse.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Browse.Font = New System.Drawing.Font("Segoe UI Light", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Browse.Image = CType(resources.GetObject("Browse.Image"), System.Drawing.Image)
        Me.Browse.Location = New System.Drawing.Point(225, 110)
        Me.Browse.Name = "Browse"
        Me.Browse.Size = New System.Drawing.Size(91, 38)
        Me.Browse.TabIndex = 11
        Me.Browse.Text = "Browse"
        Me.Browse.UseVisualStyleBackColor = True
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.AllowUserToResizeColumns = False
        Me.DataGridView1.AllowUserToResizeRows = False
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(28, 201)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowHeadersVisible = False
        Me.DataGridView1.Size = New System.Drawing.Size(280, 158)
        Me.DataGridView1.TabIndex = 12
        '
        'Button2
        '
        Me.Button2.FlatAppearance.BorderSize = 0
        Me.Button2.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent
        Me.Button2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.Button2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Font = New System.Drawing.Font("Segoe UI Light", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.Image = CType(resources.GetObject("Button2.Image"), System.Drawing.Image)
        Me.Button2.Location = New System.Drawing.Point(225, 154)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(91, 38)
        Me.Button2.TabIndex = 13
        Me.Button2.Text = "Import"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'ImportDbase
        '
        Me.ImportDbase.FlatAppearance.BorderSize = 0
        Me.ImportDbase.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.ImportDbase.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.ImportDbase.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ImportDbase.Font = New System.Drawing.Font("Segoe UI Light", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImportDbase.Image = Global.Class_Manager.My.Resources.Resources.importdbase
        Me.ImportDbase.Location = New System.Drawing.Point(65, 365)
        Me.ImportDbase.Name = "ImportDbase"
        Me.ImportDbase.Size = New System.Drawing.Size(213, 49)
        Me.ImportDbase.TabIndex = 14
        Me.ImportDbase.Text = "Import to Database"
        Me.ImportDbase.UseVisualStyleBackColor = True
        '
        'StudentToolStripMenuItem
        '
        Me.StudentToolStripMenuItem.Name = "StudentToolStripMenuItem"
        Me.StudentToolStripMenuItem.Size = New System.Drawing.Size(145, 49)
        Me.StudentToolStripMenuItem.Text = "Import Excel"
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
        'MenuStrip1
        '
        Me.MenuStrip1.BackColor = System.Drawing.Color.RoyalBlue
        Me.MenuStrip1.Font = New System.Drawing.Font("Segoe UI", 16.0!)
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.HomeToolStripMenuItem, Me.StudentToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(338, 53)
        Me.MenuStrip1.TabIndex = 15
        Me.MenuStrip1.Text = "Student"
        '
        'Close
        '
        Me.Close.BackColor = System.Drawing.Color.RoyalBlue
        Me.Close.FlatAppearance.BorderSize = 0
        Me.Close.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.Close.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.Close.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Close.Image = Global.Class_Manager.My.Resources.Resources.CloseButton
        Me.Close.Location = New System.Drawing.Point(283, 0)
        Me.Close.Name = "Close"
        Me.Close.Size = New System.Drawing.Size(55, 53)
        Me.Close.TabIndex = 23
        Me.Close.UseVisualStyleBackColor = False
        '
        'ImportExcelHome
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.ClientSize = New System.Drawing.Size(338, 426)
        Me.Controls.Add(Me.Close)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.ImportDbase)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.Browse)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "ImportExcelHome"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "StudentsRecords"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Browse As System.Windows.Forms.Button
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents ImportDbase As System.Windows.Forms.Button
    Friend WithEvents StudentToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HomeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents Close As System.Windows.Forms.Button
End Class
