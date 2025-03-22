
// Type: GameManager.Engine.ESprite2d
// Assembly: GameManager, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 472C2C08-DD69-4D44-B98A-CE427E9F4CAA
// Modded by [M]edia[E]xplorer

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

#nullable disable
namespace GameManager.Engine
{
  public class ESprite2d
  {
    public float rot;
    public Vector2 pos;
    public Vector2 dim;
    public Vector2 imgSize;
    public Vector2 imgOffset;
    public Texture2D model;
    

    public ESprite2d(string PATH, Vector2 POS, Vector2 DIM)
    {
      this.pos = POS;
      this.dim = DIM;
      this.imgSize = Vector2.One;
      
      if (PATH == "FileClass")
            PATH = "file";
      this.model = Globals.content.Load<Texture2D>(PATH);
    }

    public ESprite2d(string PATH)
    {
        this.pos = default;
        this.dim = default;
        this.imgSize = Vector2.One;

            if (PATH == "FileClass")
                PATH = "file";
        this.model = Globals.content.Load<Texture2D>(PATH);
    }

    public virtual void Update(Vector2 OFFSET)
    {
    }

    public virtual void Draw(Vector2 OFFSET)
    {
      if (this.model == null)
        return;

      Globals.spriteBatch.Draw(this.model, 
          new Rectangle((int) ((double) this.pos.X + (double) OFFSET.X),
          (int) ((double) this.pos.Y + (double) OFFSET.Y), 
          (int) ((double) this.dim.X * (double) this.imgSize.X),
          (int) ((double) this.dim.Y * (double) this.imgSize.Y)), 
          new Rectangle?(), Color.White, this.rot, Vector2.Zero, SpriteEffects.None, 0.0f);
    }

    public virtual void Draw(Vector2 OFFSET, Color COLOR)
    {
      if (this.model == null)
        return;

      Globals.spriteBatch.Draw(this.model, 
          new Rectangle((int) ((double) this.pos.X + (double) OFFSET.X), 
          (int) ((double) this.pos.Y + (double) OFFSET.Y),
          (int) ((double) this.dim.X * (double) this.imgSize.X), 
          (int) ((double) this.dim.Y * (double) this.imgSize.Y)), 
          new Rectangle?(), COLOR, this.rot, Vector2.Zero, SpriteEffects.None, 0.0f);
    }

    public virtual void DrawCentered()
    {
      if (this.model == null)
        return;
      Globals.spriteBatch.Draw(this.model, 
          new Rectangle((int) ((double) this.pos.X + (double) this.dim.X * (double) this.imgSize.X / 2.0), 
          (int) ((double) this.pos.Y + (double) this.dim.Y * (double) this.imgSize.Y / 2.0), 
          (int) ((double) this.dim.X * (double) this.imgSize.X),
          (int) ((double) this.dim.Y * (double) this.imgSize.Y)),
          new Rectangle?(), Color.White, this.rot, 
          new Vector2((float) (this.model.Width / 2), (float) (this.model.Height / 2)),
          SpriteEffects.None, 0.0f);
    }
  }
}
