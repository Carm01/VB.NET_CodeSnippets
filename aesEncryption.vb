' Properly Using AES encryption in CBC mode to encrypt text. Key is the key used to encrypt or decrypt the data. 
Private Function AESE(ByVal plaintext As String, ByVal key As String) As String
    Dim AES As New System.Security.Cryptography.AesManaged
    Dim SHA256 As New System.Security.Cryptography.SHA256Cng
    Dim ciphertext As String = ""
    Try
        AES.GenerateIV()
        AES.Key = SHA256.ComputeHash(System.Text.ASCIIEncoding.ASCII.GetBytes(key))

        AES.Mode = Security.Cryptography.CipherMode.CBC
        Dim DESEncrypter As System.Security.Cryptography.ICryptoTransform = AES.CreateEncryptor
        Dim Buffer As Byte() = System.Text.ASCIIEncoding.ASCII.GetBytes(plaintext)
        ciphertext = Convert.ToBase64String(DESEncrypter.TransformFinalBlock(Buffer, 0, Buffer.Length))

        Return Convert.ToBase64String(AES.IV) & Convert.ToBase64String(DESEncrypter.TransformFinalBlock(Buffer, 0, Buffer.Length))

    Catch ex As Exception
        Return ex.Message
    End Try
End Function

Private Function AESD(ByVal ciphertext As String, ByVal key As String) As String
    Dim AES As New System.Security.Cryptography.AesManaged
    Dim SHA256 As New System.Security.Cryptography.SHA256Cng
    Dim plaintext As String = ""
    Dim iv As String = ""
    Try
        Dim ivct = ciphertext.Split({"=="}, StringSplitOptions.None)
        iv = ivct(0) & "=="
        ciphertext = If(ivct.Length = 3, ivct(1) & "==", ivct(1))

        AES.Key = SHA256.ComputeHash(System.Text.ASCIIEncoding.ASCII.GetBytes(key))
        AES.IV = Convert.FromBase64String(iv)
        AES.Mode = Security.Cryptography.CipherMode.CBC
        Dim DESDecrypter As System.Security.Cryptography.ICryptoTransform = AES.CreateDecryptor
        Dim Buffer As Byte() = Convert.FromBase64String(ciphertext)
        plaintext = System.Text.ASCIIEncoding.ASCII.GetString(DESDecrypter.TransformFinalBlock(Buffer, 0, Buffer.Length))
        Return plaintext
    Catch ex As Exception
        Return "Bad key or ciphertext"
    End Try
End Function