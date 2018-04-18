using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace WebClient.Hosting
{
    static class HostingUtils
    {
        public const string VirtualLocation = "Virtual";

        //(Dll location, aspx file path relative to project)
        public static KeyValuePair<string, string> ParseVirtualPath(string virtualPath)
        {
            //~/Virtual/Datoteka.aspx?param=6
            var items = virtualPath.Split('/');

            var dllLocation = new Uri(Assembly.GetExecutingAssembly().CodeBase).LocalPath;

            var formModuleDllsLocation = Path.Combine(GoBackNDirectories(dllLocation, 3), "FormModuleDlls");

            var fileName = Path.GetFileNameWithoutExtension(items[2]);

            var aspxAssemblyLocation = Path.Combine(formModuleDllsLocation, $"{fileName}.dll");

            //TestFormModule.FormModule.TestFormModule
            var aspxPath = $"{fileName}.FormModule.{fileName}.aspx";

            return new KeyValuePair<string, string>(aspxAssemblyLocation, aspxPath);
        }

        private static string GoBackNDirectories(string startPath, int n)
        {
            for (int i = 0; i < n; i++)
                startPath = Directory.GetParent(startPath).FullName;

            return startPath;
        }
    }
}