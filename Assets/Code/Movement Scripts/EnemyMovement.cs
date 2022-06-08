using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GamecampPeli
{
    public class EnemyMovement : MonoBehaviour
    {
        private GameObject target;
        
        [SerializeField] private float speed = 1f;
        
        // Start is called before the first frame update
        private void Start()
        {
            target = GameObject.FindGameObjectWithTag("PlayerCharacter");
        }

        // Update is called once per frame
        private void Update()
        {
            transform.position = Vector2.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
        }
    }
}
