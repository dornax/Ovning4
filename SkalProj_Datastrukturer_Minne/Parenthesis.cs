using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Tests")]

namespace SkalProj_Datastrukturer_Minne
{
    internal class Parenthesis
    {

        public bool IsBalanced(string str)
        {
            
            Dictionary<char, char> parenthesis = new Dictionary<char, char>() { { '(', ')' }, { '[', ']' }, { '{', '}' } };
            char lastParenthesis = ' ';
            bool leftParenthesis = false;
            Stack<char> stack = new();
            
            foreach (char c in str)
            {
                if (parenthesis.ContainsKey(c))
                {
                    lastParenthesis = c;
                    stack.Push(c);
                    leftParenthesis = true;
                }

                else if (parenthesis.ContainsValue(c) && stack.Count > 0)
                {
                    if (parenthesis.TryGetValue(lastParenthesis, out char result))
                    {
                        if (c == result && stack.Count > 0)
                        {
                            stack.Pop();
                            if (stack.Count > 0) lastParenthesis = stack.Peek();
                        }
                    }
                }
                else if (parenthesis.ContainsValue(c) && stack.Count == 0) return false;
            }

            if (leftParenthesis) return stack.Count == 0;
            else return false;
        }
    }
}

