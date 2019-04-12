<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmUguali
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
        Me.lblPrimoDir = New System.Windows.Forms.Label()
        Me.lblPrimoFile = New System.Windows.Forms.Label()
        Me.lblSecondoFile = New System.Windows.Forms.Label()
        Me.lblSecondoDir = New System.Windows.Forms.Label()
        Me.lblPrimoDime = New System.Windows.Forms.Label()
        Me.lblSecondoDime = New System.Windows.Forms.Label()
        Me.cmdIndietro = New System.Windows.Forms.Button()
        Me.cmdAvanti = New System.Windows.Forms.Button()
        Me.cmdElimina1 = New System.Windows.Forms.Button()
        Me.cmdElimina2 = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblStato = New System.Windows.Forms.Label()
        Me.lblContatore = New System.Windows.Forms.Label()
        Me.cmdUscita = New System.Windows.Forms.Button()
        Me.cmdAggiorna = New System.Windows.Forms.Button()
        Me.cmdAnnullaStato = New System.Windows.Forms.Button()
        Me.cmdEliminaRicorrenza2 = New System.Windows.Forms.Button()
        Me.cmdEliminaRicorrenza1 = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'lblPrimoDir
        '
        Me.lblPrimoDir.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPrimoDir.Location = New System.Drawing.Point(12, 60)
        Me.lblPrimoDir.Name = "lblPrimoDir"
        Me.lblPrimoDir.Size = New System.Drawing.Size(414, 17)
        Me.lblPrimoDir.TabIndex = 0
        Me.lblPrimoDir.Text = "Label1"
        '
        'lblPrimoFile
        '
        Me.lblPrimoFile.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPrimoFile.Location = New System.Drawing.Point(12, 75)
        Me.lblPrimoFile.Name = "lblPrimoFile"
        Me.lblPrimoFile.Size = New System.Drawing.Size(414, 17)
        Me.lblPrimoFile.TabIndex = 1
        Me.lblPrimoFile.Text = "Label1"
        '
        'lblSecondoFile
        '
        Me.lblSecondoFile.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSecondoFile.Location = New System.Drawing.Point(12, 159)
        Me.lblSecondoFile.Name = "lblSecondoFile"
        Me.lblSecondoFile.Size = New System.Drawing.Size(413, 17)
        Me.lblSecondoFile.TabIndex = 3
        Me.lblSecondoFile.Text = "Label2"
        '
        'lblSecondoDir
        '
        Me.lblSecondoDir.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSecondoDir.Location = New System.Drawing.Point(12, 142)
        Me.lblSecondoDir.Name = "lblSecondoDir"
        Me.lblSecondoDir.Size = New System.Drawing.Size(413, 17)
        Me.lblSecondoDir.TabIndex = 2
        Me.lblSecondoDir.Text = "Label1"
        '
        'lblPrimoDime
        '
        Me.lblPrimoDime.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPrimoDime.Location = New System.Drawing.Point(13, 92)
        Me.lblPrimoDime.Name = "lblPrimoDime"
        Me.lblPrimoDime.Size = New System.Drawing.Size(320, 17)
        Me.lblPrimoDime.TabIndex = 4
        Me.lblPrimoDime.Text = "Label1"
        '
        'lblSecondoDime
        '
        Me.lblSecondoDime.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSecondoDime.Location = New System.Drawing.Point(13, 176)
        Me.lblSecondoDime.Name = "lblSecondoDime"
        Me.lblSecondoDime.Size = New System.Drawing.Size(320, 17)
        Me.lblSecondoDime.TabIndex = 5
        Me.lblSecondoDime.Text = "Label1"
        '
        'cmdIndietro
        '
        Me.cmdIndietro.Location = New System.Drawing.Point(13, 217)
        Me.cmdIndietro.Name = "cmdIndietro"
        Me.cmdIndietro.Size = New System.Drawing.Size(37, 23)
        Me.cmdIndietro.TabIndex = 6
        Me.cmdIndietro.Text = "<<"
        Me.cmdIndietro.UseVisualStyleBackColor = True
        '
        'cmdAvanti
        '
        Me.cmdAvanti.Location = New System.Drawing.Point(387, 217)
        Me.cmdAvanti.Name = "cmdAvanti"
        Me.cmdAvanti.Size = New System.Drawing.Size(37, 23)
        Me.cmdAvanti.TabIndex = 7
        Me.cmdAvanti.Text = ">>"
        Me.cmdAvanti.UseVisualStyleBackColor = True
        '
        'cmdElimina1
        '
        Me.cmdElimina1.Location = New System.Drawing.Point(56, 217)
        Me.cmdElimina1.Name = "cmdElimina1"
        Me.cmdElimina1.Size = New System.Drawing.Size(77, 23)
        Me.cmdElimina1.TabIndex = 8
        Me.cmdElimina1.Text = "Elimina 1"
        Me.cmdElimina1.UseVisualStyleBackColor = True
        '
        'cmdElimina2
        '
        Me.cmdElimina2.Location = New System.Drawing.Point(304, 217)
        Me.cmdElimina2.Name = "cmdElimina2"
        Me.cmdElimina2.Size = New System.Drawing.Size(77, 23)
        Me.cmdElimina2.TabIndex = 9
        Me.cmdElimina2.Text = "Elimina 2"
        Me.cmdElimina2.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(10, 37)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(414, 17)
        Me.Label1.TabIndex = 10
        Me.Label1.Text = "1"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(56, 115)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(368, 17)
        Me.Label2.TabIndex = 11
        Me.Label2.Text = "2"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblStato
        '
        Me.lblStato.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStato.ForeColor = System.Drawing.Color.Red
        Me.lblStato.Location = New System.Drawing.Point(13, 193)
        Me.lblStato.Name = "lblStato"
        Me.lblStato.Size = New System.Drawing.Size(411, 21)
        Me.lblStato.TabIndex = 12
        Me.lblStato.Text = "2"
        Me.lblStato.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblContatore
        '
        Me.lblContatore.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblContatore.ForeColor = System.Drawing.Color.Blue
        Me.lblContatore.Location = New System.Drawing.Point(10, 9)
        Me.lblContatore.Name = "lblContatore"
        Me.lblContatore.Size = New System.Drawing.Size(277, 19)
        Me.lblContatore.TabIndex = 13
        Me.lblContatore.Text = "1"
        Me.lblContatore.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cmdUscita
        '
        Me.cmdUscita.BackColor = System.Drawing.Color.Red
        Me.cmdUscita.Font = New System.Drawing.Font("Consolas", 9.75!, System.Drawing.FontStyle.Bold)
        Me.cmdUscita.ForeColor = System.Drawing.Color.White
        Me.cmdUscita.Location = New System.Drawing.Point(402, 5)
        Me.cmdUscita.Name = "cmdUscita"
        Me.cmdUscita.Size = New System.Drawing.Size(22, 23)
        Me.cmdUscita.TabIndex = 14
        Me.cmdUscita.Text = "X"
        Me.cmdUscita.UseVisualStyleBackColor = False
        '
        'cmdAggiorna
        '
        Me.cmdAggiorna.Location = New System.Drawing.Point(312, 5)
        Me.cmdAggiorna.Name = "cmdAggiorna"
        Me.cmdAggiorna.Size = New System.Drawing.Size(84, 23)
        Me.cmdAggiorna.TabIndex = 15
        Me.cmdAggiorna.Text = "Aggiorna"
        Me.cmdAggiorna.UseVisualStyleBackColor = True
        '
        'cmdAnnullaStato
        '
        Me.cmdAnnullaStato.Location = New System.Drawing.Point(172, 217)
        Me.cmdAnnullaStato.Name = "cmdAnnullaStato"
        Me.cmdAnnullaStato.Size = New System.Drawing.Size(99, 23)
        Me.cmdAnnullaStato.TabIndex = 16
        Me.cmdAnnullaStato.Text = "Annulla Stato"
        Me.cmdAnnullaStato.UseVisualStyleBackColor = True
        '
        'cmdEliminaRicorrenza2
        '
        Me.cmdEliminaRicorrenza2.Location = New System.Drawing.Point(14, 112)
        Me.cmdEliminaRicorrenza2.Name = "cmdEliminaRicorrenza2"
        Me.cmdEliminaRicorrenza2.Size = New System.Drawing.Size(37, 23)
        Me.cmdEliminaRicorrenza2.TabIndex = 17
        Me.cmdEliminaRicorrenza2.Text = "D"
        Me.cmdEliminaRicorrenza2.UseVisualStyleBackColor = True
        '
        'cmdEliminaRicorrenza1
        '
        Me.cmdEliminaRicorrenza1.Location = New System.Drawing.Point(13, 34)
        Me.cmdEliminaRicorrenza1.Name = "cmdEliminaRicorrenza1"
        Me.cmdEliminaRicorrenza1.Size = New System.Drawing.Size(37, 23)
        Me.cmdEliminaRicorrenza1.TabIndex = 18
        Me.cmdEliminaRicorrenza1.Text = "D"
        Me.cmdEliminaRicorrenza1.UseVisualStyleBackColor = True
        '
        'frmUguali
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(436, 254)
        Me.ControlBox = False
        Me.Controls.Add(Me.cmdEliminaRicorrenza1)
        Me.Controls.Add(Me.cmdEliminaRicorrenza2)
        Me.Controls.Add(Me.cmdAnnullaStato)
        Me.Controls.Add(Me.cmdAggiorna)
        Me.Controls.Add(Me.cmdUscita)
        Me.Controls.Add(Me.lblContatore)
        Me.Controls.Add(Me.lblStato)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cmdElimina2)
        Me.Controls.Add(Me.cmdElimina1)
        Me.Controls.Add(Me.cmdAvanti)
        Me.Controls.Add(Me.cmdIndietro)
        Me.Controls.Add(Me.lblSecondoDime)
        Me.Controls.Add(Me.lblPrimoDime)
        Me.Controls.Add(Me.lblSecondoFile)
        Me.Controls.Add(Me.lblSecondoDir)
        Me.Controls.Add(Me.lblPrimoFile)
        Me.Controls.Add(Me.lblPrimoDir)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frmUguali"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Uguali"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lblPrimoDir As System.Windows.Forms.Label
    Friend WithEvents lblPrimoFile As System.Windows.Forms.Label
    Friend WithEvents lblSecondoFile As System.Windows.Forms.Label
    Friend WithEvents lblSecondoDir As System.Windows.Forms.Label
    Friend WithEvents lblPrimoDime As System.Windows.Forms.Label
    Friend WithEvents lblSecondoDime As System.Windows.Forms.Label
    Friend WithEvents cmdIndietro As System.Windows.Forms.Button
    Friend WithEvents cmdAvanti As System.Windows.Forms.Button
    Friend WithEvents cmdElimina1 As System.Windows.Forms.Button
    Friend WithEvents cmdElimina2 As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblStato As System.Windows.Forms.Label
    Friend WithEvents lblContatore As System.Windows.Forms.Label
    Friend WithEvents cmdUscita As System.Windows.Forms.Button
    Friend WithEvents cmdAggiorna As System.Windows.Forms.Button
    Friend WithEvents cmdAnnullaStato As System.Windows.Forms.Button
    Friend WithEvents cmdEliminaRicorrenza2 As System.Windows.Forms.Button
    Friend WithEvents cmdEliminaRicorrenza1 As System.Windows.Forms.Button
End Class
