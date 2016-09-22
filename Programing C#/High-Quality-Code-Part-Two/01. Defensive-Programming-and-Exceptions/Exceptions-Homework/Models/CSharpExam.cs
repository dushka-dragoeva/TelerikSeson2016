using System;
using ExceptionsHomework.Contracts;

namespace ExceptionsHomework.Models
{
    public class CSharpExam : IExam
    {
        private const int MinScore = 0;
        private const int MaxScore = 100;
        private const string Comments = "Exam results calculated by score.";
        private int score;

        public CSharpExam(int score)
        {
            this.Score = score;
        }

        public int Score
        {
            get
            {
                return this.score;
            }

            private set
            {
                if (this.Score < MinScore || this.Score > MaxScore)
                {
                    throw new ArgumentOutOfRangeException(
                       $"The score must be within the range [{MinScore}; {MaxScore}].");
                }
                else
                {
                    this.score = value;
                }
            }
        }

        public ExamResult Check()
        {
            var examResult = new ExamResult(this.Score, MinScore, MaxScore, Comments);
            return examResult;
        }
    }
}
