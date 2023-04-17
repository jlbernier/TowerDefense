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
        SpriteMap sprMap;
        Tower _tower { get; set; }
        Button _button { get; set; }
        public LoadSceneMap()
        {
        }
        public void Load(Game mainGame, MapTiled mapTiled, SceneMap currentScene)
        {

            foreach (Tile tile in mapTiled.lstTilesAnimated)
            {
                sprMap = new SpriteMap(mainGame, tile._position, new Vector2(0, 0), "tileAnimated", tile);
                sprMap.position = tile._position;
                sprMap.isFrame = true;
                sprMap.AddAnimation("map", new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 }, 1f / 12f, tile.offsetX, tile.offsetY, true, tile.initOffsetX, tile.initOffsetY);
                sprMap.RunAnimation("map");
                currentScene.listAnimatedTiles.Add(sprMap);
            }
            Rectangle Screen = mainGame.Window.ClientBounds;
            foreach (Tile tile in mapTiled.lstTilesTower)
            {
                Vector2 towerPosition = new Vector2(tile._position.X + 32, tile._position.Y + 32);
                _tower = new Tower(mainGame, towerPosition, new Vector2(0, 0), "TOWERBASE");
                _tower.towerNextID = "TOWERBASE";
                _tower.OnClick = currentScene.onClickDefault;
                _tower.OnHover = currentScene.onHoverTowerBase;
                currentScene.listButtons.Add(_tower);
            }
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
            _button = new Button(mainGame, new Vector2(Screen.Width - 100, 100), new Vector2(0, 0), "PAUSE");
            _button.OnClick = currentScene.onClickPause;
            _button.OnHover = currentScene.onHoverThreeStates;
            currentScene.listButtons.Add(_button);
            _button = new Button(mainGame, new Vector2(Screen.Width - 100, 160), new Vector2(0, 0), "GAMESPEED");
            _button.OnClick = currentScene.onClickSpeedUp;
            _button.OnHover = currentScene.onHoverThreeStates;
            currentScene.listButtons.Add(_button);
        }
    }
}
