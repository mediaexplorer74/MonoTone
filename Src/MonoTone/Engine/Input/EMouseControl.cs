
// Type: GameManager.Engine.EMouseControl
// Assembly: GameManager, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 472C2C08-DD69-4D44-B98A-CE427E9F4CAA
// Modded by [M]edia[E]xplorer

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;

#nullable disable
namespace GameManager.Engine
{
  public class EMouseControl
  {
    public bool dragging;
    public bool rightDrag;
    public Vector2 newMousePos;
    public Vector2 oldMousePos;
    public Vector2 firstMousePos;
    public Vector2 newMouseAdjustedPos;
    public Vector2 systemCursorPos;
    public Vector2 screenLoc;
    public MouseState newMouse;
    public MouseState oldMouse;
    public MouseState firstMouse;

    public EMouseControl()
    {
      this.dragging = false;
      this.newMouse = Mouse.GetState();
      this.oldMouse = this.newMouse;
      this.firstMouse = this.newMouse;
      this.newMousePos = new Vector2((float) this.newMouse.Position.X, (float) this.newMouse.Position.Y);
      this.oldMousePos = this.newMousePos;
      this.firstMousePos = this.newMousePos;
      this.GetMouseAndAdjust();
    }

    public void Update()
    {
      this.GetMouseAndAdjust();
      if (this.newMouse.LeftButton != ButtonState.Pressed || this.oldMouse.LeftButton != ButtonState.Released)
        return;
      this.firstMouse = this.newMouse;
      this.firstMousePos = this.newMousePos = this.GetScreenPos(this.firstMouse);
    }

    public void LateUpdate()
    {
      this.oldMouse = this.newMouse;
      this.oldMousePos = this.GetScreenPos(this.oldMouse);
    }

    public virtual float GetDistanceFromClick()
    {
      return Globals.GetDistance(this.newMousePos, this.firstMousePos);
    }

    public virtual void GetMouseAndAdjust()
    {
      this.newMouse = Mouse.GetState();
      this.newMousePos = this.GetScreenPos(this.newMouse);
    }

    public int GetMouseweelChange()
    {
      return this.newMouse.ScrollWheelValue - this.oldMouse.ScrollWheelValue;
    }

    public Vector2 GetScreenPos(MouseState MOUSE)
    {
      return new Vector2((float) MOUSE.Position.X, (float) MOUSE.Position.Y);
    }

    public virtual bool LeftClick()
    {
      return this.newMouse.LeftButton == ButtonState.Pressed 
                && this.oldMouse.LeftButton != ButtonState.Pressed && this.newMouse.Position.X >= 0
                && (double) this.newMouse.Position.X <= (double) Globals.screenWidth 
                && this.newMouse.Position.Y >= 0 
                && (double) this.newMouse.Position.Y <= (double) Globals.screenHeight;
    }

    public virtual bool LeftClickHold()
    {
      bool flag = false;
      if (
                this.newMouse.LeftButton == ButtonState.Pressed 
                && this.oldMouse.LeftButton == ButtonState.Pressed 
                && this.newMouse.Position.X >= 0 
                && (double) this.newMouse.Position.X <= (double) Globals.screenWidth 
                && this.newMouse.Position.Y >= 0 
                && (double) this.newMouse.Position.Y <= (double) Globals.screenHeight
      )
      {
        flag = true;
        if (Math.Abs(this.newMouse.Position.X - this.firstMouse.Position.X) > 8 
                    || Math.Abs(this.newMouse.Position.Y - this.firstMouse.Position.Y) > 8)
          this.dragging = true;
      }
      return flag;
    }

    public virtual bool LeftClickRelease()
    {
      if (this.newMouse.LeftButton != ButtonState.Released 
                || this.oldMouse.LeftButton != ButtonState.Pressed)
        return false;

      this.dragging = false;
      return true;
    }

    public virtual bool RightClick()
    {
      return this.newMouse.RightButton == ButtonState.Pressed 
                && this.oldMouse.RightButton != ButtonState.Pressed
                && this.newMouse.Position.X >= 0 
                && (double) this.newMouse.Position.X <= (double) Globals.screenWidth
                && this.newMouse.Position.Y >= 0 
                && (double) this.newMouse.Position.Y <= (double) Globals.screenHeight;
    }

    public virtual bool RightClickHold()
    {
      bool flag = false;
      if (this.newMouse.RightButton == ButtonState.Pressed 
                && this.oldMouse.RightButton == ButtonState.Pressed
                && this.newMouse.Position.X >= 0
                && (double) this.newMouse.Position.X <= (double) Globals.screenWidth
                && this.newMouse.Position.Y >= 0 
                && (double) this.newMouse.Position.Y <= (double) Globals.screenHeight)
      {
        flag = true;
        if (Math.Abs(this.newMouse.Position.X - this.firstMouse.Position.X) > 8
                    || Math.Abs(this.newMouse.Position.Y - this.firstMouse.Position.Y) > 8)
          this.dragging = true;
      }
      return flag;
    }

    public virtual bool RightClickRelease()
    {
      if (this.newMouse.RightButton != ButtonState.Released 
                || this.oldMouse.RightButton != ButtonState.Pressed)
        return false;

      this.dragging = false;
      return true;
    }

    public void SetFirst()
    {
    }
  }
}
