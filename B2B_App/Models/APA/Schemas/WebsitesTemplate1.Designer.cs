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
    using System.Collections.Generic;
    using System.Threading.Tasks;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://tempuri.org/WebsitesTemplate.xsd")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="http://tempuri.org/WebsitesTemplate.xsd", IsNullable=false)]
    public partial class WebsiteTemplate : System.ComponentModel.INotifyPropertyChanged
    {
        
        private WebsiteTemplateSearchEngine _searchEngine;
        
        private WebsiteTemplateResultEngine _resultEngine;
        
        private WebsiteTemplateAdditionalInfo _additionalInfo;
        
        private string _name;
        
        private string _uRL;
        
        private static XmlSerializer serializer;
        
        public async virtual void SaveToFile(string fileName, Windows.Storage.StorageFolder folder)
        {
            var _option = Windows.Storage.CreationCollisionOption.ReplaceExisting;
            var _file = await folder.CreateFileAsync(fileName, _option);
            await Windows.Storage.FileIO.WriteTextAsync(_file, Serialize());
        }
        public static async Task<WebsiteTemplate> LoadFromFile(string fileName, Windows.Storage.StorageFolder folder)
        {
            var _file = await folder.GetFileAsync(fileName);
            var xml = await Windows.Storage.FileIO.ReadTextAsync(_file);
            return Deserialize(xml);
        }
        
        public WebsiteTemplate()
        {
            this._additionalInfo = new WebsiteTemplateAdditionalInfo();
            this._resultEngine = new WebsiteTemplateResultEngine();
            this._searchEngine = new WebsiteTemplateSearchEngine();
        }
        
        public WebsiteTemplateSearchEngine SearchEngine
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
        
        public WebsiteTemplateResultEngine ResultEngine
        {
            get
            {
                return this._resultEngine;
            }
            set
            {
                if ((this._resultEngine == value))
                {
                    return;
                }
                if (((this._resultEngine == null) 
                            || (_resultEngine.Equals(value) != true)))
                {
                    this._resultEngine = value;
                    this.OnPropertyChanged("ResultEngine");
                }
            }
        }
        
        public WebsiteTemplateAdditionalInfo AdditionalInfo
        {
            get
            {
                return this._additionalInfo;
            }
            set
            {
                if ((this._additionalInfo == value))
                {
                    return;
                }
                if (((this._additionalInfo == null) 
                            || (_additionalInfo.Equals(value) != true)))
                {
                    this._additionalInfo = value;
                    this.OnPropertyChanged("AdditionalInfo");
                }
            }
        }
        
        [System.Xml.Serialization.XmlAttributeAttribute()]
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
        
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string URL
        {
            get
            {
                return this._uRL;
            }
            set
            {
                if ((this._uRL == value))
                {
                    return;
                }
                if (((this._uRL == null) 
                            || (_uRL.Equals(value) != true)))
                {
                    this._uRL = value;
                    this.OnPropertyChanged("URL");
                }
            }
        }
        
        private static XmlSerializer Serializer
        {
            get
            {
                if ((serializer == null))
                {
                    serializer = new System.Xml.Serialization.XmlSerializer(typeof(WebsiteTemplate));
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
        /// Serializes current WebsiteTemplate object into an XML string
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
        /// Deserializes workflow markup into an WebsiteTemplate object
        /// </summary>
        /// <param name="input">string workflow markup to deserialize</param>
        /// <param name="obj">Output WebsiteTemplate object</param>
        /// <param name="exception">output Exception value if deserialize failed</param>
        /// <returns>true if this Serializer can deserialize the object; otherwise, false</returns>
        public static bool Deserialize(string input, out WebsiteTemplate obj, out System.Exception exception)
        {
            exception = null;
            obj = default(WebsiteTemplate);
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
        
        public static bool Deserialize(string input, out WebsiteTemplate obj)
        {
            System.Exception exception = null;
            return Deserialize(input, out obj, out exception);
        }
        
        public new static WebsiteTemplate Deserialize(string input)
        {
            System.IO.StringReader stringReader = null;
            try
            {
                stringReader = new System.IO.StringReader(input);
                return ((WebsiteTemplate)(Serializer.Deserialize(System.Xml.XmlReader.Create(stringReader))));
            }
            finally
            {
                if ((stringReader != null))
                {
                    stringReader.Dispose();
                }
            }
        }
        
        public static WebsiteTemplate Deserialize(System.IO.Stream s)
        {
            return ((WebsiteTemplate)(Serializer.Deserialize(s)));
        }
        #endregion
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://tempuri.org/WebsitesTemplate.xsd")]
    public partial class WebsiteTemplateSearchEngine : System.ComponentModel.INotifyPropertyChanged
    {
        
        private WebsiteTemplateSearchEngineDeparturePoint _departurePoint;
        
        private WebsiteTemplateSearchEngineArrivalPoint _arrivalPoint;
        
        private WebsiteTemplateSearchEngineDepartureDate _departureDate;
        
        private WebsiteTemplateSearchEngineArrivalDate _arrivalDate;
        
        private WebsiteTemplateSearchEngineRoundtrip _roundtrip;
        
        private WebsiteTemplateSearchEngineConfirmationButton _confirmationButton;
        
        private static XmlSerializer serializer;
        
        public async virtual void SaveToFile(string fileName, Windows.Storage.StorageFolder folder)
        {
            var _option = Windows.Storage.CreationCollisionOption.ReplaceExisting;
            var _file = await folder.CreateFileAsync(fileName, _option);
            await Windows.Storage.FileIO.WriteTextAsync(_file, Serialize());
        }
        public static async Task<WebsiteTemplateSearchEngine> LoadFromFile(string fileName, Windows.Storage.StorageFolder folder)
        {
            var _file = await folder.GetFileAsync(fileName);
            var xml = await Windows.Storage.FileIO.ReadTextAsync(_file);
            return Deserialize(xml);
        }
        
        public WebsiteTemplateSearchEngine()
        {
            this._confirmationButton = new WebsiteTemplateSearchEngineConfirmationButton();
            this._roundtrip = new WebsiteTemplateSearchEngineRoundtrip();
            this._arrivalDate = new WebsiteTemplateSearchEngineArrivalDate();
            this._departureDate = new WebsiteTemplateSearchEngineDepartureDate();
            this._arrivalPoint = new WebsiteTemplateSearchEngineArrivalPoint();
            this._departurePoint = new WebsiteTemplateSearchEngineDeparturePoint();
        }
        
        public WebsiteTemplateSearchEngineDeparturePoint DeparturePoint
        {
            get
            {
                return this._departurePoint;
            }
            set
            {
                if ((this._departurePoint == value))
                {
                    return;
                }
                if (((this._departurePoint == null) 
                            || (_departurePoint.Equals(value) != true)))
                {
                    this._departurePoint = value;
                    this.OnPropertyChanged("DeparturePoint");
                }
            }
        }
        
        public WebsiteTemplateSearchEngineArrivalPoint ArrivalPoint
        {
            get
            {
                return this._arrivalPoint;
            }
            set
            {
                if ((this._arrivalPoint == value))
                {
                    return;
                }
                if (((this._arrivalPoint == null) 
                            || (_arrivalPoint.Equals(value) != true)))
                {
                    this._arrivalPoint = value;
                    this.OnPropertyChanged("ArrivalPoint");
                }
            }
        }
        
        public WebsiteTemplateSearchEngineDepartureDate DepartureDate
        {
            get
            {
                return this._departureDate;
            }
            set
            {
                if ((this._departureDate == value))
                {
                    return;
                }
                if (((this._departureDate == null) 
                            || (_departureDate.Equals(value) != true)))
                {
                    this._departureDate = value;
                    this.OnPropertyChanged("DepartureDate");
                }
            }
        }
        
        public WebsiteTemplateSearchEngineArrivalDate ArrivalDate
        {
            get
            {
                return this._arrivalDate;
            }
            set
            {
                if ((this._arrivalDate == value))
                {
                    return;
                }
                if (((this._arrivalDate == null) 
                            || (_arrivalDate.Equals(value) != true)))
                {
                    this._arrivalDate = value;
                    this.OnPropertyChanged("ArrivalDate");
                }
            }
        }
        
        public WebsiteTemplateSearchEngineRoundtrip Roundtrip
        {
            get
            {
                return this._roundtrip;
            }
            set
            {
                if ((this._roundtrip == value))
                {
                    return;
                }
                if (((this._roundtrip == null) 
                            || (_roundtrip.Equals(value) != true)))
                {
                    this._roundtrip = value;
                    this.OnPropertyChanged("Roundtrip");
                }
            }
        }
        
        public WebsiteTemplateSearchEngineConfirmationButton ConfirmationButton
        {
            get
            {
                return this._confirmationButton;
            }
            set
            {
                if ((this._confirmationButton == value))
                {
                    return;
                }
                if (((this._confirmationButton == null) 
                            || (_confirmationButton.Equals(value) != true)))
                {
                    this._confirmationButton = value;
                    this.OnPropertyChanged("ConfirmationButton");
                }
            }
        }
        
        private static XmlSerializer Serializer
        {
            get
            {
                if ((serializer == null))
                {
                    serializer = new System.Xml.Serialization.XmlSerializer(typeof(WebsiteTemplateSearchEngine));
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
        /// Serializes current WebsiteTemplateSearchEngine object into an XML string
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
        /// Deserializes workflow markup into an WebsiteTemplateSearchEngine object
        /// </summary>
        /// <param name="input">string workflow markup to deserialize</param>
        /// <param name="obj">Output WebsiteTemplateSearchEngine object</param>
        /// <param name="exception">output Exception value if deserialize failed</param>
        /// <returns>true if this Serializer can deserialize the object; otherwise, false</returns>
        public static bool Deserialize(string input, out WebsiteTemplateSearchEngine obj, out System.Exception exception)
        {
            exception = null;
            obj = default(WebsiteTemplateSearchEngine);
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
        
        public static bool Deserialize(string input, out WebsiteTemplateSearchEngine obj)
        {
            System.Exception exception = null;
            return Deserialize(input, out obj, out exception);
        }
        
        public new static WebsiteTemplateSearchEngine Deserialize(string input)
        {
            System.IO.StringReader stringReader = null;
            try
            {
                stringReader = new System.IO.StringReader(input);
                return ((WebsiteTemplateSearchEngine)(Serializer.Deserialize(System.Xml.XmlReader.Create(stringReader))));
            }
            finally
            {
                if ((stringReader != null))
                {
                    stringReader.Dispose();
                }
            }
        }
        
        public static WebsiteTemplateSearchEngine Deserialize(System.IO.Stream s)
        {
            return ((WebsiteTemplateSearchEngine)(Serializer.Deserialize(s)));
        }
        #endregion
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://tempuri.org/WebsitesTemplate.xsd")]
    public partial class WebsiteTemplateSearchEngineDeparturePoint : System.ComponentModel.INotifyPropertyChanged
    {
        
        private string _tag;
        
        private string _attr;
        
        private string _name;
        
        private static XmlSerializer serializer;
        
        public async virtual void SaveToFile(string fileName, Windows.Storage.StorageFolder folder)
        {
            var _option = Windows.Storage.CreationCollisionOption.ReplaceExisting;
            var _file = await folder.CreateFileAsync(fileName, _option);
            await Windows.Storage.FileIO.WriteTextAsync(_file, Serialize());
        }
        public static async Task<WebsiteTemplateSearchEngineDeparturePoint> LoadFromFile(string fileName, Windows.Storage.StorageFolder folder)
        {
            var _file = await folder.GetFileAsync(fileName);
            var xml = await Windows.Storage.FileIO.ReadTextAsync(_file);
            return Deserialize(xml);
        }
        
        public string Tag
        {
            get
            {
                return this._tag;
            }
            set
            {
                if ((this._tag == value))
                {
                    return;
                }
                if (((this._tag == null) 
                            || (_tag.Equals(value) != true)))
                {
                    this._tag = value;
                    this.OnPropertyChanged("Tag");
                }
            }
        }
        
        public string Attr
        {
            get
            {
                return this._attr;
            }
            set
            {
                if ((this._attr == value))
                {
                    return;
                }
                if (((this._attr == null) 
                            || (_attr.Equals(value) != true)))
                {
                    this._attr = value;
                    this.OnPropertyChanged("Attr");
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
                    serializer = new System.Xml.Serialization.XmlSerializer(typeof(WebsiteTemplateSearchEngineDeparturePoint));
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
        /// Serializes current WebsiteTemplateSearchEngineDeparturePoint object into an XML string
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
        /// Deserializes workflow markup into an WebsiteTemplateSearchEngineDeparturePoint object
        /// </summary>
        /// <param name="input">string workflow markup to deserialize</param>
        /// <param name="obj">Output WebsiteTemplateSearchEngineDeparturePoint object</param>
        /// <param name="exception">output Exception value if deserialize failed</param>
        /// <returns>true if this Serializer can deserialize the object; otherwise, false</returns>
        public static bool Deserialize(string input, out WebsiteTemplateSearchEngineDeparturePoint obj, out System.Exception exception)
        {
            exception = null;
            obj = default(WebsiteTemplateSearchEngineDeparturePoint);
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
        
        public static bool Deserialize(string input, out WebsiteTemplateSearchEngineDeparturePoint obj)
        {
            System.Exception exception = null;
            return Deserialize(input, out obj, out exception);
        }
        
        public new static WebsiteTemplateSearchEngineDeparturePoint Deserialize(string input)
        {
            System.IO.StringReader stringReader = null;
            try
            {
                stringReader = new System.IO.StringReader(input);
                return ((WebsiteTemplateSearchEngineDeparturePoint)(Serializer.Deserialize(System.Xml.XmlReader.Create(stringReader))));
            }
            finally
            {
                if ((stringReader != null))
                {
                    stringReader.Dispose();
                }
            }
        }
        
        public static WebsiteTemplateSearchEngineDeparturePoint Deserialize(System.IO.Stream s)
        {
            return ((WebsiteTemplateSearchEngineDeparturePoint)(Serializer.Deserialize(s)));
        }
        #endregion
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://tempuri.org/WebsitesTemplate.xsd")]
    public partial class WebsiteTemplateSearchEngineArrivalPoint : System.ComponentModel.INotifyPropertyChanged
    {
        
        private string _tag;
        
        private string _attr;
        
        private string _name;
        
        private static XmlSerializer serializer;
        
        public async virtual void SaveToFile(string fileName, Windows.Storage.StorageFolder folder)
        {
            var _option = Windows.Storage.CreationCollisionOption.ReplaceExisting;
            var _file = await folder.CreateFileAsync(fileName, _option);
            await Windows.Storage.FileIO.WriteTextAsync(_file, Serialize());
        }
        public static async Task<WebsiteTemplateSearchEngineArrivalPoint> LoadFromFile(string fileName, Windows.Storage.StorageFolder folder)
        {
            var _file = await folder.GetFileAsync(fileName);
            var xml = await Windows.Storage.FileIO.ReadTextAsync(_file);
            return Deserialize(xml);
        }
        
        public string Tag
        {
            get
            {
                return this._tag;
            }
            set
            {
                if ((this._tag == value))
                {
                    return;
                }
                if (((this._tag == null) 
                            || (_tag.Equals(value) != true)))
                {
                    this._tag = value;
                    this.OnPropertyChanged("Tag");
                }
            }
        }
        
        public string Attr
        {
            get
            {
                return this._attr;
            }
            set
            {
                if ((this._attr == value))
                {
                    return;
                }
                if (((this._attr == null) 
                            || (_attr.Equals(value) != true)))
                {
                    this._attr = value;
                    this.OnPropertyChanged("Attr");
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
                    serializer = new System.Xml.Serialization.XmlSerializer(typeof(WebsiteTemplateSearchEngineArrivalPoint));
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
        /// Serializes current WebsiteTemplateSearchEngineArrivalPoint object into an XML string
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
        /// Deserializes workflow markup into an WebsiteTemplateSearchEngineArrivalPoint object
        /// </summary>
        /// <param name="input">string workflow markup to deserialize</param>
        /// <param name="obj">Output WebsiteTemplateSearchEngineArrivalPoint object</param>
        /// <param name="exception">output Exception value if deserialize failed</param>
        /// <returns>true if this Serializer can deserialize the object; otherwise, false</returns>
        public static bool Deserialize(string input, out WebsiteTemplateSearchEngineArrivalPoint obj, out System.Exception exception)
        {
            exception = null;
            obj = default(WebsiteTemplateSearchEngineArrivalPoint);
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
        
        public static bool Deserialize(string input, out WebsiteTemplateSearchEngineArrivalPoint obj)
        {
            System.Exception exception = null;
            return Deserialize(input, out obj, out exception);
        }
        
        public new static WebsiteTemplateSearchEngineArrivalPoint Deserialize(string input)
        {
            System.IO.StringReader stringReader = null;
            try
            {
                stringReader = new System.IO.StringReader(input);
                return ((WebsiteTemplateSearchEngineArrivalPoint)(Serializer.Deserialize(System.Xml.XmlReader.Create(stringReader))));
            }
            finally
            {
                if ((stringReader != null))
                {
                    stringReader.Dispose();
                }
            }
        }
        
        public static WebsiteTemplateSearchEngineArrivalPoint Deserialize(System.IO.Stream s)
        {
            return ((WebsiteTemplateSearchEngineArrivalPoint)(Serializer.Deserialize(s)));
        }
        #endregion
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://tempuri.org/WebsitesTemplate.xsd")]
    public partial class WebsiteTemplateSearchEngineDepartureDate : System.ComponentModel.INotifyPropertyChanged
    {
        
        private string _tag;
        
        private string _attr;
        
        private string _name;
        
        private static XmlSerializer serializer;
        
        public async virtual void SaveToFile(string fileName, Windows.Storage.StorageFolder folder)
        {
            var _option = Windows.Storage.CreationCollisionOption.ReplaceExisting;
            var _file = await folder.CreateFileAsync(fileName, _option);
            await Windows.Storage.FileIO.WriteTextAsync(_file, Serialize());
        }
        public static async Task<WebsiteTemplateSearchEngineDepartureDate> LoadFromFile(string fileName, Windows.Storage.StorageFolder folder)
        {
            var _file = await folder.GetFileAsync(fileName);
            var xml = await Windows.Storage.FileIO.ReadTextAsync(_file);
            return Deserialize(xml);
        }
        
        public string Tag
        {
            get
            {
                return this._tag;
            }
            set
            {
                if ((this._tag == value))
                {
                    return;
                }
                if (((this._tag == null) 
                            || (_tag.Equals(value) != true)))
                {
                    this._tag = value;
                    this.OnPropertyChanged("Tag");
                }
            }
        }
        
        public string Attr
        {
            get
            {
                return this._attr;
            }
            set
            {
                if ((this._attr == value))
                {
                    return;
                }
                if (((this._attr == null) 
                            || (_attr.Equals(value) != true)))
                {
                    this._attr = value;
                    this.OnPropertyChanged("Attr");
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
                    serializer = new System.Xml.Serialization.XmlSerializer(typeof(WebsiteTemplateSearchEngineDepartureDate));
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
        /// Serializes current WebsiteTemplateSearchEngineDepartureDate object into an XML string
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
        /// Deserializes workflow markup into an WebsiteTemplateSearchEngineDepartureDate object
        /// </summary>
        /// <param name="input">string workflow markup to deserialize</param>
        /// <param name="obj">Output WebsiteTemplateSearchEngineDepartureDate object</param>
        /// <param name="exception">output Exception value if deserialize failed</param>
        /// <returns>true if this Serializer can deserialize the object; otherwise, false</returns>
        public static bool Deserialize(string input, out WebsiteTemplateSearchEngineDepartureDate obj, out System.Exception exception)
        {
            exception = null;
            obj = default(WebsiteTemplateSearchEngineDepartureDate);
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
        
        public static bool Deserialize(string input, out WebsiteTemplateSearchEngineDepartureDate obj)
        {
            System.Exception exception = null;
            return Deserialize(input, out obj, out exception);
        }
        
        public new static WebsiteTemplateSearchEngineDepartureDate Deserialize(string input)
        {
            System.IO.StringReader stringReader = null;
            try
            {
                stringReader = new System.IO.StringReader(input);
                return ((WebsiteTemplateSearchEngineDepartureDate)(Serializer.Deserialize(System.Xml.XmlReader.Create(stringReader))));
            }
            finally
            {
                if ((stringReader != null))
                {
                    stringReader.Dispose();
                }
            }
        }
        
        public static WebsiteTemplateSearchEngineDepartureDate Deserialize(System.IO.Stream s)
        {
            return ((WebsiteTemplateSearchEngineDepartureDate)(Serializer.Deserialize(s)));
        }
        #endregion
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://tempuri.org/WebsitesTemplate.xsd")]
    public partial class WebsiteTemplateSearchEngineArrivalDate : System.ComponentModel.INotifyPropertyChanged
    {
        
        private string _tag;
        
        private string _attr;
        
        private string _name;
        
        private static XmlSerializer serializer;
        
        public async virtual void SaveToFile(string fileName, Windows.Storage.StorageFolder folder)
        {
            var _option = Windows.Storage.CreationCollisionOption.ReplaceExisting;
            var _file = await folder.CreateFileAsync(fileName, _option);
            await Windows.Storage.FileIO.WriteTextAsync(_file, Serialize());
        }
        public static async Task<WebsiteTemplateSearchEngineArrivalDate> LoadFromFile(string fileName, Windows.Storage.StorageFolder folder)
        {
            var _file = await folder.GetFileAsync(fileName);
            var xml = await Windows.Storage.FileIO.ReadTextAsync(_file);
            return Deserialize(xml);
        }
        
        public string Tag
        {
            get
            {
                return this._tag;
            }
            set
            {
                if ((this._tag == value))
                {
                    return;
                }
                if (((this._tag == null) 
                            || (_tag.Equals(value) != true)))
                {
                    this._tag = value;
                    this.OnPropertyChanged("Tag");
                }
            }
        }
        
        public string Attr
        {
            get
            {
                return this._attr;
            }
            set
            {
                if ((this._attr == value))
                {
                    return;
                }
                if (((this._attr == null) 
                            || (_attr.Equals(value) != true)))
                {
                    this._attr = value;
                    this.OnPropertyChanged("Attr");
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
                    serializer = new System.Xml.Serialization.XmlSerializer(typeof(WebsiteTemplateSearchEngineArrivalDate));
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
        /// Serializes current WebsiteTemplateSearchEngineArrivalDate object into an XML string
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
        /// Deserializes workflow markup into an WebsiteTemplateSearchEngineArrivalDate object
        /// </summary>
        /// <param name="input">string workflow markup to deserialize</param>
        /// <param name="obj">Output WebsiteTemplateSearchEngineArrivalDate object</param>
        /// <param name="exception">output Exception value if deserialize failed</param>
        /// <returns>true if this Serializer can deserialize the object; otherwise, false</returns>
        public static bool Deserialize(string input, out WebsiteTemplateSearchEngineArrivalDate obj, out System.Exception exception)
        {
            exception = null;
            obj = default(WebsiteTemplateSearchEngineArrivalDate);
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
        
        public static bool Deserialize(string input, out WebsiteTemplateSearchEngineArrivalDate obj)
        {
            System.Exception exception = null;
            return Deserialize(input, out obj, out exception);
        }
        
        public new static WebsiteTemplateSearchEngineArrivalDate Deserialize(string input)
        {
            System.IO.StringReader stringReader = null;
            try
            {
                stringReader = new System.IO.StringReader(input);
                return ((WebsiteTemplateSearchEngineArrivalDate)(Serializer.Deserialize(System.Xml.XmlReader.Create(stringReader))));
            }
            finally
            {
                if ((stringReader != null))
                {
                    stringReader.Dispose();
                }
            }
        }
        
        public static WebsiteTemplateSearchEngineArrivalDate Deserialize(System.IO.Stream s)
        {
            return ((WebsiteTemplateSearchEngineArrivalDate)(Serializer.Deserialize(s)));
        }
        #endregion
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://tempuri.org/WebsitesTemplate.xsd")]
    public partial class WebsiteTemplateSearchEngineRoundtrip : System.ComponentModel.INotifyPropertyChanged
    {
        
        private string _tag;
        
        private string _attr;
        
        private string _name;
        
        private static XmlSerializer serializer;
        
        public async virtual void SaveToFile(string fileName, Windows.Storage.StorageFolder folder)
        {
            var _option = Windows.Storage.CreationCollisionOption.ReplaceExisting;
            var _file = await folder.CreateFileAsync(fileName, _option);
            await Windows.Storage.FileIO.WriteTextAsync(_file, Serialize());
        }
        public static async Task<WebsiteTemplateSearchEngineRoundtrip> LoadFromFile(string fileName, Windows.Storage.StorageFolder folder)
        {
            var _file = await folder.GetFileAsync(fileName);
            var xml = await Windows.Storage.FileIO.ReadTextAsync(_file);
            return Deserialize(xml);
        }
        
        public string Tag
        {
            get
            {
                return this._tag;
            }
            set
            {
                if ((this._tag == value))
                {
                    return;
                }
                if (((this._tag == null) 
                            || (_tag.Equals(value) != true)))
                {
                    this._tag = value;
                    this.OnPropertyChanged("Tag");
                }
            }
        }
        
        public string Attr
        {
            get
            {
                return this._attr;
            }
            set
            {
                if ((this._attr == value))
                {
                    return;
                }
                if (((this._attr == null) 
                            || (_attr.Equals(value) != true)))
                {
                    this._attr = value;
                    this.OnPropertyChanged("Attr");
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
                    serializer = new System.Xml.Serialization.XmlSerializer(typeof(WebsiteTemplateSearchEngineRoundtrip));
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
        /// Serializes current WebsiteTemplateSearchEngineRoundtrip object into an XML string
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
        /// Deserializes workflow markup into an WebsiteTemplateSearchEngineRoundtrip object
        /// </summary>
        /// <param name="input">string workflow markup to deserialize</param>
        /// <param name="obj">Output WebsiteTemplateSearchEngineRoundtrip object</param>
        /// <param name="exception">output Exception value if deserialize failed</param>
        /// <returns>true if this Serializer can deserialize the object; otherwise, false</returns>
        public static bool Deserialize(string input, out WebsiteTemplateSearchEngineRoundtrip obj, out System.Exception exception)
        {
            exception = null;
            obj = default(WebsiteTemplateSearchEngineRoundtrip);
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
        
        public static bool Deserialize(string input, out WebsiteTemplateSearchEngineRoundtrip obj)
        {
            System.Exception exception = null;
            return Deserialize(input, out obj, out exception);
        }
        
        public new static WebsiteTemplateSearchEngineRoundtrip Deserialize(string input)
        {
            System.IO.StringReader stringReader = null;
            try
            {
                stringReader = new System.IO.StringReader(input);
                return ((WebsiteTemplateSearchEngineRoundtrip)(Serializer.Deserialize(System.Xml.XmlReader.Create(stringReader))));
            }
            finally
            {
                if ((stringReader != null))
                {
                    stringReader.Dispose();
                }
            }
        }
        
        public static WebsiteTemplateSearchEngineRoundtrip Deserialize(System.IO.Stream s)
        {
            return ((WebsiteTemplateSearchEngineRoundtrip)(Serializer.Deserialize(s)));
        }
        #endregion
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://tempuri.org/WebsitesTemplate.xsd")]
    public partial class WebsiteTemplateSearchEngineConfirmationButton : System.ComponentModel.INotifyPropertyChanged
    {
        
        private string _tag;
        
        private string _attr;
        
        private string _name;
        
        private static XmlSerializer serializer;
        
        public async virtual void SaveToFile(string fileName, Windows.Storage.StorageFolder folder)
        {
            var _option = Windows.Storage.CreationCollisionOption.ReplaceExisting;
            var _file = await folder.CreateFileAsync(fileName, _option);
            await Windows.Storage.FileIO.WriteTextAsync(_file, Serialize());
        }
        public static async Task<WebsiteTemplateSearchEngineConfirmationButton> LoadFromFile(string fileName, Windows.Storage.StorageFolder folder)
        {
            var _file = await folder.GetFileAsync(fileName);
            var xml = await Windows.Storage.FileIO.ReadTextAsync(_file);
            return Deserialize(xml);
        }
        
        public string Tag
        {
            get
            {
                return this._tag;
            }
            set
            {
                if ((this._tag == value))
                {
                    return;
                }
                if (((this._tag == null) 
                            || (_tag.Equals(value) != true)))
                {
                    this._tag = value;
                    this.OnPropertyChanged("Tag");
                }
            }
        }
        
        public string Attr
        {
            get
            {
                return this._attr;
            }
            set
            {
                if ((this._attr == value))
                {
                    return;
                }
                if (((this._attr == null) 
                            || (_attr.Equals(value) != true)))
                {
                    this._attr = value;
                    this.OnPropertyChanged("Attr");
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
                    serializer = new System.Xml.Serialization.XmlSerializer(typeof(WebsiteTemplateSearchEngineConfirmationButton));
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
        /// Serializes current WebsiteTemplateSearchEngineConfirmationButton object into an XML string
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
        /// Deserializes workflow markup into an WebsiteTemplateSearchEngineConfirmationButton object
        /// </summary>
        /// <param name="input">string workflow markup to deserialize</param>
        /// <param name="obj">Output WebsiteTemplateSearchEngineConfirmationButton object</param>
        /// <param name="exception">output Exception value if deserialize failed</param>
        /// <returns>true if this Serializer can deserialize the object; otherwise, false</returns>
        public static bool Deserialize(string input, out WebsiteTemplateSearchEngineConfirmationButton obj, out System.Exception exception)
        {
            exception = null;
            obj = default(WebsiteTemplateSearchEngineConfirmationButton);
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
        
        public static bool Deserialize(string input, out WebsiteTemplateSearchEngineConfirmationButton obj)
        {
            System.Exception exception = null;
            return Deserialize(input, out obj, out exception);
        }
        
        public new static WebsiteTemplateSearchEngineConfirmationButton Deserialize(string input)
        {
            System.IO.StringReader stringReader = null;
            try
            {
                stringReader = new System.IO.StringReader(input);
                return ((WebsiteTemplateSearchEngineConfirmationButton)(Serializer.Deserialize(System.Xml.XmlReader.Create(stringReader))));
            }
            finally
            {
                if ((stringReader != null))
                {
                    stringReader.Dispose();
                }
            }
        }
        
        public static WebsiteTemplateSearchEngineConfirmationButton Deserialize(System.IO.Stream s)
        {
            return ((WebsiteTemplateSearchEngineConfirmationButton)(Serializer.Deserialize(s)));
        }
        #endregion
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://tempuri.org/WebsitesTemplate.xsd")]
    public partial class WebsiteTemplateResultEngine : System.ComponentModel.INotifyPropertyChanged
    {
        
        private WebsiteTemplateResultEngineDeparturePoint _departurePoint;
        
        private WebsiteTemplateResultEngineDepartureDate _departureDate;
        
        private WebsiteTemplateResultEngineDepartureTime _departureTime;
        
        private WebsiteTemplateResultEngineArrivalPoint _arrivalPoint;
        
        private WebsiteTemplateResultEngineArrivalDate _arrivalDate;
        
        private WebsiteTemplateResultEngineArrivalTime _arrivalTime;
        
        private WebsiteTemplateResultEngineAirlineName _airlineName;
        
        private WebsiteTemplateResultEngineAirlineNumber _airlineNumber;
        
        private WebsiteTemplateResultEngineTariff _tariff;
        
        private WebsiteTemplateResultEngineTax _tax;
        
        private WebsiteTemplateResultEngineFee _fee;
        
        private WebsiteTemplateResultEnginePrice _price;
        
        private static XmlSerializer serializer;
        
        public async virtual void SaveToFile(string fileName, Windows.Storage.StorageFolder folder)
        {
            var _option = Windows.Storage.CreationCollisionOption.ReplaceExisting;
            var _file = await folder.CreateFileAsync(fileName, _option);
            await Windows.Storage.FileIO.WriteTextAsync(_file, Serialize());
        }
        public static async Task<WebsiteTemplateResultEngine> LoadFromFile(string fileName, Windows.Storage.StorageFolder folder)
        {
            var _file = await folder.GetFileAsync(fileName);
            var xml = await Windows.Storage.FileIO.ReadTextAsync(_file);
            return Deserialize(xml);
        }
        
        public WebsiteTemplateResultEngine()
        {
            this._price = new WebsiteTemplateResultEnginePrice();
            this._fee = new WebsiteTemplateResultEngineFee();
            this._tax = new WebsiteTemplateResultEngineTax();
            this._tariff = new WebsiteTemplateResultEngineTariff();
            this._airlineNumber = new WebsiteTemplateResultEngineAirlineNumber();
            this._airlineName = new WebsiteTemplateResultEngineAirlineName();
            this._arrivalTime = new WebsiteTemplateResultEngineArrivalTime();
            this._arrivalDate = new WebsiteTemplateResultEngineArrivalDate();
            this._arrivalPoint = new WebsiteTemplateResultEngineArrivalPoint();
            this._departureTime = new WebsiteTemplateResultEngineDepartureTime();
            this._departureDate = new WebsiteTemplateResultEngineDepartureDate();
            this._departurePoint = new WebsiteTemplateResultEngineDeparturePoint();
        }
        
        public WebsiteTemplateResultEngineDeparturePoint DeparturePoint
        {
            get
            {
                return this._departurePoint;
            }
            set
            {
                if ((this._departurePoint == value))
                {
                    return;
                }
                if (((this._departurePoint == null) 
                            || (_departurePoint.Equals(value) != true)))
                {
                    this._departurePoint = value;
                    this.OnPropertyChanged("DeparturePoint");
                }
            }
        }
        
        public WebsiteTemplateResultEngineDepartureDate DepartureDate
        {
            get
            {
                return this._departureDate;
            }
            set
            {
                if ((this._departureDate == value))
                {
                    return;
                }
                if (((this._departureDate == null) 
                            || (_departureDate.Equals(value) != true)))
                {
                    this._departureDate = value;
                    this.OnPropertyChanged("DepartureDate");
                }
            }
        }
        
        public WebsiteTemplateResultEngineDepartureTime DepartureTime
        {
            get
            {
                return this._departureTime;
            }
            set
            {
                if ((this._departureTime == value))
                {
                    return;
                }
                if (((this._departureTime == null) 
                            || (_departureTime.Equals(value) != true)))
                {
                    this._departureTime = value;
                    this.OnPropertyChanged("DepartureTime");
                }
            }
        }
        
        public WebsiteTemplateResultEngineArrivalPoint ArrivalPoint
        {
            get
            {
                return this._arrivalPoint;
            }
            set
            {
                if ((this._arrivalPoint == value))
                {
                    return;
                }
                if (((this._arrivalPoint == null) 
                            || (_arrivalPoint.Equals(value) != true)))
                {
                    this._arrivalPoint = value;
                    this.OnPropertyChanged("ArrivalPoint");
                }
            }
        }
        
        public WebsiteTemplateResultEngineArrivalDate ArrivalDate
        {
            get
            {
                return this._arrivalDate;
            }
            set
            {
                if ((this._arrivalDate == value))
                {
                    return;
                }
                if (((this._arrivalDate == null) 
                            || (_arrivalDate.Equals(value) != true)))
                {
                    this._arrivalDate = value;
                    this.OnPropertyChanged("ArrivalDate");
                }
            }
        }
        
        public WebsiteTemplateResultEngineArrivalTime ArrivalTime
        {
            get
            {
                return this._arrivalTime;
            }
            set
            {
                if ((this._arrivalTime == value))
                {
                    return;
                }
                if (((this._arrivalTime == null) 
                            || (_arrivalTime.Equals(value) != true)))
                {
                    this._arrivalTime = value;
                    this.OnPropertyChanged("ArrivalTime");
                }
            }
        }
        
        public WebsiteTemplateResultEngineAirlineName AirlineName
        {
            get
            {
                return this._airlineName;
            }
            set
            {
                if ((this._airlineName == value))
                {
                    return;
                }
                if (((this._airlineName == null) 
                            || (_airlineName.Equals(value) != true)))
                {
                    this._airlineName = value;
                    this.OnPropertyChanged("AirlineName");
                }
            }
        }
        
        public WebsiteTemplateResultEngineAirlineNumber AirlineNumber
        {
            get
            {
                return this._airlineNumber;
            }
            set
            {
                if ((this._airlineNumber == value))
                {
                    return;
                }
                if (((this._airlineNumber == null) 
                            || (_airlineNumber.Equals(value) != true)))
                {
                    this._airlineNumber = value;
                    this.OnPropertyChanged("AirlineNumber");
                }
            }
        }
        
        public WebsiteTemplateResultEngineTariff Tariff
        {
            get
            {
                return this._tariff;
            }
            set
            {
                if ((this._tariff == value))
                {
                    return;
                }
                if (((this._tariff == null) 
                            || (_tariff.Equals(value) != true)))
                {
                    this._tariff = value;
                    this.OnPropertyChanged("Tariff");
                }
            }
        }
        
        public WebsiteTemplateResultEngineTax Tax
        {
            get
            {
                return this._tax;
            }
            set
            {
                if ((this._tax == value))
                {
                    return;
                }
                if (((this._tax == null) 
                            || (_tax.Equals(value) != true)))
                {
                    this._tax = value;
                    this.OnPropertyChanged("Tax");
                }
            }
        }
        
        public WebsiteTemplateResultEngineFee Fee
        {
            get
            {
                return this._fee;
            }
            set
            {
                if ((this._fee == value))
                {
                    return;
                }
                if (((this._fee == null) 
                            || (_fee.Equals(value) != true)))
                {
                    this._fee = value;
                    this.OnPropertyChanged("Fee");
                }
            }
        }
        
        public WebsiteTemplateResultEnginePrice Price
        {
            get
            {
                return this._price;
            }
            set
            {
                if ((this._price == value))
                {
                    return;
                }
                if (((this._price == null) 
                            || (_price.Equals(value) != true)))
                {
                    this._price = value;
                    this.OnPropertyChanged("Price");
                }
            }
        }
        
        private static XmlSerializer Serializer
        {
            get
            {
                if ((serializer == null))
                {
                    serializer = new System.Xml.Serialization.XmlSerializer(typeof(WebsiteTemplateResultEngine));
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
        /// Serializes current WebsiteTemplateResultEngine object into an XML string
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
        /// Deserializes workflow markup into an WebsiteTemplateResultEngine object
        /// </summary>
        /// <param name="input">string workflow markup to deserialize</param>
        /// <param name="obj">Output WebsiteTemplateResultEngine object</param>
        /// <param name="exception">output Exception value if deserialize failed</param>
        /// <returns>true if this Serializer can deserialize the object; otherwise, false</returns>
        public static bool Deserialize(string input, out WebsiteTemplateResultEngine obj, out System.Exception exception)
        {
            exception = null;
            obj = default(WebsiteTemplateResultEngine);
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
        
        public static bool Deserialize(string input, out WebsiteTemplateResultEngine obj)
        {
            System.Exception exception = null;
            return Deserialize(input, out obj, out exception);
        }
        
        public new static WebsiteTemplateResultEngine Deserialize(string input)
        {
            System.IO.StringReader stringReader = null;
            try
            {
                stringReader = new System.IO.StringReader(input);
                return ((WebsiteTemplateResultEngine)(Serializer.Deserialize(System.Xml.XmlReader.Create(stringReader))));
            }
            finally
            {
                if ((stringReader != null))
                {
                    stringReader.Dispose();
                }
            }
        }
        
        public static WebsiteTemplateResultEngine Deserialize(System.IO.Stream s)
        {
            return ((WebsiteTemplateResultEngine)(Serializer.Deserialize(s)));
        }
        #endregion
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://tempuri.org/WebsitesTemplate.xsd")]
    public partial class WebsiteTemplateResultEngineDeparturePoint : System.ComponentModel.INotifyPropertyChanged
    {
        
        private string _tag;
        
        private string _attr;
        
        private string _name;
        
        private static XmlSerializer serializer;
        
        public async virtual void SaveToFile(string fileName, Windows.Storage.StorageFolder folder)
        {
            var _option = Windows.Storage.CreationCollisionOption.ReplaceExisting;
            var _file = await folder.CreateFileAsync(fileName, _option);
            await Windows.Storage.FileIO.WriteTextAsync(_file, Serialize());
        }
        public static async Task<WebsiteTemplateResultEngineDeparturePoint> LoadFromFile(string fileName, Windows.Storage.StorageFolder folder)
        {
            var _file = await folder.GetFileAsync(fileName);
            var xml = await Windows.Storage.FileIO.ReadTextAsync(_file);
            return Deserialize(xml);
        }
        
        public string Tag
        {
            get
            {
                return this._tag;
            }
            set
            {
                if ((this._tag == value))
                {
                    return;
                }
                if (((this._tag == null) 
                            || (_tag.Equals(value) != true)))
                {
                    this._tag = value;
                    this.OnPropertyChanged("Tag");
                }
            }
        }
        
        public string Attr
        {
            get
            {
                return this._attr;
            }
            set
            {
                if ((this._attr == value))
                {
                    return;
                }
                if (((this._attr == null) 
                            || (_attr.Equals(value) != true)))
                {
                    this._attr = value;
                    this.OnPropertyChanged("Attr");
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
                    serializer = new System.Xml.Serialization.XmlSerializer(typeof(WebsiteTemplateResultEngineDeparturePoint));
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
        /// Serializes current WebsiteTemplateResultEngineDeparturePoint object into an XML string
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
        /// Deserializes workflow markup into an WebsiteTemplateResultEngineDeparturePoint object
        /// </summary>
        /// <param name="input">string workflow markup to deserialize</param>
        /// <param name="obj">Output WebsiteTemplateResultEngineDeparturePoint object</param>
        /// <param name="exception">output Exception value if deserialize failed</param>
        /// <returns>true if this Serializer can deserialize the object; otherwise, false</returns>
        public static bool Deserialize(string input, out WebsiteTemplateResultEngineDeparturePoint obj, out System.Exception exception)
        {
            exception = null;
            obj = default(WebsiteTemplateResultEngineDeparturePoint);
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
        
        public static bool Deserialize(string input, out WebsiteTemplateResultEngineDeparturePoint obj)
        {
            System.Exception exception = null;
            return Deserialize(input, out obj, out exception);
        }
        
        public new static WebsiteTemplateResultEngineDeparturePoint Deserialize(string input)
        {
            System.IO.StringReader stringReader = null;
            try
            {
                stringReader = new System.IO.StringReader(input);
                return ((WebsiteTemplateResultEngineDeparturePoint)(Serializer.Deserialize(System.Xml.XmlReader.Create(stringReader))));
            }
            finally
            {
                if ((stringReader != null))
                {
                    stringReader.Dispose();
                }
            }
        }
        
        public static WebsiteTemplateResultEngineDeparturePoint Deserialize(System.IO.Stream s)
        {
            return ((WebsiteTemplateResultEngineDeparturePoint)(Serializer.Deserialize(s)));
        }
        #endregion
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://tempuri.org/WebsitesTemplate.xsd")]
    public partial class WebsiteTemplateResultEngineDepartureDate : System.ComponentModel.INotifyPropertyChanged
    {
        
        private string _tag;
        
        private string _attr;
        
        private string _name;
        
        private static XmlSerializer serializer;
        
        public async virtual void SaveToFile(string fileName, Windows.Storage.StorageFolder folder)
        {
            var _option = Windows.Storage.CreationCollisionOption.ReplaceExisting;
            var _file = await folder.CreateFileAsync(fileName, _option);
            await Windows.Storage.FileIO.WriteTextAsync(_file, Serialize());
        }
        public static async Task<WebsiteTemplateResultEngineDepartureDate> LoadFromFile(string fileName, Windows.Storage.StorageFolder folder)
        {
            var _file = await folder.GetFileAsync(fileName);
            var xml = await Windows.Storage.FileIO.ReadTextAsync(_file);
            return Deserialize(xml);
        }
        
        public string Tag
        {
            get
            {
                return this._tag;
            }
            set
            {
                if ((this._tag == value))
                {
                    return;
                }
                if (((this._tag == null) 
                            || (_tag.Equals(value) != true)))
                {
                    this._tag = value;
                    this.OnPropertyChanged("Tag");
                }
            }
        }
        
        public string Attr
        {
            get
            {
                return this._attr;
            }
            set
            {
                if ((this._attr == value))
                {
                    return;
                }
                if (((this._attr == null) 
                            || (_attr.Equals(value) != true)))
                {
                    this._attr = value;
                    this.OnPropertyChanged("Attr");
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
                    serializer = new System.Xml.Serialization.XmlSerializer(typeof(WebsiteTemplateResultEngineDepartureDate));
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
        /// Serializes current WebsiteTemplateResultEngineDepartureDate object into an XML string
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
        /// Deserializes workflow markup into an WebsiteTemplateResultEngineDepartureDate object
        /// </summary>
        /// <param name="input">string workflow markup to deserialize</param>
        /// <param name="obj">Output WebsiteTemplateResultEngineDepartureDate object</param>
        /// <param name="exception">output Exception value if deserialize failed</param>
        /// <returns>true if this Serializer can deserialize the object; otherwise, false</returns>
        public static bool Deserialize(string input, out WebsiteTemplateResultEngineDepartureDate obj, out System.Exception exception)
        {
            exception = null;
            obj = default(WebsiteTemplateResultEngineDepartureDate);
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
        
        public static bool Deserialize(string input, out WebsiteTemplateResultEngineDepartureDate obj)
        {
            System.Exception exception = null;
            return Deserialize(input, out obj, out exception);
        }
        
        public new static WebsiteTemplateResultEngineDepartureDate Deserialize(string input)
        {
            System.IO.StringReader stringReader = null;
            try
            {
                stringReader = new System.IO.StringReader(input);
                return ((WebsiteTemplateResultEngineDepartureDate)(Serializer.Deserialize(System.Xml.XmlReader.Create(stringReader))));
            }
            finally
            {
                if ((stringReader != null))
                {
                    stringReader.Dispose();
                }
            }
        }
        
        public static WebsiteTemplateResultEngineDepartureDate Deserialize(System.IO.Stream s)
        {
            return ((WebsiteTemplateResultEngineDepartureDate)(Serializer.Deserialize(s)));
        }
        #endregion
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://tempuri.org/WebsitesTemplate.xsd")]
    public partial class WebsiteTemplateResultEngineDepartureTime : System.ComponentModel.INotifyPropertyChanged
    {
        
        private string _tag;
        
        private string _attr;
        
        private string _name;
        
        private static XmlSerializer serializer;
        
        public async virtual void SaveToFile(string fileName, Windows.Storage.StorageFolder folder)
        {
            var _option = Windows.Storage.CreationCollisionOption.ReplaceExisting;
            var _file = await folder.CreateFileAsync(fileName, _option);
            await Windows.Storage.FileIO.WriteTextAsync(_file, Serialize());
        }
        public static async Task<WebsiteTemplateResultEngineDepartureTime> LoadFromFile(string fileName, Windows.Storage.StorageFolder folder)
        {
            var _file = await folder.GetFileAsync(fileName);
            var xml = await Windows.Storage.FileIO.ReadTextAsync(_file);
            return Deserialize(xml);
        }
        
        public string Tag
        {
            get
            {
                return this._tag;
            }
            set
            {
                if ((this._tag == value))
                {
                    return;
                }
                if (((this._tag == null) 
                            || (_tag.Equals(value) != true)))
                {
                    this._tag = value;
                    this.OnPropertyChanged("Tag");
                }
            }
        }
        
        public string Attr
        {
            get
            {
                return this._attr;
            }
            set
            {
                if ((this._attr == value))
                {
                    return;
                }
                if (((this._attr == null) 
                            || (_attr.Equals(value) != true)))
                {
                    this._attr = value;
                    this.OnPropertyChanged("Attr");
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
                    serializer = new System.Xml.Serialization.XmlSerializer(typeof(WebsiteTemplateResultEngineDepartureTime));
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
        /// Serializes current WebsiteTemplateResultEngineDepartureTime object into an XML string
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
        /// Deserializes workflow markup into an WebsiteTemplateResultEngineDepartureTime object
        /// </summary>
        /// <param name="input">string workflow markup to deserialize</param>
        /// <param name="obj">Output WebsiteTemplateResultEngineDepartureTime object</param>
        /// <param name="exception">output Exception value if deserialize failed</param>
        /// <returns>true if this Serializer can deserialize the object; otherwise, false</returns>
        public static bool Deserialize(string input, out WebsiteTemplateResultEngineDepartureTime obj, out System.Exception exception)
        {
            exception = null;
            obj = default(WebsiteTemplateResultEngineDepartureTime);
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
        
        public static bool Deserialize(string input, out WebsiteTemplateResultEngineDepartureTime obj)
        {
            System.Exception exception = null;
            return Deserialize(input, out obj, out exception);
        }
        
        public new static WebsiteTemplateResultEngineDepartureTime Deserialize(string input)
        {
            System.IO.StringReader stringReader = null;
            try
            {
                stringReader = new System.IO.StringReader(input);
                return ((WebsiteTemplateResultEngineDepartureTime)(Serializer.Deserialize(System.Xml.XmlReader.Create(stringReader))));
            }
            finally
            {
                if ((stringReader != null))
                {
                    stringReader.Dispose();
                }
            }
        }
        
        public static WebsiteTemplateResultEngineDepartureTime Deserialize(System.IO.Stream s)
        {
            return ((WebsiteTemplateResultEngineDepartureTime)(Serializer.Deserialize(s)));
        }
        #endregion
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://tempuri.org/WebsitesTemplate.xsd")]
    public partial class WebsiteTemplateResultEngineArrivalPoint : System.ComponentModel.INotifyPropertyChanged
    {
        
        private string _tag;
        
        private string _attr;
        
        private string _name;
        
        private static XmlSerializer serializer;
        
        public async virtual void SaveToFile(string fileName, Windows.Storage.StorageFolder folder)
        {
            var _option = Windows.Storage.CreationCollisionOption.ReplaceExisting;
            var _file = await folder.CreateFileAsync(fileName, _option);
            await Windows.Storage.FileIO.WriteTextAsync(_file, Serialize());
        }
        public static async Task<WebsiteTemplateResultEngineArrivalPoint> LoadFromFile(string fileName, Windows.Storage.StorageFolder folder)
        {
            var _file = await folder.GetFileAsync(fileName);
            var xml = await Windows.Storage.FileIO.ReadTextAsync(_file);
            return Deserialize(xml);
        }
        
        public string Tag
        {
            get
            {
                return this._tag;
            }
            set
            {
                if ((this._tag == value))
                {
                    return;
                }
                if (((this._tag == null) 
                            || (_tag.Equals(value) != true)))
                {
                    this._tag = value;
                    this.OnPropertyChanged("Tag");
                }
            }
        }
        
        public string Attr
        {
            get
            {
                return this._attr;
            }
            set
            {
                if ((this._attr == value))
                {
                    return;
                }
                if (((this._attr == null) 
                            || (_attr.Equals(value) != true)))
                {
                    this._attr = value;
                    this.OnPropertyChanged("Attr");
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
                    serializer = new System.Xml.Serialization.XmlSerializer(typeof(WebsiteTemplateResultEngineArrivalPoint));
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
        /// Serializes current WebsiteTemplateResultEngineArrivalPoint object into an XML string
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
        /// Deserializes workflow markup into an WebsiteTemplateResultEngineArrivalPoint object
        /// </summary>
        /// <param name="input">string workflow markup to deserialize</param>
        /// <param name="obj">Output WebsiteTemplateResultEngineArrivalPoint object</param>
        /// <param name="exception">output Exception value if deserialize failed</param>
        /// <returns>true if this Serializer can deserialize the object; otherwise, false</returns>
        public static bool Deserialize(string input, out WebsiteTemplateResultEngineArrivalPoint obj, out System.Exception exception)
        {
            exception = null;
            obj = default(WebsiteTemplateResultEngineArrivalPoint);
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
        
        public static bool Deserialize(string input, out WebsiteTemplateResultEngineArrivalPoint obj)
        {
            System.Exception exception = null;
            return Deserialize(input, out obj, out exception);
        }
        
        public new static WebsiteTemplateResultEngineArrivalPoint Deserialize(string input)
        {
            System.IO.StringReader stringReader = null;
            try
            {
                stringReader = new System.IO.StringReader(input);
                return ((WebsiteTemplateResultEngineArrivalPoint)(Serializer.Deserialize(System.Xml.XmlReader.Create(stringReader))));
            }
            finally
            {
                if ((stringReader != null))
                {
                    stringReader.Dispose();
                }
            }
        }
        
        public static WebsiteTemplateResultEngineArrivalPoint Deserialize(System.IO.Stream s)
        {
            return ((WebsiteTemplateResultEngineArrivalPoint)(Serializer.Deserialize(s)));
        }
        #endregion
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://tempuri.org/WebsitesTemplate.xsd")]
    public partial class WebsiteTemplateResultEngineArrivalDate : System.ComponentModel.INotifyPropertyChanged
    {
        
        private string _tag;
        
        private string _attr;
        
        private string _name;
        
        private static XmlSerializer serializer;
        
        public async virtual void SaveToFile(string fileName, Windows.Storage.StorageFolder folder)
        {
            var _option = Windows.Storage.CreationCollisionOption.ReplaceExisting;
            var _file = await folder.CreateFileAsync(fileName, _option);
            await Windows.Storage.FileIO.WriteTextAsync(_file, Serialize());
        }
        public static async Task<WebsiteTemplateResultEngineArrivalDate> LoadFromFile(string fileName, Windows.Storage.StorageFolder folder)
        {
            var _file = await folder.GetFileAsync(fileName);
            var xml = await Windows.Storage.FileIO.ReadTextAsync(_file);
            return Deserialize(xml);
        }
        
        public string Tag
        {
            get
            {
                return this._tag;
            }
            set
            {
                if ((this._tag == value))
                {
                    return;
                }
                if (((this._tag == null) 
                            || (_tag.Equals(value) != true)))
                {
                    this._tag = value;
                    this.OnPropertyChanged("Tag");
                }
            }
        }
        
        public string Attr
        {
            get
            {
                return this._attr;
            }
            set
            {
                if ((this._attr == value))
                {
                    return;
                }
                if (((this._attr == null) 
                            || (_attr.Equals(value) != true)))
                {
                    this._attr = value;
                    this.OnPropertyChanged("Attr");
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
                    serializer = new System.Xml.Serialization.XmlSerializer(typeof(WebsiteTemplateResultEngineArrivalDate));
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
        /// Serializes current WebsiteTemplateResultEngineArrivalDate object into an XML string
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
        /// Deserializes workflow markup into an WebsiteTemplateResultEngineArrivalDate object
        /// </summary>
        /// <param name="input">string workflow markup to deserialize</param>
        /// <param name="obj">Output WebsiteTemplateResultEngineArrivalDate object</param>
        /// <param name="exception">output Exception value if deserialize failed</param>
        /// <returns>true if this Serializer can deserialize the object; otherwise, false</returns>
        public static bool Deserialize(string input, out WebsiteTemplateResultEngineArrivalDate obj, out System.Exception exception)
        {
            exception = null;
            obj = default(WebsiteTemplateResultEngineArrivalDate);
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
        
        public static bool Deserialize(string input, out WebsiteTemplateResultEngineArrivalDate obj)
        {
            System.Exception exception = null;
            return Deserialize(input, out obj, out exception);
        }
        
        public new static WebsiteTemplateResultEngineArrivalDate Deserialize(string input)
        {
            System.IO.StringReader stringReader = null;
            try
            {
                stringReader = new System.IO.StringReader(input);
                return ((WebsiteTemplateResultEngineArrivalDate)(Serializer.Deserialize(System.Xml.XmlReader.Create(stringReader))));
            }
            finally
            {
                if ((stringReader != null))
                {
                    stringReader.Dispose();
                }
            }
        }
        
        public static WebsiteTemplateResultEngineArrivalDate Deserialize(System.IO.Stream s)
        {
            return ((WebsiteTemplateResultEngineArrivalDate)(Serializer.Deserialize(s)));
        }
        #endregion
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://tempuri.org/WebsitesTemplate.xsd")]
    public partial class WebsiteTemplateResultEngineArrivalTime : System.ComponentModel.INotifyPropertyChanged
    {
        
        private string _tag;
        
        private string _attr;
        
        private string _name;
        
        private static XmlSerializer serializer;
        
        public async virtual void SaveToFile(string fileName, Windows.Storage.StorageFolder folder)
        {
            var _option = Windows.Storage.CreationCollisionOption.ReplaceExisting;
            var _file = await folder.CreateFileAsync(fileName, _option);
            await Windows.Storage.FileIO.WriteTextAsync(_file, Serialize());
        }
        public static async Task<WebsiteTemplateResultEngineArrivalTime> LoadFromFile(string fileName, Windows.Storage.StorageFolder folder)
        {
            var _file = await folder.GetFileAsync(fileName);
            var xml = await Windows.Storage.FileIO.ReadTextAsync(_file);
            return Deserialize(xml);
        }
        
        public string Tag
        {
            get
            {
                return this._tag;
            }
            set
            {
                if ((this._tag == value))
                {
                    return;
                }
                if (((this._tag == null) 
                            || (_tag.Equals(value) != true)))
                {
                    this._tag = value;
                    this.OnPropertyChanged("Tag");
                }
            }
        }
        
        public string Attr
        {
            get
            {
                return this._attr;
            }
            set
            {
                if ((this._attr == value))
                {
                    return;
                }
                if (((this._attr == null) 
                            || (_attr.Equals(value) != true)))
                {
                    this._attr = value;
                    this.OnPropertyChanged("Attr");
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
                    serializer = new System.Xml.Serialization.XmlSerializer(typeof(WebsiteTemplateResultEngineArrivalTime));
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
        /// Serializes current WebsiteTemplateResultEngineArrivalTime object into an XML string
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
        /// Deserializes workflow markup into an WebsiteTemplateResultEngineArrivalTime object
        /// </summary>
        /// <param name="input">string workflow markup to deserialize</param>
        /// <param name="obj">Output WebsiteTemplateResultEngineArrivalTime object</param>
        /// <param name="exception">output Exception value if deserialize failed</param>
        /// <returns>true if this Serializer can deserialize the object; otherwise, false</returns>
        public static bool Deserialize(string input, out WebsiteTemplateResultEngineArrivalTime obj, out System.Exception exception)
        {
            exception = null;
            obj = default(WebsiteTemplateResultEngineArrivalTime);
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
        
        public static bool Deserialize(string input, out WebsiteTemplateResultEngineArrivalTime obj)
        {
            System.Exception exception = null;
            return Deserialize(input, out obj, out exception);
        }
        
        public new static WebsiteTemplateResultEngineArrivalTime Deserialize(string input)
        {
            System.IO.StringReader stringReader = null;
            try
            {
                stringReader = new System.IO.StringReader(input);
                return ((WebsiteTemplateResultEngineArrivalTime)(Serializer.Deserialize(System.Xml.XmlReader.Create(stringReader))));
            }
            finally
            {
                if ((stringReader != null))
                {
                    stringReader.Dispose();
                }
            }
        }
        
        public static WebsiteTemplateResultEngineArrivalTime Deserialize(System.IO.Stream s)
        {
            return ((WebsiteTemplateResultEngineArrivalTime)(Serializer.Deserialize(s)));
        }
        #endregion
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://tempuri.org/WebsitesTemplate.xsd")]
    public partial class WebsiteTemplateResultEngineAirlineName : System.ComponentModel.INotifyPropertyChanged
    {
        
        private string _tag;
        
        private string _attr;
        
        private string _name;
        
        private static XmlSerializer serializer;
        
        public async virtual void SaveToFile(string fileName, Windows.Storage.StorageFolder folder)
        {
            var _option = Windows.Storage.CreationCollisionOption.ReplaceExisting;
            var _file = await folder.CreateFileAsync(fileName, _option);
            await Windows.Storage.FileIO.WriteTextAsync(_file, Serialize());
        }
        public static async Task<WebsiteTemplateResultEngineAirlineName> LoadFromFile(string fileName, Windows.Storage.StorageFolder folder)
        {
            var _file = await folder.GetFileAsync(fileName);
            var xml = await Windows.Storage.FileIO.ReadTextAsync(_file);
            return Deserialize(xml);
        }
        
        public string Tag
        {
            get
            {
                return this._tag;
            }
            set
            {
                if ((this._tag == value))
                {
                    return;
                }
                if (((this._tag == null) 
                            || (_tag.Equals(value) != true)))
                {
                    this._tag = value;
                    this.OnPropertyChanged("Tag");
                }
            }
        }
        
        public string Attr
        {
            get
            {
                return this._attr;
            }
            set
            {
                if ((this._attr == value))
                {
                    return;
                }
                if (((this._attr == null) 
                            || (_attr.Equals(value) != true)))
                {
                    this._attr = value;
                    this.OnPropertyChanged("Attr");
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
                    serializer = new System.Xml.Serialization.XmlSerializer(typeof(WebsiteTemplateResultEngineAirlineName));
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
        /// Serializes current WebsiteTemplateResultEngineAirlineName object into an XML string
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
        /// Deserializes workflow markup into an WebsiteTemplateResultEngineAirlineName object
        /// </summary>
        /// <param name="input">string workflow markup to deserialize</param>
        /// <param name="obj">Output WebsiteTemplateResultEngineAirlineName object</param>
        /// <param name="exception">output Exception value if deserialize failed</param>
        /// <returns>true if this Serializer can deserialize the object; otherwise, false</returns>
        public static bool Deserialize(string input, out WebsiteTemplateResultEngineAirlineName obj, out System.Exception exception)
        {
            exception = null;
            obj = default(WebsiteTemplateResultEngineAirlineName);
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
        
        public static bool Deserialize(string input, out WebsiteTemplateResultEngineAirlineName obj)
        {
            System.Exception exception = null;
            return Deserialize(input, out obj, out exception);
        }
        
        public new static WebsiteTemplateResultEngineAirlineName Deserialize(string input)
        {
            System.IO.StringReader stringReader = null;
            try
            {
                stringReader = new System.IO.StringReader(input);
                return ((WebsiteTemplateResultEngineAirlineName)(Serializer.Deserialize(System.Xml.XmlReader.Create(stringReader))));
            }
            finally
            {
                if ((stringReader != null))
                {
                    stringReader.Dispose();
                }
            }
        }
        
        public static WebsiteTemplateResultEngineAirlineName Deserialize(System.IO.Stream s)
        {
            return ((WebsiteTemplateResultEngineAirlineName)(Serializer.Deserialize(s)));
        }
        #endregion
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://tempuri.org/WebsitesTemplate.xsd")]
    public partial class WebsiteTemplateResultEngineAirlineNumber : System.ComponentModel.INotifyPropertyChanged
    {
        
        private string _tag;
        
        private string _attr;
        
        private string _name;
        
        private static XmlSerializer serializer;
        
        public async virtual void SaveToFile(string fileName, Windows.Storage.StorageFolder folder)
        {
            var _option = Windows.Storage.CreationCollisionOption.ReplaceExisting;
            var _file = await folder.CreateFileAsync(fileName, _option);
            await Windows.Storage.FileIO.WriteTextAsync(_file, Serialize());
        }
        public static async Task<WebsiteTemplateResultEngineAirlineNumber> LoadFromFile(string fileName, Windows.Storage.StorageFolder folder)
        {
            var _file = await folder.GetFileAsync(fileName);
            var xml = await Windows.Storage.FileIO.ReadTextAsync(_file);
            return Deserialize(xml);
        }
        
        public string Tag
        {
            get
            {
                return this._tag;
            }
            set
            {
                if ((this._tag == value))
                {
                    return;
                }
                if (((this._tag == null) 
                            || (_tag.Equals(value) != true)))
                {
                    this._tag = value;
                    this.OnPropertyChanged("Tag");
                }
            }
        }
        
        public string Attr
        {
            get
            {
                return this._attr;
            }
            set
            {
                if ((this._attr == value))
                {
                    return;
                }
                if (((this._attr == null) 
                            || (_attr.Equals(value) != true)))
                {
                    this._attr = value;
                    this.OnPropertyChanged("Attr");
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
                    serializer = new System.Xml.Serialization.XmlSerializer(typeof(WebsiteTemplateResultEngineAirlineNumber));
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
        /// Serializes current WebsiteTemplateResultEngineAirlineNumber object into an XML string
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
        /// Deserializes workflow markup into an WebsiteTemplateResultEngineAirlineNumber object
        /// </summary>
        /// <param name="input">string workflow markup to deserialize</param>
        /// <param name="obj">Output WebsiteTemplateResultEngineAirlineNumber object</param>
        /// <param name="exception">output Exception value if deserialize failed</param>
        /// <returns>true if this Serializer can deserialize the object; otherwise, false</returns>
        public static bool Deserialize(string input, out WebsiteTemplateResultEngineAirlineNumber obj, out System.Exception exception)
        {
            exception = null;
            obj = default(WebsiteTemplateResultEngineAirlineNumber);
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
        
        public static bool Deserialize(string input, out WebsiteTemplateResultEngineAirlineNumber obj)
        {
            System.Exception exception = null;
            return Deserialize(input, out obj, out exception);
        }
        
        public new static WebsiteTemplateResultEngineAirlineNumber Deserialize(string input)
        {
            System.IO.StringReader stringReader = null;
            try
            {
                stringReader = new System.IO.StringReader(input);
                return ((WebsiteTemplateResultEngineAirlineNumber)(Serializer.Deserialize(System.Xml.XmlReader.Create(stringReader))));
            }
            finally
            {
                if ((stringReader != null))
                {
                    stringReader.Dispose();
                }
            }
        }
        
        public static WebsiteTemplateResultEngineAirlineNumber Deserialize(System.IO.Stream s)
        {
            return ((WebsiteTemplateResultEngineAirlineNumber)(Serializer.Deserialize(s)));
        }
        #endregion
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://tempuri.org/WebsitesTemplate.xsd")]
    public partial class WebsiteTemplateResultEngineTariff : System.ComponentModel.INotifyPropertyChanged
    {
        
        private string _tag;
        
        private string _attr;
        
        private string _name;
        
        private static XmlSerializer serializer;
        
        public async virtual void SaveToFile(string fileName, Windows.Storage.StorageFolder folder)
        {
            var _option = Windows.Storage.CreationCollisionOption.ReplaceExisting;
            var _file = await folder.CreateFileAsync(fileName, _option);
            await Windows.Storage.FileIO.WriteTextAsync(_file, Serialize());
        }
        public static async Task<WebsiteTemplateResultEngineTariff> LoadFromFile(string fileName, Windows.Storage.StorageFolder folder)
        {
            var _file = await folder.GetFileAsync(fileName);
            var xml = await Windows.Storage.FileIO.ReadTextAsync(_file);
            return Deserialize(xml);
        }
        
        public string Tag
        {
            get
            {
                return this._tag;
            }
            set
            {
                if ((this._tag == value))
                {
                    return;
                }
                if (((this._tag == null) 
                            || (_tag.Equals(value) != true)))
                {
                    this._tag = value;
                    this.OnPropertyChanged("Tag");
                }
            }
        }
        
        public string Attr
        {
            get
            {
                return this._attr;
            }
            set
            {
                if ((this._attr == value))
                {
                    return;
                }
                if (((this._attr == null) 
                            || (_attr.Equals(value) != true)))
                {
                    this._attr = value;
                    this.OnPropertyChanged("Attr");
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
                    serializer = new System.Xml.Serialization.XmlSerializer(typeof(WebsiteTemplateResultEngineTariff));
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
        /// Serializes current WebsiteTemplateResultEngineTariff object into an XML string
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
        /// Deserializes workflow markup into an WebsiteTemplateResultEngineTariff object
        /// </summary>
        /// <param name="input">string workflow markup to deserialize</param>
        /// <param name="obj">Output WebsiteTemplateResultEngineTariff object</param>
        /// <param name="exception">output Exception value if deserialize failed</param>
        /// <returns>true if this Serializer can deserialize the object; otherwise, false</returns>
        public static bool Deserialize(string input, out WebsiteTemplateResultEngineTariff obj, out System.Exception exception)
        {
            exception = null;
            obj = default(WebsiteTemplateResultEngineTariff);
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
        
        public static bool Deserialize(string input, out WebsiteTemplateResultEngineTariff obj)
        {
            System.Exception exception = null;
            return Deserialize(input, out obj, out exception);
        }
        
        public new static WebsiteTemplateResultEngineTariff Deserialize(string input)
        {
            System.IO.StringReader stringReader = null;
            try
            {
                stringReader = new System.IO.StringReader(input);
                return ((WebsiteTemplateResultEngineTariff)(Serializer.Deserialize(System.Xml.XmlReader.Create(stringReader))));
            }
            finally
            {
                if ((stringReader != null))
                {
                    stringReader.Dispose();
                }
            }
        }
        
        public static WebsiteTemplateResultEngineTariff Deserialize(System.IO.Stream s)
        {
            return ((WebsiteTemplateResultEngineTariff)(Serializer.Deserialize(s)));
        }
        #endregion
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://tempuri.org/WebsitesTemplate.xsd")]
    public partial class WebsiteTemplateResultEngineTax : System.ComponentModel.INotifyPropertyChanged
    {
        
        private string _tag;
        
        private string _attr;
        
        private string _name;
        
        private static XmlSerializer serializer;
        
        public async virtual void SaveToFile(string fileName, Windows.Storage.StorageFolder folder)
        {
            var _option = Windows.Storage.CreationCollisionOption.ReplaceExisting;
            var _file = await folder.CreateFileAsync(fileName, _option);
            await Windows.Storage.FileIO.WriteTextAsync(_file, Serialize());
        }
        public static async Task<WebsiteTemplateResultEngineTax> LoadFromFile(string fileName, Windows.Storage.StorageFolder folder)
        {
            var _file = await folder.GetFileAsync(fileName);
            var xml = await Windows.Storage.FileIO.ReadTextAsync(_file);
            return Deserialize(xml);
        }
        
        public string Tag
        {
            get
            {
                return this._tag;
            }
            set
            {
                if ((this._tag == value))
                {
                    return;
                }
                if (((this._tag == null) 
                            || (_tag.Equals(value) != true)))
                {
                    this._tag = value;
                    this.OnPropertyChanged("Tag");
                }
            }
        }
        
        public string Attr
        {
            get
            {
                return this._attr;
            }
            set
            {
                if ((this._attr == value))
                {
                    return;
                }
                if (((this._attr == null) 
                            || (_attr.Equals(value) != true)))
                {
                    this._attr = value;
                    this.OnPropertyChanged("Attr");
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
                    serializer = new System.Xml.Serialization.XmlSerializer(typeof(WebsiteTemplateResultEngineTax));
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
        /// Serializes current WebsiteTemplateResultEngineTax object into an XML string
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
        /// Deserializes workflow markup into an WebsiteTemplateResultEngineTax object
        /// </summary>
        /// <param name="input">string workflow markup to deserialize</param>
        /// <param name="obj">Output WebsiteTemplateResultEngineTax object</param>
        /// <param name="exception">output Exception value if deserialize failed</param>
        /// <returns>true if this Serializer can deserialize the object; otherwise, false</returns>
        public static bool Deserialize(string input, out WebsiteTemplateResultEngineTax obj, out System.Exception exception)
        {
            exception = null;
            obj = default(WebsiteTemplateResultEngineTax);
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
        
        public static bool Deserialize(string input, out WebsiteTemplateResultEngineTax obj)
        {
            System.Exception exception = null;
            return Deserialize(input, out obj, out exception);
        }
        
        public new static WebsiteTemplateResultEngineTax Deserialize(string input)
        {
            System.IO.StringReader stringReader = null;
            try
            {
                stringReader = new System.IO.StringReader(input);
                return ((WebsiteTemplateResultEngineTax)(Serializer.Deserialize(System.Xml.XmlReader.Create(stringReader))));
            }
            finally
            {
                if ((stringReader != null))
                {
                    stringReader.Dispose();
                }
            }
        }
        
        public static WebsiteTemplateResultEngineTax Deserialize(System.IO.Stream s)
        {
            return ((WebsiteTemplateResultEngineTax)(Serializer.Deserialize(s)));
        }
        #endregion
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://tempuri.org/WebsitesTemplate.xsd")]
    public partial class WebsiteTemplateResultEngineFee : System.ComponentModel.INotifyPropertyChanged
    {
        
        private string _tag;
        
        private string _attr;
        
        private string _name;
        
        private static XmlSerializer serializer;
        
        public async virtual void SaveToFile(string fileName, Windows.Storage.StorageFolder folder)
        {
            var _option = Windows.Storage.CreationCollisionOption.ReplaceExisting;
            var _file = await folder.CreateFileAsync(fileName, _option);
            await Windows.Storage.FileIO.WriteTextAsync(_file, Serialize());
        }
        public static async Task<WebsiteTemplateResultEngineFee> LoadFromFile(string fileName, Windows.Storage.StorageFolder folder)
        {
            var _file = await folder.GetFileAsync(fileName);
            var xml = await Windows.Storage.FileIO.ReadTextAsync(_file);
            return Deserialize(xml);
        }
        
        public string Tag
        {
            get
            {
                return this._tag;
            }
            set
            {
                if ((this._tag == value))
                {
                    return;
                }
                if (((this._tag == null) 
                            || (_tag.Equals(value) != true)))
                {
                    this._tag = value;
                    this.OnPropertyChanged("Tag");
                }
            }
        }
        
        public string Attr
        {
            get
            {
                return this._attr;
            }
            set
            {
                if ((this._attr == value))
                {
                    return;
                }
                if (((this._attr == null) 
                            || (_attr.Equals(value) != true)))
                {
                    this._attr = value;
                    this.OnPropertyChanged("Attr");
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
                    serializer = new System.Xml.Serialization.XmlSerializer(typeof(WebsiteTemplateResultEngineFee));
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
        /// Serializes current WebsiteTemplateResultEngineFee object into an XML string
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
        /// Deserializes workflow markup into an WebsiteTemplateResultEngineFee object
        /// </summary>
        /// <param name="input">string workflow markup to deserialize</param>
        /// <param name="obj">Output WebsiteTemplateResultEngineFee object</param>
        /// <param name="exception">output Exception value if deserialize failed</param>
        /// <returns>true if this Serializer can deserialize the object; otherwise, false</returns>
        public static bool Deserialize(string input, out WebsiteTemplateResultEngineFee obj, out System.Exception exception)
        {
            exception = null;
            obj = default(WebsiteTemplateResultEngineFee);
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
        
        public static bool Deserialize(string input, out WebsiteTemplateResultEngineFee obj)
        {
            System.Exception exception = null;
            return Deserialize(input, out obj, out exception);
        }
        
        public new static WebsiteTemplateResultEngineFee Deserialize(string input)
        {
            System.IO.StringReader stringReader = null;
            try
            {
                stringReader = new System.IO.StringReader(input);
                return ((WebsiteTemplateResultEngineFee)(Serializer.Deserialize(System.Xml.XmlReader.Create(stringReader))));
            }
            finally
            {
                if ((stringReader != null))
                {
                    stringReader.Dispose();
                }
            }
        }
        
        public static WebsiteTemplateResultEngineFee Deserialize(System.IO.Stream s)
        {
            return ((WebsiteTemplateResultEngineFee)(Serializer.Deserialize(s)));
        }
        #endregion
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://tempuri.org/WebsitesTemplate.xsd")]
    public partial class WebsiteTemplateResultEnginePrice : System.ComponentModel.INotifyPropertyChanged
    {
        
        private string _tag;
        
        private string _attr;
        
        private string _name;
        
        private static XmlSerializer serializer;
        
        public async virtual void SaveToFile(string fileName, Windows.Storage.StorageFolder folder)
        {
            var _option = Windows.Storage.CreationCollisionOption.ReplaceExisting;
            var _file = await folder.CreateFileAsync(fileName, _option);
            await Windows.Storage.FileIO.WriteTextAsync(_file, Serialize());
        }
        public static async Task<WebsiteTemplateResultEnginePrice> LoadFromFile(string fileName, Windows.Storage.StorageFolder folder)
        {
            var _file = await folder.GetFileAsync(fileName);
            var xml = await Windows.Storage.FileIO.ReadTextAsync(_file);
            return Deserialize(xml);
        }
        
        public string Tag
        {
            get
            {
                return this._tag;
            }
            set
            {
                if ((this._tag == value))
                {
                    return;
                }
                if (((this._tag == null) 
                            || (_tag.Equals(value) != true)))
                {
                    this._tag = value;
                    this.OnPropertyChanged("Tag");
                }
            }
        }
        
        public string Attr
        {
            get
            {
                return this._attr;
            }
            set
            {
                if ((this._attr == value))
                {
                    return;
                }
                if (((this._attr == null) 
                            || (_attr.Equals(value) != true)))
                {
                    this._attr = value;
                    this.OnPropertyChanged("Attr");
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
                    serializer = new System.Xml.Serialization.XmlSerializer(typeof(WebsiteTemplateResultEnginePrice));
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
        /// Serializes current WebsiteTemplateResultEnginePrice object into an XML string
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
        /// Deserializes workflow markup into an WebsiteTemplateResultEnginePrice object
        /// </summary>
        /// <param name="input">string workflow markup to deserialize</param>
        /// <param name="obj">Output WebsiteTemplateResultEnginePrice object</param>
        /// <param name="exception">output Exception value if deserialize failed</param>
        /// <returns>true if this Serializer can deserialize the object; otherwise, false</returns>
        public static bool Deserialize(string input, out WebsiteTemplateResultEnginePrice obj, out System.Exception exception)
        {
            exception = null;
            obj = default(WebsiteTemplateResultEnginePrice);
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
        
        public static bool Deserialize(string input, out WebsiteTemplateResultEnginePrice obj)
        {
            System.Exception exception = null;
            return Deserialize(input, out obj, out exception);
        }
        
        public new static WebsiteTemplateResultEnginePrice Deserialize(string input)
        {
            System.IO.StringReader stringReader = null;
            try
            {
                stringReader = new System.IO.StringReader(input);
                return ((WebsiteTemplateResultEnginePrice)(Serializer.Deserialize(System.Xml.XmlReader.Create(stringReader))));
            }
            finally
            {
                if ((stringReader != null))
                {
                    stringReader.Dispose();
                }
            }
        }
        
        public static WebsiteTemplateResultEnginePrice Deserialize(System.IO.Stream s)
        {
            return ((WebsiteTemplateResultEnginePrice)(Serializer.Deserialize(s)));
        }
        #endregion
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://tempuri.org/WebsitesTemplate.xsd")]
    public partial class WebsiteTemplateAdditionalInfo : System.ComponentModel.INotifyPropertyChanged
    {
        
        private WebsiteTemplateAdditionalInfoListAllowed _listAllowed;
        
        private WebsiteTemplateAdditionalInfoDetail _detail;
        
        private WebsiteTemplateAdditionalInfoBack _back;
        
        private WebsiteTemplateAdditionalInfoExactlyAirline _exactlyAirline;
        
        private WebsiteTemplateAdditionalInfoOnlyDirect _onlyDirect;
        
        private static XmlSerializer serializer;
        
        public async virtual void SaveToFile(string fileName, Windows.Storage.StorageFolder folder)
        {
            var _option = Windows.Storage.CreationCollisionOption.ReplaceExisting;
            var _file = await folder.CreateFileAsync(fileName, _option);
            await Windows.Storage.FileIO.WriteTextAsync(_file, Serialize());
        }
        public static async Task<WebsiteTemplateAdditionalInfo> LoadFromFile(string fileName, Windows.Storage.StorageFolder folder)
        {
            var _file = await folder.GetFileAsync(fileName);
            var xml = await Windows.Storage.FileIO.ReadTextAsync(_file);
            return Deserialize(xml);
        }
        
        public WebsiteTemplateAdditionalInfo()
        {
            this._onlyDirect = new WebsiteTemplateAdditionalInfoOnlyDirect();
            this._exactlyAirline = new WebsiteTemplateAdditionalInfoExactlyAirline();
            this._back = new WebsiteTemplateAdditionalInfoBack();
            this._detail = new WebsiteTemplateAdditionalInfoDetail();
            this._listAllowed = new WebsiteTemplateAdditionalInfoListAllowed();
        }
        
        public WebsiteTemplateAdditionalInfoListAllowed ListAllowed
        {
            get
            {
                return this._listAllowed;
            }
            set
            {
                if ((this._listAllowed == value))
                {
                    return;
                }
                if (((this._listAllowed == null) 
                            || (_listAllowed.Equals(value) != true)))
                {
                    this._listAllowed = value;
                    this.OnPropertyChanged("ListAllowed");
                }
            }
        }
        
        public WebsiteTemplateAdditionalInfoDetail Detail
        {
            get
            {
                return this._detail;
            }
            set
            {
                if ((this._detail == value))
                {
                    return;
                }
                if (((this._detail == null) 
                            || (_detail.Equals(value) != true)))
                {
                    this._detail = value;
                    this.OnPropertyChanged("Detail");
                }
            }
        }
        
        public WebsiteTemplateAdditionalInfoBack Back
        {
            get
            {
                return this._back;
            }
            set
            {
                if ((this._back == value))
                {
                    return;
                }
                if (((this._back == null) 
                            || (_back.Equals(value) != true)))
                {
                    this._back = value;
                    this.OnPropertyChanged("Back");
                }
            }
        }
        
        public WebsiteTemplateAdditionalInfoExactlyAirline ExactlyAirline
        {
            get
            {
                return this._exactlyAirline;
            }
            set
            {
                if ((this._exactlyAirline == value))
                {
                    return;
                }
                if (((this._exactlyAirline == null) 
                            || (_exactlyAirline.Equals(value) != true)))
                {
                    this._exactlyAirline = value;
                    this.OnPropertyChanged("ExactlyAirline");
                }
            }
        }
        
        public WebsiteTemplateAdditionalInfoOnlyDirect OnlyDirect
        {
            get
            {
                return this._onlyDirect;
            }
            set
            {
                if ((this._onlyDirect == value))
                {
                    return;
                }
                if (((this._onlyDirect == null) 
                            || (_onlyDirect.Equals(value) != true)))
                {
                    this._onlyDirect = value;
                    this.OnPropertyChanged("OnlyDirect");
                }
            }
        }
        
        private static XmlSerializer Serializer
        {
            get
            {
                if ((serializer == null))
                {
                    serializer = new System.Xml.Serialization.XmlSerializer(typeof(WebsiteTemplateAdditionalInfo));
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
        /// Serializes current WebsiteTemplateAdditionalInfo object into an XML string
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
        /// Deserializes workflow markup into an WebsiteTemplateAdditionalInfo object
        /// </summary>
        /// <param name="input">string workflow markup to deserialize</param>
        /// <param name="obj">Output WebsiteTemplateAdditionalInfo object</param>
        /// <param name="exception">output Exception value if deserialize failed</param>
        /// <returns>true if this Serializer can deserialize the object; otherwise, false</returns>
        public static bool Deserialize(string input, out WebsiteTemplateAdditionalInfo obj, out System.Exception exception)
        {
            exception = null;
            obj = default(WebsiteTemplateAdditionalInfo);
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
        
        public static bool Deserialize(string input, out WebsiteTemplateAdditionalInfo obj)
        {
            System.Exception exception = null;
            return Deserialize(input, out obj, out exception);
        }
        
        public new static WebsiteTemplateAdditionalInfo Deserialize(string input)
        {
            System.IO.StringReader stringReader = null;
            try
            {
                stringReader = new System.IO.StringReader(input);
                return ((WebsiteTemplateAdditionalInfo)(Serializer.Deserialize(System.Xml.XmlReader.Create(stringReader))));
            }
            finally
            {
                if ((stringReader != null))
                {
                    stringReader.Dispose();
                }
            }
        }
        
        public static WebsiteTemplateAdditionalInfo Deserialize(System.IO.Stream s)
        {
            return ((WebsiteTemplateAdditionalInfo)(Serializer.Deserialize(s)));
        }
        #endregion
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://tempuri.org/WebsitesTemplate.xsd")]
    public partial class WebsiteTemplateAdditionalInfoListAllowed : System.ComponentModel.INotifyPropertyChanged
    {
        
        private string _tag;
        
        private string _attr;
        
        private string _name;
        
        private static XmlSerializer serializer;
        
        public async virtual void SaveToFile(string fileName, Windows.Storage.StorageFolder folder)
        {
            var _option = Windows.Storage.CreationCollisionOption.ReplaceExisting;
            var _file = await folder.CreateFileAsync(fileName, _option);
            await Windows.Storage.FileIO.WriteTextAsync(_file, Serialize());
        }
        public static async Task<WebsiteTemplateAdditionalInfoListAllowed> LoadFromFile(string fileName, Windows.Storage.StorageFolder folder)
        {
            var _file = await folder.GetFileAsync(fileName);
            var xml = await Windows.Storage.FileIO.ReadTextAsync(_file);
            return Deserialize(xml);
        }
        
        public string Tag
        {
            get
            {
                return this._tag;
            }
            set
            {
                if ((this._tag == value))
                {
                    return;
                }
                if (((this._tag == null) 
                            || (_tag.Equals(value) != true)))
                {
                    this._tag = value;
                    this.OnPropertyChanged("Tag");
                }
            }
        }
        
        public string Attr
        {
            get
            {
                return this._attr;
            }
            set
            {
                if ((this._attr == value))
                {
                    return;
                }
                if (((this._attr == null) 
                            || (_attr.Equals(value) != true)))
                {
                    this._attr = value;
                    this.OnPropertyChanged("Attr");
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
                    serializer = new System.Xml.Serialization.XmlSerializer(typeof(WebsiteTemplateAdditionalInfoListAllowed));
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
        /// Serializes current WebsiteTemplateAdditionalInfoListAllowed object into an XML string
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
        /// Deserializes workflow markup into an WebsiteTemplateAdditionalInfoListAllowed object
        /// </summary>
        /// <param name="input">string workflow markup to deserialize</param>
        /// <param name="obj">Output WebsiteTemplateAdditionalInfoListAllowed object</param>
        /// <param name="exception">output Exception value if deserialize failed</param>
        /// <returns>true if this Serializer can deserialize the object; otherwise, false</returns>
        public static bool Deserialize(string input, out WebsiteTemplateAdditionalInfoListAllowed obj, out System.Exception exception)
        {
            exception = null;
            obj = default(WebsiteTemplateAdditionalInfoListAllowed);
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
        
        public static bool Deserialize(string input, out WebsiteTemplateAdditionalInfoListAllowed obj)
        {
            System.Exception exception = null;
            return Deserialize(input, out obj, out exception);
        }
        
        public new static WebsiteTemplateAdditionalInfoListAllowed Deserialize(string input)
        {
            System.IO.StringReader stringReader = null;
            try
            {
                stringReader = new System.IO.StringReader(input);
                return ((WebsiteTemplateAdditionalInfoListAllowed)(Serializer.Deserialize(System.Xml.XmlReader.Create(stringReader))));
            }
            finally
            {
                if ((stringReader != null))
                {
                    stringReader.Dispose();
                }
            }
        }
        
        public static WebsiteTemplateAdditionalInfoListAllowed Deserialize(System.IO.Stream s)
        {
            return ((WebsiteTemplateAdditionalInfoListAllowed)(Serializer.Deserialize(s)));
        }
        #endregion
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://tempuri.org/WebsitesTemplate.xsd")]
    public partial class WebsiteTemplateAdditionalInfoDetail : System.ComponentModel.INotifyPropertyChanged
    {
        
        private string _tag;
        
        private string _attr;
        
        private string _name;
        
        private static XmlSerializer serializer;
        
        public async virtual void SaveToFile(string fileName, Windows.Storage.StorageFolder folder)
        {
            var _option = Windows.Storage.CreationCollisionOption.ReplaceExisting;
            var _file = await folder.CreateFileAsync(fileName, _option);
            await Windows.Storage.FileIO.WriteTextAsync(_file, Serialize());
        }
        public static async Task<WebsiteTemplateAdditionalInfoDetail> LoadFromFile(string fileName, Windows.Storage.StorageFolder folder)
        {
            var _file = await folder.GetFileAsync(fileName);
            var xml = await Windows.Storage.FileIO.ReadTextAsync(_file);
            return Deserialize(xml);
        }
        
        public string Tag
        {
            get
            {
                return this._tag;
            }
            set
            {
                if ((this._tag == value))
                {
                    return;
                }
                if (((this._tag == null) 
                            || (_tag.Equals(value) != true)))
                {
                    this._tag = value;
                    this.OnPropertyChanged("Tag");
                }
            }
        }
        
        public string Attr
        {
            get
            {
                return this._attr;
            }
            set
            {
                if ((this._attr == value))
                {
                    return;
                }
                if (((this._attr == null) 
                            || (_attr.Equals(value) != true)))
                {
                    this._attr = value;
                    this.OnPropertyChanged("Attr");
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
                    serializer = new System.Xml.Serialization.XmlSerializer(typeof(WebsiteTemplateAdditionalInfoDetail));
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
        /// Serializes current WebsiteTemplateAdditionalInfoDetail object into an XML string
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
        /// Deserializes workflow markup into an WebsiteTemplateAdditionalInfoDetail object
        /// </summary>
        /// <param name="input">string workflow markup to deserialize</param>
        /// <param name="obj">Output WebsiteTemplateAdditionalInfoDetail object</param>
        /// <param name="exception">output Exception value if deserialize failed</param>
        /// <returns>true if this Serializer can deserialize the object; otherwise, false</returns>
        public static bool Deserialize(string input, out WebsiteTemplateAdditionalInfoDetail obj, out System.Exception exception)
        {
            exception = null;
            obj = default(WebsiteTemplateAdditionalInfoDetail);
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
        
        public static bool Deserialize(string input, out WebsiteTemplateAdditionalInfoDetail obj)
        {
            System.Exception exception = null;
            return Deserialize(input, out obj, out exception);
        }
        
        public new static WebsiteTemplateAdditionalInfoDetail Deserialize(string input)
        {
            System.IO.StringReader stringReader = null;
            try
            {
                stringReader = new System.IO.StringReader(input);
                return ((WebsiteTemplateAdditionalInfoDetail)(Serializer.Deserialize(System.Xml.XmlReader.Create(stringReader))));
            }
            finally
            {
                if ((stringReader != null))
                {
                    stringReader.Dispose();
                }
            }
        }
        
        public static WebsiteTemplateAdditionalInfoDetail Deserialize(System.IO.Stream s)
        {
            return ((WebsiteTemplateAdditionalInfoDetail)(Serializer.Deserialize(s)));
        }
        #endregion
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://tempuri.org/WebsitesTemplate.xsd")]
    public partial class WebsiteTemplateAdditionalInfoBack : System.ComponentModel.INotifyPropertyChanged
    {
        
        private string _tag;
        
        private string _attr;
        
        private string _name;
        
        private static XmlSerializer serializer;
        
        public async virtual void SaveToFile(string fileName, Windows.Storage.StorageFolder folder)
        {
            var _option = Windows.Storage.CreationCollisionOption.ReplaceExisting;
            var _file = await folder.CreateFileAsync(fileName, _option);
            await Windows.Storage.FileIO.WriteTextAsync(_file, Serialize());
        }
        public static async Task<WebsiteTemplateAdditionalInfoBack> LoadFromFile(string fileName, Windows.Storage.StorageFolder folder)
        {
            var _file = await folder.GetFileAsync(fileName);
            var xml = await Windows.Storage.FileIO.ReadTextAsync(_file);
            return Deserialize(xml);
        }
        
        public string Tag
        {
            get
            {
                return this._tag;
            }
            set
            {
                if ((this._tag == value))
                {
                    return;
                }
                if (((this._tag == null) 
                            || (_tag.Equals(value) != true)))
                {
                    this._tag = value;
                    this.OnPropertyChanged("Tag");
                }
            }
        }
        
        public string Attr
        {
            get
            {
                return this._attr;
            }
            set
            {
                if ((this._attr == value))
                {
                    return;
                }
                if (((this._attr == null) 
                            || (_attr.Equals(value) != true)))
                {
                    this._attr = value;
                    this.OnPropertyChanged("Attr");
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
                    serializer = new System.Xml.Serialization.XmlSerializer(typeof(WebsiteTemplateAdditionalInfoBack));
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
        /// Serializes current WebsiteTemplateAdditionalInfoBack object into an XML string
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
        /// Deserializes workflow markup into an WebsiteTemplateAdditionalInfoBack object
        /// </summary>
        /// <param name="input">string workflow markup to deserialize</param>
        /// <param name="obj">Output WebsiteTemplateAdditionalInfoBack object</param>
        /// <param name="exception">output Exception value if deserialize failed</param>
        /// <returns>true if this Serializer can deserialize the object; otherwise, false</returns>
        public static bool Deserialize(string input, out WebsiteTemplateAdditionalInfoBack obj, out System.Exception exception)
        {
            exception = null;
            obj = default(WebsiteTemplateAdditionalInfoBack);
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
        
        public static bool Deserialize(string input, out WebsiteTemplateAdditionalInfoBack obj)
        {
            System.Exception exception = null;
            return Deserialize(input, out obj, out exception);
        }
        
        public new static WebsiteTemplateAdditionalInfoBack Deserialize(string input)
        {
            System.IO.StringReader stringReader = null;
            try
            {
                stringReader = new System.IO.StringReader(input);
                return ((WebsiteTemplateAdditionalInfoBack)(Serializer.Deserialize(System.Xml.XmlReader.Create(stringReader))));
            }
            finally
            {
                if ((stringReader != null))
                {
                    stringReader.Dispose();
                }
            }
        }
        
        public static WebsiteTemplateAdditionalInfoBack Deserialize(System.IO.Stream s)
        {
            return ((WebsiteTemplateAdditionalInfoBack)(Serializer.Deserialize(s)));
        }
        #endregion
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://tempuri.org/WebsitesTemplate.xsd")]
    public partial class WebsiteTemplateAdditionalInfoExactlyAirline : System.ComponentModel.INotifyPropertyChanged
    {
        
        private string _tag;
        
        private string _attr;
        
        private string _name;
        
        private static XmlSerializer serializer;
        
        public async virtual void SaveToFile(string fileName, Windows.Storage.StorageFolder folder)
        {
            var _option = Windows.Storage.CreationCollisionOption.ReplaceExisting;
            var _file = await folder.CreateFileAsync(fileName, _option);
            await Windows.Storage.FileIO.WriteTextAsync(_file, Serialize());
        }
        public static async Task<WebsiteTemplateAdditionalInfoExactlyAirline> LoadFromFile(string fileName, Windows.Storage.StorageFolder folder)
        {
            var _file = await folder.GetFileAsync(fileName);
            var xml = await Windows.Storage.FileIO.ReadTextAsync(_file);
            return Deserialize(xml);
        }
        
        public string Tag
        {
            get
            {
                return this._tag;
            }
            set
            {
                if ((this._tag == value))
                {
                    return;
                }
                if (((this._tag == null) 
                            || (_tag.Equals(value) != true)))
                {
                    this._tag = value;
                    this.OnPropertyChanged("Tag");
                }
            }
        }
        
        public string Attr
        {
            get
            {
                return this._attr;
            }
            set
            {
                if ((this._attr == value))
                {
                    return;
                }
                if (((this._attr == null) 
                            || (_attr.Equals(value) != true)))
                {
                    this._attr = value;
                    this.OnPropertyChanged("Attr");
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
                    serializer = new System.Xml.Serialization.XmlSerializer(typeof(WebsiteTemplateAdditionalInfoExactlyAirline));
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
        /// Serializes current WebsiteTemplateAdditionalInfoExactlyAirline object into an XML string
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
        /// Deserializes workflow markup into an WebsiteTemplateAdditionalInfoExactlyAirline object
        /// </summary>
        /// <param name="input">string workflow markup to deserialize</param>
        /// <param name="obj">Output WebsiteTemplateAdditionalInfoExactlyAirline object</param>
        /// <param name="exception">output Exception value if deserialize failed</param>
        /// <returns>true if this Serializer can deserialize the object; otherwise, false</returns>
        public static bool Deserialize(string input, out WebsiteTemplateAdditionalInfoExactlyAirline obj, out System.Exception exception)
        {
            exception = null;
            obj = default(WebsiteTemplateAdditionalInfoExactlyAirline);
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
        
        public static bool Deserialize(string input, out WebsiteTemplateAdditionalInfoExactlyAirline obj)
        {
            System.Exception exception = null;
            return Deserialize(input, out obj, out exception);
        }
        
        public new static WebsiteTemplateAdditionalInfoExactlyAirline Deserialize(string input)
        {
            System.IO.StringReader stringReader = null;
            try
            {
                stringReader = new System.IO.StringReader(input);
                return ((WebsiteTemplateAdditionalInfoExactlyAirline)(Serializer.Deserialize(System.Xml.XmlReader.Create(stringReader))));
            }
            finally
            {
                if ((stringReader != null))
                {
                    stringReader.Dispose();
                }
            }
        }
        
        public static WebsiteTemplateAdditionalInfoExactlyAirline Deserialize(System.IO.Stream s)
        {
            return ((WebsiteTemplateAdditionalInfoExactlyAirline)(Serializer.Deserialize(s)));
        }
        #endregion
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://tempuri.org/WebsitesTemplate.xsd")]
    public partial class WebsiteTemplateAdditionalInfoOnlyDirect : System.ComponentModel.INotifyPropertyChanged
    {
        
        private string _tag;
        
        private string _attr;
        
        private string _name;
        
        private static XmlSerializer serializer;
        
        public async virtual void SaveToFile(string fileName, Windows.Storage.StorageFolder folder)
        {
            var _option = Windows.Storage.CreationCollisionOption.ReplaceExisting;
            var _file = await folder.CreateFileAsync(fileName, _option);
            await Windows.Storage.FileIO.WriteTextAsync(_file, Serialize());
        }
        public static async Task<WebsiteTemplateAdditionalInfoOnlyDirect> LoadFromFile(string fileName, Windows.Storage.StorageFolder folder)
        {
            var _file = await folder.GetFileAsync(fileName);
            var xml = await Windows.Storage.FileIO.ReadTextAsync(_file);
            return Deserialize(xml);
        }
        
        public string Tag
        {
            get
            {
                return this._tag;
            }
            set
            {
                if ((this._tag == value))
                {
                    return;
                }
                if (((this._tag == null) 
                            || (_tag.Equals(value) != true)))
                {
                    this._tag = value;
                    this.OnPropertyChanged("Tag");
                }
            }
        }
        
        public string Attr
        {
            get
            {
                return this._attr;
            }
            set
            {
                if ((this._attr == value))
                {
                    return;
                }
                if (((this._attr == null) 
                            || (_attr.Equals(value) != true)))
                {
                    this._attr = value;
                    this.OnPropertyChanged("Attr");
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
                    serializer = new System.Xml.Serialization.XmlSerializer(typeof(WebsiteTemplateAdditionalInfoOnlyDirect));
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
        /// Serializes current WebsiteTemplateAdditionalInfoOnlyDirect object into an XML string
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
        /// Deserializes workflow markup into an WebsiteTemplateAdditionalInfoOnlyDirect object
        /// </summary>
        /// <param name="input">string workflow markup to deserialize</param>
        /// <param name="obj">Output WebsiteTemplateAdditionalInfoOnlyDirect object</param>
        /// <param name="exception">output Exception value if deserialize failed</param>
        /// <returns>true if this Serializer can deserialize the object; otherwise, false</returns>
        public static bool Deserialize(string input, out WebsiteTemplateAdditionalInfoOnlyDirect obj, out System.Exception exception)
        {
            exception = null;
            obj = default(WebsiteTemplateAdditionalInfoOnlyDirect);
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
        
        public static bool Deserialize(string input, out WebsiteTemplateAdditionalInfoOnlyDirect obj)
        {
            System.Exception exception = null;
            return Deserialize(input, out obj, out exception);
        }
        
        public new static WebsiteTemplateAdditionalInfoOnlyDirect Deserialize(string input)
        {
            System.IO.StringReader stringReader = null;
            try
            {
                stringReader = new System.IO.StringReader(input);
                return ((WebsiteTemplateAdditionalInfoOnlyDirect)(Serializer.Deserialize(System.Xml.XmlReader.Create(stringReader))));
            }
            finally
            {
                if ((stringReader != null))
                {
                    stringReader.Dispose();
                }
            }
        }
        
        public static WebsiteTemplateAdditionalInfoOnlyDirect Deserialize(System.IO.Stream s)
        {
            return ((WebsiteTemplateAdditionalInfoOnlyDirect)(Serializer.Deserialize(s)));
        }
        #endregion
    }
}
#pragma warning restore
