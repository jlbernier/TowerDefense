using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tower_Defense.Buttons;

namespace tower_Defense.Animation
{
    public class SpriteMissileFilter
    {
        public List<SpriteMissile> liste;
        public SpriteMissileFilter(List<SpriteMissile> listeMissiles)
        {
            this.liste = listeMissiles;
        }

        public SpriteMissileFilter NameContain(string name)
        {
            liste = liste.FindAll(spriteMissile => spriteMissile.missileID.Contains(name));
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
