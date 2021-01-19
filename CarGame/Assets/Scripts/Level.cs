using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
    [SerializeField] float delayInSeconds = 2f;

    IEnumerator WaitAndLoad()
    {
        yield return new WaitForSeconds(delayInSeconds);
        SceneManager.LoadScene("GameOver");
    }
   public void LoadStartMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void LoadGame()
    {
        SceneManager.LoadScene("CarGame");
        //reset the GameSession from the begining
        FindObjectOfType<GameSession>().ResetGame();
    }

    public void LoadGameOver()
    {
        StartCoroutine(WaitAndLoad());
    }

    public static void LoadWinner()
    {
        SceneManager.LoadScene("WinnerScene");
    }
    

    public void QuitGame()
    {
        Application.Quit();
    }
}
