namespace Infestation
{
    public class Tank : Unit
    {
        private const int TankkAggression = 25;
        private const int TankHealth = 20;
        private const int TankPower = 25;

        public Tank(string id, UnitClassification unitType)
            : base(id, UnitClassification.Mechanical, TankHealth, TankPower, TankkAggression)
        {
        }
    }
}
