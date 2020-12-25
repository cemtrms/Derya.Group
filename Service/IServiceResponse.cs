using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebsiteManagerPanel.Service
{
        public interface IServiceResponse<T>
        {
            IList<T> List { get; set; }
            T Entity { get; set; }

            int Count { get; set; }

            bool IsSuccessful { get; set; }
    }
}
