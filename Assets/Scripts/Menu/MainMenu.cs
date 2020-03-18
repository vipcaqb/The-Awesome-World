using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GoToGamePlay(){
        SceneManager.LoadScene("LoadGamePlay");
    }

    public void GoToSelectLevel(){
        SceneManager.LoadScene("SelectLevel");
    } 

    public void GoToOptions(){
        SceneManager.LoadScene("Options");
    }

    public void GotoUpgradeShop(){
        SceneManager.LoadScene("LoadShop");
    }

    public void Exit(){
        Application.Quit();
    }
}
