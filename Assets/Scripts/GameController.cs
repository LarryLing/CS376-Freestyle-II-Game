using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public int zombiesKilled = 0;
    public int wavesSurvived = 0;

    public void IncrementZombiesKilled()
    {
        zombiesKilled++;
    }
}
