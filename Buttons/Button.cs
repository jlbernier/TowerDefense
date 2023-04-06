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
    public class Button : SpriteButton
    {
        private float timer;
        public float scale;
        private bool scaleUP;

        public bool isHover { get; private set; }
        public bool oldIsHoverState { get; private set; }
        public bool isClick { get; private set; }
        public bool isPush { get; set; }
        public bool isAnimated { get; set; }
        private MouseState oldMouseState;
        public OnClick onClick { get; set; }
        public OnHover onHover { get; set; }

        public Button(string buttonID, Vector2 position) : base(buttonID, position)
        {
            
        }
        public void LoadAnimation(Texture2D texture)
        {
            isAnimated = true;
            scale = 0.95f;
            scaleUP = true;
            timer = 0;
        }
        public override void Update(GameTime pGameTime)
        {
            if (isAnimated)
            {
                timer += (float)pGameTime.ElapsedGameTime.TotalSeconds;
                if (timer > 0.05f)
                {
                    if (scaleUP)
                    {
                        scale += 0.01f;
                        if (scale > 1.05f)
                        {
                            scaleUP = false;
                        }
                    }
                    else
                    {
                        scale -= 0.01f;
                        if (scale < 0.95f)
                        {
                            scaleUP = true;
                        }
                    }
                    timer = 0;
                }                
            }
            MouseState newMouseState = Mouse.GetState();
            Point MousePos = newMouseState.Position;
            if (BoundingBox.Contains(MousePos))
            {
                isHover = true;
                if (isHover != oldIsHoverState)               
                {                   
                    onHover(this);
                }
                if (newMouseState.LeftButton == ButtonState.Pressed &&
                    oldMouseState.LeftButton == ButtonState.Released)
                {
                    Debug.WriteLine("Button is click!");
                    if (onClick != null)
                    {
                        isClick = true;
                        onClick(this);
                        isPush = !isPush;
                        onHover(this);
                    }                    
                }
            }
            else
            {
                isHover = false;
                if (isHover != oldIsHoverState)
                {                    
                    onHover(this);                    
                }
            }
            isClick = false;
            oldIsHoverState = isHover;
            oldMouseState = newMouseState;
            base.Update(pGameTime);
        }

        public override void Draw(SpriteBatch pSpriteBatch)
        {
            
            if (isAnimated)
            {
                pSpriteBatch.Draw(texture, Position, TextureBox, Color.White, 0f, new Vector2(0,0), scale, SpriteEffects.None, 0);
            }
            else 
            {
                base.Draw(pSpriteBatch);
            }
        }

    }
}
