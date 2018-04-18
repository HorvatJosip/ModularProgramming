﻿using System;
using System.IO;
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
            var data = HostingUtils.ParseVirtualPath(path);



            throw new NotImplementedException();
        }
    }
}