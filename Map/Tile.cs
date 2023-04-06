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
        public void Load(Texture2D pTexture, int pLargeurFrame, int pHauteurFrame, int pDecalageX, int pDecalageY, Vector2 pVelocity, int pInitDecalageX = 0);
    }
    public class Tile : ITiles
    {
        public Texture2D _texture { get; private set; }
        public int _largeurFrame;
        public int _hauteurFrame;
        public int _decalageX;
        public int _decalageY;
        public int _initDecalageX;
        public Vector2 _position { get; private set; }
        public Vector2 _positionTileset { get; private set; } //line, column
        public int _tileFrame;
        public Rectangle _rectangleTileset { get; private set; }
        public Rectangle _rectangleMap { get; private set; }
        public ETypeTexture _typeTexture { get; private set; }
        public Vector2 _velocity { get; private set; }
        public Tile(Texture2D texture, Vector2 position, int tileFrame, Vector2 positionTileset, Rectangle rectangleMap)
        {
            _texture = texture;
            _position = position;
            _tileFrame = tileFrame;
            _positionTileset = _positionTileset;
            _rectangleMap = rectangleMap;
        }
        public void Update(Texture2D texture, Vector2 velocity)
        {
            _texture = texture;
            _velocity = velocity;
            _position += velocity;
            _rectangleMap = new Rectangle(_rectangleMap.X + (int)velocity.X, (_rectangleMap.Y + (int)velocity.Y), _rectangleMap.Width, _rectangleMap.Height);
        }

        public void Load(Texture2D pTexture, int pLargeurFrame, int pHauteurFrame, int pDecalageX, int pDecalageY, Vector2 pVelocity, int pInitDecalageX = 0)
        {
            _texture = pTexture;
            _largeurFrame = pLargeurFrame;
            _hauteurFrame = pHauteurFrame;
            _decalageX = pDecalageX;
            _decalageY = pDecalageY;
            _velocity = pVelocity;
            _initDecalageX = pInitDecalageX;
        }
    }
}
