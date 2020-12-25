using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace WebsiteManagerPanel.Framework.Exceptions
{
    [Serializable]
    public class WorkflowException : BaseException
    {
        public WorkflowException()
        {
        }

        public WorkflowException(string message) : base(message)
        {
        }

        public WorkflowException(string message, Exception exception) : base(message, exception)
        {
        }

        public WorkflowException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public override HttpStatusCode StatusCode => HttpStatusCode.BadRequest;
        public override bool IsLogSave => false;
    }
}
