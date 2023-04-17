using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tower_Defense.Animation;
using tower_Defense.Map;
using tower_Defense.Scenes;
using static tower_Defense.DataBase.TDWave;


namespace tower_Defense.Buttons
{
    public class Tower : Button
    {
        // Menu Choose tower to build or to upgrade
        public Vector2 positionBase { get; set; }
        public bool isMenuToBuild { get; set; }
        public bool isMenuToRemove { get; set; }
        public List<Tower> lstButtonsMenu { get; private set; }
        public Tower towerBase { get; private set; }
        public Tower menuTower { get; private set; }
        public SpriteWeapon spriteWeapon { get; private set; }
        public Tower towerToUpgrade { get; private set; }
        public String towerToBuild { get; set; }
        public bool WeaponOrTowerUpgrade { get; set; }
        public string towerID { get; set; }
        public string towerNextID { get; set; }
        public string towerType { get; set; }
        public int towerLevel { get; set; }
        public int weaponLevel { get; set; }
        public float timerBuild { get; set; }
        public int offsetCenterY { get; set; }
        public bool isCooldownShootUp { get; set; }
        public float angle { get; set; }
        public Tower(Game mainGame, Vector2 position, Vector2 velocity, string buttonID) : base(mainGame, position, velocity, buttonID)
        {
            towerID = buttonID;
            towerLevel = 1;
            weaponLevel = 1;
            scale = 1;
        }
        public void RemoveMenu(SceneMap pCurrentScene, Tower pMenuToRemove, Tower pTowerToBuild)
        {
            if (pMenuToRemove.isMenuToRemove)
            {
                if (towerNextID == null && pMenuToRemove.buttonID == "MENUSELECTTYPETOWER")
                {                    
                    pCurrentScene.listButtons.Add(pMenuToRemove.towerBase);
                }
                else if (pMenuToRemove.buttonID == "MENUSELECTUPGRADE")
                {
                    Debug.WriteLine("MENUSELECTUPGRADE");
                }
                pMenuToRemove.lstButtonsMenu.ForEach(tower => pCurrentScene.listButtons.Remove(tower));
                pMenuToRemove.lstButtonsMenu.Clear();
            }
        }
        public void AddButtonSelectTowerIcon(SceneMap pCurrentScene, Tower pMenuToBuild, Tower pIconToBuild, Vector2 position, String towerType, float scale)
        {
            pIconToBuild = new Tower(mainGame, position, new Vector2(0,0), towerType);
            pIconToBuild.scale = scale;
            pIconToBuild.boundingBox = new Rectangle((int)pIconToBuild.position.X, (int)pIconToBuild.position.Y,
                   (int)(pIconToBuild.widthTexture * pIconToBuild.scale), (int)(pIconToBuild.heightTexture * pIconToBuild.scale));
            pIconToBuild.positionBase = pMenuToBuild.positionBase;
            pIconToBuild.towerBase = pMenuToBuild.towerBase;
            pIconToBuild.towerToBuild = towerType;
            pIconToBuild.OnClick = pCurrentScene.onClickTowerType;
            pIconToBuild.OnHover = pCurrentScene.onHoverDefault;
            pIconToBuild.menuTower = pMenuToBuild;
            pCurrentScene.listButtons.Add(pIconToBuild);
            pMenuToBuild.lstButtonsMenu.Add(pIconToBuild);
        }
        public void AddButtonSelectTowerType(SceneMap pCurrentScene, Tower pMenuToBuild, Tower pIconToBuild)
        {
            AddButtonSelectTowerIcon(pCurrentScene, pMenuToBuild, pIconToBuild, new Vector2(pMenuToBuild.position.X - 27, pMenuToBuild.position.Y - 107),
                            "TOWER81", 0.4f);
            AddButtonSelectTowerIcon(pCurrentScene, pMenuToBuild, pIconToBuild, new Vector2(pMenuToBuild.position.X - 61, pMenuToBuild.position.Y - 107),
                            "TOWER71", 0.4f);
            AddButtonSelectTowerIcon(pCurrentScene, pMenuToBuild, pIconToBuild, new Vector2(pMenuToBuild.position.X - 9, pMenuToBuild.position.Y - 64),
                            "TOWER61", 0.4f);
            AddButtonSelectTowerIcon(pCurrentScene, pMenuToBuild, pIconToBuild, new Vector2(pMenuToBuild.position.X - 44, pMenuToBuild.position.Y - 64),
                            "TOWER51", 0.4f);
            AddButtonSelectTowerIcon(pCurrentScene, pMenuToBuild, pIconToBuild, new Vector2(pMenuToBuild.position.X - 79, pMenuToBuild.position.Y - 64),
                            "TOWER41", 0.4f);
            AddButtonSelectTowerIcon(pCurrentScene, pMenuToBuild, pIconToBuild, new Vector2(pMenuToBuild.position.X - 79, pMenuToBuild.position.Y - 24),
                            "TOWER11", 0.4f);
            AddButtonSelectTowerIcon(pCurrentScene, pMenuToBuild, pIconToBuild, new Vector2(pMenuToBuild.position.X - 44, pMenuToBuild.position.Y - 24),
                            "TOWER21", 0.4f);
            AddButtonSelectTowerIcon(pCurrentScene, pMenuToBuild, pIconToBuild, new Vector2(pMenuToBuild.position.X - 9, pMenuToBuild.position.Y - 24),
                            "TOWER31", 0.4f);
        }
        public void BuildMenuSelectTowerType(SceneMap pCurrentScene, Tower pBaseTower, Tower pMenuToBuild)
        {
            pMenuToBuild = new Tower(mainGame, new Vector2(pBaseTower.position.X + 32, pBaseTower.position.Y + 32), new Vector2(0,0), "MENUSELECTTYPETOWER");
            pMenuToBuild.scale = 1.5f;
            pMenuToBuild.boundingBox = new Rectangle((int)(pMenuToBuild.position.X -
                                pMenuToBuild.widthTexture * pMenuToBuild.scale + 32),
                                (int)(pMenuToBuild.position.Y -
                                pMenuToBuild.heightTexture * pMenuToBuild.scale + 32),
                                (int)(pMenuToBuild.widthTexture * pMenuToBuild.scale),
                                (int)(pMenuToBuild.heightTexture * pMenuToBuild.scale));
            pMenuToBuild.positionBase = pBaseTower.position;
            pMenuToBuild.towerBase = pBaseTower;
            pMenuToBuild.OnClick = pCurrentScene.onClickDefault;
            pMenuToBuild.OnHover = pCurrentScene.onHoverMenuSelectTowerType;
            pCurrentScene.listButtons.Add(pMenuToBuild);
            pMenuToBuild.lstButtonsMenu = new List<Tower>();
            pMenuToBuild.lstButtonsMenu.Add(pMenuToBuild);
            pCurrentScene.listButtons.Remove(pBaseTower);
            AddButtonSelectTowerType(pCurrentScene, pMenuToBuild, pBaseTower);
        }
        public void AddButtonUpgradeIcon(SceneMap pCurrentScene, Tower pMenuToBuild, Tower pIconToBuild, Vector2 position, String towerType, float scale)
        {
            pIconToBuild = new Tower(mainGame, position, new Vector2(0,0), towerType);
            pIconToBuild.scale = scale;
            pIconToBuild.boundingBox = new Rectangle((int)pIconToBuild.position.X - 64, (int)pIconToBuild.position.Y - 64,
                   (int)(pIconToBuild.widthTexture * pIconToBuild.scale), (int)(pIconToBuild.heightTexture * pIconToBuild.scale));
            pIconToBuild.menuTower = pMenuToBuild.menuTower;
            pIconToBuild.towerLevel = pMenuToBuild.towerLevel;
            pIconToBuild.weaponLevel = pMenuToBuild.weaponLevel;
            pIconToBuild.towerType = pMenuToBuild.towerType;
            pIconToBuild.menuTower = pMenuToBuild;
            pIconToBuild.positionBase = pMenuToBuild.positionBase;
            pIconToBuild.towerBase = pMenuToBuild.towerBase;
            pIconToBuild.towerToUpgrade = pMenuToBuild.towerToUpgrade;
            pIconToBuild.spriteWeapon = pMenuToBuild.spriteWeapon;
            pIconToBuild.OnHover = pCurrentScene.onHoverThreeStates;
            pIconToBuild.OnClick = pCurrentScene.onClickTowerUpgrade;
            pMenuToBuild.lstButtonsMenu.Add(pIconToBuild);
            pCurrentScene.listButtons.Add(pIconToBuild);
        }
        public void AddButtonUpgrade(SceneMap pCurrentScene, Tower pMenuToBuild, Tower pIconToBuild)
        {
            AddButtonUpgradeIcon(pCurrentScene, pMenuToBuild, pIconToBuild, new Vector2(pMenuToBuild.position.X - 60, pMenuToBuild.position.Y - 60),
                            "ICONTOWERUP", 1.5f);
            AddButtonUpgradeIcon(pCurrentScene, pMenuToBuild, pIconToBuild, new Vector2(pMenuToBuild.position.X + 10, pMenuToBuild.position.Y - 80),
                          "ICONWEAPONUP", 1.5f);
            AddButtonUpgradeIcon(pCurrentScene, pMenuToBuild, pIconToBuild, new Vector2(pMenuToBuild.position.X + 80, pMenuToBuild.position.Y - 60),
                         "ICONROTATEWEAPON", 1.5f);
        }
        public void BuildMenuChooseUpgrade(SceneMap pCurrentScene, Tower pBaseTower, Tower pMenuToBuild)
        {
            pBaseTower.isMenuToBuild = false;
            pMenuToBuild = new Tower(mainGame, new Vector2(pBaseTower.position.X, pBaseTower.position.Y), new Vector2(0, 0), "MENUSELECTUPGRADE");
            pMenuToBuild.menuTower = pBaseTower;
            pMenuToBuild.positionBase = pBaseTower.positionBase;
            pMenuToBuild.OnClick = pCurrentScene.onClickDefault;
            pMenuToBuild.OnHover = pCurrentScene.onHoverMenuUpgrade;
            pMenuToBuild.towerNextID = pMenuToBuild.towerID;
            pMenuToBuild.towerLevel = pBaseTower.towerLevel;
            pMenuToBuild.weaponLevel = pBaseTower.weaponLevel;
            pMenuToBuild.towerType = pBaseTower.towerType;
            pMenuToBuild.positionBase = pBaseTower.positionBase;
            pMenuToBuild.towerBase = pBaseTower;
            pMenuToBuild.menuTower = pBaseTower;
            pMenuToBuild.spriteWeapon = pBaseTower.spriteWeapon;
            pMenuToBuild.towerToUpgrade = pBaseTower;
            pCurrentScene.listButtons.Add(pMenuToBuild);
            pMenuToBuild.lstButtonsMenu = new List<Tower>();
            pMenuToBuild.lstButtonsMenu.Add(pMenuToBuild);
            AddButtonUpgrade(pCurrentScene, pMenuToBuild, pBaseTower);
        }
        public void BuildMenu(SceneMap pCurrentScene, Tower pBaseTower, Tower pMenuToBuild)
        {
            if (pBaseTower.isMenuToBuild && pBaseTower.towerID == "TOWERBASE")
                BuildMenuSelectTowerType(pCurrentScene, pBaseTower, pMenuToBuild);
            else if (pBaseTower.isMenuToBuild && pBaseTower.towerID == "MENUUPGRADE")
                BuildMenuChooseUpgrade(pCurrentScene, pBaseTower, pMenuToBuild);
        }
        public void FirstAnimationBuild(GameTime pGameTime, SceneMap pCurrentScene, Tower pCurrentTower, Tower pTowerToBuild = null)
        {
            pCurrentTower.menuTower.lstButtonsMenu.ForEach(tower => pCurrentScene.listButtons.Remove(tower));
            pCurrentTower.menuTower.lstButtonsMenu.Clear();
            pCurrentTower.position = pCurrentTower.positionBase;

            if (pCurrentTower.towerID == "MENUTILEMAP")
            {
                pCurrentScene.listButtons.Remove(pCurrentTower);
                pCurrentTower.towerType = pCurrentTower.towerNextID.Substring(pCurrentTower.towerNextID.Length - 2, 1);
            }
            if (pCurrentTower.towerID == "UPGRADE")
            {
                pCurrentScene.listButtons.Remove(pCurrentTower.towerToUpgrade);
                pCurrentScene.spriteWeaponFilter.Remove(pGameTime, pCurrentTower.spriteWeapon);
                if (pCurrentTower.buttonID == "ICONTOWERUP" && pCurrentTower.towerLevel < 3) pCurrentTower.towerLevel++;
                if (pCurrentTower.buttonID == "ICONWEAPONUP" && pCurrentTower.weaponLevel < 3) pCurrentTower.weaponLevel++;
            }
            string name = "TOWERCONSTRUCTION" + pCurrentTower.towerLevel.ToString();
            int offsetCenterX = TDData.Data[name].OffsetCenterX;
            int offsetCenterY = TDData.Data[name].OffsetCenterY;
            pCurrentTower.position = new Vector2(
                            pCurrentTower.positionBase.X + offsetCenterX,
                            pCurrentTower.positionBase.Y + offsetCenterY);
            pTowerToBuild = new Tower(mainGame, pCurrentTower.position, new Vector2(0,0), "TOWERCONSTRUCTION" + pCurrentTower.towerLevel.ToString())
            {
                towerNextID = "TOWERCONSTRUCTION" + pCurrentTower.towerLevel + "BIS",
                towerLevel = pCurrentTower.towerLevel,
                weaponLevel = pCurrentTower.weaponLevel,
                towerType = pCurrentTower.towerType,
                buttonID = pCurrentTower.buttonID,
                positionBase = pCurrentTower.positionBase,
                WeaponOrTowerUpgrade = pCurrentTower.WeaponOrTowerUpgrade,
                towerToUpgrade = pCurrentTower,
                spriteWeapon = pCurrentTower.spriteWeapon,
                isFrame = true,
                OnClick = pCurrentScene.onClickDefault,
                OnHover = pCurrentScene.onHoverDefault
            };
            pTowerToBuild.AddAnimation(
            "Tower",
                TDData.Data["TOWERCONSTRUCTION" + pCurrentTower.towerLevel].ArrayFrames,
                TDData.Data["TOWERCONSTRUCTION" + pCurrentTower.towerLevel].FramesDuration,
                TDData.Data["TOWERCONSTRUCTION" + pCurrentTower.towerLevel].OffsetX,
                TDData.Data["TOWERCONSTRUCTION" + pCurrentTower.towerLevel].OffsetY,
                TDData.Data["TOWERCONSTRUCTION" + pCurrentTower.towerLevel].IsLoop,
                TDData.Data["TOWERCONSTRUCTION" + pCurrentTower.towerLevel].InitOffsetX,
                TDData.Data["TOWERCONSTRUCTION" + pCurrentTower.towerLevel].InitOffsetY);
            pTowerToBuild.RunAnimation("Tower");
            pCurrentScene.listButtons.Add(pTowerToBuild);
            timerBuild = 0;
        }
        public void SecondAnimationBuild(SceneMap pCurrentScene, Tower pCurrentTower, Tower pTowerToBuild)
        {
            pCurrentScene.listButtons.Remove(pCurrentTower);
            pTowerToBuild = new Tower(mainGame, pCurrentTower.position, new Vector2(0,0), "TOWERCONSTRUCTION" + pCurrentTower.towerLevel.ToString() + "BIS")
            {
                towerNextID = "TOWER" + pCurrentTower.towerType + "BIS",
                towerLevel = pCurrentTower.towerLevel,
                weaponLevel = pCurrentTower.weaponLevel,
                towerType = pCurrentTower.towerType,
                positionBase = pCurrentTower.positionBase,
                WeaponOrTowerUpgrade = pCurrentTower.WeaponOrTowerUpgrade,
                towerToUpgrade = pCurrentTower.towerToUpgrade,
                OnClick = pCurrentScene.onClickDefault,
                OnHover = pCurrentScene.onHoverDefault
            };
            pTowerToBuild.isFrame = true;
            pTowerToBuild.AddAnimation(
            "Tower",
              TDData.Data["TOWERCONSTRUCTION" + pCurrentTower.towerLevel + "BIS"].ArrayFrames,
                TDData.Data["TOWERCONSTRUCTION" + pCurrentTower.towerLevel + "BIS"].FramesDuration,
                TDData.Data["TOWERCONSTRUCTION" + pCurrentTower.towerLevel + "BIS"].OffsetX,
                TDData.Data["TOWERCONSTRUCTION" + pCurrentTower.towerLevel + "BIS"].OffsetY,
                TDData.Data["TOWERCONSTRUCTION" + pCurrentTower.towerLevel + "BIS"].IsLoop,
                TDData.Data["TOWERCONSTRUCTION" + pCurrentTower.towerLevel + "BIS"].InitOffsetX,
                TDData.Data["TOWERCONSTRUCTION" + pCurrentTower.towerLevel + "BIS"].InitOffsetY);
            pTowerToBuild.RunAnimation("Tower");
            pCurrentScene.listButtons.Add(pTowerToBuild);
            timerBuild = 0;
        }
        public void RotateWeapon(SceneMap pCurrentScene, Tower pCurrentTower)
        {
            pCurrentTower.spriteWeapon.angle += 90;
            if (pCurrentTower.spriteWeapon.angle == 360) pCurrentTower.spriteWeapon.angle =0;
            pCurrentTower.towerID = "ICONROTATEWEAPON";
        }
        public int OffsetTowerY(Tower pCurrentTower)
        {
            string dataTowerID = "TOWER" + pCurrentTower.towerType + pCurrentTower.towerLevel.ToString();           
            offsetCenterY = TDData.Data[dataTowerID].OffsetCenterY;
            return offsetCenterY;
        }
        public int OffsetWeaponY(Tower pCurrentTower)
        {            
            string weaponTowerID = "WEAPONTOWER" + pCurrentTower.towerType + "LEVEL" + pCurrentTower.towerLevel.ToString();
            offsetCenterY = TDData.Data[weaponTowerID].OffsetCenterY;
            return offsetCenterY;
        }
        public void buildWeapon(SceneMap pCurrentScene, Tower pCurrentTower, Tower pTowerToBuild)
        {

            pTowerToBuild.towerLevel = pCurrentTower.towerLevel;
            pTowerToBuild.weaponLevel = pCurrentTower.weaponLevel;
            pTowerToBuild.towerType = pCurrentTower.towerType;
            pTowerToBuild.towerNextID = null;
            pTowerToBuild.positionBase = pCurrentTower.positionBase;
            pTowerToBuild.WeaponOrTowerUpgrade = pCurrentTower.WeaponOrTowerUpgrade;          
            pCurrentScene.spriteWeaponFilter.AddWeapon(mainGame,
                "WEAPONTOWER" + pCurrentTower.towerType + "LEVEL" + pCurrentTower.weaponLevel.ToString(),
                pCurrentTower.position, new Vector2(0, 0), pTowerToBuild);
        }
        public Tower buildTower(SceneMap pCurrentScene, Tower pCurrentTower, Tower pTowerToBuild)
        {
            offsetCenterY = OffsetTowerY(pCurrentTower);
            pTowerToBuild = new Tower(mainGame,
                new Vector2(pCurrentTower.positionBase.X, pCurrentTower.positionBase.Y + offsetCenterY),
                new Vector2(0, 0), "TOWER" + pCurrentTower.towerType + pCurrentTower.towerLevel.ToString())
            {
                towerLevel = pCurrentTower.towerLevel,
                weaponLevel = pCurrentTower.weaponLevel,
                towerType = pCurrentTower.towerType,
                towerNextID = null,
                positionBase = pCurrentTower.positionBase,
                spriteWeapon = pCurrentScene.spriteWeaponFilter.liste[pCurrentScene.spriteWeaponFilter.liste.Count() - 1],
                WeaponOrTowerUpgrade = pCurrentTower.WeaponOrTowerUpgrade,
                OnHover = pCurrentScene.onHoverTower,
                OnClick = pCurrentScene.onClickTowerUpgrade,
            };
            return pTowerToBuild;
        }
        public void BuildWeaponAndTower(GameTime pGameTime, SceneMap pCurrentScene, Tower pCurrentTower, Tower pTowerToBuild)
        {
            pCurrentScene.listButtons.Remove(pCurrentTower);
            if (pCurrentTower.WeaponOrTowerUpgrade)
            {
                pCurrentScene.listButtons.Remove(pCurrentTower.towerToUpgrade);
            }           
            offsetCenterY = OffsetWeaponY(pCurrentTower);
            pCurrentTower.position = new Vector2(pCurrentTower.positionBase.X, 
                pCurrentTower.positionBase.Y + offsetCenterY);
            buildWeapon(pCurrentScene, pCurrentTower, pTowerToBuild);
                            
            pCurrentTower = buildTower(pCurrentScene, pCurrentTower, pTowerToBuild);
            pCurrentScene.listButtons.Add(pCurrentTower);
        }
        public bool BuildTowerType(GameTime pGameTime, SceneMap pCurrentScene, Tower pCurrentTower, Tower pTowerToBuild)
        {
            if (pCurrentTower.towerID == "ROTATEWEAPON") RotateWeapon(pCurrentScene, pCurrentTower);
            if (pCurrentTower.towerNextID == null) { return false; }
            if (pCurrentTower.towerID == "MENUUPGRADE" || pCurrentTower.towerID == pCurrentTower.towerNextID) return false;
            if (pCurrentTower.towerID == "MENUTILEMAP" || pCurrentTower.towerID == "UPGRADE")
            {
                FirstAnimationBuild(pGameTime, pCurrentScene, pCurrentTower, pTowerToBuild);
                return true;
            }
            timerBuild += (float)pGameTime.ElapsedGameTime.TotalSeconds;
            if (timerBuild > 1.5f && (pCurrentTower.towerNextID == "TOWERCONSTRUCTION1BIS"
                || pCurrentTower.towerNextID == "TOWERCONSTRUCTION2BIS"
                || pCurrentTower.towerNextID == "TOWERCONSTRUCTION3BIS"))
            {
                SecondAnimationBuild(pCurrentScene, pCurrentTower, pTowerToBuild);
                return true;
            }
            if (timerBuild > 1.5f && pCurrentTower.towerNextID.Substring(0, 5) == "TOWER"
                && pCurrentTower.towerID.Substring(0, 9) == "TOWERCONS")
            {
                BuildWeaponAndTower(pGameTime, pCurrentScene, pCurrentTower, pTowerToBuild);
                return true;
            }
            return false;
        }
    }
}
