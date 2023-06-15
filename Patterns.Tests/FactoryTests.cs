using FluentAssertions;
using Patterns.Factory;
using Xunit;

namespace Patterns.Tests
{
    public class FactoryTests
    {
        [Fact]
        public void ButtonFactory_Test()
        {
            var navigationBar = new NavigationBarFactory();
            var dropdownMenu = new DropDownMenuFactory();

            var navigationBarType = navigationBar.Button.Type;
            var dropdownMenuType = dropdownMenu.Button.Type;

            navigationBarType.Should().NotBeNullOrWhiteSpace();
            navigationBarType.Should().Be("Navigation Button");

            dropdownMenuType.Should().NotBeNullOrWhiteSpace();
            dropdownMenuType.Should().Be("DropDown Button");
        }

        [Fact]
        public void ButtonAbstractFactory_Test()
        {
            var navigationAndroid = new NavigationBarAbstract(new AndroidFactory());
            var dropdownIos = new DropDownMenuAbstract(new AppleFactory());

            var navigationBarType = navigationAndroid.Button.Type;
            var dropdownMenuType = dropdownIos.Button.Type;

            navigationBarType.Should().NotBeNullOrWhiteSpace();
            navigationBarType.Should().Be("Android Navigation Button");

            dropdownMenuType.Should().NotBeNullOrWhiteSpace();
            dropdownMenuType.Should().Be("iOS DropDown Button");
        }
    }
}
