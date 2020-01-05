

namespace Inflexion2.Infrastructure
{
    using Logging;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Configuration;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;
    using System.Security.Cryptography;
    using Inflexion2.Extensions;

    /// <summary>
    /// Singleton instance base class to manage a collection of global key - typed values 
    /// from different saved sources like internal configuration files, data bases.
    /// Every single module has his own instance.
    /// </summary>
    public class ApplicationSettings
    {

        #region Constants

        /// <summary>
        /// Default Name Connection, this name is the only one that has to exist in the 
        /// file for database connections configuration;
        /// </summary>
        public const string DefaultNameConnection = "Default";

        /// <summary>
        /// Key name in appsettings inside web. config o app.config associated 
        /// to the database config file with the possible connection strings.
        /// One of the connections string has to have the name default.
        /// </summary>
        public const string appsettingsKey4DbconfigFile = "DbConfigFile";

        /// <summary>
        /// 
        /// </summary>
        public const string appsettingsKey4SelectedDb = "SelectedDB";

        private const string UserMark = "User Id=";
        private const string PasswordMark = "Password=";
        private const string SeparatorMark = ";";
        #endregion

        #region fields

        /// <summary>
        /// 
        /// </summary>
        private ILogger logger_;
        protected string userKey = "kbGtg5euTZPUtafUw"; // encrpting key for user
        protected string passwordKey = "t7SB5gftqkkdTgLdH"; // encripting key for password

        // collection of application settings loaded from DB
        private readonly Dictionary<string, dynamic> propertyMap = new Dictionary<string, dynamic>();

        //private static readonly ILog Log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private static readonly Lazy<ApplicationSettings> LazyInstance = new Lazy<ApplicationSettings>(() => new ApplicationSettings());
        private string selectedRepositoryConnection_;
        private static readonly byte[] Salt = new byte[] { 0xa4, 0xea, 0xda, 0x7c, 0xef, 0x5d, 0x7a, 0x9d, 0xc3, 0x7d, 0x28, 0xe9, 0xef };
        private static DBConfigData config;
        #endregion

        #region Properties

        /// <summary>
        /// public access to current looger function
        /// </summary>
        public ILogger Logger
        {
            get
            {
                return logger_;
            }
        }

        /// <summary>
        /// Singleton lazy instance
        /// this property help to use an instance class with a constructor and combines static functions and fields. 
        /// </summary>
        public static ApplicationSettings Instance
        {
            get
            {
                return LazyInstance.Value;
            }
        }

        /// <summary>
        /// Setting to enable or disable the current module
        /// </summary>
        public bool ModuleEnabled { get; private set; }

        /// <summary>
        /// This property returns if the current repository is readonly or not
        /// </summary>
        public bool ReadOnlyRepository { get; private set; }

        /// <summary>
        /// This property returns the email address for help to the end users
        /// </summary>
        public string FeedbackEmailAddress { get; private set; }

        /// <summary>
        /// This property returns the name of the current repository selected. 
        /// </summary>
        public string SelectedRepositoryConnection
        {
            get
            {
                if (selectedRepositoryConnection_ == null)
                {
                    selectedRepositoryConnection_ = DefaultNameConnection;
                }

                return selectedRepositoryConnection_;
            }
            private set
            {
                if (value != null && Config.items.FirstOrDefault(c => c.name == value) != null)
                {
                    selectedRepositoryConnection_ = value;
                }
                else
                {
                    selectedRepositoryConnection_ = DefaultNameConnection;
                }
            }
        }

        /// <summary>
        /// This property returns the arguments values to execute this module.
        /// this arguments can came from the execution of desktop application or from an app.config
        /// one of the most important argument is "\db=name of repository to use"
        /// In this way is posible to select one of all database enviroments you can have 
        /// (development, test, preproduction or production)
        /// </summary>
        public string[] Args { get; private set; }

        /// <summary>
        /// This property returns the current repository conection string using 
        /// the current SelectedRepositoryConnection.
        /// </summary>
        //public string CurrentRepositoryConnectionString
        //{
        //    get
        //    {
        //        if (ConnectionsStrings != null)
        //        {
        //            return ConnectionsStrings[SelectedRepositoryConnection];
        //        }

        //        return null;
        //    }
        //}

        /// <summary>
        /// 
        /// </summary>
        //public Dictionary<string, string> ConnectionsStrings { get; private set; }

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

        public connectionNode SelectedConnection
        {
            get
            {
                var temp = config.items.FirstOrDefault(c => c.name.ToLower().Contains(this.SelectedRepositoryConnection.ToLower()));
                if (temp == null)
                {
                    throw new InvalidOperationException("There is not default connection string defined in dbconfig.xml file.");
                }

                return temp;
            }
        }
        #endregion

        #region Constructors

        /// <summary>
        /// Parameterless constructor to set default values.
        /// </summary>
        protected ApplicationSettings()
        {
            this.ModuleEnabled = true;
            this.ReadOnlyRepository = false;
            this.FeedbackEmailAddress = null;
            this.logger_ = LogManager.GetLogger();
        }


        #endregion


        #region Public Methods

        /// <summary>
        /// 
        /// </summary>
        /// <param name="typeinit"></param>
        public void SetLogger(Type typeinit)
        {
            this.logger_ = LogManager.GetLogger(typeinit);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        public void ReadBasicPropertiesFromConfig(string[] args = null)
        {
            SetUpArguments(args);
            SelectDbConectionFromArguments();
        }

        /// <summary>
        /// SetUp Arguments int the holder field Args reading from .config appsettings or from interactive enviroemnt (console, wpf, etc) arguments
        /// </summary>
        /// <param name="args"></param>
        public void SetUpArguments(string[] args)
        {
            if (args != null && args.Count() > 1)
            {
                this.Args = args;
            }
            else
            {
                string temp = GetAppSetting("Args");//System.Configuration.ConfigurationManager.AppSettings["Args"];
                if (temp != null)
                {
                    this.Args = temp.Split(' ');
                }
            }
        }


        /// <summary>
        /// setup the db connection from the Args field or default
        /// </summary>
        public void SelectDbConectionFromArguments()
        {
            if (this.Args != null && this.Args.Length > 0)
            {
                // check if there is an option to select a database connection
                string temp = this.Args.FirstOrDefault(c => c != null && c.ToLower().StartsWith(Arguments.DbConnect));
                string name = temp.IsNullOrEmpty() ? null : temp.Substring(Arguments.DbConnect.Length);
                SetDatabaseConnectionByName(name);
            }
            else
            {
                // there is not args use the dbconfig 

                string dbConfigFileName = GetAppSetting(appsettingsKey4DbconfigFile);
                //string temp = GetAppSetting(appsettingsKey4SelectedDb); // SelectedRepositoryConnection
                string fullPath = GetPathRelativeToExecutable(dbConfigFileName);
                ReadDBConfig(fullPath);

            }
        }

        public static string GetAppSetting(string name)
        {
            string value = System.Configuration.ConfigurationManager.AppSettings.Get(name);
            if (string.IsNullOrEmpty(value))
            {
                ApplicationSettings.Instance.Logger.Debug(string.Format(CultureInfo.InvariantCulture, string.Format("AppSettings '{0}' is missing.", name)));
                return null;
            }

            return value;
        }

        /// <summary>
        /// get the current root path from the applications is runnig covering desktop and http apps.
        /// </summary>
        /// <param name="fileName">file name to combine with root execution path</param>
        /// <returns>Executable path combined with the file name in the parameter</returns>
        public static string GetPathRelativeToExecutable(string fileName)
        {
            string baseDir;

            if (System.Web.HttpContext.Current != null) // if is not a web application 
            {
                baseDir = System.Web.HttpRuntime.BinDirectory;
            }
            else // is a windows service or desktop application
            {
                baseDir = AppDomain.CurrentDomain.BaseDirectory;
            }

            return System.IO.Path.Combine(baseDir, fileName);
        }

        /// <summary>
        /// override this methood to load specific setting from the current selected repository 
        /// </summary>
        public virtual void LoadDatabaseProperties()
        {

        }
        #endregion

        #region Private Methods
        private void SetDatabaseConnectionByName(string partialName)
        {
            this.SelectedRepositoryConnection = partialName;
        }

        #endregion

        #region DB config managment         
        /// <summary>
        /// https://stackoverflow.com/questions/5069099/when-a-class-is-inherited-from-list-xmlserializer-doesnt-serialize-other-att
        /// </summary>
        [XmlRoot("dbconfig")]
        public class DBConfigData
        {
            [XmlArray("connectionStrings"), XmlArrayItem("dbConnection")]
            public List<connectionNode> items = new List<connectionNode>();
        }

        /// <summary>
        /// internal helper class to administrate different conections string from a xml file defined in appsetings of main module
        /// </summary>
        public class connectionNode
        {

            /// <summary>
            /// Name of the connection in the xml file. The values of the names in the xml file can not be repeated
            /// </summary>
            [XmlAttribute("name")]
            public string name { get; set; }

            /// <summary>
            /// string connection
            /// </summary>
            [XmlAttribute("connectionString")]
            public string connectionString { get; set; }

            /// <summary>
            /// database or repository provider
            /// </summary>
            [XmlAttribute("providerName")]
            public string providerName { get; set; }

            /// <summary>
            /// flag to indicate if the user id and paswword in the string connection are encripted
            /// </summary>
            [XmlAttribute("encrypted")]
            public bool encrypted { get; set; }

            /// <summary>
            /// runtime flag to indicate if this connection is in use
            /// </summary>
            public bool ConnectedDB
            {
                get
                {
                    return ApplicationSettings.Instance.SelectedConnection.name == this.name;
                }
            }

            /// <summary>
            /// function to encript the values of user id and password in the xml file for the current connection string
            /// </summary>
            public void EncryptUserPasword()
            {
                string user = GetUser();
                string password = GetPassword();

                string encriptedUser = Encrypt(user, ApplicationSettings.Instance.userKey);
                string encriptedPassword = Encrypt(password, ApplicationSettings.Instance.passwordKey);

                this.connectionString = this.connectionString.Replace(UserMark + user + SeparatorMark, UserMark + encriptedUser + SeparatorMark);
                this.connectionString = this.connectionString.Replace(PasswordMark + password + SeparatorMark, PasswordMark + encriptedPassword + SeparatorMark);
                this.encrypted = true;
                string fileName = ApplicationSettings.GetAppSetting(appsettingsKey4DbconfigFile);
                string selectedconnection = ApplicationSettings.GetAppSetting(appsettingsKey4DbconfigFile);

                Config = ApplicationSettings.WriteDBConfig(ApplicationSettings.Config, fileName);
            }

            /// <summary>
            /// function to decript the values of user id and password in the xml file for the current connection string
            /// </summary>
            public string GetDecryptedConnectionString()
            {
                if (!this.encrypted)
                {
                    return this.connectionString;
                }
                else
                {
                    string encriptedUser = this.connectionString.Substring(UserMark, SeparatorMark);
                    string user = GetUser();
                    string encriptedPassword = this.connectionString.Substring(PasswordMark, SeparatorMark);

                    string password = GetPassword();

                    var temp = this.connectionString.Replace(UserMark + encriptedUser + SeparatorMark, UserMark + user + SeparatorMark);
                    temp = temp.Replace(PasswordMark + encriptedPassword + SeparatorMark, PasswordMark + password + SeparatorMark);
                    return temp;
                }

            }

            /// <summary>
            /// search and get the password value in the current connection string
            /// </summary>
            /// <returns></returns>
            public string GetPassword()
            {
                string password = this.connectionString.Substring(PasswordMark, SeparatorMark);

                if (this.encrypted)
                {
                    return Decrypt(password, ApplicationSettings.Instance.passwordKey);
                }
                else
                {
                    return password;
                }
            }

            /// <summary>
            /// search and get the user id value in the current connection string
            /// </summary>
            /// <returns></returns>
            public string GetUser()
            {
                string user = this.connectionString.Substring(UserMark, SeparatorMark);

                if (this.encrypted)
                {
                    return Decrypt(user, ApplicationSettings.Instance.userKey);
                }
                else
                {
                    return user;
                }
            }


        }

        /// <summary>
        /// Read and deserialize db config file and save it in the Config property
        /// </summary>
        /// <param name="fileName"></param>
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
                providerName = Encrypt(clearData.providerName, ApplicationSettings.Instance.userKey),
                name = Encrypt(clearData.name, ApplicationSettings.Instance.passwordKey),
            };
        }

        private static connectionNode Decrypt(connectionNode cipherData)
        {
            return new connectionNode
            {
                encrypted = false,
                connectionString = cipherData.connectionString,
                providerName = Decrypt(cipherData.providerName, ApplicationSettings.Instance.userKey),
                name = Decrypt(cipherData.name, ApplicationSettings.Instance.passwordKey),
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
        #endregion

    }
}
