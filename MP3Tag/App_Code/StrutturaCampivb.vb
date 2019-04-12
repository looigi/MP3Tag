Public Class StrutturaCampivb
    Private _chkRandom As CheckBox
    Private _chkUltime As CheckBox
    Private _chkPrime As CheckBox
    Private _chkBellezza As CheckBox
    Private _chkSuperiori As CheckBox
    Private _chkFiltroTesto As CheckBox
    Private _chkFiltroNome As CheckBox
    Private _chkRicercaSuTesto As CheckBox
    Private _chkRicordaAscoltate As CheckBox
    Private _txtFiltroTesto As TextBox
    Private _cmbBellezza As ComboBox
    Private _lblAggiornamentoCanzoni As Label
    Private _lblTempoPassato As Label
    Private _lblTempoTotale As Label
    Private _lblTempoPassatoInterno As Label
    Private _lblTempoTotaleInterno As Label
    Private _lblNomeCanzone As Label
    Private _lblTesti As Label
    Private _picMP3 As PictureBox
    Private _BarraAvanzamento As TrackBar
    Private _BarraAvanzamentoInterna As TrackBar
    Private _Canzoni() As String
    Private _qCanzoni As Integer
    Private _PathMP3 As String
    Private _FiltroRicerca As String
    Private _QualeCanzoneStaSuonando As Integer
    Private _lstArtista As ListBox
    Private _lstAlbum As ListBox
    Private _lstCanzone As ListBox
    Private _PicNonCercareVideo As PictureBox
    Private _VideoLockati As Boolean
    Private _pnlImmagine As Panel
    Private _pnlImmagineArtista As DoubleBufferedPanels
    Private _pnlBarra As Panel
    Private _pnlMediaPlayer As Panel
    Private _NomeVideo As String

    Private _AxWindowsMediaPlayer1 As AxWMPLib.AxWindowsMediaPlayer

    Public Sub New()
    End Sub

    Property NomeVideo As String
        Get
            Return _NomeVideo
        End Get
        Set(ByVal value As String)
            _NomeVideo = value
        End Set
    End Property

    Property AxWindowsMediaPlayer1 As AxWMPLib.AxWindowsMediaPlayer
        Get
            Return _AxWindowsMediaPlayer1
        End Get
        Set(ByVal value As AxWMPLib.AxWindowsMediaPlayer)
            _AxWindowsMediaPlayer1 = value
        End Set
    End Property

    Property pnlMediaPlayer As Panel
        Get
            Return _pnlMediaPlayer
        End Get
        Set(ByVal value As Panel)
            _pnlMediaPlayer = value
        End Set
    End Property

    Property pnlBarra As Panel
        Get
            Return _pnlBarra
        End Get
        Set(ByVal value As Panel)
            _pnlBarra = value
        End Set
    End Property

    Property pnlImmagineArtista As DoubleBufferedPanels
        Get
            Return _pnlImmagineArtista
        End Get
        Set(ByVal value As DoubleBufferedPanels)
            _pnlImmagineArtista = value
        End Set
    End Property

    Property pnlImmagine As Panel
        Get
            Return _pnlImmagine
        End Get
        Set(ByVal value As Panel)
            _pnlImmagine = value
        End Set
    End Property

    Property PicNonCercareVideo As PictureBox
        Get
            Return _PicNonCercareVideo
        End Get
        Set(ByVal value As PictureBox)
            _PicNonCercareVideo = value
        End Set
    End Property

    Property VideoLockati As Boolean
        Get
            Return _VideoLockati
        End Get
        Set(ByVal value As Boolean)
            _VideoLockati = value
        End Set
    End Property

    'Property StaSuonando As Boolean
    '    Get
    '        Return _StaSuonando
    '    End Get
    '    Set(ByVal value As Boolean)
    '        _StaSuonando = value
    '    End Set
    'End Property

    Property lstArtista As ListBox
        Get
            Return _lstArtista
        End Get
        Set(ByVal value As ListBox)
            _lstArtista = value
        End Set
    End Property

    Property lstAlbum As ListBox
        Get
            Return _lstAlbum
        End Get
        Set(ByVal value As ListBox)
            _lstAlbum = value
        End Set
    End Property

    Property lstCanzone As ListBox
        Get
            Return _lstCanzone
        End Get
        Set(ByVal value As ListBox)
            _lstCanzone = value
        End Set
    End Property

    Property FiltroRicerca As String
        Get
            Return _FiltroRicerca
        End Get
        Set(ByVal value As String)
            _FiltroRicerca = value
        End Set
    End Property

    Property PathMP3 As String
        Get
            Return _PathMP3
        End Get
        Set(ByVal value As String)
            _PathMP3 = value
        End Set
    End Property

    Property Canzoni As String()
        Get
            Return _Canzoni
        End Get
        Set(ByVal value As String())
            _Canzoni = value
        End Set
    End Property

    Property QualeCanzoneStaSuonando As Integer
        Get
            Return _QualeCanzoneStaSuonando
        End Get
        Set(ByVal value As Integer)
            _QualeCanzoneStaSuonando = value
        End Set
    End Property

    Property qCanzoni As Integer
        Get
            Return _qCanzoni
        End Get
        Set(ByVal value As Integer)
            _qCanzoni = value
        End Set
    End Property

    Property chkRandom As CheckBox
        Get
            Return _chkRandom
        End Get
        Set(ByVal value As CheckBox)
            _chkRandom = value
        End Set
    End Property

    Property chkUltime As CheckBox
        Get
            Return _chkUltime
        End Get
        Set(ByVal value As CheckBox)
            _chkUltime = value
        End Set
    End Property

    Property chkPrime As CheckBox
        Get
            Return _chkPrime
        End Get
        Set(ByVal value As CheckBox)
            _chkPrime = value
        End Set
    End Property

    Property chkBellezza As CheckBox
        Get
            Return _chkBellezza
        End Get
        Set(ByVal value As CheckBox)
            _chkBellezza = value
        End Set
    End Property

    Property chkSuperiori As CheckBox
        Get
            Return _chkSuperiori
        End Get
        Set(ByVal value As CheckBox)
            _chkSuperiori = value
        End Set
    End Property

    Property chkFiltroTesto As CheckBox
        Get
            Return _chkFiltroTesto
        End Get
        Set(ByVal value As CheckBox)
            _chkFiltroTesto = value
        End Set
    End Property

    Property chkFiltroNome As CheckBox
        Get
            Return _chkFiltroNome
        End Get
        Set(ByVal value As CheckBox)
            _chkFiltroNome = value
        End Set
    End Property

    Property chkRicercaSuTesto As CheckBox
        Get
            Return _chkRicercaSuTesto
        End Get
        Set(ByVal value As CheckBox)
            _chkRicercaSuTesto = value
        End Set
    End Property

    Property chkRicordaAscoltate As CheckBox
        Get
            Return _chkRicordaAscoltate
        End Get
        Set(ByVal value As CheckBox)
            _chkRicordaAscoltate = value
        End Set
    End Property

    Property txtFiltroTesto As TextBox
        Get
            Return _txtFiltroTesto
        End Get
        Set(ByVal value As TextBox)
            _txtFiltroTesto = value
        End Set
    End Property

    Property cmbBellezza As ComboBox
        Get
            Return _cmbBellezza
        End Get
        Set(ByVal value As ComboBox)
            _cmbBellezza = value
        End Set
    End Property

    Property lblTesti As Label
        Get
            Return _lblTesti
        End Get
        Set(ByVal value As Label)
            _lblTesti = value
        End Set
    End Property

    Property lblAggiornamentoCanzoni As Label
        Get
            Return _lblAggiornamentoCanzoni
        End Get
        Set(ByVal value As Label)
            _lblAggiornamentoCanzoni = value
        End Set
    End Property

    Property lblTempoPassato As Label
        Get
            Return _lblTempoPassato
        End Get
        Set(ByVal value As Label)
            _lblTempoPassato = value
        End Set
    End Property

    Property lblTempoTotale As Label
        Get
            Return _lblTempoTotale
        End Get
        Set(ByVal value As Label)
            _lblTempoTotale = value
        End Set
    End Property

    Property lblTempoPassatoInterno As Label
        Get
            Return _lblTempoPassatoInterno
        End Get
        Set(ByVal value As Label)
            _lblTempoPassatoInterno = value
        End Set
    End Property

    Property lblTempoTotaleInterno As Label
        Get
            Return _lblTempoTotaleInterno
        End Get
        Set(ByVal value As Label)
            _lblTempoTotaleInterno = value
        End Set
    End Property

    Property lblNomeCanzone As Label
        Get
            Return _lblNomeCanzone
        End Get
        Set(ByVal value As Label)
            _lblNomeCanzone = value
        End Set
    End Property

    Property PicMP3 As PictureBox
        Get
            Return _picMP3
        End Get
        Set(ByVal value As PictureBox)
            _picMP3 = value
        End Set
    End Property

    Property BarraAvanzamento As TrackBar
        Get
            Return _BarraAvanzamento
        End Get
        Set(ByVal value As TrackBar)
            _BarraAvanzamento = value
        End Set
    End Property

    Property BarraAvanzamentoInterna As TrackBar
        Get
            Return _BarraAvanzamentoInterna
        End Get
        Set(ByVal value As TrackBar)
            _BarraAvanzamentoInterna = value
        End Set
    End Property
End Class
