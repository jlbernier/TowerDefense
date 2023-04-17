using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tower_Defense.Scenes;
using tower_Defense.Utils;

namespace tower_Defense.Animation
{
    public class SpriteImpactFilter
    {
        public List<SpriteMissile> liste;
        public SpriteImpactFilter()
        {
            this.liste = new();
        }
        public SpriteImpactFilter UpdateAll(GameTime pGametime)
        {
            liste.ForEach(sprite => sprite.Update(pGametime));
            return this;
        }
        public SpriteImpactFilter DrawAll(GameTime pGametime)
        {
            liste.ForEach(sprite => sprite.Draw(pGametime));
            return this;
        }
        public SpriteImpactFilter AddImpact(Game mainGame, string missileID, Vector2 position, Vector2 velocity, int missileLevel, int towerLevel, string weaponType)
        {
            string impactID = "";
            if (weaponType == "7")
            {
                impactID = "IMPACTTOWER7LEVEL1";
            }
            else
            {
                impactID = "IMPACTTOWER" + weaponType + "LEVEL" + missileLevel.ToString();
            }
            Tools tools = new Tools();
            SpriteMissile spriteMissile = new SpriteMissile(mainGame, position, velocity, impactID, missileLevel, towerLevel, weaponType);
            spriteMissile.AddAnimation(
                "Missile",
                TDData.Data[impactID].ArrayFrames,
                TDData.Data[impactID].FramesDuration,
                TDData.Data[impactID].FrameWidth,
                TDData.Data[impactID].OffsetY,
                TDData.Data[impactID].IsLoop,
                TDData.Data[impactID].InitOffsetX);
            //spriteMissile.rotation = tools.AngleRadian(velocity);
            spriteMissile.RunAnimation("Missile");
            liste.Add(spriteMissile);
            return this;
        }
        public SpriteImpactFilter ImpactFinish()
        {
            liste.RemoveAll(spriteMissile => spriteMissile.currentAnimation.isFinished);
            return this;
        }
    }
}
