using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tower_Defense.Animation;
using tower_Defense.Map;
using tower_Defense.Scenes;

namespace tower_Defense.Buttons
{
    public class Tower : Button
    {
        // Menu Choose tower to build or to upgrade
        public bool isMenuToBuild { get; set; }
        public bool isMenuToRemove { get; set; }
        public bool isWeaponTower { get; set; }
        public Vector2 positionBase { get; private set; }
        public List<Tower> lstButtonsMenu { get; private set; }
        public Tower menuTower { get; private set; }
        public Tower weaponTower { get; private set; }
        public String towerToBuild { get; set; }
        public string towerID { get; set; }
        public string towerNextID { get; set; }
        public string towerType { get; set; }
        public int towerLevel { get; set; }
        public int weaponLevel { get; set; }
        public float timerBuild { get; set; }
        public bool test { get; set; }
        public int offsetCenterY { get; set; }
        public bool isCooldownShootUp { get; set; }
        public float angle { get; set; }
        public Tower(Game mainGame, string buttonID, Vector2 position) : base(mainGame, buttonID, position)
        {
            towerID = buttonID;
            towerLevel = 1;
            weaponLevel = 1;
        }
        public void MenuToRemove(SceneMap pCurrentScene, Tower pMenuToRemove, Tower pTowerToBuild)
        {
            if (isMenuToRemove)
            {
                if (towerNextID == null)
                {
                    pTowerToBuild = new Tower(mainGame, "TOWERTILEMAP", pMenuToRemove.positionBase);
                    pTowerToBuild.towerNextID = "TOWERTILEMAP";
                    pTowerToBuild.OnClick = pCurrentScene.onClickDefault;
                    pTowerToBuild.OnHover = pCurrentScene.onHoverButtonBase;
                    pCurrentScene.listActors.Add(pTowerToBuild);
                    //pCurrentScene.listActors.Remove(pMenuToRemove);
                }
                pMenuToRemove.lstButtonsMenu.ForEach(tower => {
                    tower.ToRemove = true;
                    pCurrentScene.listActors.Remove(tower);
                });
                pMenuToRemove.lstButtonsMenu.Clear();
            }
        }
        public void AddButtonChooseTowerIcon(SceneMap pCurrentScene, Tower pMenuToBuild, Tower pIconToBuild, Vector2 position, String towerType, float scale)
        {
            pIconToBuild = new Tower(mainGame, towerType, position);
            pIconToBuild.scale = scale;
            pIconToBuild.boundingBox = new Rectangle((int)pIconToBuild.position.X, (int)pIconToBuild.position.Y,
                   (int)(pIconToBuild.widthTexture * pIconToBuild.scale), (int)(pIconToBuild.heightTexture * pIconToBuild.scale));
            pIconToBuild.positionBase = pMenuToBuild.positionBase;
            pIconToBuild.towerToBuild = towerType;
            pIconToBuild.OnClick = pCurrentScene.onClickTowerType;
            pIconToBuild.OnHover = pCurrentScene.onHoverDefault;
            pIconToBuild.menuTower = pMenuToBuild;
            pCurrentScene.listActors.Add(pIconToBuild);
            pMenuToBuild.lstButtonsMenu.Add(pIconToBuild);
        }
        public void AddButtonChooseTowerType(SceneMap pCurrentScene, Tower pMenuToBuild, Tower pIconToBuild)
        {
            AddButtonChooseTowerIcon(pCurrentScene, pMenuToBuild, pIconToBuild, new Vector2(pMenuToBuild.position.X - 27, pMenuToBuild.position.Y - 107),
                            "TOWER81", 0.4f);
            AddButtonChooseTowerIcon(pCurrentScene, pMenuToBuild, pIconToBuild, new Vector2(pMenuToBuild.position.X - 61, pMenuToBuild.position.Y - 107),
                            "TOWER71", 0.4f);
            AddButtonChooseTowerIcon(pCurrentScene, pMenuToBuild, pIconToBuild, new Vector2(pMenuToBuild.position.X - 9, pMenuToBuild.position.Y - 64),
                            "TOWER61", 0.4f);
            AddButtonChooseTowerIcon(pCurrentScene, pMenuToBuild, pIconToBuild, new Vector2(pMenuToBuild.position.X - 44, pMenuToBuild.position.Y - 64),
                            "TOWER51", 0.4f);
            AddButtonChooseTowerIcon(pCurrentScene, pMenuToBuild, pIconToBuild, new Vector2(pMenuToBuild.position.X - 79, pMenuToBuild.position.Y - 64),
                            "TOWER41", 0.4f);
            AddButtonChooseTowerIcon(pCurrentScene, pMenuToBuild, pIconToBuild, new Vector2(pMenuToBuild.position.X - 79, pMenuToBuild.position.Y - 24),
                            "TOWER11", 0.4f);
            AddButtonChooseTowerIcon(pCurrentScene, pMenuToBuild, pIconToBuild, new Vector2(pMenuToBuild.position.X - 44, pMenuToBuild.position.Y - 24),
                            "TOWER21", 0.4f);
            AddButtonChooseTowerIcon(pCurrentScene, pMenuToBuild, pIconToBuild, new Vector2(pMenuToBuild.position.X - 9, pMenuToBuild.position.Y - 24),
                            "TOWER31", 0.4f);
        }
        public void BuildMenuChooseTowerType(SceneMap pCurrentScene, Tower pBaseTower, Tower pMenuToBuild)
        {
            pMenuToBuild = new Tower(mainGame, "WOODENBOX", new Vector2(pBaseTower.position.X + 32, pBaseTower.position.Y + 32));
            pMenuToBuild.scale = 1.5f;
            pMenuToBuild.boundingBox = new Rectangle((int)(pMenuToBuild.position.X -
                                pMenuToBuild.widthTexture * pMenuToBuild.scale + 32),
                                (int)(pMenuToBuild.position.Y -
                                pMenuToBuild.heightTexture * pMenuToBuild.scale + 32),
                                (int)(pMenuToBuild.widthTexture * pMenuToBuild.scale),
                                (int)(pMenuToBuild.heightTexture * pMenuToBuild.scale));
            pMenuToBuild.positionBase = pBaseTower.position;
            pMenuToBuild.OnClick = pCurrentScene.onClickDefault;
            pMenuToBuild.OnHover = pCurrentScene.onHoverMenuTypeTower;
            pCurrentScene.listActors.Add(pMenuToBuild);
            pMenuToBuild.lstButtonsMenu = new List<Tower>
            {
                pMenuToBuild
            };
            pBaseTower.ToRemove = true;
            pCurrentScene.listActors.Remove(pBaseTower);
            SpriteButton.lstButtonSprites.Remove(pBaseTower);
            AddButtonChooseTowerType(pCurrentScene, pMenuToBuild, pBaseTower);
        }
        public void AddButtonUpgradeIcon(SceneMap pCurrentScene, Tower pMenuToBuild, Tower pIconToBuild, Vector2 position, String towerType, float scale)
        {
            pIconToBuild = new Tower(mainGame, towerType, position);
            pIconToBuild.scale = scale;
            pIconToBuild.boundingBox = new Rectangle((int)pIconToBuild.position.X - 64, (int)pIconToBuild.position.Y - 64,
                   (int)(pIconToBuild.widthTexture * pIconToBuild.scale), (int)(pIconToBuild.heightTexture * pIconToBuild.scale));
            pIconToBuild.menuTower = pMenuToBuild.menuTower;
            //pIconToBuild.towerToBuild = towerType;
            pIconToBuild.towerLevel = pMenuToBuild.towerLevel;
            pIconToBuild.weaponLevel = pMenuToBuild.weaponLevel;
            pIconToBuild.towerType = pMenuToBuild.towerType;
            pIconToBuild.menuTower = pMenuToBuild;
            pIconToBuild.positionBase = pMenuToBuild.positionBase;
            pIconToBuild.weaponTower = pMenuToBuild.weaponTower;
            pIconToBuild.OnHover = pCurrentScene.onHoverThreeStates;
            pIconToBuild.OnClick = pCurrentScene.onClickTowerUpgrade;
            pMenuToBuild.lstButtonsMenu.Add(pIconToBuild);
            pCurrentScene.listActors.Add(pIconToBuild);
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
            pMenuToBuild = new Tower(mainGame, "BOUNDINGBOX", new Vector2(pBaseTower.position.X, pBaseTower.position.Y));
            pMenuToBuild.menuTower = pBaseTower;
            pMenuToBuild.positionBase = pBaseTower.positionBase;
            pMenuToBuild.OnClick = pCurrentScene.onClickDefault;
            pMenuToBuild.OnHover = pCurrentScene.onHoverMenuTypeTower;
            pMenuToBuild.towerNextID = pMenuToBuild.towerID;
            pMenuToBuild.towerLevel = pBaseTower.towerLevel;
            pMenuToBuild.weaponLevel = pBaseTower.weaponLevel;
            pMenuToBuild.towerType = pBaseTower.towerType;
            pMenuToBuild.positionBase = pBaseTower.positionBase;
            pMenuToBuild.menuTower = pBaseTower;
            pMenuToBuild.weaponTower = pBaseTower.weaponTower;
            pCurrentScene.listActors.Add(pMenuToBuild);
            pMenuToBuild.lstButtonsMenu = new List<Tower>
            {
                pMenuToBuild
            };
            AddButtonUpgrade(pCurrentScene, pMenuToBuild, pBaseTower);
        }
        public void BuildMenu(SceneMap pCurrentScene, Tower pBaseTower, Tower pMenuToBuild)
        {
            if (pBaseTower.isMenuToBuild && pBaseTower.towerID == "TOWERTILEMAP")
                BuildMenuChooseTowerType(pCurrentScene, pBaseTower, pMenuToBuild);
            else if (pBaseTower.isMenuToBuild && pBaseTower.towerID == "MENUUPGRADE")
                BuildMenuChooseUpgrade(pCurrentScene, pBaseTower, pMenuToBuild);
        }

        public void FirstAnimationBuild(SceneMap pCurrentScene, Tower pCurrentTower, Tower pTowerToBuild = null)
        {
            pCurrentTower.menuTower.lstButtonsMenu.ForEach(tower => pCurrentScene.listActors.Remove(tower));
            if (pCurrentTower.towerID == "MENUTILEMAP")
            {
                pCurrentScene.listActors.Remove(pCurrentTower.menuTower);
                pCurrentTower.towerType = pCurrentTower.towerNextID.Substring(pCurrentTower.towerNextID.Length - 2, 1);
                pCurrentTower.position = new Vector2(pCurrentTower.positionBase.X, pCurrentTower.positionBase.Y - 32);
            }
            if (pCurrentTower.towerID == "UPGRADE")
            {
                SpriteButton.lstButtonSprites.Remove(pCurrentTower);
                pCurrentTower.position = pCurrentTower.positionBase;
                MenuToRemove(pCurrentScene, pCurrentTower, pTowerToBuild);
            }
            pTowerToBuild = new Tower(mainGame, "TOWERCONSTRUCTION" + pCurrentTower.towerLevel.ToString(), pCurrentTower.position)
            {
                towerNextID = "TOWERCONSTRUCTION" + pCurrentTower.towerLevel + "BIS",
                towerLevel = pCurrentTower.towerLevel,
                weaponLevel = pCurrentTower.weaponLevel,
                towerType = pCurrentTower.towerType,
                buttonID = pCurrentTower.buttonID,
                positionBase = pCurrentTower.positionBase,
                OnClick = pCurrentScene.onClickDefault,
                OnHover = pCurrentScene.onHoverDefault
            };
            pCurrentScene.listActors.Add(pTowerToBuild);
            timerBuild = 0;
        }

        public void SecondAnimationBuild(SceneMap pCurrentScene, Tower pCurrentTower, Tower pTowerToBuild)
        {
            SpriteButton.lstButtonSprites.Remove(pCurrentTower);
            pTowerToBuild = new Tower(mainGame, "TOWERCONSTRUCTION" + pCurrentTower.towerLevel.ToString() + "BIS", pCurrentTower.position)
            {
                towerNextID = "TOWER" + pCurrentTower.towerType + "1",
                towerLevel = pCurrentTower.towerLevel,
                weaponLevel = pCurrentTower.weaponLevel,
                towerType = pCurrentTower.towerType,
                positionBase = pCurrentTower.positionBase,
                OnClick = pCurrentScene.onClickDefault,
                OnHover = pCurrentScene.onHoverDefault
            };
            pCurrentScene.listActors.Remove(pCurrentTower);
            pCurrentScene.listActors.Add(pTowerToBuild);
            timerBuild = 0;
        }
        public void RotateWeapon(Tower pCurrentTower)
        {
            //pTowerToBuild.rotation = MathHelper.ToRadians(180);
            pCurrentTower.weaponTower.angle += 90;
            pCurrentTower.towerID = "ICONROTATEWEAPON";


            pCurrentTower.weaponTower.rotation = MathHelper.ToRadians(pCurrentTower.weaponTower.angle);
        }

        public int OffsetTowerY(Tower pCurrentTower)
        {
            string dataTowerID = "TOWER" + pCurrentTower.towerType + pCurrentTower.towerLevel.ToString();           
            offsetCenterY = TDData.Data[dataTowerID].OffsetCenterY;
            return offsetCenterY;
        }

        public void OffsetWeaponY(Tower pCurrentTower)
        {
            string dataTowerID = "TOWER" + pCurrentTower.towerType + pCurrentTower.towerLevel.ToString();
            string weaponTowerID = "WEAPONTOWER" + pCurrentTower.towerType + "LEVEL" + pCurrentTower.weaponLevel.ToString();
            offsetCenterY = TDData.Data[weaponTowerID].FrameHeight / 2 - TDData.Data[dataTowerID].FrameHeight / 2;
            offsetCenterY += TDData.Data[weaponTowerID].OffsetCenterY;
        }

        public void buildWeapon(SceneMap pCurrentScene, Tower pCurrentTower, Tower pTowerToBuild)
        {
            pTowerToBuild.towerLevel = pCurrentTower.towerLevel;
            pTowerToBuild.weaponLevel = pCurrentTower.weaponLevel;
            pTowerToBuild.towerType = pCurrentTower.towerType;
            pTowerToBuild.isWeaponTower = true;
            pTowerToBuild.towerNextID = null;
            pTowerToBuild.positionBase = pCurrentTower.position;
            pTowerToBuild.OnClick = pCurrentScene.onClickDefault;
            pTowerToBuild.OnHover = pCurrentScene.onHoverDefault;
        }
        public Tower buildTower(SceneMap pCurrentScene, Tower pCurrentTower, Tower pTowerToBuild)
        {
            pTowerToBuild = new Tower(mainGame, "TOWER" + pCurrentTower.towerType + pCurrentTower.towerLevel.ToString(),
                    new Vector2(pCurrentTower.positionBase.X,
                    pCurrentTower.positionBase.Y + offsetCenterY))
            {
                towerLevel = pCurrentTower.towerLevel,
                weaponLevel = pCurrentTower.weaponLevel,
                towerType = pCurrentTower.towerType,
                towerNextID = null,
                positionBase = pCurrentTower.position,
                weaponTower = pCurrentTower,
                OnClick = pCurrentScene.onClickDefault,
                OnHover = pCurrentScene.onHoverDefault,
            };
            return pTowerToBuild;
        }

        public void BuildWeaponAndTower(SceneMap pCurrentScene, Tower pCurrentTower, Tower pTowerToBuild, SpriteTowerFilter spriteTowerFilter)
        {           
            //position = pCurrentTower.position;
            SpriteButton.lstButtonSprites.Remove(pCurrentTower);
            pCurrentScene.listActors.Remove(pCurrentTower);
            // weapon Build
            if (pCurrentTower.buttonID == "ICONTOWERUP")
            {

            }
            else if (pCurrentTower.buttonID == "ICONWEAPONUP")
            {
                SpriteButton.lstButtonSprites.Remove(pCurrentTower);
            }
            else
            {
                OffsetTowerY(pCurrentTower);
                spriteTowerFilter.AddTower(mainGame, "WEAPONTOWER" + towerType + "LEVEL" + pCurrentTower.towerLevel.ToString(), pCurrentTower, pCurrentScene);
                pTowerToBuild = spriteTowerFilter.liste[spriteTowerFilter.liste.Count() - 1];
                buildWeapon(pCurrentScene, pCurrentTower, pTowerToBuild);
                pCurrentTower = buildTower(pCurrentScene, pCurrentTower, pTowerToBuild);                
                pCurrentScene.listActors.Add(pCurrentTower);
                pCurrentScene.listActors.Add(pTowerToBuild);
            }

            /*
            OffsetWeaponY(pCurrentTower); 
            pCurrentTower.ToRemove = true;
            pCurrentTower.position = new Vector2(pCurrentTower.position.X,
                    pCurrentTower.position.Y + offsetCenterY);

            pTowerToBuild = new Tower(mainGame, "WEAPONTOWER" + pCurrentTower.towerType + "LEVEL" + pCurrentTower.weaponLevel.ToString(),
                    pCurrentTower.position);
            pTowerToBuild.towerLevel = pCurrentTower.towerLevel;
            pTowerToBuild.weaponLevel = pCurrentTower.weaponLevel;
            pTowerToBuild.towerType = pCurrentTower.towerType;
            pTowerToBuild.OnClick = pCurrentScene.onClickDefault;
            pTowerToBuild.OnHover = pCurrentScene.onHoverDefault;
            */
            //buildWeapon(pCurrentScene, pCurrentTower, pTowerToBuild, spriteTowerFilter);
            //
            /*
            pCurrentTower = pTowerToBuild;
            // Tower build               
            pTowerToBuild = new Tower(mainGame, "TOWER" + pCurrentTower.towerType + pCurrentTower.towerLevel.ToString(),
                position);
            pTowerToBuild.weaponTower = pCurrentTower;
            pTowerToBuild.towerLevel = pCurrentTower.towerLevel;
            pTowerToBuild.weaponLevel = pCurrentTower.weaponLevel;
            pTowerToBuild.towerType = pCurrentTower.towerType;
            pTowerToBuild.positionBase = pTowerToBuild.position;
            pTowerToBuild.OnClick = pCurrentScene.onClickDefault;
            pTowerToBuild.OnHover = pCurrentScene.onHoverTowerUpgrade;
            */
           
        }
        
        public bool BuildTowerType(SceneMap pCurrentScene, GameTime gameTime, Tower pCurrentTower, Tower pTowerToBuild, SpriteTowerFilter spriteTowerFilter)
        {
            if (pCurrentTower.towerNextID == null) { return false; }
            if (pCurrentTower.towerID == "ROTATEWEAPON") RotateWeapon(pCurrentTower);
            if (pCurrentTower.towerID == "MENUUPGRADE" || pCurrentTower.towerID == pCurrentTower.towerNextID) return false;
            if (pCurrentTower.towerID == "MENUTILEMAP" || pCurrentTower.towerID == "UPGRADE")
            {
                FirstAnimationBuild(pCurrentScene, pCurrentTower, pTowerToBuild);
                return true;
            }
            timerBuild += (float)gameTime.ElapsedGameTime.TotalSeconds;
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
                BuildWeaponAndTower(pCurrentScene, pCurrentTower, pTowerToBuild, spriteTowerFilter);
                return true;
            }
            return false;
        }
        
    }
}
