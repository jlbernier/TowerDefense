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
        public bool IsHover { get; private set; }
        public bool OldIsHoverState { get; private set; }
        public bool IsClick { get; private set; }
        public bool IsPush { get; set; }
        private MouseState oldMouseState;
        public OnClick OnClick { get; set; }
        public OnHover OnHover { get; set; }

        public Button(Game mainGame, string buttonID, Vector2 position) : base(mainGame, buttonID, position)
        {            
        }
        
        public override void Update(GameTime pGameTime)
        {            
            MouseState newMouseState = Mouse.GetState();
            Point MousePos = newMouseState.Position;
            if (boundingBox.Contains(MousePos))
            {
                IsHover = true;
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

        public override void Draw(SpriteBatch pSpriteBatch)
        {            
            base.Draw(pSpriteBatch);
        }
    }
}
