using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using tower_Defense;
using tower_Defense.Map;
using tower_Defense.Scenes;


namespace TowerDefence
{
    public class TowerUpgrade : Controller
    {
        public  bool OnHover()
        {
            return true;
        }

        public override void DrawGUI()
        {
            foreach (Tile tile in MapTiled.lstTilesTowers)
            {
                Vector2 towerPosition = new Vector2(tile._position.X, tile._position.Y);
                //if (!OnHover(tile))
                {
                    MainGame.spriteBatch.Draw(TDTextures.Textures[TDData.Data["TOWERBASE"].NameTexture], towerPosition, Color.White);
                }
            }
        }
        

        public override void CheckClic(MainGame mainGame)
        {
           
        }

        

        public override void Update()
        {
        }
    }
}




