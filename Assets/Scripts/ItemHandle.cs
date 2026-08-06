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
        previewItemImage.sprite = scriptTableObject.itemPreview;
        itemNameText.text = scriptTableObject.itemName;
        itemDescriptionText.text = scriptTableObject.ItemDescription;
    }

}