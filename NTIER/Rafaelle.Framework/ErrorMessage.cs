using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rafaelle.Framework
{
    public class ErrorMessage
    {

        private string _message;
        private string _source;
        private int _id;

        public ErrorMessage(string message, string source)
        {
            this._message = message;
            this._source = source;
        }

        public ErrorMessage(string message)
        {
            this._message = message;
        }

        public ErrorMessage(string message, int id)
        {
            this._message = message;
            this._id = id;
        }

        public ErrorMessage(string message, string source, int id)
        {
            this._message = message;
            this._source = source;
            this._id = id;
        }

        public ErrorMessage()
        {
        }

        public string Message
        {
            get
            {
                return this._message;
            }
            set
            {
                this._message = value;
            }
        }

        public string Source
        {
            get
            {
                return this._source;
            }
            set
            {
                this._source = value;
            }
        }

        public int ID
        {
            get
            {
                return this._id;
            }
            set
            {
                this._id = value;
            }
        }

        public override string ToString()
        {
            return this._message;
        }
    }
}
