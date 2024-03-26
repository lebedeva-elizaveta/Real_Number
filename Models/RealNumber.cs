using System;

public class RealNumber
{
    private int _sign;
    private double _mantissa;
    private int _exponent;

    public RealNumber(int sign, double mantissa, int exponent)
    {
        Sign = sign;
        Mantissa = mantissa;
        Exponent = exponent;
        Normalize();
    }

    public int Sign
    {
        get { return _sign; }
        set { _sign = value; }
    }

    public double Mantissa
    {
        get { return _mantissa; }
        set { _mantissa = value; }
    }

    public int Exponent
    {
        get { return _exponent; }
        set { _exponent = value; }
    }

    public override string ToString()
    {
        return $"{Sign} {Mantissa}E{Exponent}";
    }

    public void Normalize()
    {
        if (Mantissa == 0)
        {
            Exponent = 0;
            return;
        }

        while (Mantissa >= 10 || Mantissa < 1)
        {
            if (Mantissa >= 10)
            {
                Mantissa /= 10;
                Exponent++;
            }
            else if (Mantissa < 1)
            {
                Mantissa *= 10;
                Exponent--;
            }
        }
    }

    public static int Compare(RealNumber num1, RealNumber num2)
    {
        double val1 = num1.Sign * num1.Mantissa * Math.Pow(10, num1.Exponent);
        double val2 = num2.Sign * num2.Mantissa * Math.Pow(10, num2.Exponent);

        return val1.CompareTo(val2);
    }

    public static RealNumber Add(RealNumber num1, RealNumber num2)
    {
        int expDiff = Math.Abs(num1.Exponent - num2.Exponent);
        double mantissa1 = num1.Mantissa * Math.Pow(10, expDiff * Math.Sign(num1.Exponent - num2.Exponent));
        double mantissa2 = num2.Mantissa * Math.Pow(10, expDiff * Math.Sign(num2.Exponent - num1.Exponent));

        double resultMantissa = num1.Sign * mantissa1 + num2.Sign * mantissa2;
        int resultSign = Math.Sign(resultMantissa);
        resultMantissa = Math.Abs(resultMantissa);

        int resultExponent = num1.Exponent > num2.Exponent ? num1.Exponent : num2.Exponent;

        return new RealNumber(resultSign, resultMantissa, resultExponent);
    }

    public static RealNumber Subtract(RealNumber num1, RealNumber num2)
    {
        RealNumber negativeNum2 = new RealNumber(-num2.Sign, num2.Mantissa, num2.Exponent);
        return Add(num1, negativeNum2);
    }

    public static RealNumber Multiply(RealNumber num1, RealNumber num2)
    {
        int resultSign = num1.Sign * num2.Sign;
        double resultMantissa = num1.Mantissa * num2.Mantissa;
        int resultExponent = num1.Exponent + num2.Exponent;

        return new RealNumber(resultSign, resultMantissa, resultExponent);
    }

    public static RealNumber Divide(RealNumber num1, RealNumber num2)
    {
        int resultSign = num1.Sign * num2.Sign;
        double resultMantissa = num1.Mantissa / num2.Mantissa;
        int resultExponent = num1.Exponent - num2.Exponent;

        return new RealNumber(resultSign, resultMantissa, resultExponent);
    }
}
