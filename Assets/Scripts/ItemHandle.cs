using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemHandle : MonoBehaviour

{
    [SerializeField] private ItemScriptTable scriptTableObject;
    [SerializeField] private Image previewItemImage;
    [SerializeField] private TextMeshProUGUI itemNameText;
    [SerializeField] private TextMeshProUGUI itemDescriptionText;


    private void Start()
    {
        if (scriptTableObject != null)
        {
            MostrarDatos();
        }
    }
    public void Setup(ItemScriptTable item)
    {
        scriptTableObject = item;
        MostrarDatos();
    }
    private void MostrarDatos()
    {
        previewItemImage.sprite = scriptTableObject.itemPreview;
        itemNameText.text = scriptTableObject.itemName;
        itemDescriptionText.text = scriptTableObject.ItemDescription;
    }

}