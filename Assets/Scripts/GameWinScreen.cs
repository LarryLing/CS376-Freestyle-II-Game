using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameWinScreen : MonoBehaviour
{
    public GameController gameController;

    public void ShowGameWinScreen()
    {
        gameObject.SetActive(true);
    }

    public void PlayAgain()
    {
        Time.timeScale = 1.0f;

        SceneManager.LoadScene("SampleScene");
    }
}
