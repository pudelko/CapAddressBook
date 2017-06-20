using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace TestAddressBook.Helpers
{
    public static class ExceptionTools
    {
            /// <summary>
            /// Get the current name of the method in which the exception occurred
            /// </summary>
            /// <param name="exception">current exception</param>
            /// <returns>method name</returns>
            private static string GetCurrentMethodName(Exception exception)
            {
                var sTrace = new StackTrace(exception);
                var frame = sTrace.GetFrame(0);
                var method = frame.GetMethod();

                return string.Concat(method.DeclaringType.FullName, ".", method.Name);
            }

            /// <summary>
            /// Propagates an exception with the name of the method in which it occurred 
            /// </summary>
            /// <param name="exceprion">exception</param>
            /// <returns>new exception</returns>
            public static Exception PropagateDetailsException(Exception exceprion)
            {
                return new Exception(string.Format("[{0}]: {1}", GetCurrentMethodName(exceprion), exceprion.Message), exceprion);
            }
    }
}