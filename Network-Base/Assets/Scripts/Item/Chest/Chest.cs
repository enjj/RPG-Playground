using System;
using UnityEngine;

public class Chest : Interactable {

    public Action onTakeDamage;
    public Action onOpened;

    [Header("Initializations")]
    [SerializeField]
    private Item_SO _itemDefinition_Template = null;

    [Header("Debug")]
    [SerializeField]
    private Item_SO _item = null;

    private Animator _animator = null;
    private bool _hasOpened = false;

    private const string OPEN = "Open";
    private const string TAKE_DAMAGE = "TakeDamage";

    private CharacterStats _lastInteractedCharacterStats = null;

    #region Initializations

    private void Awake() {
        _animator = GetComponent<Animator>();

        if (_itemDefinition_Template != null) {
            _item = Instantiate(_itemDefinition_Template);
        }
    }

    #endregion

    public bool IsDead { 
        get {
            return _item.CurrentHealth <= 0 ? true : false;
        }
    }

    private void ValidateCurrentHealth() {
        if (_item.CurrentHealth >= _item.MaxHealth) {
            _item.CurrentHealth = _item.MaxHealth;

            return;
        }

        if (_item.CurrentHealth <= 0) {
            _item.CurrentHealth = 0;

            return;
        }

        if (_item.CurrentHealth > _item.MaxHealth) {
            SetCurrentHealth(_item.MaxHealth);

            return;
        }
    }

    #region Increasers

    public void IncreaseCurrentHealth(float amount) {
        _item.CurrentHealth += amount;

        ValidateCurrentHealth();
    }

    public void IncreaseMaxHealth(float amount) {
        _item.MaxHealth += amount;

        ValidateCurrentHealth();
    }

    #endregion

    #region Decreasers

    public void DecreaseCurrentHealth(float amount) {
        _item.CurrentHealth -= amount;

        ValidateCurrentHealth();
    }

    public void DecreaseMaxHealth(float amount) {
        _item.MaxHealth -= amount;

        ValidateCurrentHealth();
    }

    #endregion

    #region Setters

    public void SetCurrentHealth(float value) {
        _item.CurrentHealth = value;

        ValidateCurrentHealth();
    }

    public void SetMaxHealth(float value) {
        _item.MaxHealth = value;

        ValidateCurrentHealth();
    }

    #endregion

    #region Reporters

    public float GetCurrentHealth() {
        return _item.CurrentHealth;
    }

    public float GetMaxHealth() {
        return _item.MaxHealth;
    }

    #endregion

    public override void OnInteracted(CharacterStats characterStats) {
        base.OnInteracted(characterStats);

        this._lastInteractedCharacterStats = characterStats;

        Interact();
    }

    private void Interact() {
        if (IsDead && !_hasOpened) {
            Open();
        } else {
            TakeDamage();
        }
    }

    private void Open() {
        _animator.SetTrigger(OPEN);

        _hasOpened = true;

        onOpened?.Invoke();
    }

    private void TakeDamage() {
        if (IsDead || _hasOpened) {
            return;
        }

        DecreaseCurrentHealth(_lastInteractedCharacterStats.GetAttackDamage());
        onTakeDamage?.Invoke();

        if (IsDead && !_hasOpened) {
            Open();
        } else {
            _animator.SetTrigger(TAKE_DAMAGE);
        }
    }

}
