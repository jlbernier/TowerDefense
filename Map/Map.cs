using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using TiledSharp;
using tower_Defense.Animation;

namespace tower_Defense.Map
{
    public interface IMap
    {
        public void RegisterTile(ITiles tile);
        public void RemoveTile(ITiles tile);
        public void NotifyTiles();
    }
    public class MapTiled : IMap
    {
        private static int DECALAGEX = 448; // décalage tileset Animated water tiles
        private TmxMap map;
        private Texture2D tileset;
        private List<Texture2D> lstTilesets = new List<Texture2D>();
        private List<int> lstTilesetsGrid = new List<int>();
        int tileWidth;
        int tileHeight;
        private int mapWidth;
        int mapHeight;
        int tilesetColumns;
        int tilesetLines;
        public List<ITiles> lstTiles = new List<ITiles>();
        public List<ITiles> lstTilesAnimated = new List<ITiles>();
        public List<ITiles> lstTilesTower = new List<ITiles>();
        protected MainGame mainGame;
        public MapTiled(MainGame mainGame) : base() { this.mainGame = mainGame; }

        public void LoadMap()
        {
            mainGame.IsMouseVisible = true;
            map = new TmxMap("Content/myMap.tmx");
            foreach (TmxTileset tmxTileset in map.Tilesets)
            {
                lstTilesets.Add(mainGame.Content.Load<Texture2D>(tmxTileset.Name.ToString()));
                lstTilesetsGrid.Add(tmxTileset.FirstGid);
            }
            mapWidth = map.Width;
            mapHeight = map.Height;
          
            int nbLayers = map.Layers.Count;
            int nLayer = 0;
            bool isWater = false;
            bool isTower = false;
            foreach (TmxLayer layer in map.Layers)
            {
                if (layer.Visible)
                {
                    int line = 0, column = 0;
                    for (int i = 0; i < map.Layers[nLayer].Tiles.Count; i++)
                    {
                        int gid = map.Layers[nLayer].Tiles[i].Gid;
                        if (gid != 0)
                        {
                            int tileFrame = gid - 1;
                            int tilesetLine = 0;
                            int tilesetColumn = 0;
                            for (int indexGID = 1; indexGID < lstTilesetsGrid.Count; indexGID++)
                            {
                                isTower = (gid == 39)? true: false; 
                                if (gid < lstTilesetsGrid[indexGID])
                                {
                                    isWater = false;
                                    tileset = lstTilesets[indexGID - 1];
                                    tileWidth = map.Tilesets[indexGID - 1].TileWidth;
                                    tileHeight = map.Tilesets[indexGID - 1].TileHeight;
                                    tilesetLines = lstTilesets[indexGID - 1].Height / tileHeight;
                                    tilesetColumns = lstTilesets[indexGID - 1].Width / tileWidth;
                                }
                                else
                                {
                                    isWater = true;
                                    tileFrame -= lstTilesetsGrid[indexGID] - 1 ;
                                    tileset = lstTilesets[indexGID];
                                    tileWidth = map.Tilesets[indexGID].TileWidth; 
                                    tileHeight = map.Tilesets[indexGID].TileHeight; 
                                    tilesetLines = lstTilesets[indexGID].Height / tileHeight;
                                    tilesetColumns = lstTilesets[indexGID].Width / tileWidth; 
                                }
                            }
                            tilesetColumn = tileFrame % tilesetColumns;
                            tilesetLine =
                            (int)Math.Floor((double)tileFrame / (double)tilesetColumns);
                            float x = column * tileWidth;
                            float y = line * tileHeight;
                            Rectangle tilesetRec =
                            new Rectangle(
                            tileWidth * tilesetColumn,
                            tileHeight * tilesetLine,
                            tileWidth, tileHeight);          
                            Tile tile = new Tile(tileset, new Vector2(x, y), tileFrame,
                                                new Vector2(tilesetLine , tilesetColumn),
                                                tilesetRec);
                            if (isWater)
                            {
                                tile._initDecalageX = tileWidth * tilesetColumn;
                                tile._decalageX = DECALAGEX;
                                tile._decalageY = tileHeight * tilesetLine;
                                tile._largeurFrame = tileWidth;
                                tile._hauteurFrame = tileHeight;
                                RegisterTile(tile);
                            }
                            else
                            {
                                lstTiles.Add(tile);
                                if (isTower)
                                {
                                    lstTilesTower.Add(tile);
                                    isTower = false;
                                }
                            }
                        }
                        column++;
                        if (column == mapWidth)
                        {
                            column = 0;
                            line++;
                        }
                    }
                }
                nLayer++;
            }            
        }
        
        public void Load(SpriteBatch spriteBatch)
        {
            SpriteMap sprMap;
            foreach (Tile tile in lstTilesAnimated)
            {
                sprMap = new SpriteMap(mainGame, spriteBatch, tile._texture, tile._largeurFrame,
                    tile._hauteurFrame, 256, 0, new Vector2(0, 0), 0);
                sprMap.spriteX = tile._position.X;
                sprMap.spriteY = tile._position.Y;
                //lstEnnemies.Add(sprEnnemy);
                sprMap.AjouteAnimation("map", new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 }, 1f / 12f, tile._decalageX, tile._decalageY, true, tile._initDecalageX);
                sprMap.LanceAnimation("map");
            }
        }

        public void Update(GameTime gameTime)
        {
            foreach (Tile tile in lstTilesAnimated)
            {

            }
            NotifyTiles();
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (Tile tile in lstTiles)
            {
                spriteBatch.Draw(tile._texture, tile._position, tile._rectangleMap, Color.White);
            }          
        }

        public void RegisterTile(ITiles tile)
        {
            lstTilesAnimated.Add(tile);
        }

        public void RemoveTile(ITiles tile)
        {
            lstTilesAnimated.Remove(tile);
        }
        public void NotifyTiles()
        {
            foreach (ITiles tile in lstTilesAnimated)
            {
                
            }
        }

       
    }
}
