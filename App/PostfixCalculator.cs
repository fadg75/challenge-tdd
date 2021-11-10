using System;
using System.Collections.Generic;
using System.Linq;

namespace App
{
    public static class PostfixCalculator
    {
        public static string Calculate(string postfixExpression)
        {
            if (postfixExpression == null)
            {
                throw new FormatException();
            }
            if (postfixExpression.Length == 0)
            {
                return "0";
            }
            var array = postfixExpression.Split(' ');
            int index = 0;
            var st = new Stack<int>();
            while(index < array.Length)
            {
                try
                {
                    if (array[index] == "+")
                    {
                        var x = st.Pop();
                        var y = st.Pop();
                        st.Push(x + y);
                    }
                    if (array[index] == "-")
                    {
                        var x = st.Pop();
                        var y = st.Pop();
                        st.Push(y - x);
                    }
                    if (array[index] == "*")
                    {
                        var x = st.Pop();
                        var y = st.Pop();
                        st.Push(x * y);
                    }
                    if (array[index] != "+" && array[index] != "-" && array[index] != "*")
                    {
                        st.Push(int.Parse(array[index]));
                    }
                }
                catch
                {
                    throw new FormatException();
                }
                index++;
            }
            if(st.Count > 1)
            {
                throw new FormatException();
            }
            return st.Pop().ToString();
        }
    }
}
