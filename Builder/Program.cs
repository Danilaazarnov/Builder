using System;
using System.Collections.Generic;

namespace Programm
{

    public interface IBuilder
    {
        void coffee();

        void friedegg();

        void Dessert();
    }

    public class ConcreteBuilder : IBuilder
    {
        private Product _product = new Product();

        public ConcreteBuilder()
        {
            this.Reset();
        }

        public void Reset()
        {
            this._product = new Product();
        }

        public void coffee()
        {
            this._product.Add("Кофе");
        }

        public void friedegg()
        {
            this._product.Add("Яичница");
        }

        public void Dessert()
        {
            this._product.Add("Дессерт");
        }

        public Product GetProduct()
        {
            Product result = this._product;

            this.Reset();

            return result;
        }
    }


    public class Product
    {
        private List<object> _parts = new List<object>();

        public void Add(string part)
        {
            this._parts.Add(part);
        }

        public string ListParts()
        {
            string str = string.Empty;

            for (int i = 0; i < this._parts.Count; i++)
            {
                str += this._parts[i] + ", ";
            }

            str = str.Remove(str.Length - 2);

            return "Заказ: " + str + "\n";
        }
    }

    public class Director
    {
        private IBuilder _builder;

        public IBuilder Builder
        {
            set { _builder = value; }
        }

        public void BuildMinimalViableProduct()
        {
            this._builder.coffee();
        }

        public void BuildFullFeaturedProduct()
        {
            this._builder.coffee();
            this._builder.friedegg();
            this._builder.Dessert();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var director = new Director();
            var builder = new ConcreteBuilder();
            director.Builder = builder;

            Console.WriteLine("Только Кофе:");
            director.BuildMinimalViableProduct();
            Console.WriteLine(builder.GetProduct().ListParts());

            Console.WriteLine("Полный завтрак:");
            director.BuildFullFeaturedProduct();
            Console.WriteLine(builder.GetProduct().ListParts());

            Console.WriteLine("Дессерт к кофе:");
            builder.coffee();
            builder.Dessert();
            Console.Write(builder.GetProduct().ListParts());
        }
    }
}