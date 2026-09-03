using System;
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
        GameManager.OnTakeScreenshot += OnTakeScreenshot;
        GameManager.OnEndTakeScreenshot += OnMainMenuPanel;
    }
    private void OnDisable()
    {
        GameManager.OnMainMenu -= OnMainMenuPanel;
        GameManager.OnInventoryMenu -= OnInventoryMenuPanel;
        GameManager.OnEditMenu -= OnEditMenuPanel;
        GameManager.OnTakeScreenshot -= OnTakeScreenshot;
        GameManager.OnEndTakeScreenshot -= OnMainMenuPanel;
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
    private void OnTakeScreenshot()
    {
        mainMenuPanel.SetActive(false);
        inventoryMenuPanel.SetActive(false);
        editMenuPanel.SetActive(false);
    }
    
}
