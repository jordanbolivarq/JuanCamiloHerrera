using Mapbox.Examples;
using Mapbox.Unity.Utilities;
using Mapbox.Utils;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.Events;

public class CustomSpawnOnMap : SpawnOnMap {
    private GameObject marker;
    private Vector2d location;

    [Space] public UnityEvent<Transform> OnPinPlaced;

    protected override void Update() {
        if (marker != null) {
            marker.transform.localPosition = _map.GeoToWorldPosition(location);
            marker.transform.localScale = Vector3.one * _spawnScale;
        }
    }

    public void Spawn(string latLong) {
        if (marker != null) {
            Destroy(marker);
        }

        location = Conversions.StringToLatLon(latLong);
        marker = Instantiate(_markerPrefab);
        marker.name = latLong;
        marker.transform.localPosition = _map.GeoToWorldPosition(location);
        _map.UpdateMap(location);
        marker.transform.localScale = Vector3.one * _spawnScale;

        OnPinPlaced?.Invoke(marker.transform);
    }
}