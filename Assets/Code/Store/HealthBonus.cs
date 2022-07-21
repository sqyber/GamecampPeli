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
            currencyManager = FindObjectOfType<ShopCurrencyManager>();

            //Instantiate(currencyManager.SavedCurrency;

        }
        public void Update()
        {
            textMesh.text = currentHpBonus + " / " + maxHpBonus;

            Limiter();
            }
        
        //increase the upgrade level
        public void IncreaseValue()
            {
                if (currencyManager.SavedCurrency >10* currentHpBonus)
                {
                    currentHpBonus++;
                    currencyManager.SavedCurrency -= 10 * currentHpBonus;
                }
                else
                {
                    return;
                }
                
            }
        //decrease upgrade level
        public void DecreaseValue()
        {
            if (currentHpBonus > 1)
            {
                currentHpBonus--;
                currencyManager.SavedCurrency += 10 * currentHpBonus;
            }
            else
            {
                return;
            }
                
            }
        //limit the upgrade levels to given values
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
