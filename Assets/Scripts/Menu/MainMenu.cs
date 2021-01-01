using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{

    public Animator transition;
    public float transitionTime = 1f;
    public void PlayGame()
    {
        FindObjectOfType<AudioManager>().PlayAudio(("gameStart"));
        StartCoroutine(LoadLevel(1));
    }
    
    public void ExitGame()
    {
        Application.Quit();
        FindObjectOfType<AudioManager>().PlayAudio(("buttonClick"));
    }

    IEnumerator LoadLevel(int SceneIndex)
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(SceneIndex);
    }
}
