using System;
using System.Collections;
using System.Diagnostics;

namespace Arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            int courseCount = 12;
            int size = 20;

            Timing tObj1 = new Timing();
            Timing tObj2 = new Timing();

            int [] gradesArr = new int[size];
            int [,] grades = new int[courseCount, size];
            ArrayList gradesArrList = new ArrayList();
    
            MultiArrayCourse englishCourse = new MultiArrayCourse();
            englishCourse.AddGrades(grades, courseCount, size); 

            tObj1.StartTime();
            ArrayListCourse frenchCourse = new ArrayListCourse();
            frenchCourse.AddGrades(gradesArrList, size);
            frenchCourse.AverageGrade(gradesArrList);
            frenchCourse.HighestGrade(gradesArrList);
            frenchCourse.LowestGrade(gradesArrList);
            tObj1.StopTime();

            tObj2.StartTime();
            ArrayCourse deutschCourse = new ArrayCourse();
            deutschCourse.AddGrades(gradesArr, size);
            deutschCourse.AverageGrade(gradesArr);
            deutschCourse.HighestGrade(gradesArr);
            deutschCourse.LowestGrade(gradesArr);
            tObj2.StopTime();

            ArrayListMimic mimic = new ArrayListMimic();

            for (int i = 0; i < 100; i++)
            {
                mimic.Add(1);
            }
            
            ArrayListMimic test = new ArrayListMimic();

            test.AddRange(mimic);
            int s = test.Capacity();
            test.Clear();
            
            for (int i = 0; i < grades.GetLength(0); i++)
            {
                Console.WriteLine("Przedmiot nr: " + i + "\n");

                for (int j = 0; j < grades.GetLength(1); j++)
                {
                    Console.WriteLine("Ocena to:" + grades [i,j]);
                }
            }

            foreach (var item in gradesArrList)
            {
                Console.WriteLine("Ocena to:" + item);    
            }
            
             Console.WriteLine("Average of grades equals: " + englishCourse.AverageGrade(grades));
             Console.WriteLine("Highest grade equals: " + englishCourse.HighestGrade(grades));
             Console.WriteLine("Lowest grade equals: " + englishCourse.LowestGrade(grades));

             Console.WriteLine("Time of Array List equals: " + tObj1.Result().TotalMilliseconds.ToString());

             Console.WriteLine("Time of Array equals: " + tObj2.Result().TotalMilliseconds.ToString());
        }
    }

    public class MultiArrayCourse
    {
        Random rnd = new Random();

        public int[,] AddGrades(int[,] arr, int courseCount, int size)
        {
            for (int row = 0; row < courseCount; row++)
            {
                 for (int col = 0; col < size; col++)
                 {
                     arr[row,col] = rnd.Next(1,7);
                 }
            }

            return arr;
        }

        public double AverageGrade(int[,] arr)
        {
            double avg = 0;

            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    avg += arr[i,j];   
                }
                 
            }

            avg = avg / arr.Length;
            return avg;
        }

        public int HighestGrade(int[,] arr)
        {
            int highest = 0;

            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    if(arr[i,j] > highest)
                    highest = arr[i,j];
                }
            }

            return highest;
        }

        public int LowestGrade(int[,] arr)
        {
            int lowest = 6;

            for (int i = 0; i < arr.GetLength(0); i++)
                {
                    for (int j = 0; j < arr.GetLength(1); j++)
                    {
                        if(arr[i,j] < lowest)
                        lowest = arr[i,j];
                    }
                    
                }

            return lowest;
        }

    }

    public class ArrayCourse
    {
        Random rnd = new Random();

        public int[] AddGrades(int[] arr, int size)
        {
            for (int i = 0; i < arr.Length; i++)
            {               
                arr[i] = rnd.Next(1,7);
            }

            return arr;
        }

        public double AverageGrade(int[] arr)
        {
            double avg = 0;

            for (int i = 0; i < arr.Length; i++)
            {      
                avg += arr[i];          
            }

            avg = avg / arr.Length;
            return avg;
        }

        public int HighestGrade(int[] arr)
        {
            int highest = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                if(arr[i] > highest)
                highest = arr[i];

            }

            return highest;
        }

        public int LowestGrade(int[] arr)
        {
            int lowest = 6;

            for (int i = 0; i < arr.Length; i++)
            {
                if(arr[i] < lowest)
                lowest = arr[i];     
            }

            return lowest;
        }

    }


    public class ArrayListCourse
    {
        Random rnd = new Random();

        public ArrayList AddGrades(ArrayList arr, int size)
        { 
            for (int i = 0; i < size; i++)
            {
                arr.Add(rnd.Next(1,7));
            }

            return arr;
        }

         public double AverageGrade(ArrayList arr)
        {
            double avg = 0;

            foreach (var item in arr)
            {
                avg += (int)item;
            }

            avg = avg / arr.Count;
            return avg;
        }

        public int HighestGrade(ArrayList arr)
        {
            int highest = 0;    

            foreach (var item in arr)
            {
                if((int)item > highest)
                highest = (int)item;
            }

            return highest;
        }

        public int LowestGrade(ArrayList arr)
        {
            int lowest = 6;
                
            foreach (var item in arr)
            {
                if((int)item < lowest)
                lowest = (int)item;     
            }

            return lowest;
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
        public void StartTime() 
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

    public class ArrayListMimic : IEnumerator,IEnumerable
    {
        private Object [] arr;
        private int size = 16;
        private int position = -1;
        public ArrayListMimic()
        {
            arr = new Object[size];
        }

        public void Add(Object item)
        {
            CheckCount();

            int index = Array.IndexOf(arr, null);

            arr[index] = item;
        }

        public void AddRange(ArrayListMimic items)
        {
            foreach (var item in items)
            {
                CheckCount();
                int index = Array.IndexOf(arr, null);
                arr[index] = item;
            }
        }

        public int Capacity()
        {
            return size;
        }

        public void Clear()
        {
            size = 16;
            arr = new Object[size];
        }

         //IEnumerator and IEnumerable require these methods.
        public IEnumerator GetEnumerator()
        {
            return (IEnumerator)this;
        }
        //IEnumerator
        public bool MoveNext()
        {
            position++;
            return (position < arr.Length);
        }
        //IEnumerable
        public void Reset()
        {
            position = 0;
        }
        //IEnumerable
        public object Current
        {
            get { return arr[position];}
        }

        private void CheckCount()
        {
            if(arr[arr.Length-1] != null)
            {
                size += 16;
                Array.Resize(ref arr, size);
            }
        }
    }
}
