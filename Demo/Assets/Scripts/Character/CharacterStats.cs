﻿using System.Collections;
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

    public void IncreaseAttackRange(float amount) {
        _character.AttackRange += amount;
    }

    public void IncreaseAttackDamage(float amount) {
        _character.AttackDamage += amount;
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

    public void DecreaseAttackRange(float amount) {
        if (_character.AttackRange - amount < 0) {
            return;
        }

        _character.AttackRange -= amount;
    }

    public void DecreaseAttackDamage(float amount) {
        if (_character.AttackDamage - amount < 0) {
            return;
        }

        _character.AttackDamage -= amount;
    }

    #endregion

    #region Setters

    public void SetMovementSpeed(float value) {
        _character.MovementSpeed = value;
    }

    public void SetRotationSpeed(float value) {
        _character.RotationSpeed = value;
    }

    public void SetAttackRange(float value) {
        _character.AttackRange = value;
    }

    public void SetAttackDamage(float value) {
        _character.AttackDamage = value;
    }

    #endregion

    #region Reporters

    public float GetMovementSpeed() {
        return _character.MovementSpeed;
    }

    public float GetRotationSpeed() {
        return _character.RotationSpeed;
    }

    public float GetAttackRange() {
        return _character.AttackRange;
    }

    public float GetAttackDamage() {
        return _character.AttackDamage;
    }

    #endregion

}