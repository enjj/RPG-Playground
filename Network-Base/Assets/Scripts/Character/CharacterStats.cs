using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    [Header("Initializations")]
    [SerializeField]
    private CharacterStats_SO _characterDefinition_Template = null;

    [Header("Debug")]
    [SerializeField]
    private CharacterStats_SO _character = null;

    #region Initializations

    private void Awake() {
        if (_characterDefinition_Template != null) {
            _character = Instantiate(_characterDefinition_Template);
        }
    }

    #endregion

    #region Increasers

    public void IncreaseMovementSpeed(float amount) {
        _character.MovementSpeed += amount;
    }
    public void IncreaseRotationSpeed(float amount) {
        _character.RotationSpeed += amount;
    }

    #endregion

    #region Decreasers
    public void DecreaseMovementSpeed(float amount) {
        if (_character.MovementSpeed - amount < 0) {
            return;
        }

        _character.MovementSpeed -= amount;
    }
    public void DecreaseRotationSpeed(float amount) {
        if (_character.RotationSpeed - amount < 0) {
            return;
        }
        
        _character.RotationSpeed -= amount;
    }

    #endregion

    #region Setters

    public void SetMovementSpeed(float value) {
        _character.MovementSpeed = value;
    }

    public void SetRotationSpeed(float value) {
        _character.RotationSpeed = value;
    }

    #endregion

    #region Reporters

    public float GetMovementSpeed() {
        return _character.MovementSpeed;
    }

    public float GetRotationSpeed() {
        return _character.RotationSpeed;
    }

    #endregion

}
