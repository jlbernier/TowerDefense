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

        public EnnemyGameplay(MainGame mainGame) { _mainGame = mainGame; }

        public void AddEnnemy(SpriteBatch spriteBatch, GraphicsDeviceManager graphics, string ennemyID, int positionX = 0, int positionY = 0)
        {
            
            sprEnnemy = new SpriteEnnemy(_mainGame, spriteBatch,
                               EnnemyTextures.Textures[ennemyID],
                               Ennemy.Data[ennemyID].FrameWidth,
                               Ennemy.Data[ennemyID].FrameHeight,
                               Ennemy.Data[ennemyID].DecalageX,
                               Ennemy.Data[ennemyID].DecalageY,
                               Ennemy.Data[ennemyID].Velocity,
                               Ennemy.Data[ennemyID].InitDecalageX                              
                               );
            sprEnnemy.Load(_mainGame ,ennemyID);
            sprEnnemy.IsMirrored = Ennemy.Data[ennemyID].isMirrored;
            sprEnnemy.AjouteAnimation("run",
                    Ennemy.Data[ennemyID].EnnemyFrames,
                    Ennemy.Data[ennemyID].EnnemyFramesLenght,
                    Ennemy.Data[ennemyID].DecalageX,
                    Ennemy.Data[ennemyID].DecalageY);            
            sprEnnemy.spriteX = graphics.PreferredBackBufferWidth + positionX;
            sprEnnemy.spriteY = (graphics.PreferredBackBufferHeight / 2) + 4 + positionY;
            sprEnnemy.LanceAnimation("run");
        }
        public void LeftRightEnnemy(string ennemyID)
        {
            Ennemy.Data[ennemyID].isMirrored = !Ennemy.Data[ennemyID].isMirrored;
            Ennemy.Data[ennemyID].Velocity = -Ennemy.Data[ennemyID].Velocity;
        }

        public void Start(SpriteBatch spriteBatch, GraphicsDeviceManager graphics, int level = 1, int wave = 1)

        {
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

                    LeftRightEnnemy(ennemyID);
                    AddEnnemy(spriteBatch, graphics, ennemyID, position - graphics.PreferredBackBufferWidth);
                    position -= 40;
                    LeftRightEnnemy(ennemyID);

                }
                index++;
            }

                       /*
            LeftRightEnnemy("CLAMPBEETLE");
            AddEnnemy(spriteBatch, graphics, "CLAMPBEETLE", -360 - graphics.PreferredBackBufferWidth);
            LeftRightEnnemy("FIREBUG");
            AddEnnemy(spriteBatch, graphics, "FIREBUG", -60 - graphics.PreferredBackBufferWidth);
            LeftRightEnnemy("FIREWASP");
            AddEnnemy(spriteBatch, graphics, "FIREWASP", -420 - graphics.PreferredBackBufferWidth);
            LeftRightEnnemy("FLYING_LOCUST");
            AddEnnemy(spriteBatch, graphics, "FLYING_LOCUST", -240 - graphics.PreferredBackBufferWidth);
            LeftRightEnnemy("LEAFBUG");
            AddEnnemy(spriteBatch, graphics, "LEAFBUG", 0 - graphics.PreferredBackBufferWidth);
            LeftRightEnnemy("MAGMA_CRAB");
            AddEnnemy(spriteBatch, graphics, "MAGMA_CRAB", -120 - graphics.PreferredBackBufferWidth);
            LeftRightEnnemy("SCORPION");
            AddEnnemy(spriteBatch, graphics, "SCORPION", -180 - graphics.PreferredBackBufferWidth);
            LeftRightEnnemy("VOIDBUTTERFLY");
            AddEnnemy(spriteBatch, graphics, "VOIDBUTTERFLY", -300 - graphics.PreferredBackBufferWidth);
            */

        }
    }
}
