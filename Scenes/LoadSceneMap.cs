using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tower_Defense.Animation;
using tower_Defense.Buttons;
using tower_Defense.Map;

namespace tower_Defense.Scenes
{
    public class LoadSceneMap
    {
        private SpriteMap sprMap;
        SpriteTower _tower { get; set; }
        Button _button { get; set; }
        public LoadSceneMap()
        {
        }
        public static void LoadMenu(Game mainGame, MapTiled mapTiled, SceneMap currentScene, int left, int up, int nbBoxWidth, int nbBoxHeight)
        {
            Rectangle Screen = mainGame.Window.ClientBounds;
            Button _button = new Button(mainGame, new Vector2(Screen.Width + left, up), new Vector2(0, 0), "MENUUPLEFT");
            _button.OnClick = currentScene.onClickDefault;
            _button.OnHover = currentScene.onHoverDefault;
            currentScene.listButtons.Add(_button);
            for (int i = 1; i < nbBoxWidth + 1; i++)
            {
                _button = new Button(mainGame, new Vector2(Screen.Width + left + i * 32, up), new Vector2(0, 0), "MENUUP");
                _button.OnClick = currentScene.onClickDefault;
                _button.OnHover = currentScene.onHoverDefault;
                currentScene.listButtons.Add(_button);
            }

            _button = new Button(mainGame, new Vector2(Screen.Width + left + (nbBoxWidth +1) * 32, up), new Vector2(0, 0), "MENUUPRIGHT");
            _button.OnClick = currentScene.onClickDefault;
            _button.OnHover = currentScene.onHoverDefault;
            currentScene.listButtons.Add(_button);
            for (int i = 1; i < nbBoxHeight + 1; i++)
            {
                _button = new Button(mainGame, new Vector2(Screen.Width + left, up + i * 32), new Vector2(0, 0), "MENULEFT");
                _button.OnClick = currentScene.onClickDefault;
                _button.OnHover = currentScene.onHoverDefault;
                currentScene.listButtons.Add(_button);
            }
            for (int i = 1; i < nbBoxHeight + 1; i++)
            {
                _button = new Button(mainGame, new Vector2(Screen.Width + left + 32 * (nbBoxWidth + 1), up + i * 32), new Vector2(0, 0), "MENURIGHT");
                _button.OnClick = currentScene.onClickDefault;
                _button.OnHover = currentScene.onHoverDefault;
                currentScene.listButtons.Add(_button);
            }
            for (int i = 1; i < nbBoxWidth + 1; i++)
            {
                for (int j = 1; j < nbBoxHeight + 1; j++)
                {
                    _button = new Button(mainGame, new Vector2(Screen.Width + left + i * 32, up + j * 32), new Vector2(0, 0), "MENUMIDDLE");
                    _button.OnClick = currentScene.onClickDefault;
                    _button.OnHover = currentScene.onHoverDefault;
                    currentScene.listButtons.Add(_button);
                }
            }
            _button = new Button(mainGame, new Vector2(Screen.Width + left, up + 32 * (nbBoxHeight + 1)), new Vector2(0, 0), "MENUBOTTOMLEFT");
            _button.OnClick = currentScene.onClickDefault;
            _button.OnHover = currentScene.onHoverDefault;
            currentScene.listButtons.Add(_button);
            for (int i = 1; i < nbBoxWidth + 1; i++)
            {
                _button = new Button(mainGame, new Vector2(Screen.Width + left + i * 32, up + 32 * (nbBoxHeight + 1)), new Vector2(0, 0), "MENUBOTTOM");
                _button.OnClick = currentScene.onClickDefault;
                _button.OnHover = currentScene.onHoverDefault;
                currentScene.listButtons.Add(_button);
            }
            _button = new Button(mainGame, new Vector2(Screen.Width + left + (nbBoxWidth + 1) * 32, up + 32 * (nbBoxHeight + 1)), new Vector2(0, 0), "MENUBOTTOMRIGHT");
            _button.OnClick = currentScene.onClickDefault;
            _button.OnHover = currentScene.onHoverDefault;
            currentScene.listButtons.Add(_button);
        }
        public void Load(Game mainGame, MapTiled mapTiled, SceneMap currentScene)
        {
            Random rand = new Random();
            float time = 1 / 12f;

            foreach (Tile tile in mapTiled.lstTilesWater)
            {
                time = 1f / 12f;
                sprMap = new SpriteMap(mainGame, tile._position, new Vector2(0, 0), "tileAnimated", tile);
                sprMap.position = tile._position;
                sprMap.isFrame = true;
                time *= rand.Next(1, 3);
                sprMap.AddAnimation("map", new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 }, time, tile.offsetX, tile.offsetY, true, tile.initOffsetX, tile.initOffsetY);
                sprMap.RunAnimation("map");
                sprMap.frame = rand.Next(0, 10);
                currentScene.lstTilesWater.Add(sprMap);
            }
            Rectangle Screen = mainGame.Window.ClientBounds;
           /* foreach (Tile tile in mapTiled.lstTilesTowers)
            {
                Vector2 towerPosition = new Vector2(tile._position.X + 32, tile._position.Y + 32);
                /*_tower = new Tower(mainGame, towerPosition, new Vector2(0, 0), "TOWERBASE");
                _tower.towerNextID = "TOWERBASE";
                _tower.OnClick = currentScene.onClickDefault;
                _tower.OnHover = currentScene.onHoverTowerBase;
                currentScene.listButtons.Add(_tower);*/

                /*Vector2 towerPosition = new Vector2(tile._position.X + 32, tile._position.Y + 32);
                _button = new MenuButton(mainGame, towerPosition, new Vector2(0, 0), "TOWERBASE", currentScene);
                _button.OnClick = currentScene.onClickDefault;
                _button.OnHover = currentScene.OnHoverMenuTowerBase;
                currentScene.listMenuTowerBase.Add(_button);
            }*/

            _button = new Button(mainGame, new Vector2(75, 110), new Vector2(0, 0), "CHAIN");
            _button.OnClick = currentScene.onClickDefault;
            _button.OnHover = currentScene.onHoverDefault;
            currentScene.listButtons.Add(_button);
            _button = new Button(mainGame, new Vector2(160, 110), new Vector2(0, 0), "CHAIN");
            _button.OnClick = currentScene.onClickDefault;
            _button.OnHover = currentScene.onHoverDefault;
            currentScene.listButtons.Add(_button);
            _button = new Button(mainGame, new Vector2(200, 80), new Vector2(0, 0), "WOODENLIFE");
            _button.OnClick = currentScene.onClickDefault;
            _button.OnHover = currentScene.onHoverDefault;
            currentScene.listButtons.Add(_button);
            _button = new Button(mainGame, new Vector2(200, 160), new Vector2(0, 0), "WOODENLIFE");
            _button.OnClick = currentScene.onClickDefault;
            _button.OnHover = currentScene.onHoverDefault;
            currentScene.listButtons.Add(_button);
            _button = new Button(mainGame, new Vector2(110, 45), new Vector2(0, 0), "GOLD");
            _button.OnClick = currentScene.onClickDefault;
            _button.OnHover = currentScene.onHoverDefault;
            currentScene.listButtons.Add(_button);
            _button = new Button(mainGame, new Vector2(35, 45), new Vector2(0, 0), "HEART");
            _button.OnClick = currentScene.onClickDefault;
            _button.OnHover = currentScene.onHoverDefault;
            currentScene.listButtons.Add(_button);
            _button = new Button(mainGame, new Vector2(Screen.Width / 2, Screen.Height / 2), new Vector2(0, 0), "PLAY");
            _button.OnClick = currentScene.onClickPlay;
            _button.OnHover = currentScene.onHoverDefault;
            currentScene.listButtons.Add(_button);

            LoadMenu(mainGame, mapTiled, currentScene, TDData.MenuLeft, TDData.MenuUp, 5, 5);

            LoadMenu(mainGame, mapTiled, currentScene, TDData.MenuInfoLeft, TDData.MenuInfoUp, 8, 12);


            _button = new Button(mainGame, new Vector2(Screen.Width - 200, 150), new Vector2(0, 0), "PAUSE");
            _button.OnClick = currentScene.onClickPause;
            _button.OnHover = currentScene.onHoverThreeStates;
            currentScene.listButtons.Add(_button);
            _button = new Button(mainGame, new Vector2(Screen.Width - 100, 150), new Vector2(0, 0), "GAMESPEED");
            _button.OnClick = currentScene.onClickSpeedUp;
            _button.OnHover = currentScene.onHoverThreeStates;
            currentScene.listButtons.Add(_button);

        }
    }
}
