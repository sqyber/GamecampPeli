using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GamecampPeli
{
    public class BonusSaver : MonoBehaviour
    {
        private HealthBonus hp;
        private SpeedBonus spd;
        private W1Bonus w1;
        private W2Bonus w2;
        private W3Bonus w3;
        private W4Bonus w4;

        private void Start()
        {
            hp = FindObjectOfType<HealthBonus>();
            spd = FindObjectOfType<SpeedBonus>();
            w1 = FindObjectOfType<W1Bonus>();
            w2 = FindObjectOfType<W2Bonus>();
            w3 = FindObjectOfType<W3Bonus>();
            w4 = FindObjectOfType<W4Bonus>();
        }

        public void performSave()
        {
            hp.HealthPrefSave();
            spd.SpeedPrefSave();
            w1.W1PrefSave();
            w2.W2PrefSave();
            w3.W3PrefSave();
            w4.W4PrefSave();
        }
    }
}
