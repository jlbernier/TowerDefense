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
        Vector2 position { get; }
        string buttonID { get; }
        Rectangle boundingBox { get; }
        void Update(GameTime pGameTime);
        void Draw(SpriteBatch pSpriteBatch);      
        bool ToRemove { get; set; }
    }
}