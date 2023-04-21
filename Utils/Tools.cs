using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
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

        public static Vector2 NewVelocity(SpriteEnnemy spriteEnnemy)
        {
            Vector2 velocity = new Vector2(0,0);
            if (spriteEnnemy.CurrentBox + new Vector2(1,0) == spriteEnnemy.NextBox)
            {
                if (spriteEnnemy.NextBox + new Vector2(0, -1) == spriteEnnemy.NextAfterBox)
                {
                    // right up
                    return new Vector2(1, -1);

                }
                if (spriteEnnemy.NextBox + new Vector2(1, 0) == spriteEnnemy.NextAfterBox)
                {
                    // right right
                    return new Vector2 (1, 0);
                }
                if (spriteEnnemy.NextBox + new Vector2(0, 1) == spriteEnnemy.NextAfterBox)
                {
                    // right bottom
                    return new Vector2(1, 0);

                }

            }

            return velocity;
        }

        public static Vector2 NextAfterBox(SceneMap currentScene,SpriteEnnemy spriteEnnemy)
        {
            int rightBox = (int)currentScene.map.arrayPath[(int)spriteEnnemy.NextBox.X + 1, (int)spriteEnnemy.NextBox.Y];
            int upBox = ((int)spriteEnnemy.NextBox.Y == 0) ? 0 :
                (int)currentScene.map.arrayPath[(int)spriteEnnemy.NextBox.X, (int)spriteEnnemy.NextBox.Y - 1];
            int downBox = ((int)spriteEnnemy.NextBox.Y == currentScene.map.arrayPath.GetLength(1)) ? 0 :
                (int)currentScene.map.arrayPath[(int)spriteEnnemy.NextBox.X, (int)spriteEnnemy.NextBox.Y + 1];
            Vector2 nextAfterBox = new Vector2();
            switch (spriteEnnemy.nextDestination)
            {
                case TDData.eDirection.None:
                    break;
                case TDData.eDirection.Left:
                    break;
                case TDData.eDirection.Right:
                     if (spriteEnnemy.currentDestination == TDData.eDirection.Right)
                    {
                        switch (rightBox)
                        {
                            case TDData.HorizontalPath:
                                return new Vector2(spriteEnnemy.NextBox.X + 1, spriteEnnemy.NextBox.Y);
                            case TDData.StonePath:
                                if (spriteEnnemy.IsFlying)
                                    return new Vector2(spriteEnnemy.NextBox.X + 1, spriteEnnemy.NextBox.Y);
                                if (spriteEnnemy.IsPreferredDirectionLeft && (upBox == TDData.VerticalPath || upBox == TDData.VerticalBridge1))
                                    return new Vector2(spriteEnnemy.NextBox.X, spriteEnnemy.NextBox.Y - 1);
                                return new Vector2(spriteEnnemy.NextBox.X, spriteEnnemy.NextBox.Y + 1);
                            default:
                                break;
                        }
                        Debug.WriteLine(currentScene.map.arrayPath[(int)spriteEnnemy.NextBox.X +1, (int)spriteEnnemy.NextBox.Y].ToString());
                    }
                    break;
                case TDData.eDirection.Up:
                    if (spriteEnnemy.currentDestination == TDData.eDirection.Up)
                        Debug.WriteLine(currentScene.map.arrayPath[(int)spriteEnnemy.NextBox.X + 1, (int)spriteEnnemy.NextBox.Y].ToString());
                    switch (upBox)
                    {
                        case TDData.VerticalPath:
                        case TDData.VerticalBridge2:
                        case TDData.UpRight:
                            return new Vector2(spriteEnnemy.NextBox.X, spriteEnnemy.NextBox.Y - 1);
                        case TDData.StonePath:
                            if (spriteEnnemy.IsFlying)
                                return new Vector2(spriteEnnemy.NextBox.X, spriteEnnemy.NextBox.Y -1); 
                            break;
                        case TDData.VerticalBridge1:
                            if (!spriteEnnemy.IsFlying)
                                return new Vector2(spriteEnnemy.NextBox.X, spriteEnnemy.NextBox.Y - 1);


                            // bridge pour volants à faire
                            break;
                        default:
                            break;
                    }



                    break;
                case TDData.eDirection.Botton:
                    break;
                default:
                    break;
            }

            return nextAfterBox;
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
