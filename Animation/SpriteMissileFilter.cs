using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tower_Defense.Buttons;
using tower_Defense.Utils;
using tower_Defense.Scenes;

namespace tower_Defense.Animation
{
    public class SpriteMissileFilter    {

        public List<SpriteMissile> liste;
        public SpriteMissileFilter()
        {
            this.liste = new();
        }
                        
        public SpriteMissileFilter AddMissile(Game mainGame, string missileID, Vector2 position, Vector2 velocity, int missileLevel, int towerLevel, string towerType)
        {
            Tools tools = new Tools();           
            SpriteMissile spriteMissile = new SpriteMissile(mainGame, position, velocity, missileID, missileLevel, towerLevel, towerType);
            spriteMissile.AddAnimation(
                "Missile",
                TDData.Data[missileID].ArrayFrames,
                TDData.Data[missileID].FramesDuration,
                TDData.Data[missileID].FrameWidth,
                TDData.Data[missileID].OffsetY,
                TDData.Data[missileID].IsLoop,
                TDData.Data[missileID].InitOffsetX);
            spriteMissile.rotation = tools.AngleRadian(velocity);            
            spriteMissile.RunAnimation("Missile");
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

        public SpriteMissileFilter OutOfRange()
        {
            liste.RemoveAll(sprite => sprite.outOfRange);                
            return this;
        }

        public SpriteMissileFilter TimeOutMissile()
        {
            liste.RemoveAll(sprite => sprite.isTimeOutMissile);
            return this;
        }

        public SpriteMissileFilter ImpactCollision(MainGame mainGame, SceneMap pCurrentScene, SpriteEnnemyFilter spriteEnnemyFilter)
        {
            Tools tools = new Tools();
            liste.ForEach(spriteMissile => 
            {
                    spriteEnnemyFilter.liste.ForEach(spriteEnnemy => 
                    {
                        if (spriteMissile.boundingBox.Intersects(spriteEnnemy.boundingBox)) 
                        {
                            spriteEnnemy.HP -= 30; // pour les tests
                            spriteMissile.isCollision = true;
                            pCurrentScene.spriteImpactFilter.AddImpact(mainGame, spriteMissile.missileID,
                                spriteMissile.position, spriteMissile.velocity, spriteMissile.missileLevel,
                                spriteMissile.towerLevel, spriteMissile.weaponType);
                        }                        
                    });                    
            });
            return this;
        }

        public SpriteMissileFilter CollisionFinished()
        {
            liste.RemoveAll(spriteMissile => spriteMissile.isCollision);
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
