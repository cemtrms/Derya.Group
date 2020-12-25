using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebsiteManagerPanel.Framework.Exceptions
{
    public class ErrorDetail
    {
        public ErrorDetail(string message,int code)
        {
            Messagee = message;
            StatusCodee = code;
        }
        public string Messagee { get; set; }
        public int StatusCodee { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
