using System;

namespace Patterns.Decorator
{
    abstract class ChristmasTree
    {
        public abstract string GetDescription();

        public virtual void Light()
        {
        }

        public void Show()
        {
            Console.WriteLine(GetDescription());
            Light();
        }
    }

    class FirTree : ChristmasTree
    {
        private double height;

        public FirTree(double height)
        {
            this.height = height;
        }

        public override string GetDescription()
        {
            return "Ялинка висотою " + height + " м";
        }
    }

    abstract class TreeDecorator : ChristmasTree
    {
        protected ChristmasTree tree;

        public TreeDecorator(ChristmasTree tree)
        {
            this.tree = tree;
        }

        public override string GetDescription()
        {
            return tree.GetDescription();
        }

        public override void Light()
        {
            tree.Light();
        }
    }

    class ToysDecorator : TreeDecorator
    {
        private int ballsCount;
        private string topper;

        public ToysDecorator(ChristmasTree tree, int ballsCount, string topper)
            : base(tree)
        {
            this.ballsCount = ballsCount;
            this.topper = topper;
        }

        public override string GetDescription()
        {
            return tree.GetDescription() + ", прикраси: " + ballsCount + " кульок, верхівка - " + topper;
        }
    }

    class GarlandDecorator : TreeDecorator
    {
        private string color;

        public GarlandDecorator(ChristmasTree tree, string color)
            : base(tree)
        {
            this.color = color;
        }

        public override string GetDescription()
        {
            return tree.GetDescription() + ", гірлянда (" + color + ")";
        }

        public void Shine()
        {
            Console.WriteLine("Гірлянда світиться: " + color);
        }

        public override void Light()
        {
            base.Light();
            Shine();
        }
    }

    static class Demo
    {
        public static void Run()
        {
            ChristmasTree tree = new FirTree(1.8);
            tree.Show();

            ChristmasTree treeWithToys = new ToysDecorator(new FirTree(2.0), 30, "зірка");
            treeWithToys.Show();

            ChristmasTree treeWithGarland = new GarlandDecorator(new FirTree(1.5), "жовтий");
            treeWithGarland.Show();

            ChristmasTree fullTree = new GarlandDecorator(
                new ToysDecorator(new FirTree(2.5), 50, "шпиль"), "різнокольоровий");
            fullTree.Show();
        }
    }
}
