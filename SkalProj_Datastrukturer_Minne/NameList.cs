using System.Diagnostics;

namespace SkalProj_Datastrukturer_Minne
{
    internal class NameList
    {

        public bool NameIsValid => Name.Length > 1;
        public string Name { get; private set; }

        private List<string> list = new();
        

        public bool Add(string name)
        {
            Name = name;
            if (NameIsValid) list.Add(Name);
            return NameIsValid;
        }

        public bool Remove(string name)
        {
            Name = name;
            return list.Remove(Name);
        }

        public string Capacity()
        {
            return $"Capacity: {list.Capacity}";
            
        }

        public string Display()
        {
            string str = "";

            foreach (string item in list)
            {
                str += item + "\n";
            }
            return str;
        }

    }
}


