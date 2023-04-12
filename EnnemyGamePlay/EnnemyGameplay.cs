using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tower_Defense.Animation;
using tower_Defense.Buttons;
using tower_Defense.Scenes;
using tower_Defense.Utils;
using static tower_Defense.Utils.Wave;

namespace tower_Defense.EnnemyGameplayNameSpace
{  
    public class EnnemyGameplay
    {
        public SpriteEnnemy sprEnnemy;
        public Game _mainGame;
        public string waveID;
        private bool gameIsSpeedUp;

        public EnnemyGameplay(MainGame mainGame) { _mainGame = mainGame; }

        
        public void LeftRightEnnemy(SpriteEnnemy sprEnnemy)
        {
            sprEnnemy.IsMirrored = !sprEnnemy.IsMirrored;
            sprEnnemy.velocity = new Vector2(-1 * sprEnnemy.velocity.X, -1 * sprEnnemy.velocity.Y);            
        }

        public void Start(Game mainGame,SpriteBatch spriteBatch, GraphicsDeviceManager graphics, SpriteEnnemyFilter spriteEnnemyFilter, bool pGameIsSpeedUp = false, int level = 1, int wave = 1)

        {
            gameIsSpeedUp = pGameIsSpeedUp;
            int position = 0;
            string ennemyID = "";
            int index = 1;            
            foreach (var waveData in Wave.Data)
            {
                if (waveData.Value.Level == level && waveData.Value.Wave == wave)
                {
                    waveID = waveData.Value.ID;
                    break;
                }
            }
            index = 1;
            foreach (int i in Wave.Data[waveID].NumberEnnemies)
            {
                for (int j = 0; j < i; j++)
                {
                    if (index == 1) ennemyID = Wave.Data[waveID].EnnemyID1.ToString();  
                    else if (index == 2) ennemyID = Wave.Data[waveID].EnnemyID2.ToString();
                    else if (index == 3) ennemyID = Wave.Data[waveID].EnnemyID3.ToString();
                    else if(index == 4) ennemyID = Wave.Data[waveID].EnnemyID4.ToString();
                    else if (index == 5) ennemyID = Wave.Data[waveID].EnnemyID5.ToString();
                    else if (index == 6) ennemyID = Wave.Data[waveID].EnnemyID6.ToString();
                    else if (index == 7) ennemyID = Wave.Data[waveID].EnnemyID7.ToString();
                    else if (index == 8) ennemyID = Wave.Data[waveID].EnnemyID8.ToString();
                    spriteEnnemyFilter.AddEnnemy(mainGame, spriteBatch, ennemyID, 
                        new Vector2(position, graphics.PreferredBackBufferHeight / 2) , new Vector2(50,0));                   
                    position -= 40;
                }
                index++;
            }
        }
    }
}
