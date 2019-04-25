using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondLab_C_Octotorp_Variant_11
{
    class Right_Triangle : Triangle
    {
        private int firstKatet;
        private int secondKatet;
        private int gipatenuza;

        private double firstAngle;
        private double secondAngle;
        private const double rightDegree = 90;

        public Right_Triangle()
        {
            FirstKatet = 1;
            SecondKatet = 1;
            Gipatenuza = 1;
        }

        public Right_Triangle(int oneKatet)
            :this(oneKatet,1,1)
        {
        }

        public Right_Triangle(int oneKatet,int twoKatet)
            :this(oneKatet,twoKatet,1)
        {
        }

        public Right_Triangle(int firstKatet, int secondKatet, int gipatenuza)
        {
            FirstKatet = firstKatet;
            SecondKatet = secondKatet;
            Gipatenuza = gipatenuza;
        }

        public int FirstKatet { get => firstKatet; set => firstKatet = value > 0 ? value : 1; }
        public int SecondKatet { get => secondKatet; set => secondKatet = value > 0 ? value : 1; }
        public int Gipatenuza { get => gipatenuza; set => gipatenuza = value > 0 ? value : 1; }
        public double FirstAngle { get => firstAngle; set => firstAngle = value; }
        public double SecondAngle { get => secondAngle; set => secondAngle = value; }

        public bool ExistsCheckRightTriangle()
        {
            FirstAngle = (double)FirstKatet / SecondKatet;
            SecondAngle = 90 - RadianToDegree(FirstAngle); 
            if ((RadianToDegree(FirstAngle) + SecondAngle) == 90)
            {
                return true;
            }
            else            
                return false;            
        }

        public string PrintInfo_RightTriangle()
        {
            return $"First katet: {FirstKatet}\n Second katet: {SecondKatet}\n Gipatenuza: {Gipatenuza}\n";
        }

        public string PrintDegreeInfo()
        {
            return $"First Angel: {RadianToDegree(FirstAngle)}\n Second Angel: {SecondAngle}\n Right Angel: {rightDegree}\n";
        }

        private double RadianToDegree(double angle)
        {
            return Math.Atan(angle) * 180.0 / Math.PI;
        }
    }
}
