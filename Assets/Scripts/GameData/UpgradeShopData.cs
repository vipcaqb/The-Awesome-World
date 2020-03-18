using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

public class UpgradeShopData
{
    public float hpLevelUpgrade;
    public float damageLevelUpgrade;
    public float attackSpeedLevelUpgrade;
    public float criticalLevelUpgrade;

    public string KEY_DATA = "upgradeshop";

    public UpgradeShopData(){
        hpLevelUpgrade = 1;
        damageLevelUpgrade = 1;
        attackSpeedLevelUpgrade = 1;
        criticalLevelUpgrade = 1;
    }

    public void Save(){
        string s = JsonConvert.SerializeObject(this);

        PlayerPrefs.SetString(KEY_DATA,s);
    }

    public void Save(Shop data){
        hpLevelUpgrade = data.hpLevelUpgrade;
        damageLevelUpgrade = data.damageLevelUpgrade;
        attackSpeedLevelUpgrade = data.attackSpeedLevelUpgrade;
        criticalLevelUpgrade = data.criticalLevelUpgrade;

        string s = JsonConvert.SerializeObject(this);

        PlayerPrefs.SetString(KEY_DATA,s);
    }
}
