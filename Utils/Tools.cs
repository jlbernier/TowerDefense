using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tower_Defense.Animation;
using tower_Defense.Scenes;
using static tower_Defense.DataBase.TDWave;

namespace tower_Defense.Utils
{
    public class Tools
    {
        public Tools() { }

        public static void IsMouseVisible(Boolean isVisible)
        {
            if (isVisible)
                Mouse.SetCursor(MouseCursor.Arrow);
            Mouse.SetCursor(MouseCursor.FromTexture2D(MainGame.transparentTexture, 0, 0));
        }

        public static int BoxToCheck(SceneMap currentScene,SpriteEnnemy spriteEnnemy, TDData.eDirection direction)
        {
            switch (direction)
            {
                case TDData.eDirection.Left:
                    return ((int)spriteEnnemy.NextBox.X == 0) ? 0 :
                (int)currentScene.map.arrayPath[(int)spriteEnnemy.NextBox.X - 1, (int)spriteEnnemy.NextBox.Y];
                case TDData.eDirection.Right:
                    return ((int)spriteEnnemy.NextBox.X == currentScene.map.arrayPath.GetLength(0)) ? 0 :
                             (int)currentScene.map.arrayPath[(int)spriteEnnemy.NextBox.X + 1, (int)spriteEnnemy.NextBox.Y]; break;
                case TDData.eDirection.Botton:
                    return ((int)spriteEnnemy.NextBox.Y == currentScene.map.arrayPath.GetLength(1)) ? 0 :
                          (int)currentScene.map.arrayPath[(int)spriteEnnemy.NextBox.X, (int)spriteEnnemy.NextBox.Y + 1]; break;
                case TDData.eDirection.Up:
                    return ((int)spriteEnnemy.NextBox.Y == 0) ? 0 :
                             (int)currentScene.map.arrayPath[(int)spriteEnnemy.NextBox.X, (int)spriteEnnemy.NextBox.Y - 1]; break;
                default:
                    return 0;
            }
        }

        public static void NextDestinationLeft(SceneMap currentScene, SpriteEnnemy spriteEnnemy)
        {
            if (spriteEnnemy.IsArrivalNextCurrentBox)
            {
                spriteEnnemy.NextAfterBox = new Vector2(spriteEnnemy.NextBox.X - 1, spriteEnnemy.NextBox.Y);
                spriteEnnemy.IsArrivalCurrentBox = true;
                return;
            }
            if (spriteEnnemy.IsArrivalAfterNextCurrentBox)
            {
                spriteEnnemy.NextAfterBox = new Vector2(spriteEnnemy.NextBox.X - 1, spriteEnnemy.NextBox.Y);
                spriteEnnemy.IsArrivalNextCurrentBox = true;
                return;
            }
            switch (BoxToCheck(currentScene, spriteEnnemy, TDData.eDirection.Left))
            {
                case TDData.EndBox:
                    spriteEnnemy.NextAfterBox = new Vector2(spriteEnnemy.NextBox.X - 1, spriteEnnemy.NextBox.Y);
                    spriteEnnemy.IsArrivalAfterNextCurrentBox = true;
                    return;
                case TDData.HorizontalPath:   
                case TDData.HorizontalPathBis:
                case TDData.BottomLeft3:
                case TDData.UpLeft3: 
                case TDData.LeftUp1:
                case TDData.LeftBottom1: 
                    spriteEnnemy.NextAfterBox = new Vector2(spriteEnnemy.NextBox.X - 1, spriteEnnemy.NextBox.Y);
                    return;
                case TDData.LeftUp2:
                    spriteEnnemy.nextAfterDestination = TDData.eDirection.Up;
                    spriteEnnemy.NextAfterBox = new Vector2(spriteEnnemy.NextBox.X - 1, spriteEnnemy.NextBox.Y);
                    return;
                case TDData.LeftBottom2:
                    spriteEnnemy.nextAfterDestination = TDData.eDirection.Botton;
                    spriteEnnemy.NextAfterBox = new Vector2(spriteEnnemy.NextBox.X - 1, spriteEnnemy.NextBox.Y);
                    return;
                case TDData.StonePath:
                    if (spriteEnnemy.IsFlying)
                    {
                        spriteEnnemy.NextAfterBox = new Vector2(spriteEnnemy.NextBox.X - 1, spriteEnnemy.NextBox.Y);
                        return;
                    }
                    break;
                case TDData.VerticalBridge1:
                case TDData.VerticalBridge2:
                    if (!spriteEnnemy.IsFlying)
                    {
                        spriteEnnemy.NextAfterBox = new Vector2(spriteEnnemy.NextBox.X - 1, spriteEnnemy.NextBox.Y);
                        return;
                    }
                    break;
                default:
                    break;
            }
            if (TDData.Data[spriteEnnemy.ennemyID].isPreferredDirectionLeft)
                switch (BoxToCheck(currentScene, spriteEnnemy, TDData.eDirection.Up))
                {
                    case TDData.StonePath:
                        if (spriteEnnemy.IsFlying)
                        {
                            spriteEnnemy.currentDestination = TDData.eDirection.Up;
                            spriteEnnemy.nextAfterDestination = TDData.eDirection.Up;
                            spriteEnnemy.NextAfterBox = new Vector2(spriteEnnemy.NextBox.X, spriteEnnemy.NextBox.Y - 1);
                            return;
                        }
                        break;
                    case TDData.HorizontalBridge1:
                        if (!spriteEnnemy.IsFlying)
                        {
                            spriteEnnemy.currentDestination = TDData.eDirection.Up;
                            spriteEnnemy.nextAfterDestination = TDData.eDirection.Up;
                            spriteEnnemy.NextAfterBox = new Vector2(spriteEnnemy.NextBox.X, spriteEnnemy.NextBox.Y - 1);
                            return;
                        }
                        break;
                    default:
                        break;
                }
            switch (BoxToCheck(currentScene, spriteEnnemy, TDData.eDirection.Botton))
            {
                case TDData.StonePath:
                    spriteEnnemy.currentDestination = TDData.eDirection.Botton;
                    spriteEnnemy.nextAfterDestination = TDData.eDirection.Botton;
                    spriteEnnemy.NextAfterBox = new Vector2(spriteEnnemy.NextBox.X, spriteEnnemy.NextBox.Y - 1);
                    break;
                case TDData.HorizontalBridge1:
                    spriteEnnemy.currentDestination = TDData.eDirection.Botton;
                    spriteEnnemy.nextAfterDestination = TDData.eDirection.Botton;
                    spriteEnnemy.NextAfterBox = new Vector2(spriteEnnemy.NextBox.X, spriteEnnemy.NextBox.Y - 1);
                    break;
                default:
                    break;
            }
        }

        public static void NextDestinationRight(SceneMap currentScene, SpriteEnnemy spriteEnnemy)
        {
            if (spriteEnnemy.IsArrivalNextCurrentBox)
            {
                spriteEnnemy.NextAfterBox = new Vector2(spriteEnnemy.NextBox.X + 1, spriteEnnemy.NextBox.Y);
                spriteEnnemy.IsArrivalCurrentBox = true;
                return;
            }
            if (spriteEnnemy.IsArrivalAfterNextCurrentBox)
            {
                spriteEnnemy.NextAfterBox = new Vector2(spriteEnnemy.NextBox.X + 1, spriteEnnemy.NextBox.Y);
                spriteEnnemy.IsArrivalNextCurrentBox = true;
                return;
            }
            switch (BoxToCheck(currentScene, spriteEnnemy, TDData.eDirection.Right))
            {
                case TDData.EndBox:
                    spriteEnnemy.NextAfterBox = new Vector2(spriteEnnemy.NextBox.X + 1, spriteEnnemy.NextBox.Y);
                    spriteEnnemy.IsArrivalAfterNextCurrentBox = true;
                    return;
                case TDData.HorizontalPath:
                case TDData.HorizontalPathBis:
                case TDData.Crossing1:
                case TDData.Crossing2:
                case TDData.Crossing3:
                case TDData.RightDown1:
                case TDData.BottomRight3:
                case TDData.RightUp1: 
                    spriteEnnemy.NextAfterBox = new Vector2(spriteEnnemy.NextBox.X +1, spriteEnnemy.NextBox.Y);
                    return;
                case TDData.RightUp2: 
                    spriteEnnemy.NextAfterBox = new Vector2(spriteEnnemy.NextBox.X + 1, spriteEnnemy.NextBox.Y);
                    spriteEnnemy.nextAfterDestination = TDData.eDirection.Up;
                    return;
                
                case TDData.RightDown2:
                    spriteEnnemy.NextAfterBox = new Vector2(spriteEnnemy.NextBox.X + 1, spriteEnnemy.NextBox.Y);
                    spriteEnnemy.nextAfterDestination = TDData.eDirection.Botton;
                    return;
                case TDData.UpRight3: // end of turn up right
                    spriteEnnemy.NextAfterBox = new Vector2(spriteEnnemy.NextBox.X + 1, spriteEnnemy.NextBox.Y);
                    return;
                case TDData.StonePath:
                    if (spriteEnnemy.IsFlying)
                    {
                        spriteEnnemy.NextAfterBox = new Vector2(spriteEnnemy.NextBox.X +1, spriteEnnemy.NextBox.Y);
                        return;
                    }
                    break;
                case TDData.VerticalBridge1:
                case TDData.VerticalBridge2:
                    if (!spriteEnnemy.IsFlying)
                    {
                        spriteEnnemy.NextAfterBox = new Vector2(spriteEnnemy.NextBox.X+1, spriteEnnemy.NextBox.Y);
                        return;
                    }
                    break;
                default:
                    break;
            }
            if (TDData.Data[spriteEnnemy.ennemyID].isPreferredDirectionLeft)
                //Debug.WriteLine(BoxToCheck(currentScene, spriteEnnemy, TDData.eDirection.Up));
                switch (BoxToCheck(currentScene, spriteEnnemy, TDData.eDirection.Up))
                {
                    case TDData.StonePath:
                        if (spriteEnnemy.IsFlying)
                        {
                            spriteEnnemy.nextDestination = TDData.eDirection.Up;
                            spriteEnnemy.nextAfterDestination = TDData.eDirection.Up;
                            spriteEnnemy.NextAfterBox = new Vector2(spriteEnnemy.NextBox.X, spriteEnnemy.NextBox.Y - 1);
                            return;
                        }
                        break;
                    case TDData.HorizontalBridge1:
                        if (!spriteEnnemy.IsFlying)
                        {
                            spriteEnnemy.nextDestination = TDData.eDirection.Up;
                            spriteEnnemy.nextAfterDestination = TDData.eDirection.Up;
                            spriteEnnemy.NextAfterBox = new Vector2(spriteEnnemy.NextBox.X, spriteEnnemy.NextBox.Y - 1);
                            return;
                        }
                        break;
                        case TDData.VerticalPath:
                        spriteEnnemy.nextDestination = TDData.eDirection.Up;
                        spriteEnnemy.nextAfterDestination = TDData.eDirection.Up;
                        spriteEnnemy.NextAfterBox = new Vector2(spriteEnnemy.NextBox.X, spriteEnnemy.NextBox.Y - 1);
                        return; ;
                    default:
                        break;
                }
            switch (BoxToCheck(currentScene, spriteEnnemy, TDData.eDirection.Botton))
            {
                case TDData.StonePath:
                case TDData.HorizontalBridge2:
                case TDData.DownRight1:
                case TDData.DownLeft1:
                case TDData.VerticalPath:
                case TDData.Crossing1:
                case TDData.Crossing2:
                case TDData.Crossing3:
                case TDData.Crossing4:
                    spriteEnnemy.nextDestination = TDData.eDirection.Botton;
                    spriteEnnemy.nextAfterDestination = TDData.eDirection.Botton;
                    spriteEnnemy.NextAfterBox = new Vector2(spriteEnnemy.NextBox.X, spriteEnnemy.NextBox.Y + 1);
                    break;
                default:
                    Debug.WriteLine(BoxToCheck(currentScene, spriteEnnemy, TDData.eDirection.Botton));
                    break;
            }
        }

        public static void NextDestinationUp(SceneMap currentScene, SpriteEnnemy spriteEnnemy)
        {
            if (spriteEnnemy.IsArrivalNextCurrentBox)
            {
                spriteEnnemy.NextAfterBox = new Vector2(spriteEnnemy.NextBox.X, spriteEnnemy.NextBox.Y - 1);
                spriteEnnemy.IsArrivalCurrentBox = true;
                return;
            }
            if (spriteEnnemy.IsArrivalAfterNextCurrentBox)
            {
                spriteEnnemy.NextAfterBox = new Vector2(spriteEnnemy.NextBox.X, spriteEnnemy.NextBox.Y - 1);
                spriteEnnemy.IsArrivalNextCurrentBox = true;
                return;
            }
            switch (BoxToCheck(currentScene, spriteEnnemy, TDData.eDirection.Up))
            {
                case TDData.EndBox:
                    spriteEnnemy.NextAfterBox = new Vector2(spriteEnnemy.NextBox.X, spriteEnnemy.NextBox.Y - 1);
                    spriteEnnemy.IsArrivalAfterNextCurrentBox = true;
                    return;
                case TDData.VerticalPath:
                case TDData.HorizontalBridge2:
                case TDData.UpRight1:
                case TDData.RightUp3:
                case TDData.LeftUp3:
                case TDData.UpLeft1:
                case TDData.Crossing1:
                case TDData.Crossing2:
                case TDData.Crossing3:
                case TDData.Crossing4:
                    spriteEnnemy.nextAfterDestination = TDData.eDirection.Up;
                    spriteEnnemy.NextAfterBox = new Vector2(spriteEnnemy.NextBox.X, spriteEnnemy.NextBox.Y - 1);
                    return;
                case TDData.UpLeft2:
                    spriteEnnemy.nextAfterDestination = TDData.eDirection.Left;
                    spriteEnnemy.NextAfterBox = new Vector2(spriteEnnemy.NextBox.X, spriteEnnemy.NextBox.Y - 1);
                    return;
                case TDData.UpRight2:
                    spriteEnnemy.nextAfterDestination = TDData.eDirection.Right;
                    spriteEnnemy.NextAfterBox = new Vector2(spriteEnnemy.NextBox.X, spriteEnnemy.NextBox.Y - 1);
                    return;
                 case TDData.StonePath:
                    if (spriteEnnemy.IsFlying)
                    {
                        spriteEnnemy.NextAfterBox = new Vector2(spriteEnnemy.NextBox.X, spriteEnnemy.NextBox.Y - 1);
                        return;
                    }
                    break;
                case TDData.HorizontalBridge1:
                    if (!spriteEnnemy.IsFlying)
                    {
                        spriteEnnemy.NextAfterBox = new Vector2(spriteEnnemy.NextBox.X, spriteEnnemy.NextBox.Y - 1);
                        return;
                    }
                    break;
                default:
                    break;
            }
            if (TDData.Data[spriteEnnemy.ennemyID].isPreferredDirectionLeft)
            switch (BoxToCheck(currentScene, spriteEnnemy, TDData.eDirection.Left))
            {
                case TDData.StonePath:
                        if (spriteEnnemy.IsFlying)
                        {
                            spriteEnnemy.NextAfterBox = new Vector2(spriteEnnemy.NextBox.X, spriteEnnemy.NextBox.Y - 1);
                            return;
                        }
                    break;
                case TDData.HorizontalBridge1:
                        if (!spriteEnnemy.IsFlying)
                        {
                            spriteEnnemy.NextAfterBox = new Vector2(spriteEnnemy.NextBox.X, spriteEnnemy.NextBox.Y - 1);
                            return;
                        }
                    break;
                default:
                        int box = ((int)spriteEnnemy.NextBox.Y == 0) ? 0 :
                             (int)currentScene.map.arrayPath[(int)spriteEnnemy.NextBox.X, (int)spriteEnnemy.NextBox.Y]; 

                        if (box == TDData.Crossing3)
                        {
                            // turn Right after Crossing3
                            spriteEnnemy.nextDestination = TDData.eDirection.Right;
                            spriteEnnemy.nextAfterDestination = TDData.eDirection.Right;
                            spriteEnnemy.NextAfterBox = new Vector2(spriteEnnemy.NextBox.X + 1, spriteEnnemy.NextBox.Y);
                        }
                        break;
            }
            switch (BoxToCheck(currentScene, spriteEnnemy, TDData.eDirection.Right))
            {
                case TDData.StonePath:
                    spriteEnnemy.NextAfterBox = new Vector2(spriteEnnemy.NextBox.X, spriteEnnemy.NextBox.Y - 1);
                    break;
                case TDData.HorizontalBridge1:
                    spriteEnnemy.NextAfterBox = new Vector2(spriteEnnemy.NextBox.X, spriteEnnemy.NextBox.Y - 1);
                    break;
                case TDData.HorizontalPath:
                case TDData.HorizontalPathBis:
                    spriteEnnemy.nextDestination = TDData.eDirection.Right;
                    spriteEnnemy.nextAfterDestination = TDData.eDirection.Right;
                    spriteEnnemy.NextAfterBox = new Vector2(spriteEnnemy.NextBox.X + 1, spriteEnnemy.NextBox.Y);
                    break;
                default:
                    break;
            }
        }

        public static void NextDestinationBotton(SceneMap currentScene, SpriteEnnemy spriteEnnemy)
        {

            if (spriteEnnemy.IsArrivalNextCurrentBox)
            {
                spriteEnnemy.NextAfterBox = new Vector2(spriteEnnemy.NextBox.X, spriteEnnemy.NextBox.Y + 1);
                spriteEnnemy.IsArrivalCurrentBox = true;
                return;
            }
            if (spriteEnnemy.IsArrivalAfterNextCurrentBox)
            {
                spriteEnnemy.NextAfterBox = new Vector2(spriteEnnemy.NextBox.X, spriteEnnemy.NextBox.Y + 1);
                spriteEnnemy.IsArrivalNextCurrentBox = true;
                return;
            }
            switch (BoxToCheck(currentScene, spriteEnnemy, TDData.eDirection.Botton))
            {
                case TDData.EndBox:
                    spriteEnnemy.NextAfterBox = new Vector2(spriteEnnemy.NextBox.X, spriteEnnemy.NextBox.Y + 1);
                    spriteEnnemy.IsArrivalAfterNextCurrentBox = true;
                    return;
                case TDData.VerticalPath:
                case TDData.HorizontalBridge1:
                case TDData.BottomRight1:
                case TDData.BottomLeft1:
                case TDData.LeftBottom3:
                case TDData.RightDown3:
                case TDData.Crossing4:
                    spriteEnnemy.NextAfterBox = new Vector2(spriteEnnemy.NextBox.X, spriteEnnemy.NextBox.Y + 1);
                    return;
                case TDData.BottomRight2:
                case TDData.BottomRight2bis:
                case TDData.Crossing1:
                case TDData.Crossing2:
                case TDData.Crossing3:
                    // we have to turn right or left
                    spriteEnnemy.nextAfterDestination = TDData.eDirection.Right;
                    spriteEnnemy.NextAfterBox = new Vector2(spriteEnnemy.NextBox.X, spriteEnnemy.NextBox.Y + 1);
                    return;
                case TDData.BottomLeft2:
                    spriteEnnemy.nextAfterDestination = TDData.eDirection.Left;
                    spriteEnnemy.NextAfterBox = new Vector2(spriteEnnemy.NextBox.X, spriteEnnemy.NextBox.Y + 1);
                    return;
                case TDData.StonePath:
                    if (!spriteEnnemy.IsFlying)
                    {
                        Debug.WriteLine(BoxToCheck(currentScene, spriteEnnemy, TDData.eDirection.Right));
                    }
                        if (spriteEnnemy.IsFlying)
                    {
                        spriteEnnemy.NextAfterBox = new Vector2(spriteEnnemy.NextBox.X, spriteEnnemy.NextBox.Y + 1);
                        return;
                    }
                    break;
                case TDData.HorizontalBridge2:
                    if (!spriteEnnemy.IsFlying)
                    {
                        spriteEnnemy.NextAfterBox = new Vector2(spriteEnnemy.NextBox.X, spriteEnnemy.NextBox.Y + 1);
                        return;
                    }
                    break;
                default:
                    break;
            }
            if (TDData.Data[spriteEnnemy.ennemyID].isPreferredDirectionLeft)
                switch (BoxToCheck(currentScene, spriteEnnemy, TDData.eDirection.Right))
                {
                    case TDData.Crossing1:
                    case TDData.Crossing2:
                    case TDData.Crossing3:
                    case TDData.HorizontalPath:
                    case TDData.HorizontalPathBis:
                        spriteEnnemy.nextDestination = TDData.eDirection.Right;
                        spriteEnnemy.nextAfterDestination = TDData.eDirection.Right;
                        spriteEnnemy.NextAfterBox = new Vector2(spriteEnnemy.NextBox.X + 1, spriteEnnemy.NextBox.Y);
                        return;
                    case TDData.StonePath:
                        if (spriteEnnemy.IsFlying)
                        {
                            spriteEnnemy.nextAfterDestination = TDData.eDirection.Right;
                            spriteEnnemy.NextAfterBox = new Vector2(spriteEnnemy.NextBox.X + 1, spriteEnnemy.NextBox.Y);
                            return;
                        }
                        break;
                    case TDData.VerticalBridge1:
                        if (!spriteEnnemy.IsFlying)
                        {
                            spriteEnnemy.nextAfterDestination = TDData.eDirection.Right;
                            spriteEnnemy.NextAfterBox = new Vector2(spriteEnnemy.NextBox.X + 1, spriteEnnemy.NextBox.Y);
                            return;
                        }
                        break;
                    default:
                       break;
                }
            switch (BoxToCheck(currentScene, spriteEnnemy, TDData.eDirection.Left))
            {
                case TDData.Crossing1:
                case TDData.Crossing2:
                case TDData.Crossing3:
                case TDData.HorizontalPath:
                case TDData.HorizontalPathBis:
                    spriteEnnemy.nextAfterDestination = TDData.eDirection.Left;
                    spriteEnnemy.NextAfterBox = new Vector2(spriteEnnemy.NextBox.X - 1, spriteEnnemy.NextBox.Y);
                    return;
                case TDData.StonePath:
                    if (spriteEnnemy.IsFlying)
                    {
                        spriteEnnemy.nextAfterDestination = TDData.eDirection.Left;
                        spriteEnnemy.NextAfterBox = new Vector2(spriteEnnemy.NextBox.X - 1, spriteEnnemy.NextBox.Y);
                    }
                    break;
                case TDData.VerticalBridge2: // modif
                    if (!spriteEnnemy.IsFlying)
                    {
                        spriteEnnemy.nextAfterDestination = TDData.eDirection.Left;
                        spriteEnnemy.NextAfterBox = new Vector2(spriteEnnemy.NextBox.X - 1, spriteEnnemy.NextBox.Y);
                    }
                    break;
                default:
                    spriteEnnemy.nextDestination = TDData.eDirection.Right;
                    spriteEnnemy.nextAfterDestination = TDData.eDirection.Right;
                    spriteEnnemy.NextAfterBox = new Vector2(spriteEnnemy.NextBox.X + 1, spriteEnnemy.NextBox.Y);
                    break;
            }
        }
        public static void NextAfterBox(SceneMap currentScene,SpriteEnnemy spriteEnnemy)
        {           
            switch (spriteEnnemy.nextDestination)
            {
                case TDData.eDirection.Left:
                    NextDestinationLeft(currentScene, spriteEnnemy);
                    break;
                case TDData.eDirection.Right:
                    NextDestinationRight(currentScene, spriteEnnemy);
                    break;
                case TDData.eDirection.Up:
                    NextDestinationUp(currentScene, spriteEnnemy);
                    break;
                case TDData.eDirection.Botton:
                    NextDestinationBotton(currentScene, spriteEnnemy);
                    break;
                default:
                    break;
            }
        }
        public static void EnnemyArrival(SpriteEnnemy spriteEnnemy)
        {
            switch (spriteEnnemy.nextDestination)
            {
                case TDData.eDirection.Left: // à vérifier
                    if (spriteEnnemy.position.X <= (spriteEnnemy.CurrentBox.X + 1) * TDData.BoxWidth - TDData.BoxWidth / 2)
                    {
                        Debug.WriteLine("spriteEnnemy.Arrival: " + spriteEnnemy.CurrentBox.ToString());
                        spriteEnnemy.ennemyVelocity = new Vector2();
                        spriteEnnemy.IsArrived = true;
                        return;
                    }
                        break;
                case TDData.eDirection.Right:
                    if (spriteEnnemy.position.X >= spriteEnnemy.CurrentBox.X * TDData.BoxWidth + TDData.BoxWidth / 2)
                    {
                        Debug.WriteLine("spriteEnnemy.Arrival: " + spriteEnnemy.CurrentBox.ToString());
                        spriteEnnemy.ennemyVelocity = new Vector2();
                        spriteEnnemy.IsArrived = true;
                        return;
                    }
                    break;
                case TDData.eDirection.Up:
                    
                    break;
                case TDData.eDirection.Botton:
                    
                    break;
                default:
                    break;
            }
        }
        public static float AngleRadian(Vector2 velocity)
        {
            float rotation = 0f;
            if (velocity.X == 0 && velocity.Y == 0) return 0f;
            if (velocity.X > 0 && velocity.Y == 0) return (float)Math.PI / 2;
            if (velocity.X < 0 && velocity.Y == 0) return (float)Math.Atan(velocity.X / velocity.Y);
            if (velocity.X == 0 && velocity.Y > 0) return (float)Math.PI;
            if (velocity.X == 0 && velocity.Y < 0) return 0f;
            if (velocity.X > 0 && velocity.Y > 0) return (float)Math.Atan(velocity.X / velocity.Y) * -1 + (float)Math.PI;
            if (velocity.X < 0 && velocity.Y > 0) return (float)Math.Atan(velocity.X / velocity.Y) * -1 + (float)Math.PI;
            if (velocity.X > 0 && velocity.Y < 0) return (float)Math.Atan(velocity.X / velocity.Y) * -1;
            if (velocity.X < 0 && velocity.Y < 0) return (float)Math.Atan(velocity.X / velocity.Y) * -1;
            return rotation;
        }
        public static Vector2 VelocityAngleSpeed(float angleDegree, float speed)
        {
            float angleRadian = MathHelper.ToRadians(angleDegree + 270);
            float forceX = (float)Math.Cos(angleRadian) * speed;
            float forceY = (float)Math.Sin(angleRadian) * speed;
            Vector2 velocity = new Vector2(forceX, forceY);
            return velocity;
        }
        public static Vector2 originePositionMissile(Vector2 position, Vector2 velocity, String missileID)
        {
            float angleRadian = AngleRadian(velocity);
            float offsetX = (float)Math.Sin(angleRadian) * TDData.Data[missileID].offsetMissileWeapon * -1;
            float offsetY = (float)Math.Cos(angleRadian) * TDData.Data[missileID].offsetMissileWeapon;

            Vector2 positionMissile = new Vector2(position.X + offsetX, position.Y + offsetY);
            return positionMissile;
        }

        public static Rectangle TextureFrameRectangle(SpriteEnnemy spriteEnnemy)
        {
            string ennemyID = spriteEnnemy.ennemyID;
            Texture2D texture = TDTextures.Textures[TDData.Data[ennemyID].NameTexture];
            int frameNumber = spriteEnnemy.frame;
            int framesNumber = TDData.Data[ennemyID].ArrayFrames.Length;
            int frameWidth = TDData.Data[ennemyID].FrameWidth;
            int frameHeight = TDData.Data[ennemyID].FrameHeight;
            int initOffsetY = TDData.Data[ennemyID].InitOffsetY;
            int left = frameNumber * frameWidth;
            int right = frameNumber * frameWidth + frameWidth;
            int top = initOffsetY;
            int bottom = initOffsetY + frameHeight;
            return new Rectangle();
        }

        public static float OutOfRange(SpriteWeapon spriteWeapon)
        {
            float outOfRange = TDData.Data[spriteWeapon.ID].maxDistance;
            string tower = "TOWER" + spriteWeapon.weaponType + spriteWeapon.towerLevel.ToString();
            outOfRange += TDData.Data[tower].maxDistanceTower;
            return outOfRange;
        }

        public static int AngleMissileEnnemy(SpriteMissile spriteMissile)
        {
            float angleRadian = AngleRadian(new Vector2(spriteMissile.spriteEnnemy.position.X - spriteMissile.position.X,
                            spriteMissile.spriteEnnemy.position.Y - spriteMissile.position.Y));
            int angleDegree = (int)MathHelper.ToDegrees(angleRadian);
            return angleDegree;
        }

        public static int AngleWeaponEnnemy(SpriteWeapon spriteWeapon)
        {
            float angleRadian = AngleRadian(new Vector2(spriteWeapon.spriteEnnemy.position.X - spriteWeapon.position.X,
                            spriteWeapon.spriteEnnemy.position.Y - spriteWeapon.position.Y));
            int angleDegree = (int)MathHelper.ToDegrees(angleRadian);           
            return angleDegree;
        }

        public static float EnnemyDistanceFromWeapon(SpriteWeapon spriteWeapon, SpriteEnnemy spriteEnnemy)
        {
            float ennemyDistanceFromWeapon =
                (float)Math.Sqrt(Math.Pow(Math.Abs(spriteWeapon.position.X - spriteEnnemy.position.X), 2) +
                    Math.Pow(Math.Abs(spriteWeapon.position.Y - spriteEnnemy.position.Y), 2));
            // vérifier si angle est ok à faire
            float angleRadian = AngleRadian(new Vector2(spriteEnnemy.position.X - spriteWeapon.position.X,
                            spriteEnnemy.position.Y - spriteWeapon.position.Y));
            int angleDegree = (int)MathHelper.ToDegrees(angleRadian);
            if (((Math.Abs(angleDegree) + spriteWeapon.angleSelected) % 360) < TDData.Data[spriteWeapon.ID].maxAngle) 
            {
                spriteWeapon.spriteEnnemy = spriteEnnemy;
                return ennemyDistanceFromWeapon; 
            }
        return Tools.OutOfRange(spriteWeapon);
        }

        public static BoundingBox GetNonTransparentBoundingBox(Texture2D texture, Vector3 position, SpriteEnnemy spriteEnnemy = null)
        {
            string ennemyID = spriteEnnemy.ennemyID;
            Color[] colorData = new Color[texture.Width * texture.Height];
            texture.GetData(colorData);

            int startLeft = spriteEnnemy.frame * TDData.Data[ennemyID].FrameWidth;
            int startRight = spriteEnnemy.frame * TDData.Data[ennemyID].FrameWidth + TDData.Data[ennemyID].FrameWidth;
            int startTop = TDData.Data[ennemyID].InitOffsetY + TDData.Data[ennemyID].FrameWidth;
            int startBottom = TDData.Data[ennemyID].InitOffsetY;

            int left = startLeft;
            int right = startRight;
            int top = startTop;
            int bottom = startBottom;

            for (int y = startBottom; y < startTop; y++)
            {
                for (int x = startLeft; x < startRight; x++)
                {
                    Color color = colorData[x + y * TDData.Data[ennemyID].FrameWidth];

                    if (color.A != 0)
                    {
                        if (x < left) left = x;
                        if (x > right) right = x;
                        if (y < top) top = y;
                        if (y > bottom) bottom = y;
                    }
                }
            }

            Vector3 min = new Vector3(position.X + left, position.Y + top, position.Z);
            Vector3 max = new Vector3(position.X + right, position.Y + bottom, position.Z);

            return new BoundingBox(min, max);
        }
        


    }
}
