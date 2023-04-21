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
using tower_Defense.Scenes;

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
        private static int OFFSETX = 448; // décalage tileset Animated water tiles
        private TmxMap map;
        private Texture2D tileset;
        private int indexTileset;
        public int[,] arrayPath { get; set; }
        private List<Texture2D> lstTilesets = new List<Texture2D>();
        private List<int> lstTilesetsGrid = new List<int>();
        int tileWidth;
        int tileHeight;
        private int mapWidth;
        private int mapHeight;
        int tilesetColumns;
        int tilesetLines;
        public List<ITiles> lstTilesGrass = new();
        public List<ITiles> lstTilesPath = new();
        public List<ITiles> lstTilesBridges = new();
        public List<ITiles> lstTilesTowers = new();
        public List<ITiles> lstTilesWater = new();
        public List<ITiles> lstTilesTreesAndStones = new ();
        public List<ITiles> lstTilesSartEnd = new();

        protected MainGame mainGame;
        public MapTiled(MainGame mainGame) : base() { this.mainGame = mainGame; }

        public void LoadMap()
        {
            mainGame.IsMouseVisible = true;
            map = new TmxMap("Content/Tilesets/myMap.tmx");
            arrayPath = new int[map.Width,map.Height];
            foreach (TmxTileset tmxTileset in map.Tilesets)
            {
                lstTilesets.Add(mainGame.Content.Load<Texture2D>("Tilesets/" + tmxTileset.Name.ToString()));
                lstTilesetsGrid.Add(tmxTileset.FirstGid);
            }

            mapWidth = map.Width;
            Debug.WriteLine(map.Layers[0].Name) ;
            mapHeight = map.Height;
          
            int nbLayers = map.Layers.Count;
            int nLayer = 0;
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
                            int tileFrame = gid;
                            indexTileset = 0;
                            int tilesetLine = 0;
                            int tilesetColumn = 0;
                            for (int indexGID = 0; indexGID < lstTilesetsGrid.Count -1; indexGID++)
                            {
                                if (gid <= lstTilesetsGrid[1])
                                {
                                    tileFrame -= 1;
                                    indexTileset = indexGID;
                                    break;
                                }
                                if (gid >= lstTilesetsGrid[lstTilesetsGrid.Count - 1])
                                {
                                    tileFrame = gid - lstTilesetsGrid[lstTilesetsGrid.Count - 1];
                                    indexTileset = lstTilesetsGrid.Count - 1;
                                    break;
                                }
                                if (gid >= lstTilesetsGrid[indexGID] && gid < lstTilesetsGrid[indexGID + 1])
                                {
                                    tileFrame = gid - lstTilesetsGrid[indexGID] ;
                                    indexTileset = indexGID;
                                    break;
                                }
                            }
                            tileset = lstTilesets[indexTileset];
                            tileWidth = map.Tilesets[indexTileset].TileWidth;
                            tileHeight = map.Tilesets[indexTileset].TileHeight;
                            tilesetLines = lstTilesets[indexTileset].Height / tileHeight;
                            tilesetColumns = lstTilesets[indexTileset].Width / tileWidth;
                            
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
                            if (map.Layers[nLayer].Name == "Water")
                            {
                                x += tileWidth / 2;
                                y += tileHeight / 2;
                            }
                            Tile tile = new Tile(tileset, new Vector2(x, y), tileFrame,
                                            new Vector2(tilesetLine , tilesetColumn),
                                            tilesetRec);
                            if (map.Layers[nLayer].Name == "Water")
                            {
                                tile.initOffsetX = tileWidth * tilesetColumn;
                                tile.initOffsetY = tileHeight * tilesetLine;
                                tile.offsetX = OFFSETX;
                                tile.offsetY = tileHeight * tilesetLine;
                                tile.frameWidth = tileWidth;
                                tile.frameHeight = tileHeight;
                                lstTilesWater.Add(tile);
                            }
                            else if (map.Layers[nLayer].Name == "Towers")
                            {
                                lstTilesTowers.Add(tile);

                            }
                            else if (map.Layers[nLayer].Name == "Path")
                            {
                                arrayPath[column,line] = gid;
                                lstTilesPath.Add(tile);
                            }
                            else if (map.Layers[nLayer].Name == "Bridges")
                            {
                                arrayPath[column, line] = gid;
                                lstTilesBridges.Add(tile);
                            }
                            else if (map.Layers[nLayer].Name == "Grass")
                            {
                                lstTilesGrass.Add(tile);
                            }
                            else if (map.Layers[nLayer].Name == "TreesAndStones")
                            {
                                arrayPath[column, line] = gid;
                                lstTilesTreesAndStones.Add(tile);
                            }
                            else if (map.Layers[nLayer].Name == "StartEnd")
                            {
                                arrayPath[column, line] = gid;
                                lstTilesSartEnd.Add(tile);
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
        public void Load(SceneMap currentScene)
        {
            SpriteMap sprMap;
            foreach (Tile tile in lstTilesWater)
            {
                sprMap = new SpriteMap(mainGame, tile._position, new Vector2(0, 0), "tileAnimated", tile);
                sprMap.position = tile._position;
                sprMap.isFrame = true;
                sprMap.AddAnimation("map", new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 }, 1f / 12f, tile.offsetX, tile.offsetY, true, tile.initOffsetX);
                sprMap.RunAnimation("map");
            }
        }

        public void Update(GameTime gameTime)
        {
            NotifyTiles();
        }
        public void Draw(SpriteBatch spriteBatch, List<ITiles> list)
        {
            foreach (Tile tile in list)
            {
               spriteBatch.Draw(tile.texture, tile._position, tile._rectangleMap, Color.White);
            }          
        }

        public void RegisterTileWater(ITiles tile)
        {
            lstTilesWater.Add(tile);
        }

        public void RegisterTile(ITiles tile)
        {
            lstTilesWater.Add(tile);
        }

        public void RemoveTile(ITiles tile)
        {
            lstTilesWater.Remove(tile);
        }
        public void NotifyTiles()
        {
            
        }

       
    }
}
