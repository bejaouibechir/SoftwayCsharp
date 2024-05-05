public class Celcius
{
    public double Value;

    static public explicit operator Farenheit(Celcius c)
    {
        double fahrenheitValue = (c.Value * 9 / 5) + 32;
        return new Farenheit { Value = fahrenheitValue };
    }
    /*static public implicit operator Farenheit(Celcius c)
    {
        double fahrenheitValue = (c.Value * 9 / 5) + 32;
        return new Farenheit { Value = fahrenheitValue };
    }*/
}

public class Farenheit
{
    public double Value;
    static public explicit operator Celcius(Farenheit f)
    {
        double celciusheitValue = (f.Value - 32) * 5 / 9;
        return new Celcius { Value = celciusheitValue };
    }
    /*static public implicit operator Celcius(Farenheit f)
    {
        double celciusheitValue = (f.Value - 32) * 5 / 9;
        return new Celcius { Value = celciusheitValue };
    }*/
}


internal class Program
{
    static void Main(string[] args)
    {
        //Celcius to Farenheit
        Celcius celcius = new Celcius { Value = 30 };
        Farenheit farenheit = (Farenheit)celcius;

        //Frenheit to celcius
        Farenheit farenheit1 = new Farenheit { Value = 30 };
        Celcius celcius1 = (Celcius)farenheit1;

    }
}