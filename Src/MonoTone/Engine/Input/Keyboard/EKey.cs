
// Type: GameManager.Engine.EKey
// Assembly: GameManager, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 472C2C08-DD69-4D44-B98A-CE427E9F4CAA
// Modded by [M]edia[E]xplorer

#nullable disable
namespace GameManager.Engine
{
  public class EKey
  {
    public int state;
    public string key;
    public string print;
    public string display;

    public EKey(string KEY, int STATE)
    {
      this.key = KEY;
      this.state = STATE;
      this.MakePrint(this.key);
    }

        public virtual void Update()
        {
            this.state = 2;
        }

        public void MakePrint(string KEY)
    {
      this.display = KEY;
      string str = "";
      if (KEY == "A" || KEY == "B" || KEY == "C" || KEY == "D" || KEY == "E" 
                || KEY == "F" || KEY == "G" || KEY == "H" || KEY == "I" 
                || KEY == "J" || KEY == "K" || KEY == "L" || KEY == "M"
                || KEY == "N" || KEY == "O" || KEY == "P" || KEY == "Q" 
                || KEY == "R" || KEY == "S" || KEY == "T" || KEY == "U" 
                || KEY == "V" || KEY == "W" || KEY == "X" || KEY == "Y" || KEY == "Z")
        str = KEY;

      if (KEY == "Space")
        str = " ";

      if (KEY == "OemClosedBrackets")
      {
        str = "]";
        this.display = str;
      }

      if (KEY == "OemOpenBrackets")
      {
        str = "[";
        this.display = str;
      }

      if (KEY == "OemMinus")
      {
        str = "-";
        this.display = str;
      }

      if (KEY == "OemPeriod" || KEY == "Decimal")
        str = ".";
      if (KEY == "D1" || KEY == "D2" || KEY == "D3" || KEY == "D4" || KEY == "D5" 
                || KEY == "D6" || KEY == "D7" || KEY == "D8" || KEY == "D9" || KEY == "D0")
        str = KEY.Substring(1);
      else if (KEY == "NumPad1" || KEY == "NumPad2" || KEY == "NumPad3" 
                || KEY == "NumPad4" || KEY == "NumPad5" || KEY == "NumPad6" 
                || KEY == "NumPad7" || KEY == "NumPad8" || KEY == "NumPad9" || KEY == "NumPad0")
        str = KEY.Substring(6);
      this.print = str;
    }
  }
}
