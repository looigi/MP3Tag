Imports System.Runtime.InteropServices

Public NotInheritable Class Taskbar
    Private Sub New()
    End Sub
    Public Enum TaskbarStates
        NoProgress = 0
        Indeterminate = &H1
        Normal = &H2
        [Error] = &H4
        Paused = &H8
    End Enum

    <ComImportAttribute> _
    <GuidAttribute("ea1afb91-9e28-4b86-90e9-9e9f8a5eefaf")> _
    <InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIUnknown)> _
    Private Interface ITaskbarList3
        <PreserveSig> _
        Sub HrInit()
        <PreserveSig> _
        Sub AddTab(hwnd As IntPtr)
        <PreserveSig> _
        Sub DeleteTab(hwnd As IntPtr)
        <PreserveSig> _
        Sub ActivateTab(hwnd As IntPtr)
        <PreserveSig> _
        Sub SetActiveAlt(hwnd As IntPtr)

        <PreserveSig> _
        Sub MarkFullscreenWindow(hwnd As IntPtr, <MarshalAs(UnmanagedType.Bool)> fFullscreen As Boolean)

        <PreserveSig> _
        Sub SetProgressValue(hwnd As IntPtr, ullCompleted As UInt64, ullTotal As UInt64)
        <PreserveSig> _
        Sub SetProgressState(hwnd As IntPtr, state As TaskbarStates)
    End Interface

    <GuidAttribute("56FDF344-FD6D-11d0-958A-006097C9A090")> _
    <ClassInterfaceAttribute(ClassInterfaceType.None)> _
    <ComImportAttribute> _
    Private Class TaskbarInstance
    End Class

    Private Shared taskbarInstanceII As ITaskbarList3 = DirectCast(New TaskbarInstance(), ITaskbarList3)

    Private Shared taskbarSupported As Boolean = Environment.OSVersion.Version >= New Version(6, 1)

    Public Shared Sub SetState(windowHandle As IntPtr, taskbarState As TaskbarStates)
        If taskbarSupported Then
            taskbarInstanceII.SetProgressState(windowHandle, taskbarState)
        End If
    End Sub

    Public Shared Sub SetValue(windowHandle As IntPtr, progressValue As Double, progressMax As Double)
        If taskbarSupported Then
            taskbarInstanceII.SetProgressValue(windowHandle, CULng(progressValue), CULng(progressMax))
        End If
    End Sub
End Class
