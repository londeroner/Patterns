using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.Factory
{
    public class ButtonFactory
    {
        public static Button CreateButton(string type)
        {
            return new Button { Type = $"{type} Button" };
        }
    }

    public class NavigationBarFactory
    {
        public Button Button { get; set; }
        public NavigationBarFactory()
        {
            Button = ButtonFactory.CreateButton("Navigation");
        }   
    }

    public class DropDownMenuFactory
    {
        public Button Button { get; set; }
        public DropDownMenuFactory()
        {
            Button = ButtonFactory.CreateButton("DropDown");
        }
    }
}
