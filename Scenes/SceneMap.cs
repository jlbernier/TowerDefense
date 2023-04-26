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
using System.Reflection.Metadata;
using TowerDefence;

namespace tower_Defense.Scenes
{
    public class SceneMap : Scene
    {
        // tests
        public Vector2 positionWaveTimer;
        private float radiusWaveTimer;
        private Texture2D tileset;
        private Rectangle sourceRect;
        private Vector2 scale;

        public SpriteBatch spriteBatch;
        public SpriteFont myFont;
        public SpriteFont SmallFont;
        // Map
        private readonly TmxMap _map;
        public MapTiled map;
        // GUI
        private GUI gui;
        // GamePlay
        public Wave ennemiesWave;
        // Buttons
        public bool isGamePaused;
        static bool isGameSpeedUp;
        public Button _button;
        public Tower _tower;
        // Filters
        public List<Button> listButtons = new();
        public SpriteTowerFilter spriteTowerFilter;
        public MenuButton _menuButton;
        public List<SpriteMap> lstTilesWater = new();
        public SpriteEnnemyFilter spriteEnnemyFilter = new();
        public SpriteWeaponFilter spriteWeaponFilter = new();
        public SpriteMissileFilter spriteMissileFilter = new();
        public SpriteImpactFilter spriteImpactFilter = new();
        
        private int level = 1;

        public SceneMap(MainGame mainGame) : base(mainGame)
        {
            map = new MapTiled(mainGame);
            gui = new GUI(spriteTowerFilter);
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

        public void OnHoverMenuTowerBase(Button pSender)
        {
            _menuButton = (MenuButton)pSender;
            if (pSender.IsHover) 
            { 
               // listMenuTowerBase.Add(_menuButton.lstButtonsMenu);
            }
            Debug.WriteLine("");
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
            positionWaveTimer = new Vector2();
            myFont = mainGame.Content.Load<SpriteFont>("FontM6");
            SmallFont = mainGame.Content.Load<SpriteFont>("SmallFont");
            isGamePaused = true;
            TDTextures.PopulateTextures(mainGame);
            TDData.PopulateData();
            DataBase.TDWave.PopulateData();
            map.LoadMap();            
            LoadSceneMap loadSceneMap = new LoadSceneMap();
            loadSceneMap.Load(mainGame, map, this);
            gui.LoadContent();
            Rectangle Screen = mainGame.Window.ClientBounds;
            positionWaveTimer = new Vector2(32, 350);
            tileset = mainGame.Content.Load<Texture2D>("GUI/Wooden Pixel Art GUI 32x32");
            sourceRect = new Rectangle(32 * 2, 32 * 27, 32, 32);
            scale = new Vector2(2f, 2f);

            radiusWaveTimer = 0f;
            base.Load();
        }

        public override void UnLoad()
        {            
            base.UnLoad();
        }

        public override void Update(GameTime gameTime)
        {

           
            listButtons.RemoveAll(actor => actor.ToRemove == true);
            listButtons.ForEach(actor => actor.Update(gameTime));
            gui.Update(gameTime);
            if (!isGamePaused)
                TDData.CurrentTimerWave += isGameSpeedUp ?
                     (float)gameTime.ElapsedGameTime.TotalSeconds * 20 :
                     (float)gameTime.ElapsedGameTime.TotalSeconds;
            radiusWaveTimer = (float)Math.PI*TDData.CurrentTimerWave * -2 / TDData.TimerWave;

            List<Tower> towerList = listButtons.Where(button => button.GetType() == typeof(Tower)).Select(button => (Tower)button).ToList();
            towerList.ForEach(tower => tower.RemoveMenu(this, tower, _tower));
            if (!isGamePaused) towerList.ForEach(tower => tower.BuildMenu(this, tower, _tower));
            towerList.ForEach(tower => tower.BuildTowerType(gameTime, this, tower, _tower));

            if (!isGamePaused)
            {
                spriteWeaponFilter
                .UpdateAll(gameTime)
               .EnnemyWithinRangeWeapon(mainGame, this)
               .CooldownShootIsUp(mainGame, this);
                spriteMissileFilter
                    .UpdateAll(gameTime)
                    .FollowTarget()
                    .TimeOutMissile()
                    .OutOfRange()
                    .ImpactCollision(mainGame, this, spriteEnnemyFilter)
                    .CollisionFinished();
                spriteImpactFilter
                    .UpdateAll(gameTime)
                    .ImpactCollision(mainGame, this, spriteEnnemyFilter)
                    .ImpactFinish();
                spriteEnnemyFilter
                    .UpdateAll(gameTime)
                    .UpdateVelocity(this)
                    .ImpactCollision()
                    .RemoveDeadEnnemy()
                    .EnnemyArrived();
                ennemiesWave.Update(mainGame, mainGame._graphics, gameTime, this, isGameSpeedUp);
            }
            map.Update(gameTime);
            lstTilesWater.ForEach(actor => actor.Update(gameTime));
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            
            map.Draw(MainGame.spriteBatch, map.lstTilesGrass);
            lstTilesWater.ForEach(actor => actor.Draw(gameTime));
            map.Draw(MainGame.spriteBatch, map.lstTilesPath);
            map.Draw(MainGame.spriteBatch, map.lstTilesTreesAndStones);
            map.Draw(MainGame.spriteBatch, map.lstTilesSartEnd);
            
            spriteMissileFilter.DrawAll(gameTime);
            spriteImpactFilter.DrawAll(gameTime);
            spriteEnnemyFilter.DrawAll(gameTime);
            map.Draw(MainGame.spriteBatch, map.lstTilesBridges);
            listButtons.ForEach(actor => actor.Draw(gameTime));
            gui.Draw();

            spriteWeaponFilter.DrawAll(gameTime);
            MainGame.spriteBatch.DrawString(SmallFont,
                TDData.LevelAndWave, new Vector2(40, 120), Color.White);
            MainGame.spriteBatch.DrawString(SmallFont,
                TDData.Life.ToString(), new Vector2(60, 38), Color.White);
            MainGame.spriteBatch.DrawString(SmallFont,
              TDData.Gold.ToString(), new Vector2(140, 38), Color.White);
           
            Color color = Color.White;
            Vector2 textureCenter = new Vector2(sourceRect.Width / 2f, sourceRect.Height / 2f);

            for (int i = sourceRect.X; i < sourceRect.X + sourceRect.Width; i++)
            {
                for (int j = sourceRect.Y; j < sourceRect.Y + sourceRect.Height; j++)
                {
                    Vector2 texturePosition = new Vector2(i - sourceRect.X, j - sourceRect.Y);
                    Vector2 positionScaled = positionWaveTimer - (textureCenter * scale);
                    texturePosition *= scale;
                    float cosangle = (float)Math.Cos(radiusWaveTimer);
                    float sinAngle = (float)Math.Sin(radiusWaveTimer);
                    float abscisseX = i - sourceRect.X - sourceRect.Width / 2;
                    float abscisseY = j - sourceRect.Y - sourceRect.Height / 2;
                    float distanceX = abscisseX / (sourceRect.Width / 2);
                    float distanceY = abscisseY / (sourceRect.Height / 2);

                    if (distanceX >= cosangle)// || distanceY  >= sinAngle)
                    //if (distanceY  >= sinAngle && distanceX >= cosangle)// || )
                    {
                        color = Color.White;

                    }
                    else
                    {
                        float alpha = 0.3f;
                        color = new Color(alpha, alpha, alpha);
                    }
                    MainGame.spriteBatch.Draw(tileset, positionScaled + texturePosition, new Rectangle(i, j, 1, 1), color, 0f, Vector2.Zero, scale, SpriteEffects.None, 0f);
                }
            }
           

            base.Draw(gameTime);
        }
    }
}
