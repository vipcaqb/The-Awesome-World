using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Shop : MonoBehaviour
{

    public Text money;
    public Text hp;
    public Text dmg;
    public Text atkSpd;
    public Text critical;

    public Text upgradeHp;
    public Text upgradeDmg;
    public Text upgradeAtkSpd;
    public Text upgradeCritical;

    public float hpLevelUpgrade;
    public float damageLevelUpgrade;
    public float attackSpeedLevelUpgrade;
    public float criticalLevelUpgrade;

    private void Start() {
        LoadData();
        
    }

    private void Update() {
        money.text = GameData.playerInfo.money.ToString();
        hp.text = GameData.playerInfo.maxHp.ToString();
        dmg.text = GameData.playerInfo.damage.ToString();
        atkSpd.text = GameData.playerInfo.attackSpeed.ToString();
        critical.text = GameData.playerInfo.critical.ToString();

        upgradeHp.text = (hpLevelUpgrade*500f).ToString();
        upgradeDmg.text = (damageLevelUpgrade*500f).ToString();
        upgradeAtkSpd.text = (attackSpeedLevelUpgrade*500f).ToString();
        upgradeCritical.text = (criticalLevelUpgrade*500f).ToString();
    }

    public void LoadData(){
        hpLevelUpgrade = GameData.upgradeShopData.hpLevelUpgrade;
        damageLevelUpgrade = GameData.upgradeShopData.damageLevelUpgrade;
        attackSpeedLevelUpgrade = GameData.upgradeShopData.attackSpeedLevelUpgrade;
        criticalLevelUpgrade = GameData.upgradeShopData.criticalLevelUpgrade;
    }

    public void UpgradeHp(){
        if(GameData.playerInfo.money < hpLevelUpgrade*500f){
            Debug.Log("Khong du tien");
        }
        if(GameData.playerInfo.money >= hpLevelUpgrade*500f && hpLevelUpgrade <=5){
            GameData.playerInfo.money -= hpLevelUpgrade*500f;
            GameData.playerInfo.maxHp+= 20;
            hpLevelUpgrade+=1f;
            GameData.playerInfo.Save();
            GameData.upgradeShopData.Save(this);
        }
    }

    public void UpgradeDmg(){
        if(GameData.playerInfo.money >= damageLevelUpgrade*500f && damageLevelUpgrade <=5){
            GameData.playerInfo.money -= damageLevelUpgrade*500f;
            GameData.playerInfo.damage+= 1;
            damageLevelUpgrade+=1f;
            GameData.playerInfo.Save();
            GameData.upgradeShopData.Save(this);
        }
    }

    public void UpgradeAtkSpd(){
        if(GameData.playerInfo.money >= attackSpeedLevelUpgrade*500f && attackSpeedLevelUpgrade <=5){
            GameData.playerInfo.money -= attackSpeedLevelUpgrade*500f;
            GameData.playerInfo.attackSpeed+= 0.2f;
            attackSpeedLevelUpgrade+=1f;
            GameData.playerInfo.Save();
            GameData.upgradeShopData.Save(this);
        }
    }

    public void UpgradeCritical(){
        if(GameData.playerInfo.money >= criticalLevelUpgrade*500f && criticalLevelUpgrade <=5){
            GameData.playerInfo.money -= criticalLevelUpgrade*500f;
            GameData.playerInfo.critical+= 1;
            criticalLevelUpgrade+=1f;
            GameData.playerInfo.Save();
            GameData.upgradeShopData.Save(this);
        }
    }

    public void BackToMenu(){
        SceneManager.LoadScene("MainMenu");
        GameData.playerInfo.Save();
    }
}
