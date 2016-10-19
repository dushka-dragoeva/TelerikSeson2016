using System.Linq;
using System.Reflection;
using ConsoleWebServer.Framework.Contracts;
using ConsoleWebServer.Framework.Exceptions;

namespace ConsoleWebServer.Framework.Models.Action
{
    public class ActionInvoker
    {
        ////TODO  #warning Hint: Just do not touch this magic :)

        public IActionResult InvokeAction(Controller controler, ActionDescriptor actionDescriptor)
        {
            var methodWithIntParameter = controler.GetType()
                         .GetMethods()
                         .FirstOrDefault(x => x.Name.ToLower() == actionDescriptor.ActionName.ToLower() && x.GetParameters().Length == 1
                             && x.GetParameters()[0].ParameterType == typeof(string) && x.ReturnType == typeof(IActionResult));

            if (methodWithIntParameter == null)
            {
                throw new HttpNotFound(string.Format(
                    "Expected method with signature IActionResult {0}(string) in class {1}Controller",
                        actionDescriptor.ActionName,
                        actionDescriptor.ControllerName));
            }

            try
            {
                var actionResult = (IActionResult)
                    methodWithIntParameter.Invoke(controler, new object[] { actionDescriptor.Parameter });

                return actionResult;
            }
            catch (TargetInvocationException ex)
            {
                throw ex.InnerException;
            }
        }
    } 
}