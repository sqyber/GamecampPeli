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
        private ShopCurrencyManager currencyManager;

        // Update is called once per frame
        void Start ()
        {
            textMesh = gameObject.GetComponent<TextMeshProUGUI>();
            currencyManager = FindObjectOfType<ShopCurrencyManager>();
            
        }

        public void Update()
        {
            textMesh.text = currentDmgBonus + " / " + maxDmgBonus;

            Limiter();
            }
        

        public void IncreaseValue()
        {
            if (currencyManager.SavedCurrency >10* currentDmgBonus)
            {
                currentDmgBonus++;
                currencyManager.SavedCurrency -= 10 * currentDmgBonus;
            }
            else
            {
                return;
            }
                
        }
        //decrease upgrade level
        public void DecreaseValue()
        {
            if (currentDmgBonus > 1)
            {
                currentDmgBonus--;
                currencyManager.SavedCurrency += 10 * currentDmgBonus;
            }
            else
            {
                return;
            }
                
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
