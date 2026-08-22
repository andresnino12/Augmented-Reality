using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject mainMenuPanel;

    [SerializeField] private GameObject inventoryMenuPanel;

    [SerializeField] private GameObject editMenuPanel;

    private void OnEnable()
    {
        GameManager.OnMainMenu += OnMainMenuPanel;
        GameManager.OnInventoryMenu += OnInventoryMenuPanel;
        GameManager.OnEditMenu += OnEditMenuPanel;
    }
    private void OnDisable()
    {
        GameManager.OnMainMenu -= OnMainMenuPanel;
        GameManager.OnInventoryMenu -= OnInventoryMenuPanel;
        GameManager.OnEditMenu -= OnEditMenuPanel;
    }

    public void OnMainMenuPanel()
    {
        mainMenuPanel.SetActive(true);
        inventoryMenuPanel.SetActive(false);
        editMenuPanel.SetActive(false);
    }
    public void OnInventoryMenuPanel()
    {
        mainMenuPanel.SetActive(false);
        inventoryMenuPanel.SetActive(true);
        editMenuPanel.SetActive(false);
    }
    public void OnEditMenuPanel()
    {
        mainMenuPanel.SetActive(false);
        inventoryMenuPanel.SetActive(false);
        editMenuPanel.SetActive(true);
    }
}
