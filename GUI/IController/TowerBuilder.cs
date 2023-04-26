using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.ComponentModel;
using System.Diagnostics;
using tower_Defense;
using tower_Defense.Buttons;
using tower_Defense.Map;

namespace TowerDefence
{
    public class TowerBuilder : Controller
    {
        public EBuilder type;

        public EBuilder towerSelectedToDraw;
        public bool weWantToDrawTowerOnMouse = false;


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

            
                Vector2 towerPosition = new Vector2(tile._position.X -47, tile._position.Y - 40);
                Rectangle boundingBox = new Rectangle((int)tile._position.X,
                                        (int)tile._position.Y,
                                        TDData.BoxWidth,
                                        TDData.BoxHeight);
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
                return true;
            }
            return false;
        }

        public override void DrawGUI()
        {
            foreach (Tile tile in MapTiled.lstTilesTowers)
            {
                Vector2 towerPosition = new Vector2(tile._position.X, tile._position.Y);
                if (!OnHover(tile))
                    MainGame.spriteBatch.Draw(TDTextures.Textures[TDData.Data["TOWERBASE"].NameTexture], towerPosition, Color.White);
            }
        }

        public override void DrawTowerOnMouse()
        {
            
        }


        public override void Update()
        {
            weWantToDrawTowerOnMouse = Mouse.GetState().RightButton == ButtonState.Pressed ? false : weWantToDrawTowerOnMouse;
        }

        public override void Afficher()
        {
           
        }

        public override void SelectCurrentButtonToDraw()
        {
            weWantToDrawTowerOnMouse = towerSelectedToDraw == (EBuilder)boutonCliqueIndex ? !weWantToDrawTowerOnMouse : false;
            towerSelectedToDraw = (EBuilder)boutonCliqueIndex;
        }


        public override void SelectCurrentCase()
        {
            if (weWantToDrawTowerOnMouse)
            {
                /*GUI.spriteTowerFilter
                .AddTower(mainGame, towerID, weaponTower, currentScene);
                */
            }
        }

    }
}
