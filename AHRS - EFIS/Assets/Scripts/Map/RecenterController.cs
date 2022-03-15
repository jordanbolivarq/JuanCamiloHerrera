using Mapbox.Unity.Map;
using UnityEngine;

public class RecenterController : MonoBehaviour {
    private Transform pin;
    
    [SerializeField] private AbstractMap map;

    public void GetPin(Transform pin) {
        this.pin = pin;
    }
    
    public void Recenter() {
        map.UpdateMap(map.WorldToGeoPosition(pin.position));
    }
}