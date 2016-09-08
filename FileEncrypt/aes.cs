using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace FileEncrypt
{
    public class aes
    {
        private const ulong FC_TAG = 0xFC010203040506CF;
        public string strInFile;
        public string strOutFile;
        public byte[] bPwd;
        public Button btnEncryt;
        public Button btnDecrypt;
        public ProgressBar probar;

        public aes()
        {
        }

        public aes(string strInFile, string strOutFile, byte[] bPwd, Button btnEncryt, Button btnDecrypt, ProgressBar probar)
        {
            this.strInFile = strInFile;
            this.strOutFile = strOutFile;
            this.bPwd = bPwd;
            this.probar = probar;
            this.btnEncryt = btnEncryt;
            this.btnDecrypt = btnDecrypt;
        }

        private Rijndael CreateRijndael()
        {
            PasswordDeriveBytes pdb = new PasswordDeriveBytes(bPwd, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
            Rijndael rij = Rijndael.Create();
            rij.Key = pdb.GetBytes(32);
            rij.IV = pdb.GetBytes(16);
            return rij;
        }

        public void EncryptFile()
        {
            byte[] buffer = new byte[4096];
            long filelen = 0;
            int length = 0;
            long total = 0;
            int value = 0;
            FileStream fsOut = null;
            FileStream fsIn = null;

            try
            {
                btnEncryt.Enabled = false;
                btnDecrypt.Enabled = false;

                fsIn = new FileStream(strInFile, FileMode.Open);
                fsOut = new FileStream(strOutFile, FileMode.Create);

                filelen = fsIn.Length;

                probar.Value = 0;

                // Create an AesCryptoServiceProvider object
                // with the specified key and IV.
                using (AesCryptoServiceProvider aesAlg = new AesCryptoServiceProvider())
                {
                    Rijndael rij = CreateRijndael();

                    aesAlg.Key = rij.Key;
                    aesAlg.IV = rij.IV;

                    // to be pumping data. 
                    // Our fsEncFile is going to be receiving the Encrypted bytes. 
                    CryptoStream csEncrypt = new CryptoStream(fsOut, aesAlg.CreateEncryptor(), CryptoStreamMode.Write);
                    BinaryWriter bwOut = new BinaryWriter(csEncrypt);
             
                    bwOut.Write(FC_TAG);
                    bwOut.Write(filelen);

                    while ((length = fsIn.Read(buffer, 0, 4096)) > 0)
                    {
                        csEncrypt.Write(buffer, 0, length);
                        total = total + length;
                        value = (int)((total*1.0 / filelen) * 100);
                        if(value > probar.Value)
                            probar.Value =  value;
                    }

                    csEncrypt.FlushFinalBlock();
                }

                fsIn.Close();
                fsOut.Close();
            }
            catch (Exception ex)
            {
                if (fsIn != null) fsIn.Close();
                if (fsOut != null) fsOut.Close();

                MessageBox.Show(ex.Message);
            }
            finally
            {
                btnEncryt.Enabled = true;
                btnDecrypt.Enabled = true;
            }
        }

        public void DecryptFile()
        {
            byte[] buffer = new byte[4096];
            ulong filelen = 0;
            int length = 0;
            long total = 0;
            int value = 0;
            FileStream fsOut = null;
            FileStream fsIn = null;

            try
            {
                btnEncryt.Enabled = false;
                btnDecrypt.Enabled = false;

                fsIn = new FileStream(strInFile, FileMode.Open);

                probar.Value = 0;

                // Create an AesCryptoServiceProvider object
                // with the specified key and IV.
                using (AesCryptoServiceProvider aesAlg = new AesCryptoServiceProvider())
                {
                    Rijndael rij = CreateRijndael();

                    aesAlg.Key = rij.Key;
                    aesAlg.IV = rij.IV;

                    CryptoStream cin = new CryptoStream(fsIn, aesAlg.CreateDecryptor(), CryptoStreamMode.Read);
                    BinaryReader br = new BinaryReader(cin);

                    ulong tag = br.ReadUInt64();

                    if (FC_TAG != tag)
                    {
                        MessageBox.Show("File is not encrypted, damaged or password incorrect.");
                        fsIn.Close();
                        return;
                    }

                    filelen = br.ReadUInt64();

                    fsOut = new FileStream(strOutFile, FileMode.Create, FileAccess.Write);

                    while ((length = cin.Read(buffer, 0, 4096)) > 0)
                    {
                        fsOut.Write(buffer, 0, length);
                        total = total + length;
                        value = (int)((total * 1.0 / filelen) * 100);
                        if (value > probar.Value)
                            probar.Value = value;
                    }
                }

                fsIn.Close();
                fsOut.Close();
            }
            catch (Exception ex) 
            { 
                if (fsIn != null) fsIn.Close();
                if (fsOut != null) fsOut.Close();
                MessageBox.Show(ex.Message);
            }
            finally
            {
                btnEncryt.Enabled = true;
                btnDecrypt.Enabled = true;
            }
        }
    }
}

