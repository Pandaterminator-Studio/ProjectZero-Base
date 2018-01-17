Imports MySql.Data.MySqlClient

Module connector
    Public MySQLConn As MySqlConnection

    Private DB_HOST As String = "jk-i.eu"
    Private DB_USER As String = "fuse"
    Private DB_PASS As String = "wawapowa555"
    Private DB_NAME As String = "fuse_manager"
    Public Sub connect()
        MySQLConn = New MySqlConnection()
        MySQLConn.ConnectionString = "server=" & DB_HOST & ";" _
        & "user id=" & DB_USER & ";" _
        & "password=" & DB_PASS & ";" _
        & "database=" & DB_NAME & ""
        Try
            MySQLConn.Open()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        ' MessageBox.Show("Connection to Database has been opened.")
    End Sub
End Module
