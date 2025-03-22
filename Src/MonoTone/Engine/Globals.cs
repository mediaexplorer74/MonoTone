
// Type: GameManager.Engine.Globals
// Assembly: GameManager, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 472C2C08-DD69-4D44-B98A-CE427E9F4CAA
// Modded by [M]edia[E]xplorer

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;

#nullable disable
namespace GameManager.Engine
{
  public class Globals
  {
    public static float screenHeight;
    public static float screenWidth;
    public static string SystemFont;
    public static string activeTool = "Brush";
    public static Vector2 fontSize;
    public static SpriteFont font;
    public static ContentManager content;
    public static SpriteBatch spriteBatch;
    public static EPrimitives primitives;
    public static GraphicsDevice graphicsDevice;
    public static EKeyboard keyboard;
    public static EMouseControl mouse;
    public static GameTime gameTime;

    public static float GetDistance(Vector2 pos, Vector2 target)
    {
      return (float) Math.Sqrt(Math.Pow((double) pos.X - (double) target.X, 2.0) 
          + Math.Pow((double) pos.Y - (double) target.Y, 2.0));
    }

    public static bool GetBoxOverlap(Vector2 P1, Vector2 D1, Vector2 P2, Vector2 D2)
    {
      return (double) P1.X < (double) P2.X + (double) D2.X 
                && (double) P1.X + (double) D1.X > (double) P2.X
                && (double) P1.Y < (double) P2.Y + (double) D2.Y 
                && (double) P1.Y + (double) D1.Y > (double) P2.Y;
    }
  }
}
