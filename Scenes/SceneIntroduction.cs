using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tower_Defense.Scenes
{
    public class SceneIntroduction : Scene
    {
        public SpriteFont myFont;
        public SpriteFont SmallFont;
        float time;
        public SceneIntroduction(MainGame pGame) : base(pGame)
        {
            Debug.WriteLine("New SceneIntroduction");
        }

        public override void Load()
        {
            myFont = mainGame.Content.Load<SpriteFont>("FontM6");
            SmallFont = mainGame.Content.Load<SpriteFont>("SmallFont");
            base.Load();
        }

        public override void UnLoad()
        {
            
            base.UnLoad();
        }

        public override void Update(GameTime gameTime)
        {
            time += (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (time > 1f)
            {
                mainGame._gameState.ChangeScene(GameState.SceneType.Map);
                time = 0;
            }
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            MainGame.spriteBatch.DrawString(spriteFont: myFont,
                "Introduction Tower Defense for dummies !!!!!!!!!!!!!!", new Vector2(400, 500), Color.White);
            base.Draw(gameTime);
        }
    }
}
