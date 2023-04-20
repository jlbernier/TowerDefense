﻿using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static tower_Defense.TDData;
using tower_Defense.Scenes;
using static tower_Defense.DataBase.TDWave;

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
        public SpriteEnnemyFilter AddEnnemy(Game mainGame, SceneMap currentScene, string ennemyID)
        {
            Vector2 position =new Vector2();
            for (int line = 0; line < currentScene._mapTiled.arrayPath.GetLength(0); line++)
            {
                for (int column = 0; column < currentScene._mapTiled.arrayPath.GetLength(1); column++)
                {
                    if (currentScene._mapTiled.arrayPath[line, column] == 837)
                    {
                        position = new Vector2(line * TDData.Data[ennemyID].FrameWidth + TDData.Data[ennemyID].FrameWidth/2,
                            column * TDData.Data[ennemyID].FrameHeight + TDData.Data[ennemyID].FrameHeight/2);
                    }
                }
            }
            SpriteEnnemy spriteEnnemy = new SpriteEnnemy(mainGame, position, 
                new Vector2(TDData.Data[ennemyID].Velocity.X, 0), ennemyID, eDirection.Right);
            spriteEnnemy.AddAnimation(
                "Ennemy",
                TDData.Data[ennemyID].ArrayFrames,
                TDData.Data[ennemyID].FramesDuration,
                TDData.Data[ennemyID].OffsetX,
                TDData.Data[ennemyID].OffsetY,
                TDData.Data[ennemyID].IsLoop,
                TDData.Data[ennemyID].InitOffsetX,
                TDData.Data[ennemyID].InitOffsetY);
            spriteEnnemy.RunAnimation("Ennemy");
            liste.Add(spriteEnnemy);
            return this;
        }
        public SpriteEnnemyFilter UpdateAll(GameTime pGametime)
        {
            liste.ForEach(sprite => sprite.Update(pGametime));
            return this;
        }

        public SpriteEnnemyFilter DrawAll(GameTime pGametime)
        {
            liste.ForEach(sprite => sprite.Draw(pGametime));
            return this;
        }

        public void Moving(SceneMap currentScene)
        {
            liste.ForEach(spriteEnnemy => {

                Vector2 position = new Vector2();
                for (int line = 0; line < currentScene._mapTiled.arrayPath.GetLength(0); line++)
                {
                    for (int column = 0; column < currentScene._mapTiled.arrayPath.GetLength(1); column++)
                    {
                        if (currentScene._mapTiled.arrayPath[line, column] == 837)
                        {
                            position = new Vector2(line * TDData.Data[spriteEnnemy.ennemyID].FrameWidth + TDData.Data[spriteEnnemy.ennemyID].FrameWidth / 2,
                            column * TDData.Data[spriteEnnemy.ennemyID].FrameHeight + TDData.Data[spriteEnnemy.ennemyID].FrameHeight / 2);
                        }
                    }
                }


                if (spriteEnnemy.HP <= 0)
                {
                    TDData.Gold += TDData.Data[spriteEnnemy.ID].Gold;
                    spriteEnnemy.ToRemove = true;
                }
            });
            
        }

        public SpriteEnnemyFilter ImpactCollision()
        {
            liste.ForEach(spriteEnnemy => {
                if (spriteEnnemy.HP <= 0)
                {
                    TDData.Gold += TDData.Data[spriteEnnemy.ID].Gold;
                    spriteEnnemy.ToRemove = true;
                }
            });
            return this;
        }

        public SpriteEnnemyFilter RemoveDeadEnnemy()
        {
            liste.RemoveAll(spriteEnnemy => spriteEnnemy.ToRemove);
            return this;
        }

    }
}
