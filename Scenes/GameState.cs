using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tower_Defense.Scenes
{
    public class GameState
    {
        public enum SceneType
        {
            Introduction,
            Map,
            GamePlay,
            GameOver
        }
        public MainGame mainGame;
        public Scene CurrentScene { get; set; }
        public GameState(MainGame pGame)
        {
            this.mainGame = pGame;
        }
        public void ChangeScene(SceneType psceneType)
        {
            if (CurrentScene != null)
            {
                CurrentScene.UnLoad();
                CurrentScene = null;
            }
            switch (psceneType)
            {
                case SceneType.Introduction:
                    CurrentScene = new SceneIntroduction(mainGame);
                    break;
                case SceneType.Map:
                    CurrentScene = new SceneMap(mainGame);
                    break;
                case SceneType.GamePlay:
                    //CurrentScene = new SceneGamePlay(mainGame);
                    break;
                case SceneType.GameOver:
                    //CurrentScene = new SceneGameOver(mainGame);
                    break;
                default:
                    break;
            }
            CurrentScene.Load();
        }
    }
}
