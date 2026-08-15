using Unity.Mathematics;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private GameObject currObj;

    public void Awake()
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
}
