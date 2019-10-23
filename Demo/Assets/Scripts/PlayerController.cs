using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterMotor), typeof(CharacterAttack))]
public class PlayerController : MonoBehaviour {

    private CharacterMotor _characterMotor = null;
    public float Horizontal { get; private set; }
    public float Vertical { get; private set; }
    public bool IsMoving { 
        get {
            return (Horizontal != 0 || Vertical != 0) ? true : false;
        }
    }

    private void Awake() {
        _characterMotor = GetComponent<CharacterMotor>();
    }

    private void Update() {
        Horizontal = Input.GetAxis("Horizontal");
        Vertical = Input.GetAxis("Vertical");

        if (IsMoving) {
            Move();
            Rotate();
        } else {
            Stop();
        }

        if (Input.GetKeyDown(KeyCode.Space)) {
            Attack();
        }
    }

    private void Move() {
        _characterMotor.Move(Vertical);
    }

    private void Rotate() {
        _characterMotor.Rotate(Horizontal);
    }

    private void Stop() {
        _characterMotor.Stop();
    }

    private void Attack() {
        _characterMotor.Attack();
    }

}
