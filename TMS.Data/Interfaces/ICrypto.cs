using System;
using System.Collections.Generic;
using System.Text;

namespace TMS.Data.Interfaces
{
    public interface ICrypto : IDisposable
    {
        string Encrypt(string TextToEncrypt);

        string Decrypt(string TextToDecrypt);

        string EncryptPassword(string TextToEncrypt);

        string DecryptPassword(string TextToEncrypt);
    }
}
