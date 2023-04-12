﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using tower_Defense.Animation;
using tower_Defense.Utils;

namespace tower_Defense.Buttons
{
    public class BUTTONAnimation
    {
        public string name { get; private set; }
        public int[] frames { get; private set; }
        public float dureeFrame { get; private set; }
        public bool isLoop { get; set; }
        public bool isFinished { get; set; }
        public int initOffsetX { get; private set; }
        public int initOffsetY { get; private set; }

        public int decalageY { get; private set; }
        public BUTTONAnimation(string pName, int[] pFrames, float pTime = 1f / 12f, int pInitOffsetX = 0, int pInitOffsetY = 0, bool pisLoop = true)
        {
            name = pName;
            frames = pFrames;
            dureeFrame = pTime;
            isLoop = pisLoop;
            isFinished = false;
            initOffsetX = pInitOffsetX;
            initOffsetY = pInitOffsetY;   
        }
    }
    public class SpriteButton : IActorButton
    {
        //IActor
        public string buttonID { get; private set; }
        public Vector2 position { get; set; }
        public Rectangle boundingBox { get; set; }
        public Rectangle textureBox { get; set; }
        public TDRectangle textureBoxRect;
        public float velovityX;
        public float velovityY;
        //Sprite
        public float scale { get; set; }
        public float maxScale { get; private set; }
        public float minScale { get; private set; }
        public float stepScale { get; private set; }
        public float timePerAnimation;
        public bool scaleUP;
        public bool isFrame;
        public bool isAnimated;
        public bool isTDRectangle;
        public bool isNone;
        public float rotation { get; set; }

        public Texture2D texture { get; private set; }
        public int offsetTextureX { get; private set; }
        public int offsetTextureY { get; private set; }
        public int widthTexture { get; private set; }
        public int heightTexture { get; private set; }
        public SpriteBatch spriteBatch { get; }
        public List<BUTTONAnimation> animations;
        public BUTTONAnimation animationCourante;
        public int frame { get; private set; }
        public int frameWidth { get; private set; }
        public int frameHeight { get; private set; }
        public float speed { get; set; }
        private float timeAnimation;
        public bool isPaused { get; set; }
        public bool ToRemove { get; set; }
        public Game mainGame;
        static public List<SpriteButton> lstButtonSprites = new List<SpriteButton>();
        public SpriteButton(Game mainGame, string buttonID, Vector2 position)
        {
            this.mainGame = mainGame;
            this.buttonID = buttonID;
            this.position = position;
            rotation = 0;
            scale = TDData.Data[buttonID].Scale;
            texture = TDTextures.Textures[TDData.Data[buttonID].NameTexture];
            switch (TDData.Data[buttonID].buttonAnimation)
            {
                case TDData.eButtonAnimation.None:
                    LoadNone();
                    break;
                case TDData.eButtonAnimation.UseTileset:
                    LoadTilset();
                    break;
                case TDData.eButtonAnimation.UseFrames:
                    LoadFrame();
                    break;
                case TDData.eButtonAnimation.UseAnimated:
                    LoadAnimated();
                    break;
                case TDData.eButtonAnimation.UseTDRectangle:
                    LoadTDRectangle();
                    break;
                default:
                    break;
            }
            boundingBox = new Rectangle(
                (int)(this.position.X - widthTexture / 2),
                (int)(this.position.Y - heightTexture / 2),
                widthTexture,
                heightTexture);
        }

        public void Load()
        {
            scale = TDData.Data[buttonID].Scale;
            texture = TDTextures.Textures[TDData.Data[buttonID].NameTexture];
            switch (TDData.Data[buttonID].buttonAnimation)
            {
                case TDData.eButtonAnimation.None:
                    LoadNone();
                    break;
                case TDData.eButtonAnimation.UseTileset:
                    LoadTilset();
                    break;
                case TDData.eButtonAnimation.UseFrames:
                    LoadFrame();
                    break;
                case TDData.eButtonAnimation.UseAnimated:
                    LoadAnimated();
                    break;
                case TDData.eButtonAnimation.UseTDRectangle:
                    LoadTDRectangle();
                    break;
                default:
                    break;
            }
            boundingBox = new Rectangle(
                (int)(this.position.X - widthTexture / 2),
                (int)(this.position.Y - heightTexture / 2),
                widthTexture,
                heightTexture);
        }

        private void LoadNone()
        {
            isNone = true;
            offsetTextureX = TDData.Data[buttonID].InitOffsetX;
            offsetTextureY = TDData.Data[buttonID].InitOffsetY;
            widthTexture = (int)(TDData.Data[buttonID].FrameWidth * TDData.Data[buttonID].Scale);
            heightTexture = (int)(TDData.Data[buttonID].FrameHeight * TDData.Data[buttonID].Scale);
            textureBox = new Rectangle(
                 offsetTextureX,
                 offsetTextureY,
                 TDData.Data[buttonID].FrameWidth,
                 TDData.Data[buttonID].FrameHeight);
        }

        private void LoadTilset()
        {
            offsetTextureX = TDData.Data[buttonID].InitOffsetX;
            offsetTextureY = TDData.Data[buttonID].InitOffsetY;
            widthTexture = (int)(TDData.Data[buttonID].FrameWidth * TDData.Data[buttonID].Scale);
            heightTexture = (int)(TDData.Data[buttonID].FrameHeight * TDData.Data[buttonID].Scale);
            textureBox = new Rectangle(
                 offsetTextureX,
                 offsetTextureY,
                 TDData.Data[buttonID].FrameWidth,
                 TDData.Data[buttonID].FrameHeight);
        }

        private void LoadFrame()
        {
            frameWidth = TDData.Data[buttonID].FrameWidth;
            frameHeight = TDData.Data[buttonID].FrameHeight;
            offsetTextureX = TDData.Data[buttonID].InitOffsetX;
            offsetTextureY = TDData.Data[buttonID].InitOffsetY;
            widthTexture = TDData.Data[buttonID].FrameWidth;
            heightTexture = TDData.Data[buttonID].FrameHeight;
            textureBox = new Rectangle(
                 TDData.Data[buttonID].InitOffsetX,
                 TDData.Data[buttonID].InitOffsetY,
                 TDData.Data[buttonID].FrameWidth,
                 TDData.Data[buttonID].FrameHeight);
            isFrame = true;
            animations = new List<BUTTONAnimation>();
            lstButtonSprites.Add(this);
           //properties = new Dictionary<string, string>();
            AddAnimation("bouton", TDData.Data[buttonID].ArrayFrames,
            TDData.Data[buttonID].FramesDuration,
            TDData.Data[buttonID].InitOffsetX,
            TDData.Data[buttonID].InitOffsetY,
            TDData.Data[buttonID].IsLoop);
        }

        private void LoadAnimated()
        {
            isAnimated = true;
            scaleUP = true;
            scale = TDData.Data[buttonID].MinScale;
            maxScale = TDData.Data[buttonID].MaxScale;
            minScale = TDData.Data[buttonID].MinScale;
            stepScale = TDData.Data[buttonID].StepScale;
            timePerAnimation = TDData.Data[buttonID].TimePerAnimation;
            offsetTextureX = 0;
            offsetTextureY = 0;
            widthTexture = texture.Width;
            heightTexture = texture.Height;
            textureBox = new Rectangle(0, 0, texture.Width, texture.Height);
        }
        private void LoadTDRectangle()
        {
            isTDRectangle = true;
            offsetTextureX = TDData.Data[buttonID].InitOffsetX;
            offsetTextureY = TDData.Data[buttonID].InitOffsetY;
            widthTexture = (int)(TDData.Data[buttonID].FrameWidth * TDData.Data[buttonID].Scale);
            heightTexture = (int)(TDData.Data[buttonID].FrameHeight * TDData.Data[buttonID].Scale);
            textureBox = new Rectangle(
                 offsetTextureX,
                 offsetTextureY,
                 TDData.Data[buttonID].FrameWidth,
                 TDData.Data[buttonID].FrameHeight);

            textureBoxRect = new TDRectangle(mainGame, TDRectangle.Type.outlineOnly,
              (int)(this.position.X - widthTexture / 2) - 1,
              (int)(this.position.Y - heightTexture / 2) - 1,
              widthTexture + 2,
              heightTexture + 2,
              Color.Black, Color.White);
        }

        static public void DrawAll(SpriteBatch spriteBatch)
        {
            SpriteButton.lstButtonSprites.ForEach(sprite => sprite.Draw(spriteBatch));
        }

        static public void UpdateAll(GameTime pGametime)
        {
            SpriteButton.lstButtonSprites.ForEach(sprite => sprite.Update(pGametime));            
        }       

        public void AddAnimation(string pName, int[] pFrames, float pDureeFrame, int initOffsetX, int initOffsetY, bool pisLoop = true)
        {
            BUTTONAnimation animation = new BUTTONAnimation(pName, pFrames, pDureeFrame, initOffsetX, initOffsetY, pisLoop);
            animations.Add(animation);
            RunAnimation(pName);
        }

        public void RunAnimation(string pName)
        {
            if (isPaused) return;     
            foreach (BUTTONAnimation element in animations)
            {
                if (element.name == pName)
                {
                    animationCourante = element;
                    frame = 0;
                    animationCourante.isFinished = false;
                    break;
                }
            }
            Debug.Assert(animationCourante != null, "LanceAnimation : Aucune animation trouvée");
        }

        public void UpdateScale(GameTime gameTime)
        {
            if (isPaused) return;
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
            if (isPaused) return;
            if (animationCourante == null) return;
            if (animationCourante.dureeFrame == 0) return;
            if (animationCourante.isFinished) return;
            timeAnimation += (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (timeAnimation > animationCourante.dureeFrame)
            {
                textureBox = new Rectangle(animationCourante.frames[frame] * frameWidth,
                offsetTextureY, frameWidth, frameHeight);
                frame++;
                if (frame >= animationCourante.frames.Count())
                {
                    if (animationCourante.isLoop)
                    {
                        frame = 0;
                    }
                    else
                    {
                        frame--;
                        animationCourante.isFinished = true;
                    }
                }
                timeAnimation = 0;
            }
        }

        public virtual void Update(GameTime gameTime)
        {
            if (isPaused) return;
            if (isAnimated) UpdateScale(gameTime);                
            if (isFrame) UpdateFrame(gameTime);
        }
        public virtual void Draw(SpriteBatch spriteBatch)
        {
            Vector2 origine = new Vector2(scale*textureBox.Width/2, scale * textureBox.Height/2);
            if (textureBoxRect != null && isTDRectangle) textureBoxRect.Draw(spriteBatch);
            spriteBatch.Draw(texture, position, textureBox, Color.White, rotation, origine, scale, SpriteEffects.None, 0f);
        }
    }
}
