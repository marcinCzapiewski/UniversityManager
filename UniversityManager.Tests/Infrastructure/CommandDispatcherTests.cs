using System;
using System.Threading.Tasks;
using Autofac;
using Moq;
using UniversityManager.Infrastructure.Commands;
using Xunit;

namespace UniversityManager.Tests.Infrastructure
{
    public class CommandDispatcherTests
    {
        [Fact]
        public async Task when_command_is_null_should_throw_exception()
        {
            //arrange
            var context = new Mock<IComponentContext>();
            var dispatcher = new CommandDispatcher(context.Object);
            //act & assert
            await Assert.ThrowsAsync<ArgumentNullException>(() => dispatcher.Dispatch<ICommand>(null));
        }
    }
}
