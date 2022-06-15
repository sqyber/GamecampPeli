using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GamecampPeli
{
    public class ForcePosition : MonoBehaviour
    {
        // Used to store parents position
        private Vector2 parentPosition;

        private void Update()
        {
            parentPosition = transform.parent.position;
            UpdatePosition();
        }

        // Function to update the game objects position at parents position
        private void UpdatePosition()
        {
            transform.position = parentPosition;
        }
    }
}
