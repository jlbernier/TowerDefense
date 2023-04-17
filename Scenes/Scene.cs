using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using tower_Defense.Buttons;

namespace tower_Defense.Scenes
{
    abstract public class Scene
    {
        public MainGame mainGame;
        //public SpriteBatch spriteBatch;
        //public List<IActorButton> listButtons;
        //public SpriteFont myFont;
        //public SpriteFont SmallFont;
        public Scene(MainGame mainGame)
        {
            this.mainGame = mainGame;
            //listButtons = new List<IActorButton>();
        }
        public void Clean()
        {
            //listButtons.RemoveAll(item => item.ToRemove == true);
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
