﻿using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tower_Defense.Animation
{
    public class SpriteEnnemyFilter
    {
        public List<SpriteEnnemy> liste;
        public List<SpriteEnnemy> filtredListe;


        public SpriteEnnemyFilter()
        {
            this.liste = new();
            filtredListe = new();
        }
        public SpriteEnnemyFilter AddEnnemy(Game mainGame, SpriteBatch spriteBatch, string ennemyID, Vector2 position, Vector2 velocity)
        {
            SpriteEnnemy spriteEnnemy = new SpriteEnnemy(mainGame, spriteBatch, ennemyID, position, velocity);
            if (spriteEnnemy.velocity.X > 0) spriteEnnemy.IsMirrored = !spriteEnnemy.IsMirrored;
            spriteEnnemy.AddAnimation(
                "Run",
                TDData.Data[ennemyID].ArrayFrames,
                TDData.Data[ennemyID].FramesDuration,
                TDData.Data[ennemyID].OffsetX,
                TDData.Data[ennemyID].OffsetY,
                TDData.Data[ennemyID].IsLoop,
                TDData.Data[ennemyID].InitOffsetX);
            spriteEnnemy.RunAnimation("Run");
            liste.Add(spriteEnnemy);
            return this;
        }
        public SpriteEnnemyFilter ImpactCollision()
        {
            liste.ForEach(spriteEnnemy => {
                if (spriteEnnemy.position.X > 400)
                    spriteEnnemy.HP -= 10;
                if (spriteEnnemy.HP <= 0)
                    spriteEnnemy.ToRemove = true;
            });
            return this;
        }

        public SpriteEnnemyFilter RemoveDeadEnnemy()
        {
            liste.RemoveAll(spriteEnnemy => spriteEnnemy.HP <= 0);
            return this;
        }

    }
}
