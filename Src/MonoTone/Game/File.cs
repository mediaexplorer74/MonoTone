
// Type: GameManager.Source.Game.FileClass
// Assembly: GameManager, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 472C2C08-DD69-4D44-B98A-CE427E9F4CAA
// Modded by [M]edia[E]xplorer

using Microsoft.Xna.Framework;
using GameManager.Engine;

#nullable disable
namespace GameManager.Source.Game
{
  public class FileClass : ESprite2d
  {
        private bool selected;

        private Vector2 vector2;
     
        public float Width { get; }
        public float Height { get; }

        public FileClass(float width, Vector2 POS, Vector2 zero)
        : base(nameof (FileClass), POS, /*Vector2.Zero*/zero)
        {
            this.dim = new Vector2(width, this.model.Height);
            FileClass FC = new FileClass((float) this.model.Width, (float) this.model.Height);
        }

        public FileClass(string s) : base(nameof(FileClass))
        {
            Width = 24;
            Height = 24;
            //Experimental
            this.dim = new Vector2(Width, Height);
            //FileClass FC = new FileClass(dim.X, dim.Y);
        }

        public FileClass(float width, float height) : base(nameof(FileClass))
        {
            Width = width;
            Height = height;

            //Experimental
            this.dim = new Vector2(width/*this.model.Width*/, this.model.Height);
            //FileClass FC = new FileClass(/*(float)this.model.Width*/width, (float)this.model.Height);
        }

        public FileClass(Vector2 size) :  base(nameof(FileClass))
        {
            Width = size.X;
            Height = size.Y;
        }

      
        //public FileClass(float width, Vector2 POS, Vector2 zero)
        //  :

        public FileClass(string s, Vector2 vector2) : this(s)
        {
            this.vector2 = vector2;
            this.pos = this.vector2;
        }

        public override void Draw(Vector2 OFFSET)
        {
            
            //Experiment =)
            base.Draw(OFFSET, new Color(Color.CornflowerBlue, 0.5f));

            if (!this.selected)
                return;

            Globals.primitives.DrawRect(new Vector2(this.pos.X - 5f, this.pos.Y + 12f),
                new Vector2(this.dim.X + 10f, this.dim.Y - 6f), new Color(Color.CornflowerBlue, 0.5f));
        }

        public override void Update(Vector2 OFFSET)
        {
            if (Globals.mouse.LeftClick())
                this.selected = false;

            if (Globals.GetBoxOverlap(this.pos, this.dim,
                MonoGameManager.selectBoxPos,
                MonoGameManager.selectBoxDim) && Globals.mouse.LeftClickHold())
                this.selected = true;

            base.Update(OFFSET);
        }
    }
}
