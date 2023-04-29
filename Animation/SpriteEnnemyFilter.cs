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
using Microsoft.Xna.Framework.Input;

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
        public static (Vector2,Vector2) StartPositionAndBox(string ennemyID)
        {
            Vector2 position = new Vector2();
            Vector2 currentBox = new Vector2();
            for (int line = 0; line < SceneMap.map.arrayPath.GetLength(0); line++)
            {
                for (int column = 0; column < SceneMap.map.arrayPath.GetLength(1); column++)
                {
                    if (SceneMap.map.arrayPath[line, column] == TDData.StartBox)
                    {
                        position = new Vector2(line * TDData.BoxWidth + TDData.BoxWidth / 2,
                            column * TDData.BoxHeight + TDData.BoxHeight / 2);
                        currentBox = new Vector2(line, column);
                    }
                }
            }
            return (position, currentBox);
        }
   
        
        public SpriteEnnemyFilter AddEnnemy(Game mainGame, string ennemyID)
        {
            (Vector2 position, Vector2 currentBox) = StartPositionAndBox(ennemyID);
            SpriteEnnemy spriteEnnemy = new SpriteEnnemy(mainGame, position, currentBox, ennemyID);
            spriteEnnemy.AddAnimation(
                "Ennemy",
                TDData.Data[ennemyID].ArrayFrames,
                TDData.Data[ennemyID].FramesDuration,
                TDData.Data[ennemyID].OffsetX,
                TDData.Data[ennemyID].OffsetY,
                TDData.Data[ennemyID].IsLoop,
                TDData.Data[ennemyID].InitOffsetX,
                TDData.Data[ennemyID].InitOffsetY);
            spriteEnnemy.currentDestination = eDirection.Right;
            spriteEnnemy.nextDestination = eDirection.Right;
            spriteEnnemy.ennemyVelocity = new Vector2(1,0);
            spriteEnnemy.CurrentBox = currentBox;
            spriteEnnemy.NextBox = currentBox + new Vector2(1,0);
            Tools.NextAfterBox(spriteEnnemy);
            spriteEnnemy.nextDestination = spriteEnnemy.nextAfterDestination;
            if (spriteEnnemy.nextAfterDestination == eDirection.None)
            {
                spriteEnnemy.nextDestination = eDirection.Right;
                spriteEnnemy.nextAfterDestination = eDirection.Right;
            }
            spriteEnnemy.RunAnimation("Ennemy");
            liste.Add(spriteEnnemy);
            return this;
        }
        public bool EnnemyInCurrentBox(SpriteEnnemy spriteEnnemy)
        {
            if (spriteEnnemy.position.X >= spriteEnnemy.CurrentBox.X * TDData.BoxWidth &&
                spriteEnnemy.position.X <= (spriteEnnemy.CurrentBox.X + 1) * TDData.BoxWidth &&
                spriteEnnemy.position.Y >= spriteEnnemy.CurrentBox.Y * TDData.BoxHeight &&
                spriteEnnemy.position.Y <= (spriteEnnemy.CurrentBox.Y + 1) * TDData.BoxHeight)
                return true;
            return false;
        }
        public void ContinueStraight(SpriteEnnemy spriteEnnemy)
        {
            switch (spriteEnnemy.currentDestination)
            {
                case TDData.eDirection.Right:
                    spriteEnnemy.currentAnimation.initOffsetY = TDData.Data[spriteEnnemy.ennemyID].InitOffsetY;
                    spriteEnnemy.isFlipHorizontally = TDData.Data[spriteEnnemy.ennemyID].isTilesetDirectionLeft;
                    spriteEnnemy.ennemyVelocity = new Vector2(1, 0);
                    break;
                case TDData.eDirection.Left:
                    spriteEnnemy.currentAnimation.initOffsetY = TDData.Data[spriteEnnemy.ennemyID].InitOffsetY;
                    spriteEnnemy.isFlipHorizontally = !TDData.Data[spriteEnnemy.ennemyID].isTilesetDirectionLeft;
                    spriteEnnemy.ennemyVelocity = new Vector2(-1, 0);
                    break;
                case TDData.eDirection.Up:
                    spriteEnnemy.currentAnimation.initOffsetY = TDData.Data[spriteEnnemy.ennemyID].InitOffsetYUp;
                    spriteEnnemy.ennemyVelocity = new Vector2(0, -1);
                    break;
                case TDData.eDirection.Botton:
                    spriteEnnemy.currentAnimation.initOffsetY = TDData.Data[spriteEnnemy.ennemyID].InitOffsetYBottom;
                    spriteEnnemy.ennemyVelocity = new Vector2(0, 1);
                    break;
                default:
                    break;
            }
        }
        public void TurnRightUpOrRightBottom(SpriteEnnemy spriteEnnemy)
        {

            if (spriteEnnemy.nextDestination == eDirection.Up)
            {
                spriteEnnemy.currentAnimation.initOffsetY = TDData.Data[spriteEnnemy.ennemyID].InitOffsetY;
                spriteEnnemy.isFlipHorizontally = TDData.Data[spriteEnnemy.ennemyID].isTilesetDirectionLeft;
                spriteEnnemy.ennemyVelocity = new Vector2(1, -1);
                spriteEnnemy.rotation = (float)Math.PI / 4 * -1;

            }
            else
            {
                spriteEnnemy.currentAnimation.initOffsetY = TDData.Data[spriteEnnemy.ennemyID].InitOffsetY;
                spriteEnnemy.isFlipHorizontally = TDData.Data[spriteEnnemy.ennemyID].isTilesetDirectionLeft;
                spriteEnnemy.ennemyVelocity = new Vector2(1, 1);
                spriteEnnemy.rotation = (float)Math.PI / 4;
            }
        }
        public void TurnLeftUpOrLeftBottom(SpriteEnnemy spriteEnnemy)
        {
            if (spriteEnnemy.nextDestination == eDirection.Up)
            {
                spriteEnnemy.currentAnimation.initOffsetY = TDData.Data[spriteEnnemy.ennemyID].InitOffsetY;
                spriteEnnemy.isFlipHorizontally = !TDData.Data[spriteEnnemy.ennemyID].isTilesetDirectionLeft;
                spriteEnnemy.ennemyVelocity = new Vector2(-1, -1);
                spriteEnnemy.rotation = (float)Math.PI / 4  ;
            }
            else
            {
                spriteEnnemy.currentAnimation.initOffsetY = TDData.Data[spriteEnnemy.ennemyID].InitOffsetY;
                spriteEnnemy.isFlipHorizontally = !TDData.Data[spriteEnnemy.ennemyID].isTilesetDirectionLeft;
                spriteEnnemy.ennemyVelocity = new Vector2(-1, 1);
                spriteEnnemy.rotation = (float)Math.PI / 4 * -1;
            }
        }
        public void TurnUpRightOrUpLeft(SpriteEnnemy spriteEnnemy)
        {
            spriteEnnemy.isFlipHorizontally = false;
            if (spriteEnnemy.nextDestination == eDirection.Right)
            {
                spriteEnnemy.ennemyVelocity = new Vector2(1, -1);
                spriteEnnemy.rotation = (float)Math.PI / 4;
            }
            else
            {
                spriteEnnemy.ennemyVelocity = new Vector2(-1, -1);
                spriteEnnemy.rotation = (float)Math.PI / 4 * -1;

            }
        }
        public void TurnBottomRightOrBottomLeft(SpriteEnnemy spriteEnnemy)
        {
            spriteEnnemy.isFlipHorizontally = false;
            if (spriteEnnemy.nextDestination == eDirection.Right)
            {
                spriteEnnemy.ennemyVelocity = new Vector2(1, 1);
                spriteEnnemy.rotation = (float)Math.PI / 4 * -1;
            }
            else
            {
                spriteEnnemy.ennemyVelocity = new Vector2(-1, 1);
                spriteEnnemy.rotation = (float)Math.PI / 4 ;
            }
        }
        public void StartTurning(SpriteEnnemy spriteEnnemy)
        {
            switch (spriteEnnemy.currentDestination)
            {
                case TDData.eDirection.Right:
                    TurnRightUpOrRightBottom(spriteEnnemy);
                    break;
                case TDData.eDirection.Left:
                    TurnLeftUpOrLeftBottom(spriteEnnemy);
                    break;
                case TDData.eDirection.Up:
                    TurnUpRightOrUpLeft(spriteEnnemy);
                    break;
                case TDData.eDirection.Botton:
                    TurnBottomRightOrBottomLeft(spriteEnnemy);
                    break;
                default:
                    break;
            }            
        }
        public void NextEnnemyDestination(SpriteEnnemy spriteEnnemy)
        {
            Debug.WriteLine("NextEnnemyDestination");

            if ((spriteEnnemy.currentDestination == spriteEnnemy.nextDestination
                && spriteEnnemy.nextDestination == spriteEnnemy.nextAfterDestination) || spriteEnnemy.IsEnnemyTurning)
            {
                Debug.WriteLine("ContinueStraight");
                ContinueStraight(spriteEnnemy);
                spriteEnnemy.IsEnnemyTurning = false;
                spriteEnnemy.rotation = 0;
            }
            else if (spriteEnnemy.currentDestination != spriteEnnemy.nextDestination)
            {
                Debug.WriteLine("StartTurning");
                StartTurning(spriteEnnemy);
                spriteEnnemy.currentDestination = spriteEnnemy.nextDestination;
                spriteEnnemy.nextDestination = spriteEnnemy.nextAfterDestination;
                spriteEnnemy.IsEnnemyTurning = true;
                return;
            }
            spriteEnnemy.currentDestination = spriteEnnemy.nextDestination;
            spriteEnnemy.nextDestination = spriteEnnemy.nextAfterDestination;
            //spriteEnnemy.rotation = 0;
        }

        public void ReplaceEnnemy(SpriteEnnemy spriteEnnemy)
        {
            switch (spriteEnnemy.currentDestination)
            {
                case eDirection.Left:
                    spriteEnnemy.position = new Vector2(spriteEnnemy.CurrentBox.X * TDData.BoxWidth - 1,
                        spriteEnnemy.CurrentBox.Y * TDData.BoxHeight + TDData.BoxHeight / 2);
                    break;
                case eDirection.Right:
                    spriteEnnemy.position = new Vector2(spriteEnnemy.CurrentBox.X * TDData.BoxWidth + TDData.BoxWidth + 1,
                        spriteEnnemy.CurrentBox.Y * TDData.BoxHeight + TDData.BoxHeight / 2);
                    break;
                case eDirection.Up:
                    spriteEnnemy.position = new Vector2(spriteEnnemy.CurrentBox.X * TDData.BoxWidth + TDData.BoxWidth - TDData.BoxWidth / 2,
                        spriteEnnemy.CurrentBox.Y * TDData.BoxHeight -1);
                    break;
                case eDirection.Botton:
                    spriteEnnemy.position = new Vector2(spriteEnnemy.CurrentBox.X * TDData.BoxWidth + TDData.BoxWidth - TDData.BoxWidth / 2,
                        (spriteEnnemy.CurrentBox.Y + 1) * TDData.BoxHeight + 1);
                    break;
                default:
                    break;
            }
        }

        public SpriteEnnemyFilter UpdateVelocity(SceneMap currentScene)
        {
            liste.ForEach(spriteEnnemy =>
            {

                if (spriteEnnemy.IsArrivalCurrentBox)
                {
                    Tools.EnnemyArrival(spriteEnnemy);
                }
                else
                {
                    if (!EnnemyInCurrentBox(spriteEnnemy))
                    {
                        ReplaceEnnemy(spriteEnnemy);
                        NextEnnemyDestination(spriteEnnemy);
                        spriteEnnemy.CurrentBox = spriteEnnemy.NextBox;
                        spriteEnnemy.NextBox = spriteEnnemy.NextAfterBox;
                        Tools.NextAfterBox(spriteEnnemy);
                    }
                    if (spriteEnnemy.CurrentBox == new Vector2(19, 3))
                        Debug.WriteLine("spriteEnnemy.CurrentBox: " + spriteEnnemy.CurrentBox.ToString());
                }
                spriteEnnemy.velocity = new Vector2(spriteEnnemy.ennemyVelocity.X * spriteEnnemy.speed,
                    spriteEnnemy.ennemyVelocity.Y * spriteEnnemy.speed);
            });
            return this;
        }

        public SpriteEnnemy OnHover()
        {
            MouseState mouseState = Mouse.GetState();
            Point mousePos = mouseState.Position;
            return liste.FirstOrDefault(sprite => sprite.ennemyBoundingBox.Contains(mousePos));
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

        public SpriteEnnemyFilter EnnemyArrived()
        {
            liste.ForEach(spriteEnnemy =>
            {
                if (spriteEnnemy.IsArrived)
                {
                    TDData.Life -= Data[spriteEnnemy.ennemyID].LifeMinus;
                }
            });
            liste.RemoveAll(spriteEnnemy => spriteEnnemy.IsArrived);
            return this;
        }

        public SpriteEnnemyFilter RemoveDeadEnnemy()
        {
            liste.RemoveAll(spriteEnnemy => spriteEnnemy.ToRemove);
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
    }
}
