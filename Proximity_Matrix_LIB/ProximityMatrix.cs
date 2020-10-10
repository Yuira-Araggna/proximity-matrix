using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proximity_Matrix_LIB
{
    public static class ProximityMatrix
    {
        //proximity sheet 2

        public static List<string[]> Result(List<Person> inputList)
        {
            double value = 0;
            int x = 0;
            int y = 0;
            int a = 0;
            int b = 0;
            List<string[]> listOfAnswer = new List<string[]>();
            for (int i = 1; i <=(inputList.Count() - 1); i++)
            {
                string baseAnswer = "";
                if (inputList[i].Feat1.ToLower() == "yes")
                {
                    x = 1;
                }
                else
                {
                    x = 0;
                }
                if (inputList[i].Feat2.ToLower() == "yes")
                {
                    a = 1;
                }
                else
                {
                    a = 0;
                }

                foreach (Person person in inputList)
                {


                    if (person.Feat1.ToLower() == "yes")
                    {
                        y = 1;
                    }
                    else
                    {
                        y = 0;
                    }
                    if (person.Feat2.ToLower() == "yes")
                    {
                        b = 1;
                    }
                    else
                    {
                        b = 0;
                    }
                    value += Math.Pow(x - y, 2);
                    value += Math.Pow(a - b, 2);
                    value += Math.Pow(inputList[i].Feat3 - person.Feat3, 2);
                    value = Math.Sqrt(value);
                    
                    baseAnswer +=  value.ToString() + ",";
                    
                }
                string[] answer = baseAnswer.Split(',');
                listOfAnswer.Add(answer);
            }
            return listOfAnswer;

        }
    }
}
