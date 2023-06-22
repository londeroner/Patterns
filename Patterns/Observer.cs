using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns
{
    public interface IObserver
    {
        void Update(object obj);
    }

    public interface IObservable
    {
        void RegisterObserver(IObserver observer);
        void RemoveObserver(IObserver observer);
        void NotifyObservers();
    }

    public struct StockInfo
    {
        public float USD;
    }

    public class Stock : IObservable
    {
        public StockInfo StockInfo { get; set; }

        public List<IObserver> Observers { get; set; } = new List<IObserver>();

        public Stock()
        {
            StockInfo = new StockInfo();
        }
        public void RegisterObserver(IObserver observer)
        {
            Observers.Add(observer);
        }

        public void RemoveObserver(IObserver observer)
        {
            Observers.Remove(observer);
        }

        public void NotifyObservers()
        {
            foreach (var obs in Observers)
                obs.Update(StockInfo);
        }

        public void ChangePrices(StockInfo prices)
        {
            StockInfo = prices;
            NotifyObservers();
        }
    }

    public class Broker : IObserver
    {
        public string Action { get; set; }
        public Broker(IObservable observable)
        {
            observable.RegisterObserver(this);
        }

        public void Update(object obj)
        {
            StockInfo stockInfo = (StockInfo)obj;

            if (stockInfo.USD > 80)
                Action = "Sell USD";
            else Action = "Buy USD";
        }
    }
}
