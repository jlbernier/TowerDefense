using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tower_Defense.Buttons;

namespace tower_Defense.Scenes
{
    abstract public class Scene
    {
        public MainGame mainGame;
        public List<IActorButton> listActors;
        public SpriteFont myFont;
        public SpriteFont SmallFont;
        public Scene(MainGame pGame)
        {
            mainGame = pGame;
            listActors = new List<IActorButton>();
        }
        /*public void Clean()
        {
            listActors.RemoveAll(item => item.ToRemove == true);
        }*/
        public virtual void Load()
        {
            myFont = mainGame.Content.Load<SpriteFont>("FontM6");
            SmallFont = mainGame.Content.Load<SpriteFont>("SmallFont");
        }

        public virtual void UnLoad()
        {

        }
        public virtual void Update(GameTime gameTime)
        {
            listActors.RemoveAll(actor => actor.ToRemove);
            listActors.ForEach(actor => actor.Update(gameTime));
            /*foreach (IActorButton actor in listActors)
            {
                actor.Update(gameTime);

            }
            */
        }

        public virtual void Draw(GameTime gameTime)
        {
            foreach (IActorButton actor in listActors)
            {
                actor.Draw(mainGame._spriteBatch);

            }
        }
    }
}
