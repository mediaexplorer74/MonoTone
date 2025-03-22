
// Type: GameManager.Engine.EPrimitives
// Assembly: GameManager, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 472C2C08-DD69-4D44-B98A-CE427E9F4CAA
// Modded by [M]edia[E]xplorer

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

#nullable disable
namespace GameManager.Engine
{
  public class EPrimitives
  {
    private Texture2D square;

    public EPrimitives()
    {
      this.square = Globals.content.Load<Texture2D>("Square");
      Globals.font = Globals.content.Load<SpriteFont>(Globals.SystemFont);
    }

    public void DrawLine(Vector2 P1, Vector2 P2, int SIZE, Color COLOR)
    {
      float rotation = (float) Math.Atan2((double) P1.Y - (double) P2.Y, (double) P1.X - (double) P2.X);
      float width = Vector2.Distance(P1, P2);
      Globals.spriteBatch.Draw(this.square, new Rectangle((int) P2.X, (int) P2.Y, (int) width, SIZE), 
          new Rectangle?(), COLOR, rotation, Vector2.Zero, SpriteEffects.None, 0.0f);
    }

    public void DrawRect(Vector2 POS, Vector2 DIM, Color COLOR)
    {
      Globals.spriteBatch.Draw(this.square, 
          new Rectangle((int) POS.X, (int) POS.Y, (int) DIM.X, (int) DIM.Y), COLOR);
    }

    public void DrawRect(Vector2 POS, Vector2 DIM, float ROT, Color COLOR)
    {
      Globals.spriteBatch.Draw(this.square, 
          new Rectangle((int) POS.X, (int) POS.Y, (int) DIM.X, (int) DIM.Y), 
          new Rectangle?(), COLOR, ROT, new Vector2(0.0f, 0.0f), SpriteEffects.None, 0.0f);
    }

    public void DrawTxt(string TXT, Vector2 POS, Vector2 DIM, Color COLOR)
    {
      Globals.spriteBatch.DrawString(Globals.font,
          TXT, POS, COLOR, 0.0f, Vector2.Zero, DIM, SpriteEffects.None, 0.0f);
    }
  }
}
