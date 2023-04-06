using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

using System.Text;
using System.Threading.Tasks;
using tower_Defense.Animation;
using tower_Defense.Utils;

namespace tower_Defense.Buttons
{
    public class BUTTONAnimation
    {
        public string name { get; private set; }
        public int[] frames { get; private set; }
        public float dureeFrame { get; private set; }
        public bool isLoop { get; set; }
        public bool isFinished { get; set; }
        public int initOffsetX { get; private set; }
        public int initOffsetY { get; private set; }

        public int decalageY { get; private set; }
        public BUTTONAnimation(string pName, int[] pFrames, float pTime = 1f / 12f, int pInitOffsetX = 0, int pInitOffsetY = 0, bool pisLoop = true)
        {
            name = pName;
            frames = pFrames;
            dureeFrame = pTime;
            isLoop = pisLoop;
            isFinished = false;
            initOffsetX = pInitOffsetX;
            initOffsetY = pInitOffsetY;   
        }
    }
    public class SpriteButton : IActorButton
    {
        //IActor
        public string ButtonID { get; private set; }
        public Vector2 Position { get; set; }
        public Rectangle BoundingBox { get; private set; }
        public Rectangle TextureBox { get; set; }
        public float velovityX;
        public float velovityY;
        //Sprite
        public Texture2D texture { get; }
        public int offsetTextureX { get; }
        public int offsetTextureY { get; }
        public int widthTexture { get; }
        public int heightTexture { get; }

        public bool isFrame;


        public Dictionary<string, string> properties { get; }
        public SpriteBatch spriteBatch { get; }
        public List<BUTTONAnimation> animations;
        public BUTTONAnimation animationCourante;
        public int frame { get; private set; }
        public int frameWidth { get; private set; }
        public int frameHeight { get; private set; }
        public float speed { get; set; }
        private float time;
        public int decalageX;
        public int decalageY;
        public int initDecalageX;
        static public List<SpriteButton> lstButtonSprites = new List<SpriteButton>();


        public bool ToRemove { get; set; }
        public float scale { get; set; }
    public SpriteButton(string buttonID, Vector2 position)
        {
            ButtonID = buttonID;
            Position = position;            
            scale = ButtonGUI.Data[buttonID].Scale;
            Debug.WriteLine("scale : " + scale);
            texture = GUITextures.Textures[ButtonGUI.Data[buttonID].NameTexture];

            switch (ButtonGUI.Data[buttonID].buttonAnimation)
            {
                case ButtonGUI.eButtonAnimation.None:
                    widthTexture = ButtonGUI.Data[buttonID].FrameWidth;
                    heightTexture = ButtonGUI.Data[buttonID].FrameHeight;                    
                    BoundingBox = new Rectangle(
                        (int)Position.X,
                        (int)Position.Y,
                        widthTexture,
                        heightTexture);
                    TextureBox =
                      new Rectangle(
                         0,
                         0,
                         widthTexture,
                         heightTexture);
                    break;
                case ButtonGUI.eButtonAnimation.UseTileset:
                    offsetTextureX = ButtonGUI.Data[buttonID].InitOffsetX;
                    offsetTextureY = ButtonGUI.Data[buttonID].InitOffsetY;
                    widthTexture = ButtonGUI.Data[buttonID].FrameWidth;
                    heightTexture = ButtonGUI.Data[buttonID].FrameHeight;
                    BoundingBox = new Rectangle(
                        (int)Position.X,
                        (int)Position.Y,
                        (int)(ButtonGUI.Data[buttonID].FrameWidth* ButtonGUI.Data[buttonID].Scale),
                        (int)(ButtonGUI.Data[buttonID].FrameHeight * ButtonGUI.Data[buttonID].Scale));
                    TextureBox =  new Rectangle(
                         offsetTextureX,
                         offsetTextureY,
                         widthTexture,
                         heightTexture);
                    break;
                case ButtonGUI.eButtonAnimation.UseFrames:
                    frameWidth = ButtonGUI.Data[buttonID].FrameWidth;
                    frameHeight = ButtonGUI.Data[buttonID].FrameHeight;
                    offsetTextureX = ButtonGUI.Data[buttonID].InitOffsetX;
                    offsetTextureY = ButtonGUI.Data[buttonID].InitOffsetY;
                    widthTexture = ButtonGUI.Data[buttonID].FrameWidth;
                    heightTexture = ButtonGUI.Data[buttonID].FrameHeight;
                    BoundingBox = new Rectangle(
                        (int)position.X,
                        (int)position.Y,
                        ButtonGUI.Data[buttonID].FrameWidth,
                        ButtonGUI.Data[buttonID].FrameHeight);
                    TextureBox = new Rectangle(
                         ButtonGUI.Data[buttonID].InitOffsetX,
                         ButtonGUI.Data[buttonID].InitOffsetY,
                         ButtonGUI.Data[buttonID].FrameWidth,
                         ButtonGUI.Data[buttonID].FrameHeight);
                    isFrame = true;
                    animations = new List<BUTTONAnimation>();
                    lstButtonSprites.Add(this);
                    properties = new Dictionary<string, string>();
                    
                    AddAnimation("bouton", ButtonGUI.Data[buttonID].ButtonFrames,
                    ButtonGUI.Data[buttonID].ButtonFramesLenght,
                    ButtonGUI.Data[buttonID].InitOffsetX,
                    ButtonGUI.Data[buttonID].InitOffsetY,
                    ButtonGUI.Data[buttonID].IsLoop);  
                    break;
                case ButtonGUI.eButtonAnimation.UseAnimation:
                    BoundingBox = new Rectangle(
                        (int)Position.X,
                        (int)Position.Y,
                        texture.Width,
                        texture.Height);
                    offsetTextureX = 0;
                    offsetTextureY = 0;
                    widthTexture = texture.Width;
                    heightTexture = texture.Height;
                    TextureBox = new Rectangle(0, 0, texture.Width, texture.Height);
                    break;
                default:
                    break;
            }
        }

        static public void DrawAll(SpriteBatch spriteBatch)
        {
            foreach (var sprite in SpriteButton.lstButtonSprites)
            {
                sprite.Draw(spriteBatch);
            }
        }

        static public void UpdateAll(GameTime pGametime)
        {
            foreach (var sprite in SpriteButton.lstButtonSprites)
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

        public void AddAnimation(string pName, int[] pFrames, float pDureeFrame, int initOffsetX, int initOffsetY, bool pisLoop = true)
        {
            BUTTONAnimation animation = new BUTTONAnimation(pName, pFrames, pDureeFrame, initOffsetX, initOffsetY, pisLoop);
            animations.Add(animation);
            RunAnimation(pName);
        }

        public void RunAnimation(string pName)
        {
            //Debug.WriteLine("LanceAnimation({0})", pName);
            foreach (BUTTONAnimation element in animations)
            {
                if (element.name == pName)
                {
                    animationCourante = element;
                    frame = 0;
                    animationCourante.isFinished = false;
                    //Debug.WriteLine("Button LanceAnimation, OK {0}" + animationCourante.name);
                    break;
                }
            }
            Debug.Assert(animationCourante != null, "LanceAnimation : Aucune animation trouvée");
        }

        public virtual void Update(GameTime gameTime)
        {
            if (isFrame)
            {
                if (animationCourante == null) return;
                if (animationCourante.dureeFrame == 0) return;
                if (animationCourante.isFinished) return;
                time += (float)gameTime.ElapsedGameTime.TotalSeconds;
                if (time > animationCourante.dureeFrame)
                {
                    TextureBox = new Rectangle(animationCourante.frames[frame] * frameWidth,
                 offsetTextureY, frameWidth, frameHeight);
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
        }
        public virtual void Draw(SpriteBatch spriteBatch)
        {
            if (isFrame)
            {
                
               /* TextureBox = new Rectangle(animationCourante.frames[frame] * frameWidth,
                  animationCourante.initOffsetY, frameWidth, frameHeight);*/
                spriteBatch.Draw(texture, Position, TextureBox, Color.White, 0f,
                    new Vector2(0, 0), 1, SpriteEffects.None, 0.0f);
            }
            else
            {
                float rotation = 0f;
                Vector2 origine = new Vector2(0, 0);
                if (scale != 0)
                spriteBatch.Draw(texture, Position, TextureBox, Color.White, rotation, origine, scale, SpriteEffects.None, 0.0f);
                else
                    spriteBatch.Draw(texture, Position, TextureBox, Color.White, rotation, origine, 1, SpriteEffects.None, 0.0f);

            }
        }
    }
}
