using System;
using System.Reflection;

namespace CQRS.Core.Helpers
{
    public static class ReflectionExtensions
    {
        private const BindingFlags MethodBindingFlags =
            BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic;

        public static object InvokeMemberOnType(this object target, string
                                                                        name, object[] args)
        {
            var type = target.GetType();

            return InvokeMemberOnType(type, target, name, args);
        }

        private static object InvokeMemberOnType(Type type, object target,
                                                 string name, object[] args)
        {
            try
            {
                // Try to invoke the method
                return type.InvokeMember(
                    name,
                    BindingFlags.InvokeMethod | MethodBindingFlags,
                    null,
                    target,
                    args);
            }
            catch (MissingMethodException)
            {
                // If we couldn't find the method, try on the base class
                if (type.BaseType != null)
                {
                    return InvokeMemberOnType(type.BaseType, target, name,
                                              args);
                }
                //quick greg hack to allow methods to not exist!
                return null;
            }
        }
    }
}