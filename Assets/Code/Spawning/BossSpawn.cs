using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace GamecampPeli
{
    public class BossSpawn : MonoBehaviour
    {
        [SerializeField] private GameObject boss;

        [SerializeField] private GameObject bossSpawningTextGO;
        [SerializeField] private TextMeshProUGUI bossSpawningText;

        // Progress bar to track progress
        [SerializeField] private ProgressBarManager progressBar;
        
        // Spawn time
        [SerializeField] private int timeToSpawn = 5;

        // Bool to allow spawning of boss
        private bool allowBossSpawn = false;
        
        // Bool to disable spawning after boss has been spawned
        private bool bossSpawned = false;

        private void Start()
        {
            bossSpawningText.text = "Boss spawning at the starting point in " + timeToSpawn + " seconds!";
        }

        private void Update()
        {
            if (bossSpawned) return;
            
            CheckProgress();
            if (allowBossSpawn)
            {
                StartTimerToSpawn();
            }
        }

        // Function to check progress and allow the spawning of boss
        private void CheckProgress()
        {
            if (progressBar.slider.value == progressBar.MaxProgress)
            {
                allowBossSpawn = true;
            }
        }

        // Function to start the timer to spawn the boss and show the text to tell the
        // player that the boss is spawning
        private void StartTimerToSpawn()
        {
            if (bossSpawned) return;
            bossSpawned = true;
            allowBossSpawn = false;

            bossSpawningTextGO.SetActive(true);
            Invoke(nameof(SpawnBoss), timeToSpawn);
            
        }
        
        // Function to spawn boss
        private void SpawnBoss()
        {
            bossSpawningTextGO.SetActive(false);
            Instantiate(boss, transform.position, Quaternion.identity);
        }
    }
}
