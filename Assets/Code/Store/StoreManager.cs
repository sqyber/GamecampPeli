using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

namespace GamecampPeli
{
    public class StoreManager : MonoBehaviour
    {
        
        [SerializeField] private int MaxHpBonus = 10;
        [SerializeField] private int CurrentHpBonus = 1;

        private TextMeshProUGUI textMesh;
        
        // Update is called once per frame
        void Start ()
        {
            textMesh = gameObject.GetComponent<TextMeshProUGUI>();
        }

        public void Update()
        {
            textMesh.text = CurrentHpBonus.ToString();
            textMesh.text = MaxHpBonus.ToString();
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
