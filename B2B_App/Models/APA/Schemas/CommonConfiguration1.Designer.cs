
#pragma warning disable
namespace B2B_App
{
    using System;
    using System.Diagnostics;
    using System.Xml.Serialization;
    using System.Collections;
    using System.Xml.Schema;
    using System.ComponentModel;
    using System.IO;
    using System.Text;
    using System.Xml;
    using System.Threading.Tasks;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://tempuri.org/CommonConfiguration.xsd")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="http://tempuri.org/CommonConfiguration.xsd", IsNullable=false)]
    public partial class CommonConfiguration : System.ComponentModel.INotifyPropertyChanged
    {
        
        private CommonConfigurationDatabase _database;
        
        private CommonConfigurationBerlogicEngine _berlogicEngine;
        
        private CommonConfigurationSearchEngine _searchEngine;
        
        private System.DateTime _stateDate;
        
        private static XmlSerializer serializer;
        
        public async virtual Task SaveToFile(string fileName, Windows.Storage.StorageFolder folder)
        {
            var _option = Windows.Storage.CreationCollisionOption.ReplaceExisting;
            var _file = await folder.CreateFileAsync(fileName, _option);
            await Windows.Storage.FileIO.WriteTextAsync(_file, Serialize());
        }

        public static void SaveAltToFile(string fileName, CommonConfiguration xml,bool flag)
        {
            System.IO.FileStream file = null;
            System.IO.StreamWriter sr = null;

            try
            {
                file = new System.IO.FileStream(fileName, System.IO.FileMode.Create, System.IO.FileAccess.Write);
                sr = new System.IO.StreamWriter(file);
                string xmlString = xml.Serialize();
                sr.WriteLine(xmlString);
                sr.Dispose();
                file.Dispose();
            }
            finally
            {
                if ((file != null))
                {
                    file.Dispose();
                }
                if ((sr != null))
                {
                    sr.Dispose();
                }
            }
        }

        public static async Task<CommonConfiguration> LoadFromFile(string fileName, Windows.Storage.StorageFolder folder)
        {
            var _file = await folder.GetFileAsync(fileName);
            var xml = await Windows.Storage.FileIO.ReadTextAsync(_file);
            return Deserialize(xml);
        }
        public static bool LoadFromFile(string fileName, out CommonConfiguration obj, out System.Exception exception)
        {
            exception = null;
            obj = default(CommonConfiguration);
            try
            {
                obj = LoadFromFile(fileName);
                return true;
            }
            catch (System.Exception ex)
            {
                exception = ex;
                return false;
            }
        }
        public static bool LoadFromFile(string fileName, out CommonConfiguration obj)
        {
            System.Exception exception = null;
            return LoadFromFile(fileName, out obj, out exception);
        }

        public new static CommonConfiguration LoadFromFile(string fileName)
        {
            System.IO.FileStream file = null;
            System.IO.StreamReader sr = null;

            try
            {
                file=new FileStream(fileName,FileMode.Open,FileAccess.Read);
                sr = new System.IO.StreamReader(file);
                string xmlString = sr.ReadToEnd();
                sr.Dispose();
                file.Dispose();
                return Deserialize(xmlString);
            }
            finally
            {
                if ((file != null))
                {
                    file.Dispose();
                }
                if ((sr != null))
                {
                    sr.Dispose();
                }
            }
        }

        public CommonConfiguration()
        {
            this._searchEngine = new CommonConfigurationSearchEngine();
            this._berlogicEngine = new CommonConfigurationBerlogicEngine();
            this._database = new CommonConfigurationDatabase();
        }
        
        public CommonConfigurationDatabase Database
        {
            get
            {
                return this._database;
            }
            set
            {
                if ((this._database == value))
                {
                    return;
                }
                if (((this._database == null) 
                            || (_database.Equals(value) != true)))
                {
                    this._database = value;
                    this.OnPropertyChanged("Database");
                }
            }
        }
        
        public CommonConfigurationBerlogicEngine BerlogicEngine
        {
            get
            {
                return this._berlogicEngine;
            }
            set
            {
                if ((this._berlogicEngine == value))
                {
                    return;
                }
                if (((this._berlogicEngine == null) 
                            || (_berlogicEngine.Equals(value) != true)))
                {
                    this._berlogicEngine = value;
                    this.OnPropertyChanged("BerlogicEngine");
                }
            }
        }
        
        public CommonConfigurationSearchEngine SearchEngine
        {
            get
            {
                return this._searchEngine;
            }
            set
            {
                if ((this._searchEngine == value))
                {
                    return;
                }
                if (((this._searchEngine == null) 
                            || (_searchEngine.Equals(value) != true)))
                {
                    this._searchEngine = value;
                    this.OnPropertyChanged("SearchEngine");
                }
            }
        }
        
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public System.DateTime StateDate
        {
            get
            {
                return this._stateDate;
            }
            set
            {
                if ((_stateDate.Equals(value) != true))
                {
                    this._stateDate = value;
                    this.OnPropertyChanged("StateDate");
                }
            }
        }
        
        private static XmlSerializer Serializer
        {
            get
            {
                if ((serializer == null))
                {
                    serializer = new System.Xml.Serialization.XmlSerializer(typeof(CommonConfiguration));
                }
                return serializer;
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        public virtual void OnPropertyChanged(string propertyName)
        {
            System.ComponentModel.PropertyChangedEventHandler handler = this.PropertyChanged;
            if ((handler != null))
            {
                handler(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
        
        #region Serialize/Deserialize
        /// <summary>
        /// Serializes current CommonConfiguration object into an XML string
        /// </summary>
        /// <returns>string XML value</returns>
        public virtual string Serialize()
        {
            System.IO.StreamReader streamReader = null;
            System.IO.MemoryStream memoryStream = null;
            try
            {
                memoryStream = new System.IO.MemoryStream();
                System.Xml.XmlWriterSettings xmlWriterSettings = new System.Xml.XmlWriterSettings();
                xmlWriterSettings.Indent = true;
                System.Xml.XmlWriter xmlWriter = XmlWriter.Create(memoryStream, xmlWriterSettings);
                Serializer.Serialize(xmlWriter, this);
                memoryStream.Seek(0, System.IO.SeekOrigin.Begin);
                streamReader = new System.IO.StreamReader(memoryStream);
                return streamReader.ReadToEnd();
            }
            finally
            {
                if ((streamReader != null))
                {
                    streamReader.Dispose();
                }
                if ((memoryStream != null))
                {
                    memoryStream.Dispose();
                }
            }
        }
        
        /// <summary>
        /// Deserializes workflow markup into an CommonConfiguration object
        /// </summary>
        /// <param name="input">string workflow markup to deserialize</param>
        /// <param name="obj">Output CommonConfiguration object</param>
        /// <param name="exception">output Exception value if deserialize failed</param>
        /// <returns>true if this Serializer can deserialize the object; otherwise, false</returns>
        public static bool Deserialize(string input, out CommonConfiguration obj, out System.Exception exception)
        {
            exception = null;
            obj = default(CommonConfiguration);
            try
            {
                obj = Deserialize(input);
                return true;
            }
            catch (System.Exception ex)
            {
                exception = ex;
                return false;
            }
        }
        
        public static bool Deserialize(string input, out CommonConfiguration obj)
        {
            System.Exception exception = null;
            return Deserialize(input, out obj, out exception);
        }
        
        public new static CommonConfiguration Deserialize(string input)
        {
            System.IO.StringReader stringReader = null;
            try
            {
                stringReader = new System.IO.StringReader(input);
                return ((CommonConfiguration)(Serializer.Deserialize(System.Xml.XmlReader.Create(stringReader))));
            }
            finally
            {
                if ((stringReader != null))
                {
                    stringReader.Dispose();
                }
            }
        }
        
        public static CommonConfiguration Deserialize(System.IO.Stream s)
        {
            return ((CommonConfiguration)(Serializer.Deserialize(s)));
        }
        #endregion
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://tempuri.org/CommonConfiguration.xsd")]
    public partial class CommonConfigurationDatabase : System.ComponentModel.INotifyPropertyChanged
    {
        
        private string _host;
        
        private string _remoteHost;
        
        private int _port;
        
        private string _user;
        
        private string _password;
        
        private string _name;
        
        private static XmlSerializer serializer;
        
        public async virtual void SaveToFile(string fileName, Windows.Storage.StorageFolder folder)
        {
            var _option = Windows.Storage.CreationCollisionOption.ReplaceExisting;
            var _file = await folder.CreateFileAsync(fileName, _option);
            await Windows.Storage.FileIO.WriteTextAsync(_file, Serialize());
        }
        public static async Task<CommonConfigurationDatabase> LoadFromFile(string fileName, Windows.Storage.StorageFolder folder)
        {
            var _file = await folder.GetFileAsync(fileName);
            var xml = await Windows.Storage.FileIO.ReadTextAsync(_file);
            return Deserialize(xml);
        }
        
        public CommonConfigurationDatabase()
        {
            this._port = 3306;
            this._user = "root";
        }
        
        public string Host
        {
            get
            {
                return this._host;
            }
            set
            {
                if ((this._host == value))
                {
                    return;
                }
                if (((this._host == null) 
                            || (_host.Equals(value) != true)))
                {
                    this._host = value;
                    this.OnPropertyChanged("Host");
                }
            }
        }
        
        public string RemoteHost
        {
            get
            {
                return this._remoteHost;
            }
            set
            {
                if ((this._remoteHost == value))
                {
                    return;
                }
                if (((this._remoteHost == null) 
                            || (_remoteHost.Equals(value) != true)))
                {
                    this._remoteHost = value;
                    this.OnPropertyChanged("RemoteHost");
                }
            }
        }
        
        public int Port
        {
            get
            {
                return this._port;
            }
            set
            {
                if ((_port.Equals(value) != true))
                {
                    this._port = value;
                    this.OnPropertyChanged("Port");
                }
            }
        }
        
        public string User
        {
            get
            {
                return this._user;
            }
            set
            {
                if ((this._user == value))
                {
                    return;
                }
                if (((this._user == null) 
                            || (_user.Equals(value) != true)))
                {
                    this._user = value;
                    this.OnPropertyChanged("User");
                }
            }
        }
        
        public string Password
        {
            get
            {
                return this._password;
            }
            set
            {
                if ((this._password == value))
                {
                    return;
                }
                if (((this._password == null) 
                            || (_password.Equals(value) != true)))
                {
                    this._password = value;
                    this.OnPropertyChanged("Password");
                }
            }
        }
        
        public string Name
        {
            get
            {
                return this._name;
            }
            set
            {
                if ((this._name == value))
                {
                    return;
                }
                if (((this._name == null) 
                            || (_name.Equals(value) != true)))
                {
                    this._name = value;
                    this.OnPropertyChanged("Name");
                }
            }
        }
        
        private static XmlSerializer Serializer
        {
            get
            {
                if ((serializer == null))
                {
                    serializer = new System.Xml.Serialization.XmlSerializer(typeof(CommonConfigurationDatabase));
                }
                return serializer;
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        public virtual void OnPropertyChanged(string propertyName)
        {
            System.ComponentModel.PropertyChangedEventHandler handler = this.PropertyChanged;
            if ((handler != null))
            {
                handler(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
        
        #region Serialize/Deserialize
        /// <summary>
        /// Serializes current CommonConfigurationDatabase object into an XML string
        /// </summary>
        /// <returns>string XML value</returns>
        public virtual string Serialize()
        {
            System.IO.StreamReader streamReader = null;
            System.IO.MemoryStream memoryStream = null;
            try
            {
                memoryStream = new System.IO.MemoryStream();
                System.Xml.XmlWriterSettings xmlWriterSettings = new System.Xml.XmlWriterSettings();
                xmlWriterSettings.Indent = true;
                System.Xml.XmlWriter xmlWriter = XmlWriter.Create(memoryStream, xmlWriterSettings);
                Serializer.Serialize(xmlWriter, this);
                memoryStream.Seek(0, System.IO.SeekOrigin.Begin);
                streamReader = new System.IO.StreamReader(memoryStream);
                return streamReader.ReadToEnd();
            }
            finally
            {
                if ((streamReader != null))
                {
                    streamReader.Dispose();
                }
                if ((memoryStream != null))
                {
                    memoryStream.Dispose();
                }
            }
        }
        
        /// <summary>
        /// Deserializes workflow markup into an CommonConfigurationDatabase object
        /// </summary>
        /// <param name="input">string workflow markup to deserialize</param>
        /// <param name="obj">Output CommonConfigurationDatabase object</param>
        /// <param name="exception">output Exception value if deserialize failed</param>
        /// <returns>true if this Serializer can deserialize the object; otherwise, false</returns>
        public static bool Deserialize(string input, out CommonConfigurationDatabase obj, out System.Exception exception)
        {
            exception = null;
            obj = default(CommonConfigurationDatabase);
            try
            {
                obj = Deserialize(input);
                return true;
            }
            catch (System.Exception ex)
            {
                exception = ex;
                return false;
            }
        }
        
        public static bool Deserialize(string input, out CommonConfigurationDatabase obj)
        {
            System.Exception exception = null;
            return Deserialize(input, out obj, out exception);
        }
        
        public new static CommonConfigurationDatabase Deserialize(string input)
        {
            System.IO.StringReader stringReader = null;
            try
            {
                stringReader = new System.IO.StringReader(input);
                return ((CommonConfigurationDatabase)(Serializer.Deserialize(System.Xml.XmlReader.Create(stringReader))));
            }
            finally
            {
                if ((stringReader != null))
                {
                    stringReader.Dispose();
                }
            }
        }
        
        public static CommonConfigurationDatabase Deserialize(System.IO.Stream s)
        {
            return ((CommonConfigurationDatabase)(Serializer.Deserialize(s)));
        }
        #endregion
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://tempuri.org/CommonConfiguration.xsd")]
    public partial class CommonConfigurationBerlogicEngine : System.ComponentModel.INotifyPropertyChanged
    {
        
        private CommonConfigurationBerlogicEngineAgency _agency;
        
        private static XmlSerializer serializer;
        
        public async virtual void SaveToFile(string fileName, Windows.Storage.StorageFolder folder)
        {
            var _option = Windows.Storage.CreationCollisionOption.ReplaceExisting;
            var _file = await folder.CreateFileAsync(fileName, _option);
            await Windows.Storage.FileIO.WriteTextAsync(_file, Serialize());
        }
        public static async Task<CommonConfigurationBerlogicEngine> LoadFromFile(string fileName, Windows.Storage.StorageFolder folder)
        {
            var _file = await folder.GetFileAsync(fileName);
            var xml = await Windows.Storage.FileIO.ReadTextAsync(_file);
            return Deserialize(xml);
        }
        
        public CommonConfigurationBerlogicEngine()
        {
            this._agency = new CommonConfigurationBerlogicEngineAgency();
        }
        
        public CommonConfigurationBerlogicEngineAgency Agency
        {
            get
            {
                return this._agency;
            }
            set
            {
                if ((this._agency == value))
                {
                    return;
                }
                if (((this._agency == null) 
                            || (_agency.Equals(value) != true)))
                {
                    this._agency = value;
                    this.OnPropertyChanged("Agency");
                }
            }
        }
        
        private static XmlSerializer Serializer
        {
            get
            {
                if ((serializer == null))
                {
                    serializer = new System.Xml.Serialization.XmlSerializer(typeof(CommonConfigurationBerlogicEngine));
                }
                return serializer;
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        public virtual void OnPropertyChanged(string propertyName)
        {
            System.ComponentModel.PropertyChangedEventHandler handler = this.PropertyChanged;
            if ((handler != null))
            {
                handler(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
        
        #region Serialize/Deserialize
        /// <summary>
        /// Serializes current CommonConfigurationBerlogicEngine object into an XML string
        /// </summary>
        /// <returns>string XML value</returns>
        public virtual string Serialize()
        {
            System.IO.StreamReader streamReader = null;
            System.IO.MemoryStream memoryStream = null;
            try
            {
                memoryStream = new System.IO.MemoryStream();
                System.Xml.XmlWriterSettings xmlWriterSettings = new System.Xml.XmlWriterSettings();
                xmlWriterSettings.Indent = true;
                System.Xml.XmlWriter xmlWriter = XmlWriter.Create(memoryStream, xmlWriterSettings);
                Serializer.Serialize(xmlWriter, this);
                memoryStream.Seek(0, System.IO.SeekOrigin.Begin);
                streamReader = new System.IO.StreamReader(memoryStream);
                return streamReader.ReadToEnd();
            }
            finally
            {
                if ((streamReader != null))
                {
                    streamReader.Dispose();
                }
                if ((memoryStream != null))
                {
                    memoryStream.Dispose();
                }
            }
        }
        
        /// <summary>
        /// Deserializes workflow markup into an CommonConfigurationBerlogicEngine object
        /// </summary>
        /// <param name="input">string workflow markup to deserialize</param>
        /// <param name="obj">Output CommonConfigurationBerlogicEngine object</param>
        /// <param name="exception">output Exception value if deserialize failed</param>
        /// <returns>true if this Serializer can deserialize the object; otherwise, false</returns>
        public static bool Deserialize(string input, out CommonConfigurationBerlogicEngine obj, out System.Exception exception)
        {
            exception = null;
            obj = default(CommonConfigurationBerlogicEngine);
            try
            {
                obj = Deserialize(input);
                return true;
            }
            catch (System.Exception ex)
            {
                exception = ex;
                return false;
            }
        }
        
        public static bool Deserialize(string input, out CommonConfigurationBerlogicEngine obj)
        {
            System.Exception exception = null;
            return Deserialize(input, out obj, out exception);
        }
        
        public new static CommonConfigurationBerlogicEngine Deserialize(string input)
        {
            System.IO.StringReader stringReader = null;
            try
            {
                stringReader = new System.IO.StringReader(input);
                return ((CommonConfigurationBerlogicEngine)(Serializer.Deserialize(System.Xml.XmlReader.Create(stringReader))));
            }
            finally
            {
                if ((stringReader != null))
                {
                    stringReader.Dispose();
                }
            }
        }
        
        public static CommonConfigurationBerlogicEngine Deserialize(System.IO.Stream s)
        {
            return ((CommonConfigurationBerlogicEngine)(Serializer.Deserialize(s)));
        }
        #endregion
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://tempuri.org/CommonConfiguration.xsd")]
    public partial class CommonConfigurationBerlogicEngineAgency : System.ComponentModel.INotifyPropertyChanged
    {
        
        private string _name;
        
        private string _number;
        
        private string _salespoint;
        
        private string _password;
        
        private static XmlSerializer serializer;
        
        public async virtual void SaveToFile(string fileName, Windows.Storage.StorageFolder folder)
        {
            var _option = Windows.Storage.CreationCollisionOption.ReplaceExisting;
            var _file = await folder.CreateFileAsync(fileName, _option);
            await Windows.Storage.FileIO.WriteTextAsync(_file, Serialize());
        }
        public static async Task<CommonConfigurationBerlogicEngineAgency> LoadFromFile(string fileName, Windows.Storage.StorageFolder folder)
        {
            var _file = await folder.GetFileAsync(fileName);
            var xml = await Windows.Storage.FileIO.ReadTextAsync(_file);
            return Deserialize(xml);
        }
        
        public string Name
        {
            get
            {
                return this._name;
            }
            set
            {
                if ((this._name == value))
                {
                    return;
                }
                if (((this._name == null) 
                            || (_name.Equals(value) != true)))
                {
                    this._name = value;
                    this.OnPropertyChanged("Name");
                }
            }
        }
        
        public string Number
        {
            get
            {
                return this._number;
            }
            set
            {
                if ((this._number == value))
                {
                    return;
                }
                if (((this._number == null) 
                            || (_number.Equals(value) != true)))
                {
                    this._number = value;
                    this.OnPropertyChanged("Number");
                }
            }
        }
        
        public string Salespoint
        {
            get
            {
                return this._salespoint;
            }
            set
            {
                if ((this._salespoint == value))
                {
                    return;
                }
                if (((this._salespoint == null) 
                            || (_salespoint.Equals(value) != true)))
                {
                    this._salespoint = value;
                    this.OnPropertyChanged("Salespoint");
                }
            }
        }
        
        public string Password
        {
            get
            {
                return this._password;
            }
            set
            {
                if ((this._password == value))
                {
                    return;
                }
                if (((this._password == null) 
                            || (_password.Equals(value) != true)))
                {
                    this._password = value;
                    this.OnPropertyChanged("Password");
                }
            }
        }
        
        private static XmlSerializer Serializer
        {
            get
            {
                if ((serializer == null))
                {
                    serializer = new System.Xml.Serialization.XmlSerializer(typeof(CommonConfigurationBerlogicEngineAgency));
                }
                return serializer;
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        public virtual void OnPropertyChanged(string propertyName)
        {
            System.ComponentModel.PropertyChangedEventHandler handler = this.PropertyChanged;
            if ((handler != null))
            {
                handler(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
        
        #region Serialize/Deserialize
        /// <summary>
        /// Serializes current CommonConfigurationBerlogicEngineAgency object into an XML string
        /// </summary>
        /// <returns>string XML value</returns>
        public virtual string Serialize()
        {
            System.IO.StreamReader streamReader = null;
            System.IO.MemoryStream memoryStream = null;
            try
            {
                memoryStream = new System.IO.MemoryStream();
                System.Xml.XmlWriterSettings xmlWriterSettings = new System.Xml.XmlWriterSettings();
                xmlWriterSettings.Indent = true;
                System.Xml.XmlWriter xmlWriter = XmlWriter.Create(memoryStream, xmlWriterSettings);
                Serializer.Serialize(xmlWriter, this);
                memoryStream.Seek(0, System.IO.SeekOrigin.Begin);
                streamReader = new System.IO.StreamReader(memoryStream);
                return streamReader.ReadToEnd();
            }
            finally
            {
                if ((streamReader != null))
                {
                    streamReader.Dispose();
                }
                if ((memoryStream != null))
                {
                    memoryStream.Dispose();
                }
            }
        }
        
        /// <summary>
        /// Deserializes workflow markup into an CommonConfigurationBerlogicEngineAgency object
        /// </summary>
        /// <param name="input">string workflow markup to deserialize</param>
        /// <param name="obj">Output CommonConfigurationBerlogicEngineAgency object</param>
        /// <param name="exception">output Exception value if deserialize failed</param>
        /// <returns>true if this Serializer can deserialize the object; otherwise, false</returns>
        public static bool Deserialize(string input, out CommonConfigurationBerlogicEngineAgency obj, out System.Exception exception)
        {
            exception = null;
            obj = default(CommonConfigurationBerlogicEngineAgency);
            try
            {
                obj = Deserialize(input);
                return true;
            }
            catch (System.Exception ex)
            {
                exception = ex;
                return false;
            }
        }
        
        public static bool Deserialize(string input, out CommonConfigurationBerlogicEngineAgency obj)
        {
            System.Exception exception = null;
            return Deserialize(input, out obj, out exception);
        }
        
        public new static CommonConfigurationBerlogicEngineAgency Deserialize(string input)
        {
            System.IO.StringReader stringReader = null;
            try
            {
                stringReader = new System.IO.StringReader(input);
                return ((CommonConfigurationBerlogicEngineAgency)(Serializer.Deserialize(System.Xml.XmlReader.Create(stringReader))));
            }
            finally
            {
                if ((stringReader != null))
                {
                    stringReader.Dispose();
                }
            }
        }
        
        public static CommonConfigurationBerlogicEngineAgency Deserialize(System.IO.Stream s)
        {
            return ((CommonConfigurationBerlogicEngineAgency)(Serializer.Deserialize(s)));
        }
        #endregion
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://tempuri.org/CommonConfiguration.xsd")]
    public partial class CommonConfigurationSearchEngine : System.ComponentModel.INotifyPropertyChanged
    {
        
        private int _pageLimit;
        
        private int _formLimit;
        
        private int _searchLimit;
        
        private static XmlSerializer serializer;
        
        public async virtual void SaveToFile(string fileName, Windows.Storage.StorageFolder folder)
        {
            var _option = Windows.Storage.CreationCollisionOption.ReplaceExisting;
            var _file = await folder.CreateFileAsync(fileName, _option);
            await Windows.Storage.FileIO.WriteTextAsync(_file, Serialize());
        }
        public static async Task<CommonConfigurationSearchEngine> LoadFromFile(string fileName, Windows.Storage.StorageFolder folder)
        {
            var _file = await folder.GetFileAsync(fileName);
            var xml = await Windows.Storage.FileIO.ReadTextAsync(_file);
            return Deserialize(xml);
        }
        
        public CommonConfigurationSearchEngine()
        {
            this._pageLimit = 1;
            this._formLimit = 2;
            this._searchLimit = 5;
        }
        
        public int PageLimit
        {
            get
            {
                return this._pageLimit;
            }
            set
            {
                if ((_pageLimit.Equals(value) != true))
                {
                    this._pageLimit = value;
                    this.OnPropertyChanged("PageLimit");
                }
            }
        }
        
        public int FormLimit
        {
            get
            {
                return this._formLimit;
            }
            set
            {
                if ((_formLimit.Equals(value) != true))
                {
                    this._formLimit = value;
                    this.OnPropertyChanged("FormLimit");
                }
            }
        }
        
        public int SearchLimit
        {
            get
            {
                return this._searchLimit;
            }
            set
            {
                if ((_searchLimit.Equals(value) != true))
                {
                    this._searchLimit = value;
                    this.OnPropertyChanged("SearchLimit");
                }
            }
        }
        
        private static XmlSerializer Serializer
        {
            get
            {
                if ((serializer == null))
                {
                    serializer = new System.Xml.Serialization.XmlSerializer(typeof(CommonConfigurationSearchEngine));
                }
                return serializer;
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        public virtual void OnPropertyChanged(string propertyName)
        {
            System.ComponentModel.PropertyChangedEventHandler handler = this.PropertyChanged;
            if ((handler != null))
            {
                handler(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
        
        #region Serialize/Deserialize
        /// <summary>
        /// Serializes current CommonConfigurationSearchEngine object into an XML string
        /// </summary>
        /// <returns>string XML value</returns>
        public virtual string Serialize()
        {
            System.IO.StreamReader streamReader = null;
            System.IO.MemoryStream memoryStream = null;
            try
            {
                memoryStream = new System.IO.MemoryStream();
                System.Xml.XmlWriterSettings xmlWriterSettings = new System.Xml.XmlWriterSettings();
                xmlWriterSettings.Indent = true;
                System.Xml.XmlWriter xmlWriter = XmlWriter.Create(memoryStream, xmlWriterSettings);
                Serializer.Serialize(xmlWriter, this);
                memoryStream.Seek(0, System.IO.SeekOrigin.Begin);
                streamReader = new System.IO.StreamReader(memoryStream);
                return streamReader.ReadToEnd();
            }
            finally
            {
                if ((streamReader != null))
                {
                    streamReader.Dispose();
                }
                if ((memoryStream != null))
                {
                    memoryStream.Dispose();
                }
            }
        }
        
        /// <summary>
        /// Deserializes workflow markup into an CommonConfigurationSearchEngine object
        /// </summary>
        /// <param name="input">string workflow markup to deserialize</param>
        /// <param name="obj">Output CommonConfigurationSearchEngine object</param>
        /// <param name="exception">output Exception value if deserialize failed</param>
        /// <returns>true if this Serializer can deserialize the object; otherwise, false</returns>
        public static bool Deserialize(string input, out CommonConfigurationSearchEngine obj, out System.Exception exception)
        {
            exception = null;
            obj = default(CommonConfigurationSearchEngine);
            try
            {
                obj = Deserialize(input);
                return true;
            }
            catch (System.Exception ex)
            {
                exception = ex;
                return false;
            }
        }
        
        public static bool Deserialize(string input, out CommonConfigurationSearchEngine obj)
        {
            System.Exception exception = null;
            return Deserialize(input, out obj, out exception);
        }
        
        public new static CommonConfigurationSearchEngine Deserialize(string input)
        {
            System.IO.StringReader stringReader = null;
            try
            {
                stringReader = new System.IO.StringReader(input);
                return ((CommonConfigurationSearchEngine)(Serializer.Deserialize(System.Xml.XmlReader.Create(stringReader))));
            }
            finally
            {
                if ((stringReader != null))
                {
                    stringReader.Dispose();
                }
            }
        }
        
        public static CommonConfigurationSearchEngine Deserialize(System.IO.Stream s)
        {
            return ((CommonConfigurationSearchEngine)(Serializer.Deserialize(s)));
        }
        #endregion
    }
}
#pragma warning restore
