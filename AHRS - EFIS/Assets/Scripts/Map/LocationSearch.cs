using System;
using TMPro;
using UnityEngine;

public class LocationSearch : MonoBehaviour {
    private TMP_Text placeHolder;
    private Color originalPlaceHolderColor;
    
    [SerializeField] private TMP_InputField inputLatLong;
    [SerializeField] private CustomSpawnOnMap spawnOnMap;
    [SerializeField] private Color errorColor = Color.red;

    private void Awake() {
        placeHolder = inputLatLong.placeholder.GetComponent<TMP_Text>();
        originalPlaceHolderColor = placeHolder.color;
    }

    public void Search() {
        string latLng = inputLatLong.text.Trim();
        inputLatLong.text = "";
        ResetPlaceHolderColor();
        
        try {
            spawnOnMap.Spawn(latLng);
        }
        catch (Exception e) {
            Debug.Log("Invalid lat long");
            placeHolder.color = errorColor;
        }
    }

    public void ResetPlaceHolderColor() {
        placeHolder.color = originalPlaceHolderColor;
    }
}
