using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using tower_Defense.Buttons;

namespace tower_Defense.Scenes
{
    abstract public class Scene
    {
        public MainGame mainGame;
        public Scene(MainGame mainGame)
        {
            this.mainGame = mainGame;
        }
        public void Clean()
        {
        }
        public virtual void Load()
        {
            
        }
        public virtual void UnLoad() { }
        public virtual void Update(GameTime gameTime)
        {
                     
        }
        public virtual void Draw(GameTime gameTime)
        {
            
        }
    }
}
