using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.InputSystem;
public class ArPlaceCube : MonoBehaviour
{
    [SerializeField] private ARRaycastManager aRRaycastManager;
    private bool isPlacing = false;

    public void Update()
    {
        var touchscreen = Touchscreen.current;

        if (touchscreen.touches[0].isInProgress && !isPlacing)
        {
            var touch0 = touchscreen.touches[0];
            if (touch0.phase.ReadValue() == UnityEngine.InputSystem.TouchPhase.Began)
            {
                Vector2 touchPos = touch0.position.ReadValue();
                PlaceObj(touchPos);
            }
        }
    }

    private void PlaceObj(Vector2 touchPosition)
    {
        var rayHits = new List<ARRaycastHit>();
        aRRaycastManager.Raycast(touchPosition, rayHits, TrackableType.AllTypes);
        if (rayHits.Count > 0)
        {
            StartCoroutine(WaitPlace());
            Vector3 spawnPosition = rayHits[0].pose.position;
            Quaternion spawnRotation = rayHits[0].pose.rotation;
            Instantiate(GameManager.instance.currObj, spawnPosition, spawnRotation);
            //StopCoroutine(WaitPlace());
            //StopAllCoroutines();
        }
    }


    // creamos una corrutina: la corrutina es para que se ejecute al mismo tiempo que el codigo sin detenerce
    IEnumerator WaitPlace()
    {
        isPlacing = true;
        yield return new WaitForSeconds(1f);
        isPlacing = false;

    }
}
