using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Web;

namespace GiphyAPI.Helpers
{
    public class ErrorHelper
    {
        public static void Handle(Exception ex)
        {
            if (ex is ThreadAbortException) { return; }
            else
            {
                var msg = string.Format("Giphy", ex.Message, ex.StackTrace);
                Trace.WriteLine(msg);
                Debug.WriteLine(msg);
            }
        }
    }
}