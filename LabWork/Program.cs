namespace LabWork;

internal static class Program
{
    static void Main()
    {
        double xn, xk, h, e;

        do
        {
            Console.WriteLine("Enter start interval Xstart(Xstart<Хfinish)");
            xn = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Enter the end of the interval Xfinish(Xstart<Хfinish)");
            xk = Convert.ToDouble(Console.ReadLine());
        } while (xk < xn);

        do
        {
            Console.WriteLine("Enter interval step h  (0<h<" + (xk - xn) + ")");
            h = Convert.ToDouble(Console.ReadLine());
        } while ((h < 0) & (h > (xk - xn)));

        do
        {
            Console.WriteLine("Enter precision (0;1) e=");
            e = Convert.ToDouble(Console.ReadLine()); //precision something like 0,0001
        } while ((e < 0) & (e > 1) & (e > xn));

        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine("Function tabulation y=e^-x for |x|<infinity");
        Console.WriteLine("at interval [" + xn + ";" + xk + "] with interval step h=" + h + " and precision e=" +
                          e);
        Console.WriteLine("-------------------------------------------");
        Console.WriteLine("|Arg| Func |Number of row members|");
        Console.WriteLine("-------------------------------------------");
        double x = 1;
        double sum = 1;
        do
        {
            var n = 1;
            if (e >= Math.Abs(x))
            {
                Console.WriteLine("Unable to calculate series with given precision");
            }
            else
            {
                while (Math.Abs(x) >= e)
                {
                    x = (x * (-xn / n)); //finding the next element of a row
                    sum += x; //series summation
                    n++; //increase in the number of members of the series
                }

                //displaying the value of the argument, function, number of members of the series
                Console.WriteLine("|   {0:f2} |{1:f7}|         {2}          |", xn, sum, n);
                xn += h;
                x = 1;
                sum = 1;
            }
        } while (xk >= xn);

        Console.WriteLine("-------------------------------------------");
        Console.ReadKey();
    }
}