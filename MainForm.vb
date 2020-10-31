Imports System.Threading
Imports System.Runtime
Public Class MainForm
    Dim messages As Integer = 0
    Private Declare Function GetForegroundWindow Lib "user32" Alias "GetForegroundWindow" () As IntPtr
    Private Declare Auto Function GetWindowText Lib "user32" (ByVal hWnd As System.IntPtr, ByVal lpString As System.Text.StringBuilder, ByVal cch As Integer) As Integer
    Private Declare Function GetAsyncKeyState Lib "user32" (ByVal vkey As Integer) As Short
    Private Function GetCaption() As String
        Dim Caption As New System.Text.StringBuilder(256)
        Dim hWnd As IntPtr = GetForegroundWindow()
        GetWindowText(hWnd, Caption, Caption.Capacity)
        Return Caption.ToString()
    End Function
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim mainThread As Thread = New Thread(New ThreadStart(AddressOf ClearRam))
        mainThread.Start()
        Updater.Start()
        Clipboard.SetText(Utils.RandomChineseString(320))
    End Sub
    Public Sub ClearRam()
        Thread.Sleep(1500)
        GCSettings.LargeObjectHeapCompactionMode = GCLargeObjectHeapCompactionMode.CompactOnce
        GC.Collect(GC.MaxGeneration)
        GC.WaitForPendingFinalizers()
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Button1.Enabled = False
        Button2.Enabled = True
        SpamAll.Interval = 2000
        SpamAll.Start()
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Button2.Enabled = False
        Button1.Enabled = True
        SpamAll.Stop()
        messages = 0
    End Sub
    Private Sub SpamAll_Tick(sender As Object, e As EventArgs) Handles SpamAll.Tick
        Dim exist As Boolean = False
        For Each p As Process In Process.GetProcesses()
            If p.ProcessName.ToLower().Contains("discord") Then
                If Not p.Responding Then
                    Exit Sub
                Else
                    exist = True
                    Exit For
                End If
            End If
        Next
        If Not exist Then
            Exit Sub
        End If
        If Not GetCaption().ToLower().EndsWith(" - discord") Then
            Exit Sub
        End If
        Randomize()
        Dim theMessage As String = ""
        Dim theNum As Integer = Utils.GetRandomNumber(11)
        If CheckBox1.Checked And CheckBox2.Checked Then
            If theNum <= 1 Then
                theMessage = "@everyone"
                SpamAll.Interval = Utils.GetRandomNumber(350, 550)
            ElseIf theNum = 2 Then
                theMessage = "@here"
                SpamAll.Interval = Utils.GetRandomNumber(350, 550)
            ElseIf theNum = 3 Then
                theMessage = "@everyone" + Environment.NewLine + "@here"
                For i = 0 To 30
                    theMessage += Environment.NewLine + "RAID BY WRLD - FIGLI DI PUTTANA SIAMO TORNATI!"
                Next
                SpamAll.Interval = Utils.GetRandomNumber(1150, 1300)
            ElseIf theNum = 4 Then
                theMessage = "@everyone" + Environment.NewLine + "@here"
                For i = 0 To 30
                    theMessage += Environment.NewLine + "RAID BY WRLD - FROCI SIAMO TORNATI!"
                Next
                SpamAll.Interval = Utils.GetRandomNumber(1075, 1200)
            ElseIf theNum = 5 Then
                theMessage = "@everyone @here Mein Kampf è il saggio pubblicato nel 1925 attraverso il quale Adolf Hitler espose il suo pensiero politico e delineò il programma del Partito nazionalsocialista sotto forma di un'autobiografia."
                SpamAll.Interval = Utils.GetRandomNumber(785, 850)
            ElseIf theNum = 6 Then
                theMessage = "@everyone" + vbNewLine + "@here" + vbNewLine + "FIGLI DI PUTTANA SIAMO RITORNATI" + vbNewLine + "RAID BY WRLD"
                SpamAll.Interval = Utils.GetRandomNumber(525, 705)
            ElseIf theNum = 7 Then
                theMessage = "!help"
                SpamAll.Interval = Utils.GetRandomNumber(300, 500)
            ElseIf theNum = 8 Then
                theMessage = "pls help image"
                SpamAll.Interval = Utils.GetRandomNumber(413, 601)
            ElseIf theNum = 9 Then
                theMessage = "@everyone" + vbNewLine + "@here" + vbNewLine + Utils.RandomChineseString(1750)
                SpamAll.Interval = Utils.GetRandomNumber(1275, 1350)
            ElseIf theNum >= 10 Then
                For i = 0 To 30
                    theMessage += " @everyone" + Environment.NewLine + " @here"
                Next
                SpamAll.Interval = Utils.GetRandomNumber(480, 800)
            End If
        ElseIf CheckBox1.Checked Then
            If theNum <= 1 Then
                theMessage = "@everyone"
                SpamAll.Interval = Utils.GetRandomNumber(350, 550)
            ElseIf theNum = 2 Then
                For i = 0 To 30
                    theMessage += " @everyone"
                Next
                SpamAll.Interval = Utils.GetRandomNumber(415, 575)
            ElseIf theNum = 3 Then
                For i = 0 To 30
                    theMessage += Environment.NewLine + "@everyone"
                Next
                SpamAll.Interval = Utils.GetRandomNumber(650, 715)
            ElseIf theNum = 4 Then
                theMessage = "@everyone " + Utils.RandomChineseString(1750)
                SpamAll.Interval = Utils.GetRandomNumber(1275, 1350)
            ElseIf theNum = 5 Then
                theMessage = "@everyone Mein Kampf è il saggio pubblicato nel 1925 attraverso il quale Adolf Hitler espose il suo pensiero politico e delineò il programma del Partito nazionalsocialista sotto forma di un'autobiografia."
                SpamAll.Interval = Utils.GetRandomNumber(785, 850)
            ElseIf theNum = 6 Then
                theMessage = "@everyone" + vbNewLine + "FIGLI DI PUTTANA SIAMO RITORNATI" + vbNewLine + "RAID BY WRLD"
                SpamAll.Interval = Utils.GetRandomNumber(525, 705)
            ElseIf theNum = 7 Then
                theMessage = "!help"
                SpamAll.Interval = Utils.GetRandomNumber(300, 500)
            ElseIf theNum = 8 Then
                theMessage = "pls help image"
                SpamAll.Interval = Utils.GetRandomNumber(413, 601)
            ElseIf theNum = 9 Then
                theMessage = "@everyone"
                For i = 0 To 30
                    theMessage += Environment.NewLine + "RAID BY WRLD - FIGLI DI PUTTANA SIAMO TORNATI!"
                Next
                SpamAll.Interval = Utils.GetRandomNumber(1150, 1300)
            ElseIf theNum >= 10 Then
                theMessage = "@everyone"
                For i = 0 To 30
                    theMessage += Environment.NewLine + "RAID BY WRLD - FROCI SIAMO TORNATI!"
                Next
                SpamAll.Interval = Utils.GetRandomNumber(1075, 1200)
            End If
        ElseIf CheckBox2.Checked Then
            If theNum <= 1 Then
                theMessage = "@here"
                SpamAll.Interval = Utils.GetRandomNumber(350, 550)
            ElseIf theNum = 2 Then
                For i = 0 To 30
                    theMessage += " @here"
                Next
                SpamAll.Interval = Utils.GetRandomNumber(415, 575)
            ElseIf theNum = 3 Then
                For i = 0 To 30
                    theMessage += Environment.NewLine + "@here"
                Next
                SpamAll.Interval = Utils.GetRandomNumber(650, 715)
            ElseIf theNum = 4 Then
                theMessage = "@here " + Utils.RandomChineseString(1750)
                SpamAll.Interval = Utils.GetRandomNumber(1275, 1350)
            ElseIf theNum = 5 Then
                theMessage = "@here Mein Kampf è il saggio pubblicato nel 1925 attraverso il quale Adolf Hitler espose il suo pensiero politico e delineò il programma del Partito nazionalsocialista sotto forma di un'autobiografia."
                SpamAll.Interval = Utils.GetRandomNumber(785, 850)
            ElseIf theNum = 6 Then
                theMessage = "@here" + vbNewLine + "FIGLI DI PUTTANA SIAMO RITORNATI" + vbNewLine + "RAID BY WRLD"
                SpamAll.Interval = Utils.GetRandomNumber(525, 705)
            ElseIf theNum = 7 Then
                theMessage = "!help"
                SpamAll.Interval = Utils.GetRandomNumber(300, 500)
            ElseIf theNum = 8 Then
                theMessage = "pls help image"
                SpamAll.Interval = Utils.GetRandomNumber(413, 601)
            ElseIf theNum = 9 Then
                theMessage = "@here"
                For i = 0 To 30
                    theMessage += Environment.NewLine + "RAID BY WRLD - FIGLI DI PUTTANA SIAMO TORNATI!"
                Next
                SpamAll.Interval = Utils.GetRandomNumber(1150, 1300)
            ElseIf theNum >= 10 Then
                theMessage = "@here"
                For i = 0 To 30
                    theMessage += Environment.NewLine + "RAID BY WRLD - FROCI SIAMO TORNATI!"
                Next
                SpamAll.Interval = Utils.GetRandomNumber(1075, 1200)
            End If
        Else
            If theNum <= 1 Then
                theMessage = TextBox1.Text
                SpamAll.Interval = Utils.GetRandomNumber(875, 955)
            ElseIf theNum = 2 Then
                theMessage = TextBox2.Text
                SpamAll.Interval = Utils.GetRandomNumber(1000, 1200)
            ElseIf theNum = 3 Then
                theMessage = "FIGLI DI PUTTANA SIAMO RITORNATI" + vbNewLine + "RAID BY WRLD"
                SpamAll.Interval = Utils.GetRandomNumber(500, 675)
            ElseIf theNum = 4 Then
                theMessage = "Mein Kampf è il saggio pubblicato nel 1925 attraverso il quale Adolf Hitler espose il suo pensiero politico e delineò il programma del Partito nazionalsocialista sotto forma di un'autobiografia."
                SpamAll.Interval = Utils.GetRandomNumber(755, 822)
            ElseIf theNum = 5 Then
                theMessage = "!help"
                SpamAll.Interval = Utils.GetRandomNumber(300, 500)
            ElseIf theNum = 6 Then
                theMessage = "pls help image"
                SpamAll.Interval = Utils.GetRandomNumber(413, 601)
            ElseIf theNum = 7 Then
                theMessage = TextBox3.Text
                SpamAll.Interval = Utils.GetRandomNumber(733, 915)
            ElseIf theNum = 8 Then
                For i = 0 To 30
                    theMessage += Environment.NewLine + "RAID BY WRLD - FROCI SIAMO TORNATI!"
                Next
                SpamAll.Interval = Utils.GetRandomNumber(1000, 1150)
            ElseIf theNum = 9 Then
                For i = 0 To 30
                    theMessage += Environment.NewLine + "RAID BY WRLD - FIGLI DI PUTTANA SIAMO TORNATI!"
                Next
                SpamAll.Interval = Utils.GetRandomNumber(1100, 1250)
            ElseIf theNum >= 10 Then
                theMessage = Utils.RandomChineseString(1750)
                SpamAll.Interval = Utils.GetRandomNumber(1250, 1300)
            End If
        End If
        messages += 1
        SpamAll.Interval += messages * 2
        SpamAll.Interval += NumericUpDown2.Value
        Clipboard.SetText(theMessage)
        SendKeys.Send("^v{ENTER}")
        If messages >= NumericUpDown1.Value Then
            Button2.PerformClick()
        End If
    End Sub
    Private Sub Updater_Tick(sender As Object, e As EventArgs) Handles Updater.Tick
        Label5.Text = "Messages sent: " + messages.ToString() + "/" + NumericUpDown1.Value.ToString()
        If GetAsyncKeyState(Keys.F3) Or GetAsyncKeyState(Keys.F3) = -32767 Then
            Button1.PerformClick()
        ElseIf GetAsyncKeyState(Keys.F4) Or GetAsyncKeyState(Keys.F4) = -32767 Then
            Button2.PerformClick()
        End If
    End Sub
    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Process.Start("https://mee6.xyz/dashboard")
    End Sub
    Private Sub LinkLabel2_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked
        Process.Start("https://dyno.gg/account")
    End Sub
End Class