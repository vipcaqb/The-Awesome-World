using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using UnityEngine.SceneManagement;

public class LoadPlayerData : MonoBehaviour
{

    public string nextScene;

    string KEY_DATA = "playerinfo";
    string KEY_DATA2 = "upgradeshop";

    private void Awake() {
        LoadStatusData();
        LoadShopData();

        SceneManager.LoadScene(nextScene);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void LoadStatusData(){
        string s = PlayerPrefs.GetString(KEY_DATA);

        if(string.IsNullOrEmpty(s)){
            GameData.playerInfo = new PlayerInfo();
            return;
        }

        GameData.playerInfo = JsonConvert.DeserializeObject<PlayerInfo>(s);
    }

    void LoadShopData(){
        string s = PlayerPrefs.GetString(KEY_DATA2);

        if(string.IsNullOrEmpty(s)){
            GameData.upgradeShopData = new UpgradeShopData();
            return;
        }

        GameData.upgradeShopData = JsonConvert.DeserializeObject<UpgradeShopData>(s);
    }
}
