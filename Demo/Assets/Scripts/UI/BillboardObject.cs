using UnityEngine;

[ExecuteInEditMode]
public class BillboardObject : MonoBehaviour {

    [Header("Initializations")]
    [SerializeField]
    private Transform _targetTransform = null;

    private Camera _cameraMain = null;

    private void Awake() {
        _cameraMain = Camera.main;
    }

    private void LateUpdate() {
        if (_targetTransform == null) {
            return;
        }

        _targetTransform.LookAt(_targetTransform.position + _cameraMain.transform.rotation * Vector3.forward, _cameraMain.transform.rotation * Vector3.up);
    }

}
