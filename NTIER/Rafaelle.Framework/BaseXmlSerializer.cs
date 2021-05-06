using System;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace Rafaelle.Framework
{
    [Serializable]
    public abstract class BaseXmlSerializer
    {
        private XmlSerializerNamespaces _xmlNamespace;
        private bool _removeXmlHeader;

        public bool RemoveXmlHeader
        {
            get
            {
                return this._removeXmlHeader;
            }
            set
            {
                this._removeXmlHeader = value;
            }
        }

        [XmlIgnore]
        public XmlSerializerNamespaces XmlNamespace
        {
            get
            {
                return this._xmlNamespace;
            }
            set
            {
                this._xmlNamespace = value;
            }
        }

        public BaseXmlSerializer()
        {
            this._xmlNamespace = new XmlSerializerNamespaces();
            this._removeXmlHeader = false;
        }

        protected string Serialize(Type type)
        {
            return this.Serialize(Encoding.UTF8, type);
        }

        protected string Serialize(Encoding encoding, Type type)
        {
            using (MemoryStream memoryStream = new MemoryStream())
            {
                XmlSerializer xmlSerializer = new XmlSerializer(type);
                memoryStream.Position = 0L;
                using (TextWriter textWriter = (TextWriter)new StreamWriter((Stream)memoryStream))
                    xmlSerializer.Serialize(textWriter, (object)this, this._xmlNamespace);
                byte[] buffer = memoryStream.GetBuffer();
                return encoding.GetString(buffer, 0, Convert.ToInt32(buffer.Length));
            }
        }

        public static string Serialize(object objectToSerialize, Encoding encoding, Type objectType)
        {
            using (MemoryStream memoryStream = new MemoryStream())
            {
                XmlSerializer xmlSerializer = new XmlSerializer(objectType);
                memoryStream.Position = 0L;
                using (TextWriter textWriter = (TextWriter)new StreamWriter((Stream)memoryStream))
                    xmlSerializer.Serialize(textWriter, objectToSerialize);
                byte[] buffer = memoryStream.GetBuffer();
                return encoding.GetString(buffer, 0, Convert.ToInt32(buffer.Length));
            }
        }

        public static void SerializeToFile(string path, object objectToSerialize, Type objectType)
        {
            using (FileStream fileStream = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.Read))
                new XmlSerializer(objectType).Serialize((Stream)fileStream, objectToSerialize);
        }

        public static object Deserialize(string xmlData, Type objectType)
        {
            if (string.IsNullOrEmpty(xmlData))
                return (object)null;
            using (StringReader stringReader = new StringReader(xmlData))
                return new XmlSerializer(objectType).Deserialize((TextReader)stringReader);
        }

        public static object DeserializeFromFile(string path, Type objectType)
        {
            using (StreamReader streamReader = new StreamReader(path))
                return new XmlSerializer(objectType).Deserialize((TextReader)streamReader);
        }

        public abstract string Serialize();

        public abstract void SerializeToFile(string path);

        public abstract string Serialize(Encoding encoding);
    }
}
