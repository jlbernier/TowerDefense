using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            this.waveNumber = 1;
            waveID = "LEVEL" + level.ToString() + "WAVE1";
            TDData.LevelAndWave = "Level " + level.ToString()  + "  Wave " + waveNumber.ToString()
                + "/" + DataWave[waveID].NbWaves;
            lstWaveEnnemies = DataWave["LEVEL" + level.ToString() + "WAVE1"].ListEnnemies;
            timerEnnemies = 0;
            indexEnnemy = 0;
            indexMaxEnnemy = lstWaveEnnemies.Count();
        }

        
        public void LeftRightEnnemy(SpriteEnnemy sprEnnemy)
        {
            sprEnnemy.isFlipHorizontally = !sprEnnemy.isFlipHorizontally;
            sprEnnemy.velocity = new Vector2(-1 * sprEnnemy.velocity.X, -1 * sprEnnemy.velocity.Y);            
        }

        public void NextWave()
        {
            if (TDData.CurrentTimerWave < DataWave["LEVEL1"].waveTimer) return;
            TDData.CurrentTimerWave = 0;
            waveNumber++; // à faire fin du niveau
            waveID = "LEVEL" + level.ToString() + "WAVE" + waveNumber.ToString();
            TDData.LevelAndWave = "Level " + level.ToString() + "  Wave " + waveNumber.ToString()
                 + "/" + DataWave[waveID].NbWaves;
            lstWaveEnnemies = DataWave["LEVEL" + level.ToString() + "WAVE" + waveNumber.ToString()].ListEnnemies;
            timerEnnemies = 0;
            indexEnnemy = 0;
            indexMaxEnnemy = lstWaveEnnemies.Count();


        }

        public void Update(Game mainGame, GraphicsDeviceManager graphics, GameTime gameTime, bool pGameIsSpeedUp = false)
        {
            timerEnnemies += (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (indexEnnemy > lstWaveEnnemies.Count() - 1)
            {
                NextWave();
                return;
            }
            if (timerEnnemies > DataWave[waveID].TimeBetweenEnnemies || indexEnnemy == 0)
            {
                if (indexEnnemy > lstWaveEnnemies.Count() - 1) return;
                ennemyID = lstWaveEnnemies[indexEnnemy].ToString();
                SceneMap.spriteEnnemyFilter.AddEnnemy(mainGame, ennemyID);
                indexEnnemy++;
                timerEnnemies = 0;
            }  
        }
    }
}
