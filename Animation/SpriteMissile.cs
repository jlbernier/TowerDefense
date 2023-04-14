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
        public string typeMissile { get; set; }
        public bool isCollision { get; set; }
        public bool isExploded {  get; set; }
        public bool isGamePaused { get; set; }

        public bool isCooldownShootUp { get; set; }

        public string missileID {  get; set; }
        
        public SpriteMissile(Game mainGame, Vector2 position, Vector2 velocity, String missileID) : base(mainGame, position, velocity)
        {
            typeMissile = missileID;
            texture = TDTextures.Textures[TDData.Data[missileID].NameTexture];
            frameWidth = TDData.Data[missileID].FrameWidth;
            frameHeight = TDData.Data[missileID].FrameHeight;
            offsetX = TDData.Data[missileID].OffsetX;
            offsetY = TDData.Data[missileID].OffsetY;
            scale = TDData.Data[missileID].Scale;
            isFrame = true;
        }        

        public void GameIsPaused()
        {
            isGamePaused = true;
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
