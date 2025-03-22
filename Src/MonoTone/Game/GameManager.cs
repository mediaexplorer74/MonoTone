
// Type: GameManager.Engine.GameManager
// Assembly: GameManager, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 472C2C08-DD69-4D44-B98A-CE427E9F4CAA
// Modded by [M]edia[E]xplorer

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;
using GameManager.Source.Game;
using System.Collections.Generic;

#nullable disable
namespace GameManager.Engine
{
  public class MonoGameManager
  {
    private ESprite2d room;
    private ESprite2d screen;
    private ESprite2d mouse;
    private ESprite2d rotate;
    private List<FileClass> files = new List<FileClass>();
    public static Vector2 selectBoxPos;
    public static Vector2 selectBoxDim;
    private Song bgm;

    public MonoGameManager()
    {
      this.room = new ESprite2d(nameof (room), Vector2.Zero, Vector2.Zero);
      this.screen = new ESprite2d(nameof (screen), Vector2.Zero, Vector2.Zero);
      this.mouse = new ESprite2d("cursor", Vector2.Zero, Vector2.Zero);

      this.room.dim = new Vector2((float) this.room.model.Width / 2.2f, 
          (float) this.room.model.Height / 2.2f);
      this.screen.dim = new Vector2((float) this.screen.model.Width * 1.14f,
          (float) this.screen.model.Height * 1.14f);
      this.mouse.dim = new Vector2((float) this.mouse.model.Width * 1f, 
          (float) this.mouse.model.Height * 1f);
      this.room.pos = new Vector2((float) (Globals.graphicsDevice.Viewport.Width / 2) 
          - this.room.dim.X / 2f, 450f);
      this.screen.pos = new Vector2((float) (Globals.graphicsDevice.Viewport.Width / 2) 
          - this.screen.dim.X / 2f, 30f);
      
      this.rotate = new ESprite2d(nameof (rotate), new Vector2(508f, 358f), new Vector2(30f));

      for (int index = 0; index < 7; ++index)
                for (int index2 = 0; index2 < 7; ++index2)
                    this.files.Add(new Source.Game.FileClass("file" + index, 
                        new Vector2(40f, (float)(30 + 40 * index2))));

      for (int index = 0; index < 5; ++index)
        this.files.Add
        (
            new Source.Game.FileClass("file" + (index + 7), 
            new Vector2(80f, (float)(30 + 40 * index)))
        );

    for (int index = 0; index < 2; ++index)
    {
        this.files.Add(new Source.Game.FileClass("file" + (index + 12),
            new Vector2(200f, (float)(30 + 40 * index))));

        this.files.Add((FileClass)new Source.Game.FileClass(
            new Vector2(40f, (float)(30 + 40 * index))));
    }

      for (int index = 0; index < 5; ++index)
        this.files.Add((FileClass)new Source.Game.FileClass(new Vector2(80f, (float) (30 + 40 * index))));

      for (int index = 0; index < 2; ++index)
        this.files.Add((FileClass)new Source.Game.FileClass(new Vector2(200f, (float) (30 + 40 * index))));

      this.bgm = Globals.content.Load<Song>(nameof (bgm));
      MediaPlayer.Play(this.bgm);
      MediaPlayer.IsRepeating = false;//true;
    }

    public void Update()
    {
      this.mouse.pos = Globals.mouse.newMousePos;
      this.room.Update(Vector2.Zero);
      this.screen.Update(Vector2.Zero);
      this.mouse.Update(Vector2.Zero);
      this.rotate.rot += 0.1f;
      this.rotate.Update(Vector2.Zero);
      foreach (ESprite2d file in this.files)
        file.Update(Vector2.Zero);
    }

    public void Draw()
    {
      this.room.Draw(Vector2.Zero);
      this.screen.Draw(Vector2.Zero);
      this.rotate.DrawCentered();

     foreach (ESprite2d file in this.files)
     {
        file.Draw(Vector2.Zero);
     }

      this.beginWindowContent();

      if (Globals.mouse.LeftClickHold())
      {
        Vector2 firstMousePos = Globals.mouse.firstMousePos;
        Vector2 newMousePos = Globals.mouse.newMousePos;
        if ((double) Globals.mouse.firstMousePos.X < (double) Globals.mouse.newMousePos.X)
        {
          if ((double) Globals.mouse.firstMousePos.Y < (double) Globals.mouse.newMousePos.Y)
          {
            MonoGameManager.selectBoxPos = firstMousePos;
            MonoGameManager.selectBoxDim = newMousePos - firstMousePos;
          }
          else
          {
            MonoGameManager.selectBoxPos = new Vector2(firstMousePos.X, newMousePos.Y);
            MonoGameManager.selectBoxDim = new Vector2(newMousePos.X - firstMousePos.X,
                firstMousePos.Y - newMousePos.Y);
          }
        }
        else if ((double) Globals.mouse.firstMousePos.Y < (double) Globals.mouse.newMousePos.Y)
        {
          MonoGameManager.selectBoxPos = new Vector2(newMousePos.X, firstMousePos.Y);
          MonoGameManager.selectBoxDim = new Vector2(firstMousePos.X - newMousePos.X, 
              newMousePos.Y - firstMousePos.Y);
        }
        else
        {
          MonoGameManager.selectBoxPos = newMousePos;
          MonoGameManager.selectBoxDim = firstMousePos - newMousePos;
        }
        Globals.primitives.DrawRect(MonoGameManager.selectBoxPos, MonoGameManager.selectBoxDim, 
            new Color(Color.CornflowerBlue, 0.5f));
      }
      this.endWindowContent();
      this.mouse.Draw(Vector2.Zero);
    }

    public void beginWindowContent()
    {
      Globals.spriteBatch.End();
      RasterizerState rasterizerState = new RasterizerState();
      rasterizerState.ScissorTestEnable = true;
      Globals.spriteBatch.GraphicsDevice.RasterizerState = rasterizerState;
      Globals.spriteBatch.GraphicsDevice.ScissorRectangle = new Rectangle((int) this.screen.pos.X, 
          (int) this.screen.pos.Y, (int) this.screen.dim.X, (int) this.screen.dim.Y);
      Globals.spriteBatch.Begin(blendState: BlendState.AlphaBlend, samplerState: SamplerState.PointWrap,
          rasterizerState: rasterizerState);
    }

    public void endWindowContent()
    {
      Globals.spriteBatch.End();
      Globals.spriteBatch.Begin(blendState: BlendState.AlphaBlend);
    }
  }
}
