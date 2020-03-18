using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Newtonsoft.Json;

public class LoadGamePlayData : MonoBehaviour
{
    public string nextScene;

    string KEY_DATA = "playerinfo";

    private void Awake() {
        LoadStatusData();

        SceneManager.LoadScene(nextScene);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
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
}
