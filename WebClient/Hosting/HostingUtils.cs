using System.Collections.Generic;
using System.Linq;

namespace WebClient.Hosting
{
    static class HostingUtils
    {
        public const string VirtualLocation = "Virtual";

        //(Dll location, aspx file path relative to project)
        public static List<string> ParseVirtualPath(string virtualPath)
        {
            //~/Virtual/Folder/Datoteka.aspx?param=6
            var items = virtualPath.Split('/');

            return items.Skip(2).ToList();
        }
    }
}