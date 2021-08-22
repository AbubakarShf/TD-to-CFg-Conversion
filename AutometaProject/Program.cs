using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutometaProject
{
    class Program
    {
        public static List<State> listOfStates = new List<State>();
        public static List<State> orderedListOfStates = new List<State>();



        public static void OrderTheList()
        {


            orderedListOfStates.Clear();
            foreach (State state in listOfStates)
            {
                if (state.IsStart == true)
                    orderedListOfStates.Add(state);
            }
            foreach (State state1 in listOfStates)
            {
                if (state1.IsStart == false)
                    orderedListOfStates.Add(state1);
            }
            listOfStates.Clear();
            foreach (State state2 in orderedListOfStates)
            {
                listOfStates.Add(state2);
            }
        }


        public static void Menu()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.Green;
            Console.Clear();
            Console.WriteLine("\n\n\t\t\t\t\t\t-----TD to CFG-----\n");
            Console.WriteLine("\t\t>>Develop by<<\n");
            Console.WriteLine("\t\t\tAbubakarShf(18-ntu-1050)\n");
            Console.WriteLine("\t\t\tParwaiz(18-ntu-afg-1050)\n");
            Console.WriteLine("\t\t\tUnknown(18-ntu-afg-1050)\n\n");

            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Blue;


            Console.WriteLine("\t1\tEnter a State\t\t\t\t\t\t\t");
            Console.WriteLine("\t2\tDisplay All States\t\t\t\t\t\t");
            Console.WriteLine("\t3\tSet a State as Start\t\t\t\t\t\t");
            Console.WriteLine("\t4\tSet a State as Final\t\t\t\t\t\t");
            Console.WriteLine("\t5\tEnter Input Letter and Corresponding state for a State\t\t");
            Console.WriteLine("\t6\tValidate a String\t\t\t\t\t\t");
            Console.WriteLine("\t7\tClear the Transition Diagram\t\t\t\t\t");
            Console.WriteLine("\t8\tRead Null\t\t\t\t\t\t\t");
            Console.WriteLine("\t9\tConvert to CFG\t\t\t\t\t\t\t");
            Console.WriteLine("\t0\tFor exit\t\t\t\t\t\t\t\n\n");
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.Green;
        }
        public static bool CheckStartState()
        {
            foreach (State state in listOfStates)
            {
                if (state.IsStart == true)
                    return true;
            }
            return false;
        }

        public static bool CheckFinalState()
        {
            foreach (State state in listOfStates)
            {
                if (state.IsFinal == true)
                    return true;
            }
            return false;
        }

        public static void TDtoCFG()
        {
            OrderTheList();
            if (listOfStates.Count == 0)
            {
                Console.WriteLine("No Transition Diagram found");
                return;
            }
            if (CheckStartState() == false)
            {
                Console.WriteLine("Set a start state!!!");
                return;
            }
            if (CheckFinalState() == false)
            {
                Console.WriteLine("Set a Final State");
                return;
            }
            Console.WriteLine("\n\nContext Free Grammer\n--------------------\n\n");
            foreach (State state in listOfStates)
            {
                Console.Write(state.Name + " -> ");
                int i = 0;
                for (i = 0; i < state.InputLetters.Count - 1; i++)
                {
                    Console.Write(state.InputLetters[i] + state.CorrespondingStates[i] + " / ");
                }
                Console.Write(state.InputLetters[i] + state.CorrespondingStates[i]);
                if (state.IsFinal == true)
                {
                    Console.Write(" / ^");
                }
                Console.WriteLine("\n");
            }
        }
        public static bool InputLetterLengthChecker(string name)
        {
            if (name.Length == 1)
                return true;
            else
                return false;
        }
        public static bool CheckState(string name)
        {
            foreach (State state in listOfStates)
            {
                if (state.Name == name)
                    return true;
            }
            return false;
        }
        public static void SetStartState(string name)
        {
            foreach (State state in listOfStates)
            {
                if (state.Name == name)
                {
                    state.IsStart = true;
                }
            }
        }
        public static void SetFinalState(string name)
        {
            foreach (State state in listOfStates)
            {
                if (state.Name == name)
                {
                    state.IsFinal = true;
                }
            }
        }
        public static void StartState()
        {
            if (listOfStates.Count == 0)
            {
                Console.Clear();
                Console.WriteLine("No State Found!");
                Console.ReadLine();
                return;
            }
            if (CheckStartState() == true)
            {
                Console.Clear();
                Console.WriteLine("One Transition Diagram have only one Starrt State!!!");
                Console.ReadLine();
                return;
            }
            string name;
            Console.WriteLine("Enter State Name:\t");
            name = Console.ReadLine();
            if (CheckState(name) == true)
            {
                SetStartState(name);
            }
            else
            {
                Console.Clear();
                Console.WriteLine("State with this name not exists");
                Console.ReadLine();
            }
        }
        public static void FinalState()
        {
            if (listOfStates.Count == 0)
            {
                Console.Clear();
                Console.WriteLine("No State Found!");
                Console.ReadLine();
                return;
            }
            string name;
            Console.WriteLine("Enter State Name:\t");
            name = Console.ReadLine();
            if (CheckState(name) == true)
            {
                SetFinalState(name);
            }
            else
            {
                Console.Clear();
                Console.WriteLine("State with this name not exists");
                Console.ReadLine();
            }
        }
        public static void inputState()
        {
            State s;
            int exit = 0;
            int boolvalue = 0;
            s = new State();
            Console.WriteLine("Enter State Name:\t");
            s.Name = Console.ReadLine();
            if (CheckStartState() == false)
            {
                while (true)
                {
                    Console.WriteLine("Enter 1 if it is a start state else 0:\t");
                    boolvalue = Convert.ToInt32(Console.ReadLine());
                    if (boolvalue == 1 || boolvalue == 0)
                    {
                        if (boolvalue == 1)
                            s.IsStart = true;
                        else
                            s.IsStart = false;
                        break;
                    }
                    Console.WriteLine("You Entered Invalid value!!!");
                }
            }
            while (true)
            {
                Console.WriteLine("Enter 1 if it is a final state else 0:\t");
                boolvalue = Convert.ToInt32(Console.ReadLine());
                if (boolvalue == 1 || boolvalue == 0)
                {
                    if (boolvalue == 1)
                        s.IsFinal = true;
                    else
                        s.IsFinal = false;
                    break;
                }
                Console.WriteLine("You Entered Invalid value!!!");
            }
            listOfStates.Add(s);
            Console.Clear();
            Console.WriteLine("State " + s.Name + " Entered Successfully");
            Console.ReadLine();
        }

        public static string GetCorrespondingState(string name)
        {

            foreach (State state in listOfStates)
            {
                if (state.Name == name)
                    return state.Name;
            }
            return "";
        }

        public static void SetInput(string name, string letter, string corState)
        {
            foreach (State state in listOfStates)
            {
                if (state.Name == name)
                {
                    state.SetInputs(letter, corState);
                }
            }
        }
        public static void Inputs()
        {
            string inputletter;
            string statename;
            if (listOfStates.Count == 0)
            {
                Console.Clear();
                Console.WriteLine("No State Found!");
                Console.ReadLine();
                return;
            }
            string name;
            Console.WriteLine("Enter State Name:\t");
            name = Console.ReadLine();
            if (CheckState(name) == true)
            {
                while (true)
                {
                    Console.Clear();
                    Console.WriteLine("Enter Input Letter:\t");
                    inputletter = Console.ReadLine();
                    if (InputLetterLengthChecker(inputletter) == true)
                    {
                        break;
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Length of Input Letter must be 1!!!");
                        Console.ReadLine();
                    }
                }
                while (true)
                {
                    Console.Clear();
                    Console.WriteLine("Enter Corresponding State Name:\t");
                    statename = Console.ReadLine();
                    if (CheckState(statename) == true)
                    {
                        break;
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("State with this name not Exists!!!");
                        Console.ReadLine();
                    }
                }
                SetInput(name, inputletter, GetCorrespondingState(statename));
            }
            else
            {
                Console.Clear();
                Console.WriteLine("State with this name not exists");
                Console.ReadLine();
            }
        }

        public static void Display()
        {
            if (listOfStates.Count == 0)
            {
                Console.Clear();
                Console.WriteLine("No State Found");
                return;
            }
            OrderTheList();
            foreach (State state in listOfStates)
            {
                Console.WriteLine("\n");
                state.Display();
            }
        }

        public static string myFun2(string input, string stateName)
        {
            foreach (State state in listOfStates)
            {
                if (state.Name == stateName)
                {
                    for (int i = 0; i < state.InputLetters.Count; i++)
                    {
                        if (input == state.InputLetters[i])
                        {
                            return state.CorrespondingStates[i];
                        }
                    }
                }
            }
            return "";
        }

        public static void myFun(string inputString)
        {
            OrderTheList();
            bool ressult = true;
            int length = inputString.Length;
            string stateName;
            stateName = listOfStates[0].Name;
            for (int i = 0; i < inputString.Length; i++)
            {
                stateName = myFun2(inputString[i].ToString(), stateName);
                if (stateName == "")
                {
                    ressult = false;
                }
            }
            if (ressult == false)
            {
                Console.Clear();
                Console.WriteLine("Invalid String!!!");
                return;
            }
            else
            {
                foreach (State state in listOfStates)
                {
                    if (state.Name == stateName)
                    {
                        if (state.IsFinal == true)
                        {
                            Console.Clear();
                            Console.WriteLine("Valid String!!!");
                            return;
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("InValid String Dead end state!!!");
                            return;
                        }
                    }
                }
            }
        }

        public static void ValidateString()
        {
            string inputString;
            if (listOfStates.Count == 0)
            {
                Console.Clear();
                Console.WriteLine("No State Exists!!" +
                    "Input Some Sates");
                return;
            }
            if (CheckStartState() == false)
            {
                Console.Clear();
                Console.WriteLine("Transition Diagram must have a Start State");
                return;
            }
            if (CheckFinalState() == false)
            {
                Console.Clear();
                Console.WriteLine("Transition Diagram must have a Final State");
                return;
            }
            Console.WriteLine("Enter a String:\t");
            inputString = Console.ReadLine();
            myFun(inputString);
        }

        public static void ReadNull()
        {
            OrderTheList();
            if (listOfStates.Count == 0)
            {
                Console.Clear();
                Console.WriteLine("Transition Diagram not found!!!");
                return;
            }
            else
            {
                if (listOfStates[0].IsStart == true && listOfStates[0].IsFinal == true)
                {
                    Console.WriteLine("Null is a Valid String!!!");
                }
                else
                {
                    Console.WriteLine("Null is an Invalid String!!!");
                }
            }
        }

        static void Main(string[] args)
        {
            int exit = 1;
            int menuSelector = 0;
            while (true)
            {
                Console.Clear();
                Menu();
                Console.WriteLine("\t\tEnter Your Choice:\t\t\t\t\t");
                menuSelector = Convert.ToInt32(Console.ReadLine());
                switch (menuSelector)
                {
                    case 1:
                        Console.Clear();
                        inputState();
                        break;
                    case 2:
                        Console.Clear();
                        Display();
                        Console.ReadLine();
                        break;
                    case 3:
                        Console.Clear();
                        StartState();
                        break;
                    case 4:
                        Console.Clear();
                        FinalState();
                        break;
                    case 5:
                        Console.Clear();
                        Inputs();
                        break;
                    case 6:
                        Console.Clear();
                        ValidateString();
                        Console.ReadLine();
                        break;
                    case 7:
                        Console.Clear();
                        listOfStates.Clear();
                        Console.WriteLine("Transition Diagram is Deleted!!!");
                        Console.ReadLine();
                        break;
                    case 8:
                        Console.Clear();
                        ReadNull();
                        Console.ReadLine();
                        break;
                    case 9:
                        Console.Clear();
                        TDtoCFG();
                        Console.ReadLine();
                        break;
                    case 0:
                        exit = 0;
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Invalid Choice");
                        Console.ReadLine();
                        break;
                }
                if (exit == 0)
                    break;
            }
        }
    }

}