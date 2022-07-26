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



        // Start is called before the first frame update
        void Start()
        {
            
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
