using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using UnityEngine.SceneManagement;

public class LoadPlayerData : MonoBehaviour
{

    public string nextScene;

    string KEY_DATA = "playerinfo";
    private void Awake() {
        LoadData();

        SceneManager.LoadScene(nextScene);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void LoadData(){
        string s = PlayerPrefs.GetString(KEY_DATA);

        if(string.IsNullOrEmpty(s)){
            GameData.playerInfo = new PlayerInfo();
            return;
        }

        GameData.playerInfo = JsonConvert.DeserializeObject<PlayerInfo>(s);
    }
}
