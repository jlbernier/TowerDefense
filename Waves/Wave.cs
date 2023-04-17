﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tower_Defense.Animation;
using tower_Defense.Buttons;
using tower_Defense.DataBase;
using tower_Defense.Scenes;
using static tower_Defense.DataBase.TDWave;

namespace tower_Defense.EnnemiesWave
{
    public class Wave
    {
        public string waveID;
        public int level;
        public int waveNumber;
        public List<eEnnemyID> lstWaveEnnemies = new();
        public int indexEnnemy;
        public int indexMaxEnnemy;
        public SpriteEnnemy sprEnnemy;
        private bool gameIsSpeedUp;
        public float timerEnnemies;
        public string ennemyID;
        public Wave(int level) 
        {
            this.level = level;
            waveID = "LEVEL" + level.ToString() + "WAVE1";
            waveNumber = 1;
            lstWaveEnnemies = DataWave["LEVEL" + level.ToString() + "WAVE1"].ListEnnemies;
            timerEnnemies = 0;
            indexEnnemy = 0;
            indexMaxEnnemy = lstWaveEnnemies.Count();
        }

        
        public void LeftRightEnnemy(SpriteEnnemy sprEnnemy)
        {
            sprEnnemy.IsMirrored = !sprEnnemy.IsMirrored;
            sprEnnemy.velocity = new Vector2(-1 * sprEnnemy.velocity.X, -1 * sprEnnemy.velocity.Y);            
        }

        public void Update(Game mainGame, GraphicsDeviceManager graphics, GameTime gameTime, SceneMap currentScene, bool pGameIsSpeedUp = false)

        {
            timerEnnemies += (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (indexEnnemy > lstWaveEnnemies.Count() - 1) return;
            if (timerEnnemies > DataWave[waveID].TimeBetweenEnnemies || indexEnnemy == 0)
            {
                ennemyID = lstWaveEnnemies[indexEnnemy].ToString();
                currentScene.spriteEnnemyFilter.AddEnnemy(mainGame, ennemyID,
                        new Vector2(0, graphics.PreferredBackBufferHeight / 2),
                        new Vector2(50, 0), TDData.eDirection.Right);
                indexEnnemy++;
                timerEnnemies = 0;
            }  
        }
    }
}
