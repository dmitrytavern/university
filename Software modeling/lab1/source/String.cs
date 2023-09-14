namespace App
{
  public class String
  {
    private char[] characters;
    private int length;

    public String()
    {
      characters = new char[0];
      length = 0;
    }

    public String(char c)
    {
      characters = new char[] { c };
      length = 1;
    }

    public String(string str)
    {
      characters = str.ToCharArray();
      length = characters.Length;
    }

    public void SetString(string str)
    {
      characters = str.ToCharArray();
      length = characters.Length;
    }

    public string GetString()
    {
      return new string(characters);
    }

    public int GetLength()
    {
      return length;
    }

    public void Clear()
    {
      characters = new char[0];
      length = 0;
    }
  }
}
