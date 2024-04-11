using System;

namespace Assignemt2
{
    public class mainClass
    {
        public static void Main()
        {
            Console.Write("Enter 4 for 1st question and 5 for 2nd question :- ");
            string s = Console.ReadLine();
            if (s.Equals("4"))
            {
                Program4 Pro = new Program4();
                Pro.Question();
            }
            else if(s.Equals("5"))
            {
                Program5 pro = new Program5();
                pro.Question();
            }
            else
            {
                Console.WriteLine("Enter right credentials ");
            }
        }
    }
    // Program for questiuon 4
    public class Program4
    {
        public void Question()
        {
            while (true)
            {
                Equipment Equip;
                Equip = new Functions();
                Equip.setCredential();
                Equip.setSpacificationOfEquipment();
                while (true)
                {
                    Console.Write("Type distance :- ");
                    string s = Console.ReadLine();
                    int distance = Convert.ToInt32(s);
                    Equip.movedBy(distance);
                    Equip.maintenanaceCostIncrease(distance);
                    Console.Write("Type r for result or anything for continue :- ");
                    string str = Console.ReadLine();
                    if (str.Equals("r"))
                    {
                        Equip.getEquipmentDetails();
                        Console.Write("Type x for new Equipment or exit or anything for continue :- ");
                        string sr = Console.ReadLine();
                        if (sr.Equals("x")) break;
                    }
                }
                Console.Write("Write x to exit or anything for continue");
                string st = Console.ReadLine();
                if (st.Equals("x")) break;
            }
        }
    }

    public class Functions:Equipment
    {
        public override void setCredential() // Function for set credential
        {
            Console.Write("Enter the name of equipment :- ");
            name = Console.ReadLine();
            Console.Write("Enter the description of equipment :- ");
            description = Console.ReadLine();
            Console.Write("Enter the type(0 -> mobile, 1-> imMobile) of equipment :- ");
            string s = Console.ReadLine();
            int position = Convert.ToInt32(s);
            try
            {
                type = Enum.GetName(typeof(typeOfEquipment), position);
            }
            catch
            {
                Console.WriteLine("Please select the correct equipment type");
            }
            
            base.setCredential();
        }


        public override void setSpacificationOfEquipment()
        {
            try
            {
                if (type.Equals("mobile"))
                {
                    Console.Write("Enter number of wheels in equipment :- ");
                    string numberOfWheels = Console.ReadLine();
                    
                    try
                    {
                        spacificationOfEqipment = Convert.ToInt32(numberOfWheels);
                    }
                    catch
                    {
                        Console.WriteLine("Wheels should be a number!");
                    }
                }
                else if (type.Equals("imMobile"))
                {
                    Console.Write("Enter weight of equipment :- ");
                    string weightOfEquipment = Console.ReadLine();
                    try
                    {
                        spacificationOfEqipment = Convert.ToInt32(weightOfEquipment);
                    }
                    catch
                    {
                        Console.WriteLine("Weight should be a number!");
                    }
                }
                else
                {
                    Console.WriteLine("Please enter right type of equipment!");
                }
            }
            catch
            {
                Console.WriteLine("Equipment type is not derfined!");
            }
        }

        public override void movedBy(int distance)
        {
            distanceMovedTillDate += distance;
        }
        public override void maintenanaceCostIncrease(int distance)
        {
            maintenanceCost += spacificationOfEqipment * distance;
        }

        public override void getEquipmentDetails()
        {
            Console.WriteLine("{0} :- {1}", "Name of the equipment :- ", name);
            Console.WriteLine("{0} :- {1}", "Type of the equipment :- ", type);
            Console.WriteLine("{0} :- {1}", "Description of the equipment :- ", description);
            Console.WriteLine("{0} :- {1}", "Distance moved till date :- ", distanceMovedTillDate);
            Console.WriteLine("{0} :- {1}", "Total Maintenance cost :- ", maintenanceCost);
            if (type.Equals("mobile"))
            {
                Console.WriteLine("{0} :- {1}", "Wheels in eqipment :- ", spacificationOfEqipment);
            }
            else
            {
                Console.WriteLine("{0} :- {1}", "Weight of eqipment :- ", spacificationOfEqipment);
            }
        }
    }

    public abstract class Equipment // Main Equipment Abstract Class 
    {
        public string name;
        public string description;
        public int distanceMovedTillDate;
        public int maintenanceCost;
        public enum typeOfEquipment { mobile, imMobile };
        public string type;
        public int spacificationOfEqipment;
        public virtual void setCredential()
        {
            distanceMovedTillDate = 0;
            maintenanceCost = 0;
        }
        public abstract void setSpacificationOfEquipment();
        public abstract void movedBy(int distance);
        public abstract void maintenanaceCostIncrease(int distance);
        public abstract void getEquipmentDetails();
    }



    // Program For Question 5

    public class Program5
    {
        public void Question()
        {
            while (true)
            {
                Duck duck = new Duck();
                Console.Write("Enter the type of duck 0 - Rubber, 1 - Mallard, 2 - Redhead :- ");
                int duckNumber = Convert.ToInt32(Console.ReadLine());
                switch (duckNumber)
                {
                    case 0:
                        Rubber rubber = new Rubber();
                        Console.Write("Enter the weight of duck :- ");
                        int rubberWeight = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Enter the Number of Wings in the duck :- ");
                        int rubberNumberOfWings = Convert.ToInt32(Console.ReadLine());
                        rubber.setWeight(rubberWeight);
                        rubber.setNumberOfWings(rubberNumberOfWings);
                        rubber.setTypeOfDuck(duckNumber);
                        rubber.setFlyStatus();
                        rubber.setQueakStatus();
                        rubber.showResult();
                        break;
                    case 1:
                        Mallard mallard = new Mallard();
                        Console.Write("Enter the weight of duck :- ");
                        int mallardWeight = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Enter the Number of Wings in the duck :- ");
                        int mallardNumberOfWings = Convert.ToInt32(Console.ReadLine());
                        mallard.setWeight(mallardWeight);
                        mallard.setNumberOfWings(mallardNumberOfWings);
                        mallard.setTypeOfDuck(duckNumber);
                        mallard.setFlyStatus();
                        mallard.setQueakStatus();
                        mallard.showResult();
                        break;
                    case 2:
                        Redhead redhead = new Redhead();
                        Console.Write("Enter the weight of duck :- ");
                        int redheadWeight = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Enter the Number of Wings in the duck :- ");
                        int redheadNumberOfWings = Convert.ToInt32(Console.ReadLine());
                        redhead.setWeight(redheadWeight);
                        redhead.setNumberOfWings(redheadNumberOfWings);
                        redhead.setTypeOfDuck(duckNumber);
                        redhead.setFlyStatus();
                        redhead.setQueakStatus();
                        redhead.showResult();
                        break;
                    default:
                        Console.WriteLine("Wrong input");
                        break;
                }
                
                Console.Write("Type x to exit or type anything to continue :- ");
                string s = Console.ReadLine();
                if (s.Equals("x")) break;
            }
        }
    }

    public interface IDuckProperties{
        void setFlyStatus();
        void setQueakStatus();
    }

    public class Duck
    {
        public int weight;
        public int numberOfWings;
        public string typeOfDuck;
        public string flyStatus;
        public string quackStatus;
        public enum typeOfDucks {
            Rubber,
            Mallard,
            Redhead
        }
        public void showResult()
        {
            Console.WriteLine("{0} :- {1}", "The type of duck", typeOfDuck);
            Console.WriteLine("{0} :- {1}", "The weight of duck", weight);
            Console.WriteLine("{0} :- {1}", "The number of wings", numberOfWings);
            Console.WriteLine("{0} :- {1}", "The Flying status of duck", flyStatus);
            Console.WriteLine("{0} :- {1}", "The Quack status of duck", quackStatus);
        }
    }
    public class Rubber:Duck, IDuckProperties
    {
        public void setWeight(int weight)
        {
            this.weight = weight;
        }
        public void setNumberOfWings(int numberOfWings)
        {
            this.numberOfWings = numberOfWings;
        }
        public void setTypeOfDuck(int duckNumber)
        {
            try
            {
                typeOfDuck = Enum.GetName(typeof(typeOfDucks), duckNumber);
            }
            catch
            {
                Console.WriteLine("Wrong duck number");
            }
        }
        public void setFlyStatus()
        {
            flyStatus = "Don't fly";
        }
        public void setQueakStatus()
        {
            quackStatus = "Squack";
        }
    }
    public class Mallard :Duck, IDuckProperties
    {
        public void setWeight(int weight)
        {
            this.weight = weight;
        }
        public void setNumberOfWings(int numberOfWings)
        {
            this.numberOfWings = numberOfWings;
        }
        public void setTypeOfDuck(int duckNumber)
        {
            try
            {
                typeOfDuck = Enum.GetName(typeof(typeOfDucks), duckNumber);
            }
            catch
            {
                Console.WriteLine("Wrong duck number");
            }
        }
        public void setFlyStatus()
        {
            flyStatus = "Fly fast";
        }
        public void setQueakStatus()
        {
            quackStatus = "Quack loud";
        }
    }
    public class Redhead :Duck, IDuckProperties
    {
        public void setWeight(int weight)
        {
            this.weight = weight;
        }
        public void setNumberOfWings(int numberOfWings)
        {
            this.numberOfWings = numberOfWings;
        }
        public void setTypeOfDuck(int duckNumber)
        {
            try
            {
                typeOfDuck = Enum.GetName(typeof(typeOfDucks), duckNumber);
            }
            catch
            {
                Console.WriteLine("Wrong duck number");
            }
        }
        public void setFlyStatus()
        {
            flyStatus = "Fly slow";
        }
        public void setQueakStatus()
        {
            quackStatus = "Quack mild";
        }
    }
}

