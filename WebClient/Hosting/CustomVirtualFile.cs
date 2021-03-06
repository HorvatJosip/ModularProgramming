﻿using System;
using System.IO;
using System.Reflection;
using System.Web;
using System.Web.Hosting;

namespace WebClient.Hosting
{
    class CustomVirtualFile : VirtualFile
    {
        private string path;

        public CustomVirtualFile(string virtualPath) : base(virtualPath)
        {
            path = VirtualPathUtility.ToAppRelative(virtualPath);
        }

        public override Stream Open()
        {
            //assembly location, aspx inside assembly location
            var data = HostingUtils.ParseVirtualPath(path);

            var ass = Assembly.LoadFile(data.Key);

            var aspxStream = ass.GetManifestResourceStream(data.Value);

            return aspxStream;
        }
    }
}