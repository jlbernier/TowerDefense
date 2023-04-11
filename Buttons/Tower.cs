using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tower_Defense.Map;
using tower_Defense.Scenes;

namespace tower_Defense.Buttons
{    
    public class Tower : Button
    {
        // Menu Choose tower to build or to upgrade
        public bool isMenuToBuild { get; set; }
        public bool isMenuToRemove { get; set; }
        public Vector2 positionBase { get; private set; }
        public List<Tower> lstTower { get; private set; }
        public Tower menuTower { get; private set; }
        public Tower buildTower { get; private set; }
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
        public float angle { get; set; }
        public Tower(Game mainGame, string buttonID, Vector2 position) : base(mainGame, buttonID, position)
        {
            towerID = buttonID;
            towerLevel = 1;
            weaponLevel = 1;
        }        

        public void BuildMenuToRemove(SceneMap pCurrentScene, Tower pBaseTower, Tower pMenuToBuild)
        {
            if (isMenuToRemove)
            {
                if (towerNextID == null)
                {
                    pMenuToBuild = new Tower(mainGame, "TOWERTILEMAP", new Vector2(pBaseTower.position.X - 32, pBaseTower.position.Y - 32));
                    pMenuToBuild.towerNextID = "TOWERTILEMAP";
                    pMenuToBuild.OnClick = pCurrentScene.onClickDefault;
                    pMenuToBuild.OnHover = pCurrentScene.onHoverButtonBase;
                    pCurrentScene.listActors.Add(pMenuToBuild);
                    pCurrentScene.listActors.Remove(pBaseTower);
                }
                pBaseTower.lstTower.ForEach(tower => pCurrentScene.listActors.Remove(tower));
                pBaseTower.lstTower.Clear();
            }
        }
        public void AddTower(SceneMap pCurrentScene, Tower pMenuToBuild, Tower pIconToBuild, Vector2 position, String towerType, float scale)
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
            pMenuToBuild.lstTower.Add(pIconToBuild);
        }
        public void AddTowerIcon(SceneMap pCurrentScene, Tower pMenuToBuild, Tower pIconToBuild)
        {
            AddTower(pCurrentScene, pMenuToBuild, pIconToBuild, new Vector2(pMenuToBuild.position.X - 27, pMenuToBuild.position.Y - 107),
                            "TOWER81", 0.4f);            
            AddTower(pCurrentScene, pMenuToBuild, pIconToBuild, new Vector2(pMenuToBuild.position.X - 61, pMenuToBuild.position.Y - 107),
                            "TOWER71", 0.4f);
            AddTower(pCurrentScene, pMenuToBuild, pIconToBuild, new Vector2(pMenuToBuild.position.X - 9, pMenuToBuild.position.Y - 64),
                            "TOWER61", 0.4f);
            AddTower(pCurrentScene, pMenuToBuild, pIconToBuild, new Vector2(pMenuToBuild.position.X - 44, pMenuToBuild.position.Y - 64),
                            "TOWER51", 0.4f);
            AddTower(pCurrentScene, pMenuToBuild, pIconToBuild, new Vector2(pMenuToBuild.position.X - 79, pMenuToBuild.position.Y - 64),
                            "TOWER41", 0.4f);
            AddTower(pCurrentScene, pMenuToBuild, pIconToBuild, new Vector2(pMenuToBuild.position.X - 79, pMenuToBuild.position.Y - 24),
                            "TOWER11", 0.4f);
            AddTower(pCurrentScene, pMenuToBuild, pIconToBuild, new Vector2(pMenuToBuild.position.X - 44, pMenuToBuild.position.Y - 24),
                            "TOWER21", 0.4f);
            AddTower(pCurrentScene, pMenuToBuild, pIconToBuild, new Vector2(pMenuToBuild.position.X - 9, pMenuToBuild.position.Y - 24),
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
            pMenuToBuild.lstTower = new List<Tower>();
            pCurrentScene.listActors.Add(pMenuToBuild);
            pCurrentScene.listActors.Remove(pBaseTower);
            SpriteButton.lstButtonSprites.Remove(pBaseTower);
            AddTowerIcon(pCurrentScene, pMenuToBuild, pBaseTower);
        }

        public void AddIcon(SceneMap pCurrentScene, Tower pMenuToBuild, Tower pIconToBuild, Vector2 position, String towerType, float scale)
        {
            pIconToBuild = new Tower(mainGame, towerType, position);
            pIconToBuild.scale = scale;
            pIconToBuild.boundingBox = new Rectangle((int)pIconToBuild.position.X - 64, (int)pIconToBuild.position.Y - 64,
                   (int)(pIconToBuild.widthTexture * pIconToBuild.scale), (int)(pIconToBuild.heightTexture * pIconToBuild.scale));
            pIconToBuild.buildTower = pMenuToBuild.buildTower;
            pIconToBuild.towerToBuild = towerType;
            pIconToBuild.towerLevel = pMenuToBuild.towerLevel;
            pIconToBuild.weaponLevel = pMenuToBuild.weaponLevel;
            pIconToBuild.towerType = pMenuToBuild.towerType;
            pIconToBuild.menuTower = pMenuToBuild;
            pIconToBuild.positionBase = pMenuToBuild.positionBase;
            pIconToBuild.weaponTower = pMenuToBuild.weaponTower;
            pIconToBuild.OnHover = pCurrentScene.onHoverThreeStates;
            pIconToBuild.OnClick = pCurrentScene.onClickTowerUpgrade;
            pMenuToBuild.lstTower.Add(pIconToBuild);
            pCurrentScene.listActors.Add(pIconToBuild);
        }

        public void AddUpdateIcon(SceneMap pCurrentScene, Tower pMenuToBuild, Tower pIconToBuild)
        {
            AddIcon(pCurrentScene, pMenuToBuild, pIconToBuild, new Vector2(pMenuToBuild.position.X - 60, pMenuToBuild.position.Y - 60),
                            "ICONTOWERUP", 1.5f);          
            AddIcon(pCurrentScene, pMenuToBuild, pIconToBuild, new Vector2(pMenuToBuild.position.X + 10, pMenuToBuild.position.Y - 80),
                          "ICONWEAPONUP", 1.5f);           
            AddIcon(pCurrentScene, pMenuToBuild, pIconToBuild, new Vector2(pMenuToBuild.position.X + 80, pMenuToBuild.position.Y - 60),
                         "ICONROTATEWEAPON", 1.5f);                                                    
        }

       
        public void BuildMenuChooseTowerUpgrade(SceneMap pCurrentScene, Tower pBaseTower, Tower pMenuToBuild)
        {
            //pBaseTower.towerID = pBaseTower.towerNextID;
            pBaseTower.isMenuToBuild = false;
            pMenuToBuild = new Tower(mainGame, "BOUNDINGBOX", new Vector2(pBaseTower.position.X, pBaseTower.position.Y ));
            pMenuToBuild.buildTower = pBaseTower;
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
            pMenuToBuild.lstTower = new List<Tower>();
            pMenuToBuild.lstTower.Add(pMenuToBuild);
            AddUpdateIcon(pCurrentScene, pMenuToBuild, pBaseTower);
        }

        public void BuildMenuChooseTower(SceneMap pCurrentScene, Tower pBaseTower, Tower pMenuToBuild)
        {
            if (pBaseTower.isMenuToBuild && pBaseTower.towerID == "TOWERTILEMAP")
                BuildMenuChooseTowerType(pCurrentScene, pBaseTower, pMenuToBuild);
            else if (pBaseTower.isMenuToBuild && pBaseTower.towerID == "MENUUPGRADE")
                BuildMenuChooseTowerUpgrade(pCurrentScene, pBaseTower, pMenuToBuild);             
        }

        public void RemoveUpgradeMenu(SceneMap pCurrentScene, Tower pCurrentTower)
        {
            pCurrentScene.listActors.Remove(pCurrentTower.weaponTower);
            SpriteButton.lstButtonSprites.Remove(pCurrentTower.weaponTower);
            pCurrentScene.listActors.Remove(pCurrentTower.buildTower);
        }

        public void FirstAnimationBuild(SceneMap pCurrentScene, Tower pCurrentTower, Tower pTowerToBuild = null)
        {
            pCurrentTower.menuTower.lstTower.ForEach(tower => pCurrentScene.listActors.Remove(tower));
            if (pCurrentTower.towerID == "MENUTILEMAP")
            {
                pCurrentScene.listActors.Remove(pCurrentTower.menuTower);
                pCurrentTower.towerType = pCurrentTower.towerNextID.Substring(pCurrentTower.towerNextID.Length - 2, 1);
                pCurrentTower.position = new Vector2(pCurrentTower.positionBase.X, pCurrentTower.positionBase.Y - 32);
            }
            if (pCurrentTower.towerID == "UPGRADE")
            {
                pCurrentTower.position = pCurrentTower.positionBase;
                RemoveUpgradeMenu(pCurrentScene, pCurrentTower);                
            }
            pTowerToBuild = new Tower(mainGame, "TOWERCONSTRUCTION" + pCurrentTower.towerLevel.ToString(), pCurrentTower.position);
            pTowerToBuild.towerNextID = "TOWERCONSTRUCTION" + pCurrentTower.towerLevel + "BIS";
            pTowerToBuild.towerLevel = pCurrentTower.towerLevel;
            pTowerToBuild.weaponLevel = pCurrentTower.weaponLevel;
            pTowerToBuild.towerType = pCurrentTower.towerType;
            pTowerToBuild.OnClick = pCurrentScene.onClickDefault;
            pTowerToBuild.OnHover = pCurrentScene.onHoverDefault;
            pCurrentScene.listActors.Add(pTowerToBuild);
            timerBuild = 0;
        }

        public void SecondAnimationBuild(SceneMap pCurrentScene, Tower pCurrentTower, Tower pTowerToBuild)
        {
            SpriteButton.lstButtonSprites.Remove(pCurrentTower);
            pTowerToBuild = new Tower(mainGame, "TOWERCONSTRUCTION" + pCurrentTower.towerLevel.ToString() + "BIS", pCurrentTower.position);
            pTowerToBuild.towerNextID = "TOWER" + pCurrentTower.towerType + "1";
            pTowerToBuild.towerLevel = pCurrentTower.towerLevel;
            pTowerToBuild.weaponLevel = pCurrentTower.weaponLevel;
            pTowerToBuild.towerType = pCurrentTower.towerType;
            pTowerToBuild.OnClick = pCurrentScene.onClickDefault;
            pTowerToBuild.OnHover = pCurrentScene.onHoverDefault;
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

        public void BuildWeaponAndTower(SceneMap pCurrentScene, Tower pCurrentTower, Tower pTowerToBuild)
        {           
            position = pCurrentTower.position;
            // weapon Build                
            SpriteButton.lstButtonSprites.Remove(pCurrentTower);
            OffsetWeaponY(pCurrentTower); // 
            pTowerToBuild = new Tower(mainGame, "WEAPONTOWER" + pCurrentTower.towerType + "LEVEL" + pCurrentTower.weaponLevel.ToString(),
                    new Vector2(pCurrentTower.position.X,
                    pCurrentTower.position.Y + offsetCenterY));
            pTowerToBuild.towerLevel = pCurrentTower.towerLevel;
            pTowerToBuild.weaponLevel = pCurrentTower.weaponLevel;
            pTowerToBuild.towerType = pCurrentTower.towerType;
            pTowerToBuild.OnClick = pCurrentScene.onClickDefault;
            pTowerToBuild.OnHover = pCurrentScene.onHoverDefault;
            pCurrentScene.listActors.Remove(pCurrentTower);
            pCurrentTower = pTowerToBuild;
            // Tower build               
            pTowerToBuild = new Tower(mainGame, "TOWER" + pCurrentTower.towerType + pCurrentTower.towerLevel.ToString(),
                position);
            pTowerToBuild.towerNextID = "WEAPONTOWER" + towerType + "LEVEL" + pCurrentTower.towerLevel.ToString();
            pTowerToBuild.towerLevel = pCurrentTower.towerLevel;
            pTowerToBuild.weaponLevel = pCurrentTower.weaponLevel;
            pTowerToBuild.towerType = pCurrentTower.towerType;
            pTowerToBuild.weaponTower = pCurrentTower;
            pTowerToBuild.towerNextID = pTowerToBuild.towerID;
            pTowerToBuild.positionBase = pTowerToBuild.position;
            pTowerToBuild.OnClick = pCurrentScene.onClickDefault;
            pTowerToBuild.OnHover = pCurrentScene.onHoverTowerUpgrade;
            pCurrentScene.listActors.Add(pTowerToBuild);
            pCurrentScene.listActors.Add(pCurrentTower);
        }
        public bool BuildTowerType(SceneMap pCurrentScene, GameTime gameTime, Tower pCurrentTower, Tower pTowerToBuild = null, string pTowerType = "")
        {
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
            if (pCurrentTower.towerNextID == null) { return false; }
            if (timerBuild > 1.5f && pCurrentTower.towerNextID.Substring(0, 5) == "TOWER"
                && pCurrentTower.towerID.Substring(0, 9) == "TOWERCONS")
            {
                BuildWeaponAndTower(pCurrentScene, pCurrentTower, pTowerToBuild);
                return true;
            }
            return false;
        }
        public void OffsetWeaponY(Tower pCurrentTower)
        {
            string dataTowerID = "TOWER" + pCurrentTower.towerType + pCurrentTower.towerLevel.ToString();
            string weaponTowerID = "WEAPONTOWER"+ pCurrentTower.towerType + "LEVEL" + pCurrentTower.weaponLevel.ToString();
            offsetCenterY = ButtonGUI.Data[weaponTowerID].FrameHeight / 2 - ButtonGUI.Data[dataTowerID].FrameHeight / 2;
            offsetCenterY += ButtonGUI.Data[weaponTowerID].OffsetCenterY + ButtonGUI.Data[dataTowerID].OffsetCenterY;
        }
    }
}
