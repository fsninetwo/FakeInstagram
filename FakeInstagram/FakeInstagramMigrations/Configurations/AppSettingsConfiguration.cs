using FakeInstagramEfModels.Entities;
using FakeInstagramMigrations;
using FakeInstagramMigrations.Configurations;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;

namespace FakeInstagramMigrations.Configurations
{
    public static class AppSettingsConfiguration
    {
        public static AppSettings GetAppSettings(string environmentName, string filePath)
        {
            IConfigurationBuilder builder = new ConfigurationBuilder()
                .SetBasePath(filePath)
                .AddJsonFile("appsettings.json", optional: true)
                .AddJsonFile($"appsettings.{environmentName}.json", optional: true);

            IConfigurationRoot configuration = builder.Build();

            var settings = new AppSettings();
            configuration.Bind(settings);
            return settings;
        }
    }
}
