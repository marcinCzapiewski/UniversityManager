using System;
using System.Collections.Generic;
using System.Text;
using UniversityManager.Infrastructure.Mappers;
using Xunit;

namespace UniversityManager.Tests.Infrastructure
{
    public class MapperConfigTests
    {
        [Fact]
        public void when_mapper_config_is_setup_configuration_should_be_valid()
        {
            var config = AutoMapperConfig.Initialize();

            config.ConfigurationProvider.AssertConfigurationIsValid();
        }
    }
}
