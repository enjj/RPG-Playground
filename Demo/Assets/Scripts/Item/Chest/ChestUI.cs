using UnityEngine;
using UnityEngine.UI;

public class ChestUI : MonoBehaviour {

    [Header("Initializations")]
    [SerializeField]
    private Image _fillHealthImage = null;
    [SerializeField]
    private Canvas _UICanvas = null;

    private Chest _chest = null;

    private void Awake() {
        _chest = GetComponent<Chest>();

        _chest.onTakeDamage += UpdateHealthBar;
        _chest.onOpened += OnDead;
    }

    private void Start() {
        UpdateHealthBar();
    }

    private void UpdateHealthBar() {
        _fillHealthImage.fillAmount = _chest.GetCurrentHealth() / _chest.GetMaxHealth();
    }

    private void OnDead() {
        this._UICanvas.gameObject.SetActive(false);
    }

}
