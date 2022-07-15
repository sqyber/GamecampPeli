using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace GamecampPeli
{
    public class SpawnEnemies : MonoBehaviour
    {
        // Enemy objects to spawn
        [SerializeField] private GameObject smallMob;
        [SerializeField] private GameObject bigMob;

        // Progressbar to track progress
        [SerializeField] private ProgressBarManager progressBar;

        // Spawn time and delay between spawns
        [SerializeField] private float spawnTime = 1.0f;
        [SerializeField] private float spawnDelay = 2.0f;

        // Division value for bigger mob spawns
        [SerializeField] private int divisionValueForBiggerMobs = 10;
        
        // Bool for spawning big mob
        [SerializeField] private bool spawnBigMob = false;

        // Bool to stop spawning
        [SerializeField] private bool stopSpawning = false;

        private int dividedValue;
        private int valueToSpawnBigMob;

        private void Start()
        {
            dividedValue = progressBar.MaxProgress / divisionValueForBiggerMobs;
            valueToSpawnBigMob = dividedValue;
            InvokeRepeating(nameof(SpawnEnemy), spawnTime, spawnDelay);
        }

        // Function to spawn enemies
        private void SpawnEnemy()
        {
            if (stopSpawning)
            {
                CancelInvoke(nameof(SpawnEnemy));
            }
            
            CheckForBigMobSpawn();
            
            if (spawnBigMob)
            {
                Instantiate(bigMob, transform.position, Quaternion.identity);
                valueToSpawnBigMob += dividedValue;
                spawnBigMob = false;
            }
            else
            {
                Instantiate(smallMob, transform.position, Quaternion.identity);
            }
        }

        // Function to check progress for spawning a bigger mob
        private void CheckForBigMobSpawn()
        {
            if (progressBar.slider.value >= valueToSpawnBigMob)
            {
                spawnBigMob = true;
            }
        }
    }
}
