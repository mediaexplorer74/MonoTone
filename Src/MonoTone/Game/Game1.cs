
// Type: GameManager.Game1
// Assembly: GameManager, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 472C2C08-DD69-4D44-B98A-CE427E9F4CAA
// Modded by [M]edia[E]xplorer

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using GameManager.Engine;

#nullable disable
namespace GameManager
{
  public class Game1 : Game
  {
    private GraphicsDeviceManager graphics;
    private SpriteBatch spriteBatch;
    private MonoGameManager gm;

    public Game1()
    {
      this.graphics = new GraphicsDeviceManager((Game) this);
      this.Content.RootDirectory = "Content";
      this.IsMouseVisible = false;
    }

    protected override void Initialize()
    {
      this.graphics.PreferredBackBufferWidth = 620;
      this.graphics.PreferredBackBufferHeight = 765;
      Globals.screenWidth = 620f;
      Globals.screenHeight = 765f;
      this.graphics.ApplyChanges();
      Globals.SystemFont = "galleryFont";
      Globals.fontSize = new Vector2(0.5f, 0.5f);
      Globals.spriteBatch = new SpriteBatch(this.GraphicsDevice);
      Globals.content = this.Content;
      Globals.keyboard = new EKeyboard();
      Globals.mouse = new EMouseControl();
      Globals.primitives = new EPrimitives();
      Globals.graphicsDevice = this.GraphicsDevice;
      this.gm = new MonoGameManager();
      base.Initialize();
    }

    protected override void LoadContent()
    {
      this.spriteBatch = new SpriteBatch(this.GraphicsDevice);
    }

    protected override void Update(GameTime gameTime)
    {
      if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed 
                || Keyboard.GetState().IsKeyDown(Keys.Escape))
        this.Exit();

      Globals.mouse.Update();
      this.gm.Update();

      Globals.mouse.LateUpdate();
      base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
      this.GraphicsDevice.Clear(new Color(67, 0, 0));
      Globals.spriteBatch.Begin(blendState: BlendState.AlphaBlend);
      this.gm.Draw();
      Globals.spriteBatch.End();
      base.Draw(gameTime);
    }
  }
}
