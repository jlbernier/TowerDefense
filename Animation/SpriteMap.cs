using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tower_Defense.Map;

namespace tower_Defense.Animation
{
    public class SpriteMap : TDSprite
    {
       public SpriteMap(Game mainGame, Vector2 position, Vector2 velocity, Tile tile) : base(mainGame, position, velocity)
        {
            texture = tile._texture;
            frameWidth = tile.frameWidth;
            frameHeight = tile.frameHeight;
            initOffsetX = tile.initOffsetX;
            offsetX = tile.offsetX;
            offsetY = tile.offsetY;
            isFrame = true;          
            scale = 1f;           
        }
                
        public override void Update(GameTime gameTime)
        {            
            base.Update(gameTime);
        }
    }
}
