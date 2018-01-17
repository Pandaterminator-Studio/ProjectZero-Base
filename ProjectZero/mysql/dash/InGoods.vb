Imports MySql.Data.MySqlClient

Module InGoods
    Dim i As Integer
    Public Sub get_goods()
        Dim sql As String
        sql = "SELECT * FROM delivery_announce ORDER BY cargo_ready ASC LIMIT 5"
        Dim cmd As New MySqlCommand
        Dim da As New MySqlDataAdapter
        Dim publictable As New DataTable
        With cmd
            .Connection = connector.MySQLConn
            .CommandText = sql
        End With
        da.SelectCommand = cmd
        da.Fill(publictable)
        If publictable.Rows.Count > 0 Then

            If (MainForm.ListView1.Items.Count > 0) Then

                If (MainForm.ListView1.Items(MainForm.ListView1.Items.Count - 1).SubItems(0).Text.ToLower = "total") Then

                    MainForm.ListView1.Items.RemoveAt(MainForm.ListView1.Items.Count - 1)

                End If

            End If
            i = i + 1
            Dim str(4) As String
            Dim itm As ListViewItem
            str(0) = publictable.Rows(0).Item(1)

            str(1) = publictable.Rows(0).Item(2)

            str(2) = publictable.Rows(0).Item(3)

            str(3) = publictable.Rows(0).Item(5)

            itm = New ListViewItem(str)

            MainForm.ListView1.Items.Insert(0, itm)
        Else
            MsgBox("Contact administrator: error loading delivery_announce !")
        End If
        da.Dispose()
    End Sub
End Module
