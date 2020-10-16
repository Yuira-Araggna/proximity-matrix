using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proximity_Matrix_LIB
{
    public static class BestSplit
    {
        public static int parentCount;
        public static int node0Count;
        public static int node1Count;
        public static int node2Count;

        #region Parent
        public static double CalcGiniParent(List<Person> inputListPerson)
        {
            int yes, no;
            yes = 0;
            no = 0;

            foreach (Person person in inputListPerson)
            {
                if (person.Class.ToLower() == "yes")
                {
                    yes++;
                }
                else
                {
                    no++;
                }
            }
            double giniParent = 1 - Math.Pow((double)yes / (yes + no), 2) - Math.Pow((double)no / (yes + no), 2);
            parentCount = yes + no;
            return giniParent;
        }
        #endregion

        #region Feat1
        public static double CalcGiniNode0Feat1(List<Person> inputListPerson)
        {
            int n0c0, n0c1;
            n0c0 = 0;
            n0c1 = 0;

            foreach (Person person in inputListPerson)
            {
                if (person.Feat1.ToLower() == "yes" && person.Class.ToLower() == "yes")
                {
                    n0c0++;
                }
                else if (person.Feat1.ToLower() == "yes" && person.Class.ToLower() == "no")
                {
                    n0c1++;
                }                
            }
            int totalN1 = n0c0 + n0c1;
            double giniNode0Feat1 = 1 - Math.Pow((double)n0c0 / totalN1, 2) - Math.Pow((double)n0c1 / totalN1, 2);
            node0Count = totalN1;
            return giniNode0Feat1;
        }

        public static double CalcGiniNode1Feat1(List<Person> inputListPerson)
        {
            int n1c0, n1c1;
            n1c0 = 0;
            n1c1 = 0;

            foreach (Person person in inputListPerson)
            {
                if (person.Feat1.ToLower() == "no" && person.Class.ToLower() == "yes")
                {
                    n1c0++;
                }
                else if (person.Feat1.ToLower() == "no" && person.Class.ToLower() == "no")
                {
                    n1c1++;
                }
            }
            int totalN1 = n1c0 + n1c1;
            double giniNode1Feat1 = 1 - Math.Pow((double)n1c0 / totalN1, 2) - Math.Pow((double)n1c1 / totalN1, 2);
            node1Count = totalN1;
            return giniNode1Feat1;
        }

        public static double CalcGiniFeat1(List<Person> inputListPerson)
        {
            double giniParent, giniNode0, giniNode1;
            giniParent = CalcGiniParent(inputListPerson);
            giniNode0 = CalcGiniNode0Feat1(inputListPerson);
            giniNode1 = CalcGiniNode1Feat1(inputListPerson);

            double giniChildren = (double)node0Count / parentCount * giniNode0 + (double)node1Count / parentCount * giniNode1;

            return giniChildren;
        }
        #endregion

        #region Feat2
        public static double CalcGiniNode0Feat2(List<Person> inputListPerson)
        {
            int n0c0, n0c1;
            n0c0 = 0;
            n0c1 = 0;
            foreach (Person person in inputListPerson)
            {
                if (person.Feat2.ToLower() == "single" && person.Class.ToLower() == "yes")
                {
                    n0c0++;
                }
                else if (person.Feat2.ToLower() == "single" && person.Class.ToLower() == "no")
                {
                    n0c1 = 0;
                }
            }
            int totalYesNo = n0c0 + n0c1;
            double giniNode0Feat2 = 1 - Math.Pow((double)n0c0 / totalYesNo, 2) - Math.Pow((double)n0c1 / totalYesNo, 2);
            node0Count = totalYesNo;
            return giniNode0Feat2;
        }

        public static double CalcGiniNode1Feat2(List<Person> inputListPerson)
        {
            int n1c0, n1c1;
            n1c0 = 0;
            n1c1 = 0;
            foreach (Person person in inputListPerson)
            {
                if (person.Feat2.ToLower() == "married" && person.Class.ToLower() == "yes")
                {
                    n1c0++;
                }
                else if (person.Feat2.ToLower() == "married" && person.Class.ToLower() == "no")
                {
                    n1c1 = 0;
                }
            }
            int totalYesNo = n1c0 + n1c1;
            double giniNode1Feat2 = 1 - Math.Pow((double)n1c0 / totalYesNo, 2) - Math.Pow((double)n1c1 / totalYesNo, 2);
            node1Count = totalYesNo;
            return giniNode1Feat2;
        }

        public static double CalcGiniNode2Feat2(List<Person> inputListPerson)
        {
            int n2c0, n2c1;
            n2c0 = 0;
            n2c1 = 0;
            foreach (Person person in inputListPerson)
            {
                if (person.Feat2.ToLower() == "divorced" && person.Class.ToLower() == "yes")
                {
                    n2c0++;
                }
                else if (person.Feat2.ToLower() == "divorced" && person.Class.ToLower() == "no")
                {
                    n2c1 = 0;
                }
            }
            int totalYesNo = n2c0 + n2c1;
            double giniNode2Feat2 = 1 - Math.Pow((double)n2c0 / totalYesNo, 2) - Math.Pow((double)n2c1 / totalYesNo, 2);
            node2Count = totalYesNo;
            return giniNode2Feat2;
        }

        public static double CalcGiniFeat2(List<Person> inputListPerson)
        {
            double giniParent, giniNode0, giniNode1, giniNode2;
            giniParent = CalcGiniParent(inputListPerson);
            giniNode0 = CalcGiniNode0Feat2(inputListPerson);
            giniNode1 = CalcGiniNode1Feat2(inputListPerson);
            giniNode2 = CalcGiniNode2Feat2(inputListPerson);

            double giniChildren = node0Count / parentCount * giniNode0 + node1Count / parentCount * giniNode1 + node2Count / parentCount * giniNode2;

            return giniChildren;
        }
        #endregion

        #region Feat3
        public static double CalcGiniNode0Feat3(List<Person> inputListPerson, int inputSplit)
        {
            int n0c0, n0c1;
            n0c0 = 0;
            n0c1 = 0;

            double giniNode0Feat3;

            foreach (Person person in inputListPerson)
            {
                if (person.Feat3 <= inputSplit && person.Class.ToLower() == "yes")
                {
                    n0c0++;
                }
                else if (person.Feat3 <= inputSplit && person.Class.ToLower() == "no")
                {
                    n0c1++;
                }
            }

            if (n0c0 == 0 && n0c1 == 0)
            {
                giniNode0Feat3 = 0;
            }
            else if (n0c0 == 0)
            {
                giniNode0Feat3 = 1 - Math.Pow((double)n0c1 / (n0c0 + n0c1), 2);
            }
            else
            {
                giniNode0Feat3 = 1 - Math.Pow((double)n0c0 / (n0c0 + n0c1), 2) - Math.Pow((double)n0c0 / (n0c0 + n0c1), 2);
            }

            node0Count = n0c0 + n0c1;
            return giniNode0Feat3;
        }

        public static double CalcGiniNode1Feat3(List<Person> inputListPerson, int inputSplit)
        {
            int n1c0, n1c1;
            n1c0 = 0;
            n1c1 = 0;

            double giniNode1Feat3;

            foreach (Person person in inputListPerson)
            {
                if (person.Feat3 > inputSplit && person.Class.ToLower() == "yes")
                {
                    n1c0++;
                }
                else if (person.Feat3 > inputSplit && person.Class.ToLower() == "no")
                {
                    n1c1++;
                }
            }

            if (n1c0 == 0 && n1c1 == 0)
            {
                giniNode1Feat3 = 0;
            }
            else if (n1c0 == 0)
            {
                giniNode1Feat3 = 1 - Math.Pow((double)n1c1 / (n1c0 + n1c1), 2);
            }
            else
            {
                giniNode1Feat3 = 1 - Math.Pow((double)n1c0 / (n1c0 + n1c1), 2) - Math.Pow((double)n1c1 / (n1c0 + n1c1), 2);
            }

            node1Count = n1c0 + n1c1;
            return giniNode1Feat3;
        }

        public static double CalcGiniFeat3(List<Person> inputListPerson)
        {
            double giniFeat3 = 0;
            double giniParent = CalcGiniParent(inputListPerson);

            inputListPerson.Sort(delegate (Person x, Person y)
            {
                if (x.Feat3 == 0 && y.Feat3 == 0) return 0;
                else if (x.Feat3 == 0) return -1;
                else if (y.Feat3 == 0) return 1;
                else return x.Feat3.CompareTo(y.Feat3);
            });

            for (int i = 1; i < inputListPerson.Count; i++)
            {
                int split = (inputListPerson[i - 1].Feat3 + inputListPerson[i].Feat3) / 2;
                double giniNode0 = CalcGiniNode0Feat3(inputListPerson, split);
                double giniNode1 = CalcGiniNode1Feat3(inputListPerson, split);

                double giniChildren = (double)node0Count / parentCount * giniNode0 + (double)node1Count / parentCount * giniNode1;

                if (giniFeat3 == 0)
                {
                    giniFeat3 = giniChildren;
                }
                else if (giniFeat3 > giniChildren)
                {
                    giniFeat3 = giniChildren;
                }
            }
            return giniFeat3;
        }
        #endregion

        public static double FindBestSplit(List<Person> inputListPerson)
        {
            double bestSplit = 0;

            List<double> listOfGiniChildren = new List<double>();            
            listOfGiniChildren.Add(CalcGiniFeat1(inputListPerson));
            listOfGiniChildren.Add(CalcGiniFeat2(inputListPerson));
            listOfGiniChildren.Add(CalcGiniFeat3(inputListPerson));

            for(int i = 0; i < listOfGiniChildren.Count; i++)
            {
                if (bestSplit == 0)
                {
                    bestSplit = listOfGiniChildren[i];
                }
                else if (bestSplit > listOfGiniChildren[i])
                {
                    bestSplit = listOfGiniChildren[i];
                }
            }
            return bestSplit;
        }
        public static string FindBestSplitFeat(List<Person> inputListPerson)
        {
            string feat = "";

            List<double> listOfGini = new List<double>();
            listOfGini.Add(CalcGiniFeat1(inputListPerson));
            listOfGini.Add(CalcGiniFeat2(inputListPerson));
            listOfGini.Add(CalcGiniFeat3(inputListPerson));

            int min = 1;
            int i = 0;
            int output = 0;
            while(listOfGini[i] < min)
            {
                listOfGini[i] = min;
                i++;
                output = i;
            }
            if(output == 0)
            {
                feat = "feat1";
            }
            else if (output == 1)
            {
                feat = "feat2";
            }
            else if (output == 2)
            {
                feat = "feat3";
            }
            return feat;
        }
    }
}
