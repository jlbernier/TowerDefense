using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using tower_Defense;
using tower_Defense.Animation;
using tower_Defense.Scenes;

namespace TowerDefence
{
    public class GUI
    {
        public MainGame mainGame;
        public MouseState oldMouseState;
        public SpriteEnnemy spriteEnnemy;
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
            currentTower = null;
            currentTower = SceneMap.spriteTowerFilter.OnHover();
            this.controller = (currentTower != null) ? towerUpgrade : towerBuild;
            controller.Update();
            controller.CheckClic(mainGame);
            
        }

        public void Draw()
        {
            controller.DrawGUI();
        }
    }
}
