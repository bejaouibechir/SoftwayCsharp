using System;
using System.Configuration;
using System.Diagnostics;
using static System.Net.Mime.MediaTypeNames;

namespace Client
{
    public class Program
    {
        static public void Main(string[] args)
        {
            ConfigEncryptor.Decrypt();

        }
    }

    static public class ConfigEncryptor
    {
        public static void Encrypt()
        {
            string path = AppDomain.CurrentDomain.SetupInformation.ConfigurationFile;

            //Create a new ExeConfigurationFileMap
            ExeConfigurationFileMap oFile = new ExeConfigurationFileMap();
            //Precise its path
            oFile.ExeConfigFilename = path;
            //Create a new configuration object related to the configuration file
            Configuration oConfiguration = ConfigurationManager.OpenMappedExeConfiguration(oFile, ConfigurationUserLevel.None);
            //Create a section and set it as the targeted section
            ConnectionStringsSection oSection = oConfiguration.GetSection("connectionStrings") as ConnectionStringsSection;
            //if the section is already encrypted dont ecrypt it again
            if (oSection != null && !oSection.SectionInformation.IsProtected)
            {
                //The section ecryption
                oSection.SectionInformation.ProtectSection("DataProtectionConfigurationProvider");
                //Update the configuration file
                oConfiguration.Save();
                Debug.WriteLine("Connection string encrypted");

            }
        }

        public static void Decrypt()
        {
            //Create a new ExeConfigurationFileMap
            ExeConfigurationFileMap oFile = new ExeConfigurationFileMap();
            //Precise its path
            oFile.ExeConfigFilename = AppDomain.CurrentDomain.SetupInformation.ConfigurationFile;
            //Create a new configuration object related to the configuration file
            Configuration oConfiguration = ConfigurationManager.OpenMappedExeConfiguration(oFile, ConfigurationUserLevel.None);
            //Create a section and set it as the targeted section
            ConnectionStringsSection oSection = oConfiguration.GetSection("connectionStrings") as ConnectionStringsSection;
            if (oSection != null && oSection.SectionInformation.IsProtected)
            {
                oSection.SectionInformation.UnprotectSection();
                oConfiguration.Save();
                Debug.WriteLine("Connection string decrypted");
            }
        }
    }
}


/*
 static CustomProtectionProvider _myProvider = new CustomProtectionProvider("myProvider",
              CryptAlgorythmToUse.RijndaelManaged, Generate.Auto);
        static public void Main(string[] args)
        {
            Encrypt();
            Decrypt();
        }

        static public void Decrypt()
        {
            _myProvider.ConfigFilePath = AppDomain.
               CurrentDomain.SetupInformation.ConfigurationFile;
            //Precise the targeted configuration section
            _myProvider.SectionName = "connectionStrings";

            //Unprotect the confguration section
            XmlNode myNode = _myProvider.Decrypt(null);
        }

        static public void Encrypt()
        {
            _myProvider = new CustomProtectionProvider("myProvider",
                CryptAlgorythmToUse.RijndaelManaged, Generate.Auto);
            _myProvider.ConfigFilePath = AppDomain.
                CurrentDomain.SetupInformation.ConfigurationFile;
            //Precise the targeted configuration section
            _myProvider.SectionName = "connectionStrings";
            //Protect the configuration section
            XmlNode myNode = _myProvider.Encrypt(null);
            Console.WriteLine("Encryption is done!!!");
            Console.Read();
        }
 
 
 */