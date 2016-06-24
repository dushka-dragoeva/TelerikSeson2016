namespace StudentsAndWorkers
{
    using System;
    using Utilities.Validators;

    internal class Worker : Human
    {
        private decimal weeklySalary;
        private int workHoursPerDay;

        public Worker(string firstNme, string lastName, decimal weeklysalary, int workHoursPerDay)
            : base(firstNme, lastName)
        {
            this.WeeklySalary = weeklysalary;
            this.WorkHoursPerDay = workHoursPerDay;
        }

        public int WorkHoursPerDay
        {
            get
            {
                return this.workHoursPerDay;
            }

            private set
            {
                this.workHoursPerDay = value.ValidateIntegerRange(4, 12);
            }
        }

        public decimal WeeklySalary
        {
            get
            {
                return this.weeklySalary;
            }

            private set
            {
                this.weeklySalary += value.ValidateIntegerRange(200m, decimal.MaxValue);
            }
        }

        public decimal CalculateMoneyPerHour()
        {
            return Math.Round(this.weeklySalary / (this.workHoursPerDay * 5), 2);
        }

        public override string ToString()
        {
            return base.ToString() + $"\tMoney per hour {this.CalculateMoneyPerHour():f2}";
        }
    }
}
