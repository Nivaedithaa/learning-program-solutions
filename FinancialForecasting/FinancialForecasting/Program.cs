using System;
public class Program
{
    public static double PredictValue(double currValue, double growRate, int yr)
    {
        if (yr == 0)
            return currValue;

        // Recursive call
        return PredictValue(currValue, growRate, yr - 1) * (1 + growRate);
    }
    public static void Main()
    {
        Console.Write("Enter current value: ");
        double current = Convert.ToDouble(Console.ReadLine());

        Console.Write("Enter annual growth rate: ");
        double rate = Convert.ToDouble(Console.ReadLine());

        Console.Write("Enter number of years to forecast: ");
        int years = Convert.ToInt32(Console.ReadLine());

        double futureValue = Program.PredictValue(current, rate, years);
        Console.WriteLine($"\n Predicted value after {years} years: {futureValue:F2}");
    }
}
