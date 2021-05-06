using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rafaelle.Framework
{
    [Serializable]
    public class ErrorMessageCollection : CollectionBase
    {
        public bool HasError
        {
            get
            {
                return this.Count > 0;
            }
        }

        public void Add(ErrorMessage item)
        {
            this.List.Add((object)item);
        }

        public void Add(string message, string source)
        {
            this.List.Add((object)new ErrorMessage(message, source));
        }

        public void Add(string message)
        {
            this.Add(message, string.Empty);
        }

        public void Add(ErrorMessageCollection errorMessages)
        {
            foreach (ErrorMessage errorMessage in (CollectionBase)errorMessages)
                this.Add(errorMessage.Message, errorMessage.Source);
        }

        public void Remove(ErrorMessage item)
        {
            this.List.Remove((object)item);
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            foreach (ErrorMessage errorMessage in (IEnumerable)this.List)
            {
                if (stringBuilder.Length > 0)
                    stringBuilder.Append(Environment.NewLine);
                stringBuilder.Append(errorMessage.ToString());
            }
            return stringBuilder.ToString();
        }

        public ErrorMessage this[int index]
        {
            get
            {
                return (ErrorMessage)this.List[index];
            }
        }

        public ErrorMessage FirstErrorMessage
        {
            get
            {
                if (this.List.Count == 0)
                    return new ErrorMessage();
                return (ErrorMessage)this.List[0];
            }
        }
    }
}
