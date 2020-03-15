using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{



    GameObject pauseUI;
    bool paused;

    // Start is called before the first frame update
    void Start()
    {
        paused = false;
        pauseUI = GameObject.Find("PauseMenuUI"); 
        pauseUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    public void Resume(){
        paused = false;
        Time.timeScale = 1f;
        pauseUI.SetActive(false);
    }

    public void Pause(){
        paused = true;
        Time.timeScale = 0f;
        pauseUI.SetActive(true);
    }

    public void Restart(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        paused = false;
        Time.timeScale = 1f;
        pauseUI.SetActive(false);
    }

    public void BackToMainMenu(){
        Time.timeScale = 1f;
        paused = false;
        pauseUI.SetActive(false);
        SceneManager.LoadScene("MainMenu");
    }
}
