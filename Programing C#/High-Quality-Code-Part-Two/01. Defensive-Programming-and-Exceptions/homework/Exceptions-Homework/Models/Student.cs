using System;
using System.Collections.Generic;
using System.Linq;
using ExceptionsHomework.Contracts;
using ExceptionsHomework.Models;

public class Student
{
    private const string NameIsEmpty = "Name cannot be null or empty";

    private string firstName;
    private string lastName;
    private IList<IExam> exams;

    public Student(string firstName, string lastName, IList<IExam> exams = null)
    {
        this.FirstName = firstName;
        this.LastName = lastName;
        this.Exams = exams;
    }

    public string FirstName
    {
        get
        {
            return this.firstName;
        }

        set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException(NameIsEmpty, "first name");
            }

            this.firstName = value;
        }
    }

    public string LastName
    {
        get
        {
            return this.lastName;
        }

        set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException(NameIsEmpty, "last name");
            }

            this.lastName = value;
        }
    }

    public IList<IExam> Exams
    {
        get
        {
            return this.exams;
        }

        set
        {
            if (value == null)
            {
                this.Exams = new List<IExam>();
            }

            this.exams = value;
        }
    }

    public IList<ExamResult> CheckExams()
    {
        IList<ExamResult> results = new List<ExamResult>();

        for (int i = 0; i < this.Exams.Count; i++)
        {
            results.Add(this.Exams[i].Check());
        }

        return results;
    }

    public double CalcAverageExamResultInPercents()
    {
        double[] examScore = new double[this.Exams.Count];
        IList<ExamResult> examResults = this.CheckExams();
        for (int i = 0; i < examResults.Count; i++)
        {
            examScore[i] =
                ((double)examResults[i].Grade - examResults[i].MinGrade) /
                (examResults[i].MaxGrade - examResults[i].MinGrade);
        }

        return examScore.Average();
    }
}
