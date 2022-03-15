using UnityEngine;

public class CameraFollow : MonoBehaviour {
    private Transform target;

    [SerializeField] private Vector3 offset;

    public Transform Target {
        get {
            return target;
        }
        set {
            target = value;
            Follow();
        }
    }

    public void Follow() {
        if (Target == null) {
            return;
        }
        transform.position = Target.position + offset;
    }
}