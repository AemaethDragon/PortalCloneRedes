using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[System.Serializable]
public class PauseMenu : MonoBehaviour
{

    //verificar se o jogo esta em pasua
    public static bool GameIsPaused = false;

    public GameObject pauseMenuUI;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            //SerializationManager.Save("testData", SaveData.currentSave);

            if (GameIsPaused == true)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
        //if (Input.GetKeyDown(KeyCode.Backspace))
        //{
        //    SaveData.currentSave = (SaveData)SerializationManager.Load(Application.persistentDataPath + "/saves/test.save");
        //}
    }

    public void Pause()
    {

        pauseMenuUI.SetActive(true);

        //parar o jogo enquanto o menu estiver ativo
        Time.timeScale = 0f;

        GameIsPaused = true;

    }

    public void Resume()
    {

        pauseMenuUI.SetActive(false);

        Time.timeScale = 1f;

        GameIsPaused = false;

    }

    public void ExitGame()
    {

        SceneManager.LoadScene(0);

    }
}
