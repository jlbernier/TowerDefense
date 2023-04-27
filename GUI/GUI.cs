using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using tower_Defense;
using tower_Defense.Animation;

namespace TowerDefence
{
    public class GUI
    {
        public MainGame mainGame;
        public MouseState oldMouseState;
        public static SpriteTowerFilter spriteTowerFilter;
        public static SpriteTower currentTower;
        private TowerBuilder towerBuild = new();
        private TowerUpgrade towerUpgrade = new();
        private IController controller;

        public GUI(MainGame mainGame, SpriteTowerFilter spriteTowerFilter) 
        {
            this.mainGame = mainGame;
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
            MouseState mouseState = Mouse.GetState();
            if (mouseState.LeftButton == ButtonState.Pressed &&
                        mouseState.LeftButton != oldMouseState.LeftButton)
            {
                currentTower = null;
                currentTower = spriteTowerFilter.IsSelected();
                if (currentTower != null)
                    this.controller = towerUpgrade;
            }
            oldMouseState = Mouse.GetState();
            controller.Update();
            controller.CheckClic(mainGame);
        }

        public void Draw()
        {
            controller.DrawGUI();
        }
    }
}
