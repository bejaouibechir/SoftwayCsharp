using System;

using System.Xml;

using System.Security.Cryptography;

using System.IO;
using System.Text;
using System.Configuration;
using System.Diagnostics;


namespace Client
{
    /// <summary>
    /// Enumeration : Helps to choose the right algorithm to use
    /// </summary>
    enum CryptAlgorythmToUse
    {
        RijndaelManaged, TripleDES
    }
    /// <summary>
    /// Enumeration : Helps to choose the key and IV generation mode
    /// </summary>
    enum Generate
    {
        Auto, Manual
    }
    /// <summary>
    /// Class that inherits form the abstract class ProtectedConfigurationProvider
    /// </summary>
    sealed class CustomProtectionProvider : ProtectedConfigurationProvider
    {
        //Used to precise the name of the current provider
        private string CustomProviderName;
        //Used to precise the configuration file path
        private string _ConfigFilePath;
        //Used to precise the configuration section to Encrypt/Decrypt
        private string _SectionName;
        //The key
        private byte[] _Key;
        //The initial vector
        private byte[] _IV;
        //Symetric Algorithm
        private SymmetricAlgorithm algo;

        /// <summary>
        /// The first class constructor
        /// </summary>
        /// <param name="CustomProviderName">String: The provider name</param>
        /// <param name="Algorithm">Enum: The symmetric algorithm to use </param>
        /// <param name="Generate">Enum: Precise if the key and the initial vector
        /// are auto generated or given by the class user
        ///</param>

        public CustomProtectionProvider(string CustomProviderName, CryptAlgorythmToUse Algorithm, Generate Generate)
        {
            //Set the provider name
            this.CustomProviderName = CustomProviderName;
            //In this case the rijndael is selected
            if (Algorithm == CryptAlgorythmToUse.RijndaelManaged)
            {
                 algo = new RijndaelManaged();
                //If the generation mode is auto means that algo generates the key and IV automatically
                if (Generate == Generate.Auto)
                {
                    algo.GenerateKey();
                    _Key = algo.Key;
                    algo.GenerateIV();
                    _IV = algo.IV;
                }
            }

            //In this case the TripleDES is selected
            if (Algorithm == CryptAlgorythmToUse.TripleDES)
            {
                 algo = new TripleDESCryptoServiceProvider();
                if (Generate == Generate.Auto)
                {
                    algo.GenerateKey();
                    _Key = algo.Key;
                    algo.GenerateIV();
                    _IV = algo.IV;
                }
            }
        }

        /// <summary>
        /// The second class constructor
        /// </summary>
        /// <param name="CustomProviderName">String: The provider name</param>
        /// <param name="ConfigFilePath">String: The configuration file path</param>
        /// <param name="Algorithm">Enum: The symmetric algorithm to use</param>
        /// <param name="Generate">Enum: Precise if the key and the initial vector
        /// are auto generated or given by the class user</param>
        public CustomProtectionProvider(string CustomProviderName, string ConfigFilePath, CryptAlgorythmToUse Algorithm, Generate Generate)
        {
            //Set the provider name
            this.CustomProviderName = CustomProviderName;
            //Set the configuration path
            this.ConfigFilePath = ConfigFilePath;
            if (Algorithm == CryptAlgorythmToUse.RijndaelManaged)
            {
                var algo = new RijndaelManaged();
                if (Generate == Generate.Auto)

                {
                    algo.GenerateKey();

                    _Key = algo.Key;

                    algo.GenerateIV();

                    _IV = algo.IV;

                }

            }

            if (Algorithm == CryptAlgorythmToUse.TripleDES)

            {

                var Algo = new TripleDESCryptoServiceProvider();

                if (Generate == Generate.Auto)

                {

                    Algo.GenerateKey();

                    _Key = Algo.Key;

                    Algo.GenerateIV();

                    _IV = Algo.IV;

                }

            }

        }

        /// <summary>
        /// String: Get and set the configuration file path
        /// </summary>
        public string ConfigFilePath

        {
            get { return _ConfigFilePath; }
            set { _ConfigFilePath = value; }
        }

        /// <summary>
        /// String : Get the custom provider name
        /// </summary>
        public override string Name
        {
            get
            {

                return "EncryptConfigurationFile.CustomProtectionProvider:  " + CustomProviderName;
            }
        }
        /// <summary>
        /// String : Get the custom provider description
        /// </summary>
        public override string Description
        {
            get
            {
                return "This is a customized protection provider to encrypt/decrypt configurations sections";
            }
        }
        /// <summary>
         /// Byte array : Get and set the algorithm key
        /// </summary>
        public byte[] Key
        {
            get
            { return _Key; }
            set
            { _Key = value; }
        }
        /// <summary>
        /// Byte array : Get and set the algorithm initial vector
        /// </summary>
        public byte[] IV
        {
            get { return _IV; }
            set { _IV = value; }
        }
        /// <summary>
        /// String : Get and set the configuration section name
        /// </summary>
        public string SectionName
        {
            get { return _SectionName; }
            set { _SectionName = value; }
        }
        /// <summary>
        /// XmlNode : Function that returns an encrypted xml node
        /// </summary>
        /// <param name="node">XmlNode : Xml node that could be null</param>
        /// <returns></returns>
        public override XmlNode Encrypt(XmlNode node)
        {
            //Create a new xml document
            XmlDocument myDoc = new XmlDocument();
            //Then load it, the configuration file path has to be precised
            myDoc.Load(ConfigFilePath);
            //If you leave the argument as null you have toprecise at least the configuration section name
            if (node == null)
            {
                XmlNodeList myXmlNodeList = myDoc.GetElementsByTagName(SectionName);
                node = myXmlNodeList[0] as XmlNode;
            }
            //This option lets you precise the xml node to encrypt outside the class scoop
            if (node != null)
            {
                XmlNodeList myXmlNodeList = myDoc.GetElementsByTagName(node.Name);
                node = myXmlNodeList[0] as XmlNode;
            }
            //Encode the configuration section contents to bytes
            byte[] nodeContentInByte = Encoding.Unicode.GetBytes(node.InnerXml);
            //This byte array is used to contain the output after encryption
            byte[] outPutContentInByte = new byte[nodeContentInByte.Length];
            //I choose the file stream instead of the memory stream
            using (FileStream oStream = new FileStream(@"C:\temp\inout.txt", FileMode.Create, FileAccess.Write))
            {
                //Create an encryptor
                using (ICryptoTransform oTransform = algo.CreateEncryptor(algo.Key, algo.IV))
                {
                    using (CryptoStream crStream = new CryptoStream(oStream, oTransform, CryptoStreamMode.Write))
                    {
                        try
                        {
                            crStream.Write(nodeContentInByte, 0, nodeContentInByte.Length);
                            crStream.Flush();
                        }
                        catch (ArgumentException caught) { Debug.WriteLine(caught.Message); }
                    }
                }
            }
            //The ouput as string
            string output = Convert.ToBase64String(outPutContentInByte);
            //Set the new node content
            node.InnerXml = AddTags(output);
            Debug.WriteLine(node.InnerXml);
            //Update the configuration file
            myDoc.Save(ConfigFilePath);
            return node;
        }

        public override XmlNode Decrypt(XmlNode node)
        {
            XmlDocument myDoc = new XmlDocument();
            myDoc.Load(ConfigFilePath);
            string output = "";

            if (node == null)
            {
                XmlNodeList myXmlNodeList = myDoc.GetElementsByTagName(SectionName);
                node = myXmlNodeList[0] as XmlNode;
            }
            if (node != null)
            {
                XmlNodeList myXmlNodeList = myDoc.GetElementsByTagName(node.Name);
                node = myXmlNodeList[0] as XmlNode;
            }
            using (FileStream oStream = new FileStream(@"C:\temp\inout.txt", FileMode.Open, FileAccess.Read))
            {
                using (BinaryReader oBinaryReader = new BinaryReader(oStream))
                {
                    long Max = oBinaryReader.BaseStream.Length;
                    //Put the file content into an array of bytes
                    byte[] ContentToByte = oBinaryReader.ReadBytes(Convert.ToInt32(Max));
                    //Encode the bytes to chars
                    char[] ContentToChar = Encoding.Unicode.GetChars(ContentToByte);
                    //Transform the char array to string
                    string inputstring = new string(ContentToChar);
                    //Set the current position of this stream
                    oStream.Seek(0, SeekOrigin.Begin);
                    using (ICryptoTransform oTransform = algo.CreateDecryptor(Key, IV))
                    {
                        using (CryptoStream crStream = new CryptoStream(oStream, oTransform, CryptoStreamMode.Read))
                        {
                            //Read the data within the crypto stream using a stream reader instance
                            using (StreamReader oReader = new StreamReader(crStream, new UnicodeEncoding()))
                            {
                                output = oReader.ReadToEnd();
                            }
                            crStream.Flush();
                        }
                    }
                }
            }
            //Update the node conetent
            node.InnerXml = output;
            Debug.WriteLine(node.InnerXml);
            //Update the configuration file
            myDoc.Save(ConfigFilePath);
            return node;
        }
        /// <summary>
        /// int: Get the hash code
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        /// <summary>
        /// String : Adds tags to indicate that the current string is a ecrypted
        /// </summary>
        /// <param name="input">String: The string going to be tagged</param>
        /// <returns>String : Tagged encrypted string</returns>
        private string AddTags(string input)

        {
            return "<EncryptedData>" + input + "</EncryptedData>";
        }

    }

}