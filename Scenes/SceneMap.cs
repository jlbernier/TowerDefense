using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiledSharp;
using tower_Defense.Buttons;
using tower_Defense.Map;
using tower_Defense.Animation;
using tower_Defense.Utils;
using tower_Defense.EnnemyGameplayNameSpace;
using static System.Formats.Asn1.AsnWriter;
using System.Reflection;
using System.Xml.Linq;
using tower_Defense.EnnemyGamePlay;

namespace tower_Defense.Scenes
{
    public class SceneMap : Scene
    {
        // Map
        private readonly TmxMap _map;
        private readonly MapTiled _mapTiled;
        // GamePlay
        private readonly EnnemyGameplay _ennemyGamePlay;
        // Buttons
        private bool isGamePaused;
        public Button _button;
        public Tower _tower;
        public SpriteMissileFilter spriteMissileFilter;
        public SpriteEnnemyFilter spriteEnnemyFilter;
        public SpriteTowerFilter spriteTowerFilter;
        // Textes
        private string LevelAndWave;
        private int level = 1;
        private int wave = 1;
        //timers
        bool gameIsSpeedUp;
        float timerWaves;
        float timerEnnemies;

        public SceneMap(MainGame pGame) : base(pGame)
        {
            _mapTiled = new MapTiled(mainGame);
            spriteMissileFilter = new SpriteMissileFilter();
            spriteEnnemyFilter = new SpriteEnnemyFilter();
            spriteTowerFilter = new SpriteTowerFilter();
            _ennemyGamePlay = new EnnemyGameplay(mainGame);
        }
        public void onHoverDefault(Button pSender) { }
        public void onClickDefault(Button pSender) { }
        public void onClickPlay(Button pSender)
        {
            pSender.isAnimated = false;
            pSender.ToRemove = true;
            timerWaves = 100;
            isGamePaused = false;
        }
        public void onHoverSpeedUp(Button pSender)
        {           
            if (isGamePaused) return;

            if (!pSender.IsHover)
            {
                pSender.textureBox = pSender.IsPush ?
                      new Rectangle(TDData.Data["GAMESPEED"].InitOffsetX + TDData.Data["GAMESPEED"].OffsetPushX, pSender.textureBox.Y,
                          pSender.textureBox.Width, pSender.textureBox.Height) :
                      new Rectangle(TDData.Data["GAMESPEED"].InitOffsetX, pSender.textureBox.Y,
                          pSender.textureBox.Width, pSender.textureBox.Height);
            }
            else
            {
                if (pSender.IsClick)
                {
                    pSender.textureBox = pSender.IsPush ?
                       new Rectangle(TDData.Data["GAMESPEED"].InitOffsetX + TDData.Data["GAMESPEED"].OffsetPushX, pSender.textureBox.Y,
                          pSender.textureBox.Width, pSender.textureBox.Height) :
                       new Rectangle(TDData.Data["GAMESPEED"].InitOffsetX, pSender.textureBox.Y,
                          pSender.textureBox.Width, pSender.textureBox.Height);
                }
                else
                {
                    pSender.textureBox = new Rectangle(TDData.Data["GAMESPEED"].InitOffsetX + TDData.Data["GAMESPEED"].OffsetSelectedX, pSender.textureBox.Y,
                         pSender.textureBox.Width, pSender.textureBox.Height);
                }
            }      
        }
        public void onClickSpeedUp(Button pSender)
        {
            if (isGamePaused) return;
            TDSprite.lstSprites.ForEach(sprite => sprite.isSpeedUp = pSender.IsPush);
            gameIsSpeedUp = pSender.IsPush;
        }
        public void onHoverPause(Button pSender)
        {
          if (!pSender.IsHover)
            {
                pSender.textureBox = pSender.IsPush ?
                      new Rectangle(TDData.Data["PAUSE"].InitOffsetX + TDData.Data["PAUSE"].OffsetPushX, pSender.textureBox.Y,
                          pSender.textureBox.Width, pSender.textureBox.Height) :
                      new Rectangle(TDData.Data["PAUSE"].InitOffsetX, pSender.textureBox.Y,
                          pSender.textureBox.Width, pSender.textureBox.Height);
            }
            else
            {
                if (pSender.IsClick)
                {
                    pSender.textureBox = pSender.IsPush ?
                       new Rectangle(TDData.Data["PAUSE"].InitOffsetX + TDData.Data["PAUSE"].OffsetPushX, pSender.textureBox.Y,
                          pSender.textureBox.Width, pSender.textureBox.Height) :
                       new Rectangle(TDData.Data["PAUSE"].InitOffsetX, pSender.textureBox.Y,
                          pSender.textureBox.Width, pSender.textureBox.Height);
                }
                else
                {
                    pSender.textureBox = new Rectangle(TDData.Data["PAUSE"].InitOffsetX + TDData.Data["PAUSE"].OffsetSelectedX, pSender.textureBox.Y,
                         pSender.textureBox.Width, pSender.textureBox.Height);
                }
            }
        }
        public void onClickPause(Button pSender)
        {
            
            TDSprite.lstSprites.ForEach(sprite => sprite.isPaused = pSender.IsPush);
            SpriteButton.lstButtonSprites.ForEach(spritebutton => spritebutton.isPaused = pSender.IsPush);
            isGamePaused = pSender.IsPush;
        }
        public void onClickTowerType(Button pSender)
        {
            _tower= (Tower)pSender;
            _tower.towerNextID = _tower.towerToBuild;
            _tower.towerID = "MENUTILEMAP";
        }
        public void onHoverButtonBase(Button pSender)
        {
            if (isGamePaused) return;
            _tower = (Tower)pSender;
            _tower.isMenuToBuild = true;
        }
        public void onHoverMenuTypeTower(Button pSender)
        {
            if (isGamePaused) return;
            _tower = (Tower)pSender;
            _tower.isMenuToRemove = !pSender.IsHover;          
        }
        public void onHoverTowerUpgrade(Button pSender)
        {
            if (isGamePaused) return;
            if (isGamePaused) return;
            _tower = (Tower)pSender;
            if (_tower.IsHover || _tower.lstButtonsMenu != null)
            {
                _tower.towerID = "MENUUPGRADE";
                _tower.isMenuToBuild = true;
            }
        }     
        public void onClickTowerUpgrade(Button pSender)
        {
            if (isGamePaused) return;
            _tower = (Tower)pSender;
            if (_tower.towerID == "ICONROTATEWEAPON")
            {
                  _tower.towerID = "ROTATEWEAPON";
            }
            if (_tower.towerID == "ICONTOWERUP")
            {
                if (_tower.towerLevel < 3)
                {
                    _tower.towerToBuild = "TOWER" + _tower.towerType + (_tower.towerLevel++).ToString();
                    _tower.towerNextID = _tower.towerToBuild;
            _tower.towerID = "UPGRADE";
                }
            }
            if (_tower.towerID == "ICONWEAPONUP")
            {
                if (_tower.weaponLevel < 3)
                {
                    _tower.weaponLevel++;
                    _tower.towerToBuild = "TOWER" + _tower.towerType + (_tower.towerLevel).ToString();
                    _tower.towerNextID = _tower.towerToBuild;
            _tower.towerID = "UPGRADE";
                }
            }
        }
        public void onHoverThreeStates(Button pSender)
        {
            if (!pSender.IsHover)
            {
                pSender.textureBox = pSender.IsPush ?
                      new Rectangle(TDData.Data[pSender.buttonID.ToString()].InitOffsetX + TDData.Data[pSender.buttonID.ToString()].OffsetPushX, pSender.textureBox.Y,
                          pSender.textureBox.Width, pSender.textureBox.Height) :
                      new Rectangle(TDData.Data[pSender.buttonID.ToString()].InitOffsetX, pSender.textureBox.Y,
                          pSender.textureBox.Width, pSender.textureBox.Height);
            }
            else
            {
                if (pSender.IsClick)
                {
                    pSender.textureBox = pSender.IsPush ?
                       new Rectangle(TDData.Data[pSender.buttonID.ToString()].InitOffsetX + TDData.Data[pSender.buttonID.ToString()].OffsetPushX, pSender.textureBox.Y,
                          pSender.textureBox.Width, pSender.textureBox.Height) :
                       new Rectangle(TDData.Data[pSender.buttonID.ToString()].InitOffsetX, pSender.textureBox.Y,
                          pSender.textureBox.Width, pSender.textureBox.Height);
                }
                else
                {
                    pSender.textureBox = new Rectangle(TDData.Data[pSender.buttonID.ToString()].InitOffsetX + TDData.Data[pSender.buttonID.ToString()].OffsetSelectedX, pSender.textureBox.Y,
                         pSender.textureBox.Width, pSender.textureBox.Height);
                }
            }
        }
     
        public override void Load()
        {
            LevelAndWave = "Level: 1 Wave: 1/7";
            isGamePaused = true;
            TDTextures.PopulateTextures(mainGame);
            TDData.PopulateData();
            Wave.PopulateData();
            _mapTiled.LoadMap();
           _mapTiled.Load(mainGame._spriteBatch);
            LoadSceneMap loadSceneMap = new LoadSceneMap();
            loadSceneMap.Load(mainGame, _mapTiled, this);


           




            // pour les tests
            int offset = 0;
            for (int i = 1; i < 9; i++)
            {
                for (int j = 1; j < 4; j++)
                {
                    if (i == 8) continue;
                    if (i == 7)
                    {
                        spriteMissileFilter.AddMissile(mainGame, mainGame._spriteBatch,"MISSILETOWER7LEVELX",new Vector2(100 + offset, 1000), new Vector2(0, -15));
                        
                    }
                    else
                    {
                        spriteMissileFilter.AddMissile(mainGame, mainGame._spriteBatch, "MISSILETOWER" + i.ToString() + "LEVEL" + j.ToString(),
              new Vector2(100 + offset, 1000), new Vector2(0, -15));
                    }
                    offset += 40;
                }
            }
            base.Load();
        }

        public override void UnLoad()
        {            
            base.UnLoad();
        }

        public override void Update(GameTime gameTime)
        {
            List<Tower> towerList = listActors.Where(button => button.GetType() == typeof(Tower)).Select(button => (Tower)button).ToList();
            if (!isGamePaused) towerList.ForEach(tower => tower.BuildMenu(this,  tower, _tower));
            towerList.ForEach(tower => tower.MenuToRemove(this, tower, _tower));
            towerList.ForEach(tower => tower.BuildTowerType(this, gameTime, tower, _tower, spriteTowerFilter));
            List<Tower> weaponTowerList = towerList.Where(tower =>tower.isWeaponTower).ToList();
           
            Debug.WriteLine("spriteTowerFilter" +  spriteTowerFilter.liste.Count());

            spriteTowerFilter
                .CooldownShootIsUp();
                

            spriteMissileFilter
                .CollisionFinished()
                 .ImpactCollision();
            spriteEnnemyFilter
                .ImpactCollision()
                .RemoveDeadEnnemy();

            if (weaponTowerList.Count != 0)
            {
                weaponTowerList[0].weaponLevel = 1;
            }

            timerWaves += gameIsSpeedUp ?
               (float)gameTime.ElapsedGameTime.TotalSeconds * 20 :
               (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (timerWaves > 10f)
            {
                wave += 1;
                LevelAndWave = "Level: 1 Wave: " + wave + "/7";
                _ennemyGamePlay.Start(mainGame, mainGame._spriteBatch, mainGame._graphics, spriteEnnemyFilter, gameIsSpeedUp, 1, 2);
                
                timerWaves = 0;
                int offsetY = 100;
                int offset = 0;
                for (int i = 1; i < 9; i++)
                {
                    for (int j = 1; j < 4; j++)
                    {
                        if (i == 8) continue;
                        if (i == 1 || i == 6 || i == 7)
                        {
                            spriteMissileFilter.AddMissile(mainGame, mainGame._spriteBatch,
                             "IMPACTTOWER1LEVELX",
                  new Vector2(100 + offset, 1000 - offsetY), new Vector2(0, 0));
                        }
                        else
                        {
                            spriteMissileFilter.AddMissile(mainGame, mainGame._spriteBatch,
                             "IMPACTTOWER" + i.ToString() + "LEVEL" + j.ToString(),
                  new Vector2(100 + offset, 1000 - offsetY), new Vector2(0, 0));
                        }
                        offset += 40;
                    }
                }
            }






            timerEnnemies += (float)gameTime.ElapsedGameTime.TotalSeconds;
            
            TDSprite.lstSprites.RemoveAll(ennemy => ennemy.ToRemove);            
            _mapTiled.Update(gameTime);
            spriteMissileFilter.UpdateAll(gameTime);
             TDSprite.UpdateAll(gameTime);
            SpriteButton.UpdateAll(gameTime);
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            _mapTiled.Draw(mainGame._spriteBatch);
            spriteMissileFilter.DrawAll(gameTime);
             TDSprite.DrawAll(gameTime);
            SpriteButton.DrawAll(mainGame._spriteBatch);
            base.Draw(gameTime);
            mainGame._spriteBatch.DrawString(spriteFont: base.SmallFont,
                LevelAndWave, new Vector2(40, 120), Color.White);
            mainGame._spriteBatch.DrawString(spriteFont: base.SmallFont,
                "20", new Vector2(60, 38), Color.White);
            mainGame._spriteBatch.DrawString(spriteFont: base.SmallFont,
              "1500", new Vector2(140, 38), Color.White);
        }
    }
}
