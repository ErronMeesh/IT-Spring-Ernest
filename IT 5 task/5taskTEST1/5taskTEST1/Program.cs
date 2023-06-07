using System;
using System.Collections.Generic;

// Interface 
public interface Entrant
{
    string Name { get; set; }
    void Register();
    void PayTuition();
}

// Abstract class 
public abstract class Student : Entrant
{
    public string Name { get; set; }
    public int Age { get; set; }
    public string StudentId { get; set; }

    public abstract void AttendClass();
    public abstract void Study();

    public void Register()
    {
        Console.WriteLine("Student registration completed.");
    }

    public void PayTuition()
    {
        Console.WriteLine("Tuition payment completed.");
    }
}

public class PartTimeStudent : Student
{
    public string Course { get; set; }
    public bool IsEmployed { get; set; }

    public override void AttendClass()
    {
        Console.WriteLine("Attending part-time classes.");
    }

    public override void Study()
    {
        Console.WriteLine("Studying part-time.");
    }

    public void Work()
    {
        Console.WriteLine("Working part-time.");
    }

    public void SubmitAssignment()
    {
        Console.WriteLine("Submitting part-time assignment.");
    }
}


class Program
{
    static void Main(string[] args)
    {
        
        List<Entrant> entrants = new List<Entrant>();

        
        PartTimeStudent student1 = new PartTimeStudent()
        {
            Name = "John Doe",
            Age = 25,
            StudentId = "P12345",
            Course = "Computer Science",
            IsEmployed = true
        };

        entrants.Add(student1);

        PartTimeStudent student2 = new PartTimeStudent()
        {
            Name = "Jane Smith",
            Age = 22,
            StudentId = "P67890",
            Course = "Business Administration",
            IsEmployed = false
        };

        entrants.Add(student2);

       
        foreach (Entrant entrant in entrants)
        {
            Console.WriteLine("Name: " + entrant.Name);
            Console.WriteLine("Age: " + ((Student)entrant).Age);
            Console.WriteLine("Student ID: " + ((Student)entrant).StudentId);
            entrant.Register();
            entrant.PayTuition();

            ((Student)entrant).AttendClass();
            ((Student)entrant).Study();

            if (entrant is PartTimeStudent)
            {
                PartTimeStudent partTimeStudent = (PartTimeStudent)entrant;
                partTimeStudent.Work();
                partTimeStudent.SubmitAssignment();
            }

            Console.WriteLine();
        }
    }
}
