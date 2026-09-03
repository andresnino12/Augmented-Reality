using System;
using System.Collections;
using System.IO;
using Unity.Mathematics;
using UnityEditor;

using UnityEngine;
using UnityEngine.XR.ARFoundation;

public enum AppStates { Defaul, InMainMenu, InInventoryMenu, InEditMenu }
public class GameManager : MonoBehaviour

{
    public static GameManager Instance;
    public GameObject currObj;
    private GameObject selectedObj;
    public static event Action OnMainMenu;
    public static event Action OnInventoryMenu;
    public static event Action OnEditMenu;
    public static event Action OnTakeScreenshot;
    public static event Action OnEndTakeScreenshot;
    public ARPlaneManager planeManager;


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

    public void MainMenu()
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

    public void TakeScreenshotUi()
    {
        OnTakeScreenshot?.Invoke();
        HidePLanes();
    }
    public void EndTakeScreenshot()
    {
        OnEndTakeScreenshot?.Invoke();
        ShowPlanes();
    }
    public void HidePLanes()
    {
        var planes = planeManager.trackables;

        foreach (var plane in planes)
        {
            plane.gameObject.SetActive(false);
        }
    }
    public void ShowPlanes()
    {
        var planes = planeManager.trackables;

        foreach (var plane in planes)
        {
            plane.gameObject.SetActive(true);
        }
    }
    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("se salio del juego");
    }
    public void TakeScreenshot()
    {
        StartCoroutine(Screenshot());
    }
    private IEnumerator Screenshot()
    {
        GameManager.Instance.TakeScreenshotUi();
        yield return new WaitForEndOfFrame();


        Texture2D ss = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
        ss.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
        ss.Apply();

        string filePath = Path.Combine(Application.temporaryCachePath, "shared img.png");
        File.WriteAllBytes(filePath, ss.EncodeToPNG());

        Destroy(ss);

        new NativeShare().AddFile(filePath)
            .SetSubject("Subject goes here").SetText("Hola esto es una prueba fusunga")
            .SetCallback((result, shareTarget) => Debug.Log("Share result: " + result + ", selected app: " + shareTarget))
            .Share();
        GameManager.Instance.EndTakeScreenshot();


    }


}
