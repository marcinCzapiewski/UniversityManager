using System;
using System.Collections.Generic;
using System.Text;
using Autofac;
using Microsoft.Extensions.Configuration;
using UniversityManager.Infrastructure.EF;

namespace UniversityManager.Infrastructure.IoC.Modules
{
    public class SettingsModule : Autofac.Module
    {
        private readonly IConfiguration _configuration;

        public SettingsModule(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void Load(ContainerBuilder builder)
        {
            var section = typeof(SqlSettings).Name.Replace("Settings", string.Empty);
            var configurationValue = new SqlSettings();
            _configuration.GetSection(section).Bind(configurationValue);

            builder.RegisterInstance(configurationValue)
                .SingleInstance();
        }
    }
}
