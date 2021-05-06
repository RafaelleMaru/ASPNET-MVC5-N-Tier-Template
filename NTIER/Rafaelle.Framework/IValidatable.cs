using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rafaelle.Framework
{
    public interface IValidatable
    {
        string ValidationMessage { get; }

        bool Validate();
    }
}
