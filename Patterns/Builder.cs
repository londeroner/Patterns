using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns
{
    public class Cake { 
        public string Content { get; set; }

        public void AddToCake(string content)
        {
            Content += $"{content};";
        }
    }
    public class Cook { 
        public Cake MakeCake(CakeBuilder builder)
        {
            builder.CreateCake();
            builder.AddDough();
            builder.AddBase();
            builder.AddTopping();

            return builder.Cake;
        }
    }
    public abstract class CakeBuilder
    {
        public Cake Cake { get; private set; }
        public void CreateCake()
        {
            Cake = new Cake();
        }

        public abstract void AddDough();
        public abstract void AddBase();
        public abstract void AddTopping();
    }

    public class ChocolateCakeBuilder : CakeBuilder
    {

        public override void AddDough()
        {
            Cake.AddToCake("shortbread dough");
        }
        public override void AddBase()
        {
            Cake.AddToCake("chocolate base");
        }

        public override void AddTopping()
        {
            Cake.AddToCake("chocolate topping");
        }
    }

    public class CreamCakeBuilder : CakeBuilder
    {
        public override void AddDough()
        {
            Cake.AddToCake("biscuit dough");
        }
        public override void AddBase()
        {
            Cake.AddToCake("cream base");
        }

        public override void AddTopping()
        {
            Cake.AddToCake("cream topping");
        }
    }
}
