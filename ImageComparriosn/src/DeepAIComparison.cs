using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageComparriosn.src
{
    internal class DeepAIComparison
    {
        internal string img1 { get; set; } = "";
        internal string img2 { get; set; } = " ";
        internal int distance { get; set; } = -1;
        internal string notes { get; set; } = "";

        internal DeepAIComparison(string _img1, string _img2, int _distance = -1)
        {
            img1 = _img1;
            img2 = _img2;
            distance = _distance;
        }

        internal static DeepAIComparison ReturnMin(DeepAIComparison d1, DeepAIComparison d2)
        {
            if(d1.distance <= d2.distance)
            {
                return d1;
            }
            else
            {
                return d2;
            }
        }

        internal static List<DeepAIComparison> BubbleSort(List<DeepAIComparison> input)
        {
            Console.WriteLine("Image Comparison: Sorting Results");
            List<DeepAIComparison> result = input;
            List<DeepAIComparison> holding = new List<DeepAIComparison>();

            bool toContinue = false;
            do
            {
                toContinue = false;
                for(int i = 0; i < (input.Count); i++)
                {
                    if ((i + 1).Equals(input.Count))
                    {
                        holding.Add(input[i]);
                    }
                    else
                    {
                        DeepAIComparison min = DeepAIComparison.ReturnMin(result[i], result[i + 1]);
                        if (result[i].Equals(min))
                        {
                            holding.Add(result[i]);
                        }
                        else
                        {
                            holding.Add(result[i + 1]);
                            holding.Add(result[i]);
                            i++;
                            toContinue = true;
                        }
                    }
                }
                result.Clear();
                result.AddRange(holding);
                holding.Clear();
            } while (toContinue);

            Console.WriteLine("Image Comparison: Finished Sorting Results");

            return result;

        }
    }
}
