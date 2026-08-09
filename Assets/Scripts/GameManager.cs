using UnityEngine;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    [Header("Tarjetas")]
    [SerializeField] private GameObject cardPrefap;
    [SerializeField] private Transform cardContainer;

    [Header("lista de items")]
    [SerializeField] private List<ItemScriptTable> items = new List<ItemScriptTable>();

    private void Start()
    {
        CrearTarjetas();
    }

    private void CrearTarjetas()
    {
        foreach (ItemScriptTable item in items)
        {
            GameObject nuevaTarjeta = Instantiate(cardPrefap, cardContainer);

            ItemHandle itemHandle = nuevaTarjeta.GetComponent<ItemHandle>();

            if (itemHandle != null)
            {
                itemHandle.Setup(item);
            }
        }
    }
}


