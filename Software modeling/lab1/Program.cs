using App;

class Program
{
  static void Main()
  {
    DecimalString num_empty = new DecimalString();
    Console.WriteLine("Empty DecimalString: " + num_empty.GetString());

    DecimalString num_char = new DecimalString('1');
    Console.WriteLine("Char DecimalString: " + num_char.GetString());

    DecimalString num_decimal = new DecimalString(123);
    Console.WriteLine("Decimal DecimalString: " + num_decimal.GetString());

    Console.WriteLine("DecimalString  operations:");

    DecimalString num1 = new DecimalString("123");
    DecimalString num2 = new DecimalString("45");
    DecimalString num3 = new DecimalString("+15");
    DecimalString num4 = new DecimalString("-15");
    DecimalString result = num1.Subtract(num2);

    Console.WriteLine("  123 - 45 : " + result.GetString());
    Console.WriteLine("  123 > 45 : " + num1.IsGreaterThan(num2));
    Console.WriteLine("  123 < 45 : " + num1.IsLessThan(num2));
    Console.WriteLine("  +15 > -15: " + num3.IsGreaterThan(num4));
    Console.WriteLine("  +15 < -15: " + num3.IsLessThan(num4));

    Console.WriteLine("DecimalString handling error:");
    Console.WriteLine("  Invalid char  : " + new DecimalString('a').GetString());
    Console.WriteLine("  Invalid string: " + new DecimalString("-1-").GetString());
  }
}
