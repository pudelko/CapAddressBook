using Elmah;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TestAddressBook.Helpers
{
    public class ExceptionFilter : IExceptionFilter
    {
        /// <summary>
        /// Fires when exception was executed in the code
        /// </summary>
        /// <param name="context"></param>
        public void OnException(ExceptionContext context)
        {
            Debug.WriteLine(context.Exception.Message, "App Errors");

            if (context.ExceptionHandled)
            {
                ErrorSignal.FromCurrentContext().Raise(context.Exception);
            }
        }
    }
}