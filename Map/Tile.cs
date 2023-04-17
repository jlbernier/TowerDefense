using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace tower_Defense.Map
{
    public enum ETypeTexture // à developper pour animer des feuilles qui volent, des oiseaux, etc;
    {
        fixe,
        spriteFixe,
        spriteMove
    }
    public interface ITiles
    {
        public void Update(Texture2D texture, Vector2 velocity);
        public void Load(Texture2D texture, int frameWidth, int frameHeight, int offsetX, int offsetY, Vector2 velocity, int initOffsetX = 0);
    }
    public class Tile : ITiles
    {
        public Texture2D texture { get; private set; }
        public int frameWidth;
        public int frameHeight;
        public int offsetX;
        public int offsetY;
        public int initOffsetX;
        public int initOffsetY;
        public Vector2 _position { get; private set; }
        public Vector2 _positionTileset { get; private set; } //line, column
        public int _tileFrame;
        public Rectangle _rectangleTileset { get; private set; }
        public Rectangle _rectangleMap { get; private set; }
        public ETypeTexture _typeTexture { get; private set; }
        public Vector2 _velocity { get; private set; }
        public Tile(Texture2D texture, Vector2 position, int tileFrame, Vector2 positionTileset, Rectangle rectangleMap)
        {
            this.texture = texture;
            _position = position;
            _tileFrame = tileFrame;
            _positionTileset = _positionTileset;
            _rectangleMap = rectangleMap;
        }
        public void Update(Texture2D texture, Vector2 velocity)
        {
            this.texture = texture;
            _velocity = velocity;
            _position += velocity;
            _rectangleMap = new Rectangle(_rectangleMap.X + (int)velocity.X, (_rectangleMap.Y + (int)velocity.Y), _rectangleMap.Width, _rectangleMap.Height);
        }

        public void Load(Texture2D texture, int frameWidth, int frameHeight, int offsetX, int offsetY, Vector2 velocity, int initOffsetX = 0)
        {
            this.texture = texture;
            this.frameWidth = frameWidth;
            this.frameHeight = frameHeight;
            this.offsetX = offsetX;
            this.offsetY = offsetY;
            _velocity = velocity;
            this.initOffsetX = initOffsetX;
        }
    }
}
