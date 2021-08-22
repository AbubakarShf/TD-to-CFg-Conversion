using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutometaProject
{
    class State
    {
        public string Name { get; set; }
        public bool IsFinal { get; set; }
        public bool IsStart { get; set; }
        public List<string> InputLetters;
        public List<string> CorrespondingStates;

        public State()
        {
            this.CorrespondingStates = new List<string>();
            this.InputLetters = new List<string>();
        }

        public void SetInputs(string input, string state)
        {
            this.InputLetters.Add(input);
            this.CorrespondingStates.Add(state);
        }

        public void Display()
        {
            Console.WriteLine("State " + this.Name);
            if (this.IsStart == true)
                Console.WriteLine("Start State");
            if (this.IsFinal == true)
                Console.WriteLine("Final State");
            Console.WriteLine("\nInput\t\tState");
            int len = this.InputLetters.Count;
            for (int i = 0; i < len; i++)
            {
                Console.WriteLine(this.InputLetters[i] + "\t\t" + this.CorrespondingStates[i]);
            }
        }
    }

}
