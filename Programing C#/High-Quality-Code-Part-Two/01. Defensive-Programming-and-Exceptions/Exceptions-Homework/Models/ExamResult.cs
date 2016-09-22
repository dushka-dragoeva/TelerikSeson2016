using System;
using ExceptionsHomework.Utilities;

namespace ExceptionsHomework.Models
{
    public class ExamResult
    {
        private const int GradeMinValue = 0;

        private int grade;
        private int minGrade;
        private int maxGrade;
        private string comments;

        public ExamResult(int grade, int minGrade, int maxGrade, string comments)
        {
            this.Grade = grade;
            this.MinGrade = minGrade;
            this.MaxGrade = maxGrade;
            this.Comments = comments;
        }

        public int Grade
        {
            get
            {
                return this.grade;
            }

            private set
            {
                if (!Validator.ValidateIntegerRange(value, GradeMinValue))
                {
                    throw new ArgumentOutOfRangeException($"{nameof(this.Grade)} shoul be a positive number");
                }
                else
                {
                    this.grade = value;
                }
            }
        }

        public int MinGrade
        {
            get
            {
                return this.minGrade;
            }

            private set
            {
                if (!Validator.ValidateIntegerRange(value, GradeMinValue, this.Grade))
                {
                    throw new ArgumentOutOfRangeException(
                        $"{nameof(this.MinGrade)} shold be less or equal to{this.Grade}");
                }
                else
                {
                    this.minGrade = value;
                }
            }
        }

        public int MaxGrade
        {
            get
            {
                return this.maxGrade;
            }

            private set
            {
                if (!Validator.ValidateIntegerRange(value, this.MinGrade))
                {
                    throw new ArgumentOutOfRangeException(
                        $"{nameof(this.maxGrade)} must be grater or equal than {this.Grade}");
                }
                else
                {
                    this.maxGrade = value;
                }
            }
        }

        public string Comments
        {
            get
            {
                return this.comments;
            }

            private set
            {
                if (!Validator.ValidateString(value))
                {
                    throw new ArgumentException("The string should not be null or empty.");
                }
                else
                {
                    this.comments = value;
                }
            }
        }
    }
}