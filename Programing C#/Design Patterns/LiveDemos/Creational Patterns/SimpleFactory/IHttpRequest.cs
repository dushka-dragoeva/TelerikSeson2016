using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleFactory
{
    public interface IHttpRequest
    {
        string Method { get; set; }

        string Url { get; set; }

        IDictionary<string, string> Headers { get; set; }

    }
}
