using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GamecampPeli
{
    public class OrbitAroundTarget : MonoBehaviour
    {
        [SerializeField] private Transform targetToOrbitAround;
        [SerializeField] private float movementSpeed = 2f;
        [SerializeField] private float rotationRadius = 2f;
        
        private float posX, posY, angle = 0f;

        private void FixedUpdate()
        {
            Rotate();
        }

        private void Rotate()
        {
            posX = targetToOrbitAround.position.x + Mathf.Cos(angle) * rotationRadius;
            posY = targetToOrbitAround.position.y + Mathf.Sin(angle) * rotationRadius;
            transform.position = new Vector2(posX, posY);
            angle = angle + Time.fixedDeltaTime * movementSpeed;

            if (angle >= 360f) angle = 0f;
        }
    }
}
