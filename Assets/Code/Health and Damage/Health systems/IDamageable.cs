using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GamecampPeli
{
    // Interface with a DealDamage function that is used for damaging enemies and the player
    public interface IDamageable
    {
        void DealDamage(int damage);
    }
}