using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NXPBugger
{
    
    public static class GeneralProgramClass
    {
        public enum UploadMode
        {
            NONE,
            CONFIG,
            PROGRAM
        }

        public enum CanMessageState
        {
            ERROR,
            OK,
            TIMEOUT
        }

        public enum UartMessageState
        {
            ERROR,
            OK,
            TIMEOUT
        }

        public static UploadMode ModeForUpload;
        public static bool READCFG = false;
        public static string DefaultFileLocation;
        public static volatile bool FormActive_CFG_Creator = false;
        public static bool FormActive_CFG_Reader = false;
        public static bool ListenInfinite = false;
    }
}
