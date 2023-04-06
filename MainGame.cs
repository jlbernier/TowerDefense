﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using tower_Defense.Scenes;

namespace tower_Defense
{
    public class MainGame : Game
    {
        public GraphicsDeviceManager _graphics;
        public SpriteBatch _spriteBatch;
        public GameState _gameState;
        public MainGame()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            _graphics.PreferredBackBufferWidth = 1920;
            _graphics.PreferredBackBufferHeight = 1080;
            //_graphics.IsFullScreen = true; // pour le devellopement
            _graphics.ApplyChanges();
            _gameState = new GameState(this);
        }
        protected override void Initialize()
        {
            _gameState.ChangeScene(GameState.SceneType.Introduction);
            base.Initialize();
        }
        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
        }
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            if (_gameState.CurrentScene != null)
            {
                _gameState.CurrentScene.Update(gameTime);
            }
            base.Update(gameTime);
        }
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            _spriteBatch.Begin();
            if (_gameState.CurrentScene != null)
            {               
                _gameState.CurrentScene.Draw(gameTime);
            }
            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}