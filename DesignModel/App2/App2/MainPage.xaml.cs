using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace App2
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    /// 

    public abstract class Duck
    {
        public FlyBehavior flyBehavior;
        public QuackBehavior quackBehavior;
        public Duck()
        {
        }

        public abstract void display();

        public void performFly()
        {
            flyBehavior.fly();
        }

        public void performQuack()
        {
            quackBehavior.quack();
        }

        public void swim()
        {
            System.Diagnostics.Debug.WriteLine("All ducks float, even decoys!");
        }

        public void setFlyBehavior(FlyBehavior fb)
        {
            flyBehavior = fb;
        }

        public void setQuackBehavior(QuackBehavior qb) {
            quackBehavior = qb;
        }
    }

    public class ModelDuck : Duck {
        public ModelDuck() {
            flyBehavior = new FlyNoWay();
            quackBehavior = new Quack();
        }

        public override void display() {
            System.Diagnostics.Debug.WriteLine("I'm a model duck");
        }
    }

    public class FlyRocketPowered : FlyBehavior {
        public void fly() {
            System.Diagnostics.Debug.WriteLine("I'm flying with a rocket!");
        }
    }

    public class MallardDuck : Duck
    {
        public MallardDuck()
        {
            quackBehavior = new Quack();
            flyBehavior = new FlyWithWings();
        }

        public override void display()
        {
            System.Diagnostics.Debug.WriteLine("I'm a real Mallard duck");
        }
    }

    public interface FlyBehavior
    {
        void fly();
    }

    public class FlyWithWings : FlyBehavior
    {
        public void fly()
        {
            System.Diagnostics.Debug.WriteLine("I'm flying!!");
        }
    }

    public class FlyNoWay : FlyBehavior
    {
        public void fly()
        {
            System.Diagnostics.Debug.WriteLine("I can't fly!");
        }
    }

    public interface QuackBehavior
    {
        void quack();
    }

    public class Quack : QuackBehavior
    {
        public void quack()
        {
            System.Diagnostics.Debug.WriteLine("Quack");
        }
    }

    public class MuteQuack : QuackBehavior
    {
        public void quack()
        {
            System.Diagnostics.Debug.WriteLine("<< Silence >>");
        }
    }

    public class Squeak : QuackBehavior
    {
        public void quack()
        {
            System.Diagnostics.Debug.WriteLine("Squeak");
        }
    }

    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            Duck model = new ModelDuck();
            Duck mallard = new MallardDuck();
            mallard.performQuack();
            mallard.performFly();
            model.performFly();
            model.setFlyBehavior(new FlyRocketPowered());
            model.performFly();
        }
    }
}
