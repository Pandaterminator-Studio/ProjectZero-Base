Imports System.IO
Imports System.Net

Public Class MainForm
    Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Panel4.Visible = False
        InGoods.get_goods()

        Label1.Text = user_data.name & " " & user_data.last_name
        Dim url As String = "http://web.jk-i.eu/framework/platform/jki/user_data/img/" & user_data.customer_photo
        Dim MyWebClient As New System.Net.WebClient

        'BYTE ARRAY HOLDS THE DATA
        Dim ImageInBytes() As Byte = MyWebClient.DownloadData(url)

        'CREATE A MEMORY STREAM USING THE BYTES
        Dim ImageStream As New IO.MemoryStream(ImageInBytes)

        PictureBox1.Image = New System.Drawing.Bitmap(ImageStream)

        If user_data.permission_group = "0" Then
            Label2.Text = "Customer"
        ElseIf user_data.permission_group = "1" Then
            Label2.Text = "Factory"
        ElseIf user_data.permission_group = "2" Then
            Label2.Text = "Warehouse"
        ElseIf user_data.permission_group = "3" Then
            Label2.Text = "Office"
        ElseIf user_data.permission_group = "4" Then
            Label2.Text = "Client"
        ElseIf user_data.permission_group = "10" Then
            Label2.Text = "Creator"
        Else
            Label2.Text = "Not memeber ?"
        End If
    End Sub

    Dim drag As Boolean
    Dim mousex As Integer
    Dim mousey As Integer

    Private Sub Form1_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Panel1.MouseDown
        drag = True 'Sets the variable drag to true.
        mousex = Windows.Forms.Cursor.Position.X - Me.Left 'Sets variable mousex
        mousey = Windows.Forms.Cursor.Position.Y - Me.Top 'Sets variable mousey
    End Sub

    Private Sub Form1_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Panel1.MouseMove
        'If drag is set to true then move the form accordingly.
        If drag Then
            Me.Top = Windows.Forms.Cursor.Position.Y - mousey
            Me.Left = Windows.Forms.Cursor.Position.X - mousex
        End If
    End Sub

    Private Sub Form1_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Panel1.MouseUp
        drag = False 'Sets drag to false, so the form does not move according to the code in MouseMove
    End Sub


    Private Sub Form_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Panel2.MouseDown
        drag = True 'Sets the variable drag to true.
        mousex = Windows.Forms.Cursor.Position.X - Me.Left 'Sets variable mousex
        mousey = Windows.Forms.Cursor.Position.Y - Me.Top 'Sets variable mousey
    End Sub

    Private Sub Form_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Panel2.MouseMove
        'If drag is set to true then move the form accordingly.
        If drag Then
            Me.Top = Windows.Forms.Cursor.Position.Y - mousey
            Me.Left = Windows.Forms.Cursor.Position.X - mousex
        End If
    End Sub

    Private Sub Form_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Panel2.MouseUp
        drag = False 'Sets drag to false, so the form does not move according to the code in MouseMove
    End Sub

    Private Sub PictureBox5_Click(sender As Object, e As EventArgs) Handles PictureBox5.Click
        LoginFRM.Show()
        Me.Close()
    End Sub

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
        If Panel4.Visible = False Then
            Panel4.Visible = True
        ElseIf Panel4.Visible = True Then
            Panel4.Visible = False
        End If
    End Sub

    Private Sub Panel4_MouseLeave(sender As Object, e As EventArgs) Handles Panel4.MouseLeave
        If Panel4.Visible = True Then
            Panel4.Visible = False
        End If
    End Sub

    Private Sub Panel3_Paint(sender As Object, e As PaintEventArgs) Handles Panel3.Paint

    End Sub
End Class