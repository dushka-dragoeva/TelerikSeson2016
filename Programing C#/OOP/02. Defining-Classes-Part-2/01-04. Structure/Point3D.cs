namespace _01_04.Structure
{
    internal struct Point3D
    {
        private static readonly Point3D StartO = new Point3D(0, (double)0, (double)0);

        public Point3D(double x, double y, double z)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
        }

        public double X { get; set; }

        public double Y { get; set; }

        public double Z { get; set; }

        public Point3D O
        {
            get
            {
                return StartO;
            }
        }

        public override string ToString()
        {
            return $"X = {this.X}, Y = {this.Y}, Z = {this.Z}";
        }
    }
}
