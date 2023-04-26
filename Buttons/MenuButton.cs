using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tower_Defense.Animation;
using tower_Defense.Scenes;

namespace tower_Defense.Buttons
{
    // The Command interface defines a method for executing a command
    public interface ICommand
    {
        void Execute();
    }

    public class MenuButton : Button
    {
        public Vector2 positionBase { get; set; }        
        public List<Button> lstButtonsMenu = new List<Button>();
        public Button button { get; private set; }        
        public MenuButton(Game mainGame, Vector2 position, Vector2 velocity, string buttonID, SceneMap currentScene) : base(mainGame, position, velocity, buttonID)
        {
            button = new Button(mainGame, new Vector2(position.X + 32, position.Y + 32), new Vector2(0, 0), "MENUSELECTTYPETOWER");
            button.scale = 1.5f;
            button.boundingBox = new Rectangle((int)(position.X -
                                widthTexture * 1.5f + 32),
                                (int)(position.Y -
                                heightTexture * 1.5f + 32),
                                (int)(widthTexture * 1.5f),
                                (int)(heightTexture * 1.5f));
            button.OnClick = currentScene.onClickDefault;
            button.OnHover = currentScene.OnHoverMenuTowerBase;
            lstButtonsMenu.Add(button);
            AddButtonSelectTowerType(currentScene, position);
        }
        public void AddButtonSelectTowerType(SceneMap pCurrentScene, Vector2 position)
        {
            AddButtonSelectTowerIcon(pCurrentScene, new Vector2(position.X - 27, position.Y - 107),
                            "TOWER81", 0.4f);
            AddButtonSelectTowerIcon(pCurrentScene, new Vector2(position.X - 61, position.Y - 107),
                            "TOWER71", 0.4f);
            AddButtonSelectTowerIcon(pCurrentScene, new Vector2(position.X - 9, position.Y - 64),
                            "TOWER61", 0.4f);
            AddButtonSelectTowerIcon(pCurrentScene, new Vector2(position.X - 44, position.Y - 64),
                            "TOWER51", 0.4f);
            AddButtonSelectTowerIcon(pCurrentScene, new Vector2(position.X - 79, position.Y - 64),
                            "TOWER41", 0.4f);
            AddButtonSelectTowerIcon(pCurrentScene, new Vector2(position.X - 79, position.Y - 24),
                            "TOWER11", 0.4f);
            AddButtonSelectTowerIcon(pCurrentScene, new Vector2(position.X - 44, position.Y - 24),
                            "TOWER21", 0.4f);
            AddButtonSelectTowerIcon(pCurrentScene, new Vector2(position.X - 9, position.Y - 24),
                            "TOWER31", 0.4f);
        }

        public void AddButtonSelectTowerIcon(SceneMap currentScene, Vector2 position, String towerType, float scale)
        {
            button = new Button(mainGame, position, new Vector2(0, 0), towerType);
            button.scale = scale;
            button.boundingBox = new Rectangle((int)position.X, (int)position.Y,
                   (int)(widthTexture * scale), (int)(heightTexture * scale));
            button.OnClick = currentScene.onClickTowerType;
            button.OnHover = currentScene.onHoverDefault;
            lstButtonsMenu.Add(button);
        }

    }
}
