using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOverScreen : MonoBehaviour
{
    public GameController gameController;
    public TMP_Text ZombiesKilledText;
    public TMP_Text WavesSurvivedText;

    public void ShowGameOverScreen()
    {
        ZombiesKilledText.text = "Zombies Killed: " + gameController.zombiesKilled;
        WavesSurvivedText.text = "Waves Survived: " + gameController.wavesSurvived;

        gameObject.SetActive(true);
    }

    public void TryAgain()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
