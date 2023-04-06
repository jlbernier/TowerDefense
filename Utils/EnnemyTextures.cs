using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tower_Defense.Utils
{
    public class EnnemyTextures
    {
        public static Dictionary<string, Texture2D> Textures = new Dictionary<string, Texture2D>();

        public static void PopulateTextures(Game mainGame)
        {
            Textures.Add("CLAMPBEETLE", mainGame.Content.Load<Texture2D>("ennemies/Clampbeetle"));
            Textures.Add("FIREBUG", mainGame.Content.Load<Texture2D>("ennemies/Firebug"));
            Textures.Add("FIREWASP", mainGame.Content.Load<Texture2D>("ennemies/Firewasp"));
            Textures.Add("FLYING_LOCUST", mainGame.Content.Load<Texture2D>("ennemies/Flying Locust"));
            Textures.Add("LEAFBUG", mainGame.Content.Load<Texture2D>("ennemies/Leafbug"));
            Textures.Add("MAGMA_CRAB", mainGame.Content.Load<Texture2D>("ennemies/Magma Crab"));
            Textures.Add("SCORPION", mainGame.Content.Load<Texture2D>("ennemies/Scorpion"));
            Textures.Add("VOIDBUTTERFLY", mainGame.Content.Load<Texture2D>("ennemies/Voidbutterfly"));
            
        }
    }
}
