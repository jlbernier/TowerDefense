using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Diagnostics;
using tower_Defense;
using tower_Defense.Animation;
using tower_Defense.Map;
using tower_Defense.Scenes;


namespace TowerDefence
{
    public class TowerUpgrade : Controller
    {
        public MouseState oldMouseState;
        public string upgradeTypeIconOnHover;
        private SpriteTower currentTower;
        public Rectangle boundingBoxMenuUpgradeOpen;

        public TowerUpgrade()
        {
        }

        public void AddButtonSelectUpgradeIcon(Vector2 position, String towerType, float scale)
        {
            MainGame.spriteBatch.Draw(TDTextures.Textures[TDData.Data[towerType].NameTexture],
                                    position,
                                    new Rectangle(
                                    TDData.Data[towerType].InitOffsetX,
                                    TDData.Data[towerType].InitOffsetY,
                                    TDData.Data[towerType].FrameWidth,
                                    TDData.Data[towerType].FrameHeight),
                                    Color.White, 0f, new Vector2(), scale, 0f, 0f);
            MouseState newMouseState = Mouse.GetState();
            Point MousePos = newMouseState.Position;
            Rectangle boundingBox = new Rectangle((int)position.X,
                                    (int)position.Y,
                                    (int)(TDData.Data[towerType].FrameWidth * scale),
                                    (int)(TDData.Data[towerType].FrameHeight * scale));
            if (boundingBox.Contains(MousePos))
            {
                upgradeTypeIconOnHover = towerType;
                //DisplayInfoTower(upgradeTypeIconOnHover);
            }
        }

        public void AddButtonSelectTowerOrWeaponUpgrade(Vector2 position)
        {
            AddButtonSelectUpgradeIcon(new Vector2(position.X - 64, position.Y - 100),
                            "ICONTOWERUP", 1.7f);
            AddButtonSelectUpgradeIcon(new Vector2(position.X + 16, position.Y - 100),
                            "ICONWEAPONUP", 1.7f);
        }

        public override void DrawGUI()
        {
            foreach (Tile tile in MapTiled.lstTilesTowers)
            {
                Vector2 towerBasePosition = new Vector2(tile._position.X, tile._position.Y);
                {
                    MainGame.spriteBatch.Draw(TDTextures.Textures[TDData.Data["TOWERBASE"].NameTexture], towerBasePosition, Color.White);
                }
            }
            MouseState newMouseState = Mouse.GetState();
            Point MousePos = newMouseState.Position;

            currentTower = SceneMap.spriteTowerFilter.OnHover();

            if (currentTower != null)
            {
                currentTower.IsMenuUpgradeOpen = true;
                currentTower.BoundingBox = new Rectangle(
                         (int)(currentTower.position.X - TDData.Data[currentTower.ID].FrameWidth / 2) -32,
                         (int)(currentTower.position.Y - TDData.Data[currentTower.ID].FrameHeight / 2) - 48,
                         TDData.Data[currentTower.ID].FrameWidth + 64,
                         TDData.Data[currentTower.ID].FrameHeight + 48);
                upgradeTypeIconOnHover = null;
                AddButtonSelectTowerOrWeaponUpgrade(currentTower.position);

                
                DisplayInfoTower(currentTower.ID, currentTower.spriteWeapon.weaponLevel);                
            }
        }
        

        public override void CheckClic(MainGame mainGame)
        {
            MouseState mouseState = Mouse.GetState();

            if (mouseState.LeftButton == ButtonState.Pressed &&
                        mouseState.LeftButton != oldMouseState.LeftButton &&
                        upgradeTypeIconOnHover != null)
            {
                switch (upgradeTypeIconOnHover)
                {
                    case "ICONTOWERUP":
                        if (currentTower.towerLevel < 3) 
                        { 
                            currentTower.towerLevel += 1;
                            currentTower.spriteWeapon.towerLevel = currentTower.towerLevel;
                            SceneMap.spriteTowerFilter.UpgradeTower(mainGame, currentTower);
                        }
                        break;
                    case "ICONWEAPONUP":
                        if (currentTower.weaponLevel < 3)
                        {
                            currentTower.weaponLevel += 1;
                            SceneMap.spriteTowerFilter.UpgradeWeapon(mainGame, currentTower);
                        }
                        break;
                    default:
                        break;
                }
            }
            oldMouseState = Mouse.GetState();

        }



        public override void Update()
        {
        }
    }
}




