using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GamecampPeli
{
    public class FollowPlayer : MonoBehaviour
    {
        [SerializeField] private GameObject playerCharacter;
        [SerializeField] private float cameraZCoordinate = -10;

        private Vector2 playerPosition;
        private Vector3 newCameraPosition;

        private void Start()
        {
            GetPlayerPosition();
        }

        private void FixedUpdate()
        {
            UpdateCameraPosition();
            GetPlayerPosition();
        }

        // Function used to get the players position
        private void GetPlayerPosition()
        {
            playerPosition = playerCharacter.transform.position;
        }

        // Function to update the cameras position, this changes
        // according to the players position.
        private void UpdateCameraPosition()
        {
            newCameraPosition.x = playerPosition.x;
            newCameraPosition.y = playerPosition.y;
            newCameraPosition.z = cameraZCoordinate;

            transform.position = newCameraPosition;
        }
    }
}