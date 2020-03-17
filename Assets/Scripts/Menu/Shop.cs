using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{

    public Text money;
    public Text hp;
    public Text dmg;
    public Text atkSpd;
    public Text critical;

    private void Start() {
        LoadData();
        
    }

    public void LoadData(){
        money.text = GameData.playerInfo.money.ToString();
        hp.text = GameData.playerInfo.maxHp.ToString();
        dmg.text = GameData.playerInfo.damage.ToString();
        atkSpd.text = GameData.playerInfo.attackSpeed.ToString();
        critical.text = GameData.playerInfo.critical.ToString();
    }

}
