using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GamecampPeli
{
    public class SpawnEnemies : MonoBehaviour
    {
        // Enemy objects to spawn
        [SerializeField] private GameObject smallMob;
        //[SerializeField] private GameObject bigMob;
        //[SerializeField] private GameObject boss;

        // Spawn time and delay between spawns
        [SerializeField] private float spawnTime = 1.0f;
        [SerializeField] private float spawnDelay = 2.0f;
        
        // Bool to stop spawning
        [SerializeField] private bool stopSpawning = false;
        
        private void Start()
        {
            InvokeRepeating(nameof(SpawnEnemy), spawnTime, spawnDelay);
        }

        private void SpawnEnemy()
        {
            Instantiate(smallMob, transform.position, Quaternion.identity);
            if (stopSpawning)
            {
                CancelInvoke(nameof(SpawnEnemy));
            }
        }
    }
}
