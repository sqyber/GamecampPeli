using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

namespace GamecampPeli
{
    public class HealthBonus : MonoBehaviour
    {
        
        [SerializeField] private int maxHpBonus = 10;
        [SerializeField] private int currentHpBonus = 1;

        private TextMeshProUGUI textMesh;
        private ShopCurrencyManager currencyManager;

        // Update is called once per frame
        void Start ()
        {
            textMesh = gameObject.GetComponent<TextMeshProUGUI>();
            currencyManager = GetComponent<ShopCurrencyManager>();
        }
        public void Update()
        {
            textMesh.text = currentHpBonus + " / " + maxHpBonus;

            Limiter();
            }
        

        public void IncreaseValue()
            {
                currentHpBonus++;
                PlayerPrefs.SetInt("Coins", currencyManager.SavedCurrency-10 * currentHpBonus);
            }

        public void DecreaseValue()
            {
                currentHpBonus--;
                PlayerPrefs.SetInt("Coins", currencyManager.SavedCurrency+10 * currentHpBonus);
            }

        public void Limiter()
            {
                if (currentHpBonus > maxHpBonus)
                {
                    currentHpBonus = maxHpBonus;
                }
                else if (currentHpBonus < 1)
                {
                    currentHpBonus = 1;
                }
            }
    }
    }
