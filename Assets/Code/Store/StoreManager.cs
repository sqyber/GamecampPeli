using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

namespace GamecampPeli
{
    public class StoreManager : MonoBehaviour
    {

        [SerializeField] private int MaxHpBonus = 10;
        [SerializeField] int CurrentHpBonus = 1;

        // Update is called once per frame
        void Start () {
     
        }

        public void Update()
        {

        }

        public void IncreaseValue()
            {
                CurrentHpBonus++;
            }

            public void DecreaseValue()
            {
                CurrentHpBonus--;
            }


        }
    }
