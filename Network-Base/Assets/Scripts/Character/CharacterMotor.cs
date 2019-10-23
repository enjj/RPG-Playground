using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(CharacterStats), typeof(CharacterAttack))]
public class CharacterMotor : MonoBehaviour {

    public Action onMove;
    public Action onStop;

    private Rigidbody _rb = null;
    private CharacterStats _characterStats = null;
    private CharacterAttack _characterAttack = null;

    public float CurrentVelocity { 
        get {
            return _rb.velocity.magnitude;
        }
    }

    private void Awake() {
        _rb = GetComponent<Rigidbody>();
        _characterStats = GetComponent<CharacterStats>();
        _characterAttack = GetComponent<CharacterAttack>();
    }

    public void Move(float vertical) {
        _rb.velocity = transform.forward * vertical * _characterStats.GetMovementSpeed();

        onMove?.Invoke();
    }

    public void Rotate(float horizontal) {
        transform.Rotate(Vector3.up * horizontal * _characterStats.GetRotationSpeed() * Time.deltaTime);
    }

    public void Stop() {
        _rb.velocity = Vector3.zero;

        onStop?.Invoke();
    }

    public void Attack() {
        _characterAttack.Attack();
    }

}
