using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tower_Defense.Buttons;

namespace tower_Defense.Animation
{
    public class SpriteMissileFilter    {

        public List<SpriteMissile> liste;
        public SpriteMissileFilter()
        {
            this.liste = new();
        }

        public SpriteMissileFilter AddMissile(Game mainGame, SpriteBatch spriteBatch, string missileID, Vector2 position, Vector2 velocity)
        {
            SpriteMissile spriteMissile = new SpriteMissile(mainGame, spriteBatch, missileID, position,velocity);
            spriteMissile.AddAnimation(
                "Run",
                TDData.Data[missileID].ArrayFrames,
                TDData.Data[missileID].FramesDuration,
                TDData.Data[missileID].OffsetX,
                TDData.Data[missileID].OffsetY,
                TDData.Data[missileID].IsLoop,
                TDData.Data[missileID].InitOffsetX);
            spriteMissile.RunAnimation("Run");
            liste.Add(spriteMissile);
            
            return this;
        }

        public SpriteMissileFilter NameContain(string name)
        {
            liste = liste.FindAll(spriteMissile => spriteMissile.missileID.Contains(name));
            return this;
        }

        public SpriteMissileFilter UpdateAll(GameTime pGametime)
        {
            liste.ForEach(sprite => sprite.Update(pGametime));
            return this;
        }
        public SpriteMissileFilter DrawAll(GameTime pGametime)
        {
            liste.ForEach(sprite => sprite.Draw(pGametime));
            return this;
        }


        public SpriteMissileFilter ImpactCollision()
        {
            liste = liste.FindAll(spriteMissile => spriteMissile.isCollision);
            return this;
        }

        public SpriteMissileFilter CollisionFinished()
        {
            liste = liste.FindAll(spriteMissile => spriteMissile.isExploded);
            return this;
        }
        
        public SpriteMissileFilter CooldownShootIsUp()
        {
            liste = liste.FindAll(spriteMissile => spriteMissile.isCooldownShootUp);
            return this;
        }
        public SpriteMissileFilter GameIsPaused()
        {
            liste.ForEach(spriteMissile => spriteMissile.GameIsPaused());
            return this;
        }

        public List<SpriteMissile> Build()
        {
            return liste;
        }
    }
}
