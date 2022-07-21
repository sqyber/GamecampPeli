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
        private ShopCurrencyManager currencyManager;

        
        // Update is called once per frame
        void Start ()
        {
            textMesh = gameObject.GetComponent<TextMeshProUGUI>();
            currencyManager = FindObjectOfType<ShopCurrencyManager>();
        }

        public void Update()
        {
            textMesh.text = currentSpeedBonus + " / " + maxSpeedBonus;

            Limiter();
            }
        

        public void IncreaseValue()
        {
            if (currencyManager.SavedCurrency >10* currentSpeedBonus)
            {
                currentSpeedBonus++;
                currencyManager.SavedCurrency -= 10 * currentSpeedBonus;
            }
            else
            {
                return;
            }
                
        }
        //decrease upgrade level
        public void DecreaseValue()
        {
            if (currentSpeedBonus > 1)
            {
                currentSpeedBonus--;
                currencyManager.SavedCurrency += 10 * currentSpeedBonus;
            }
            else
            {
                return;
            }
                
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
