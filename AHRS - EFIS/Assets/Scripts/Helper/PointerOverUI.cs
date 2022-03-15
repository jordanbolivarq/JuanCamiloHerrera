using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PointerOverUI : MonoBehaviour
{
    public static bool IsPointerOverUIObject()
    {
        PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
        eventDataCurrentPosition.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventDataCurrentPosition, results);
        return results.Count > 0;
    }
    
    public static List<GameObject> GetUIObjectUnderPointer()
    {
        PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
        eventDataCurrentPosition.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventDataCurrentPosition, results);

        List<GameObject> gameObjects = new List<GameObject>();

        foreach (var VARIABLE in results)
        {
            Debug.Log("Is Pointer over ui" + VARIABLE.gameObject.name);
            gameObjects.Add(VARIABLE.gameObject);
        }

        return gameObjects;
    }
}
