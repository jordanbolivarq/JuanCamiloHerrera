using UnityEngine;

public class PointTowardsNorth : MonoBehaviour {
    [SerializeField] private float lerpSpeed = .5f;
    private void Update() {
        RotateNorth();
    }

    private void RotateNorth() {
        Quaternion newRotation = Quaternion.Euler(0, (int)Input.compass.trueHeading, 0);
        transform.localRotation = Quaternion.Slerp(transform.localRotation, newRotation, lerpSpeed);
    }
}
