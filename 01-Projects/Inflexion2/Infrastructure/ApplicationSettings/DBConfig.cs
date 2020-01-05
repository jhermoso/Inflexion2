namespace Inflexion2.Infrastructure
{
    using System;
    using System.Linq;
    using System.Collections;
    using System.Collections.Generic;
    using System.IO;
    using System.Security.Cryptography;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;
    using System.Security;
    using Inflexion2.Extensions;


    /// <summary>
    /// Setup functions and methods for Database access configuration files.
    /// Every module has to have his own dbconfig file with all the possible database connections.
    /// </summary>
    public static class DBConfig
    {
        private const string userKey = "kbGtg5euTZPUtafUw"; // encrpting key for user
        private const string passwordKey = "t7SB5gftqkkdTgLdH"; // encripting key for password
        private static readonly byte[] Salt = new byte[] { 0xa4, 0xea, 0xda, 0x7c, 0xef, 0x5d, 0x7a, 0x9d, 0xc3, 0x7d, 0x28, 0xe9, 0xef };
        private const string UserMark = "User Id=";
        private const string PasswordMark = "Password=";
        private const string SeparatorMark = ";";
        private static DBConfigData config;

        //public static string SelectedConnectionName { get; private set; }
        public static DBConfigData Config
        {
            get
            {
                return config;
            }

            private set
            {
                config = value;
            } 
        }


        public static connectionNode SelectedConnection
        {
            get
            {
                if (!String.IsNullOrWhiteSpace(SelectedConnectionName))
                {
                    var temp = config.items.FirstOrDefault(c => c.name.ToLower().Contains(SelectedConnectionName.ToLower()));
                    if (temp == null)
                    {
                        SelectedConnectionName = "Default";
                        temp = config.items.FirstOrDefault(c => c.name.ToLower().Contains(SelectedConnectionName.ToLower()));
                    }

                    return temp;
                }
                    
                return null;
            }
        }

        /// <summary>
        /// https://stackoverflow.com/questions/5069099/when-a-class-is-inherited-from-list-xmlserializer-doesnt-serialize-other-att
        /// </summary>
        [XmlRoot("dbconfig")]
        public class DBConfigData 
        {
            [XmlArray("connectionStrings"), XmlArrayItem("dbConnection")]
            public List<connectionNode> items = new List<connectionNode>();
        }

        public class connectionNode
        {
            [XmlAttribute("name")]
            public string name { get; set; }

            [XmlAttribute("connectionString")]
            public string connectionString { get; set; }

            [XmlAttribute("providerName")]
            public string providerName { get; set; }

            [XmlAttribute("encrypted")]
            public bool encrypted { get; set; }

            public bool ConnectedDB
            {
                get
                {
                    return DBConfig.SelectedConnection.name == this.name;
                }
            }

            public void EncryptUserPasword()
            {
                string user = GetUser();
                string password = GetPassword();

                string encriptedUser = Encrypt(user, userKey);
                string encriptedPassword = Encrypt(password, passwordKey);

                this.connectionString = this.connectionString.Replace(UserMark + user + SeparatorMark, UserMark + encriptedUser + SeparatorMark);
                this.connectionString = this.connectionString.Replace(PasswordMark + password + SeparatorMark, PasswordMark + encriptedPassword + SeparatorMark);
                this.encrypted = true;
                string fileName = ApplicationSettings.GetAppSetting("db.config");

                Config = DBConfig.WriteDBConfig(DBConfig.Config, fileName);
            }

            public string GetDecryptedConnectionString()
            {
                if (!this.encrypted)
                {
                    return this.connectionString;
                }
                else
                {
                    string encriptedUser =  this.connectionString.Substring(UserMark, SeparatorMark);
                    string user = GetUser();
                    string encriptedPassword = this.connectionString.Substring(PasswordMark, SeparatorMark);

                    string password = GetPassword();

                    var temp = this.connectionString.Replace( UserMark + encriptedUser + SeparatorMark, UserMark + user + SeparatorMark);
                    temp     =                  temp.Replace( PasswordMark + encriptedPassword + SeparatorMark, PasswordMark + password + SeparatorMark);
                    return temp;
                }

            }

            public string GetPassword()
            {
                string password = this.connectionString.Substring(PasswordMark, SeparatorMark);

                if (this.encrypted)
                {
                    return Decrypt(password, passwordKey);
                }
                else
                {
                    return password;
                }
            }

            public string GetUser()
            {
                string user = this.connectionString.Substring(UserMark, SeparatorMark);

                if (this.encrypted)
                {
                    return Decrypt(user, userKey);
                }
                else
                {
                    return user;
                }
            }


        }

        public static void ReadDBConfig(string fileName)
        {
            using (TextReader reader = new StreamReader(fileName))
            {
                XmlReader xmlReader = XmlReader.Create(reader);
                System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(typeof(DBConfigData));
                Config = (DBConfigData)serializer.Deserialize(xmlReader);

                //return Decrypt(dbConfigData);// dbConfigData.encrypted ? Decrypt(dbConfigData) : dbConfigData;
            }
        }

        private static DBConfigData Decrypt(DBConfigData dbConfigData)
        {
            DBConfigData decriptedfile = new DBConfigData();
            
            connectionNode decriptedConnection;
            foreach (var connection in dbConfigData.items)
            {
                decriptedConnection = connection.encrypted ? Decrypt(connection) : connection;
                decriptedfile.items.Add(decriptedConnection);
            }

            return decriptedfile;
        }

        private static DBConfigData Encrypt(DBConfigData decriptedfile)
        {
            DBConfigData encriptedfile = new DBConfigData();

            connectionNode encriptedConnection;
            foreach (var connection in decriptedfile.items)
            {
                encriptedConnection = connection.encrypted ? connection : Encrypt(connection);
                encriptedfile.items.Add(encriptedConnection);
            }

            return decriptedfile;
        }

        public static void WriteDBConfig(DBConfigData dbConfigData, string fileName, bool encrypt)
        {
            DBConfigData outDBConfigData = encrypt ? Encrypt(dbConfigData) : dbConfigData;
            using (TextWriter writer = new StreamWriter(fileName))
            {
                var xmlWriterSettings = new XmlWriterSettings
                {
                    Indent = true,
                    OmitXmlDeclaration = false,
                    Encoding = Encoding.UTF8
                };

                XmlWriter xmlWriter = XmlWriter.Create(writer, xmlWriterSettings);
                var serializer = new XmlSerializer(typeof(DBConfigData));
                serializer.Serialize(xmlWriter, outDBConfigData);
                writer.WriteLine();
            }
        }

        public static DBConfigData WriteDBConfig(DBConfigData dbConfigData, string fileName)
        {

            using (TextWriter writer = new StreamWriter(fileName))
            {
                var xmlWriterSettings = new XmlWriterSettings
                {
                    Indent = true,
                    OmitXmlDeclaration = false,
                    Encoding = Encoding.UTF8
                };

                XmlWriter xmlWriter = XmlWriter.Create(writer, xmlWriterSettings);
                var serializer = new XmlSerializer(typeof(DBConfigData));
                serializer.Serialize(xmlWriter, dbConfigData);
                writer.Flush();
            }

            return dbConfigData;
        }

        private static connectionNode Encrypt(connectionNode clearData)
        {
            return new connectionNode
            {
                encrypted = true,
                connectionString = clearData.connectionString,
                providerName = Encrypt(clearData.providerName, userKey),
                name = Encrypt(clearData.name, passwordKey),
            };
        }

        private static connectionNode Decrypt(connectionNode cipherData)
        {
            return new connectionNode
            {
                encrypted = false,
                connectionString = cipherData.connectionString,
                providerName = Decrypt(cipherData.providerName, userKey),
                name = Decrypt(cipherData.name, passwordKey),
            };
        }

        private static string Encrypt(string clearText, string key)
        {
            byte[] clearBytes = Encoding.Unicode.GetBytes(clearText);
            using (Aes encryptor = Aes.Create())
            {
                if (encryptor == null)
                {
                    throw new InvalidOperationException("Could not create Aes instance.");
                }

                var pdb = new Rfc2898DeriveBytes(key, Salt);
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                var ms = new MemoryStream();
                using (var cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                {
                    cs.Write(clearBytes, 0, clearBytes.Length);
                }

                return Convert.ToBase64String(ms.ToArray());
            }
        }

        private static string Decrypt(string cipherText, string key)
        {
            byte[] cipherBytes = Convert.FromBase64String(cipherText);
            using (Aes encryptor = Aes.Create())
            {
                if (encryptor == null)
                {
                    throw new InvalidOperationException("Could not create Aes instance.");
                }

                var pdb = new Rfc2898DeriveBytes(key, Salt);
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                var ms = new MemoryStream();
                using (var cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                {
                    cs.Write(cipherBytes, 0, cipherBytes.Length);
                }

                return Encoding.Unicode.GetString(ms.ToArray());
            }
        }
    }
}
