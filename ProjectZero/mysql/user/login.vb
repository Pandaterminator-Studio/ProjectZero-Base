Imports System.Security.Cryptography
Imports System.Text
Imports MySql.Data.MySqlClient

Module login
    Public Sub user(ByVal email As String, ByVal password As String)
        Dim email_ As String = email
        Dim pass As String = GetHash(password)
        Dim sqlQuery As String
        Dim publictable As New DataTable

        If email.Contains("@") Then
            sqlQuery = "SELECT * FROM customers WHERE email=@email AND password=@password"
            Dim cmd As New MySqlCommand
            Dim da As New MySqlDataAdapter
            With cmd
                .Connection = connector.MySQLConn
                .CommandText = sqlQuery
                .Parameters.Add("@email", email_)
                .Parameters.Add("@password", pass)
            End With
            da.SelectCommand = cmd
            da.Fill(publictable)
            If publictable.Rows.Count > 0 Then
                user_data.id = publictable.Rows(0).Item(0)
                user_data.customer_id = publictable.Rows(0).Item(1)
                user_data.client_id = publictable.Rows(0).Item(2)
                user_data.email = email_
                user_data.pass = pass
                user_extra(user_data.customer_id)
            Else
                MsgBox("Contact administrator to registered!")
                email_ = ""
                pass = ""
            End If
            da.Dispose()
        Else
            sqlQuery = "SELECT * FROM customers WHERE client_id=@email AND password =@password"
            Dim cmd As New MySqlCommand
            Dim da As New MySqlDataAdapter
            With cmd
                .Connection = connector.MySQLConn
                .CommandText = sqlQuery
                .Parameters.Add("@email", email_)
                .Parameters.Add("@password", pass)
            End With
            da.SelectCommand = cmd
            da.Fill(publictable)
            If publictable.Rows.Count > 0 Then
                user_data.id = publictable.Rows(0).Item(0)
                user_data.customer_id = publictable.Rows(0).Item(1)
                user_data.client_id = publictable.Rows(0).Item(2)
                user_data.email = email_
                user_data.pass = pass
                user_extra(user_data.customer_id)
            Else
                MsgBox("Contact administrator to registered!")
                email_ = ""
                pass = ""
            End If
            da.Dispose()
        End If

    End Sub

    Private Function GetHash(strToHash As String) As String

        Dim md5Obj As New System.Security.Cryptography.MD5CryptoServiceProvider
        Dim bytesToHash() As Byte = System.Text.Encoding.ASCII.GetBytes(strToHash)

        bytesToHash = md5Obj.ComputeHash(bytesToHash)
        Dim strResult As New StringBuilder

        For Each b As Byte In bytesToHash
            strResult.Append(b.ToString("x2"))
        Next

        Return strResult.ToString

    End Function

    Private Sub user_extra(ByVal cust_id As String)
        Dim publictable As New DataTable
        Dim sqlQuery As String
        sqlQuery = "SELECT * FROM customer_data WHERE customer_id=@uid"
        Dim cmd As New MySqlCommand
        Dim da As New MySqlDataAdapter
        With cmd
            .Connection = connector.MySQLConn
            .CommandText = sqlQuery
            .Parameters.Add("@uid", cust_id)

        End With
        da.SelectCommand = cmd
        da.Fill(publictable)
        If publictable.Rows.Count > 0 Then
            user_data.name = publictable.Rows(0).Item(2)
            user_data.last_name = publictable.Rows(0).Item(3)
            user_data.permission_group = publictable.Rows(0).Item(4)
            user_data.customer_photo = publictable.Rows(0).Item(5)
            MainForm.Show()
            LoginFRM.Close()
        Else
            MsgBox("Contact administrator to registered!")
        End If
        da.Dispose()
    End Sub
End Module
