using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

namespace GamecampPeli
{
    public class SpeedBonus : MonoBehaviour
    {
        
        [SerializeField] private int maxSpeedBonus = 10;
        [SerializeField] private int currentSpeedBonus = 1;

        private TextMeshProUGUI textMesh;
        
        // Update is called once per frame
        void Start ()
        {
            textMesh = gameObject.GetComponent<TextMeshProUGUI>();
        }

        public void Update()
        {
            textMesh.text = currentSpeedBonus + " / " + maxSpeedBonus;

            Limiter();
            }
        

        public void IncreaseValue()
            {
                currentSpeedBonus++;
            }

        public void DecreaseValue()
            {
                currentSpeedBonus--;
            }

        public void Limiter()
            {
                if (currentSpeedBonus > maxSpeedBonus)
                {
                    currentSpeedBonus = maxSpeedBonus;
                }
                else if (currentSpeedBonus < 1)
                {
                    currentSpeedBonus = 1;
                }
            }
    }
    }
