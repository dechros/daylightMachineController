using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DayLightMachineController.Utility
{
    class FileHandler
    {
        private string licenseFileDir;

        public FileHandler()
        {
            licenseFileDir = @"../License/License.txt";
        }

        public void WriteLicenseToTxt(byte[] encrypted)
        {
            File.WriteAllBytes(licenseFileDir, encrypted);
        }

        public string ReadLicenseFromTxt()
        {
            try
            {
                string returnValue = "";
                byte[] tempByte = File.ReadAllBytes(licenseFileDir);
                foreach (byte b in tempByte)
                {
                    if(b >= 48)
                    {
                        returnValue += (b - 48).ToString();
                    }
                    else
                    {
                        returnValue += "-";
                    }
                    
                }
                return returnValue;
            }
            catch (Exception)
            {
                return "";
            }
        }
    }
}
