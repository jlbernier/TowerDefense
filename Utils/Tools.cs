using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tower_Defense.Utils
{
    public class Tools
    {

        public Tools() { }

        public float AngleRadian(Vector2 velocity)
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
        public Vector2 VelocityAngleSpeed(float angleDegree, float speed)
        {
            float angleRadian = MathHelper.ToRadians(angleDegree + 270);
            float forceX = (float)Math.Cos(angleRadian) * speed;
            float forceY = (float)Math.Sin(angleRadian) * speed;
            Vector2 velocity = new Vector2(forceX, forceY);
            return velocity;
        }
        public Vector2 originePositionMissile(Vector2 position, Vector2 velocity, String missileID)
        {
            Tools tools = new Tools();
            float angleRadian = tools.AngleRadian(velocity);
            float offsetX = (float)Math.Sin(angleRadian) * TDData.Data[missileID].offsetMissileWeapon * -1;
            float offsetY = (float)Math.Cos(angleRadian) * TDData.Data[missileID].offsetMissileWeapon;

            Vector2 positionMissile = new Vector2(position.X + offsetX, position.Y + offsetY);
            return positionMissile;
        }
    }
}
