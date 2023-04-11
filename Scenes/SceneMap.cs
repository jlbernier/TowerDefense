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


namespace tower_Defense.Scenes
{
    public class SceneMap : Scene
    {
        private TDRectangle rectangle;
        // Map
        private readonly TmxMap _map;
        private readonly MapTiled _mapTiled;
        // GamePlay
        private readonly EnnemyGameplay _ennemyGamePlay;
        //public List<SpriteEnnemy> lstSpriteEnnemies;

        // Buttons
        private bool isGamePaused;
        public Button _button;
        public Tower _tower;
        public bool buildTower;
        public bool buildWoodenBox;
        public bool isHoverMenuTower;


        public TDRectangle tdRectangle;
        public List<Tower> lstButtonMenuTower = new List<Tower>();
        public Vector2 positionBaseTower;

        // Ennemies
        private SpriteEnnemy ennemySprite;
        // Missiles
        private SpriteMissile spriteMissile;
        // Textes
        private string LevelAndWave;
        private int level = 1;
        private int wave = 1;
        public bool[] isWavesLaunch = new bool[20];

        //timers
        bool gameIsSpeedUp;
        float timerWaves;
        float timerEnnemies;

        public SceneMap(MainGame pGame) : base(pGame)
        {
            _mapTiled = new MapTiled(mainGame);
            _ennemyGamePlay = new EnnemyGameplay(mainGame);
        }
        public void onHoverDefault(Button pSender) { }
        public void onClickDefault(Button pSender) { }
        public void onClickPlay(Button pSender)
        {
            _ennemyGamePlay.Start(mainGame._spriteBatch, mainGame._graphics);
            pSender.isAnimated = false;
            pSender.ToRemove = true;
            isWavesLaunch[0] = false;
            timerWaves = 0;
            isGamePaused = false;
        }
        public void onHoverSpeedUp(Button pSender)
        {           
            if (isGamePaused) return;

            if (!pSender.IsHover)
            {
                pSender.textureBox = pSender.IsPush ?
                      new Rectangle(ButtonGUI.Data["GAMESPEED"].InitOffsetX + ButtonGUI.Data["GAMESPEED"].OffsetPushX, pSender.textureBox.Y,
                          pSender.textureBox.Width, pSender.textureBox.Height) :
                      new Rectangle(ButtonGUI.Data["GAMESPEED"].InitOffsetX, pSender.textureBox.Y,
                          pSender.textureBox.Width, pSender.textureBox.Height);
            }
            else
            {
                if (pSender.IsClick)
                {
                    pSender.textureBox = pSender.IsPush ?
                       new Rectangle(ButtonGUI.Data["GAMESPEED"].InitOffsetX + ButtonGUI.Data["GAMESPEED"].OffsetPushX, pSender.textureBox.Y,
                          pSender.textureBox.Width, pSender.textureBox.Height) :
                       new Rectangle(ButtonGUI.Data["GAMESPEED"].InitOffsetX, pSender.textureBox.Y,
                          pSender.textureBox.Width, pSender.textureBox.Height);
                }
                else
                {
                    pSender.textureBox = new Rectangle(ButtonGUI.Data["GAMESPEED"].InitOffsetX + ButtonGUI.Data["GAMESPEED"].OffsetSelectedX, pSender.textureBox.Y,
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
                      new Rectangle(ButtonGUI.Data["PAUSE"].InitOffsetX + ButtonGUI.Data["PAUSE"].OffsetPushX, pSender.textureBox.Y,
                          pSender.textureBox.Width, pSender.textureBox.Height) :
                      new Rectangle(ButtonGUI.Data["PAUSE"].InitOffsetX, pSender.textureBox.Y,
                          pSender.textureBox.Width, pSender.textureBox.Height);
            }
            else
            {
                if (pSender.IsClick)
                {
                    pSender.textureBox = pSender.IsPush ?
                       new Rectangle(ButtonGUI.Data["PAUSE"].InitOffsetX + ButtonGUI.Data["PAUSE"].OffsetPushX, pSender.textureBox.Y,
                          pSender.textureBox.Width, pSender.textureBox.Height) :
                       new Rectangle(ButtonGUI.Data["PAUSE"].InitOffsetX, pSender.textureBox.Y,
                          pSender.textureBox.Width, pSender.textureBox.Height);
                }
                else
                {
                    pSender.textureBox = new Rectangle(ButtonGUI.Data["PAUSE"].InitOffsetX + ButtonGUI.Data["PAUSE"].OffsetSelectedX, pSender.textureBox.Y,
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
            if (_tower.IsHover || _tower.lstTower != null)
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
                      new Rectangle(ButtonGUI.Data[pSender.buttonID.ToString()].InitOffsetX + ButtonGUI.Data[pSender.buttonID.ToString()].OffsetPushX, pSender.textureBox.Y,
                          pSender.textureBox.Width, pSender.textureBox.Height) :
                      new Rectangle(ButtonGUI.Data[pSender.buttonID.ToString()].InitOffsetX, pSender.textureBox.Y,
                          pSender.textureBox.Width, pSender.textureBox.Height);
            }
            else
            {
                if (pSender.IsClick)
                {
                    pSender.textureBox = pSender.IsPush ?
                       new Rectangle(ButtonGUI.Data[pSender.buttonID.ToString()].InitOffsetX + ButtonGUI.Data[pSender.buttonID.ToString()].OffsetPushX, pSender.textureBox.Y,
                          pSender.textureBox.Width, pSender.textureBox.Height) :
                       new Rectangle(ButtonGUI.Data[pSender.buttonID.ToString()].InitOffsetX, pSender.textureBox.Y,
                          pSender.textureBox.Width, pSender.textureBox.Height);
                }
                else
                {
                    pSender.textureBox = new Rectangle(ButtonGUI.Data[pSender.buttonID.ToString()].InitOffsetX + ButtonGUI.Data[pSender.buttonID.ToString()].OffsetSelectedX, pSender.textureBox.Y,
                         pSender.textureBox.Width, pSender.textureBox.Height);
                }
            }
        }
     
              




        public override void Load()
        {
            LevelAndWave = "Level: 1 Wave: 1/7";
            isGamePaused = true;
            isWavesLaunch[0] = true;
            GUITextures.PopulateTextures(mainGame);
            ButtonGUI.PopulateData();
            EnnemyTextures.PopulateTextures(mainGame);
            Ennemy.PopulateData();
            Wave.PopulateData();
            _mapTiled.LoadMap();
           _mapTiled.Load(mainGame._spriteBatch);
            
            Rectangle Screen = mainGame.Window.ClientBounds;

           
            foreach (Tile tile in _mapTiled.lstTilesTower)
            {
                Vector2 towerPosition = new Vector2(tile._position.X + 32 , tile._position.Y + 32);
                _tower = new Tower(mainGame, "TOWERTILEMAP", towerPosition);
                _tower.towerNextID = "TOWERTILEMAP";
                _tower.OnClick = onClickDefault;
                _tower.OnHover = onHoverButtonBase;
                listActors.Add(_tower);
            }
            _button = new Button(mainGame, "CHAIN", new Vector2(75, 110));
            _button.OnClick = onClickDefault;
            _button.OnHover = onHoverDefault;
            listActors.Add(_button);
            listActors.Add(_button); _button = new Button(mainGame, "CHAIN", new Vector2(160, 110));
            _button.OnClick = onClickDefault;
            _button.OnHover = onHoverDefault;
            listActors.Add(_button);
            _button = new Button(mainGame, "WOODENLIFE", new Vector2(200, 80));
            _button.OnClick = onClickDefault;
            _button.OnHover = onHoverDefault;
            listActors.Add(_button);
            _button = new Button(mainGame, "WOODENLIFE", new Vector2(200, 160));
            _button.OnClick = onClickDefault;
            _button.OnHover = onHoverDefault;
            listActors.Add(_button);
            _button = new Button(mainGame, "GOLD", new Vector2(110, 45));
            _button.OnClick = onClickDefault;
            _button.OnHover = onHoverDefault;
            listActors.Add(_button);
            _button = new Button(mainGame, "HEART", new Vector2(35, 45));
            _button.OnClick = onClickDefault;
            _button.OnHover = onHoverDefault;
            listActors.Add(_button);
            _button = new Button(mainGame, "PLAY", new Vector2(Screen.Width / 2 , Screen.Height / 2 ));
            _button.OnClick = onClickPlay;
            _button.OnHover = onHoverDefault;
            listActors.Add(_button);
            _button = new Button(mainGame, "PAUSE",
                new Vector2(Screen.Width - 100, 100));
            _button.OnClick = onClickPause;
            _button.OnHover = onHoverThreeStates;
            listActors.Add(_button);
            _button = new Button(mainGame, "GAMESPEED",
                new Vector2(Screen.Width - 100, 160));           
            _button.OnClick = onClickSpeedUp;
            _button.OnHover = onHoverThreeStates;
            int offset = 0;
            for (int i = 1; i < 9; i++)
            {
                for (int j = 1; j < 4; j++)
                {
                    if (i == 8) continue;
                    if (i == 7)
                    {
                        spriteMissile = SpriteMissile.AddMissile(mainGame, mainGame._spriteBatch,
                         "MISSILETOWER7LEVELX",
              new Vector2(100 + offset, 1000), new Vector2(0, -15));
                    }
                    else
                    {
                        spriteMissile = SpriteMissile.AddMissile(mainGame, mainGame._spriteBatch,
                         "MISSILETOWER" + i.ToString() + "LEVEL" + j.ToString(),
              new Vector2(100 + offset, 1000), new Vector2(0, -15));
                    }
                    offset += 40;
                }
            }
           



            listActors.Add(_button);
            base.Load();
        }

        public override void UnLoad()
        {            
            base.UnLoad();
        }

        public override void Update(GameTime gameTime)
        {
            List<Tower> towerList = listActors.Where(button => button.GetType() == typeof(Tower)).Select(button => (Tower)button).ToList();
            towerList.ForEach(tower => tower.BuildTowerType(this, gameTime, tower, _tower));
            if (!isGamePaused) towerList.ForEach(tower => tower.BuildMenuChooseTower(this,  tower, _tower));
            towerList.ForEach(tower => tower.BuildMenuToRemove(this, tower, _tower));   

            timerWaves += gameIsSpeedUp ?
               (float)gameTime.ElapsedGameTime.TotalSeconds * 20 :
               (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (timerWaves > 60f && !isWavesLaunch[0])
            {
                wave += 1;
                LevelAndWave = "Level: 1 Wave: " + wave + "/7";
                _ennemyGamePlay.Start(mainGame._spriteBatch, mainGame._graphics, gameIsSpeedUp, 1, 2);
                timerWaves = 0;
                if (wave == 7) isWavesLaunch[0] = true;
            }

            towerList.ForEach(tower => tower.BuildTowerType(this, gameTime, tower, _tower));
            timerEnnemies += (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (timerEnnemies > 2)
            {
                foreach (var ennemy in SpriteEnnemy.lstEnnemy)
                {
                    if (ennemy.spriteX > 400) ennemy.IsAttack(10);
                    if (ennemy._HP <= 0) ennemy.ToRemove = true;
                }
                timerEnnemies = 0;


            }
            SpriteEnnemy.lstEnnemy.RemoveAll(ennemy => ennemy._HP <= 0);
            TDSprite.lstSprites.RemoveAll(ennemy => ennemy.ToRemove);            
            _mapTiled.Update(gameTime);
            TDSprite.UpdateAll(gameTime);
            SpriteButton.UpdateAll(gameTime);
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            _mapTiled.Draw(mainGame._spriteBatch);
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
