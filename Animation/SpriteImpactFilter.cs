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
        public SpriteImpactFilter AddImpact(Game mainGame, SpriteMissile spriteMissile)
        {
            string impactID = "";
            if (spriteMissile.typeMissile == "7")
            {
                impactID = "IMPACTTOWER7LEVEL1";
            }
            else
            {
                impactID = "IMPACTTOWER" + spriteMissile.weaponType + "LEVEL" + spriteMissile.missileLevel.ToString();
            }
            Tools tools = new Tools();
            SpriteMissile spriteImpact = new SpriteMissile(mainGame, spriteMissile.position, new Vector2(0,0), impactID, spriteMissile);
            spriteImpact.AddAnimation(
                "Missile",
                TDData.Data[impactID].ArrayFrames,
                TDData.Data[impactID].FramesDuration,
                TDData.Data[impactID].FrameWidth,
                TDData.Data[impactID].OffsetY,
                TDData.Data[impactID].IsLoop,
                TDData.Data[impactID].InitOffsetX);
            spriteImpact.RunAnimation("Missile");
            liste.Add(spriteImpact);
            return this;
        }

        public SpriteImpactFilter AddImpact8(Game mainGame, SpriteWeapon spriteWeapon)
        {
            
            string impactID = "IMPACTTOWER" + spriteWeapon.weaponType + "LEVEL" + spriteWeapon.weaponLevel.ToString();
            
            Tools tools = new Tools();
            SpriteMissile spriteImpact = new SpriteMissile(mainGame, spriteWeapon.position, new Vector2(0, 0), impactID, spriteWeapon);
            spriteImpact.AddAnimation(
                "Impact8",
                TDData.Data[impactID].ArrayFrames,
                TDData.Data[impactID].FramesDuration,
                TDData.Data[impactID].FrameWidth,
                TDData.Data[impactID].OffsetY,
                TDData.Data[impactID].IsLoop,
                TDData.Data[impactID].InitOffsetX);
            spriteImpact.RunAnimation("Impact8");
            liste.Add(spriteImpact);
            return this;
        }

        public SpriteImpactFilter ImpactCollision(MainGame mainGame, SceneMap pCurrentScene, SpriteEnnemyFilter spriteEnnemyFilter)
        {
            Tools tools = new Tools();
            liste.ForEach(spriteMissile =>
            {
                spriteEnnemyFilter.liste.ForEach(spriteEnnemy =>
                {
                    if (spriteMissile.missileBoundingBox.Intersects(spriteEnnemy.ennemyBoundingBox) &&
                        !spriteMissile.isExploded)
                    {                        
                        spriteEnnemy.HP -= TDData.Data[spriteMissile.impactID].Damages;
                        spriteMissile.isExploded = true;
                    }
                });
            });
            return this;
        }

        public SpriteImpactFilter ImpactFinish()
        {
            liste.RemoveAll(spriteMissile => spriteMissile.currentAnimation.isFinished);
            return this;
        }
    }
}
