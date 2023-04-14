using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tower_Defense.Utils;
namespace tower_Defense.Buttons
{
    public interface IActorButton
    {
        string buttonID { get; }
        Vector2 position { get; }
        Rectangle boundingBox { get; }
        bool ToRemove { get; set; }
        void Update(GameTime gameTime);
        void Draw(GameTime gameTime);      
    }
}