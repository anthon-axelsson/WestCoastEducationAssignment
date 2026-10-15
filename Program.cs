using System;
using System.Collections.Generic;
using WestCoastEducationAssignment.CourseModels;
using WestCoastEducationAssignment.Models;
using WestCoastEducationAssignment.Services;

class Program
{
    static void Main()
    {
        string dataDirectory = "Data";
        Directory.CreateDirectory(dataDirectory);

        string courseFile = Path.Combine(dataDirectory, "courses.json");
        string studentFile = Path.Combine(dataDirectory, "students.json");

        List<Course> courses = JsonFileService.LoadData<Course>(courseFile);
        List<Student> students = JsonFileService.LoadData<Student>(studentFile);

        bool running = true;
        while (running)
        {
            Console.Clear();
            Console.WriteLine("===WESTCOAST EDUCATION - ADMINISTRATION===");
            Console.WriteLine("1. List all Course");
            Console.WriteLine("2. Add a new classroom course");
            Console.WriteLine("3. Add a new distance course");
            Console.WriteLine("4. Add a new student");
            Console.WriteLine("5. List all students");
            Console.WriteLine("6. End session");
            Console.Write("\nChoose an option (1-6): ");

            string choice = Console.ReadLine()!;

            switch (choice)
            {
                case "1":
                    Console.WriteLine("\n--- Course-List ---");
                    if (courses.Count == 0)
                    {
                        Console.WriteLine("No Courses registered yet.");
                    }
                    else
                    {
                        foreach (var c in courses)
                        {
                            Console.WriteLine(c.GetCourseDetails());
                        }
                    }
                    break;

                case "2":
                    Console.Write("Input coursenumber: ");
                    string cNum = Console.ReadLine() ?? string.Empty;
                    Console.Write("Input title: ");
                    string cTitle = Console.ReadLine() ?? string.Empty;
                    Console.Write("Input length in weeks: ");
                    if (int.TryParse(Console.ReadLine(), out int weeks))
                    {
                        courses.Add(new CourseClassroom 
                        { 
                            CourseNumber = cNum, 
                            Title = cTitle, 
                            DurationInWeeks = weeks, 
                            StartDate = DateTime.Now, 
                            EndDate = DateTime.Now.AddDays(weeks * 7),
                            Location = "Gothenburg" 
                        });

                        JsonFileService.SaveData(courses, courseFile);
                        Console.WriteLine("Classroom course added and saved to JSON!");
                    }
                    break;

                case "3":
                    Console.Write("Input coursenumber: ");
                    string dNum = Console.ReadLine() ?? string.Empty;
                    Console.Write("Input title: ");
                    string dTitle = Console.ReadLine() ?? string.Empty;
                    Console.Write("Input length in weeks: ");
                    if (int.TryParse(Console.ReadLine(), out int dweeks))
                    {
                        courses.Add(new CourseDistance 
                        { 
                            CourseNumber = dNum, 
                            Title = dTitle, 
                            DurationInWeeks = dweeks, 
                            StartDate = DateTime.Now, 
                            EndDate = DateTime.Now.AddDays(dweeks * 7),
                            MeetingPlatform = "Teams" 
                        });

                        
                        JsonFileService.SaveData(courses, courseFile);
                        Console.WriteLine("Distance course added and saved to JSON!");
                    }
                    break;

                case "4":
                    Console.Write("Firstname: ");
                    string fName = Console.ReadLine()!;
                    Console.Write("Lastname: ");
                    string lName = Console.ReadLine()!;
                    Console.Write("Personal Number: ");
                    string PersonalNo = Console.ReadLine()!;
                    Console.Write("Phone: ");
                    string PhoneNo = Console.ReadLine()!;
                    Console.Write("Address: ");
                    string Adrs = Console.ReadLine()!;
                    Console.Write("PostalCode: ");
                    string PoCode = Console.ReadLine()!;
                    Console.Write("Region: ");
                    string Reg = Console.ReadLine()!;

                    students.Add(new Student 
                    { 
                        FirstName = fName, 
                        LastName = lName, 
                        PersonalNumber = PersonalNo, 
                        PhoneNumber = PhoneNo, 
                        Address = Adrs, 
                        PostalCode = PoCode, 
                        Region = Reg 
                    });

                    
                    JsonFileService.SaveData(students, studentFile);
                    Console.WriteLine("Student added and saved to JSON!");
                    break;

                case "5":
                    Console.WriteLine("\n---STUDENT LIST---");
                    if (students.Count == 0)
                    {
                        Console.WriteLine("No students registered yet.");
                    }
                    else
                    {
                        foreach (var s in students)
                        {
                            Console.WriteLine(s.GetDetails());
                        }
                    }
                    break;

                case "6":
                    running = false;
                    Console.WriteLine("Ending The Session...");
                    break;

                default:
                    Console.WriteLine("Invalid choice, try again.");
                    break;
            }

            if (choice != "6")
            {
                Console.WriteLine("\nPress any button to continue...");
                Console.ReadKey();
            }
        }
    }
}