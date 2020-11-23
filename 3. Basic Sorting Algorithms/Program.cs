using System;

namespace Basic_Sorting_Algorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = "twój stary pijany chleje harnasie pod sklepem";

            var splitted = text.Split(" ");

            Sorting sorting = new Sorting();
            //sorting.BubbleSort(splitted);
            sorting.SelectionSort(splitted);

        }
    }

    public class Sorting
    {
        public void BubbleSort(string [] arr)
        {          
            string temp = string.Empty;

            for (int outer = arr.Length-1;  outer >= 1; outer--)
            {
                for (int inner = 0; inner <= outer - 1;  inner++)
                {
                    if(arr[inner].CompareTo(arr[inner + 1]) > 0 ) 
                        {
                            temp = arr[inner];
                            arr[inner] = arr[inner + 1];
                            arr[inner + 1] = temp;
                        }
                }
                ShowSortingProcess(arr);
            }
      
        }

        public void SelectionSort(string [] arr)
        {
            int min;
            string temp = "";
            
            for (int outer = 0; outer < arr.Length - 1; outer++)
            {
                min = outer;
                for (int inner = outer + 1; inner < arr.Length - 1; inner++)
                {
                    if (arr[inner].CompareTo(arr[min]) < 0)
                        min = inner;                          
                }
                temp = arr[outer];
                arr[outer] = arr[min];
                arr[min] = temp;
                ShowSortingProcess(arr);
            }

        }

        public void ShowSortingProcess(string [] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i] + " ");
            }

            Console.WriteLine("\n");
        } 
    }
}


