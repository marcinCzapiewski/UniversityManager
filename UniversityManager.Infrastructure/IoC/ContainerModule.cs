using System;
using System.Collections.Generic;
using System.Text;
using Autofac;
using AutoMapper.Configuration;
using UniversityManager.Infrastructure.Mappers;

namespace UniversityManager.Infrastructure.IoC
{
    public class ContainerModule : Module
    {
        private readonly IConfiguration _configuration;

        public ContainerModule(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterInstance(AutoMapperConfig.Initialize()).SingleInstance();
        }
    }
}
