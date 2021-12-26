using NUnit.Framework;
using SortingApp;
using System;
using System.Collections.Generic;



namespace TestSortingApp
{

    public class Test

    {

        RandomNumbers randomNumbers = new RandomNumbers();
        private List<IAlgo> methods;
        private List<int> randomNumbersList;
        private Tuple<List<int>, List<int>> numbers;


        [SetUp]
        public void Setup()
        {

            numbers = randomNumbers.FakeGenerate();

            randomNumbersList = new List<int>(numbers.Item1);

            methods = randomNumbers.AllMethods();
        }

        public void GeneralTest(int method, Tuple <List<int>, List<int>> numbers)
        {
            List<int> list = methods[method].Sort(numbers.Item1);

            Assert.AreEqual(list, numbers.Item2);

        }



        [Test]
        public void BubbleTest()
        {
            GeneralTest(0, numbers);
        }

        [Test]
        public void InsertionTest()
        {

            GeneralTest(1, numbers);

        }

        [Test]
        public void SelectionTest()
        {
            
            GeneralTest(2, numbers);

        }

        [Test]
        public void QuickTest()
        {
            
            GeneralTest(3, numbers);

        }

        [Test]
        public void MergeTest()
        {
            GeneralTest(4, numbers);
        }

    }
}
