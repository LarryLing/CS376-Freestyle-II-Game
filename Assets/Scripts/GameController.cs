using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class GameController : MonoBehaviour
{
    public Player player;

    public GameObject normalZombiePrefab;

    public GameObject speedZombiePrefab;

    public GameObject tankZombiePrefab;

    public TMP_Text zombiesRemainingText;

    public TMP_Text waveText;

    public UnityEvent OnWin;

    public int zombiesKilled = 0;

    public int wave = 1;

    public int zombiesSpawnedDuringWave = 0;

    public int zombiesRemaining;

    public int maxZombiesPerWave = 10;

    public float normalZombieProbability = 1f;

    public float speedZombieProbability = 0f;

    public float tankZombieProbability = 0f;

    private float timeSinceGracePeriodStart;

    private float timeBetweenWaves = 20f;

    private float timeSinceLastSpawn;

    private float timeBetweenSpawns = 6f;

    private float spawnRadius = 5f;

    private bool isGracePeriodActive = false;

    void Awake()
    {
        zombiesRemaining = maxZombiesPerWave;

        zombiesRemainingText.text = "Zombies Remaining: " + zombiesRemaining;

        waveText.text = "Wave: " + wave;
    }

    void Update()
    {
        if (!isGracePeriodActive)
        {
            if ((Time.time - timeSinceLastSpawn >= timeBetweenSpawns) && (zombiesSpawnedDuringWave < maxZombiesPerWave))
            {
                SpawnZombie();
            }
        }
        else
        {
            if (Time.time - timeSinceGracePeriodStart >= timeBetweenWaves)
            {
                ProgressToNextWave();
            }
        }
    }

    public void IncrementZombiesKilled()
    {
        zombiesKilled += 1;

        zombiesRemaining -= 1;

        zombiesRemainingText.text = "Zombies Remaining: " + zombiesRemaining;

        if (zombiesRemaining == 0)
        {
            if (wave == 5)
            {
                Time.timeScale = 0;

                OnWin.Invoke();
            }
            else
            {
                StartGracePeriod();
            }
        }
    }

    private void StartGracePeriod()
    {
        player.Heal();

        isGracePeriodActive = true;

        timeSinceGracePeriodStart = Time.time;

        zombiesRemainingText.text = "Grace Period...";
    }

    private void ProgressToNextWave()
    {
        isGracePeriodActive = false;

        zombiesSpawnedDuringWave = 0;

        normalZombieProbability -= 0.2f;

        speedZombieProbability += 0.1f;

        tankZombieProbability += 0.1f;

        wave += 1;

        timeBetweenSpawns -= 1f;

        maxZombiesPerWave = 10 * wave;

        zombiesRemaining = maxZombiesPerWave;

        zombiesRemainingText.text = "Zombies Remaining: " + zombiesRemaining;

        waveText.text = "Wave: " + wave;
    }

    private void SpawnZombie()
    {
        int zombieType = DetermineZombieType();
        Vector2 spawnLocation = DetermineSpawnLocation();

        if (zombieType == 0 || zombieType == -1)
        {
            Instantiate(normalZombiePrefab, spawnLocation, Quaternion.identity);
        }
        else if (zombieType == 1)
        {
            Instantiate(speedZombiePrefab, spawnLocation, Quaternion.identity);
        }
        else if (zombieType == 2)
        {
            Instantiate(tankZombiePrefab, spawnLocation, Quaternion.identity);
        }

        timeSinceLastSpawn = Time.time;

        zombiesSpawnedDuringWave += 1;
    }

    private Vector2 DetermineSpawnLocation()
    {
        Vector2 position = GetRandomVisiblePoint();

        for (var i = 0; i < 50 && !IsPointFree(position); i++)
        {
            position = GetRandomVisiblePoint();
        }

        return position;
    }

    private Vector2 GetRandomVisiblePoint()
    {
        Vector2 min = new Vector2(-81f, -52f);
        Vector2 max = new Vector2(81f, 45f);

        return new Vector2(Random.Range(min.x, max.x), Random.Range(min.y, max.y));
    }

    private bool IsPointFree(Vector2 position)
    {
        return Physics2D.CircleCast(position, spawnRadius, Vector2.up, 0);
    }

    private int DetermineZombieType()
    {
        float spawnFloat = Random.value;

        float speedZombieMinimumProbability = normalZombieProbability;
        float speedZombieMaximumProbability = speedZombieMinimumProbability + speedZombieProbability;

        bool spawnNormalZombie = (0f <= spawnFloat) && (spawnFloat < speedZombieMinimumProbability);
        bool spawnSpeedZombie = (speedZombieMinimumProbability <= spawnFloat) && (spawnFloat < speedZombieMaximumProbability);
        bool spawnTankZombie = (speedZombieMaximumProbability <= spawnFloat) && (spawnFloat <= 1f);

        if (spawnNormalZombie)
        {
            return 0;
        }
        else if (spawnSpeedZombie) 
        {
            return 1;
        }
        else if (spawnTankZombie)
        {
            return 2;
        }
        else
        {
            return -1;
        }
    }
}
