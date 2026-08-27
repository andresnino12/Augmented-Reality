using System;
using Unity.Mathematics;
using UnityEditor;

using UnityEngine;

public enum AppStates {Defaul, InMainMenu, InInventoryMenu, InEditMenu}
public class GameManager : MonoBehaviour

{
    public static GameManager Instance;
    public GameObject currObj;
    private GameObject selectedObj;
    public static event Action OnMainMenu;
    public static event Action OnInventoryMenu;
    public static event Action OnEditMenu;

    public AppStates appStates;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        else
        {
            Instance = this;
        }
    }
    public void Start()
    {
        MainMenu();
    }

    public void CreateObj(GameObject obj)
    {
        if (currObj != null)
        {
            DestroyObject(currObj);
        }
        currObj = Instantiate(obj, Vector3.zero, quaternion.identity);
    }
    public void DestroyObject()
    {
        Destroy(currObj);
    }

    public void DestroyObject(GameObject obj)
    {
        Destroy(obj);
    }

    public void SelecObjToPlace(GameObject prefab)
    {
        currObj = prefab;
    }
    public GameObject GetSelectedPrefab()
        {
        return currObj;
        }

    public void MainMenu ()
    {
        OnMainMenu?.Invoke();
        appStates = AppStates.InMainMenu;
        Debug.Log($"Se llamo al main menu");
    }
    public void InventoryMenu()
    {
        OnInventoryMenu?.Invoke();
        appStates = AppStates.InInventoryMenu;

        Debug.Log($"Se llamo al Inventory menu");
    }
    public void EditMenu()
    {
        OnEditMenu?.Invoke();
        appStates = AppStates.InEditMenu;

        Debug.Log($"Se llamo al edit menu");
    }
}
