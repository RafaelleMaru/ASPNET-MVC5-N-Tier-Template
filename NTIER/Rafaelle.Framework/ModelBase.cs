using System;
using System.Xml.Serialization;

namespace Rafaelle.Framework
{
    [Serializable]
    public abstract class ModelBase
    {
        private ErrorMessageCollection _errorMessages;

        public ModelBase()
        {
            this._errorMessages = new ErrorMessageCollection();
        }

        public ModelBase(ErrorMessageCollection errorMessages)
        {
            this._errorMessages = errorMessages;
        }

        [XmlIgnore]
        public bool HasError
        {
            get
            {
                return this._errorMessages.HasError;
            }
        }

        [XmlIgnore]
        public ErrorMessageCollection ErrorMessages
        {
            get
            {
                return this._errorMessages;
            }
        }
    }
}
