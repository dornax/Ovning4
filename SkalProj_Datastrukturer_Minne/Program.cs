using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Reflection.PortableExecutable;
using System.Security.Cryptography.X509Certificates;

namespace SkalProj_Datastrukturer_Minne
{
    class Program
    {
        /// <summary>
        /// The main method, will handle the menues for the program
        /// </summary>
        /// <param name="args"></param>
        /* 1. Hur fungerar stacken och heapen?
         * Stacken är av typen LIFO, last in first out. Om man vill komma åt objektet
         * som ligger under det översta måste man först ta bort det översta objektet
         *
         * Heapen är en slags träd-struktur där man har enkel åtkomst till alla object. 
         * 
         * 2. Vad är Value Types respektive Reference Types och vad skiljer dem åt?
         *    Value Types är ex int, float, char, bool. Reference type är class, interface, object
         *    delegate och string. Value types lagras på stacken eller heapen. Reference Types lagras
         *    alltid på heapen.
         *    
         * 3. ReturnValue() returnerar 3 eftersom värdet på x inte ändras. ReturnValaue2 retunerar 4 
         *    eftersom referensen till y sätts lika med referensen til x. När värdet på y sätts, sätts
         *    även värdet på x, eftersom de har samma referens.
         */
        static void Main()
        {

            while (true)
            {
                Console.WriteLine("Please navigate through the menu by entering the number "
                    + "\n(1, 2, 3 ,4, 0) of your choice"
                    + "\n1. Examine a List"
                    + "\n2. Examine a Queue"
                    + "\n3. Examine a Stack"
                    + "\n4. CheckParanthesis"
                    + "\n0. Exit the application");

                string input = Console.ReadLine()!;
                string nav = string.IsNullOrEmpty(input) ? "" : input.Substring(0, 1);

                switch (nav)
                {
                    case "1":
                        ExamineList();
                        break;
                    case "2":
                        ExamineQueue();
                        break;
                    case "3":
                        ExamineStack();
                        break;
                    case "4":
                        CheckParanthesis();
                        break;
                    /*
                     * Extend the menu to include the recursive 
                     * and iterative exercises.
                     */
                    case "0":
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Please enter some valid input (0, 1, 2, 3, 4)");
                        break;
                }
            }
        }

       


        /// <summary>
        /// Examines the datastructure List
        /// </summary>
        static void ExamineList()
        {
            /*
             * Loop this method untill the user inputs something to exit to main menue.
             * Create a switch statement with cases '+' and '-'
             * '+': Add the rest of the input to the list (The user could write +Adam and "Adam" would be added to the list)
             * '-': Remove the rest of the input from the list (The user could write -Adam and "Adam" would be removed from the list)
             * In both cases, look at the count and capacity of the list
             * As a default case, tell them to use only + or -
             * Below you can see some inspirational code to begin working.
            */

            /*
             * 2. När ökar listans kapacitet?
             *    När count är lika med capacity och man lägger till ett element.
             * 
             * 3. Med hur mycket ökar kapaciteten?
             *    Med 4 element.
             * 
             * 4. Varför ökar inte listans kapacitet i samma takt som element läggs till?
             *    Eftersom listans underliggande array kopieras till en ny array när 
             *    listans kapacitet ökas ned 4. 
             * 
             * 5. Minskar kapaciteten när element tas bort ur listan? 
             *    Nej
             *    
             * 6. När är det då fördelaktigt att använda en egendefinierad array istället för en lista?
             *    När man har ett givet konstant antal element man ska lagra.
             */
            
            WriteListMenu();
            NameList list = new();
            bool quit = false;
            while (!quit)
            {
                string input = Console.ReadLine()!;
                string nav = string.IsNullOrEmpty(input) ? "" : input.Substring(0, 1);
                switch (nav)
                {
                    case "+":
                        if (!list.Add(input.Substring(1, input.Length - 1)))
                            Console.WriteLine("Name must have at least 2 characters");
                        break;
                    case "-":
                        list.Remove(input.Substring(1, input.Length - 1));
                        break;
                    case "d":
                        string display = list.Display();
                        if (display == "") Console.WriteLine("List is empty");
                        else Console.Write(display);
                        break;
                    case "c":
                        Console.WriteLine(list.Capacity());
                        break;
                    case "q":
                        quit = true;
                        break;
                    default:
                        Console.WriteLine("Enter +Name, -Name, c, d, or q");
                        break;
                }
            }
        }


        private static void WriteListMenu()
        {
            Console.WriteLine("Please manage the list by entering"
                + "\n+Name to add Name to the list"
                + "\n-Name to remove Name from the list"
                + "\nc Show capacity"
                + "\nd Display the list"
                + "\nq Quit, goto main menu");
        }

        private static void WriteQueueMenu()
        {
            Console.WriteLine("Please manage the qeue by entering"
                + "\n+Name to add Name to the queue"
                + "\n- Remove first Name from the queue"
                + "\nd Display the queue"
                + "\nq Quit, goto main menu");
        }

        private static void WriteStackMenu()
        {
            Console.WriteLine("Please manage the list by entering"
                + "\n+Name to push Name to the stack"
                + "\n- Pop the stack"
                + "\nd Display the stack"
                + "\nr Reverse text"
                + "\nq Quit, goto main menu");
        }

        /// <summary>
        /// Examines the datastructure Queue
        /// </summary>
        static void ExamineQueue()
        {
            /*
             * Loop this method untill the user inputs something to exit to main menue.
             * Create a switch with cases to enqueue items or dequeue items
             * Make sure to look at the queue after Enqueueing and Dequeueing to see how it behaves
             */

            /* 1. Simulera kö
             *                                  Kön 
             *    Start                         Tom
             *    Kalle ställer sig i kön       Kalle
             *    Greta ställer sig i kön       Kalle Greta
             *    Kalle lämnar kön              Greta
             *    Stina ställer sig i kön       Greta Stina
             *    Olle ställer sig i kön        Greta Stina Olle
             */

            WriteQueueMenu();
            Queue<string> queueLine = new Queue<string>();
            bool quit = false;
            while (!quit)
            {
                
                string input = Console.ReadLine()!;
                string nav = string.IsNullOrEmpty(input) ? "" : input.Substring(0, 1);

                switch (nav)
                {
                    case "+":
                        input = input.Substring(1, input.Length - 1);
                        if (input.Length > 1)
                            queueLine.Enqueue(input);
                        else
                            Console.WriteLine("Name must be at least 2 characters long");
                        break;
                    case "-":
                        if (queueLine.Count > 0)
                            Console.WriteLine($"Removed: {queueLine.Dequeue()}");
                        else Console.WriteLine("Queue is empty");
                        break;
                    case "d":
                        DisplayQueue(queueLine);
                        break;
                    case "q":
                        quit = true;
                        break;
                    default:
                        Console.WriteLine("Enter +Name, -, d, or q");
                        break;
                }
            }
        }

        private static void DisplayQueue(Queue<string> queueLine)
        {
            if (queueLine.Count > 0)
            {
                foreach (string item in queueLine)
                {
                    Console.WriteLine(item);
                }
            }
            else Console.WriteLine("Queue is empty");
        }

        /// <summary>
        /// Examines the datastructure Stack
        /// </summary>
        static void ExamineStack()
        {
            /*
             * Loop this method until the user inputs something to exit to main menue.
             * Create a switch with cases to push or pop items
             * Make sure to look at the stack after pushing and and poping to see how it behaves
            */


            Stack<string> stack = new Stack<string>();

            WriteStackMenu();

            bool quit = false;
            while (!quit)
            {
                string input = Console.ReadLine()!;
                string nav = string.IsNullOrEmpty(input) ? "" : input.Substring(0, 1);
                switch (nav)
                {

                    case "+":
                        input = input.Substring(1, input.Length - 1);
                        if (input.Length > 1)
                            stack.Push(input);
                        else
                            Console.WriteLine("Name must be at least 2 characters long");
                        break;
                    case "-":
                        if (stack.Count > 0)
                            Console.WriteLine($"Removed: {stack.Pop()}");
                        else Console.WriteLine("Stack empty");
                        break;
                    case "d":
                        DisplayStack(stack);
                        break;
                    case "r":
                        Console.WriteLine("Enter text");
                        input = Console.ReadLine()!;
                        if (!string.IsNullOrEmpty(input))
                            Console.WriteLine(ReverseString(input));
                        else Console.WriteLine("No input");
                        break;
                    case "q":
                        quit = true;
                        break;
                    default:
                        Console.WriteLine("Enter +Name, -, d, r, or q");
                        break;
                }
            }
        }


        private static void DisplayStack(Stack<string> stack)
        {
            foreach (string item in stack)
            {
                Console.WriteLine(item);
            }
        }

        private static string ReverseString(string input)
        {
            Stack<char> chars = new Stack<char>();
            foreach (char ch in input)
            {
                chars.Push(ch);
            }
            string output = "";

            foreach (char ch in chars)
            {
                output += ch;
            }

            return output;
        }

        static void CheckParanthesis()
        {
            /*
             * Use this method to check if the paranthesis in a string is Correct or incorrect.
             * Example of correct: (()), {}, [({})],  List<int> list = new List<int>() { 1, 2, 3, 4 };
             * Example of incorrect: (()]), [), {[()}],  List<int> list = new List<int>() { 1, 2, 3, 4 );
             */

            /* 1.
             * Använder stack
             *
             * Itterera genom strängen 
             *      if char = ( or [ or {
             *      push char 
             *      else 
             *          if char = ) or ] or }
             *          pop motsvarande parantes
             *      if stacken är tom 
             *          strängen välformad
             *      else 
             *          strängen inte välformad
             */


            Parenthesis parenthesis = new();
            Console.WriteLine("Enter text to test if parantesis are balanced");
            string input = Console.ReadLine()!;
            if (!string.IsNullOrEmpty(input) && input.Length > 1)
            {
                if (parenthesis.IsBalanced(input)) Console.WriteLine("Parenthesis are balanced");
                else Console.WriteLine("Parenthises are not balanced");
            }
            else Console.WriteLine("Text must be at least 2 characters long");
        }

    }
}


