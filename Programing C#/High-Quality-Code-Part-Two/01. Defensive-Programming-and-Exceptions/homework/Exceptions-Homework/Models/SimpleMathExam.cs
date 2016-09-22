using System;
using ExceptionsHomework.Contracts;

namespace ExceptionsHomework.Models
{
    public class SimpleMathExam : IExam
    {
        private const string ExelentResultComment = "Excellent result: everything's done correctly.";
        private const string AvarageResultComment = "Average result: almost nothing done.";
        private const string BadResultComment = "Bad result: nothing done.";
        private const string InvalidNumberOfProblemsSolved = "Invalid number of problems solved!";

        private const int MinProblemsSolved = 0;
        private const int MaxProblemsSolved = 10;
        private const int BadGradeMaxProblems = 2;
        private const int AvarageGradeMaxProblems = 7;
        private const int BadGrade = 2;
        private const int AvarageGrade = 4;
        private const int ExelentGrade = 6;

        private int problemsSolved;

        public SimpleMathExam(int problemsSolved)
        {
            this.ProblemsSolved = problemsSolved;
        }

        public int ProblemsSolved
        {
            get
            {
                return this.problemsSolved;
            }

            private set
            {
                if (value < MinProblemsSolved)
                {
                    value = MinProblemsSolved;
                }

                if (value > MaxProblemsSolved)
                {
                    value = MaxProblemsSolved;
                }

                this.problemsSolved = value;
            }
        }

        public ExamResult Check()
        {
            var comment = string.Empty;
            var grade = 0;

            if (this.ProblemsSolved <= BadGradeMaxProblems)
            {
                grade = BadGrade;
                comment = BadResultComment;
            }
            else if (this.ProblemsSolved <= AvarageGradeMaxProblems)
            {
                grade = AvarageGrade;
                comment = AvarageResultComment;
            }
            else
            {
                grade = ExelentGrade;
                comment = ExelentResultComment;
            }

            return new ExamResult(grade, BadGrade, ExelentGrade, comment);
        }
    }
}