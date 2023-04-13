using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tower_Defense.Buttons;
using tower_Defense.Map;
using tower_Defense.Scenes;

namespace tower_Defense.EnnemyGamePlay
{
    public class LoadSceneMap
    {
        Tower _tower { get; set; }
        Button _button { get; set; }
        public LoadSceneMap()
        {
        }
        public void Load(Game mainGame, MapTiled mapTiled, SceneMap currentScene)
        {
            Rectangle Screen = mainGame.Window.ClientBounds;

            foreach (Tile tile in mapTiled.lstTilesTower)
            {
                Vector2 towerPosition = new Vector2(tile._position.X + 32, tile._position.Y + 32);
                _tower = new Tower(mainGame, "TOWERTILEMAP", towerPosition);
                _tower.towerNextID = "TOWERTILEMAP";
                _tower.OnClick = currentScene.onClickDefault;
                _tower.OnHover = currentScene.onHoverButtonBase;
                currentScene.listActors.Add(_tower);
            }
            _button = new Button(mainGame, "CHAIN", new Vector2(75, 110));
            _button.OnClick = currentScene.onClickDefault;
            _button.OnHover = currentScene.onHoverDefault;
            currentScene.listActors.Add(_button);
            _button = new Button(mainGame, "CHAIN", new Vector2(160, 110));
            _button.OnClick = currentScene.onClickDefault;
            _button.OnHover = currentScene.onHoverDefault;
            currentScene.listActors.Add(_button);
            _button = new Button(mainGame, "WOODENLIFE", new Vector2(200, 80));
            _button.OnClick = currentScene.onClickDefault;
            _button.OnHover = currentScene.onHoverDefault;
            currentScene.listActors.Add(_button);
            _button = new Button(mainGame, "WOODENLIFE", new Vector2(200, 160));
            _button.OnClick = currentScene.onClickDefault;
            _button.OnHover = currentScene.onHoverDefault;
            currentScene.listActors.Add(_button);
            _button = new Button(mainGame, "GOLD", new Vector2(110, 45));
            _button.OnClick = currentScene.onClickDefault;
            _button.OnHover = currentScene.onHoverDefault;
            currentScene.listActors.Add(_button);
            _button = new Button(mainGame, "HEART", new Vector2(35, 45));
            _button.OnClick = currentScene.onClickDefault;
            _button.OnHover = currentScene.onHoverDefault;
            currentScene.listActors.Add(_button);
            _button = new Button(mainGame, "PLAY", new Vector2(Screen.Width / 2, Screen.Height / 2));
            _button.OnClick = currentScene.onClickPlay;
            _button.OnHover = currentScene.onHoverDefault;
            currentScene.listActors.Add(_button);
            _button = new Button(mainGame, "PAUSE",
                new Vector2(Screen.Width - 100, 100));
            _button.OnClick = currentScene.onClickPause;
            _button.OnHover = currentScene.onHoverThreeStates;
            currentScene.listActors.Add(_button);
            _button = new Button(mainGame, "GAMESPEED",
                new Vector2(Screen.Width - 100, 160));
            _button.OnClick = currentScene.onClickSpeedUp;
            _button.OnHover = currentScene.onHoverThreeStates;
            currentScene.listActors.Add(_button);
        }
    }
}
