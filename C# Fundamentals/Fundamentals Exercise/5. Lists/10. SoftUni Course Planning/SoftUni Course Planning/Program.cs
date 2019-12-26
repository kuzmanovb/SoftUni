using System;
using System.Collections.Generic;
using System.Linq;

namespace SoftUni_Course_Planning
{
    class Program
    {
        static void Main(string[] args)
        {
            var course = Console.ReadLine().Split(", ").ToList();

            string input = Console.ReadLine();

            while (input != "course start")
            {

                string[] commandArray = input.Split(":");
                string command = commandArray[0];

                if (command == "Add")
                {
                    string lesson = commandArray[1];

                    if (!course.Contains(lesson))
                    {
                        course.Add(lesson);
                    }
                }
                else if (command == "Insert")
                {
                    string lesson = commandArray[1];
                    int index = int.Parse(commandArray[2]);


                    if (!course.Contains(lesson))
                    {
                        course.Insert(index, lesson);
                    }
                }
                else if (command == "Remove")
                {
                    string lesson = commandArray[1];

                    if (course.Contains(lesson))
                    {
                        course.Remove(lesson);

                        if (course.Contains(lesson + "-Exercise"))
                        {
                            course.Remove(lesson + "-Exercise");
                        }
                    }

                }
                else if (command == "Swap")
                {
                    string lessonOne = commandArray[1];
                    string lessonTwo = commandArray[2];


                    if (course.Contains(lessonOne) && course.Contains(lessonTwo))
                    {
                        int indexOne = course.IndexOf(lessonOne);
                        int indexTwo = course.IndexOf(lessonTwo);

                        course[indexOne] = lessonTwo;
                        course[indexTwo] = lessonOne;

                        MoveExercite(course, lessonOne, lessonTwo, indexOne, indexTwo);
                    }
                }
                else if (command == "Exercise")
                {
                    string lesson = commandArray[1];
                    string lessonExercise = lesson + "-Exercise";

                    if (course.Contains(lesson) && !course.Contains(lessonExercise))
                    {
                        int index = course.IndexOf(lesson);

                        course.Insert(index + 1, lessonExercise);

                    }
                    else if (!course.Contains(lesson) && !course.Contains(lessonExercise))
                    {
                        course.Add(lesson);
                        course.Add(lessonExercise);
                    }
                }

                input = Console.ReadLine();
            }

            for (int i = 1; i <= course.Count; i++)
            {
                Console.WriteLine($"{i}.{course[i - 1]}");
            }

        }

        private static void MoveExercite(List<string> course, string lessonOne, string lessonTwo, int indexOne, int indexTwo)
        {
            string lessonOneExercise = lessonOne + "-Exercise";

            if (course.Contains(lessonOneExercise))
            {
                course.Remove(lessonOneExercise);

                if (indexTwo + 1 > course.Count - 1)
                {
                    course.Add(lessonOneExercise);
                }
                else
                {
                    course.Insert(indexTwo + 1, lessonOneExercise);
                }
            }

            string lessonTwoExercise = lessonTwo + "-Exercise";

            if (course.Contains(lessonTwoExercise))
            {
                course.Remove(lessonTwoExercise);

                if (indexOne + 1 > course.Count - 1)
                {
                    course.Add(lessonTwoExercise);
                }
                else
                {
                    course.Insert(indexOne + 1, lessonTwoExercise);
                }
            }
        }
    }
}
