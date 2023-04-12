using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tower_Defense.Animation
{   
    public class TDAnimation
    {
        public string name { get; private set; }
        public int[] ArrayFrames { get; private set; }
        public float frameDuration { get; private set; }
        public bool isLoop { get; set; }
        public bool isFinished { get; set; }
        public int offsetX { get; private set; }
        public int initOffsetX { get; private set; }
        public int offsetY { get; private set; }
        public TDAnimation(string name, int[] frames, float frameDuration = 1f / 12f, int offsetX = 0, int offsetY = 0, bool isLoop = true, int initOffsetX = 0)
        {
            this.name = name;
            this.ArrayFrames = frames;
            this.frameDuration = frameDuration;
            this.isLoop = isLoop;
            this.isFinished = false;
            this.offsetX = offsetX;
            this.offsetY = offsetY;
            this.initOffsetX = initOffsetX;
        }
    }
    public class TDSprite
    {
        public Vector2 position { get; set; }
        public Vector2 velocity { get; set; }  
        public bool isSpeedUp;
        public bool isPaused;
        public bool isVisible { get; set; }
        public bool isCentered { get; set; }
        public float zoom { get; set; }
        public float rotation { get; set; }
        public SpriteBatch spriteBatch { get; set; }
        public Texture2D texture { get; set; }
        public List<TDAnimation> animations;
        public TDAnimation currentAnimation;
        protected SpriteEffects effect;
        public int frame { get;  set; }
        public int frameWidth { get;  set; }
        public int frameHeight { get;  set; }
        public float speed { get; set; }
        private float time;
        public int offsetX;
        public int offsetY;
        public int initOffsetX;
        static public List<TDSprite> lstSprites = new();
        public bool ToRemove { get; set; }
        public Game mainGame;
             
        public TDSprite(Game mainGame, SpriteBatch spriteBatch, String missileID, Vector2 position, Vector2 velocity)
        {
            this.mainGame = mainGame;
            this.spriteBatch = spriteBatch;           
            this.isVisible = true;
            this.isCentered = true;            
            this.zoom = 1.0f;
            this.speed = 60.0f;
            this.effect = SpriteEffects.None;
            this.animations = new List<TDAnimation>();
            lstSprites.Add(this);
            this.velocity = velocity;            
        }
        static public void UpdateAll(GameTime pGametime)
        {
            TDSprite.lstSprites.ForEach(sprite => sprite.Update(pGametime));
        }
        static public void DrawAll(GameTime pGametime)
        {
            TDSprite.lstSprites.ForEach(sprite => sprite.Draw(pGametime));           
        }


        public void AddAnimation(string name, int[] arrayFrames, float FramesDuration, int offsetX, int offsetY, bool isLoop = true, int initOffsetX = 0)
        {
            TDAnimation animation = new TDAnimation(name, arrayFrames, FramesDuration, offsetX, offsetY, isLoop, initOffsetX);
            animations.Add(animation);
        }

        public void RunAnimation(string pName)
        {
            foreach (TDAnimation element in animations)
            {
                if (element.name == pName)
                {
                    currentAnimation = element;
                    frame = 0;
                    currentAnimation.isFinished = false;
                    break;
                }
            }
            Debug.Assert(currentAnimation != null, "RunAnimation : No animation find");
        }

        public virtual void Update(GameTime gameTime)
        {               
            if (isPaused) return;
            position = new Vector2(position.X + velocity.X * (float)gameTime.ElapsedGameTime.TotalSeconds,
                                   position.Y + velocity.Y * (float)gameTime.ElapsedGameTime.TotalSeconds);                    
                                     
            if (currentAnimation == null) return;
            if (currentAnimation.frameDuration == 0) return;
            if (currentAnimation.isFinished) return;
            time += (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (time > currentAnimation.frameDuration)
            {
                frame++;
                if (frame >= currentAnimation.ArrayFrames.Count())
                {
                    if (currentAnimation.isLoop)
                    {
                        frame = 0;
                    }
                    else
                    {
                        frame--;
                        currentAnimation.isFinished = true;
                    }
                }
                time = 0;
            }
        }

        public virtual void Draw(GameTime gameTime)
        {
            if (!isVisible) return;            
                int Offset = frameWidth;
                Rectangle source = new Rectangle(0, 0, 0, 0);
            if (currentAnimation.offsetX > 0)
            {
                Offset = currentAnimation.ArrayFrames[frame] * currentAnimation.offsetX;
                source = new Rectangle(currentAnimation.initOffsetX + Offset,
                 currentAnimation.offsetY, frameWidth, frameHeight);
            }
            else
            {
                source = new Rectangle(currentAnimation.ArrayFrames[frame] * frameWidth,
                  currentAnimation.offsetY, frameWidth, frameHeight);
            }
            
            Vector2 origine = new Vector2(0, 0);
            if (isCentered)
            {
                origine = new Vector2(frameWidth / 2, frameHeight / 2);
            }            
            spriteBatch.Draw(texture, position, source, Color.White, rotation, origine, zoom, effect, 0.0f);
        }
    }
}
