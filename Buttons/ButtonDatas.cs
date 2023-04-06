using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static tower_Defense.Utils.Ennemy;
using tower_Defense.Utils;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using static tower_Defense.Buttons.ButtonGUI;
using System.Runtime.CompilerServices;

namespace tower_Defense.Buttons
{
    public class GUITextures
    {
        public static Dictionary<string, Texture2D> Textures = new Dictionary<string, Texture2D>();

        public static void PopulateTextures(Game mainGame)
        {
            Textures.Add("WEAPONTOWER1LEVEL1", mainGame.Content.Load<Texture2D>("Weapon/Tower 01 - Level 01 - Weapon"));
            Textures.Add("TOWERCONSTRUCTION", mainGame.Content.Load<Texture2D>("Misc/Tower Construction"));
            Textures.Add("TOWER1", mainGame.Content.Load<Texture2D>("Tower/Tower 01"));
            Textures.Add("BUTTON1", mainGame.Content.Load<Texture2D>("Button/button1"));
            Textures.Add("GUI WOODEN PIXEL ART", mainGame.Content.Load<Texture2D>("GUI/Wooden Pixel Art GUI 32x32"));
            Textures.Add("PLAY", mainGame.Content.Load<Texture2D>("Buttons/button"));
        }
    }


    public class ButtonGUIDatas
    {
        public string ID;
        public string NameTexture;
        public int FrameWidth;
        public int FrameHeight;
        public int InitOffsetX;
        public int InitOffsetY;
        public int OffsetSelectedX;
        public int OffsetSelectedY;
        public int OffsetPushX;
        public int OffsetPushY;
        public int OffsetX;
        public int OffsetY;
        public bool IsLoop;
        public int[] ButtonFrames;
        public float ButtonFramesLenght;
        public float Scale;
        public ButtonGUI.eButtonAnimation buttonAnimation;
        public ButtonGUIDatas() { }
    }

    public static class ButtonGUI
    {
        public enum eButtonAnimation
        {
            None,
            UseTileset,
            UseFrames,
            UseAnimation            
        }
        public static Dictionary<string, ButtonGUIDatas> Data = new Dictionary<string, ButtonGUIDatas>();

        public static void PopulateData()
        {
            Data.Add("WEAPONTOWER1LEVEL1", new ButtonGUIDatas
            {
                ID = "WeaponTower1Level1",
                NameTexture = "WEAPONTOWER1LEVEL1",
                FrameWidth = 96,
                FrameHeight = 96,
                ButtonFrames = new int[] { 0, 1, 2, 3, 4, 5 },
                ButtonFramesLenght = 8f / 12f,
                IsLoop = true,
                Scale = 1f,
                buttonAnimation = eButtonAnimation.UseFrames
            });
            Data.Add("TOWER11", new ButtonGUIDatas
            {
                ID = "Tower1",
                NameTexture = "TOWER1",
                FrameWidth = 64,
                FrameHeight = 128,
                InitOffsetX = 0,
                Scale = 1f,
                buttonAnimation = eButtonAnimation.None
            });

            Data.Add("TOWERCONSTRUCTION1", new ButtonGUIDatas
            {
                ID = "TowerConstruction1",
                NameTexture = "TOWERCONSTRUCTION",
                FrameWidth = 192,
                FrameHeight = 256,
                InitOffsetX = 0,
                InitOffsetY = 0,
                ButtonFrames = new int[] { 0, 1, 2, 3, 4, 5},
                ButtonFramesLenght = 5f / 12f,
                IsLoop = true,
                Scale = 1f,
                buttonAnimation = eButtonAnimation.UseFrames
            });
            Data.Add("TOWERCONSTRUCTION1BIS", new ButtonGUIDatas
            {
                ID = "TowerConstruction1bis",
                NameTexture = "TOWERCONSTRUCTION",
                FrameWidth = 192,
                FrameHeight = 256,
                InitOffsetX = 0,
                InitOffsetY = 256,
                ButtonFrames = new int[] { 0, 1, 2, 3, 4, 5 },
                ButtonFramesLenght = 5f / 12f,
                IsLoop = false,
                Scale = 1f,
                buttonAnimation = eButtonAnimation.UseFrames
            });
            Data.Add("TOWERCONSTRUCTION2", new ButtonGUIDatas
            {
                ID = "TowerConstruction2",
                NameTexture = "TOWERCONSTRUCTION",
                FrameWidth = 192,
                FrameHeight = 256,
                InitOffsetX = 0,
                InitOffsetY = 256 * 2,
                ButtonFrames = new int[] { 0, 1, 2, 3, 4, 5 },
                ButtonFramesLenght = 5f / 12f,
                IsLoop = true,
                Scale = 1f,
                buttonAnimation = eButtonAnimation.UseFrames
            });
            Data.Add("TOWERCONSTRUCTION2BIS", new ButtonGUIDatas
            {
                ID = "TowerConstruction2bis",
                NameTexture = "TOWERCONSTRUCTION",
                FrameWidth = 192,
                FrameHeight = 256,
                InitOffsetX = 0,
                InitOffsetY = 256 * 3,             
                ButtonFrames = new int[] { 0, 1, 2, 3, 4 },
                ButtonFramesLenght = 5f / 12f,
                IsLoop = false,
                Scale = 1f,
                buttonAnimation = eButtonAnimation.UseFrames
            });
            Data.Add("TOWERCONSTRUCTION3", new ButtonGUIDatas
            {
                ID = "TowerConstruction",
                NameTexture = "TOWERCONSTRUCTION",
                FrameWidth = 192,
                FrameHeight = 256,
                InitOffsetX = 0,
                InitOffsetY = 256 * 4,               
                ButtonFrames = new int[] { 0, 1, 2, 3, 4, 5 },
                ButtonFramesLenght = 5f / 12f,
                IsLoop = true,
                Scale = 1f,
                buttonAnimation = eButtonAnimation.UseFrames
            });
            Data.Add("TOWERCONSTRUCTION3BIS", new ButtonGUIDatas
            {
                ID = "TowerConstruction3bis",
                NameTexture = "TOWERCONSTRUCTION",
                FrameWidth = 192,
                FrameHeight = 256,
                InitOffsetX = 0,
                InitOffsetY = 256 * 5,
                ButtonFrames = new int[] { 0, 1, 2, 3, 4 },
                ButtonFramesLenght = 5f / 12f,
                IsLoop = false,
                Scale = 1f,
                buttonAnimation = eButtonAnimation.UseFrames
            });

            Data.Add("PLAY", new ButtonGUIDatas
            {
                ID = "Play",
                NameTexture = "PLAY",
                FrameWidth = 190,
                FrameHeight = 49,
                InitOffsetX = 0,
                InitOffsetY = 0,
                OffsetSelectedX = 0,
                OffsetSelectedY = 0,
                OffsetPushX = 0,
                OffsetPushY = 0,
                Scale = 1f,
                buttonAnimation = eButtonAnimation.UseAnimation
            });
            Data.Add("GAMESPEED", new ButtonGUIDatas
            {
                ID = "GameSpeed",
                NameTexture = "GUI WOODEN PIXEL ART",
                FrameWidth = 32,
                FrameHeight = 32,
                InitOffsetX = 32 * 4,
                InitOffsetY = 32 * 0,
                OffsetSelectedX = 32 * 9,
                OffsetSelectedY = 32 * 0,
                OffsetPushX = 32 * 18,
                OffsetPushY = 32 * 0,
                Scale = 1.5f,
                buttonAnimation = eButtonAnimation.UseTileset
            });
            Data.Add("BUTTON1", new ButtonGUIDatas
            {
                ID = "Button1",
                NameTexture = "BUTTON1",
                FrameWidth = 144,
                FrameHeight = 72,              
                Scale = 1f,
                buttonAnimation = eButtonAnimation.None
            });
        }
    }
}



