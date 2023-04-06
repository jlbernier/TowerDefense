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


namespace tower_Defense.Scenes
{
    internal class SceneMap : Scene
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
        private Button _button;
        private Button _buttonTower;

        private int indexButton;
        public bool buttonToRemove;
        public bool ennemyToRemove;

        public TDRectangle tdRectangle;
        public bool buildTower;
        public bool buildTowerBis;
        public bool buildTower1;

        // Ennemies
        private SpriteEnnemy ennemySprite;
        private TDSprite ennemyTDSprite;

        // Textes
        private string LevelAndWave;
        private int level = 1;
        private int wave = 1;
        public bool[] isWavesLaunch = new bool[20];

        //timers
        bool gameIsSpeedUp;
        float timerWaves;
        float timer;

        public SceneMap(MainGame pGame) : base(pGame)
        {
            _mapTiled = new MapTiled(mainGame);
            _ennemyGamePlay = new EnnemyGameplay(mainGame);
        }
        public void onClickPlay(Button pSender)
        {
            _ennemyGamePlay.Start(mainGame._spriteBatch, mainGame._graphics);
            pSender.isAnimated = false;
            _button = pSender;
            buttonToRemove = true;
            isWavesLaunch[0] = false;
            timerWaves = 0;
            isGamePaused = false;
        }
        public void onHoverPlay(Button pSender) {}

        public void onClickSpeedUp(Button pSender)
        {
            if (isGamePaused) return;
            foreach (var sprite in TDSprite.lstSprites)
            {
                sprite.isSpeedUp = !pSender.isPush;
            }
            gameIsSpeedUp = !pSender.isPush;
        }

        public void onHoverSpeedUp(Button pSender)
        {           
            if (isGamePaused) return;
            if (!pSender.isHover)
            {
                pSender.TextureBox = pSender.isPush ?
                      new Rectangle(ButtonGUI.Data["GAMESPEED"].InitOffsetX + ButtonGUI.Data["GAMESPEED"].OffsetPushX, pSender.TextureBox.Y,
                          pSender.TextureBox.Width, pSender.TextureBox.Height) :
                      new Rectangle(ButtonGUI.Data["GAMESPEED"].InitOffsetX, pSender.TextureBox.Y,
                          pSender.TextureBox.Width, pSender.TextureBox.Height);
            }
            else
            {
                if (pSender.isClick)
                {
                    pSender.TextureBox = pSender.isPush ?
                       new Rectangle(ButtonGUI.Data["GAMESPEED"].InitOffsetX + ButtonGUI.Data["GAMESPEED"].OffsetPushX, pSender.TextureBox.Y,
                          pSender.TextureBox.Width, pSender.TextureBox.Height) :
                       new Rectangle(ButtonGUI.Data["GAMESPEED"].InitOffsetX, pSender.TextureBox.Y,
                          pSender.TextureBox.Width, pSender.TextureBox.Height);
                }
                else
                {
                    pSender.TextureBox = new Rectangle(ButtonGUI.Data["GAMESPEED"].InitOffsetX + ButtonGUI.Data["GAMESPEED"].OffsetSelectedX, pSender.TextureBox.Y,
                         pSender.TextureBox.Width, pSender.TextureBox.Height);
                }
            }
        }




        public void onClickTOWERCONSTRUCTION1(Button pSender)
        {
            
        }

        public void onHoverTOWERCONSTRUCTION1(Button pSender)
        {
            
        }

        public void onClickButtonBase(Button pSender)
        {
            if (isGamePaused) return;
            _button = pSender;
            buttonToRemove = true;
            buildTower = true;           
        }

        public void onHoverButtonBase(Button pSender)
        {
           
        }

        public override void Load()
        {
            LevelAndWave = "Level: 1 Wave: 1/5";
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

            _button = new Button("BUTTON1",
               new Vector2(700, 100));

            _button.onClick = onClickButtonBase;
            _button.onHover = onHoverButtonBase;
            listActors.Add(_button);

            _button = new Button("PLAY", new Vector2(Screen.Width / 2 - 100, Screen.Height / 2 - 25) );
            _button.LoadAnimation(_button.texture);
            _button.onClick = onClickPlay;
            _button.onHover = onHoverPlay;
            listActors.Add(_button);
            
           
            _button = new Button("GAMESPEED",
                new Vector2(200, (Screen.Height - 1000)));           
            _button.onClick = onClickSpeedUp;
            _button.onHover = onHoverSpeedUp;
            listActors.Add(_button);       


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

            if (timerWaves > 60f && !isWavesLaunch[0])
            {
                wave += 1;
                LevelAndWave = "Level: 1 Wave: " + wave + "/5";
                _ennemyGamePlay.Start(mainGame._spriteBatch, mainGame._graphics, 1, 2);
                timerWaves = 0;
                if (wave == 5) isWavesLaunch[0] = true;
            }


            if (buttonToRemove)
            {
                _button.isAnimated = false;
                listActors.Remove(_button);
                buttonToRemove = false;
            }
            if (buildTower)
            { 
                _button = new Button("TOWERCONSTRUCTION1", _button.Position);
                _button.onClick = onClickTOWERCONSTRUCTION1;
                _button.onHover = onHoverTOWERCONSTRUCTION1;                
                listActors.Add(_button);                
                indexButton = listActors.Count();
                timer = 0;
                buildTower = false;
                buildTowerBis = true;
            }
            timer += (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (timer > 1.5f && buildTowerBis)
            {
                foreach (var button in listActors)
                {
                    if (button.ButtonID == "TOWERCONSTRUCTION1") _button = (Button)button;
                }                
                    if (_button.ButtonID == "TOWERCONSTRUCTION1")
                    {
                        listActors.Remove(_button);
                        _button = new Button("TOWERCONSTRUCTION1BIS",
                     _button.Position);
                        _button.onClick = onClickTOWERCONSTRUCTION1;
                        _button.onHover = onHoverTOWERCONSTRUCTION1;
                        listActors.Add(_button);
                        buildTower1 = true;
                        timer = 0;
                        buildTowerBis = false;
                    }
            }
            if (timer > 1.5f && buildTower1)
            {
                if (_button.ButtonID == "TOWERCONSTRUCTION1BIS")
                {
                    _button.animations.Clear();
                    listActors.Remove(_button);
                    _button = new Button("TOWER11",
               new Vector2(_button.Position.X+64, _button.Position.Y + 64));
                    _button.onClick = onClickTOWERCONSTRUCTION1;
                    _button.onHover = onHoverTOWERCONSTRUCTION1;
                    listActors.Add(_button);

                    _button = new Button("WEAPONTOWER1LEVEL1",
                new Vector2(_button.Position.X -16, _button.Position.Y));
                    _button.onClick = onClickTOWERCONSTRUCTION1;
                    _button.onHover = onHoverTOWERCONSTRUCTION1;
                    listActors.Add(_button);
                    buildTower1 = false;
                    
                }
            }
                MouseState newMouseState = Mouse.GetState();
            if (newMouseState.LeftButton == ButtonState.Pressed)
            {
                //_ennemyGamePlay.Start(mainGame._spriteBatch, mainGame._graphics);
            }
            // tests
            foreach (var ennemy in SpriteEnnemy.lstEnnemy)
            {
                if (ennemy.spriteX > 300)
                {
                    ennemy.IsAttack(30);
                }
                if (ennemy._HP <= 0)
                {
                    ennemySprite = ennemy;
                    ennemyToRemove = true;
                }
            }
            if (ennemyToRemove)
            {
                SpriteEnnemy.lstEnnemy.Remove(ennemySprite);
                TDSprite.lstSprites.Remove(ennemySprite);

            }
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
            mainGame._spriteBatch.DrawString(spriteFont: base.myFont,
                LevelAndWave, new Vector2(880, 40), Color.Brown);
            base.Draw(gameTime);
        }
    }
}
