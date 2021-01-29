using System;
using System.Collections.Generic;
using System.Linq;

namespace TaskList
{
    class Program
    {
        static void Main(string[] args)
        {
            int option;
            string input;

            List<ToDo> toDos = new List<ToDo>();

            Console.WriteLine("Welcome to the Task List\n");

            while (true)
            {
                input = GetInput("What would you like to do: \n\n\t1. List Tasks\n\t2. Add tasks\n\t3. Delete task\n\t4. Mark task as complete\n\t5. Edit a task\n\t6. Show tasks by assignment\n\t7. Quit");
                int.TryParse(input, out option);

                try
                {
                    if (option == 1)
                    {
                        //List tasks
                        Console.Clear();
                        ListTasks(toDos);
                    }
                    else if (option == 2)
                    {
                        //Add tasks
                        Console.Clear();
                        AddTask(toDos);
                    }
                    else if (option == 3)
                    {
                        //Delete tasks
                        Console.Clear();
                        DeleteTask(toDos);
                    }
                    else if (option == 4)
                    {
                        //Mark task as complete
                        Console.Clear();
                        UpdateTask(toDos);
                    }
                    else if (option == 5)
                    {
                        //Edit a task
                        Console.Clear();
                        EditTask(toDos);
                    }
                    else if (option == 6)
                    {
                        //Show all tasks belonging to a certain team member
                    }
                    else if (option == 7)
                    {
                        break;
                    }
                    else
                    {
                        throw new Exception("Invalid input. Please enter an integer 1 - 5");
                    }
                }
                catch (Exception e)
                {
                    Console.Clear();
                    Console.WriteLine(e.Message);
                }

            }
        }

        public static string GetInput(string display)
        {
            Console.WriteLine(display);
            return Console.ReadLine();
        }

        public static void AddTask(List<ToDo> tasks)
        {
            string teamMember;
            string description;
            string dueDate;

            teamMember = GetInput("Who is this task being assigned to?");
            description = GetInput("What is the task?");
            dueDate = GetInput("When is it due?");

            ToDo newTask = new ToDo(teamMember, description, dueDate);
            tasks.Add(newTask);
        }

        public static void ListTasks(List<ToDo> tasks)
        {
            if(tasks.Count != 0)
            {
                Console.WriteLine();
                foreach (ToDo task in tasks)
                {
                    Console.WriteLine($"\t{tasks.IndexOf(task) + 1}. {task.TeamMember}: {task.Description} by {task.DueDate}. Completed: {task.Completed}");
                }
                Console.WriteLine();
            }
            else
            {
                throw new Exception("No tasks have been added yet");
            }

        }

        public static void DeleteTask(List<ToDo> tasks)
        {
            int option;
            string input;

            while(true)
            {
                Console.WriteLine("Which task do you want to delete?");
                ListTasks(tasks);
                input = Console.ReadLine();

                try
                {
                    if (int.TryParse(input, out option))
                    {
                        if (option > 0 && option <= tasks.Count)
                        {
                            Console.WriteLine("Are you sure you want to delete the following task? (Y/N)");
                            Console.WriteLine($"{option}. {tasks[option - 1].TeamMember}: {tasks[option - 1].Description} by {tasks[option - 1].DueDate}");
                            if (Console.ReadLine().Trim().ToLower() == "y")
                            {
                                tasks.RemoveAt(option - 1);
                                Console.WriteLine("Task deleted");
                            }
                            break;
                        }
                        else
                        {
                            throw new Exception($"Invalid input. Please enter an integer from 1 to {tasks.Count}");
                        }

                    }
                    else
                    {
                        throw new Exception("Invalid input. Input must be in the form of an integer");
                    }
                }
                catch (Exception e)
                {
                    Console.Clear();
                    Console.WriteLine(e.Message);
                }
            }




        }

        public static void UpdateTask(List<ToDo> tasks)
        {
            int option;
            string input;

            while(true)
            {
                Console.WriteLine("Which task do you want to update?");
                ListTasks(tasks);
                input = Console.ReadLine();

                try
                {
                    if (int.TryParse(input, out option))
                    {
                        if (option > 0 && option <= tasks.Count)
                        {
                            Console.WriteLine("Are you sure you want to update the following task? (Y/N)");
                            Console.WriteLine($"{option}. {tasks[option - 1].TeamMember}: {tasks[option - 1].Description} by {tasks[option - 1].DueDate}");
                            if (Console.ReadLine().Trim().ToLower() == "y")
                            {
                                tasks[option - 1].Completed = true;
                                Console.WriteLine("Task has been marked complete");
                            }
                            break;
                        }
                        else
                        {
                            throw new Exception($"Invalid input. Please enter an integer from 1 to {tasks.Count}");
                        }
                    }
                    else
                    {
                        throw new Exception($"Invalid input. Input must be in the form of an integer");
                    }
                }
                catch (Exception e)
                {
                    Console.Clear();
                    Console.WriteLine(e.Message);
                }
            }

        }

        public static void EditTask(List<ToDo> tasks)
        {
            int option;
            int editOption;
            string input;

            while(true)
            {
                Console.WriteLine("Which task do you want to edit?");
                ListTasks(tasks);
                input = Console.ReadLine();

                try
                {
                    if (int.TryParse(input, out option))
                    {
                        if (option > 0 && option <= tasks.Count)
                        {
                            Console.WriteLine("Are you sure you want to edit the following task? (Y/N)");
                            Console.WriteLine($"{option}. {tasks[option - 1].TeamMember}: {tasks[option - 1].Description} by {tasks[option - 1].DueDate}");

                            if (Console.ReadLine().Trim().ToLower() == "y")
                            {
                                Console.WriteLine("What do you want to change?\n\t1. Who it's assigned to\n\t2. The task\n\t3. The due date");
                                input = Console.ReadLine();

                                if (int.TryParse(input, out editOption))
                                {
                                    if (editOption == 1)
                                    {
                                        Console.WriteLine("Please enter a new name");
                                        tasks[option - 1].TeamMember = Console.ReadLine().Trim();
                                        Console.WriteLine("Task updated");
                                        break;
                                    }
                                    else if (editOption == 2)
                                    {
                                        Console.WriteLine("Please enter a new task description");
                                        tasks[option - 1].Description = Console.ReadLine().Trim();
                                        Console.WriteLine("Task updated");
                                        break;
                                    }
                                    else if (editOption == 3)
                                    {
                                        Console.WriteLine("Please enter a new due date");
                                        tasks[option - 1].DueDate = Console.ReadLine();
                                        Console.WriteLine("Task updated");
                                        break;
                                    }
                                    else
                                    {
                                        throw new Exception("Invalid input. Please enter a number from 1 to 3");
                                    }
                                }
                                else
                                {
                                    throw new Exception("Invalid input. Input must be in the form of an integer");
                                }
                            }
                            else
                            {
                                break;
                            }
                        }
                        else
                        {
                            throw new Exception($"Invalid input. Please enter an integer from 1 - {tasks.Count}");
                        }
                    }
                    else
                    {
                        throw new Exception("Invalid input. Input must be in the form of an integer");
                    }
                }
                catch (Exception e)
                {
                    Console.Clear();
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}
