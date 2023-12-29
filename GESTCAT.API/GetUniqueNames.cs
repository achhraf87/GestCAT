using System.Net;
using System.Reflection;

namespace GESTCAT.API
{
    public static class GetUniqueNames
    {
        public static string GetUniqueName(string eventName)
        {
            string hostName = Dns.GetHostName();
            string callingAssembly = Assembly.GetCallingAssembly().GetName().Name;
            return $"{hostName}.{callingAssembly}.{eventName}";
        }
    }
}
