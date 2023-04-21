using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static tower_Defense.TDData;
using tower_Defense.Scenes;
using static tower_Defense.DataBase.TDWave;
using tower_Defense.Utils;
using System.Diagnostics;
using tower_Defense.Map;

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
            Vector2 currentBox =new Vector2();
            for (int line = 0; line < currentScene.map.arrayPath.GetLength(0); line++)
            {
                for (int column = 0; column < currentScene.map.arrayPath.GetLength(1); column++)
                {
                    if (currentScene.map.arrayPath[line, column] == TDData.StartBox)
                    {
                        position = new Vector2(line * TDData.BoxWidth + TDData.BoxWidth/2,
                            column * TDData.BoxHeight + TDData.BoxHeight/2);
                        currentBox = new Vector2(line, column);
                    }
                }
            }
            SpriteEnnemy spriteEnnemy = new SpriteEnnemy(mainGame, position, 
                currentBox, ennemyID);
            spriteEnnemy.AddAnimation(
                "Ennemy",
                TDData.Data[ennemyID].ArrayFrames,
                TDData.Data[ennemyID].FramesDuration,
                TDData.Data[ennemyID].OffsetX,
                TDData.Data[ennemyID].OffsetY,
                TDData.Data[ennemyID].IsLoop,
                TDData.Data[ennemyID].InitOffsetX,
                TDData.Data[ennemyID].InitOffsetY);
            NextEnnemyDestination(spriteEnnemy, spriteEnnemy.CurrentBox, spriteEnnemy.NextBox);
            spriteEnnemy.NextAfterBox = Tools.NextAfterBox(currentScene, spriteEnnemy);
            spriteEnnemy.RunAnimation("Ennemy");
            liste.Add(spriteEnnemy);
            return this;
        }
        public bool EnnemyInCurrentBox(SpriteEnnemy spriteEnnemy)
        {
            if (spriteEnnemy.position.X >= spriteEnnemy.CurrentBox.X * spriteEnnemy.frameWidth &&
                spriteEnnemy.position.X <= (spriteEnnemy.CurrentBox.X + 1) * spriteEnnemy.frameWidth &&
                spriteEnnemy.position.Y >= spriteEnnemy.CurrentBox.Y * spriteEnnemy.frameHeight &&
                spriteEnnemy.position.Y <= (spriteEnnemy.CurrentBox.Y + 1) * spriteEnnemy.frameHeight)
                return true;
            return false;
        }
        public void NextEnnemyDestination(SpriteEnnemy spriteEnnemy, Vector2 boxOrigine, Vector2 boxDestination)
        {
            Vector2 destination = boxDestination - boxOrigine;
            switch (destination)
            {
                case Vector2(0,0):
                    spriteEnnemy.nextDestination = spriteEnnemy.currentDestination;
                    break;
                case Vector2(1,0):
                    spriteEnnemy.IsMirrored = !TDData.Data[spriteEnnemy.ennemyID].isMirrored;
                    spriteEnnemy.nextDestination = eDirection.Right;
                    break;
                case Vector2(-1, 0):
                    spriteEnnemy.IsMirrored = TDData.Data[spriteEnnemy.ennemyID].isMirrored;
                    spriteEnnemy.nextDestination = eDirection.Left;
                    break;
                case Vector2(0, 1):
                    spriteEnnemy.nextDestination = eDirection.Botton;
                    break;
                case Vector2(0, -1):
                case Vector2(1,-1):
                case Vector2(-1, -1):
                    spriteEnnemy.currentAnimation.initOffsetY = TDData.Data[spriteEnnemy.ennemyID].InitOffsetYUp;
                    spriteEnnemy.nextDestination = eDirection.Up;
                    break;
                default:
                    break;
            }
        }

        public void ReplaceEnnemy(SpriteEnnemy spriteEnnemy)
        {
            switch (spriteEnnemy.currentDestination)
            {
                case eDirection.Left:
                    spriteEnnemy.position = new Vector2(spriteEnnemy.CurrentBox.X * TDData.BoxWidth - TDData.BoxWidth,
                        spriteEnnemy.CurrentBox.Y * TDData.BoxHeight + TDData.BoxHeight / 2);
                    break;
                case eDirection.Right:
                    spriteEnnemy.position = new Vector2(spriteEnnemy.CurrentBox.X * TDData.BoxWidth + TDData.BoxWidth,
                        spriteEnnemy.CurrentBox.Y * TDData.BoxHeight + TDData.BoxHeight / 2);
                    break;
                case eDirection.Up:
                    spriteEnnemy.position = new Vector2(spriteEnnemy.CurrentBox.X * TDData.BoxWidth + TDData.BoxWidth - TDData.BoxWidth / 2,
                        spriteEnnemy.CurrentBox.Y * TDData.BoxHeight);
                    break;
                case eDirection.Botton:
                    spriteEnnemy.position = new Vector2(spriteEnnemy.CurrentBox.X * TDData.BoxWidth - TDData.BoxWidth - TDData.BoxWidth / 2,
                        spriteEnnemy.CurrentBox.Y * TDData.BoxHeight);
                    break;
                default:
                    break;
            }
        }

        public SpriteEnnemyFilter UpdateVelocity(SceneMap currentScene)
        {
            liste.ForEach(spriteEnnemy =>
            {
                if (!EnnemyInCurrentBox(spriteEnnemy))
                {
                    ReplaceEnnemy(spriteEnnemy);
                    NextEnnemyDestination(spriteEnnemy, spriteEnnemy.CurrentBox, spriteEnnemy.NextAfterBox);
                    spriteEnnemy.currentDestination = spriteEnnemy.nextDestination;
                    spriteEnnemy.CurrentBox = spriteEnnemy.NextBox;
                    spriteEnnemy.NextBox = spriteEnnemy.NextAfterBox;
                    spriteEnnemy.NextAfterBox = Tools.NextAfterBox(currentScene, spriteEnnemy);
                }
                spriteEnnemy.ennemyVelocity = Tools.NewVelocity(spriteEnnemy);
                spriteEnnemy.velocity = new Vector2(spriteEnnemy.ennemyVelocity.X * spriteEnnemy.speed, 
                    spriteEnnemy.ennemyVelocity.Y * spriteEnnemy.speed);               
            });
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
