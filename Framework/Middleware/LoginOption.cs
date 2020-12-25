using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebsiteManagerPanel.Framework.Middleware
{
    public class MiddlewareOption
    {
        public IApplicationBuilder App { get; set; }
    }
}
