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
        [SerializeField] private int baseCostOfUpgrade = 10;

        private TextMeshProUGUI textMesh;
        private ShopCurrencyManager currencyManager;

        
        // Update is called once per frame
        private void Start ()
        {
            textMesh = gameObject.GetComponent<TextMeshProUGUI>();
            currencyManager = FindObjectOfType<ShopCurrencyManager>();
        }

        private void Update()
        {
            textMesh.text = currentSpeedBonus + " / " + maxSpeedBonus;
            Limiter();
        }

        public void IncreaseValue()
        {
            if (currencyManager.SavedCurrency > baseCostOfUpgrade * currentSpeedBonus)
            {
                currencyManager.SavedCurrency -= baseCostOfUpgrade * currentSpeedBonus;
                currentSpeedBonus++;
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
                currencyManager.SavedCurrency += baseCostOfUpgrade * currentSpeedBonus;
            }
            else
            {
                return;
            }
        }

        private void Limiter()
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
