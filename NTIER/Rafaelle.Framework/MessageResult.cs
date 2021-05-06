using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rafaelle.Framework
{
     public class MessageResult
     {
        public string message;
         public bool error;
         public object data;
         public object tag;

         public MessageResult(string message, bool error)
         {
             this.message = message;
             this.error = error;
             this.data = (object)null;
         }

         public MessageResult(string message, bool error, object data)
         {
             this.message = message;
             this.error = error;
             this.data = data;
         }

         public MessageResult(string message, bool error, object data, object tag)
         {
             this.message = message;
             this.error = error;
             this.data = data;
             this.tag = tag;
         }

         public string ToJson()
         {
             return string.Format("{{error:{0}, message:\"{1}\", data:\"{2}\", tag:\"{3}\"}}", (object)this.error.ToString().ToLower(), (object)this.message, this.data == null ? (object)"" : (object)this.data.ToString(), this.tag == null ? (object)"" : (object)this.tag.ToString());
         }

         public string ToXml()
         {
             StringBuilder stringBuilder = new StringBuilder();
             stringBuilder.Append("<result>");
             stringBuilder.AppendFormat("<error>{0}</error>", (object)this.error.ToString());
             stringBuilder.AppendFormat("<message>{0}</message>", (object)this.message);
             if (this.data != null)
                 stringBuilder.AppendFormat("<data>{0}</data>", this.data);
             if (this.tag != null)
                 stringBuilder.AppendFormat("<tag>{0}</tag>", this.tag);
             stringBuilder.Append("</result>");
             return stringBuilder.ToString();
         }
    }
}
