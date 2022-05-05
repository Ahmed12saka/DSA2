using System;
using System.Collections.Generic;
using System.Text;


namespace DSA2
{
    class Program
    {
        static void Main(string[] args)
        {
            Assignment();
        }

        static void Assignment()
        {
            int input;
            bool empty;
            empty = false;
            LinkedList<Student> list = new LinkedList<Student>();
            CustomDataList database = new CustomDataList(list);

            while (true)
            {
                try
                {
                    Console.WriteLine();
                    Console.WriteLine("Main Menu");
                    Console.WriteLine("----------------------------------");
                    Console.WriteLine("1. Populate With Sample Data");
                    Console.WriteLine("2. Input New Element");
                    Console.WriteLine("3. Get Element by Index");
                    Console.WriteLine("4. Delete Element by Index");
                    Console.WriteLine("5. Remove First Element ");
                    Console.WriteLine("6. Remove Last Element");
                    Console.WriteLine("7. Display All Element");
                    Console.WriteLine("8. Sort Data");
                    Console.WriteLine("9. Highest Score Student");
                    Console.WriteLine("10. Lowest Score Student");
                    Console.WriteLine("11. Exit");
                    Console.WriteLine("----------------------------------");
                    Console.WriteLine();
                    Console.Write("Input: ");

                    input = -1;
                    string userinput = Console.ReadLine();

                    if (int.TryParse(userinput, out int result) && int.Parse(userinput) > 0 && int.Parse(userinput) < 12)
                        input = result;
                    else
                    {
                        Console.WriteLine();
                        Console.WriteLine("Incorrect Input!");
                        Console.WriteLine();
                    }

                    switch (input)
                    {
                        case 1:
                            Console.Clear();
                            database.PopulateWithSampleData();
                            Console.WriteLine();
                            Console.WriteLine("Sample Data Added!");
                            empty = true;
                            break;
                        case 2:
                            Console.Clear();
                            Console.WriteLine();
                            Console.WriteLine("Input New Element");
                            Console.WriteLine("----------------------------------");
                            Console.Write("Student First Name: ");
                            string First = Convert.ToString(Console.ReadLine());
                            Console.WriteLine();
                            Console.Write("Student Last Name: ");
                            string Last = Convert.ToString(Console.ReadLine());
                            Console.WriteLine();
                            Console.Write("Student Number: ");
                            string SNumber = Convert.ToString(Console.ReadLine());
                            Console.WriteLine();
                            Console.WriteLine("How many score to input ?");
                            int NumberInput = Convert.ToInt32(Console.ReadLine());
                            float[] scores = Scores(NumberInput);
                            float Score = Average(scores);
                            Student student = new Student(First, Last, SNumber, Score);
                            Console.Clear();
                            Console.WriteLine();
                            Console.WriteLine("New Student Information");
                            Console.WriteLine("----------------------------------");
                            Console.WriteLine(student.ToString());
                            Console.WriteLine();
                            Console.Write("Proceed? (y/n): ");
                            if (Convert.ToString(Console.ReadLine()) == "y")
                            {
                                database.Add(student);
                                empty = true;
                            }
                            break;
                        case 3:
                            if (empty == false)
                            {
                                DataCheck();
                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine($"Enter the index number: (1 to {database.Database.Count})");
                                int indexsearch = Convert.ToInt32(Console.ReadLine());
                                Student Get = database.GetElement(indexsearch);
                                Console.WriteLine();
                                Console.WriteLine($"Student Index {indexsearch} Information");
                                Console.WriteLine("----------------------------------");
                                Console.WriteLine(Get.ToString());
                                break;
                            }
                            break;
                        case 4:
                            if (empty == false)
                            {
                                DataCheck();
                            }
                            else
                            {
                                Console.Clear();
                                database.DisplayList();
                                Console.WriteLine();
                                Console.Write("Enter the index number to remove: ");
                                int index = Convert.ToInt32(Console.ReadLine());
                                database.RemoveByIndex(index);
                                Console.Clear();
                                Console.WriteLine();
                                Console.WriteLine($"Student Index {index} Removed!");
                                break;
                            }
                            break;
                        case 5:
                            if (empty == false)
                            {
                                DataCheck();
                            }
                            else
                            {
                                Console.WriteLine();
                                database.RemoveFirst();
                                Console.WriteLine();
                                Console.WriteLine("First Index Removed!");
                                break;
                            }
                            break;
                        case 6:
                            if (empty == false)
                            {
                                DataCheck();
                            }
                            else
                            {
                                Console.WriteLine();
                                database.RemoveLast();
                                Console.WriteLine();
                                Console.WriteLine("Last Index Removed!");
                                break;
                            }
                            break;
                        case 7:
                            Console.Clear();
                            Console.WriteLine();
                            Console.WriteLine("Student Database");
                            Console.WriteLine("----------------------------------");
                            database.DisplayList();
                            break;

                        case 8:
                            Console.Clear();
                            Console.WriteLine();
                            Console.WriteLine("Sort By:");
                            Console.WriteLine();
                            Console.WriteLine("1 - First Name");
                            Console.WriteLine("2 - Last Name");
                            Console.WriteLine("3 - Average Score");
                            Console.WriteLine();
                            Console.Write("Input (1/2/3) :");
                            int sortField = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine();
                            Console.WriteLine();
                            Console.WriteLine("1 - Ascending Order");
                            Console.WriteLine("2 - Descending Order");
                            Console.WriteLine();
                            Console.Write("Input (1/2) :");
                            int sortDirection = Convert.ToInt32(Console.ReadLine());
                            database.Sort(sortDirection, sortField);
                            Console.WriteLine();
                            Console.WriteLine("Sorted Database");
                            Console.WriteLine("----------------------------------");
                            Console.WriteLine();
                            database.DisplayList();
                            break;
                        case 9:
                            if (empty == false)
                            {
                                DataCheck();
                            }
                            else
                            {
                                Console.Clear();
                                Student HighestStudent = database.GetMaxElement();
                                Console.WriteLine("Highest Average Score Student");
                                Console.WriteLine("----------------------------------");
                                Console.WriteLine(HighestStudent.ToString());
                                break;
                            }
                            break;
                        case 10:
                            if (empty == false)
                            {
                                DataCheck();
                            }
                            else
                            {
                                Console.Clear();
                                Student LowestStudent = database.GetMinElement();
                                Console.WriteLine("Lowest Average Score Student");
                                Console.WriteLine("----------------------------------");
                                Console.WriteLine(LowestStudent.ToString());
                                break;
                            }
                            break;
                        case 11:
                            Console.Clear();
                            goto breakOut;
                    }
                    Console.WriteLine();
                    Console.WriteLine("Press any key to back to the main menu!");
                    Console.ReadKey();
                    Console.Clear();
                }
                catch (FormatException msg)
                {
                Console.WriteLine(msg.Message);
                }
                catch (Exception)
                {
                Console.WriteLine("Error, Please try again!");
                }
            }
        breakOut:;
        }

        static public void DataCheck ()
        {
            Console.WriteLine();
            Console.WriteLine("Database is empty!");
        }

        static public float Average(float[] scores)
        {
            float averageS = 0;
            for (int i = 0; i < scores.Length; i++)
            {
                averageS += scores[i];
            }
            averageS /= scores.Length;
            return averageS;
        }

        static public float[] Scores(int numberOfScores)
        {
            float[] scores = new float[numberOfScores];
            for (int i = 0; i < numberOfScores; i++)
            {
                Console.Write($"Enter Score Number {i+1}: ");
                scores[i] = Convert.ToSingle(Console.ReadLine());
            }
            return scores;
        }





    }
}
