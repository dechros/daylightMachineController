using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;
using System.IO;

namespace DayLightMachineController.Utility
{
    class LicenseHandler
    {
        private FileHandler fileHandler;
        public LicenseHandler()
        {
            fileHandler = new FileHandler();
        }

        public bool DecodeLicense(string license, string machineId)
        {
            string decodedId = "";
            license = license.Replace("-", String.Empty);

            for (int i = 0; i <= license.Length - 2; i += 2)
            {
                int birler = Convert.ToInt32(license[license.Length - i - 1]) - 48;
                int onlar = Convert.ToInt32(license[license.Length - i - 2]) - 48;
                onlar = onlar * 10;
                int decoded = (birler + onlar) / 4 - 11;
                decodedId += decoded.ToString();
            }
            return decodedId == machineId;
        }

        public bool CheckExistingLicense(string deviceId)
        {
            string txtLicense = fileHandler.ReadLicenseFromTxt();
            return DecodeLicense(txtLicense, deviceId);
        }
    }
}
