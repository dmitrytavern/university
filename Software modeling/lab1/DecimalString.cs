using System;

namespace App
{
    public class DecimalString : String
    {
        public DecimalString() : base("0") { }

        public DecimalString(decimal number) : base()
        {
            SetString(number.ToString());
        }

        public DecimalString(char c) : base()
        {
            try
            {
                SetString(decimal.Parse(c.ToString()).ToString());
            }
            catch (Exception)
            {
                SetString("0");
            }
        }

        public DecimalString(string str) : base()
        {
            try
            {
                SetString(decimal.Parse(str).ToString());
            }
            catch(Exception)
            {
                SetString("0");
            }
        }

        public DecimalString Subtract(DecimalString number)
        {
            decimal subtract = Parse(GetString()) - Parse(number.GetString());
            return new DecimalString(subtract);
        }

        public bool IsGreaterThan(DecimalString number)
        {
            return Parse(GetString()) > Parse(number.GetString());

        }

        public bool IsLessThan(DecimalString number)
        { 
            return Parse(GetString()) < Parse(number.GetString());
        }

        private decimal Parse(string str)
        {
            return decimal.Parse(str);
        }
    }
}
