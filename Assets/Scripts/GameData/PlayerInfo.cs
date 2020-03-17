using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

public class PlayerInfo 
{
    public float money;
    public float maxHp;
    public float damage;
    public float attackSpeed;
    public float critical;

    string KEY_DATA = "playerinfo";

    //Constructor
    public PlayerInfo(){
        money = 0f;
        maxHp = 100f;
        damage = 8f;
        attackSpeed = 1f;
        critical = 0f;
    }
    
    public void Save(Status sta){
        money = sta.money;
        maxHp = sta.maxHp;
        damage = sta.damage;
        attackSpeed = sta.attackSpeed;
        critical = sta.critical;

        //convert data sang string

        string s = JsonConvert.SerializeObject(this);

        //Dung PlayerPrefs luu du lieu lai

        PlayerPrefs.SetString(KEY_DATA,s);
    }
}
