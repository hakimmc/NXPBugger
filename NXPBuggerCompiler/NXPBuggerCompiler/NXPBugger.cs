using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace NXPBuggerCompiler
{
    public static class NXPBugger
    {
        public static void CreateCWA(string ConfigFileAddr, string binFileAdrr,string CWAFileName)
        {
            byte[] cfg_bytes;
            cfg_bytes = File.ReadAllBytes(ConfigFileAddr);
            File.WriteAllBytes(CWAFileName, MergeByteArrays(cfg_bytes, File.ReadAllBytes(binFileAdrr)));
        }
       
        private static byte[] MergeByteArrays(byte[] array1, byte[] array2)
        {
            byte[] mergedArray = new byte[array1.Length + array2.Length];
            Buffer.BlockCopy(array1, 0, mergedArray, 0, array1.Length);
            Buffer.BlockCopy(array2, 0, mergedArray, array1.Length, array2.Length);
            return mergedArray;
        }

    }
}
