using System;
using System.Collections;
using System.Diagnostics;
using System.Linq;

namespace Example
{
    class Program
    {
        static void Main(string[] args)
        {
            Test test = new Test();
            Collection<Test> submittedTests = new Collection<Test>();
            Collection<Test> outForChecking = new Collection<Test>();

            test.Name = "Sprawdzian";
            test.TestNumber = 2;
            submittedTests.Add(test);
            submittedTests.Remove(test);

            outForChecking.Add(test);   

            foreach (Test item in outForChecking)
            {
                Console.WriteLine(item.Name);
                Console.WriteLine(item.TestNumber);
            }

           // int [] numbs = new int[1000000];
            Collection<int> nums = new Collection<int>();
            Timing tObj1 = new Timing();
            Timing tObj2 = new Timing();

            tObj1.startTime();
            int[] terms = Enumerable.Range(0, 1000000).ToArray();
            tObj1.StopTime();

            //tObj2.startTime();
           // BuildCollection(nums);
            //tObj2.StopTime();

            Console.WriteLine("Array time: " + tObj1.Result().TotalMilliseconds.ToString());
           // Console.WriteLine("Collecion time: " +  tObj2.Result().TotalMilliseconds.ToString());
            
        }

        static void BuildArray(int[] arr) 
        {
            for(int i = 0; i < 1000000; i++)
                arr[i] = i;
        }

        static void BuildCollection(Collection<int> clt) 
        {
            for(int i = 0; i < 1000000; i++)
                clt.Add(i);
        }
    }
    class Test
    {
        public string Name { get; set; }
        public int TestNumber { get; set; }

    }
    public class Collection<T> : CollectionBase
    {
        public void Add(T item) {
            InnerList.Add(item);
        }
        public void Remove(T item) {
            InnerList.Remove(item);
        }
        public new void Clear() {
            InnerList.Clear();
        }
        public new int Count() {
            return InnerList.Count;
        }
        public void Insert(int index, T item){
            InnerList.Insert(index, item);
        }
        public bool Contains(T item){
            return InnerList.Contains(item);
        }
        public int IndexOf(T item){
            return InnerList.IndexOf(item);
        }
        public new void RemoveAt(int index){
            InnerList.RemoveAt(index);
        }
        
    }
    
    public class Timing 
    {
        TimeSpan startingTime;
        TimeSpan duration;
        public Timing() 
        {
            startingTime = new TimeSpan(0);
            duration = new TimeSpan(0);
        }
        public void StopTime() 
        {
            duration = Process.GetCurrentProcess().Threads[0].
            UserProcessorTime.Subtract(startingTime);
        }
        public void startTime() 
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
            startingTime =  Process.GetCurrentProcess()
                                .Threads[0]
                                .UserProcessorTime;
        }
        public TimeSpan Result() 
        {
            return duration;
        } 
    }  
}
    



