using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GamecampPeli
{
    public class DestroyAfterAnimation : MonoBehaviour
    {
        public void Destroy()
        {
            Destroy(gameObject);
        }
    }
}
