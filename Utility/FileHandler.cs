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

        public bool WriteLicenseToTxt(string license)
        {
            try
            {
                if (File.Exists(licenseFileDir))
                {
                    File.WriteAllText(licenseFileDir, string.Empty);
                }
                File.AppendAllText(licenseFileDir, license);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
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
