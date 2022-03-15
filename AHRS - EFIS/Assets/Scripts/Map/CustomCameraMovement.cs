using System;
using Mapbox.Examples;
using Mapbox.Unity.Utilities;
using Mapbox.Utils;
using UnityEngine;
using UnityEngine.EventSystems;

public class CustomCameraMovement : QuadTreeCameraMovement {
    void UseMeterConversion() {
        if (Input.GetMouseButtonUp(1)) {
            var mousePosScreen = Input.mousePosition;

            //assign distance of camera to ground plane to z, otherwise ScreenToWorldPoint() will always return the position of the camera
            //http://answers.unity3d.com/answers/599100/view.html
            mousePosScreen.z = _referenceCamera.transform.position.y;
            var pos = _referenceCamera.ScreenToWorldPoint(mousePosScreen);

            var latlongDelta = _mapManager.WorldToGeoPosition(pos);
            Debug.Log("Latitude: " + latlongDelta.x + " Longitude: " + latlongDelta.y);
        }

        if (Input.GetMouseButton(0) && !EventSystem.current.IsPointerOverGameObject()) {
            var mousePosScreen = Input.mousePosition;

            //assign distance of camera to ground plane to z, otherwise ScreenToWorldPoint() will always return the position of the camera
            //http://answers.unity3d.com/answers/599100/view.html
            mousePosScreen.z = _referenceCamera.transform.localPosition.y;
            _mousePosition = _referenceCamera.ScreenToWorldPoint(mousePosScreen);

            if (_shouldDrag == false) {
                _shouldDrag = true;
                _origin = _referenceCamera.ScreenToWorldPoint(mousePosScreen);
            }
        }
        else {
            _shouldDrag = false;
        }

        if (_shouldDrag == true) {
            var changeFromPreviousPosition = _mousePositionPrevious - _mousePosition;

            if (Mathf.Abs(changeFromPreviousPosition.x) > 0.0f || Mathf.Abs(changeFromPreviousPosition.y) > 0.0f) {
                _mousePositionPrevious = _mousePosition;
                var offset = _origin - _mousePosition;

                if (Mathf.Abs(offset.x) > 0.0f || Mathf.Abs(offset.z) > 0.0f) {
                    if (null != _mapManager) {
                        float factor =
                            _panSpeed * Conversions.GetTileScaleInMeters((float) 0, _mapManager.AbsoluteZoom) /
                            _mapManager.UnityTileSize;

                        var latlongDelta =
                            Conversions.MetersToLatLon(new Vector2d(offset.x * factor, offset.z * factor));

                        var newLatLong = _mapManager.CenterLatitudeLongitude + latlongDelta;

                        _mapManager.UpdateMap(newLatLong, _mapManager.Zoom);
                    }
                }

                _origin = _mousePosition;
            }
            else {
                if (EventSystem.current.IsPointerOverGameObject()) {
                    return;
                }

                _mousePositionPrevious = _mousePosition;
                _origin = _mousePosition;
            }
        }
    }

    protected override void UseDegreeConversion() {
        if (Input.GetMouseButton(0) && !EventSystem.current.IsPointerOverGameObject()) {
            var mousePosScreen = Input.mousePosition;

            //assign distance of camera to ground plane to z, otherwise ScreenToWorldPoint() will always return the position of the camera
            //http://answers.unity3d.com/answers/599100/view.html
            mousePosScreen.z = _referenceCamera.transform.position.y;
            _mousePosition = _referenceCamera.ScreenToWorldPoint(mousePosScreen);

            if (_shouldDrag == false) {
                _shouldDrag = true;
                _origin = _referenceCamera.ScreenToWorldPoint(mousePosScreen);
            }
        }
        else {
            _shouldDrag = false;
        }

        if (_shouldDrag == true) {
            var changeFromPreviousPosition = _mousePositionPrevious - _mousePosition;

            if (Mathf.Abs(changeFromPreviousPosition.x) > 0.0f || Mathf.Abs(changeFromPreviousPosition.y) > 0.0f) {
                _mousePositionPrevious = _mousePosition;
                var offset = _origin - _mousePosition;

                if (Mathf.Abs(offset.x) > 0.0f || Mathf.Abs(offset.z) > 0.0f) {
                    if (null != _mapManager) {
                        // Get the number of degrees in a tile at the current zoom level.
                        // Divide it by the tile width in pixels ( 256 in our case)
                        // to get degrees represented by each pixel.
                        // Mouse offset is in pixels, therefore multiply the factor with the offset to move the center.
                        float factor =
                            _panSpeed * Conversions.GetTileScaleInDegrees((float) _mapManager.CenterLatitudeLongitude.x,
                                _mapManager.AbsoluteZoom) / _mapManager.UnityTileSize;

                        var latitudeLongitude = new Vector2d(_mapManager.CenterLatitudeLongitude.x + offset.z * factor,
                            _mapManager.CenterLatitudeLongitude.y + offset.x * factor);

                        _mapManager.UpdateMap(latitudeLongitude, _mapManager.Zoom);
                    }
                }

                _origin = _mousePosition;
            }
            else {
                if (EventSystem.current.IsPointerOverGameObject()) {
                    return;
                }

                _mousePositionPrevious = _mousePosition;
                _origin = _mousePosition;
            }
        }
    }

    protected override void ZoomMapUsingTouchOrMouse(float zoomFactor) {
        Vector2 centerScreen = new Vector2(Screen.width / 2f, Screen.height / 2f);
        Vector3 centerMap = GetGroundPlaneHitPoint(_referenceCamera.ScreenPointToRay(centerScreen));
        float zoom = Mathf.Max(0.0f, Mathf.Min(_mapManager.Zoom + zoomFactor * _zoomSpeed, 21.0f));

        if (Math.Abs(zoom - _mapManager.Zoom) > 0.0f) {
            _mapManager.UpdateMap(
                _mapManager.WorldToGeoPosition(centerMap), zoom);
        }
    }
}