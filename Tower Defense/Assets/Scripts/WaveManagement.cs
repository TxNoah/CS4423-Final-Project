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
    [SerializeField] float setupTime = 5f; // Setup time before the next wave
    [SerializeField] int zombiesPerWave = 5; // Number of zombies per wave

    public TextMeshProUGUI waveCounterText; // Reference to TextMeshPro text component
    public TextMeshProUGUI waveStartTimerText; // Reference to TextMeshPro text component for timer

    bool spawn = true;
    int waveCounter = 0;

    public Transform[] spawnPositions;
    int spawnPoints = 1; // Initial number of spawn points

    IEnumerator Start()
    {
        yield return new WaitForSeconds(initialDelay);
        while (spawn)
        {
            UpdateWaveCounterText(); // Update wave counter text
            yield return StartCoroutine(StartWaveTimer()); // Display the timer before starting the wave
            SpawnWave();
            waveCounter++;
            yield return StartCoroutine(WaitForWaveCompletion()); // Wait until all zombies are eliminated
            yield return new WaitForSeconds(setupTime); // Give the user setup time
            minWaveDelay -= spawnSpeedIncrease; // Increase spawn speed for the next wave
            maxWaveDelay -= spawnSpeedIncrease;

            // Increase spawn points every three levels
            if (waveCounter % 2 == 0)
            {
                spawnPoints++;
            }

            zombiesPerWave += 2; // Increase the number of zombies for the next wave
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
        waveStartTimerText.text = ""; // Hide the timer text after the countdown finishes
    }

    IEnumerator WaitForWaveCompletion()
    {
        while (GameObject.FindObjectOfType<Zombie>() != null) // Check if any zombies are remaining
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
            int spawnPointIndex = Random.Range(0, spawnPoints); // Select random spawn point
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

        // Instantiate the attacker at the specified spawn point index
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
