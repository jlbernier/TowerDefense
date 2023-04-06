using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tower_Defense.Utils
{
    public class EnnemyDatas
    {
        public string ID;
        public String Name;
        public int FrameWidth;
        public int FrameHeight;
        public Ennemy.eDirection Direction;
        public Ennemy.ePreferredDirection PreferredDirection;
        public int DecalageX;
        public int InitDecalageX;
        public int DecalageY;
        public Vector2 Velocity;
        public int MaxHP;
        public int HP;
        public bool isFlying;
        public int[] EnnemyFrames;
        public float EnnemyFramesLenght;
        public bool isMirrored;
        public EnnemyDatas() { }

        public EnnemyDatas(EnnemyDatas pCopy)
        {
            ID = pCopy.ID;
            Name = pCopy.Name;
            HP = pCopy.HP;
            Direction = pCopy.Direction;
        }
    }

    public static class Ennemy
    {
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

        public static Dictionary<string, EnnemyDatas> Data = new Dictionary<string, EnnemyDatas>();

        public static void PopulateData()
        {
            Data.Add("CLAMPBEETLE", new EnnemyDatas
            {
                ID = "Clampbeetle",
                Name = "Clampbeetle",
                FrameWidth = 64,
                FrameHeight = 64,
                Direction = eDirection.Left,
                PreferredDirection = ePreferredDirection.Left,
                DecalageX = 0,
                InitDecalageX = 0,
                DecalageY = 64 * 5,
                Velocity = new Vector2(-10, 0),
                EnnemyFrames = new int[] { 0, 1, 2, 3, 4, 5, 6, 7 },
                EnnemyFramesLenght = 1f / 12f,
                isFlying = true,
                isMirrored = false,
                MaxHP = 100,
                HP = 100
            });

            Data.Add("FIREBUG", new EnnemyDatas
            {
                ID = "Firebug",
                Name = "Firebug",
                FrameWidth = 128,
                FrameHeight = 64,
                Direction = eDirection.Left,
                PreferredDirection = ePreferredDirection.Left,
                DecalageX = 0,
                InitDecalageX = 0,
                DecalageY = 64 * 5,
                Velocity = new Vector2(-10, 0),
                EnnemyFrames = new int[] { 0, 1, 2, 3, 4, 5 },
                EnnemyFramesLenght = 1f / 12f,
                isFlying = false,
                isMirrored = true,
                MaxHP = 100,
                HP = 100
            });

            Data.Add("FIREWASP", new EnnemyDatas
            {
                ID = "Firewasp",
                Name = "Firewasp",
                FrameWidth = 32+64,
                FrameHeight = 99,
                Direction = eDirection.Left,
                PreferredDirection = ePreferredDirection.Left,
                DecalageX = 0,
                InitDecalageX = 0,
                DecalageY = 99 * 2,
                //DecalageY = 99 * 5,
                Velocity = new Vector2(-10, 0),
                EnnemyFrames = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 },
                //EnnemyFrames = new int[] { 0, 1, 2, 3, 4, 5, 6, 7 },
                EnnemyFramesLenght = 1f / 12f,
                isFlying = true,
                isMirrored = true,
                MaxHP = 100,
                HP = 100
            });

            Data.Add("FLYING_LOCUST", new EnnemyDatas
            {
                ID = "Flying Locust",
                Name = "Flying Locust",
                FrameWidth = 64,
                FrameHeight = 64,
                Direction = eDirection.Left,
                PreferredDirection = ePreferredDirection.Left,
                DecalageX = 0,
                InitDecalageX = 0,
                DecalageY = 64 * 2,
                Velocity = new Vector2(-10, 0),
                EnnemyFrames = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 },
                //EnnemyFrames = new int[] { 0, 1, 2, 3, 4, 5, 6, 7 },
                EnnemyFramesLenght = 1f / 12f,
                isFlying = true,
                isMirrored = true,
                MaxHP = 100,
                HP = 100
            });
            Data.Add("LEAFBUG", new EnnemyDatas
            {
                ID = "Leafbug",
                Name = "Leafbug",
                FrameWidth = 64,
                FrameHeight = 64,
                Direction = eDirection.Left,
                PreferredDirection = ePreferredDirection.Left,
                DecalageX = 0,
                InitDecalageX = 0,
                DecalageY = 64 * 5,
                Velocity = new Vector2(-10, 0),
                EnnemyFrames = new int[] { 0, 1, 2, 3, 4, 5, 6, 7 },
                EnnemyFramesLenght = 1f / 12f,
                isFlying = false,
                isMirrored = true,
                MaxHP = 100,
                HP = 100
            });
            Data.Add("MAGMA_CRAB", new EnnemyDatas
            {
                ID = "Magma Crab",
                Name = "Magma Crab",
                FrameWidth = 64,
                FrameHeight = 64,
                Direction = eDirection.Left,
                PreferredDirection = ePreferredDirection.Left,
                DecalageX = 0,
                InitDecalageX = 0,
                DecalageY = 64*5,
                Velocity = new Vector2(-10,0),
                EnnemyFrames = new int[] { 0, 1, 2, 3, 4, 5, 6, 7 },
                EnnemyFramesLenght = 1f / 12f,
                isFlying = false,
                isMirrored = false,
                MaxHP = 100,
                HP = 100
            });
            Data.Add("SCORPION", new EnnemyDatas
            {
                ID = "Scorpion",
                Name = "Scorpion",
                FrameWidth = 64,
                FrameHeight = 64,
                Direction = eDirection.Left,
                PreferredDirection = ePreferredDirection.Left,
                DecalageX = 0,
                InitDecalageX = 0,
                DecalageY = 64*5,
                Velocity = new Vector2(-10, 0),
                EnnemyFrames = new int[] { 0, 1, 2, 3, 4, 5, 6, 7 },
                EnnemyFramesLenght = 1f / 12f,
                isFlying = false,
                isMirrored = false,
                MaxHP = 100,
                HP = 100
            });
            Data.Add("VOIDBUTTERFLY", new EnnemyDatas
            {
                ID = "Voidbutterfly",
                Name = "Voidbutterfly",
                FrameWidth = 64,
                FrameHeight = 64,
                Direction = eDirection.Left,
                PreferredDirection = ePreferredDirection.Left,
                DecalageX = 0,
                InitDecalageX = 0,
                DecalageY = 64 * 2,
                Velocity = new Vector2(-10, 0),
                EnnemyFrames = new int[] { 0, 1, 2, 3, 4, 5 },
                EnnemyFramesLenght = 1f / 12f,
                isFlying = false,
                isMirrored = true,
                MaxHP = 100,
                HP = 100
            });
        }

    }
}
