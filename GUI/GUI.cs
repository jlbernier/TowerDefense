using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using tower_Defense.Animation;

namespace TowerDefence
{
    public class GUI
    {
        public static SpriteTowerFilter spriteTowerFilter;

        private TowerBuilder towerBuild = new();
        private TowerUpgrade towerUpgrade = new();
        private IController controller;

        public GUI(SpriteTowerFilter spriteTowerFilter) 
        {
            GUI.spriteTowerFilter = spriteTowerFilter;
        }

        public void Initialize()
        {

        }

        public void LoadContent()
        {
            this.controller = towerBuild;
        }

        public void Update(GameTime gameTime)
        {
            MouseState newMouseState = Mouse.GetState();
            Point MousePos = newMouseState.Position;

            KeyboardState state = Keyboard.GetState();
            if (state.IsKeyDown(Keys.A))
            {
                this.controller = towerUpgrade;
            }
            if (state.IsKeyDown(Keys.Z))
            {
                this.controller = towerBuild;
            }

            controller.CheckClic();

            controller.Update();

        }

        public void Draw()
        {
            controller.DrawGUI();
            controller.Afficher();
            controller.DrawTowerOnMouse();                        
        }
    }
}
