using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondLab_C_Octotorp_Variant_11
{
    class Triangle
    {
        private int firstSide;
        private int secondSide;
        private int thirdSide;

        public Triangle()
        {
            FirstSide = 1;
            SecondSide = 1;
            ThirdSide = 1;
        }

        public Triangle(int oneSide)
            :this(oneSide,1,1)
        {           
        }

        public Triangle(int oneSide, int twoSide)
            :this(oneSide,twoSide,1)
        {
        }

        public Triangle(int firstSide, int secondSide, int thirdSide)
        {
            FirstSide = firstSide;
            SecondSide = secondSide;
            ThirdSide = thirdSide;
        }

        public int FirstSide { get => firstSide; set => firstSide = value > 0 ? value : 1; }
        public int SecondSide { get => secondSide; set => secondSide = value > 0 ? value : 1; }
        public int ThirdSide { get => thirdSide; set => thirdSide = value > 0 ? value : 1; }
        // mb some parameters
        public bool ExistsCheckTriangle()
        {
            //Чтобы треугольник существовал, сумма двух сторон треугольника всегда должна быть больше третей стороны.
            int sumFirst = FirstSide + SecondSide;
            int sumSecond = SecondSide + ThirdSide;
            int sumThird = FirstSide + ThirdSide;

            //Another type of Conditional operation
            if (sumFirst > ThirdSide)
                Console.WriteLine(FirstSide);
            else
                Console.WriteLine("Triangle not exists");
            if (sumSecond > FirstSide)
                Console.WriteLine(SecondSide);
            else
                Console.WriteLine("Triangle not exists");
            if(sumThird > SecondSide)
                Console.WriteLine(ThirdSide);
            else
                Console.WriteLine("Triangle not exists");
            if (sumFirst > ThirdSide && sumSecond > FirstSide && sumThird > SecondSide)
            {
                return true;
            }
            else
                return false;            
        }

        public string PrintSides()
        {
            return $"First side : {FirstSide} " +
            $"Second side : {SecondSide} " +
            $"Third side : {ThirdSide}\n";
        }

        public string PrintAngles()
        {
            //Углы треугольника в сумме дают 180°, поэтому зная два из них, можно вычислить третий
            //Через теорему косинусов можно найти угол треугольника, зная все три стороны треугольника.
            double firstAngle = (Math.Pow(FirstSide, 2) + Math.Pow(ThirdSide, 2) - Math.Pow(SecondSide, 2)) / (2 * FirstSide * ThirdSide); 
            double secondAngle = (Math.Pow(FirstSide, 2) + Math.Pow(SecondSide, 2) - Math.Pow(ThirdSide, 2)) / (2 * FirstSide * SecondSide);
            double thirdAngle = (Math.Pow(SecondSide, 2) + Math.Pow(ThirdSide, 2) - Math.Pow(FirstSide, 2)) / (2 * SecondSide * ThirdSide);
            double sumOfAngle = RadianToDegree(firstAngle) + RadianToDegree(secondAngle) + RadianToDegree(thirdAngle);

            return $"First angle: {RadianToDegree(firstAngle)}\nSecond angle: {RadianToDegree(secondAngle)}\nThird angle: " +
                $"{RadianToDegree(thirdAngle)}\nSum of angle: {sumOfAngle}\n";
        }
        public string PrintPerimetr()
        {
            int perimert = FirstSide + SecondSide + ThirdSide;
            return $"Perimert: {perimert}\n";
        }
        public int PrintSquare()
        {
            // формула Герона
            int halfPerimetr = (FirstSide + SecondSide + ThirdSide) / 2;
            int square = (int)Math.Sqrt(halfPerimetr * (halfPerimetr - FirstSide) * 
                (halfPerimetr - SecondSide) * (halfPerimetr - ThirdSide));
            return square;
        }

        private double RadianToDegree(double angle)
        {
            return Math.Acos(angle) * 180 / Math.PI;
        }
    }
}
