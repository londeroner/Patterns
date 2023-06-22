using FluentAssertions;
using Patterns.Factory;
using Xunit;

namespace Patterns.Tests
{
    public class PatternsTests
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

        [Theory]
        [InlineData(4, 6)]
        public void Prototype_Test(int a, int b)
        {
            var rectangle = new Rectangle(a, b);
            var newRectangle = rectangle.Clone();

            rectangle.GetArea().Should().Be(a * b);
            newRectangle.Should().NotBeNull();
            newRectangle.GetArea().Should().Be(a * b);
            rectangle.Should().NotBe(newRectangle);
        }

        [Fact]
        public void Builder_Test()
        {
            var Cook = new Cook();

            var chocolateCake = Cook.MakeCake(new ChocolateCakeBuilder());
            chocolateCake.Content.Should().Be("shortbread dough;chocolate base;chocolate topping;");

            var creamCake = Cook.MakeCake(new CreamCakeBuilder());
            creamCake.Content.Should().Be("biscuit dough;cream base;cream topping;");
        }

        [Theory]
        [InlineData(1500, 1000)]
        public void Strategy_Test(int a, int b)
        {
            Game game = new Game();
            game.AllyTeamGold = a;
            game.EnemyTeamGold = b;

            game.MakeAction().Should().Be("Attack");
        }

        [Theory]
        [InlineData(70)]
        public void Observer_Test(int usd)
        {
            Stock stock = new Stock();
            Broker broker = new Broker(stock);

            stock.ChangePrices(new StockInfo() { USD = usd });

            broker.Action.Should().Be("Buy USD");
        }
    }
}
