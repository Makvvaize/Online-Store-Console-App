using System.Numerics;
using System.Reflection;
namespace OnlineSale
{


    internal class Program
    {
        public static void Main(string[] args)
        {
            string onay = null;
            Phone phone1 = new Phone("Samsung ", 149.99);
            Phone phone2 = new Phone("Iphone ", 189.99);
            Phone phone3 = new Phone("Xiaomi ", 119.99);
            Phone phone4 = new Phone("Hwei ", 449.99);
            Mouse mouse1 = new Mouse("Zowie FK-2 ", 49.99);
            Mouse mouse2 = new Mouse("Logitech Superlight ", 44.99);
            Mouse mouse3 = new Mouse("Razer Deathadder ", 39.99);
            Keyboard keyboard1 = new Keyboard("Apex Pro ", 29.99);
            Keyboard keyboard2 = new Keyboard("Daktilo ", 19.99);
            Keyboard keyboard3 = new Keyboard("Rampage ", 14.99);


            Console.WriteLine("Hoş geldin gadaşım");
            Console.WriteLine("Karşında ürün listesi;");

            //Console.WriteLine(Item.TotalCount());
            //for (int i = 0; i < Item.TotalCount(); i++)
            //{
            //    Console.WriteLine((i+1)+ ". " +Item.termsList[i]);
            //}

            foreach (var item in Item.termsList)
            {
                Console.WriteLine((Item.termsList.IndexOf(item) + 1) + " " + item.Description());
            }
            Console.Write("Ne istersin canım : ");

            do
            {
                if (onay == "yes")
                {
                    Console.Write("Tabi kardeşim ne istersin: ");
                }

                int order = Convert.ToInt32(Console.ReadLine());
                Item.sepetList.Add(Item.termsList[order - 1]);
                Console.WriteLine("Buyur kardeşim : " + Item.termsList[order - 1].title);
                //Console.WriteLine("Borcun: " + Item.termsList[order - 1].price);
                //Item.termsList.RemoveAt(order-1);

                Console.WriteLine("Var mı başka bir isteğin? (varsa yes yaz)");
                onay = Console.ReadLine();


                foreach (var item in Item.termsList)
                {
                    if (Item.sepetList.Contains(item))
                    {
                        Console.WriteLine((Item.termsList.IndexOf(item) + 1) + " " + item.Description() + " Sepette ");
                    }
                    else
                    {
                        Console.WriteLine((Item.termsList.IndexOf(item) + 1) + " " + item.Description());
                    }

                }

            }
            while (onay == "yes");
            double sum = 0;
            Console.WriteLine("Sepet içeriği: ");
            foreach (var sepet in Item.sepetList)
            {
                Console.WriteLine(Item.sepetList.IndexOf(sepet) + 1 + " " + sepet.title + " " + sepet.price + "$");
                sum = sum + sepet.price;
            }
            Console.Write("Total sepet tutarı: " + sum + "$");
        }

    }

    abstract class Item
    {
        public string title { get; set; }
        public double price { get; set; }
        public static int itemCount { get; set; }
        public static Item[] items = new Item[itemCount + 1];
        public static List<Item> termsList = new List<Item>();
        public static List<Item> sepetList = new List<Item>();
        public Item(string aTitle, double aPrice)
        {

            title = aTitle;
            price = aPrice;
            termsList.Add(this);

            itemCount++;


        }

        public static int TotalCount()
        {
            return itemCount;
        }

        public string Description()
        {
            return this.title + property(this.title) + " " + this.price + "$";
        }

        public abstract string property(string title);

    }

    class Phone : Item
    {
        public Phone(string aTitle, double aPrice) : base(aTitle, aPrice)
        {

        }

        public override string property(string title)
        {
            return " Makes a call";
        }
    }

    class Keyboard : Item
    {
        public Keyboard(string aTitle, double aPrice) : base(aTitle, aPrice)
        {

        }

        public override string property(string title)
        {
            return " Takes input from user ";
        }
    }

    class Mouse : Item
    {
        public Mouse(string aTitle, double aPrice) : base(aTitle, aPrice)
        {

        }

        public override string property(string title)
        {
            return " CLICK ";
        }
    }


}