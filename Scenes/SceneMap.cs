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
using tower_Defense.EnnemiesWave;
using static System.Formats.Asn1.AsnWriter;
using System.Reflection;
using System.Xml.Linq;
using static tower_Defense.DataBase.TDWave;
using tower_Defense.DataBase;

namespace tower_Defense.Scenes
{
    public class SceneMap : Scene
    {
        public SpriteBatch spriteBatch;
        public SpriteFont myFont;
        public SpriteFont SmallFont;
        // Map
        private readonly TmxMap _map;
        public MapTiled _mapTiled;
        // GamePlay
        public Wave ennemiesWave;
        // Buttons
        public bool isGamePaused;
        static bool isGameSpeedUp;
        public Button _button;
        public Tower _tower;
        // Filters
        public List<Button> listButtons = new();
        public List<SpriteMap> lstTilesWater = new();
        public SpriteEnnemyFilter spriteEnnemyFilter = new();
        public SpriteWeaponFilter spriteWeaponFilter = new();
        public SpriteMissileFilter spriteMissileFilter = new();
        public SpriteImpactFilter spriteImpactFilter = new();
        
        private int level = 1;

        public SceneMap(MainGame mainGame) : base(mainGame)
        {
            _mapTiled = new MapTiled(mainGame);            
        }
        public bool MenuAlreadyOpen(Button menu)
        {
            List<Tower> towerList = listButtons.Where(button => button.GetType() == typeof(Tower)).Select(button => (Tower)button).ToList();
            int numberOfmenus = towerList.Count(tower => tower.isMenuAlreadyBuild);
            if (numberOfmenus > 0 && menu.IsHover == true)
            {
                List<Tower> listMenuOpen = towerList.FindAll(tower => tower.isMenuAlreadyBuild);
                listMenuOpen.ForEach(menu =>
                {
                    menu.isMenuToRemove = true;
                });
                return true;
            }
            return false;
        }

        public void onHoverDefault(Button pSender) { }
        public void onClickDefault(Button pSender) { }
        public void onClickPlay(Button pSender)
        {
            pSender.isAnimated = false;            
            pSender.ToRemove = true;
            ennemiesWave = new Wave(level);
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
            isGameSpeedUp = pSender.IsPush;
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
            if (MenuAlreadyOpen(pSender)) return;            
            _tower.isMenuToBuild = pSender.IsHover;
        }
        public void onHoverTower(Button pSender)
        {
            if (isGamePaused) return;
            _tower = (Tower)pSender;
            _tower.towerID = "MENUUPGRADE";
            if (MenuAlreadyOpen(pSender)) return;
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
                //_tower.weaponLevel++;
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
            isGamePaused = true;
            TDTextures.PopulateTextures(mainGame);
            TDData.PopulateData();
            DataBase.TDWave.PopulateData();
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
            TDData.CurrentTimerWave += isGameSpeedUp ?
                 (float)gameTime.ElapsedGameTime.TotalSeconds * 20 :
                 (float)gameTime.ElapsedGameTime.TotalSeconds;

            listButtons.RemoveAll(actor => actor.ToRemove == true);
            listButtons.ForEach(actor => actor.Update(gameTime));
            List<Tower> towerList = listButtons.Where(button => button.GetType() == typeof(Tower)).Select(button => (Tower)button).ToList();
            towerList.ForEach(tower => tower.RemoveMenu(this, tower, _tower));
            if (!isGamePaused) towerList.ForEach(tower => tower.BuildMenu(this, tower, _tower));
            towerList.ForEach(tower => tower.BuildTowerType(gameTime, this, tower, _tower));
            spriteWeaponFilter
                .EnnemyWithinRangeWeapon(mainGame, this)
               .CooldownShootIsUp(mainGame, this);
            spriteMissileFilter
                .FollowTarget()
                .TimeOutMissile()
                .OutOfRange()
                .ImpactCollision(mainGame, this, spriteEnnemyFilter)
                .CollisionFinished();
            spriteImpactFilter
                .ImpactCollision(mainGame, this, spriteEnnemyFilter)
                .ImpactFinish();
            spriteEnnemyFilter
                .ImpactCollision()
                .RemoveDeadEnnemy();
            /*
            if (TDData.CurrentTimerWave > TDData.TimerWave)
            {
                ennemiesWave = new Wave(level);
                TDData.CurrentTimerWave = 0;
            }
            */
            _mapTiled.Update(gameTime);
            if (!isGamePaused) ennemiesWave.Update(mainGame, mainGame._graphics, gameTime, this, isGameSpeedUp);

            lstTilesWater.ForEach(actor => actor.Update(gameTime));
            spriteWeaponFilter.UpdateAll(gameTime);
            spriteMissileFilter.UpdateAll(gameTime);
            spriteImpactFilter.UpdateAll(gameTime);
            spriteEnnemyFilter.UpdateAll(gameTime);           
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            
            _mapTiled.Draw(MainGame.spriteBatch, _mapTiled.lstTilesGrass);
            lstTilesWater.ForEach(actor => actor.Draw(gameTime));
            _mapTiled.Draw(MainGame.spriteBatch, _mapTiled.lstTilesPath);
            _mapTiled.Draw(MainGame.spriteBatch, _mapTiled.lstTilesTreesAndStones);
            _mapTiled.Draw(MainGame.spriteBatch, _mapTiled.lstTilesBridges);
            _mapTiled.Draw(MainGame.spriteBatch, _mapTiled.lstTilesSartEnd);
            
            listButtons.ForEach(actor => actor.Draw(gameTime));
            spriteWeaponFilter.DrawAll(gameTime);
            spriteMissileFilter.DrawAll(gameTime);
            spriteImpactFilter.DrawAll(gameTime);
            spriteEnnemyFilter.DrawAll(gameTime);
            MainGame.spriteBatch.DrawString(SmallFont,
                TDData.LevelAndWave, new Vector2(40, 120), Color.White);
            MainGame.spriteBatch.DrawString(SmallFont,
                TDData.Life.ToString(), new Vector2(60, 38), Color.White);
            MainGame.spriteBatch.DrawString(SmallFont,
              TDData.Gold.ToString(), new Vector2(140, 38), Color.White);
            base.Draw(gameTime);
        }
    }
}
