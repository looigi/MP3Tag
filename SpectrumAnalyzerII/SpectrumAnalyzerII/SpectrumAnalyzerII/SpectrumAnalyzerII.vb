Imports NAudio.CoreAudioApi
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks
Imports System.Windows.Forms
Imports System.Drawing
Imports System.Drawing.Drawing2D

'Imports System.Windows.Threading
Imports Un4seen.Bass
Imports Un4seen.BassWasapi

Public Class FormAudioSpectrum
    Private Handle As IntPtr
    Private WithEvents Pannello As Panel
    Private Const LunghezzaSpectrum As Integer = 20
    Private Valori(LunghezzaSpectrum) As Integer
    Private QualeValore As Integer = 0
    Private device As MMDevice = Nothing

    Private WithEvents timerSpectrum As Timer = New Timer()

    Public Sub FermaTimer()
        Try
            Passo = CInt(Pannello.Width / LunghezzaSpectrum) + 1
            For Me.CicloI = 0 To LunghezzaSpectrum
                Pen.FillRectangle(myBrush, CicloI * Passo, 0, Passo, Pannello.Height)
            Next
        Catch ex As Exception

        End Try

        timerSpectrum.Enabled = False
    End Sub

    Public Sub FaiPartireTimer()
        timerSpectrum.Enabled = True
    End Sub

    Public Sub Inizializza(pnl As Panel, h As IntPtr)
        timerSpectrum.Interval = 25

        Handle = h

        Pannello = pnl
        Pannello.BackColor = Color.Transparent
        Pen = Pannello.CreateGraphics()
        Pen.SmoothingMode = SmoothingMode.AntiAlias

        Inizalizza()

        Try
            If device IsNot Nothing Then
                FaiPartireTimer()
            End If

            'Taskbar.SetState(Handle, Taskbar.TaskbarStates.NoProgress)
        Catch e As System.IO.IOException
        End Try
    End Sub

    ' ********************************************************************
    'Private _timer As DispatcherTimer
    Private _fft As Single()
    Private _process As WASAPIPROC
    Private _lastlevel As Integer
    Private _hanctr As Integer
    Private _spectrumdata As List(Of Byte) = Nothing
    Private _lines As Integer = LunghezzaSpectrum

    Public Sub Inizalizza()
        Try
            ' Don't remove this line.
            ' Validating the activation key.
            BassNet.Registration("buddyknox@usa.org", "2X11841782815")

            _fft = New Single(8191) {}

            _lastlevel = 0
            _hanctr = 0

            _process = New WASAPIPROC(AddressOf Process)
            _spectrumdata = New List(Of Byte)()

            Try
                Bass.BASS_SetConfig(BASSConfig.BASS_CONFIG_UPDATETHREADS, False)
                Bass.BASS_Init(0, 44100, BASSInit.BASS_DEVICE_DEFAULT, IntPtr.Zero)
            Catch e As Exception
            End Try

            Me.Enable = True
        Catch ex As Exception

        End Try
    End Sub

    Private Property Enable() As Boolean
        Get
            Try
                Return True
            Catch ex As Exception
                Return False
            End Try
        End Get
        Set(value As Boolean)
            Try
                If value Then
                    Try
                        BassWasapi.BASS_WASAPI_Init(1, 0, 0, BASSWASAPIInit.BASS_WASAPI_BUFFER, 1.0F, 0.05F, _
                            _process, IntPtr.Zero)
                        BassWasapi.BASS_WASAPI_Start()
                        System.Threading.Thread.Sleep(500)
                        '_timer.IsEnabled = True
                    Catch e As Exception
                    End Try
                End If
            Catch ex As Exception

            End Try
        End Set
    End Property

    Private Function Process(buffer As IntPtr, length As Integer, user As IntPtr) As Integer
        Try
            Return length
        Catch ex As Exception
            Return 0
        End Try
    End Function

    Public Sub Free()
        Try
            BassWasapi.BASS_WASAPI_Free()
            Bass.BASS_Free()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub LeggeSpectrum()
        Try
            Array.Clear(_fft, 0, _fft.Length)

            Dim ret As Integer = BassWasapi.BASS_WASAPI_GetData(_fft, CInt(BASSData.BASS_DATA_FFT16384))
            If ret < -1 Then
                Return
            End If
            Dim x As Integer, y As Integer
            Dim b0 As Integer = 0

            For x = 0 To _lines - 1
                Dim peak As Single = 0
                Dim b1 As Integer = CInt(Math.Pow(2, x * 10.0 / (_lines - 1)))
                If b1 > 8191 Then
                    b1 = 8191
                End If
                If b1 <= b0 Then
                    b1 = b0 + 1
                End If

                While b0 < b1
                    If peak < _fft(1 + b0) Then
                        peak = _fft(1 + b0)
                    End If
                    b0 += 1
                End While

                y = CInt(Math.Sqrt(peak) * 3 * 255 - 4)
                If y > 255 Then
                    y = 255
                End If
                If y < 0 Then
                    y = 0
                End If

                _spectrumdata.Add(CByte(y))
            Next

            ' Disegna barre
            Passo = CInt(Pannello.Width / LunghezzaSpectrum) + 1
            For Me.CicloI = 0 To _spectrumdata.Count - 1
                Valore = Pannello.Height * _spectrumdata(CicloI) / 105
                Pen.FillRectangle(myBrush, CicloI * Passo, 0, Passo, Pannello.Height)
                Pen.FillRectangle(myBrushG, CicloI * Passo, Pannello.Height - Valore, Passo, Valore)
            Next
            ' Disegna barre

            Dim level As Integer = BassWasapi.BASS_WASAPI_GetLevel()
            If level = _lastlevel AndAlso level <> 0 Then
                _hanctr += 1
            End If

            _lastlevel = level

            If _hanctr > 3 Then
                _hanctr = 0
                Free()
                Bass.BASS_Init(0, 44100, BASSInit.BASS_DEVICE_DEFAULT, IntPtr.Zero)
                Me.Enable = True
            End If

            _spectrumdata.Clear()
        Catch ex As Exception
            FermaTimer()
        End Try
    End Sub
    ' ********************************************************************

    Public Sub ImpostaDevice(Scheda As [String])
        Dim enumerator As New MMDeviceEnumerator()
        Dim devices As MMDeviceCollection = enumerator.EnumerateAudioEndPoints(DataFlow.All, DeviceState.Active)

        device = (From d In devices Where d.FriendlyName.Contains(Scheda)).FirstOrDefault()
    End Sub

    Public Function RitornaDevices() As [String]
        Dim enumerator As New MMDeviceEnumerator()
        Dim devices As MMDeviceCollection = enumerator.EnumerateAudioEndPoints(DataFlow.All, DeviceState.Active)

        Dim Ritorno As [String] = ""

        For i As Integer = 0 To devices.Count - 1
            Ritorno += devices(i).FriendlyName + ";"
        Next

        Return Ritorno
    End Function

    'Dim ch As AudioMeterInformationChannels
    Dim Valore As Integer
    Dim CicloI As Integer = 0

    Private Sub timerSpectrum_Tick(sender As Object, e As EventArgs) Handles timerSpectrum.Tick
        If device IsNot Nothing And Pannello IsNot Nothing Then
            'ch = device.AudioMeterInformation.PeakValues
            'Valore = CInt(Math.Round(device.AudioMeterInformation.MasterPeakValue * 100))

            LeggeSpectrum()

            ''Taskbar.SetValue(Handle, Valore, 100)
            ''Taskbar.SetState(Handle, Taskbar.TaskbarStates.[Error])

            ''QualeValore += 1
            ''If QualeValore > LunghezzaSpectrum - 1 Then
            ''    QualeValore = 0
            ''End If
            ''Valori(QualeValore) = Pannello.Height - CInt(Pannello.Height * (Valore - 1) / 100)
            'Passo = CInt(Pannello.Width / LunghezzaSpectrum) + 1

            'Randomize()
            'x = Int(Rnd(1) * LunghezzaSpectrum)
            'x *= Passo
            'Try
            '    Pen.FillRectangle(myBrush, x, 0, Passo, Pannello.Height)
            '    'Pen.FillRectangle(myBrushT, x, 0, Passo, Pannello.Height)
            '    Valore = Pannello.Height * Valore / 102
            '    Pen.FillRectangle(myBrushG, x, Pannello.Height - Valore, Passo, Valore)
            'Catch ex As Exception

            'End Try
        End If
    End Sub

    Public Sub CreaBarre(pnl As Panel)

    End Sub

    Dim myBrush As New System.Drawing.SolidBrush(System.Drawing.Color.Black)
    'Dim myBrushT As New System.Drawing.SolidBrush(System.Drawing.Color.Transparent)
    Dim myBrushG As New System.Drawing.SolidBrush(System.Drawing.Color.Green)

    Dim greenPen As New Pen(Color.Green, 2)
    Dim blackPen As New Pen(Color.Black, 2)
    Dim x As Integer = 0
    Dim Point1 As Point
    Dim Point2 As Point
    Dim Passo As Integer = 0
    Dim Pen As System.Drawing.Graphics

    'Private Sub Pannello_Paint(sender As Object, e As PaintEventArgs) Handles Pannello.Paint
    '    'x = 0
    '    'For i As Integer = 0 To LunghezzaSpectrum ' - 1
    '    '    e.Graphics.SmoothingMode = SmoothingMode.HighQuality
    '    '    e.Graphics.DrawLine(blackPen, x, Valori(i), x + Passo, Pannello.Height)
    '    '    x += Passo
    '    'Next
    'End Sub
End Class

