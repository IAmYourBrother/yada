using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Configuration;
using System.Text;
using System.Threading.Tasks;

namespace PSSFx
{
    public class PSSFactory
    {
        static Assembly assembly = null;

        /*Call getAssembly to get the types of the assembly (assemplyPath)
         * this returns an array of types 
         * 
         * 
         * 
         * iterate to each type to get the interfaces of the type (IMessenger, IPublisher... so on)
         * 
         * in the getMessenger, if the array of types contain an IMessenger, it will create an instance 
         * of the class, and return the instance.
         * 
         * Same goes for the IPublisher
         * 
         * 
         * This factory would be called by the application to access the PSSLib
         * 
         * */
        public static void getAssembly()
        {
            if (assembly == null)
            {   
                string assemblyPath = ConfigurationManager.AppSettings["assemblyPath"];
                // gets all list of types 
                assembly = Assembly.LoadFile(assemblyPath); 
            }
        }
        public static IMessenger getMessenger()
        {
            getAssembly();
            Type[] types = assembly.GetTypes();
            foreach (Type type in types)
            {
                Type[] interfaces = type.GetInterfaces();
                if (interfaces.Contains(typeof(IMessenger)))
                {
                    return (IMessenger)assembly.CreateInstance(type.FullName);
                }               
            }
            return null;
        }

        public static IPublisher getPublisher()
        {
            getAssembly();
            Type[] types = assembly.GetTypes();
            foreach (Type type in types)
            {
                Type[] interfaces = type.GetInterfaces();
                if (interfaces.Contains(typeof(IPublisher)))
                {
                    return (IPublisher)assembly.CreateInstance(type.FullName);
                }
            }
            return null;
        }
    }
}
