using System.Linq;

namespace Client
{
    static public class StringExtensions
    {
        static public string Capitalize(this string str)
        {
            string first, second, output;
            if (str == null)
            {
                return null;
            }
            if (str[0].ToString() == str[0].ToString().ToUpper())
                return str;
            else
            {
                
                if(str.Split(' ').Count()== 1)
                {
                     first = str[0].ToString().ToUpper();
                     output = first + str.Remove(0,1);
                }
                else
                {
                    var elements = str.Split(' ');
                    first = (elements[0])[0].ToString().ToUpper();
                    output = first + (elements[0]).ToString().Remove(0, 1);

                    second = (elements[1])[0].ToString().ToUpper();
                    output += " " + second + elements[1].Remove(0, 1);
                }
                return output;
            }
        }
    }
}
