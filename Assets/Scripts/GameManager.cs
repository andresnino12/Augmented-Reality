using System;
using Unity.Mathematics;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

public enum GameStates {Defaul, InGame, Pause, Death }
public class GameManager : MonoBehaviour

{
    public static GameManager instance;
    public GameObject currObj;
    public static event Action OnMainMenu;
    public static event Action OnInventoryMenu;
    public static event Action OnEditMenu;

    public GameStates gameState;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }
        else
        {
            instance = this;
        }
    }
    public void Start()
    {
        MainMenu();
        gameState = GameStates.InGame;
    }

    public void CreateObj(GameObject obj)
    {
        if (currObj != null)
        {
            DestroyObject(currObj);
        }
        currObj = Instantiate(obj, Vector3.zero, quaternion.identity);
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
        Debug.Log($"Se llamo al main menu");
    }
    public void InventoryMenu()
    {
        OnInventoryMenu?.Invoke();
        Debug.Log($"Se llamo al Inventory menu");
    }
    public void EditMenu()
    {
        OnEditMenu?.Invoke();
        Debug.Log($"Se llamo al edit menu");
    }
}
