using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tower_Defense.Animation
{
    public enum EDirection
    {
        None,Left, Right, Top, Bottom
    }
    public class TDAnimation
    {
        public string name { get; private set; }
        public int[] frames { get; private set; }
        public float dureeFrame { get; private set; }
        public bool isLoop { get; set; }
        public bool isFinished { get; set; }
        public int decalageX { get; private set; }
        public int initDecalageX { get; private set; }

        public int decalageY { get; private set; }
        public EDirection direction { get; private set; }
        public TDAnimation(string pName, int[] pFrames, float pTime = 1f / 12f, int pdecalageX = 0, int pdecalageY = 0, bool pisLoop = true, int pInitDecalageX = 0)
        {
            name = pName;
            frames = pFrames;
            dureeFrame = pTime;
            isLoop = pisLoop;
            isFinished = false;
            decalageX = pdecalageX;
            decalageY = pdecalageY;
            direction = EDirection.None;
            this.initDecalageX = pInitDecalageX;
        }
    }
    public class TDSprite
    {
        //protected Game mainGame;
        public float spriteX { get; set; }
        public float spriteY { get; set; }
        public Vector2 velocity { get; set; }  
        public bool isSpeedUp;
        public bool isPaused;
        public bool isVisible { get; set; }
        public bool isCentered { get; set; }
        public float zoom { get; set; }
        public float rotation { get; set; }
        public Dictionary<string, string> properties { get; }
        public SpriteBatch spriteBatch { get; }
        public Texture2D texture { get; }
        public List<TDAnimation> animations;
        public TDAnimation animationCourante;
        protected SpriteEffects effect;
        public int frame { get; private set; }
        public int largeurFrame { get; private set; }
        public int hauteurFrame { get; private set; }
        public float speed { get; set; }
        private float time;
        public int decalageX;
        public int decalageY;
        public int initDecalageX;
        static public List<TDSprite> lstSprites = new List<TDSprite>();
        public bool ToRemove { get; set; }
        public Game mainGame;
             
        public TDSprite(Game pGame, SpriteBatch pSpriteBatch, Texture2D pTexture, int pFrameWidth, int pFrameHeight, int pDecalageX, int pDecalageY, Vector2 pVelocity, int pInitDecalageX)
        {
            mainGame = pGame;
            spriteBatch = pSpriteBatch;
            texture = pTexture;
            isVisible = true;
            isCentered = true;
            frame = 0;
            largeurFrame = pFrameWidth;
            hauteurFrame = pFrameHeight;
            rotation = 0f;
            zoom = 1.0f;
            speed = 60.0f;
            effect = SpriteEffects.None;
            animations = new List<TDAnimation>();
            lstSprites.Add(this);
            properties = new Dictionary<string, string>();            
            velocity = pVelocity;
            decalageX = pDecalageX;
            decalageY = pDecalageY;
            initDecalageX = pInitDecalageX;
        }
        static public void DrawAll(GameTime pGametime)
        {
            foreach (var sprite in TDSprite.lstSprites)
            {
                sprite.Draw(pGametime);
            }
        }

        static public void UpdateAll(GameTime pGametime)
        {
            foreach (var sprite in TDSprite.lstSprites)
            {
                sprite.Update(pGametime);
            }
        }
        public string getProperty(string pName)
        {
            if (properties.ContainsKey(pName))
            {
                return properties[pName];
            }
            return "";
        }

        public void AjouteAnimation(string pName, int[] pFrames, float pDureeFrame, int pDecalageX, int pDecalageY, bool pisLoop = true, int pinitDecalageX = 0)
        {
            TDAnimation animation = new TDAnimation(pName, pFrames, pDureeFrame, pDecalageX, pDecalageY, pisLoop, pinitDecalageX);
            animations.Add(animation);
        }

        public void LanceAnimation(string pName)
        {
            //Debug.WriteLine("LanceAnimation({0})", pName);
            foreach (TDAnimation element in animations)
            {
                if (element.name == pName)
                {
                    animationCourante = element;
                    frame = 0;
                    animationCourante.isFinished = false;
                    //Debug.WriteLine("LanceAnimation, OK {0}", animationCourante.name);
                    break;
                }
            }
            Debug.Assert(animationCourante != null, "LanceAnimation : Aucune animation trouvée");
        }

        public virtual void Update(GameTime gameTime)
        {
               
            if (isPaused) return;
            this.spriteX += this.velocity.X * (float)gameTime.ElapsedGameTime.TotalSeconds;
            this.spriteY += this.velocity.Y * (float)gameTime.ElapsedGameTime.TotalSeconds;
           
                                     
            // Traitement des animations image par image
            if (animationCourante == null) return;
            if (animationCourante.dureeFrame == 0) return;
            if (animationCourante.isFinished) return;
            time += (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (time > animationCourante.dureeFrame)
            {
                frame++;
                if (frame >= animationCourante.frames.Count())
                {
                    if (animationCourante.isLoop)
                    {
                        frame = 0;
                    }
                    else
                    {
                        frame--;
                        animationCourante.isFinished = true;
                    }
                }
                time = 0;
            }
        }

        public virtual void Draw(GameTime gameTime)
        {
            if (!isVisible) return;
            
                int calculDecalage = largeurFrame;
                Rectangle source = new Rectangle(0, 0, 0, 0);
            if (animationCourante.decalageX > 0)
            {
                calculDecalage = animationCourante.frames[frame] * animationCourante.decalageX;

                source = new Rectangle(animationCourante.initDecalageX + calculDecalage,
                 animationCourante.decalageY, largeurFrame, hauteurFrame);
            }
            else
            {
                source = new Rectangle(animationCourante.frames[frame] * largeurFrame,
                  animationCourante.decalageY, largeurFrame, hauteurFrame);
            }
            
            Vector2 origine = new Vector2(0, 0);
            if (isCentered)
            {
                origine = new Vector2(largeurFrame / 2, hauteurFrame / 2);
            }
            
            Vector2 position = new Vector2(spriteX, spriteY);

            spriteBatch.Draw(texture, position, source, Color.White, rotation, origine, zoom, effect, 0.0f);
        }
    }
}
