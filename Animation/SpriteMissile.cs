using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tower_Defense.Utils;
using tower_Defense.Buttons;
using Microsoft.Xna.Framework.Input;

namespace tower_Defense.Animation
{
    public class SpriteMissile : TDSprite
    {
        private static SpriteMissile sprMissile;
        public string typeMissile { get; set; }

        private bool isExploded {  get; set; }
        public string missileID {  get; set; }
        
        static public List<SpriteMissile> lstMissiles = new();
        public SpriteMissile(Game pGame, SpriteBatch pSpriteBatch, Texture2D pTexture, int pFrameWidth, int pFrameHeight, int pDecalageX, int pDecalageY, Vector2 pVelocity, int pInitDecalageX = 0) : base(pGame, pSpriteBatch, pTexture, pFrameWidth, pFrameHeight, pDecalageX, pDecalageY, pVelocity, pInitDecalageX = 0)
        {
            lstMissiles.Add(this);
        }

        public static SpriteMissile AddMissile(Game mainGame, SpriteBatch spriteBatch, string missileID, Vector2 position, Vector2 velocity)
        {
            sprMissile = new SpriteMissile(mainGame, spriteBatch, GUITextures.Textures[ButtonGUI.Data[missileID].NameTexture],
                ButtonGUI.Data[missileID].FrameWidth, ButtonGUI.Data[missileID].FrameHeight, ButtonGUI.Data[missileID].OffsetX,
                ButtonGUI.Data[missileID].OffsetY, velocity);
            sprMissile.spriteX = position.X;
            sprMissile.spriteY = position.Y;
            sprMissile.velocity = velocity;

            sprMissile.AjouteAnimation("run",
                    ButtonGUI.Data[missileID].ButtonFrames,
                    ButtonGUI.Data[missileID].ButtonFramesLenght,
                    ButtonGUI.Data[missileID].OffsetX,
                    ButtonGUI.Data[missileID].OffsetY,
                    ButtonGUI.Data[missileID].IsLoop);
            sprMissile.spriteX = position.X;
            sprMissile.spriteY = position.Y;
            sprMissile.velocity = velocity;
            sprMissile.LanceAnimation("run");
            return sprMissile;
        }


        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {           
            base.Draw(gameTime);
        }
    }
}
