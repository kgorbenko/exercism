using System;
using System.Collections.Generic;
using System.Linq;

public static class Triangle
{
    public static bool IsScalene(double side1, double side2, double side3)
        => IsTriangle(side1, side2, side3) &&
            side1 != side2 && side2 != side3 && side1 != side3;

    public static bool IsIsosceles(double side1, double side2, double side3)
        => IsTriangle(side1, side2, side3) &&
            (side1 == side2 || side2 == side3 || side1 == side3);


    public static bool IsEquilateral(double side1, double side2, double side3)
        => IsTriangle(side1, side2, side3) &&
            side1 == side2 && side1 == side3;

    private static bool IsTriangle(double side1, double side2, double side3)
    {
        return AllSidesHavePositiveLength() && SumOfAnyTwoSidesIsAlwaysMoreThanThirdSide();

        bool AllSidesHavePositiveLength()
            => side1 > 0 && side2 > 0 && side3 > 0;

        bool SumOfAnyTwoSidesIsAlwaysMoreThanThirdSide()
            => side1 + side2 > side3 &&
               side1 + side3 > side2 &&
               side2 + side3 > side1;
    }
}

public class TriangleException : Exception { }