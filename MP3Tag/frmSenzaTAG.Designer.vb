<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSenzaTAG
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
        Me.lblDirFile = New System.Windows.Forms.Label()
        Me.lblNomeFile = New System.Windows.Forms.Label()
        Me.lblContatore = New System.Windows.Forms.Label()
        Me.cmdAvanti = New System.Windows.Forms.Button()
        Me.cmdIndietro = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtAlbum = New System.Windows.Forms.TextBox()
        Me.txtArtista = New System.Windows.Forms.TextBox()
        Me.txtAnno = New System.Windows.Forms.TextBox()
        Me.txtTraccia = New System.Windows.Forms.TextBox()
        Me.cmdImposta = New System.Windows.Forms.Button()
        Me.cmdUscita = New System.Windows.Forms.Button()
        Me.txtTitolo = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cmdPlay = New System.Windows.Forms.Button()
        Me.cmdElimina = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'lblDirFile
        '
        Me.lblDirFile.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDirFile.Location = New System.Drawing.Point(12, 38)
        Me.lblDirFile.Name = "lblDirFile"
        Me.lblDirFile.Size = New System.Drawing.Size(383, 20)
        Me.lblDirFile.TabIndex = 5
        Me.lblDirFile.Text = "Destinazione"
        Me.lblDirFile.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblNomeFile
        '
        Me.lblNomeFile.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNomeFile.Location = New System.Drawing.Point(12, 58)
        Me.lblNomeFile.Name = "lblNomeFile"
        Me.lblNomeFile.Size = New System.Drawing.Size(383, 20)
        Me.lblNomeFile.TabIndex = 6
        Me.lblNomeFile.Text = "Destinazione"
        Me.lblNomeFile.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblContatore
        '
        Me.lblContatore.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblContatore.ForeColor = System.Drawing.Color.Blue
        Me.lblContatore.Location = New System.Drawing.Point(12, 9)
        Me.lblContatore.Name = "lblContatore"
        Me.lblContatore.Size = New System.Drawing.Size(345, 20)
        Me.lblContatore.TabIndex = 7
        Me.lblContatore.Text = "Destinazione"
        Me.lblContatore.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cmdAvanti
        '
        Me.cmdAvanti.Location = New System.Drawing.Point(359, 218)
        Me.cmdAvanti.Name = "cmdAvanti"
        Me.cmdAvanti.Size = New System.Drawing.Size(37, 23)
        Me.cmdAvanti.TabIndex = 9
        Me.cmdAvanti.Text = ">>"
        Me.cmdAvanti.UseVisualStyleBackColor = True
        '
        'cmdIndietro
        '
        Me.cmdIndietro.Location = New System.Drawing.Point(13, 218)
        Me.cmdIndietro.Name = "cmdIndietro"
        Me.cmdIndietro.Size = New System.Drawing.Size(37, 23)
        Me.cmdIndietro.TabIndex = 8
        Me.cmdIndietro.Text = "<<"
        Me.cmdIndietro.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(13, 110)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(47, 16)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "Album"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 82)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(48, 16)
        Me.Label1.TabIndex = 11
        Me.Label1.Text = "Artista"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(14, 162)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(41, 16)
        Me.Label3.TabIndex = 12
        Me.Label3.Text = "Anno"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(13, 187)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(54, 16)
        Me.Label4.TabIndex = 13
        Me.Label4.Text = "Traccia"
        '
        'txtAlbum
        '
        Me.txtAlbum.Location = New System.Drawing.Point(101, 106)
        Me.txtAlbum.MaxLength = 50
        Me.txtAlbum.Name = "txtAlbum"
        Me.txtAlbum.Size = New System.Drawing.Size(295, 20)
        Me.txtAlbum.TabIndex = 3
        '
        'txtArtista
        '
        Me.txtArtista.Location = New System.Drawing.Point(100, 81)
        Me.txtArtista.MaxLength = 50
        Me.txtArtista.Name = "txtArtista"
        Me.txtArtista.Size = New System.Drawing.Size(295, 20)
        Me.txtArtista.TabIndex = 2
        '
        'txtAnno
        '
        Me.txtAnno.Location = New System.Drawing.Point(101, 158)
        Me.txtAnno.MaxLength = 4
        Me.txtAnno.Name = "txtAnno"
        Me.txtAnno.Size = New System.Drawing.Size(295, 20)
        Me.txtAnno.TabIndex = 5
        '
        'txtTraccia
        '
        Me.txtTraccia.Location = New System.Drawing.Point(101, 183)
        Me.txtTraccia.MaxLength = 2
        Me.txtTraccia.Name = "txtTraccia"
        Me.txtTraccia.Size = New System.Drawing.Size(295, 20)
        Me.txtTraccia.TabIndex = 6
        '
        'cmdImposta
        '
        Me.cmdImposta.Location = New System.Drawing.Point(255, 218)
        Me.cmdImposta.Name = "cmdImposta"
        Me.cmdImposta.Size = New System.Drawing.Size(98, 23)
        Me.cmdImposta.TabIndex = 18
        Me.cmdImposta.Text = "Imposta"
        Me.cmdImposta.UseVisualStyleBackColor = True
        '
        'cmdUscita
        '
        Me.cmdUscita.BackColor = System.Drawing.Color.Red
        Me.cmdUscita.Font = New System.Drawing.Font("Consolas", 9.75!, System.Drawing.FontStyle.Bold)
        Me.cmdUscita.ForeColor = System.Drawing.Color.White
        Me.cmdUscita.Location = New System.Drawing.Point(376, 6)
        Me.cmdUscita.Name = "cmdUscita"
        Me.cmdUscita.Size = New System.Drawing.Size(24, 23)
        Me.cmdUscita.TabIndex = 19
        Me.cmdUscita.Text = "X"
        Me.cmdUscita.UseVisualStyleBackColor = False
        '
        'txtTitolo
        '
        Me.txtTitolo.Location = New System.Drawing.Point(101, 132)
        Me.txtTitolo.MaxLength = 50
        Me.txtTitolo.Name = "txtTitolo"
        Me.txtTitolo.Size = New System.Drawing.Size(295, 20)
        Me.txtTitolo.TabIndex = 4
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(13, 136)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(42, 16)
        Me.Label5.TabIndex = 20
        Me.Label5.Text = "Titolo"
        '
        'cmdPlay
        '
        Me.cmdPlay.Location = New System.Drawing.Point(12, 9)
        Me.cmdPlay.Name = "cmdPlay"
        Me.cmdPlay.Size = New System.Drawing.Size(37, 23)
        Me.cmdPlay.TabIndex = 22
        Me.cmdPlay.Text = "P"
        Me.cmdPlay.UseVisualStyleBackColor = True
        '
        'cmdElimina
        '
        Me.cmdElimina.Location = New System.Drawing.Point(56, 218)
        Me.cmdElimina.Name = "cmdElimina"
        Me.cmdElimina.Size = New System.Drawing.Size(98, 23)
        Me.cmdElimina.TabIndex = 23
        Me.cmdElimina.Text = "Elimina"
        Me.cmdElimina.UseVisualStyleBackColor = True
        '
        'frmSenzaTAG
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(407, 250)
        Me.ControlBox = False
        Me.Controls.Add(Me.cmdElimina)
        Me.Controls.Add(Me.cmdPlay)
        Me.Controls.Add(Me.txtTitolo)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.cmdUscita)
        Me.Controls.Add(Me.cmdImposta)
        Me.Controls.Add(Me.txtTraccia)
        Me.Controls.Add(Me.txtAnno)
        Me.Controls.Add(Me.txtArtista)
        Me.Controls.Add(Me.txtAlbum)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cmdAvanti)
        Me.Controls.Add(Me.cmdIndietro)
        Me.Controls.Add(Me.lblContatore)
        Me.Controls.Add(Me.lblNomeFile)
        Me.Controls.Add(Me.lblDirFile)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frmSenzaTAG"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "MP3 Senza TAG"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblDirFile As System.Windows.Forms.Label
    Friend WithEvents lblNomeFile As System.Windows.Forms.Label
    Friend WithEvents lblContatore As System.Windows.Forms.Label
    Friend WithEvents cmdAvanti As System.Windows.Forms.Button
    Friend WithEvents cmdIndietro As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtAlbum As System.Windows.Forms.TextBox
    Friend WithEvents txtArtista As System.Windows.Forms.TextBox
    Friend WithEvents txtAnno As System.Windows.Forms.TextBox
    Friend WithEvents txtTraccia As System.Windows.Forms.TextBox
    Friend WithEvents cmdImposta As System.Windows.Forms.Button
    Friend WithEvents cmdUscita As System.Windows.Forms.Button
    Friend WithEvents txtTitolo As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cmdPlay As System.Windows.Forms.Button
    Friend WithEvents cmdElimina As System.Windows.Forms.Button
End Class
