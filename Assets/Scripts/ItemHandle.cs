using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemHandle : MonoBehaviour

{
    public ItemScriptTable scriptTableObject;
    [SerializeField] private Image previewItemImage;
    [SerializeField] private TextMeshProUGUI itemNameText;
    [SerializeField] private TextMeshProUGUI itemDescriptionText;
    private Button Button;

    private void Start()
    {
        if (scriptTableObject != null)
        {
            LoadDates();
        }

        Button.onClick.AddListener(() => CreateObject());
    }

    private void Awake()
    {
        Button = GetComponent<Button>();
    }
    public void Setup(ItemScriptTable item)
    {
        scriptTableObject = item;
        LoadDates();
    }
    public void LoadDates()
    {
        previewItemImage.sprite = scriptTableObject.itemPreview;
        itemNameText.text = scriptTableObject.itemName;
        itemDescriptionText.text = scriptTableObject.ItemDescription;
    }

    private void CreateObject()
    {

    }

}