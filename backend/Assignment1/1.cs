using System;

namespace ConsoleApp1
{
    public class MainClass
    {
        public static void Main()
        {
            while (true)
            {
                Console.Write("Type: 1 - Exercise1, 2 - Exercise2, 3 - Exercise3  =>  ");
                string s = Console.ReadLine();
                switch (s)
                {
                    case "1":
                        Program1 firstQuestion = new Program1();
                        firstQuestion.Question();
                        break;
                    case "2":
                        Program2 secondQuestion = new Program2();
                        secondQuestion.Question();
                        break;
                    case "3":
                        Program3 thirdQuestion = new Program3();
                        thirdQuestion.Question();
                        break;
                    default:
                        Console.WriteLine("Wrong input");
                        break;
                }
                Console.Write("Enter c to continue or any key to exit");
                string str = Console.ReadLine();
                if (!str.Equals("c")) break;
            }
        }
    }
    public class Program1
    {
        public void Question()
        {
            Program1 Pro1 = new Program1();
            Console.Write("Enter Input :- ");
            string s = Console.ReadLine();
            Console.Write("Choose 1 : int, 2 : float, 3 : boolen :- ");
            string c = Console.ReadLine();
            switch (c)
            {
                case "1":
                    Pro1.convertInt(s);
                    break;
                case "2":
                    Pro1.convertFloat(s);
                    break;
                case "3":
                    Pro1.convertBoolen(s);
                    break;
                default:
                    Console.WriteLine("Wrong input");
                    break;
            }
        }
        public void convertInt(string s)
        { 
            try
            {
                // Using Int32.Parse
                Console.Write("Using int32.Parse :- ");
                Console.WriteLine(Int32.Parse(s));
                // Using Convert.ToInt32
                Console.Write("Using Convert.ToInt32 :- ");
                Console.WriteLine(Convert.ToInt32(s));

                // Using int.TryParse
                int convertedInt;
                Console.Write("Using int.TryParse :- ");
                int.TryParse(s, out convertedInt);
                Console.WriteLine(convertedInt);
            }
            catch{
                Console.WriteLine("Error cause while converting to int bcz input is not in Integer formate");  
            }
        }
        public void convertFloat(string s)
        {
            try
            {
                // Using float.Parse
                Console.Write("Using float.Parse :- ");
                Console.WriteLine(float.Parse(s));

                // Using Convert.ToDouble
                Console.Write("Using Convert.ToDouble :- ");
                Console.WriteLine(Convert.ToDouble(s));

                // Using flaot.TryParse
                float convertedFloat;
                Console.Write("Using float.TryParse:- ");
                float.TryParse(s, out convertedFloat);
                Console.WriteLine(convertedFloat);
            }
            catch
            {
                Console.WriteLine("Error cause while converting to int bcz input is not in Float formate");
            }
            
        }
        public void convertBoolen(string s)
        {
            try
            {
                // Using bool.Parse
                Console.Write("Using bool.Parse :- ");
                Console.WriteLine(bool.Parse(s));

                // Using Convert.ToBoolean
                Console.Write("Using Convert.ToBoolen :- ");
                Console.WriteLine(Convert.ToBoolean(s));

                // Using bool.TryParse
                bool convertedBool;
                Console.Write("Using bool.TryParse:- ");
                bool.TryParse(s, out convertedBool);
                Console.WriteLine(convertedBool);
            }
            catch
            {
                Console.WriteLine("Error cause while converting to int bcz input is not in Boolen formate");
            }
            
        }
    }






    public class Program2
    {

        public void Question()
        {
            object firstObject = null; // Null Object
            object secondObject = new object(); // A Non-null Object
            object thirdObject = null; // Null Object
            object fourthObject = new object(); // A Non-null Object

            Console.WriteLine("For \"==\" Operator====> ");
            Console.WriteLine("For {0} =>>> {1}", "(firstObject(Null) == secondObject(Non-null))", firstObject == secondObject);
            Console.WriteLine("For {0} =>>> {1}", "(firstObject(Null) == thirdObject(Null))", firstObject == thirdObject);
            Console.WriteLine("For {0} =>>> {1}", "(secondObject(Non-null) == thirdObject(Null))", secondObject == thirdObject);

            Console.WriteLine("\nFor \"Equals\" Method====> ");
            try 
            { 
                Console.WriteLine("For {0} =>>> {1}", "(secondObject(Non-null).Equals(fourthObject(Non-null)))",secondObject.Equals(fourthObject)); // Comparing Two Non-null objects
            } 
            catch (Exception e) 
            { 
                Console.WriteLine("For {0} =>>> {1}", "(secondObject(Non-null).Equals(fourthObject(Non-null)))", e.GetType()); 
            }
            try 
            { 
                Console.WriteLine("For {0} =>>> {1}", "(thirdObject(Null).Equals(firstObject(Null)))", thirdObject.Equals(firstObject)); // Comparing Two null object -- will give error bcz both are null and comparing a null object
            } 
            catch(Exception e) 
            { 
                Console.WriteLine("For {0} =>>> {1}", "(thirdObject(Null).Equals(firstObject(Null)))", e.GetType()); 
            }
            try 
            { 
                Console.WriteLine("For {0} =>>> {1}", "(firstObject(Null).Equals(secondObject(Non-null)))", firstObject.Equals(secondObject)); // Comparing null object to Non-null object will give error because we are comparing a null object 
            } 
            catch (Exception e) 
            { 
                Console.WriteLine("For {0} =>>> {1}", "(firstObject(Null).Equals(secondObject(Non-null)))", e.GetType()); 
            }
            try 
            { 
                Console.WriteLine("For {0} =>>> {1}", "(firstObject(Null).Equals(thirdObject(Null)))", firstObject.Equals(thirdObject)); // Comparing Two null object -- will give error bcz both are null and comparing a null object
            } 
            catch (Exception e) 
            {
                Console.WriteLine("For {0} =>>> {1}", "(firstObject(Null).Equals(thirdObject(Null)))", e.GetType()); 
            }
            try 
            { 
                Console.WriteLine("For {0} =>>> {1}", "(secondObject(Non-null).Equals(thirdObject(Null)))", secondObject.Equals(thirdObject)); // Comparing Non-null object with null give FALSE because we are comparing a non null object with null object. 
            } 
            catch (Exception e) 
            { 
                Console.WriteLine("For {0} =>>> {1}", "(secondObject(Non-null).Equals(thirdObject(Null)))", e.GetType()); 
            }


            Console.WriteLine("\nFor \"ReferenceEquals\" Method====> ");
            Console.WriteLine("For {0} =>>> {1}", "ReferenceEquals(firstObject(Null),secondObject(Non-null)", ReferenceEquals(firstObject,secondObject));
            Console.WriteLine("For {0} =>>> {1}", "ReferenceEquals(firstObject(Null),thirdObject(Null)", ReferenceEquals(firstObject,thirdObject));
            Console.WriteLine("For {0} =>>> {1}", "ReferenceEquals(thirdObject(Null),firstObject(Null)", ReferenceEquals(thirdObject, firstObject));
            Console.WriteLine("For {0} =>>> {1}", "ReferenceEquals(secondObject(Non-null),thirdObject(Null)", ReferenceEquals(secondObject,thirdObject));
            Console.WriteLine("For {0} =>>> {1}", "ReferenceEquals(secondObject(Non-null),fourthObject(Non-null)", ReferenceEquals(secondObject, fourthObject));
        }
    }



    public class Program3
    {
        public void Question()
        {
            while (true)
            {
                Console.WriteLine("Enter two numbers first number should be less than second number");
                Console.Write("Enter first number -> ");
                int firstNumber = Convert.ToInt32(Console.ReadLine());
                Console.Write("Enter second number -> ");
                int secondNumber = Convert.ToInt32(Console.ReadLine());
                if(firstNumber >= secondNumber)
                {
                    Console.WriteLine("First number should be greater then second number");
                    Console.WriteLine("Please Enter Right Crediantial");
                    continue;
                }
                else if(firstNumber<0 || secondNumber < 0)
                {
                    Console.WriteLine("Any or both of the number is negetive");
                    Console.WriteLine("Please Enter Right Crediantial");
                    continue;
                }
                else if(firstNumber<2 || firstNumber>1000 || secondNumber<2 || secondNumber>1000){
                    Console.WriteLine("Any or both of the number is not is not in range (2 - 1000)");
                    Console.WriteLine("Please Enter Right Crediantial");
                    continue;
                }

                Program3 checkPrimeNumber = new Program3();
                for(int i = firstNumber; i <= secondNumber; i++)
                {
                    if (checkPrimeNumber.checkPrime(i))
                    {
                        Console.Write("{0}, ",i);
                    }
                }
                Console.WriteLine();
                Console.Write("Enter c to continue or any key to exit");
                string s = Console.ReadLine();
                if (!s.Equals("c")) break;
            }
        }

        public bool checkPrime(int number)
        {
            for(int i = 2; i <= number / 2; i++) // Run loop till half of the number because the number cann't devisible by second half number. So we check for second half numbers.  
            {
                if (number % i == 0) return false;
            }
            return true;
        }
    }



}
