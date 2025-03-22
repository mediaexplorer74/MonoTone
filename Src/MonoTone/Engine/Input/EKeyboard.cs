
// Type: GameManager.Engine.EKeyboard
// Assembly: GameManager, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 472C2C08-DD69-4D44-B98A-CE427E9F4CAA
// Modded by [M]edia[E]xplorer

using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

#nullable disable
namespace GameManager.Engine
{
  public class EKeyboard
  {
    public KeyboardState newKeyboard;
    public KeyboardState oldKeyboard;
    public List<EKey> pressedKeys = new List<EKey>();
    public List<EKey> previousPressedKeys = new List<EKey>();

    public virtual void Update()
    {
      this.newKeyboard = Keyboard.GetState();
      this.GetPressedKeys();
    }

    public void LateUpdate()
    {
      this.oldKeyboard = this.newKeyboard;
      this.previousPressedKeys = new List<EKey>();
      for (int index = 0; index < this.pressedKeys.Count; ++index)
        this.previousPressedKeys.Add(this.pressedKeys[index]);
    }

    public bool GetPress(string KEY)
    {
      for (int index = 0; index < this.pressedKeys.Count; ++index)
      {
        if (this.pressedKeys[index].key == KEY)
          return true;
      }
      return false;
    }

    public bool OnPress(string KEY)
    {
      for (int index1 = 0; index1 < this.pressedKeys.Count; ++index1)
      {
        if (this.pressedKeys[index1].key == KEY)
        {
          for (int index2 = 0; index2 < this.previousPressedKeys.Count; ++index2)
          {
            if (this.previousPressedKeys[index2].key == KEY)
              return false;
          }
          return true;
        }
      }
      return false;
    }

    public virtual void GetPressedKeys()
    {
      this.pressedKeys.Clear();

      for (int index = 0; index < this.newKeyboard.GetPressedKeys().Length; ++index)
        this.pressedKeys.Add(new EKey(this.newKeyboard.GetPressedKeys()[index].ToString(), 1));
    }
  }
}
