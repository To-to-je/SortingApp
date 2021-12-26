
using SortingApp;
using System.Diagnostics;

class Program
{
    static void Main (string[] args)
    {
        // Declaring the variables before loops

        string cont;
        string generate = "yes";
        RandomNumbers randomNumbers;
        List<IAlgo> methods;
        List<int> randomNumbersList;
        char operationId;
        List<int> sortedList;
        SortingApp.IAlgo foundOperation;
        Stopwatch stopwatch = new Stopwatch();
        string answer;
        bool condition = false;

        // Program main loop

        while (generate == "yes")
        {
            cont = "yes";
            randomNumbers = new RandomNumbers();

            methods = randomNumbers.AllMethods();

            Console.WriteLine("\n Please, enter the number of random elements to generate.\n");
            randomNumbers.length = Convert.ToInt32(Console.ReadLine());

            randomNumbersList = randomNumbers.Generate(randomNumbers.length);


            Console.WriteLine("Do you want to print out the list ?");

            answer = Console.ReadLine();
            if (answer == "yes")
            {
                randomNumbers.PrintList(randomNumbersList);

            }

            Console.WriteLine("\n \n Now lets sort it...\n");

            // Algorithm checking loop 

            while (cont == "yes")
            {
                Console.WriteLine("\n Please, choose the althorithm (insert number)\n" +
                "\n0 - Bubble Sorting" +
                "\n1 - Insertion Sorting" +
                "\n2 - Selection Sorting" +
                "\n3 - Quick Sorting" +
                "\n4 - Merge Sorting");



                condition = false;


                while (condition == false)
                {
                    operationId = Convert.ToChar(Console.ReadLine());
                    for (int i = 0; i < methods.Count; i++)
                    {
                        if(operationId == methods[i].Id)
                        {
                            condition = true;
                        }
                        else
                        {
                            continue;
                        }
                    }
                    if (condition == false)
                    {
                        Console.WriteLine("\n You inserted wrong ID of algorithm. Please, try again.\n");
                    }
                    else
                    {
                        foundOperation = methods.FirstOrDefault(ao => ao.Id == operationId);


                        stopwatch.Start();
                        sortedList = foundOperation.Sort(randomNumbersList);
                        stopwatch.Stop();
                        
                        Console.WriteLine($" You choosed {foundOperation.Name} algorithm" +
                            $"\n Execution time is {stopwatch.ElapsedMilliseconds} milliseconds");
                        stopwatch.Reset();

                        Console.WriteLine("Do you want to print out the list ?");
                        answer = Console.ReadLine();
                        if(answer == "yes")
                        {
                            randomNumbers.PrintList(sortedList);

                        }
                        
                        

                        Console.WriteLine("\n \n Do you want to continue sorting current list with other algorithms? (yes/no)");
                        cont = Console.ReadLine();
                    }

                }

                

            }

            Console.WriteLine("\n \n Do you want to generate new list ?");
            generate = Console.ReadLine();

        }

        

    }
}


