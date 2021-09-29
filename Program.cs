using System;

namespace ConsoleApp1
{
    public enum Grade { HighestSort, FirstSort, SecondSort };
    public enum Kind { Mutton, Veal, Pork, Chicken };

    class Product
    {
        protected string Name
        {
            set;
            get;
        }
        protected float Price
        {
            set;
            get;
        }
        protected float Weight
        {
            set;
            get;
        }
        public void ChangePrice(float percent)
        {
            Price = Price * (1 + percent);
        }
        public Product(string Name, float Price, float Weight)
        {
            this.Name = Name;
            this.Price = Price;
            this.Weight = Weight;
        }


        public void InputDialogue()
        {
            Console.WriteLine("Enter Name of product:\n");
            this.Name = Console.ReadLine();
            Console.WriteLine("Enter Price of product:\n");
            this.Price = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Weight of product:\n");
            this.Weight = Convert.ToInt32(Console.ReadLine());
        }
    }
    class Dairy_products : Product
    {
        public void ChangePrice(float percent)
        {
            Price = Price * (1 + percent + Term / 100);
        }
        private int Term { get; set; }
        public Dairy_products(string Name, float Price, float Weight, int Term) : base(Name, Price, Weight)
        {
            this.Term = Term;
        }
        public override bool Equals(object obj)
        {
            if (obj == null || this.GetType() != obj.GetType())
                return false;
            Dairy_products p = (Dairy_products)obj;
            if (this.Name == p.Name && this.Price == p.Price && this.Weight == p.Weight && this.Term == p.Term)
                return true;
            else return false;
        }
        public override int GetHashCode() => (Name, Price, Weight, Term).GetHashCode();
        public override string ToString()
        {
            return Name + " " + Price + "UAH " + Weight + "kg " + Term + " Days " + " \n";
        }
    }
    class Meat : Product
    {
        public void ChangePrice(float percent)
        {
            if (GradeMeat == Grade.HighestSort)
                Price = Price * (1 + percent + 1);
            else if (GradeMeat == Grade.FirstSort)
                Price = (float)(Price * (1 + percent + 0.5));
            else if (GradeMeat == Grade.SecondSort)
                Price = (Price * (1 + percent));
        }
        public enum Grade { HighestSort, FirstSort, SecondSort };
        public enum Kind { Mutton, Veal, Pork, Chicken };
        private Grade GradeMeat { set; get; }
        private Kind KindMeat { set; get; }
        public override bool Equals(object obj)
        {
            if (obj == null || this.GetType() != obj.GetType())
                return false;
            Meat p = (Meat)obj;
            if (this.Name ==
           p.Name && this.Price == p.Price && this.Weight == p.Weight && this.GradeMeat == p.GradeMeat && this.KindMeat == p.KindMeat)
                return true;
            else return false;
        }
        public override string ToString()
        {
            return Name + " " + Price + "UAH " + Weight + "kg " + this.GradeMeat + " " + KindMeat + " \n";
        }
        public Meat(string Name, float Price, float Weigh, Grade GradeMeat, Kind KindMeat) : base(Name, Price, Weigh)
        {
            this.GradeMeat = GradeMeat;
            this.KindMeat = KindMeat;
        }
        public override int GetHashCode() => (Name, Price, Weight, GradeMeat, KindMeat).GetHashCode();
    }

    

    
    class Buy : Product
    {
        protected int QuantityOfGoods;
        
        protected float TotalWeight => QuantityOfGoods * Weight;
        protected float TotalPrice { get { return QuantityOfGoods * Price; } }


        public Buy(string Name, float Price, float Weight, int QuantityOfGoods) : base(Name, Price, Weight)
        {
            this.QuantityOfGoods = QuantityOfGoods;
        }
    }
    class Check : Buy
    {
        public Check(string Name, float Price, float Weight, int QuantityOfGoods) : base(Name, Price, Weight, QuantityOfGoods)
        {
            Console.WriteLine("Name: " + this.Name + "\n");
            Console.WriteLine("Price:" + this.Price+"\n");
            Console.WriteLine("Weight:" + this.Weight + "\n");
            Console.WriteLine("Quantity Of Goods:" + this.QuantityOfGoods + "\n");
            Console.WriteLine("Total Price:" + this.TotalPrice + "\n");
            Console.WriteLine("Total Weight:" + this.TotalWeight + "\n");

        }
    }


    class Storage
    {
        protected Product[] StorageProducts;
        public Storage()
        {
            Console.WriteLine("Enter the number of products:");
            StorageProducts = new Product[Convert.ToInt32(Console.ReadLine())];
            foreach(var product in StorageProducts)
                product.InputDialogue();
            
        }
        public Storage(Product[] arr)
        {
            StorageProducts = arr;
        }

        public void ChangePrice(float percent)
        {
            foreach (var product in StorageProducts)
                product.ChangePrice(percent);
        }
        public Product this[int index]
        {
            get
            {
                return StorageProducts[index];
            }
            set
            {
                StorageProducts[index] = value;
            }
        }



    }

    class Program
    {
        static void Main(string[] args)
        {
            

        }
    }
 }

