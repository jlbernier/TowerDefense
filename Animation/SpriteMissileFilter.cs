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
        /*
    public SpriteMissileFilter QteGt(int qte)
    {
        liste = liste.FindAll(tower => tower.qte > qte);
        return this;
    }

    public SpriteMissileFilter QteLt(int qte)
    {
        liste = liste.FindAll(tower => tower.qte < qte);
        return this;
    }

    public SpriteMissileFilter CooldownShootIsUp()
    {
        liste = liste.FindAll(tower => tower.cdTir);
        return this;
    }
    public SpriteMissileFilter Attack()
    {
        liste.ForEach(tower => tower.attack());
        return this;
    }

    public SpriteMissileFilter RestartCooldown()
    {
        liste.ForEach(tower => tower.startCd = true);
        return this;
    }

        */

        public List<SpriteMissile> Build()
        {
            return liste;
        }
    }
}
