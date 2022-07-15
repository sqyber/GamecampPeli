using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GamecampPeli
{
    public class SpawnAdds : MonoBehaviour
    {
        // The GO of the boss add
        [SerializeField] private GameObject add;
        
        // Spawn time and time between add spawns
        [SerializeField] private float spawnTime = 1f;
        [SerializeField] private float spawnDelay = 7.5f;
        
        // Bool to be able to toggle add spawning
        [SerializeField] private bool stopSpawning = false;
        
        private Vector2 LeftOffset = new Vector2(2f, 1.5f);
        private Vector2 RightOffset = new Vector2(2f, -1.5f);
        
        private void Start()
        {
            InvokeRepeating(nameof(SpawnBossAdds), spawnTime, spawnDelay);
        }

        private void SpawnBossAdds()
        {
            if (stopSpawning)
            {
                CancelInvoke(nameof(SpawnBossAdds));
            }

            Vector2 BossPosition = transform.position;

            Vector2 leftSpawn = BossPosition - LeftOffset;
            Vector2 rightSpawn = BossPosition + RightOffset;
            
            Instantiate(add, leftSpawn, Quaternion.identity);
            Instantiate(add, rightSpawn, Quaternion.identity);
        }
    }
}
