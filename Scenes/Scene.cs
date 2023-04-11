using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using tower_Defense.Buttons;

namespace tower_Defense.Scenes
{
    abstract public class Scene
    {
        public MainGame mainGame;
        public List<IActorButton> listActors;
        public SpriteFont myFont;
        public SpriteFont SmallFont;
        public Scene(MainGame mainGame)
        {
            this.mainGame = mainGame;
            listActors = new List<IActorButton>();
        }
        public void Clean()
        {
            listActors.RemoveAll(item => item.ToRemove == true);
        }
        public virtual void Load()
        {
            myFont = mainGame.Content.Load<SpriteFont>("FontM6");
            SmallFont = mainGame.Content.Load<SpriteFont>("SmallFont");
        }
        public virtual void UnLoad() { }
        public virtual void Update(GameTime gameTime)
        {
            listActors.RemoveAll(actor => actor.ToRemove);
            listActors.ForEach(actor => actor.Update(gameTime));          
        }
        public virtual void Draw(GameTime gameTime)
        {
            listActors.ForEach(actor => actor.Draw(mainGame._spriteBatch));
        }
    }
}
