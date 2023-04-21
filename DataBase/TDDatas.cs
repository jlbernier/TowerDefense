using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tower_Defense.Utils;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Runtime.CompilerServices;

namespace tower_Defense
{
    public class TDTextures
    {
        public static Dictionary<string, Texture2D> Textures = new Dictionary<string, Texture2D>();

        public static void PopulateTextures(Game mainGame)
        {
            // Ennemies
            Textures.Add("CLAMPBEETLE", mainGame.Content.Load<Texture2D>("ennemies/Clampbeetle"));
            Textures.Add("FIREBUG", mainGame.Content.Load<Texture2D>("ennemies/Firebug"));
            Textures.Add("FIREWASP", mainGame.Content.Load<Texture2D>("ennemies/Firewasp"));
            Textures.Add("FLYING_LOCUST", mainGame.Content.Load<Texture2D>("ennemies/Flying Locust"));
            Textures.Add("LEAFBUG", mainGame.Content.Load<Texture2D>("ennemies/Leafbug"));
            Textures.Add("MAGMA_CRAB", mainGame.Content.Load<Texture2D>("ennemies/Magma Crab"));
            Textures.Add("SCORPION", mainGame.Content.Load<Texture2D>("ennemies/Scorpion"));
            Textures.Add("VOIDBUTTERFLY", mainGame.Content.Load<Texture2D>("ennemies/Voidbutterfly"));
            Textures.Add("TOWERTILEMAP", mainGame.Content.Load<Texture2D>("Tilesets/Grass Tileset"));
            // 15 impacts
            Textures.Add("IMPACTTOWER1LEVELX", mainGame.Content.Load<Texture2D>("Impact/Tower 01 - Weapon - Impact"));
            Textures.Add("IMPACTTOWER2LEVEL1", mainGame.Content.Load<Texture2D>("Impact/Tower 02 - Level 01 - Projectile - Impact"));
            Textures.Add("IMPACTTOWER2LEVEL2", mainGame.Content.Load<Texture2D>("Impact/Tower 02 - Level 02 - Projectile - Impact"));
            Textures.Add("IMPACTTOWER2LEVEL3", mainGame.Content.Load<Texture2D>("Impact/Tower 02 - Level 03 - Projectile - Impact"));
            Textures.Add("IMPACTTOWER3LEVEL1", mainGame.Content.Load<Texture2D>("Impact/Tower 03 - Level 01 - Projectile - Impact"));
            Textures.Add("IMPACTTOWER3LEVEL2", mainGame.Content.Load<Texture2D>("Impact/Tower 03 - Level 02 - Projectile - Impact"));
            Textures.Add("IMPACTTOWER3LEVEL3", mainGame.Content.Load<Texture2D>("Impact/Tower 03 - Level 03 - Projectile - Impact"));
            Textures.Add("IMPACTTOWER4LEVEL1", mainGame.Content.Load<Texture2D>("Impact/Tower 04 - Level 01 - Projectile - Impact"));
            Textures.Add("IMPACTTOWER4LEVEL2", mainGame.Content.Load<Texture2D>("Impact/Tower 04 - Level 02 - Projectile - Impact"));
            Textures.Add("IMPACTTOWER4LEVEL3", mainGame.Content.Load<Texture2D>("Impact/Tower 04 - Level 03 - Projectile - Impact"));
            Textures.Add("IMPACTTOWER5LEVEL1", mainGame.Content.Load<Texture2D>("Impact/Tower 05 - Level 01 - Projectile - Impact"));
            Textures.Add("IMPACTTOWER5LEVEL2", mainGame.Content.Load<Texture2D>("Impact/Tower 05 - Level 02 - Projectile - Impact"));
            Textures.Add("IMPACTTOWER5LEVEL3", mainGame.Content.Load<Texture2D>("Impact/Tower 05 - Level 03 - Projectile - Impact"));
            Textures.Add("IMPACTTOWER6LEVELX", mainGame.Content.Load<Texture2D>("Impact/Tower 06 - Weapon - Impact"));
            Textures.Add("IMPACTTOWER7LEVELX", mainGame.Content.Load<Texture2D>("Impact/Tower 07 - Level X - Projectile - Impact"));
            // 22 missiles for 8 towers with 3 levels (tower 7 has only 1 missile)
            Textures.Add("MISSILETOWER1LEVEL1", mainGame.Content.Load<Texture2D>("Projectile/Tower 01 - Level 01 - Projectile"));
            Textures.Add("MISSILETOWER1LEVEL2", mainGame.Content.Load<Texture2D>("Projectile/Tower 01 - Level 02 - Projectile"));
            Textures.Add("MISSILETOWER1LEVEL3", mainGame.Content.Load<Texture2D>("Projectile/Tower 01 - Level 03 - Projectile"));
            Textures.Add("MISSILETOWER2LEVEL1", mainGame.Content.Load<Texture2D>("Projectile/Tower 02 - Level 01 - Projectile"));
            Textures.Add("MISSILETOWER2LEVEL2", mainGame.Content.Load<Texture2D>("Projectile/Tower 02 - Level 02 - Projectile"));
            Textures.Add("MISSILETOWER2LEVEL3", mainGame.Content.Load<Texture2D>("Projectile/Tower 02 - Level 03 - Projectile"));
            Textures.Add("MISSILETOWER3LEVEL1", mainGame.Content.Load<Texture2D>("Projectile/Tower 03 - Level 01 - Projectile"));
            Textures.Add("MISSILETOWER3LEVEL2", mainGame.Content.Load<Texture2D>("Projectile/Tower 03 - Level 02 - Projectile"));
            Textures.Add("MISSILETOWER3LEVEL3", mainGame.Content.Load<Texture2D>("Projectile/Tower 03 - Level 03 - Projectile"));
            Textures.Add("MISSILETOWER4LEVEL1", mainGame.Content.Load<Texture2D>("Projectile/Tower 04 - Level 01 - Projectile"));
            Textures.Add("MISSILETOWER4LEVEL2", mainGame.Content.Load<Texture2D>("Projectile/Tower 04 - Level 02 - Projectile"));
            Textures.Add("MISSILETOWER4LEVEL3", mainGame.Content.Load<Texture2D>("Projectile/Tower 04 - Level 03 - Projectile"));
            Textures.Add("MISSILETOWER5LEVEL1", mainGame.Content.Load<Texture2D>("Projectile/Tower 05 - Level 01 - Projectile"));
            Textures.Add("MISSILETOWER5LEVEL2", mainGame.Content.Load<Texture2D>("Projectile/Tower 05 - Level 02 - Projectile"));
            Textures.Add("MISSILETOWER5LEVEL3", mainGame.Content.Load<Texture2D>("Projectile/Tower 05 - Level 03 - Projectile"));
            Textures.Add("MISSILETOWER6LEVEL1", mainGame.Content.Load<Texture2D>("Projectile/Tower 06 - Level 01 - Projectile"));
            Textures.Add("MISSILETOWER6LEVEL2", mainGame.Content.Load<Texture2D>("Projectile/Tower 06 - Level 02 - Projectile"));
            Textures.Add("MISSILETOWER6LEVEL3", mainGame.Content.Load<Texture2D>("Projectile/Tower 06 - Level 03 - Projectile"));
            Textures.Add("MISSILETOWER7LEVELX", mainGame.Content.Load<Texture2D>("Projectile/Tower 07 - Level X - Projectile"));
            Textures.Add("MISSILETOWER8LEVEL1", mainGame.Content.Load<Texture2D>("Projectile/Tower 08 - Level 01 - Projectile"));
            Textures.Add("MISSILETOWER8LEVEL2", mainGame.Content.Load<Texture2D>("Projectile/Tower 08 - Level 02 - Projectile"));
            Textures.Add("MISSILETOWER8LEVEL3", mainGame.Content.Load<Texture2D>("Projectile/Tower 08 - Level 03 - Projectile"));
            // 24 weapons for 8 towers with 3 levels
            Textures.Add("WEAPONTOWER1LEVEL1", mainGame.Content.Load<Texture2D>("Weapon/Tower 01 - Level 01 - Weapon"));
            Textures.Add("WEAPONTOWER1LEVEL2", mainGame.Content.Load<Texture2D>("Weapon/Tower 01 - Level 02 - Weapon"));
            Textures.Add("WEAPONTOWER1LEVEL3", mainGame.Content.Load<Texture2D>("Weapon/Tower 01 - Level 03 - Weapon"));
            Textures.Add("WEAPONTOWER2LEVEL1", mainGame.Content.Load<Texture2D>("Weapon/Tower 02 - Level 01 - Weapon"));
            Textures.Add("WEAPONTOWER2LEVEL2", mainGame.Content.Load<Texture2D>("Weapon/Tower 02 - Level 02 - Weapon"));
            Textures.Add("WEAPONTOWER2LEVEL3", mainGame.Content.Load<Texture2D>("Weapon/Tower 02 - Level 03 - Weapon"));
            Textures.Add("WEAPONTOWER3LEVEL1", mainGame.Content.Load<Texture2D>("Weapon/Tower 03 - Level 01 - Weapon"));
            Textures.Add("WEAPONTOWER3LEVEL2", mainGame.Content.Load<Texture2D>("Weapon/Tower 03 - Level 02 - Weapon"));
            Textures.Add("WEAPONTOWER3LEVEL3", mainGame.Content.Load<Texture2D>("Weapon/Tower 03 - Level 03 - Weapon"));
            Textures.Add("WEAPONTOWER4LEVEL1", mainGame.Content.Load<Texture2D>("Weapon/Tower 04 - Level 01 - Weapon"));
            Textures.Add("WEAPONTOWER4LEVEL2", mainGame.Content.Load<Texture2D>("Weapon/Tower 04 - Level 02 - Weapon"));
            Textures.Add("WEAPONTOWER4LEVEL3", mainGame.Content.Load<Texture2D>("Weapon/Tower 04 - Level 03 - Weapon"));
            Textures.Add("WEAPONTOWER5LEVEL1", mainGame.Content.Load<Texture2D>("Weapon/Tower 05 - Level 01 - Weapon"));
            Textures.Add("WEAPONTOWER5LEVEL2", mainGame.Content.Load<Texture2D>("Weapon/Tower 05 - Level 02 - Weapon"));
            Textures.Add("WEAPONTOWER5LEVEL3", mainGame.Content.Load<Texture2D>("Weapon/Tower 05 - Level 03 - Weapon"));
            Textures.Add("WEAPONTOWER6LEVEL1", mainGame.Content.Load<Texture2D>("Weapon/Tower 06 - Level 01 - Weapon"));
            Textures.Add("WEAPONTOWER6LEVEL2", mainGame.Content.Load<Texture2D>("Weapon/Tower 06 - Level 02 - Weapon"));
            Textures.Add("WEAPONTOWER6LEVEL3", mainGame.Content.Load<Texture2D>("Weapon/Tower 06 - Level 03 - Weapon"));
            Textures.Add("WEAPONTOWER7LEVEL1", mainGame.Content.Load<Texture2D>("Weapon/Tower 07 - Level 01 - Weapon"));
            Textures.Add("WEAPONTOWER7LEVEL2", mainGame.Content.Load<Texture2D>("Weapon/Tower 07 - Level 02 - Weapon"));
            Textures.Add("WEAPONTOWER7LEVEL3", mainGame.Content.Load<Texture2D>("Weapon/Tower 07 - Level 03 - Weapon"));
            Textures.Add("WEAPONTOWER8LEVEL1", mainGame.Content.Load<Texture2D>("Weapon/Tower 08 - Level 01 - Weapon"));
            Textures.Add("WEAPONTOWER8LEVEL2", mainGame.Content.Load<Texture2D>("Weapon/Tower 08 - Level 02 - Weapon"));
            Textures.Add("WEAPONTOWER8LEVEL3", mainGame.Content.Load<Texture2D>("Weapon/Tower 08 - Level 03 - Weapon"));
            // 3 levels construction
            Textures.Add("TOWERCONSTRUCTION", mainGame.Content.Load<Texture2D>("Misc/Tower Construction"));
            // 3 levels per png
            Textures.Add("TOWER1", mainGame.Content.Load<Texture2D>("Tower/Tower 01"));
            Textures.Add("TOWER2", mainGame.Content.Load<Texture2D>("Tower/Tower 02"));
            Textures.Add("TOWER3", mainGame.Content.Load<Texture2D>("Tower/Tower 03"));
            Textures.Add("TOWER4", mainGame.Content.Load<Texture2D>("Tower/Tower 04"));
            Textures.Add("TOWER5", mainGame.Content.Load<Texture2D>("Tower/Tower 05"));
            Textures.Add("TOWER6", mainGame.Content.Load<Texture2D>("Tower/Tower 06"));
            Textures.Add("TOWER7", mainGame.Content.Load<Texture2D>("Tower/Tower 07"));
            Textures.Add("TOWER8", mainGame.Content.Load<Texture2D>("Tower/Tower 08"));
            Textures.Add("BOUNDINGBOX", mainGame.Content.Load<Texture2D>("GUI/BoundingBox"));
            Textures.Add("GUI WOODEN PIXEL ART", mainGame.Content.Load<Texture2D>("GUI/Wooden Pixel Art GUI 32x32"));
            Textures.Add("PLAY", mainGame.Content.Load<Texture2D>("Buttons/button"));
            Textures.Add("ICONS", mainGame.Content.Load<Texture2D>("GUI/Transparent Icons"));
            Textures.Add("TOWERBASE", mainGame.Content.Load<Texture2D>("Tilesets/Grass Tileset"));
        }
    }

    public class TDDataBase
    {
        public string ID;
        public String Name;
        public TDData.eDirection Direction;
        public string NameTexture;
        public int HP;
        public int MaxHP;
        public int Damages;
        public int Gold;
        public float maxDistance;
        public float maxDistanceTower;
        public int maxAngle;
        public Vector2 Velocity;
        public int speed;
        public bool isFlying;
        public bool isPreferredDirectionLeft; 
        public bool isMirrored;
        public int FrameWidth;
        public int FrameHeight;
        public int InitOffsetX;
        public int InitOffsetY;
        public int InitOffsetYUp;
        public int OffsetSelectedX;
        public int OffsetSelectedY;
        public int OffsetPushX;
        public int OffsetPushY;
        public int OffsetX;
        public int OffsetY;
        public int OffsetCenterX;
        public int OffsetCenterY;
        public bool IsLoop;
        public int[] ArrayFrames;
        public float FramesDuration;
        public float Scale;
        public float MaxScale;
        public float MinScale;
        public float StepScale;
        public float TimePerAnimation;
        public int offsetMissileWeapon;
        public TDData.eButtonAnimation buttonAnimation;
        public TDDataBase() { }
    }

    public static class TDData
    {
        public static int Gold = 1500;
        public static int Life = 20;
        public const int BoxWidth = 64;
        public const int BoxHeight = 64;
        public static string LevelAndWave = "Level: 1 Wave: 1/7";
        public static float TimerWave = 200;
        public static float CurrentTimerWave = 0;
        public const int StartBox = 837;
        public const int HorizontalPath = 545;
        public const int VerticalPath = 530;
        public const int VerticalBridge1 = 723;
        public const int VerticalBridge2 = 707;
        public const int UpRight= 518;
        public const int StonePath = 696;


        public enum eDirection
        {
            None,
            Left,
            Right,
            Up,
            Botton,
        }
        public enum ePreferredDirection
        {
            Left,
            Right,
            Up,
            Botton
        }
        public enum eButtonAnimation
        {
            None,
            UseTileset,
            UseFrames,
            UseAnimated,
            UseTDRectangle
        }
        public static Dictionary<string, TDDataBase> Data = new Dictionary<string, TDDataBase>();

        public static void PopulateData()
        {
            Data.Add("CLAMPBEETLE", new TDDataBase
            {
                ID = "CLAMPBEETLE",
                Name = "Clampbeetle",
                NameTexture = "CLAMPBEETLE",
                FrameWidth = 64,
                FrameHeight = 64,
                Direction = eDirection.Left,
                Velocity = new Vector2(50,50),
                isPreferredDirectionLeft = true,
                OffsetX = 64,
                InitOffsetX = 0,
                OffsetY = 0,
                InitOffsetY = 64 * 5,
                ArrayFrames = new int[] { 0, 1, 2, 3, 4, 5, 6, 7 },
                FramesDuration = 1f / 12f,
                IsLoop = true,
                buttonAnimation = eButtonAnimation.UseFrames,
                isFlying = true,
                isMirrored = false,
                MaxHP = 100,
                HP = 100,
                speed = 15,
                Gold = 100,
            });

            Data.Add("FIREBUG", new TDDataBase
            {
                ID = "FIREBUG",
                Name = "Firebug",
                NameTexture = "FIREBUG",
                FrameWidth = 128,
                FrameHeight = 64,
                Direction = eDirection.Left,
                Velocity = new Vector2(50,50),
                isPreferredDirectionLeft = true,
                OffsetX = 128,
                OffsetY = 0,
                InitOffsetX = 0,
                InitOffsetY = 64 * 5,
                ArrayFrames = new int[] { 0, 1, 2, 3, 4, 5 },
                FramesDuration = 2f / 12f,
                IsLoop = true,
                buttonAnimation = eButtonAnimation.UseFrames,
                isFlying = false,
                isMirrored = true,
                MaxHP = 100,
                HP = 100,
                speed = 15,
                Gold = 100,
            });

            Data.Add("FIREWASP", new TDDataBase
            {
                ID = "FIREWASP",
                Name = "Firewasp",
                NameTexture = "FIREWASP",
                FrameWidth = 96,
                FrameHeight = 99,
                Direction = eDirection.Left,
                Velocity = new Vector2(50,50),
                isPreferredDirectionLeft = false,
                OffsetX = 96,
                OffsetY = 0,
                InitOffsetX = 0,
                InitOffsetY = 99 * 2,
                ArrayFrames = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 },
                FramesDuration = 1f / 12f,
                IsLoop = true,
                buttonAnimation = eButtonAnimation.UseFrames,
                isFlying = true,
                isMirrored = true,
                MaxHP = 100,
                HP = 100,
                Gold = 100,
                speed = 15
            });

            Data.Add("FLYING_LOCUST", new TDDataBase
            {
                ID = "FLYING_LOCUST",
                Name = "Flying Locust",
                NameTexture = "FLYING_LOCUST",
                FrameWidth = 64,
                FrameHeight = 64,
                Direction = eDirection.Left,
                Velocity = new Vector2(50,50),
                isPreferredDirectionLeft = false,
                OffsetX = 64,
                OffsetY = 0,
                InitOffsetX = 0,
                InitOffsetY = 64 * 2,
                ArrayFrames = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 },
                FramesDuration = 1f / 12f,
                IsLoop = true,
                buttonAnimation = eButtonAnimation.UseFrames,
                isFlying = true,
                isMirrored = true,
                MaxHP = 100,
                HP = 100,
                Gold = 100,
                speed = 15
            });
            Data.Add("LEAFBUG", new TDDataBase
            {
                ID = "LEAFBUG",
                Name = "Leafbug",
                NameTexture = "LEAFBUG",
                FrameWidth = 64,
                FrameHeight = 64,
                Direction = eDirection.Left,
                Velocity = new Vector2(50,50),
                isPreferredDirectionLeft = true,
                OffsetX = 64,
                OffsetY = 0,
                InitOffsetX = 0,
                InitOffsetY = 64 * 5,
                InitOffsetYUp = 64 * 4,
                ArrayFrames = new int[] { 0, 1, 2, 3, 4, 5, 6, 7 },
                FramesDuration = 0.8f / 12f,
                IsLoop = true,
                buttonAnimation = eButtonAnimation.UseFrames,
                isFlying = false,
                isMirrored = true,
                MaxHP = 100,
                HP = 100,
                Gold = 100,
                speed = 13
            });
            Data.Add("MAGMA_CRAB", new TDDataBase
            {
                ID = "MAGMA_CRAB",
                Name = "Magma Crab",
                NameTexture = "MAGMA_CRAB",
                FrameWidth = 64,
                FrameHeight = 64,
                Direction = eDirection.Left,
                Velocity = new Vector2(50,50),
                isPreferredDirectionLeft = true,
                OffsetX = 64,
                OffsetY = 0,
                InitOffsetX = 0,
                InitOffsetY = 64 * 5,
                ArrayFrames = new int[] { 0, 1, 2, 3, 4, 5, 6, 7 },
                FramesDuration = 3f / 12f,
                IsLoop = true,
                buttonAnimation = eButtonAnimation.UseFrames,
                isFlying = false,
                isMirrored = false,
                MaxHP = 100,
                HP = 100,
                Gold = 100,
                speed = 15
            });
            Data.Add("SCORPION", new TDDataBase
            {
                ID = "SCORPION",
                Name = "Scorpion",
                NameTexture = "SCORPION",
                FrameWidth = 64,
                FrameHeight = 64,
                Direction = eDirection.Left,
                Velocity = new Vector2(50,50),
                isPreferredDirectionLeft = false,
                OffsetX = 64,
                OffsetY = 0,
                InitOffsetX = 0,
                InitOffsetY = 64 * 5,
                ArrayFrames = new int[] { 0, 1, 2, 3, 4, 5, 6, 7 },
                FramesDuration = 3f / 12f,
                IsLoop = true,
                buttonAnimation = eButtonAnimation.UseFrames,
                isFlying = false,
                isMirrored = false,
                MaxHP = 100,
                HP = 100,
                Gold = 100,
                speed = 15
            });
            Data.Add("VOIDBUTTERFLY", new TDDataBase
            {
                ID = "VOIDBUTTERFLY",
                Name = "Voidbutterfly",
                NameTexture = "VOIDBUTTERFLY",
                FrameWidth = 64,
                FrameHeight = 64,
                Direction = eDirection.Left,
                Velocity = new Vector2(50,50),
                isPreferredDirectionLeft = false,
                OffsetX = 64,
                OffsetY = 0,
                InitOffsetX = 0,
                InitOffsetY = 64 * 2,
                ArrayFrames = new int[] { 0, 1, 2, 3, 4, 5 },
                FramesDuration = 1f / 12f,
                IsLoop = true,
                buttonAnimation = eButtonAnimation.UseFrames,
                isFlying = false,
                isMirrored = true,
                MaxHP = 100,
                HP = 100,
                Gold = 100,
                speed = 15
            });




            Data.Add("PLAY", new TDDataBase
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
                MaxScale = 1.05f,
                MinScale = 0.95f,
                StepScale = 0.01f,
                TimePerAnimation = 0.05f,
                buttonAnimation = eButtonAnimation.UseAnimated
            });
            Data.Add("GAMESPEED", new TDDataBase
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
            Data.Add("PAUSE", new TDDataBase
            {
                ID = "Pause",
                NameTexture = "GUI WOODEN PIXEL ART",
                FrameWidth = 32,
                FrameHeight = 32,
                InitOffsetX = 32 * 0,
                InitOffsetY = 32 * 27,
                OffsetSelectedX = 32 * 9,
                OffsetSelectedY = 32 * 0,
                OffsetPushX = 32 * 18,
                OffsetPushY = 32 * 0,
                Scale = 1.5f,
                buttonAnimation = eButtonAnimation.UseTileset
            });

            Data.Add("ICONTOWERUP", new TDDataBase
            {
                ID = "IconTowerUp",
                NameTexture = "GUI WOODEN PIXEL ART",
                FrameWidth = 32,
                FrameHeight = 32,
                InitOffsetX = 32 * 7,
                InitOffsetY = 32 * 0,
                OffsetSelectedX = 32 * 9,
                OffsetSelectedY = 32 * 0,
                OffsetPushX = 32 * 18,
                OffsetPushY = 32 * 0,
                Scale = 1.5f,
                buttonAnimation = eButtonAnimation.UseTileset
            });

            Data.Add("ICONWEAPONUP", new TDDataBase
            {
                ID = "IconWeaponUP",
                NameTexture = "GUI WOODEN PIXEL ART",
                FrameWidth = 32,
                FrameHeight = 32,
                InitOffsetX = 32 * 5,
                InitOffsetY = 32 * 0,
                OffsetSelectedX = 32 * 9,
                OffsetSelectedY = 32 * 0,
                OffsetPushX = 32 * 18,
                OffsetPushY = 32 * 0,
                Scale = 1.5f,
                buttonAnimation = eButtonAnimation.UseTileset
            });

            Data.Add("ICONROTATEWEAPON", new TDDataBase
            {
                ID = "IconRotateWeapon",
                NameTexture = "GUI WOODEN PIXEL ART",
                FrameWidth = 32,
                FrameHeight = 32,
                InitOffsetX = 32 * 3,
                InitOffsetY = 32 * 20,
                OffsetSelectedX = 32 * 9,
                OffsetSelectedY = 32 * 0,
                OffsetPushX = 32 * 18,
                OffsetPushY = 32 * 0,
                Scale = 1.5f,
                buttonAnimation = eButtonAnimation.UseTileset
            });

            Data.Add("MENUSELECTUPGRADE", new TDDataBase
            {
                ID = "MENUSELECTUPGRADE",
                NameTexture = "BOUNDINGBOX",
                FrameWidth = 192,
                FrameHeight = 256,
                Scale = 1f,
                buttonAnimation = eButtonAnimation.None
            });

            // Wooden box
            Data.Add("MENUSELECTTYPETOWER", new TDDataBase
            {
                ID = "MENUSELECTTYPETOWER",
                NameTexture = "GUI WOODEN PIXEL ART",
                FrameWidth = 32*3,
                FrameHeight = 32*3,
                InitOffsetX = 32 * 5,
                InitOffsetY = 32 * 20,             
                Scale = 1f,
                buttonAnimation = eButtonAnimation.UseTileset
            });
            Data.Add("WOODENLIFE", new TDDataBase
            {
                ID = "WoodenLifex",
                NameTexture = "GUI WOODEN PIXEL ART",
                FrameWidth = 32 * 3,
                FrameHeight = 32,
                InitOffsetX = 32 * 4,
                InitOffsetY = 32 * 34,
                Scale = 2f,
                buttonAnimation = eButtonAnimation.UseTileset
            });
            Data.Add("CHAIN", new TDDataBase
            {
                ID = "Chain",
                NameTexture = "GUI WOODEN PIXEL ART",
                FrameWidth = 16,
                FrameHeight = 16,
                InitOffsetX = 32 * 4,
                InitOffsetY = 32 * 30,
                Scale = 2f,
                buttonAnimation = eButtonAnimation.UseTileset
            });

            // Gold, Life, etc.
            Data.Add("GOLD", new TDDataBase
            {
                ID = "Gold",
                NameTexture = "ICONS",
                FrameWidth = 32,
                FrameHeight = 32,
                InitOffsetX = 32 * 10,
                InitOffsetY = 32 * 12,
                Scale = 1f,
                buttonAnimation = eButtonAnimation.UseTileset
            });
            Data.Add("HEART", new TDDataBase
            {
                ID = "Heart",
                NameTexture = "ICONS",
                FrameWidth = 32,
                FrameHeight = 32,
                InitOffsetX = 32 * 6,
                InitOffsetY = 32 * 0,
                Scale = 1f,
                buttonAnimation = eButtonAnimation.UseTileset
            });
            // Tower base where to build
            Data.Add("TOWERBASE", new TDDataBase
            {
                ID = "TOWERBASE",
                NameTexture = "TOWERBASE",
                FrameWidth = 64,
                FrameHeight = 64,
                InitOffsetX = 64 * 6,
                InitOffsetY = 64 * 7,
                Scale = 1f,
                buttonAnimation = eButtonAnimation.UseTDRectangle
            });
            
            // 8 types of towers in tilsets with 3 levels: tower 41 is type weapon 4 level tower 1
            Data.Add("TOWER11", new TDDataBase
            {
                ID = "TOWER11",
                NameTexture = "TOWER1",
                FrameWidth = 64,
                FrameHeight = 128,
                OffsetX = 64,
                InitOffsetX = 0,
                OffsetCenterY = -48 ,
                Scale = 1f,
                maxDistanceTower = 300,
                Gold = 100,
                buttonAnimation = eButtonAnimation.None
            });
            Data.Add("TOWER12", new TDDataBase
            {
                ID = "TOWER12",
                NameTexture = "TOWER1",
                FrameWidth = 64,
                FrameHeight = 128,
                OffsetX = 64,
                InitOffsetX = 64,
                OffsetCenterY = - 48,
                Scale = 1f,
                maxDistanceTower = 500,
                Gold = 100,
                buttonAnimation = eButtonAnimation.None
            });
            Data.Add("TOWER13", new TDDataBase
            {
                ID = "TOWER13",
                NameTexture = "TOWER1",
                FrameWidth = 64,
                FrameHeight = 128,
                OffsetX = 64,
                InitOffsetX = 64*2,
                OffsetCenterY = - 48,
                Scale = 1f,
                maxDistanceTower = 700,
                Gold = 100,
                buttonAnimation = eButtonAnimation.None
            });

            Data.Add("TOWER21", new TDDataBase
            {
                ID = "TOWER21",
                NameTexture = "TOWER2",
                FrameWidth = 64,
                FrameHeight = 128,
                InitOffsetY = 64,
                InitOffsetX = 0,
                OffsetX = 64,
                OffsetCenterY = -48,
                Scale = 1f,
                buttonAnimation = eButtonAnimation.None
            });
            
            Data.Add("TOWER22", new TDDataBase
            {
                ID = "TOWER22",
                NameTexture = "TOWER2",
                FrameWidth = 64,
                FrameHeight = 128,
                InitOffsetY = 64,
                InitOffsetX = 64,
                OffsetX = 64,
                OffsetCenterY = - 48,
                Scale = 1f,
                buttonAnimation = eButtonAnimation.None
            }); 
            Data.Add("TOWER23", new TDDataBase
            {
                ID = "TOWER23",
                NameTexture = "TOWER2",
                FrameWidth = 64,
                FrameHeight = 128,
                InitOffsetY = 64,
                InitOffsetX = 64*2,
                OffsetX = 64,
                OffsetCenterY = -48,
                Scale = 1f,
                buttonAnimation = eButtonAnimation.None
            }); ///
            Data.Add("TOWER31", new TDDataBase
            {
                ID = "TOWER31",
                NameTexture = "TOWER3",
                FrameWidth = 64,
                FrameHeight = 128,
                OffsetX = 64,
                InitOffsetX = 0,
                OffsetCenterY = -48,
                Scale = 1f,
                buttonAnimation = eButtonAnimation.None
            }); 
            Data.Add("TOWER32", new TDDataBase
            {
                ID = "TOWER32",
                NameTexture = "TOWER3",
                FrameWidth = 64,
                FrameHeight = 128,
                OffsetX = 64,
                InitOffsetX = 64,
                OffsetCenterY = - 48,
                Scale = 1f,
                buttonAnimation = eButtonAnimation.None
            }); 
            Data.Add("TOWER33", new TDDataBase
            {
                ID = "TOWER33",
                NameTexture = "TOWER3",
                FrameWidth = 64,
                FrameHeight = 128,
                OffsetX = 64,
                InitOffsetX = 64*2,
                OffsetCenterY = - 48,
                Scale = 1f,
                buttonAnimation = eButtonAnimation.None
            }); 
            Data.Add("TOWER41", new TDDataBase
            {
                ID = "TOWER41",
                NameTexture = "TOWER4",
                FrameWidth = 64,
                FrameHeight = 128,
                OffsetX = 64,
                InitOffsetX = 0,
                OffsetCenterY = -48,
                Scale = 1f,
                buttonAnimation = eButtonAnimation.None
            });
            Data.Add("TOWER42", new TDDataBase
            {
                ID = "TOWER42",
                NameTexture = "TOWER4",
                FrameWidth = 64,
                FrameHeight = 128,
                OffsetX = 64,
                InitOffsetX = 64,
                OffsetCenterY = - 48,
                Scale = 1f,
                buttonAnimation = eButtonAnimation.None
            }); 
            Data.Add("TOWER43", new TDDataBase
            {
                ID = "TOWER43",
                NameTexture = "TOWER4",
                FrameWidth = 64,
                FrameHeight = 128,
                OffsetX = 64,
                InitOffsetX = 64*2,
                Scale = 1f,
                OffsetCenterY = - 48,
                buttonAnimation = eButtonAnimation.None
            });
            Data.Add("TOWER51", new TDDataBase
            {
                ID = "TOWER51",
                NameTexture = "TOWER5",
                FrameWidth = 64,
                FrameHeight = 128,
                OffsetX = 64,
                InitOffsetX = 0,
                OffsetCenterY = -48,
                Scale = 1f,
                buttonAnimation = eButtonAnimation.None
            });
            Data.Add("TOWER52", new TDDataBase
            {
                ID = "TOWER52",
                NameTexture = "TOWER5",
                FrameWidth = 64,
                FrameHeight = 128,
                OffsetX = 64,
                InitOffsetX = 64,
                OffsetCenterY = - 48,
                Scale = 1f,
                buttonAnimation = eButtonAnimation.None
            });
            Data.Add("TOWER53", new TDDataBase
            {
                ID = "TOWER53",
                NameTexture = "TOWER5",
                FrameWidth = 64,
                FrameHeight = 128,
                OffsetX = 64,
                InitOffsetX = 64 * 2,
                OffsetCenterY = - 48,
                Scale = 1f,
                buttonAnimation = eButtonAnimation.None
            });
            Data.Add("TOWER61", new TDDataBase
            {
                ID = "TOWER61",
                NameTexture = "TOWER6",
                FrameWidth = 64,
                FrameHeight = 128,
                OffsetX = 64,
                InitOffsetX = 0,
                OffsetCenterY = -48,
                Scale = 1f,
                buttonAnimation = eButtonAnimation.None
            });
            Data.Add("TOWER62", new TDDataBase
            {
                ID = "TOWER62",
                NameTexture = "TOWER6",
                FrameWidth = 64,
                FrameHeight = 128,
                OffsetX = 64,
                InitOffsetX = 64,
                OffsetCenterY = - 48,
                Scale = 1f,
                buttonAnimation = eButtonAnimation.None
            });
            Data.Add("TOWER63", new TDDataBase
            {
                ID = "TOWER63",
                NameTexture = "TOWER6",
                FrameWidth = 64,
                FrameHeight = 128,
                OffsetX = 64,
                InitOffsetX = 64 * 2,
                OffsetCenterY = - 48,
                Scale = 1f,
                buttonAnimation = eButtonAnimation.None
            });
            Data.Add("TOWER71", new TDDataBase
            {
                ID = "TOWER71",
                NameTexture = "TOWER7",
                FrameWidth = 64,
                FrameHeight = 128,
                OffsetX = 64,
                InitOffsetX = 0,
                OffsetCenterY = -48,
                Scale = 1f,
                buttonAnimation = eButtonAnimation.None
            });
            Data.Add("TOWER72", new TDDataBase
            {
                ID = "TOWER72",
                NameTexture = "TOWER7",
                FrameWidth = 64,
                FrameHeight = 128,
                OffsetX = 64,
                InitOffsetX = 64,
                OffsetCenterY = -48,
                Scale = 1f,
                buttonAnimation = eButtonAnimation.None
            });
            Data.Add("TOWER73", new TDDataBase
            {
                ID = "TOWER73",
                NameTexture = "TOWER7",
                FrameWidth = 64,
                FrameHeight = 128,
                OffsetX = 64,
                InitOffsetX = 64 * 2,
                OffsetCenterY = - 48,
                Scale = 1f,
                buttonAnimation = eButtonAnimation.None
            });
            Data.Add("TOWER81", new TDDataBase
            {
                ID = "TOWER81",
                NameTexture = "TOWER8",
                FrameWidth = 64,
                FrameHeight = 128,
                OffsetX = 64,
                InitOffsetY = 64,
                InitOffsetX = 0,
                OffsetCenterY = -48,
                Scale = 1f,
                buttonAnimation = eButtonAnimation.None
            });
            Data.Add("TOWER82", new TDDataBase
            {
                ID = "TOWER82",
                NameTexture = "TOWER8",
                FrameWidth = 64,
                FrameHeight = 128,
                OffsetX = 64,
                InitOffsetY = 64,
                InitOffsetX = 64,
                OffsetCenterY = - 48,
                Scale = 1f,
                buttonAnimation = eButtonAnimation.None
            });
            Data.Add("TOWER83", new TDDataBase
            {
                ID = "TOWER83",
                NameTexture = "TOWER8",
                FrameWidth = 64,
                FrameHeight = 128,
                OffsetX = 64,
                InitOffsetY = 64,
                InitOffsetX = 64 * 2,
                OffsetCenterY = - 48,
                Scale = 1f,
                buttonAnimation = eButtonAnimation.None
            });
            // Tower construction animations 3 frames animations during building and 3 frames when building is done
            Data.Add("TOWERCONSTRUCTION1", new TDDataBase
            {
                ID = "TowerConstruction1",
                NameTexture = "TOWERCONSTRUCTION",
                FrameWidth = 192,
                FrameHeight = 256,
                OffsetX = 192,
                InitOffsetX = 0,
                InitOffsetY = 0,
                ArrayFrames = new int[] { 0, 1, 2, 3, 4, 5},
                FramesDuration = 5f / 12f,
                IsLoop = true,
                OffsetCenterX = 0,
                OffsetCenterY = - 48,
                Scale = 1f,
                buttonAnimation = eButtonAnimation.UseFrames
            });
            Data.Add("TOWERCONSTRUCTION1BIS", new TDDataBase
            {
                ID = "TowerConstruction1bis",
                NameTexture = "TOWERCONSTRUCTION",
                FrameWidth = 192,
                FrameHeight = 256,
                OffsetX = 192,
                InitOffsetX = 0,
                InitOffsetY = 256,
                ArrayFrames = new int[] { 0, 1, 2, 3, 4 },
                FramesDuration = 5f / 12f,
                IsLoop = false,
                Scale = 1f,
                buttonAnimation = eButtonAnimation.UseFrames
            });
            Data.Add("TOWERCONSTRUCTION2", new TDDataBase
            {
                ID = "TowerConstruction2",
                NameTexture = "TOWERCONSTRUCTION",
                FrameWidth = 192,
                FrameHeight = 256,
                OffsetX = 192,
                InitOffsetX = 0,
                InitOffsetY = 256 * 2,
                OffsetCenterX = 0,
                OffsetCenterY = -48,
                ArrayFrames = new int[] { 0, 1, 2, 3, 4, 5 },
                FramesDuration = 5f / 12f,
                IsLoop = true,
                Scale = 1f,
                buttonAnimation = eButtonAnimation.UseFrames
            });
            Data.Add("TOWERCONSTRUCTION2BIS", new TDDataBase
            {
                ID = "TowerConstruction2bis",
                NameTexture = "TOWERCONSTRUCTION",
                FrameWidth = 192,
                FrameHeight = 256,
                OffsetX = 192,
                InitOffsetX = 0,
                InitOffsetY = 256 * 3,             
                ArrayFrames = new int[] { 0, 1, 2, 3, 4 },
                FramesDuration = 5f / 12f,
                IsLoop = false,
                Scale = 1f,
                buttonAnimation = eButtonAnimation.UseFrames
            });
            Data.Add("TOWERCONSTRUCTION3", new TDDataBase
            {
                ID = "TowerConstruction",
                NameTexture = "TOWERCONSTRUCTION",
                FrameWidth = 192,
                FrameHeight = 256,
                OffsetX = 192,
                InitOffsetX = 0,
                InitOffsetY = 256 * 4,
                OffsetCenterX = 0,
                OffsetCenterY = -48,
                ArrayFrames = new int[] { 0, 1, 2, 3, 4, 5 },
                FramesDuration = 5f / 12f,
                IsLoop = true,
                Scale = 1f,
                buttonAnimation = eButtonAnimation.UseFrames
            });
            Data.Add("TOWERCONSTRUCTION3BIS", new TDDataBase
            {
                ID = "TowerConstruction3bis",
                NameTexture = "TOWERCONSTRUCTION",
                FrameWidth = 192,
                FrameHeight = 256,
                OffsetX = 192,
                InitOffsetX = 0,
                InitOffsetY = 256 * 5,
                ArrayFrames = new int[] { 0, 1, 2, 3, 4 },
                FramesDuration = 5f / 12f,
                IsLoop = false,
                Scale = 1f,
                buttonAnimation = eButtonAnimation.UseFrames
            });
            // 22 types for 8 types of towers and 3 levels of weapons (tower type 7 has only 1 projectile)
            Data.Add("MISSILETOWER1LEVEL1", new TDDataBase
            {
                ID = "MissileTower1Level1",
                NameTexture = "MISSILETOWER1LEVEL1",
                FrameWidth = 8,
                FrameHeight = 40,
                OffsetX = 8,
                ArrayFrames = new int[] { 0, 1, 2 },
                FramesDuration = 4f / 12f,
                IsLoop = true,
                Scale = 1f,
                offsetMissileWeapon =  -53,
                buttonAnimation = eButtonAnimation.UseFrames
            }) ;
            Data.Add("MISSILETOWER1LEVEL2", new TDDataBase
            {
                ID = "MissileTower1Level2",
                NameTexture = "MISSILETOWER1LEVEL2",
                FrameWidth = 15,
                FrameHeight = 40,
                OffsetX = 15,
                ArrayFrames = new int[] { 0, 1, 2 },
                FramesDuration = 1f / 12f,
                IsLoop = true,
                Scale = 1f,
                offsetMissileWeapon =  -53,
                buttonAnimation = eButtonAnimation.UseFrames
            }); 
            Data.Add("MISSILETOWER1LEVEL3", new TDDataBase
            {
                ID = "MissileTower1Level3",
                NameTexture = "MISSILETOWER1LEVEL3",
                FrameWidth = 22,
                FrameHeight = 40,
                ArrayFrames = new int[] { 0, 1, 2 },
                FramesDuration = 1f / 12f,
                IsLoop = true,
                Scale = 1f,
                offsetMissileWeapon =  -53,
                buttonAnimation = eButtonAnimation.UseFrames
            });
            Data.Add("MISSILETOWER2LEVEL1", new TDDataBase
            {
                ID = "MissileTower2Level1",
                NameTexture = "MISSILETOWER2LEVEL1",
                FrameWidth = 32,
                FrameHeight = 32,
                ArrayFrames = new int[] { 0, 1, 2, 3 ,4 },
                FramesDuration = 1f / 12f,
                IsLoop = true,
                Scale = 1f,
                offsetMissileWeapon =  0,
                buttonAnimation = eButtonAnimation.UseFrames
            });
            Data.Add("MISSILETOWER2LEVEL2", new TDDataBase
            {
                ID = "MissileTower2Level2",
                NameTexture = "MISSILETOWER2LEVEL2",
                FrameWidth = 32,
                FrameHeight = 32,
                ArrayFrames = new int[] { 0, 1, 2, 3, 4 },
                FramesDuration = 1f / 12f,
                IsLoop = true,
                Scale = 1f,
                offsetMissileWeapon =  0,
                buttonAnimation = eButtonAnimation.UseFrames
            });
            Data.Add("MISSILETOWER2LEVEL3", new TDDataBase
            {
                ID = "MissileTower2Level3",
                NameTexture = "MISSILETOWER2LEVEL3",
                FrameWidth = 32,
                FrameHeight = 32,
                ArrayFrames = new int[] { 0, 1, 2, 3, 4 },
                FramesDuration = 1f / 12f,
                IsLoop = true,
                Scale = 1f,
                offsetMissileWeapon =  0,
                buttonAnimation = eButtonAnimation.UseFrames
            });
            Data.Add("MISSILETOWER3LEVEL1", new TDDataBase
            {
                ID = "MissileTower3Level1",
                NameTexture = "MISSILETOWER3LEVEL1",
                FrameWidth = 10,
                FrameHeight = 10,
                ArrayFrames = new int[] { 0, 1, 2, 3, 4, 5 },
                FramesDuration = 3f / 12f,
                IsLoop = true,
                Scale = 1f,
                offsetMissileWeapon =  -36,
                buttonAnimation = eButtonAnimation.UseFrames
            });
            Data.Add("MISSILETOWER3LEVEL2", new TDDataBase
            {
                ID = "MissileTower3Level2",
                NameTexture = "MISSILETOWER3LEVEL2",
                FrameWidth = 10,
                FrameHeight = 10,
                ArrayFrames = new int[] { 0, 1, 2, 3, 4, 5 },
                FramesDuration = 3f / 12f,
                IsLoop = true,
                Scale = 1f,
                offsetMissileWeapon =  -40,
                buttonAnimation = eButtonAnimation.UseFrames
            });
            Data.Add("MISSILETOWER3LEVEL3", new TDDataBase
            {
                ID = "MissileTower3Level3",
                NameTexture = "MISSILETOWER3LEVEL3",
                FrameWidth = 10,
                FrameHeight = 10,
                ArrayFrames = new int[] { 0, 1, 2, 3, 4, 5 },
                FramesDuration = 3f / 12f,
                IsLoop = true,
                Scale = 1f,
                offsetMissileWeapon =  -40,
                buttonAnimation = eButtonAnimation.UseFrames
            });
            Data.Add("MISSILETOWER4LEVEL1", new TDDataBase
            {
                ID = "MissileTower4Level1",
                NameTexture = "MISSILETOWER4LEVEL1",
                FrameWidth = 8,
                FrameHeight = 8,
                ArrayFrames = new int[] { 0, 1, 2, 3, 4, 5 },
                FramesDuration = 5f / 12f,
                IsLoop = true,
                Scale = 1f,
                offsetMissileWeapon =  -53,
                buttonAnimation = eButtonAnimation.UseFrames
            });
            Data.Add("MISSILETOWER4LEVEL2", new TDDataBase
            {
                ID = "MissileTower4Level2",
                NameTexture = "MISSILETOWER4LEVEL2",
                FrameWidth = 15,
                FrameHeight = 12,
                ArrayFrames = new int[] { 0, 1, 2, 3, 4, 5 },
                FramesDuration = 5f / 12f,
                IsLoop = true,
                Scale = 1f,
                offsetMissileWeapon =  -53,
                buttonAnimation = eButtonAnimation.UseFrames
            });
            Data.Add("MISSILETOWER4LEVEL3", new TDDataBase
            {
                ID = "MissileTower4Level3",
                NameTexture = "MISSILETOWER4LEVEL3",
                FrameWidth = 10,
                FrameHeight = 10,
                ArrayFrames = new int[] { 0, 1, 2, 3, 4, 5, 6, 7 },
                FramesDuration = 5f / 12f,
                IsLoop = true,
                Scale = 1f,
                offsetMissileWeapon =  -53,
                buttonAnimation = eButtonAnimation.UseFrames
            });
            Data.Add("MISSILETOWER5LEVEL1", new TDDataBase
            {
                ID = "MissileTower5Level1",
                NameTexture = "MISSILETOWER5LEVEL1",
                FrameWidth = 32,
                FrameHeight = 32,
                ArrayFrames = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 },
                FramesDuration = 1f / 12f,
                IsLoop = true,
                Scale = 1f,
                offsetMissileWeapon =  -53,
                buttonAnimation = eButtonAnimation.UseFrames
            });
            Data.Add("MISSILETOWER5LEVEL2", new TDDataBase
            {
                ID = "MissileTower5Level2",
                NameTexture = "MISSILETOWER5LEVEL2",
                FrameWidth = 64,
                FrameHeight = 64,
                ArrayFrames = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 },
                FramesDuration = 1f / 12f,
                IsLoop = true,
                Scale = 1f,
                buttonAnimation = eButtonAnimation.UseFrames
            });
            Data.Add("MISSILETOWER5LEVEL3", new TDDataBase
            {
                ID = "MissileTower5Level3",
                NameTexture = "MISSILETOWER5LEVEL3",
                FrameWidth = 96,
                FrameHeight = 96,
                ArrayFrames = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 },
                FramesDuration = 1f / 12f,
                IsLoop = true,
                Scale = 1f,
                buttonAnimation = eButtonAnimation.UseFrames
            });
            Data.Add("MISSILETOWER6LEVEL1", new TDDataBase
            {
                ID = "MissileTower6Level1",
                NameTexture = "MISSILETOWER6LEVEL1",
                FrameWidth = 6,
                FrameHeight = 26,
                ArrayFrames = new int[] { 0, 1, 2 },
                FramesDuration = 1f / 12f,
                IsLoop = true,
                offsetMissileWeapon =  -20,
                Scale = 1f,
                buttonAnimation = eButtonAnimation.UseFrames
            });
            Data.Add("MISSILETOWER6LEVEL2", new TDDataBase
            {
                ID = "MissileTower6Level2",
                NameTexture = "MISSILETOWER6LEVEL2",
                FrameWidth = 8,
                FrameHeight = 34,
                ArrayFrames = new int[] { 0, 1, 2, 3 },
                FramesDuration = 1f / 12f,
                IsLoop = true,
                offsetMissileWeapon =  -30,
                Scale = 1f,
                buttonAnimation = eButtonAnimation.UseFrames
            });
            Data.Add("MISSILETOWER6LEVEL3", new TDDataBase
            {
                ID = "MissileTower6Level3",
                NameTexture = "MISSILETOWER6LEVEL3",
                FrameWidth = 10,
                FrameHeight = 37,
                ArrayFrames = new int[] { 0, 1, 2, 3 },
                FramesDuration = 1f / 12f,
                IsLoop = true,
                offsetMissileWeapon =  -30,
                Scale = 1f,
                buttonAnimation = eButtonAnimation.UseFrames
            });
            Data.Add("MISSILETOWER7LEVEL1", new TDDataBase
            {
                ID = "MissileTower7Level1",
                NameTexture = "MISSILETOWER7LEVELX",
                FrameWidth = 32,
                FrameHeight = 32,
                ArrayFrames = new int[] { 0, 1, 2, 3, 4, 5, 6, 7 },
                FramesDuration = 1f / 12f,
                IsLoop = true,
                Scale = 1f,
                buttonAnimation = eButtonAnimation.UseFrames
            });
            Data.Add("MISSILETOWER7LEVEL2", new TDDataBase
            {
                ID = "MissileTower7Level2",
                NameTexture = "MISSILETOWER7LEVELX",
                FrameWidth = 32,
                FrameHeight = 32,
                ArrayFrames = new int[] { 0, 1, 2, 3, 4, 5, 6, 7 },
                FramesDuration = 1f / 12f,
                IsLoop = true,
                Scale = 1f,
                buttonAnimation = eButtonAnimation.UseFrames
            });
            Data.Add("MISSILETOWER7LEVEL3", new TDDataBase
            {
                ID = "MissileTower7Level3",
                NameTexture = "MISSILETOWER7LEVELX",
                FrameWidth = 32,
                FrameHeight = 32,
                ArrayFrames = new int[] { 0, 1, 2, 3, 4, 5, 6, 7 },
                FramesDuration = 1f / 12f,
                IsLoop = true,
                Scale = 1f,
                buttonAnimation = eButtonAnimation.UseFrames
            });
            Data.Add("MISSILETOWER8LEVEL1", new TDDataBase
            {
                ID = "MissileTower8Level1",
                NameTexture = "MISSILETOWER8LEVEL1",
                FrameWidth = 256,
                FrameHeight = 256,
                ArrayFrames = new int[] { 0, 1, 2, 3, 4, 5, 6 },
                FramesDuration = 1f / 12f,
                IsLoop = true,
                Scale = 1f,
                buttonAnimation = eButtonAnimation.UseFrames
            });
            Data.Add("MISSILETOWER8LEVEL2", new TDDataBase
            {
                ID = "MissileTower8Level2",
                NameTexture = "MISSILETOWER8LEVEL2",
                FrameWidth = 320,
                FrameHeight = 320,
                ArrayFrames = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 },
                FramesDuration = 1f / 12f,
                IsLoop = true,
                Scale = 1f,
                buttonAnimation = eButtonAnimation.UseFrames
            });
            Data.Add("MISSILETOWER8LEVEL3", new TDDataBase
            {
                ID = "MissileTower8Level3",
                NameTexture = "MISSILETOWER8LEVEL3",
                FrameWidth = 320,
                FrameHeight = 320,
                ArrayFrames = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 }, 
                FramesDuration = 1f / 12f,
                IsLoop = true,
                Scale = 1f,
                buttonAnimation = eButtonAnimation.UseFrames
            });
            // 15 Impact Missiles
            Data.Add("IMPACTTOWER1LEVEL1", new TDDataBase
            {
                ID = "ImpactTower1Level1",
                NameTexture = "IMPACTTOWER1LEVELX",
                FrameWidth = 64,
                FrameHeight = 64,
                ArrayFrames = new int[] { 0, 1, 2, 3, 4, 5 },
                FramesDuration = 1f / 12f,
                IsLoop = false,
                Scale = 1f,
                Damages = 30,
                buttonAnimation = eButtonAnimation.UseFrames
            });
            Data.Add("IMPACTTOWER1LEVEL2", new TDDataBase
            {
                ID = "ImpactTower1Level2",
                NameTexture = "IMPACTTOWER1LEVELX",
                FrameWidth = 64,
                FrameHeight = 64,
                ArrayFrames = new int[] { 0, 1, 2, 3, 4, 5 },
                FramesDuration = 1f / 12f,
                IsLoop = false,
                Scale = 1f,
                Damages = 30,
                buttonAnimation = eButtonAnimation.UseFrames
            });
            Data.Add("IMPACTTOWER1LEVEL3", new TDDataBase
            {
                ID = "ImpactTower1Level3",
                NameTexture = "IMPACTTOWER1LEVELX",
                FrameWidth = 64,
                FrameHeight = 64,
                ArrayFrames = new int[] { 0, 1, 2, 3, 4, 5 },
                FramesDuration = 1f / 12f,
                IsLoop = false,
                Scale = 1f,
                Damages = 30,
                buttonAnimation = eButtonAnimation.UseFrames
            }); 
            Data.Add("IMPACTTOWER2LEVEL1", new TDDataBase
            {
                ID = "ImpactTower2Level1",
                NameTexture = "IMPACTTOWER2LEVEL1",
                FrameWidth = 64,
                FrameHeight = 64,
                ArrayFrames = new int[] { 0, 1, 2, 3, 4 },
                FramesDuration = 1f / 12f,
                IsLoop = false,
                Scale = 1f,
                Damages = 30,
                buttonAnimation = eButtonAnimation.UseFrames
            });
            Data.Add("IMPACTTOWER2LEVEL2", new TDDataBase
            {
                ID = "ImpactTower2Level2",
                NameTexture = "IMPACTTOWER2LEVEL2",
                FrameWidth = 64,
                FrameHeight = 64,
                ArrayFrames = new int[] { 0, 1, 2, 3, 4, 5 },
                FramesDuration = 1f / 12f,
                IsLoop = false,
                Scale = 1f,
                Damages = 30,
                buttonAnimation = eButtonAnimation.UseFrames
            });
            Data.Add("IMPACTTOWER2LEVEL3", new TDDataBase
            {
                ID = "ImpactTower2Level3",
                NameTexture = "IMPACTTOWER2LEVEL3",
                FrameWidth = 64,
                FrameHeight = 64,
                ArrayFrames = new int[] { 0, 1, 2, 3, 4, 5, 6 },
                FramesDuration = 1f / 12f,
                IsLoop = false,
                Scale = 1f,
                Damages = 30,
                buttonAnimation = eButtonAnimation.UseFrames
            });
            Data.Add("IMPACTTOWER3LEVEL1", new TDDataBase
            {
                ID = "ImpactTower3Level1",
                NameTexture = "IMPACTTOWER3LEVEL1",
                FrameWidth = 64,
                FrameHeight = 64,
                ArrayFrames = new int[] { 0, 1, 2, 3, 4, 5 },
                FramesDuration = 1f / 12f,
                IsLoop = false,
                Scale = 1f,
                Damages = 30,
                buttonAnimation = eButtonAnimation.UseFrames
            });
            Data.Add("IMPACTTOWER3LEVEL2", new TDDataBase
            {
                ID = "ImpactTower3Level2",
                NameTexture = "IMPACTTOWER3LEVEL2",
                FrameWidth = 64,
                FrameHeight = 64,
                ArrayFrames = new int[] { 0, 1, 2, 3, 4, 5 },
                FramesDuration = 1f / 12f,
                IsLoop = false,
                Scale = 1f,
                Damages = 30,
                buttonAnimation = eButtonAnimation.UseFrames
            });
            Data.Add("IMPACTTOWER3LEVEL3", new TDDataBase
            {
                ID = "ImpactTower3Level3",
                NameTexture = "IMPACTTOWER3LEVEL3",
                FrameWidth = 64,
                FrameHeight = 64,
                ArrayFrames = new int[] { 0, 1, 2, 3, 4, 5 },
                FramesDuration = 1f / 12f,
                IsLoop = false,
                Scale = 1f,
                Damages = 30,
                buttonAnimation = eButtonAnimation.UseFrames
            });
            Data.Add("IMPACTTOWER4LEVEL1", new TDDataBase
            {
                ID = "ImpactTower4Level1",
                NameTexture = "IMPACTTOWER4LEVEL1",
                FrameWidth = 72,
                FrameHeight = 64,
                ArrayFrames = new int[] { 0, 1, 2, 3, 4, 5, 6, 7 },
                FramesDuration = 1f / 12f,
                IsLoop = false,
                Scale = 1f,
                Damages = 30,
                buttonAnimation = eButtonAnimation.UseFrames
            });
            Data.Add("IMPACTTOWER4LEVEL2", new TDDataBase
            {
                ID = "ImpactTower4Level2",
                NameTexture = "IMPACTTOWER4LEVEL2",
                FrameWidth = 72,
                FrameHeight = 64,
                ArrayFrames = new int[] { 0, 1, 2, 3, 4, 5, 6, 7 },
                FramesDuration = 1f / 12f,
                IsLoop = false,
                Scale = 1f,
                Damages = 30,
                buttonAnimation = eButtonAnimation.UseFrames
            });
            Data.Add("IMPACTTOWER4LEVEL3", new TDDataBase
            {
                ID = "ImpactTower4Level3",
                NameTexture = "IMPACTTOWER4LEVEL3",
                FrameWidth = 72,
                FrameHeight = 64,
                ArrayFrames = new int[] { 0, 1, 2, 3, 4, 5, 6, 7 },
                FramesDuration = 1f / 12f,
                IsLoop = false,
                Scale = 1f,
                Damages = 30,
                buttonAnimation = eButtonAnimation.UseFrames
            });
            Data.Add("IMPACTTOWER5LEVEL1", new TDDataBase
            {
                ID = "ImpactTower5Level1",
                NameTexture = "IMPACTTOWER5LEVEL1",
                FrameWidth = 64,
                FrameHeight = 64,
                ArrayFrames = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 },
                FramesDuration = 1f / 12f,
                IsLoop = false,
                Scale = 1f,
                Damages = 30,
                buttonAnimation = eButtonAnimation.UseFrames
            });
            Data.Add("IMPACTTOWER5LEVEL2", new TDDataBase
            {
                ID = "ImpactTower5Level2",
                NameTexture = "IMPACTTOWER5LEVEL2",
                FrameWidth = 64,
                FrameHeight = 64,
                ArrayFrames = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 },
                FramesDuration = 1f / 12f,
                IsLoop = false,
                Scale = 1f,
                Damages = 30,
                buttonAnimation = eButtonAnimation.UseFrames
            });
            Data.Add("IMPACTTOWER5LEVEL3", new TDDataBase
            {
                ID = "ImpactTower5Level3",
                NameTexture = "IMPACTTOWER5LEVEL3",
                FrameWidth = 96,
                FrameHeight = 96,
                ArrayFrames = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 },
                FramesDuration = 1f / 12f,
                IsLoop = false,
                Scale = 1f,
                Damages = 30,
                buttonAnimation = eButtonAnimation.UseFrames
            });
            Data.Add("IMPACTTOWER6LEVEL1", new TDDataBase
            {
                ID = "ImpactTower6Level1",
                NameTexture = "IMPACTTOWER6LEVELX",
                FrameWidth = 64,
                FrameHeight = 64,
                ArrayFrames = new int[] { 0, 1, 2, 3, 4, 5 },
                FramesDuration = 1f / 12f,
                IsLoop = false,
                Scale = 1f,
                Damages = 30,
                buttonAnimation = eButtonAnimation.UseFrames
            });
            Data.Add("IMPACTTOWER6LEVEL2", new TDDataBase
            {
                ID = "ImpactTower6Level2",
                NameTexture = "IMPACTTOWER6LEVELX",
                FrameWidth = 64,
                FrameHeight = 64,
                ArrayFrames = new int[] { 0, 1, 2, 3, 4, 5 },
                FramesDuration = 1f / 12f,
                IsLoop = false,
                Scale = 1f,
                Damages = 30,
                buttonAnimation = eButtonAnimation.UseFrames
            });
            Data.Add("IMPACTTOWER6LEVEL3", new TDDataBase
            {
                ID = "ImpactTower6Level3",
                NameTexture = "IMPACTTOWER6LEVELX",
                FrameWidth = 64,
                FrameHeight = 64,
                ArrayFrames = new int[] { 0, 1, 2, 3, 4, 5 },
                FramesDuration = 1f / 12f,
                IsLoop = false,
                Scale = 1f,
                Damages = 30,
                buttonAnimation = eButtonAnimation.UseFrames
            });
            Data.Add("IMPACTTOWER7LEVEL1", new TDDataBase
            {
                ID = "ImpactTower7Level1",
                NameTexture = "IMPACTTOWER7LEVELX",
                FrameWidth = 64,
                FrameHeight = 64,
                ArrayFrames = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8 },
                FramesDuration = 1f / 12f,
                IsLoop = false,
                Scale = 1f,
                Damages = 30,
                buttonAnimation = eButtonAnimation.UseFrames
            });
            Data.Add("IMPACTTOWER7LEVEL2", new TDDataBase
            {
                ID = "ImpactTower7Level2",
                NameTexture = "IMPACTTOWER7LEVELX",
                FrameWidth = 64,
                FrameHeight = 64,
                ArrayFrames = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8 },
                FramesDuration = 1f / 12f,
                IsLoop = false,
                Scale = 1f,
                Damages = 30,
                buttonAnimation = eButtonAnimation.UseFrames
            }); 
            Data.Add("IMPACTTOWER7LEVEL3", new TDDataBase
            {
                ID = "ImpactTower7Level3",
                NameTexture = "IMPACTTOWER7LEVELX",
                FrameWidth = 64,
                FrameHeight = 64,
                ArrayFrames = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8 },
                FramesDuration = 1f / 12f,
                IsLoop = false,
                Scale = 1f,
                Damages = 30,
                buttonAnimation = eButtonAnimation.UseFrames
            });
            Data.Add("IMPACTTOWER8LEVEL1", new TDDataBase
            {
                ID = "IMPACTTOWER8Level1",
                NameTexture = "MISSILETOWER8LEVEL1",
                FrameWidth = 256,
                FrameHeight = 256,
                ArrayFrames = new int[] { 0, 1, 2, 3, 4, 5, 6 },
                FramesDuration = 1f / 12f,
                IsLoop = false,
                Scale = 1f,
                Damages = 30,
                buttonAnimation = eButtonAnimation.UseFrames
            });
            Data.Add("IMPACTTOWER8LEVEL2", new TDDataBase
            {
                ID = "IMPACTTOWER8Level2",
                NameTexture = "MISSILETOWER8LEVEL2",
                FrameWidth = 320,
                FrameHeight = 320,
                ArrayFrames = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 },
                FramesDuration = 1f / 12f,
                IsLoop = false,
                Scale = 1f,
                Damages = 30,
                buttonAnimation = eButtonAnimation.UseFrames
            }); 
            Data.Add("IMPACTTOWER8LEVEL3", new TDDataBase
            {
                ID = "IMPACTTOWER8Level3",
                NameTexture = "MISSILETOWER8LEVEL3",
                FrameWidth = 320,
                FrameHeight = 320,
                ArrayFrames = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 },
                FramesDuration = 1f / 12f,
                IsLoop = false,
                Scale = 1f,
                Damages = 30,
                buttonAnimation = eButtonAnimation.UseFrames
            });

            // 24 types for 8 types of towers and 3 levels of weapons (42 is weapon type 4 level 2)
            Data.Add("WEAPONTOWER1LEVEL1", new TDDataBase
            {
                ID = "WeaponTower1Level1",
                NameTexture = "WEAPONTOWER1LEVEL1",
                FrameWidth = 96,
                FrameHeight = 96,
                ArrayFrames = new int[] { 2, 3, 4, 5, 0, 1 },
                FramesDuration = 4f / 12f,
                IsLoop = false,
                OffsetCenterY = - 56,
                Scale = 1f,
                speed = 50,
                maxDistance = 300,
                maxAngle = 20,
                buttonAnimation = eButtonAnimation.UseFrames
            });
            Data.Add("WEAPONTOWER1LEVEL2", new TDDataBase
            {
                ID = "WeaponTower1Level2",
                NameTexture = "WEAPONTOWER1LEVEL2",
                FrameWidth = 96,
                FrameHeight = 96,
                ArrayFrames = new int[] { 2, 3, 4, 5, 0, 1 },
                FramesDuration = 8f / 12f,
                IsLoop = false,
                OffsetCenterY = - 65,
                Scale = 1f,
                speed = 50,
                maxDistance = 300,
                maxAngle = 20,
                buttonAnimation = eButtonAnimation.UseFrames
            });
            Data.Add("WEAPONTOWER1LEVEL3", new TDDataBase
            {
                ID = "WeaponTower1Level3",
                NameTexture = "WEAPONTOWER1LEVEL3",
                FrameWidth = 96,
                FrameHeight = 96,
                ArrayFrames = new int[] { 2, 3, 4, 5, 0, 1 },
                FramesDuration = 8f / 12f,
                OffsetCenterY = - 74,
                IsLoop = false,
                Scale = 1f,
                speed = 50,
                maxDistance = 300,
                maxAngle = 20,
                buttonAnimation = eButtonAnimation.UseFrames
            });

            Data.Add("WEAPONTOWER2LEVEL1", new TDDataBase
            {
                ID = "WeaponTower2Level1",
                NameTexture = "WEAPONTOWER2LEVEL1",
                FrameWidth = 48,
                FrameHeight = 96 / 2,
                InitOffsetY = 96 / 2,
                ArrayFrames = new int[] { 9, 10, 11, 12, 13, 14, 15, 0, 1, 2, 3, 4, 5, 6, 7, 8 },
                FramesDuration = 3f / 12f,
                IsLoop = false,
                OffsetCenterY = - 56,
                Scale = 1f,
                speed = 50,
                maxDistance = 300,
                maxAngle = 20,
                buttonAnimation = eButtonAnimation.UseFrames
            });
            
            Data.Add("WEAPONTOWER2LEVEL2", new TDDataBase
            {
                ID = "WeaponTower2Level2",
                NameTexture = "WEAPONTOWER2LEVEL2",
                FrameWidth = 64,
                FrameHeight = 128 / 2,
                InitOffsetY = 128 / 2,
                OffsetCenterY = - 56 - 9,
                ArrayFrames = new int[] { 9, 10, 11, 12, 13, 14, 15, 16, 0, 1, 2, 3, 4, 5, 6, 7, 8 },
                FramesDuration = 3f / 12f,
                IsLoop = false,
                speed = 50,
                Scale = 1f,
                maxDistance = 300,
                maxAngle = 20,
                buttonAnimation = eButtonAnimation.UseFrames
            });
            Data.Add("WEAPONTOWER2LEVEL3", new TDDataBase
            {
                ID = "WeaponTower2Level3",
                NameTexture = "WEAPONTOWER2LEVEL3",
                FrameWidth = 64,
                FrameHeight = 128 / 2,
                InitOffsetY = 128 / 2,
                OffsetCenterY = -56 -18,
                ArrayFrames = new int[] { 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 },
                FramesDuration = 3f / 12f,
                IsLoop = false,
                Scale = 1f,
                speed = 50,
                maxDistance = 300,
                maxAngle = 20,
                buttonAnimation = eButtonAnimation.UseFrames
            });
            
            Data.Add("WEAPONTOWER3LEVEL1", new TDDataBase
            {
                ID = "WeaponTower3Level1",
                NameTexture = "WEAPONTOWER3LEVEL1",
                FrameWidth = 96,
                FrameHeight = 96,
                ArrayFrames = new int[] { 6, 7, 0, 1, 2, 3, 4, 5 },
                FramesDuration = 3f / 12f,
                IsLoop = false,
                OffsetCenterY = -56,
                Scale = 1f,
                speed = 50,
                maxDistance = 300,
                maxAngle = 20,
                buttonAnimation = eButtonAnimation.UseFrames
            });

            Data.Add("WEAPONTOWER3LEVEL2", new TDDataBase
            {
                ID = "WeaponTower3Level2",
                NameTexture = "WEAPONTOWER3LEVEL2",
                FrameWidth = 96,
                FrameHeight = 96,
                ArrayFrames = new int[] { 6, 7, 0, 1, 2, 3, 4, 5 },
                FramesDuration = 3f / 12f,
                IsLoop = false,
                OffsetCenterY = -56 - 9,
                Scale = 1f,
                speed = 50,
                maxDistance = 300,
                maxAngle = 20,
                buttonAnimation = eButtonAnimation.UseFrames
            });
            Data.Add("WEAPONTOWER3LEVEL3", new TDDataBase
            {
                ID = "WeaponTower3Level3",
                NameTexture = "WEAPONTOWER3LEVEL3",
                FrameWidth = 96,
                FrameHeight = 96,
                ArrayFrames = new int[] { 6, 7, 0, 1, 2, 3, 4, 5 },
                FramesDuration = 3f / 12f,
                IsLoop = false,
                OffsetCenterY = -56 - 18,
                Scale = 1f,
                speed = 50,
                maxDistance = 300,
                maxAngle = 20,
                buttonAnimation = eButtonAnimation.UseFrames
            });
            
            Data.Add("WEAPONTOWER4LEVEL1", new TDDataBase
            {
                ID = "WeaponTower4Level1",
                NameTexture = "WEAPONTOWER4LEVEL1",
                FrameWidth = 128,
                FrameHeight = 128,
                ArrayFrames = new int[] { 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 0, 1, 2, 3, 4, 5 },
                FramesDuration = 5f / 12f,
                IsLoop = false,
                OffsetCenterY = -60,
                Scale = 1f,
                speed = 50,
                maxDistance = 300,
                maxAngle = 20,
                buttonAnimation = eButtonAnimation.UseFrames
            });

            Data.Add("WEAPONTOWER4LEVEL2", new TDDataBase
            {
                ID = "WeaponTower4Level2",
                NameTexture = "WEAPONTOWER4LEVEL2",
                FrameWidth = 128,
                FrameHeight = 128,
                ArrayFrames = new int[] { 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 0, 1, 2, 3, 4, 5 },
                FramesDuration = 5f / 12f,
                IsLoop = false,
                OffsetCenterY = -60 -9,
                Scale = 1f,
                speed = 50,
                maxDistance = 300,
                maxAngle = 20,
                buttonAnimation = eButtonAnimation.UseFrames
            });
            Data.Add("WEAPONTOWER4LEVEL3", new TDDataBase
            {
                ID = "WeaponTower4Level3",
                NameTexture = "WEAPONTOWER4LEVEL3",
                FrameWidth = 128,
                FrameHeight = 128,
                ArrayFrames = new int[] { 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 0, 1, 2, 3, 4, 5 },
                FramesDuration = 5f / 12f,
                IsLoop = false,
                OffsetCenterY = -60 - 18,
                Scale = 1f,
                speed = 50,
                maxDistance = 300,
                maxAngle = 20,
                buttonAnimation = eButtonAnimation.UseFrames
            });
            
            Data.Add("WEAPONTOWER5LEVEL1", new TDDataBase
            {
                ID = "WeaponTower5Level1",
                NameTexture = "WEAPONTOWER5LEVEL1",
                FrameWidth = 96,
                FrameHeight = 96,
                InitOffsetY = 96, 
                ArrayFrames = new int[] { 23, 24, 25, 26, 27, 28, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16,
                                            17, 18, 19, 20, 21, 22},
                FramesDuration = 1f / 12f,
                IsLoop = false,
                OffsetCenterY = -56,
                Scale = 1f,
                speed = 50,
                maxDistance = 300,
                maxAngle = 20,
                buttonAnimation = eButtonAnimation.UseFrames
            });

            Data.Add("WEAPONTOWER5LEVEL2", new TDDataBase
            {
                ID = "WeaponTower5Level2",
                NameTexture = "WEAPONTOWER5LEVEL2",
                FrameWidth = 96,
                FrameHeight = 192 / 2,
                InitOffsetY = 192 / 2,
                ArrayFrames = new int[] { 23, 24, 25, 26, 27, 28, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16,
                                            17, 18, 19, 20, 21, 22},
                FramesDuration = 1f / 12f,
                IsLoop = false,
                OffsetCenterY = -56 - 9,
                Scale = 1f,
                speed = 50,
                maxDistance = 300,
                maxAngle = 20,
                buttonAnimation = eButtonAnimation.UseFrames
            });
            Data.Add("WEAPONTOWER5LEVEL3", new TDDataBase
            {
                ID = "WeaponTower5Level3",
                NameTexture = "WEAPONTOWER5LEVEL3",
                FrameWidth = 96,
                FrameHeight = 192 / 2,
                InitOffsetY = 192 / 2,
                ArrayFrames = new int[] {23, 24, 25, 26, 27, 28, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22 },
                FramesDuration = 1f / 12f,
                IsLoop = false,
                OffsetCenterY = -56 - 18,
                Scale = 1f,
                speed = 50,
                maxDistance = 300,
                maxAngle = 20,
                buttonAnimation = eButtonAnimation.UseFrames
            });
            
            Data.Add("WEAPONTOWER6LEVEL1", new TDDataBase
            {
                ID = "WeaponTower6Level1",
                NameTexture = "WEAPONTOWER6LEVEL1",
                FrameWidth = 64,
                FrameHeight = 64,
                ArrayFrames = new int[] { 2, 3, 4, 5, 0, 1  },
                FramesDuration = 3f / 12f,
                IsLoop = false,
                OffsetCenterY = -56,
                Scale = 1f,
                speed = 50,
                maxDistance = 300,
                maxAngle = 20,
                buttonAnimation = eButtonAnimation.UseFrames
            });

            Data.Add("WEAPONTOWER6LEVEL2", new TDDataBase
            {
                ID = "WeaponTower6Level2",
                NameTexture = "WEAPONTOWER6LEVEL2",
                FrameWidth = 96,
                FrameHeight = 96,
                ArrayFrames = new int[] { 2, 3, 4, 5, 0, 1 },
                FramesDuration = 3f / 12f,
                IsLoop = false,
                OffsetCenterY = -56 - 9,
                Scale = 1f,
                speed = 50,
                maxDistance = 300,
                maxAngle = 20,
                buttonAnimation = eButtonAnimation.UseFrames
            });
            Data.Add("WEAPONTOWER6LEVEL3", new TDDataBase
            {
                ID = "WeaponTower6Level3",
                NameTexture = "WEAPONTOWER6LEVEL3",
                FrameWidth = 96,
                FrameHeight = 96,
                ArrayFrames = new int[] { 2, 3, 4, 5, 0, 1},
                FramesDuration = 3f / 12f,
                IsLoop = false,
                OffsetCenterY =  -56 - 18,
                Scale = 1f,
                speed = 50,
                maxDistance = 300,
                maxAngle = 20,
                buttonAnimation = eButtonAnimation.UseFrames
            });
            
            Data.Add("WEAPONTOWER7LEVEL1", new TDDataBase
            {
                ID = "WeaponTower7Level1",
                NameTexture = "WEAPONTOWER7LEVEL1",
                FrameWidth = 64,
                FrameHeight = 64,
                ArrayFrames = new int[] { 4, 5, 0, 1, 2, 3 },
                FramesDuration = 8f / 12f,
                IsLoop = false,
                OffsetCenterY = -56,
                Scale = 1f,
                speed = 50,
                maxAngle = 5,
                maxDistance = 300,
                buttonAnimation = eButtonAnimation.UseFrames
            });

            Data.Add("WEAPONTOWER7LEVEL2", new TDDataBase
            {
                ID = "WeaponTower7Level2",
                NameTexture = "WEAPONTOWER7LEVEL2",
                FrameWidth = 64,
                FrameHeight = 64,
                ArrayFrames = new int[] { 5, 6, 0, 1, 2, 3, 4 },
                FramesDuration = 8f / 12f,
                IsLoop = false,
                OffsetCenterY = -56 - 9,
                Scale = 1f,
                speed = 50,
                maxAngle = 5,
                maxDistance = 300,
                buttonAnimation = eButtonAnimation.UseFrames
            });
            Data.Add("WEAPONTOWER7LEVEL3", new TDDataBase
            {
                ID = "WeaponTower7Level3",
                NameTexture = "WEAPONTOWER7LEVEL3",
                FrameWidth = 64,
                FrameHeight = 64,
                ArrayFrames = new int[] { 7, 8, 0, 1, 2, 3, 4, 5, 6 },
                FramesDuration = 8f / 12f,
                IsLoop = false,
                OffsetCenterY =  -56 - 18,
                Scale = 1f,
                speed = 50,
                maxAngle = 5,
                maxDistance = 300,
                buttonAnimation = eButtonAnimation.UseFrames
            });
            Data.Add("WEAPONTOWER8LEVEL1", new TDDataBase
            {
                ID = "WeaponTower8Level1",
                NameTexture = "WEAPONTOWER8LEVEL1",
                FrameWidth = 48,
                FrameHeight = 48,
                ArrayFrames = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 },
                FramesDuration = 8f / 12f,
                IsLoop = false,
                OffsetCenterY =  - 56,
                speed = 0,
                Scale = 1f,
                maxAngle = 5,
                maxDistance = 300,
                buttonAnimation = eButtonAnimation.UseFrames
            });

            Data.Add("WEAPONTOWER8LEVEL2", new TDDataBase
            {
                ID = "WeaponTower8Level2",
                NameTexture = "WEAPONTOWER8LEVEL2",
                FrameWidth = 48,
                FrameHeight = 48,
                ArrayFrames = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 },
                FramesDuration = 8f / 12f,
                IsLoop = false,
                OffsetCenterY =  -56 - 9,
                Scale = 1f,
                speed = 0,
                maxAngle = 5,
                maxDistance = 300,
                buttonAnimation = eButtonAnimation.UseFrames
            });
            Data.Add("WEAPONTOWER8LEVEL3", new TDDataBase
            {
                ID = "WeaponTower8Level3",
                NameTexture = "WEAPONTOWER8LEVEL3",
                FrameWidth = 64,
                FrameHeight = 64,
                ArrayFrames = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 },
                FramesDuration = 8f / 12f,
                IsLoop = false,
                OffsetCenterY = -56 - 18,
                Scale = 1f,
                speed = 0,
                maxAngle = 5,
                maxDistance = 300,
                buttonAnimation = eButtonAnimation.UseFrames
            });

        }
    }
}



