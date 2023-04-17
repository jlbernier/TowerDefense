using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tower_Defense.Utils;

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
        public int offsetY { get; private set; }
        public int initOffsetX { get; private set; }
        public int initOffsetY { get; private set; }
        public TDAnimation(string name, int[] frames, float frameDuration, int offsetX, int offsetY, bool isLoop = true, int initOffsetX = 0, int initOffsetY = 0)
        {
            this.name = name;
            this.ArrayFrames = frames;
            this.frameDuration = frameDuration;
            this.isLoop = isLoop;
            this.isFinished = false;
            this.offsetX = offsetX;
            this.offsetY = offsetY;
            this.initOffsetX = initOffsetX;
            this.initOffsetY = initOffsetY;
        }
    }
    public abstract class TDSprite
    {
        public Game mainGame;
        public string ID;
        public Vector2 position { get; set; }
        public bool ToRemove { get; set; }
        public Vector2 velocity { get; set; }  
        public bool isSpeedUp;
        public bool isPaused;
        public bool isVisible { get; set; }
        public bool isCentered { get; set; }
        public float scale { get; set; }
        public float rotation { get; set; }
        public Texture2D texture { get; set; }
        public List<TDAnimation> animations;
        public TDAnimation currentAnimation;
        protected SpriteEffects effect;
        public int frame { get;  set; }
        public int frameWidth { get;   protected set; }
        public int frameHeight { get;  set; }
        private float time;       
        public bool isFrame;

        public int offsetTextureX { get;  set; }
        public int offsetTextureY { get;  set; }
        public int widthTexture { get;  set; }
        public int heightTexture { get;  set; }
        public Rectangle textureBox { get; set; }
        public TDRectangle textureBoxRect;
        public float timePerAnimation;
        private float timeAnimation;
        public float maxScale { get; set; }
        public float minScale { get; set; }
        public float stepScale { get; set; }
        public bool scaleUP;
        public bool isAnimated;
        public bool isTDRectangle;
        public bool isNone;

        static public List<TDSprite> lstSprites = new();
             
        public TDSprite(Game mainGame, Vector2 position, Vector2 velocity, String spriteID)
        {
            this.mainGame = mainGame;
            this.ID = spriteID;
            this.position = position;
            this.velocity = velocity;  
            this.isVisible = true;
            this.isCentered = true;            
            this.effect = SpriteEffects.None;
            this.animations = new List<TDAnimation>();
            lstSprites.Add(this);
        }
        static public void UpdateAll(GameTime pGametime)
        {
            TDSprite.lstSprites.ForEach(sprite => sprite.Update(pGametime));
        }
        static public void DrawAll(GameTime pGametime)
        {
            TDSprite.lstSprites.ForEach(sprite => sprite.Draw(pGametime));           
        }


        public void AddAnimation(string name, int[] arrayFrames, float FramesDuration, int offsetX, int offsetY, bool isLoop = true, int initOffsetX = 0, int initOffsetY =0)
        {
            TDAnimation animation = new TDAnimation(name, arrayFrames, FramesDuration, offsetX, offsetY, isLoop, initOffsetX, initOffsetY);
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
        }

        public void UpdateScale(GameTime gameTime)
        {
            timeAnimation += (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (timeAnimation > timePerAnimation)
            {
                if (scaleUP)
                {
                    scale += stepScale;
                    if (scale > maxScale) scaleUP = false;
                }
                else
                {
                    scale -= stepScale;
                    if (scale < minScale) scaleUP = true;
                }
                timeAnimation = 0;
            }
        }
        
        public void UpdateFrame(GameTime gameTime)
        {
            position = new Vector2(position.X + velocity.X * (float)gameTime.ElapsedGameTime.TotalSeconds,
                                   position.Y + velocity.Y * (float)gameTime.ElapsedGameTime.TotalSeconds);
            if (currentAnimation == null) return;
            if (currentAnimation.frameDuration == 0) return;
            if (currentAnimation.isFinished) return;
            time += (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (time > currentAnimation.frameDuration)
            {
                textureBox = new Rectangle(
                    currentAnimation.initOffsetX + (currentAnimation.ArrayFrames[frame]) * currentAnimation.offsetX,
                    currentAnimation.initOffsetY, 
                    frameWidth, 
                    frameHeight);
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
        public virtual void Update(GameTime gameTime)
        {
            //if (isPaused) return;
            if (isAnimated) UpdateScale(gameTime);
            if (isFrame) UpdateFrame(gameTime);
        }
        public virtual void Draw(GameTime gameTime)
        {
            if (!isVisible) return;

            Vector2 origine = new Vector2(scale * this.textureBox.Width / 2, scale * textureBox.Height / 2);
            if (textureBoxRect != null && isTDRectangle) textureBoxRect.Draw(MainGame.spriteBatch);            
            MainGame.spriteBatch.Draw(texture, position, textureBox, Color.White, rotation, origine, scale, effect, 0f);
        }
    }
}
