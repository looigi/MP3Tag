<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmStatistiche
    Inherits System.Windows.Forms.Form

    'Form esegue l'override del metodo Dispose per pulire l'elenco dei componenti.
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

    'Richiesto da Progettazione Windows Form
    Private components As System.ComponentModel.IContainer

    'NOTA: la procedura che segue è richiesta da Progettazione Windows Form
    'Può essere modificata in Progettazione Windows Form.  
    'Non modificarla nell'editor del codice.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.pnlStatistiche = New System.Windows.Forms.Panel()
        Me.lblOperazione = New System.Windows.Forms.Label()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.cmdEsegue = New System.Windows.Forms.Button()
        Me.cmdChiude = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'pnlStatistiche
        '
        Me.pnlStatistiche.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlStatistiche.AutoScroll = True
        Me.pnlStatistiche.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.pnlStatistiche.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlStatistiche.Location = New System.Drawing.Point(13, 34)
        Me.pnlStatistiche.Name = "pnlStatistiche"
        Me.pnlStatistiche.Size = New System.Drawing.Size(436, 367)
        Me.pnlStatistiche.TabIndex = 0
        '
        'lblOperazione
        '
        Me.lblOperazione.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOperazione.Location = New System.Drawing.Point(13, 8)
        Me.lblOperazione.Name = "lblOperazione"
        Me.lblOperazione.Size = New System.Drawing.Size(188, 23)
        Me.lblOperazione.TabIndex = 1
        Me.lblOperazione.Text = "Label1"
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ProgressBar1.Location = New System.Drawing.Point(207, 8)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(242, 23)
        Me.ProgressBar1.TabIndex = 2
        '
        'cmdEsegue
        '
        Me.cmdEsegue.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdEsegue.Location = New System.Drawing.Point(13, 407)
        Me.cmdEsegue.Name = "cmdEsegue"
        Me.cmdEsegue.Size = New System.Drawing.Size(129, 23)
        Me.cmdEsegue.TabIndex = 0
        Me.cmdEsegue.Text = "Esegue ricerca"
        Me.cmdEsegue.UseVisualStyleBackColor = True
        '
        'cmdChiude
        '
        Me.cmdChiude.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdChiude.Location = New System.Drawing.Point(320, 407)
        Me.cmdChiude.Name = "cmdChiude"
        Me.cmdChiude.Size = New System.Drawing.Size(129, 23)
        Me.cmdChiude.TabIndex = 3
        Me.cmdChiude.Text = "Chiude"
        Me.cmdChiude.UseVisualStyleBackColor = True
        '
        'frmStatistiche
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(461, 437)
        Me.ControlBox = False
        Me.Controls.Add(Me.cmdChiude)
        Me.Controls.Add(Me.cmdEsegue)
        Me.Controls.Add(Me.ProgressBar1)
        Me.Controls.Add(Me.lblOperazione)
        Me.Controls.Add(Me.pnlStatistiche)
        Me.Name = "frmStatistiche"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Statistiche"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlStatistiche As System.Windows.Forms.Panel
    Friend WithEvents lblOperazione As System.Windows.Forms.Label
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
    Friend WithEvents cmdEsegue As System.Windows.Forms.Button
    Friend WithEvents cmdChiude As System.Windows.Forms.Button
End Class
