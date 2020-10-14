using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proximity_Matrix_LIB
{
    public static class ProximityMatrix
    {
        //proximity dataset1
        static double[,] arrNominalProx;
        static double[,] arrNumericProx;
        static double[,] arrMixedProx;

        public static void nominalProxDist(List<Person> inputListPerson)
        {
            arrNominalProx = new double[inputListPerson.Count, inputListPerson.Count];
            int nominalAttr = 2;

            for (int i = 0; i < inputListPerson.Count; i++)
            {
                int matchingAttr = 0;
                for (int j = 0; j < inputListPerson.Count; j++)
                {
                    if(inputListPerson[i].Feat1 == inputListPerson[j].Feat1 && inputListPerson[i].Feat2 == inputListPerson[j].Feat2)
                    {
                        matchingAttr = +2;
                    }
                    else if (inputListPerson[i].Feat1 == inputListPerson[j].Feat1 || inputListPerson[i].Feat2 == inputListPerson[j].Feat2)
                    {
                        matchingAttr++;
                    }

                    double proximityVal = (double)(nominalAttr - matchingAttr) / 2;

                    arrNominalProx[i, j] = proximityVal;
                }
            }
        }

        public static void numericProxDist(List<Person> inputListPerson)
        {
            arrNominalProx = new double[inputListPerson.Count, inputListPerson.Count];

            int min, max;
            min = inputListPerson[0].Feat3;
            max = inputListPerson[0].Feat3;
            for (int i = 1; i < inputListPerson.Count; i++)
            {
                if (inputListPerson[i].Feat3 < min)
                {
                    min = inputListPerson[i].Feat3;
                }
                if(inputListPerson[i].Feat3 > max)
                {
                    max = inputListPerson[i].Feat3;
                }
            }

            for (int i = 0; i < inputListPerson.Count; i++)
            {
                for (int j = 0; j < inputListPerson.Count; j++)
                {
                    int iFeat3 = inputListPerson[i].Feat3;
                    int jFeat3 = inputListPerson[j].Feat3;
                    double proximityVal = Math.Pow(iFeat3 - jFeat3, 2)/(max - min);
                    arrNumericProx[i, j] = proximityVal;
                }
            }
        }

        public static void mixedProxDist(List<Person> inputListPerson)
        {
            arrMixedProx = new double[inputListPerson.Count, inputListPerson.Count];
            int validF1F2, validF3;

            for (int i = 0; i < inputListPerson.Count; i++)
            {
                for (int j = 0; j < inputListPerson.Count; j++)
                {
                    if (inputListPerson[i].Feat1 == null || inputListPerson[j].Feat1 == null || inputListPerson[i].Feat2 == null || inputListPerson[j].Feat2 == null)
                    {
                        validF1F2 = 0;
                    }
                    else
                    {
                        validF1F2 = 1;
                    }
                    if (inputListPerson[i].Feat3 == 0 || inputListPerson[j].Feat3 == 0)
                    {
                        validF3 = 0;
                    }
                    else
                    {
                        validF3 = 1;
                    }

                    double proximityVal = (validF1F2 * arrNominalProx[i, j]) + (validF3 * arrNumericProx[i, j]) / (validF1F2 + validF3);

                    arrMixedProx[i, j] = proximityVal;
                }
            }
        }

        /*public static List<string[]> Result(List<Person> inputList)
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

        }*/
    }
}
