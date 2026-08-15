using UnityEngine;
using System;
using System.Collections.Generic;
using UnityEngine.UIElements;
public class InventoryManager : MonoBehaviour
{
    [SerializeField] private GameObject cardPrefap;
    [SerializeField] private Transform spawnCards;  
    [SerializeField] private List<ItemScriptTable> items = new List<ItemScriptTable>();

    private void Start()
    {
        LoadCards();
    }

    private void LoadCards()
    {
        if (items.Count != 0)
        {
            GameObject cardTemp = null;
            foreach (ItemScriptTable scriptTable in items)
            {
                cardTemp = Instantiate(cardPrefap, spawnCards);
                cardTemp.GetComponent<ItemHandle>().scriptTableObject = scriptTable;
                cardTemp.GetComponent<ItemHandle>().LoadDates();
            }
        }
        else
        {
            Debug.LogWarning("aqui no hay nada FUSUNGO");
        }
    }

}



