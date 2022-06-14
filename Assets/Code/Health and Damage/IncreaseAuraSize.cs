using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GamecampPeli
{
    public class IncreaseAuraSize : MonoBehaviour
    {
        [SerializeField] private Vector3 sizeIncrement = new Vector2(0.1f, 0.1f);

        public void increaseAuraSize()
        {
            transform.localScale += sizeIncrement;
        }
    }
}
