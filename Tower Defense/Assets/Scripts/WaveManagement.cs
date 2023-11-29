using System.Collections;
using UnityEngine;
using TMPro;

public class WaveManagement : MonoBehaviour
{
    [SerializeField] float initialDelay = 3f;
    [SerializeField] float minWaveDelay = 3f;
    [SerializeField] float maxWaveDelay = 6f;
    [SerializeField] float spawnSpeedIncrease = 0.1f;
    [SerializeField] Zombie[] zombiePrefab;
    [SerializeField] float setupTime = 5f; 
    [SerializeField] int zombiesPerWave = 5; 

    public TextMeshProUGUI waveCounterText; 
    public TextMeshProUGUI waveStartTimerText; 

    bool spawn = true;
    int waveCounter = 0;

    public Transform[] spawnPositions;
    int spawnPoints = 1; 

    IEnumerator Start()
    {
        yield return new WaitForSeconds(initialDelay);
        while (spawn)
        {
            UpdateWaveCounterText(); 
            yield return StartCoroutine(StartWaveTimer()); 
            SpawnWave();
            waveCounter++;
            yield return StartCoroutine(WaitForWaveCompletion()); 
            yield return new WaitForSeconds(setupTime); 
            minWaveDelay -= spawnSpeedIncrease; 
            maxWaveDelay -= spawnSpeedIncrease;

            
            if (waveCounter % 2 == 0)
            {
                spawnPoints++;
            }

            zombiesPerWave += 2; 
        }
    }

    IEnumerator StartWaveTimer()
    {
        float timer = setupTime;
        while (timer > 0)
        {
            waveStartTimerText.text = "Next Wave Starts In: " + Mathf.Ceil(timer).ToString();
            timer -= Time.deltaTime;
            yield return null;
        }
        waveStartTimerText.text = "";
    }

    IEnumerator WaitForWaveCompletion()
    {
        while (GameObject.FindObjectOfType<Zombie>() != null) 
        {
            yield return null;
        }
    }

    public void StopSpawning()
    {
        spawn = false;
    }

    private void SpawnWave()
    {
        Debug.Log("Wave " + waveCounter + " is spawning!");
        for (int i = 0; i < zombiesPerWave; i++)
        {
            int randomZombieIndex = Random.Range(0, zombiePrefab.Length);
            Zombie randomZombie = zombiePrefab[randomZombieIndex];
            int spawnPointIndex = Random.Range(0, spawnPoints); 
            SpawnAttacker(randomZombie, spawnPointIndex);
        }
    }

    private void SpawnAttacker(Zombie myAttacker, int spawnPointIndex)
    {
        if (spawnPointIndex < 0 || spawnPointIndex >= spawnPositions.Length)
        {
            Debug.LogWarning("Invalid spawn point index!");
            return;
        }

        
        Transform selectedSpawnPoint = spawnPositions[spawnPointIndex];
        Zombie newAttacker = Instantiate(myAttacker, selectedSpawnPoint.position, selectedSpawnPoint.rotation);
        newAttacker.transform.parent = selectedSpawnPoint;
    }


    void UpdateWaveCounterText()
    {
        if (waveCounterText != null)
        {
            waveCounterText.text = "Wave: " + waveCounter.ToString();
        }
    }
}
