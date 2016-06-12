﻿using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Pomelo.AspNetCore.TimedJob;

namespace TimeJobSite.Jobs
{
    public class GarbageCollectJob : Job
    {
        [Invoke(Begin = "2016-6-12 18:00", Interval = 1000 * 60)]
        public void Collect(IServiceProvider services)
        {
            var env = services.GetRequiredService<IHostingEnvironment>();
            Console.WriteLine($"{ env.ContentRootPath } Collecting...");
            GC.Collect();
        }
    }
}
