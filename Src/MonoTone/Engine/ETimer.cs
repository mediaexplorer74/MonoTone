
// Type: GameManager.Engine.ETimer
// Assembly: GameManager, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 472C2C08-DD69-4D44-B98A-CE427E9F4CAA
// Modded by [M]edia[E]xplorer

using System;

#nullable disable
namespace GameManager.Engine
{
  public class ETimer
  {
    public bool ready;
    protected int ms;
    protected TimeSpan timer;

    public ETimer(int m)
    {
      this.ready = false;
      this.ms = m;
    }

    public ETimer(int m, bool STARTLOADED)
    {
      this.ready = STARTLOADED;
      this.ms = m;
    }

    public int Ms
    {
      get => this.ms;
      set => this.ms = value;
    }

    public int Timer => (int) this.timer.TotalMilliseconds;

    public void UpdateTimer() => this.timer += Globals.gameTime.ElapsedGameTime;

    public void UpdateTimer(float SPEED)
    {
      this.timer += TimeSpan.FromTicks((long) ((double) Globals.gameTime.ElapsedGameTime.Ticks * (double) SPEED));
    }

    public virtual void AddToTimer(int MS) => this.timer += TimeSpan.FromMilliseconds((double) MS);

    public bool Test() => this.timer.TotalMilliseconds >= (double) this.ms || this.ready;

    public void Reset()
    {
      this.timer = this.timer.Subtract(new TimeSpan(0, 0, this.ms / 60000, this.ms / 1000, this.ms % 1000));
      if (this.timer.TotalMilliseconds < 0.0)
        this.timer = TimeSpan.Zero;
      this.ready = false;
    }

    public void Restet(int NEWTIMER)
    {
      this.timer = TimeSpan.Zero;
      this.Ms = NEWTIMER;
      this.ready = false;
    }

    public void ResetToZero()
    {
      this.timer = TimeSpan.Zero;
      this.ready = false;
    }

    public void SetTimer(TimeSpan TIME) => this.timer = TIME;

    public virtual void SetTimer(int MS) => this.timer = TimeSpan.FromMilliseconds((double) MS);
  }
}
