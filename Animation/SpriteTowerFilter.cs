using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tower_Defense.Buttons;
using tower_Defense.Scenes;

namespace tower_Defense.Animation
{
    public class SpriteTowerFilter
    {  
        public List<Tower> liste;
        public SpriteTowerFilter()
        {
            this.liste = new();
        }



        public SpriteTowerFilter AddTower(Game mainGame, String towerID, Tower weaponTower, SceneMap currentScene)
        {
            Tower tower = new Tower(mainGame, weaponTower.position, new Vector2(0, 0), towerID);
            liste.Add(tower);
            return this;
        }

        public SpriteTowerFilter UpdateAll(GameTime pGametime)
        {
            liste.ForEach(sprite => sprite.Update(pGametime));
            return this;
        }
        public SpriteTowerFilter DrawAll(GameTime pGametime)
        {
            liste.ForEach(sprite => sprite.Draw(pGametime));
            return this;
        }


        public SpriteTowerFilter CooldownShootIsUp()
        {
            liste = liste.FindAll(spriteTower => spriteTower.isCooldownShootUp);
            return this;
        }

    }
}
