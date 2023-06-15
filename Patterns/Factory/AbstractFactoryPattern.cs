using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.Factory
{
    public interface IUIFactory
    {
        public Button CreateButton(string type);
    }

    public class AppleFactory : IUIFactory
    {
        public Button CreateButton(string type)
        {
            return new Button { Type = $"iOS {type} Button" };
        }
    }

    public class AndroidFactory : IUIFactory
    {
        public Button CreateButton(string type)
        {
            return new Button { Type = $"Android {type} Button" };
        }
    }

    public class NavigationBarAbstract
    {
        public Button Button { get; set; }
        public NavigationBarAbstract(IUIFactory factory)
        {
            Button = factory.CreateButton("Navigation");
        }
    }

    public class DropDownMenuAbstract
    {
        public Button Button { get; set; }
        public DropDownMenuAbstract(IUIFactory factory)
        {
            Button = factory.CreateButton("DropDown");
        }
    }
}
