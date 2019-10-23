using UnityEngine;

public class ChestVFX : MonoBehaviour {

    [Header("Initializations")]
    [SerializeField]
    private GameObject _openVFX = null;
    [SerializeField]
    private float _deadTimeInSeconds = 1.5f;

    public void FireVFX() {
        _openVFX.SetActive(true);

        Destroy(_openVFX, _deadTimeInSeconds);
        Destroy(this, _deadTimeInSeconds);
    }

}
