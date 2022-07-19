using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

namespace GamecampPeli
{
    public class W1Bonus : MonoBehaviour
    {
        
        [SerializeField] private int maxDmgBonus = 10;
        [SerializeField] private int currentDmgBonus = 1;

        private TextMeshProUGUI textMesh;
        
        // Update is called once per frame
        void Start ()
        {
            textMesh = gameObject.GetComponent<TextMeshProUGUI>();
        }

        public void Update()
        {
            textMesh.text = currentDmgBonus + " / " + maxDmgBonus;

            Limiter();
            }
        

        public void IncreaseValue()
            {
                currentDmgBonus++;
            }

        public void DecreaseValue()
            {
                currentDmgBonus--;
            }

        public void Limiter()
            {
                if (currentDmgBonus > maxDmgBonus)
                {
                    currentDmgBonus = maxDmgBonus;
                }
                else if (currentDmgBonus < 1)
                {
                    currentDmgBonus = 1;
                }
            }
    }
    }
