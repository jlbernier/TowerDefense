using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tower_Defense.Animation;
using tower_Defense.Scenes;
using tower_Defense.Utils;
using static System.Formats.Asn1.AsnWriter;

namespace tower_Defense.Buttons
{
    public delegate void OnClick(Button pSender);
    public delegate void OnHover(Button pSender);
    public class Button : TDSprite
    {        
        public string buttonID { get; set; }
        public Rectangle boundingBox { get; set; }
        public bool IsHover { get; private set; }
        public bool OldIsHoverState { get; private set; }
        public bool IsClick { get; private set; }
        public bool IsPush { get; set; }
        private MouseState oldMouseState;
        public OnClick OnClick { get; set; }
        public OnHover OnHover { get; set; }

        public Button(Game mainGame, Vector2 position, Vector2 velocity, string buttonID) : base(mainGame, position, velocity, buttonID)
        {            
            this.buttonID = buttonID;
            texture = TDTextures.Textures[TDData.Data[buttonID].NameTexture];
            frameWidth = TDData.Data[buttonID].FrameWidth;
            frameHeight = TDData.Data[buttonID].FrameHeight;                
            scale = TDData.Data[buttonID].Scale;
            Load();
        }        

        public void Load()
        {
            switch (TDData.Data[buttonID].buttonAnimation)
            {
                case TDData.eButtonAnimation.None:
                    LoadNone();
                    break;
                case TDData.eButtonAnimation.UseTileset:
                    LoadTilset();
                    break;
                case TDData.eButtonAnimation.UseFrames:
                    //LoadFrame();
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
       

        public override void Update(GameTime pGameTime)
        {            
            MouseState newMouseState = Mouse.GetState();
            Point MousePos = newMouseState.Position;
            if (boundingBox.Contains(MousePos))
            {
                IsHover = true;
                Debug.WriteLine("Button is over! :" + buttonID);
                if (IsHover != OldIsHoverState)               
                {                   
                    OnHover(this);
                }
                if (newMouseState.LeftButton == ButtonState.Pressed &&
                    oldMouseState.LeftButton == ButtonState.Released)
                {
                    Debug.WriteLine("Button is click!");
                    if (OnClick != null)
                    {
                        IsClick = true;
                        IsPush = !IsPush;
                        OnClick(this);
                        OnHover(this);
                    }                    
                }
            }
            else
            {
                IsHover = false;
                if (IsHover != OldIsHoverState)
                {                    
                    OnHover(this);                    
                }
            }
            IsClick = false;
            OldIsHoverState = IsHover;
            oldMouseState = newMouseState;
            base.Update(pGameTime);
        }

        public override void Draw(GameTime gameTime)
        {            
            base.Draw(gameTime);
        }
    }
}
