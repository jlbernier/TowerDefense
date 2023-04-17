﻿using Microsoft.Xna.Framework.Graphics;
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
using static tower_Defense.Utils.Wave;

namespace tower_Defense.Scenes
{
    public class SceneMap : Scene
    {
        public SpriteBatch spriteBatch;
        public SpriteFont myFont;
        public SpriteFont SmallFont;
        // Map
        private readonly TmxMap _map;
        private readonly MapTiled _mapTiled;
        // GamePlay
        private readonly EnnemyGameplay _ennemyGamePlay;
        // Buttons
        public bool isGamePaused;
        public Button _button;
        public Tower _tower;
        // Filters
        public List<Button> listButtons = new();
        public List<SpriteMap> listAnimatedTiles = new();
        public SpriteEnnemyFilter spriteEnnemyFilter = new();
        public SpriteWeaponFilter spriteWeaponFilter = new();
        public SpriteMissileFilter spriteMissileFilter = new();
        public SpriteImpactFilter spriteImpactFilter = new();
        // Textes
        private string LevelAndWave;
        private int level = 1;
        private int wave = 1;

        public int test;
        //timers
        static bool gameIsSpeedUp;
        public float timerWaves;
        public float timerEnnemies;

        public SceneMap(MainGame mainGame) : base(mainGame)
        {
            _mapTiled = new MapTiled(mainGame);            
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
            //SpriteButton.lstButtonSprites.ForEach(spritebutton => spritebutton.isPaused = pSender.IsPush);
            isGamePaused = pSender.IsPush;
        }
        public void onClickTowerType(Button pSender)
        {
            _tower= (Tower)pSender;
            _tower.towerNextID = _tower.towerToBuild;
            _tower.positionBase = new Vector2(_tower.positionBase.X, _tower.positionBase.Y + 16);
            _tower.towerID = "MENUTILEMAP";
        }
        public void onHoverTowerBase(Button pSender)
        {
            if (isGamePaused) return;
            _tower = (Tower)pSender;
            _tower.isMenuToBuild = pSender.IsHover;
        }
        public void onHoverTower(Button pSender)
        {
            if (isGamePaused) return;
            _tower = (Tower)pSender;
            _tower.towerID = "MENUUPGRADE";
            //if (!pSender.IsHover) { Debug.WriteLine("test"); }
            _tower.isMenuToBuild = pSender.IsHover;
        }
        public void onHoverMenuSelectTowerType(Button pSender)
        {
            if (isGamePaused) return;
            _tower = (Tower)pSender;
            if (_tower.towerID != "MENUSELECTTYPETOWER") { Debug.WriteLine("test"); }
            _tower.isMenuToRemove = !pSender.IsHover;          
        }
        public void onHoverMenuUpgrade(Button pSender)
        {
            if (isGamePaused) return;
            _tower = (Tower)pSender;
            if (_tower.towerID != "MENUSELECTUPGRADE") { Debug.WriteLine("test"); }
            _tower.towerID = "MENUUPGRADE";
            _tower.isMenuToRemove = !pSender.IsHover;
        }
        public void onClickTowerUpgrade(Button pSender)
        {
            if (isGamePaused) return;
            _tower = (Tower)pSender;
            if (_tower.towerID == "ICONROTATEWEAPON") _tower.towerID = "ROTATEWEAPON";
            else
            {
                _tower.weaponLevel++;
                _tower.towerToBuild = "TOWER" + _tower.towerType + (_tower.towerLevel).ToString();
                _tower.towerNextID = _tower.towerToBuild;
                _tower.WeaponOrTowerUpgrade = true;
                _tower.towerID = "UPGRADE";
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
            myFont = mainGame.Content.Load<SpriteFont>("FontM6");
            SmallFont = mainGame.Content.Load<SpriteFont>("SmallFont");
            LevelAndWave = "Level: 1 Wave: 1/7";
            isGamePaused = true;
            TDTextures.PopulateTextures(mainGame);
            TDData.PopulateData();
            Wave.PopulateData();
            _mapTiled.LoadMap();            
            LoadSceneMap loadSceneMap = new LoadSceneMap();
            loadSceneMap.Load(mainGame, _mapTiled, this);
            base.Load();
        }

        public override void UnLoad()
        {            
            base.UnLoad();
        }

        public override void Update(GameTime gameTime)
        {
            timerWaves += gameIsSpeedUp ?
                 (float)gameTime.ElapsedGameTime.TotalSeconds * 20 :
                 (float)gameTime.ElapsedGameTime.TotalSeconds;
            timerEnnemies += (float)gameTime.ElapsedGameTime.TotalSeconds;

            listButtons.RemoveAll(actor => actor.ToRemove == true);
            listButtons.ForEach(actor => actor.Update(gameTime));
            List<Tower> towerList = listButtons.Where(button => button.GetType() == typeof(Tower)).Select(button => (Tower)button).ToList();
            if (!isGamePaused) towerList.ForEach(tower => tower.BuildMenu(this, tower, _tower));
            towerList.ForEach(tower => tower.RemoveMenu(this, tower, _tower));
            towerList.ForEach(tower => tower.BuildTowerType(gameTime, this, tower, _tower));
            spriteWeaponFilter
               .CooldownShootIsUp(mainGame, this);
            spriteMissileFilter
                .TimeOutMissile()
                .OutOfRange()
                .ImpactCollision(mainGame, this, spriteEnnemyFilter)
                .CollisionFinished();
            spriteImpactFilter
                .ImpactFinish();
            spriteEnnemyFilter
                .RemoveDeadEnnemy();
              

            

            //tests
            if (timerWaves > 60f)
            {
                wave += 1;
                LevelAndWave = "Level: 1 Wave: " + wave + "/7";
                _ennemyGamePlay.Start(mainGame, mainGame._graphics, this, gameIsSpeedUp, 1, 2);                        
                timerWaves = 0;
            }

            _mapTiled.Update(gameTime);
            listAnimatedTiles.ForEach(actor => actor.Update(gameTime));
            spriteWeaponFilter.UpdateAll(gameTime);
            spriteMissileFilter.UpdateAll(gameTime);
            spriteImpactFilter.UpdateAll(gameTime);
            spriteEnnemyFilter.UpdateAll(gameTime);           
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            _mapTiled.Draw(MainGame.spriteBatch);
            listAnimatedTiles.ForEach(actor => actor.Draw(gameTime));

            listButtons.ForEach(actor => actor.Draw(gameTime));
            spriteWeaponFilter.DrawAll(gameTime);
            spriteMissileFilter.DrawAll(gameTime);
            spriteImpactFilter.DrawAll(gameTime);
            spriteEnnemyFilter.DrawAll(gameTime);
            MainGame.spriteBatch.DrawString(SmallFont,
                LevelAndWave, new Vector2(40, 120), Color.White);
            MainGame.spriteBatch.DrawString(SmallFont,
                "20", new Vector2(60, 38), Color.White);
            MainGame.spriteBatch.DrawString(SmallFont,
              "1500", new Vector2(140, 38), Color.White);
            base.Draw(gameTime);
        }
    }
}
