using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.ComponentModel;
using System.Diagnostics;
using tower_Defense;
using tower_Defense.Animation;
using tower_Defense.Buttons;
using tower_Defense.Map;
using tower_Defense.Scenes;

namespace TowerDefence
{
    public class TowerBuilder : Controller
    {
        public MouseState oldMouseState;
        public string towerTypeIconOnHover;
        private Tile tileToBuildTower;
        public Rectangle boundingBoxMenuTowerBuilderOpen;
        public SpriteEnnemy spriteEnnemy;

        public TowerBuilder()
        {
        }

        public void AddButtonSelectTowerIcon(Vector2 position, String towerType, float scale)
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
                towerTypeIconOnHover = towerType;
                DisplayInfoTower(towerTypeIconOnHover, 1);
            }
        }

        public void AddButtonSelectTowerType(Vector2 position)
        {
            AddButtonSelectTowerIcon(new Vector2(position.X - 27, position.Y - 107),
                            "TOWER81", 0.4f);
            AddButtonSelectTowerIcon(new Vector2(position.X - 61, position.Y - 107),
                            "TOWER71", 0.4f);
            AddButtonSelectTowerIcon(new Vector2(position.X - 9, position.Y - 64),
                            "TOWER61", 0.4f);
            AddButtonSelectTowerIcon(new Vector2(position.X - 44, position.Y - 64),
                            "TOWER51", 0.4f);
            AddButtonSelectTowerIcon(new Vector2(position.X - 79, position.Y - 64),
                            "TOWER41", 0.4f);
            AddButtonSelectTowerIcon(new Vector2(position.X - 79, position.Y - 24),
                            "TOWER11", 0.4f);
            AddButtonSelectTowerIcon(new Vector2(position.X - 44, position.Y - 24),
                            "TOWER21", 0.4f);
            AddButtonSelectTowerIcon(new Vector2(position.X - 9, position.Y - 24),
                            "TOWER31", 0.4f);
        }

        public bool OnHover(Tile tile)
        {
            MouseState newMouseState = Mouse.GetState();
            Point MousePos = newMouseState.Position;

            Vector2 towerPosition = new Vector2(tile._position.X - 47, tile._position.Y - 40);
            Rectangle boundingBox = new Rectangle((int)tile._position.X,
                                    (int)tile._position.Y,
                                    TDData.BoxWidth,
                                    TDData.BoxHeight);
            if (tile.isMenuTowerBuilderOpen)
                boundingBox = new Rectangle((int)tile._position.X - 47, (int)tile._position.Y - 40,
                                   (int)(TDData.Data["MENUSELECTTYPETOWER"].FrameWidth * 1.7f),
                                   (int)(TDData.Data["MENUSELECTTYPETOWER"].FrameHeight * 1.7f));

            if (boundingBox.Contains(MousePos))
            {
                MainGame.spriteBatch.Draw(TDTextures.Textures[TDData.Data["MENUSELECTTYPETOWER"].NameTexture],
                    towerPosition,
                    new Rectangle(
                    TDData.Data["MENUSELECTTYPETOWER"].InitOffsetX,
                    TDData.Data["MENUSELECTTYPETOWER"].InitOffsetY,
                    TDData.Data["MENUSELECTTYPETOWER"].FrameWidth,
                    TDData.Data["MENUSELECTTYPETOWER"].FrameHeight),
                    Color.White, 0f, new Vector2(), 1.7f, 0f, 0f);
                AddButtonSelectTowerType(new Vector2(tile._position.X + 64, tile._position.Y + 64));
                tile.isMenuTowerBuilderOpen = true;
                return true;
            }
            tile.isMenuTowerBuilderOpen = false;
            return false;
        }

        public override void Update()
        {
        }
        public override void CheckClic(MainGame mainGame)
        {
            MouseState mouseState = Mouse.GetState();

            if (mouseState.LeftButton == ButtonState.Pressed &&
                        mouseState.LeftButton != oldMouseState.LeftButton)
            {
                tileToBuildTower = null;
                foreach (Tile tile in MapTiled.lstTilesTowers)
                {
                    if (tile.isMenuTowerBuilderOpen && towerTypeIconOnHover != null)
                    {
                        SceneMap.spriteTowerFilter.AddTower(mainGame, 
                            new Vector2(tile._position.X +32, tile._position.Y), 
                            "TOWERCONSTRUCTION1", towerTypeIconOnHover.Substring(5, 1), 1);
                        tileToBuildTower = tile;
                    }
                }
                if (tileToBuildTower != null)
                    MapTiled.lstTilesTowers.Remove(tileToBuildTower);
            }
            oldMouseState = Mouse.GetState();
        }

        public void DisplayInfoEnnemy(SpriteEnnemy spriteEnnemy)
        {
            MainGame.spriteBatch.Draw(TDTextures.Textures[TDData.Data[spriteEnnemy.ennemyID].NameTexture],
                                    new Vector2(TDData.MenuRightBottomX + 80, 
                                    TDData.MenuRightBottomY + TDData.Data[spriteEnnemy.ennemyID].OffsetCenterY),
                                    new Rectangle(
                                    TDData.Data[spriteEnnemy.ennemyID].InitOffsetX,
                                    TDData.Data[spriteEnnemy.ennemyID].InitOffsetY,
                                    TDData.Data[spriteEnnemy.ennemyID].FrameWidth,
                                    TDData.Data[spriteEnnemy.ennemyID].FrameHeight),
                                    Color.White, 0f,
                                    new Vector2(TDData.Data[spriteEnnemy.ennemyID].FrameWidth / 2, TDData.Data[spriteEnnemy.ennemyID].FrameHeight / 2), 1.1f, 0f, 0f);

            MainGame.spriteBatch.DrawString(SceneMap.myFont,
                 TDData.Data[spriteEnnemy.ennemyID].Name, new Vector2(TDData.MenuRightBottomX - 120, 
                 TDData.MenuRightBottomY - 60),
                Color.White);
            MainGame.spriteBatch.Draw(TDTextures.Textures[TDData.Data["GOLD"].NameTexture],
                                    new Vector2(TDData.MenuRightBottomX - 80,
                                    TDData.MenuRightBottomY + 10),
                                    new Rectangle(
                                    TDData.Data["GOLD"].InitOffsetX,
                                    TDData.Data["GOLD"].InitOffsetY,
                                    TDData.Data["GOLD"].FrameWidth,
                                    TDData.Data["GOLD"].FrameHeight),
                                    Color.White, 0f,
                                    new Vector2(TDData.Data["GOLD"].FrameWidth / 2, TDData.Data["GOLD"].FrameHeight / 2), 0.8f, 0f, 0f);
            MainGame.spriteBatch.DrawString(SceneMap.SmallFont,
                 "+ " + TDData.Data[spriteEnnemy.ennemyID].Gold.ToString(), new Vector2(TDData.MenuRightBottomX - 60, TDData.MenuRightBottomY + 5),
                 Color.White);
            MainGame.spriteBatch.Draw(TDTextures.Textures[TDData.Data["HEART"].NameTexture],
                                    new Vector2(TDData.MenuRightBottomX +10,
                                    TDData.MenuRightBottomY + 10),
                                    new Rectangle(
                                    TDData.Data["HEART"].InitOffsetX,
                                    TDData.Data["HEART"].InitOffsetY,
                                    TDData.Data["HEART"].FrameWidth,
                                    TDData.Data["HEART"].FrameHeight),
                                    Color.White, 0f,
                                    new Vector2(TDData.Data["HEART"].FrameWidth / 2, TDData.Data["HEART"].FrameHeight / 2), 0.8f, 0f, 0f);
            MainGame.spriteBatch.DrawString(SceneMap.SmallFont,
                  "- " + TDData.Data[spriteEnnemy.ennemyID].LifeMinus.ToString(), new Vector2(TDData.MenuRightBottomX + 30, TDData.MenuRightBottomY + 5),
                 Color.White);
            string messageText;
            if (spriteEnnemy.IsFlying) messageText = "Flying Ennemy";
            else messageText = "Walking Ennemy";
            MainGame.spriteBatch.DrawString(SceneMap.SmallFont,
                  messageText,
                  new Vector2(TDData.MenuRightBottomX - 130, TDData.MenuRightBottomY + 40),
                 Color.White);
            messageText = "Speed : ";
            if (spriteEnnemy.speed < 40) messageText += "slow";
            else if (spriteEnnemy.speed < 60) messageText += "medium";
            else if (spriteEnnemy.speed >= 60) messageText += "fast";
            MainGame.spriteBatch.DrawString(SceneMap.SmallFont,
                  messageText, 
                  new Vector2(TDData.MenuRightBottomX - 130, TDData.MenuRightBottomY + 70),
                 Color.White);
            messageText = "HP     : " + spriteEnnemy.HP.ToString();
            MainGame.spriteBatch.DrawString(SceneMap.SmallFont,
                  messageText,
                  new Vector2(TDData.MenuRightBottomX - 130, TDData.MenuRightBottomY + 100),
                 Color.White);

            if (TDData.Data[spriteEnnemy.ID].isArmored) messageText = "Ennemy is Armored";
            else messageText = "Ennemy has no Armor";
            MainGame.spriteBatch.DrawString(SceneMap.SmallFont,
                  messageText,
                  new Vector2(TDData.MenuRightBottomX - 130, TDData.MenuRightBottomY + 130),
                 Color.White);
        }

        public override void DrawGUI()
        {
            spriteEnnemy = SceneMap.spriteEnnemyFilter.OnHover();
            if (spriteEnnemy != null) DisplayInfoEnnemy(spriteEnnemy);
            foreach (Tile tile in MapTiled.lstTilesTowers)
            {
                Vector2 towerPosition = new Vector2(tile._position.X, tile._position.Y);
                if (!OnHover(tile))
                {
                    MainGame.spriteBatch.Draw(TDTextures.Textures[TDData.Data["TOWERBASE"].NameTexture], towerPosition, Color.White);
                }
            }
        }

        


        
        


    }
}
