using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Patterns.Demos
{
    class BuilderDemo
    {
        public static void Run()
        {
            // Create director and builders
            Director director = new Director();

            Builder b1 = new ConcreteBuilder1();
            Builder b2 = new ConcreteBuilder2();

            // Construct two Items
            director.Construct(b1);

            Item p1 = b1.GetResult();
            p1.Show();

            director.Construct(b2);

            Item p2 = b2.GetResult();
            p2.Show();
        }
    }

    /// <summary>
    /// The 'Director' class
    /// </summary>
    class Director
    {
        // Builder uses a complex series of steps
        public void Construct(Builder builder)
        {
            builder.BuildPartA();
            builder.BuildPartB();
        }
    }
    /// <summary>
    /// The 'Builder' abstract class
    /// </summary>
    abstract class Builder
    {
        public abstract void BuildPartA();
        public abstract void BuildPartB();
        public abstract Item GetResult();
    }
    /// <summary>
    /// The 'ConcreteBuilder1' class
    /// </summary>
    class ConcreteBuilder1 : Builder
    {
        private Item _item = new Item();
        public override void BuildPartA()
        {
            _item.Add("PartA");
        }
        public override void BuildPartB()
        {
            _item.Add("PartB");
        }
        public override Item GetResult()
        {
            return _item;
        }
    }

    /// <summary>
    /// The 'ConcreteBuilder2' class
    /// </summary>
    class ConcreteBuilder2 : Builder
    {
        private Item _item = new Item();
        public override void BuildPartA()
        {
            _item.Add("PartX");
        }
        public override void BuildPartB()
        {
            _item.Add("PartY");
        }
        public override Item GetResult()
        {
            return _item;
        }
    }

    /// <summary>
    /// The 'Item' class
    /// </summary>
    class Item
    {
        private List<string> _parts = new List<string>();
        public void Add(string part)
        {
            _parts.Add(part);
        }
        public void Show()
        {
            Console.WriteLine("\nItem Parts -------");
            foreach (string part in _parts)
                Console.WriteLine(part);
        }
    }
}
