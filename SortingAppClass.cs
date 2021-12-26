using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingApp
{
    public class RandomNumbers
    {

        private int lengthValue;
        public int length
        {
            get { return lengthValue; }
            set { lengthValue = value; }
        }

        public Tuple<List<int>, List<int>> FakeGenerate()
        {
            int[] numbers = { 4, 15, 3, 1, 5, 83, 84, 93, 17, 21 };
            int[] numbers_ordered = { 1, 3, 4, 5, 15, 17, 21, 83, 84, 93 };

            return Tuple.Create(new List <int> (numbers), new List<int> (numbers_ordered));
        }
        public List <int> Generate(int length)
        {
            
            Random rand = new Random();
            List <int> numList = new List<int>();
            for (int i = 0; i < length; i++)
            {
                numList.Add(rand.Next(0, 1000 * length));
            }

            return numList;
        }

        public class Bubble : IAlgo
        {
            public char Id => '0';

            public string Name => "Bubble Sort";

            public List<int> Sort(List<int> numList)
            {
                int dumble;

                for (int j = 0; j <= numList.Count - 2; j++)
                {
                    for (int i = 0; i <= numList.Count - 2; i++)
                    {
                        if (numList[i] > numList[i + 1])
                        {
                            dumble = numList[i + 1];
                            numList[i + 1] = numList[i];
                            numList[i] = dumble;
                        }
                    }
                }
                return numList;


            }
        }


        public class Insertion : IAlgo
        {
            public char Id => '1';

            public string Name => "Insertion Sort";

            public List<int> Sort(List<int> numList)
            {
                int n = numList.Count, i, j, val;

                for (i = 1; i < n; i++)
                {
                    val = numList[i];
                    for (j = i - 1; j >= 0;)
                    {
                        if (val < numList[j])
                        {
                            numList[j + 1] = numList[j];
                            j--;
                            numList[j + 1] = val;
                        }
                        else
                        {
                            break;
                        }
                    }
                }

                return numList;

            }

        }


        public class Selection : IAlgo
        {
            public char Id => '2';

            public string Name => "Selection Sort";

            public List<int> Sort(List<int> numList)
            {
                int n = numList.Count;
                int temp, smallest;

                for(int i = 0; i < n - 1; ++i)
                {
                    smallest = i;

                    for(int j = i + 1; j < n; j++)
                    {
                        if (numList[j] < numList[smallest])
                        {
                            smallest = j;
                        }
                    }

                    temp = numList[smallest];
                    numList[smallest] = numList[i];
                    numList[i] = temp;
                }
                return numList;
            }
        }




        public class Quick : IAlgo
        {
            public char Id => '3';

            public string Name => "Quick Sort";

            public List<int> Sort(List<int> numList)
            {
                static void Quick_Sort(List<int> numList, int left, int right)
                {
                    if (left < right)
                    {
                        int pivot = Partition(numList, left, right);

                        if (pivot > 1)
                        {
                            Quick_Sort(numList, left, pivot - 1);
                        }
                        if (pivot + 1 < right)
                        {
                            Quick_Sort(numList, pivot + 1, right);
                        }
                    }

                }

                static int Partition(List<int> numList, int left, int right)
                {
                    int pivot = numList[left];
                    while (true)
                    {

                        while (numList[left] < pivot)
                        {
                            left++;
                        }

                        while (numList[right] > pivot)
                        {
                            right--;
                        }

                        if (left < right)
                        {
                            if (numList[left] == numList[right]) return right;

                            int temp = numList[left];
                            numList[left] = numList[right];
                            numList[right] = temp;


                        }
                        else
                        {
                            return right;
                        }
                    }
                }

                Quick_Sort(numList, 0, numList.Count - 1);
                return numList;

            }
        }

        public class Merge : IAlgo
        {
            public char Id => '4';

            public string Name => "Merge Sort";

            public List<int> Sort(List<int> numList)
            {
                static void MainMerge(List<int> numList, int left, int mid, int right)
                {
                    int[] temp = new int[numList.Count];
                    int i, eol, num, pos;
                    eol = (mid - 1);
                    pos = left;
                    num = (right - left + 1);

                    while ((left <= eol) && (mid <= right))
                    {
                        if (numList[left] <= numList[mid])
                            temp[pos++] = numList[left++];
                        else
                            temp[pos++] = numList[mid++];
                    }
                    while (left <= eol)
                        temp[pos++] = numList[left++];
                    while (mid <= right)
                        temp[pos++] = numList[mid++];
                    for (i = 0; i < num; i++)
                    {
                        numList[right] = temp[right];
                        right--;
                    }
                }

                static void SortMerge(List<int> numList, int left, int right)
                {
                    int mid;
                    if (right > left)
                    {
                        mid = (right + left) / 2;
                        SortMerge(numList, left, mid);
                        SortMerge(numList, (mid + 1), right);
                        MainMerge(numList, left, (mid + 1), right);
                    }
                }

                SortMerge(numList, 0, numList.Count - 1);
                return numList;

            }
        }

        public List <IAlgo> AllMethods()
        {
            List<IAlgo> methods = new List<IAlgo>();
            methods.Add(new RandomNumbers.Bubble());
            methods.Add(new RandomNumbers.Insertion());
            methods.Add(new RandomNumbers.Selection());
            methods.Add(new RandomNumbers.Quick());
            methods.Add(new RandomNumbers.Merge());

            return methods;


        }

        public void PrintList(List <int> intList)
        {
            Console.WriteLine("\n");
            for (int i = 0; i < intList.Count; i++)
            {
                Console.Write($"{intList[i]}, ");
            }
        }
    }


}
