using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System.Diagnostics;
using tower_Defense;
using tower_Defense.Animation;
using tower_Defense.Scenes;

namespace TowerDefence
{
    public abstract class Controller : IController
    {
        public Controller() 
        {
        
        }
        public abstract void Update();
        public abstract void CheckClic(MainGame mainGame);
        public abstract void DrawGUI();
        public void DisplayInfoTower(string towerType, int weaponLevel)
        {
            MainGame.spriteBatch.Draw(TDTextures.Textures[TDData.Data[towerType].NameTexture],
                                    new Vector2(TDData.MenuRightBottomX, TDData.MenuRightBottomY + TDData.Data[towerType].OffsetCenterY),
                                    new Rectangle(
                                    TDData.Data[towerType].InitOffsetX,
                                    TDData.Data[towerType].InitOffsetY,
                                    TDData.Data[towerType].FrameWidth,
                                    TDData.Data[towerType].FrameHeight),
                                    Color.White, 0f,
                                    new Vector2(TDData.Data[towerType].FrameWidth / 2, TDData.Data[towerType].FrameHeight / 2), 1f, 0f, 0f);
            string weaponType = "WEAPONTOWER" +
                     towerType.Substring(5, 1) + "LEVEL" + weaponLevel.ToString();
            MainGame.spriteBatch.Draw(TDTextures.Textures[TDData.Data[weaponType].NameTexture],
                                new Vector2(TDData.MenuRightBottomX, 
                                TDData.MenuRightBottomY + TDData.Data[weaponType].OffsetMenuInfoY + 
                                TDData.Data[towerType].OffsetMenuTowerWeaponY),
                                new Rectangle(
                                TDData.Data[weaponType].InitOffsetX,
                                TDData.Data[weaponType].InitOffsetY,
                                TDData.Data[weaponType].FrameWidth,
                                TDData.Data[weaponType].FrameHeight),
                                Color.White, 0f,
                                new Vector2(TDData.Data[weaponType].FrameWidth / 2, TDData.Data[weaponType].FrameHeight / 2), 1f, 0f, 0f);
            MainGame.spriteBatch.DrawString(SceneMap.SmallFont,
                 "blablablabla", new Vector2(TDData.MenuRightBottomX - 120, TDData.MenuRightBottomY + 30),
                 Color.White);
        }
        
    }
}
