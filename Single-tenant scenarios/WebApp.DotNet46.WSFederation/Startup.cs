﻿using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;

namespace WebApp.DotNet46.WSFederation
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}