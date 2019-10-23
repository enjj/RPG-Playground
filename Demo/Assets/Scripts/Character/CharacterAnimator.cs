using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterMotor))]
public class CharacterAnimator : MonoBehaviour {

    [Header("Initializations")]
    [SerializeField]
    private Animator _animator = null;
    private CharacterMotor _characterMotor = null;
    private CharacterAttack _characterAttack = null;

    private const string VELOCITY = "Velocity";
    private const string ATTACK = "Attack";

    private void Awake() {
        _characterMotor = GetComponent<CharacterMotor>();
        _characterAttack = GetComponent<CharacterAttack>();

        _characterMotor.onMove += OnMove;
        _characterMotor.onStop += OnStop;
        _characterAttack.onAttack += OnAttack;
    }

    public void OnMove() {
        _animator.SetFloat(VELOCITY, Mathf.Abs(_characterMotor.CurrentVelocity));
    }

    public void OnStop() {
        _animator.SetFloat(VELOCITY, 0);
    }

    public void OnAttack() {
        _animator.SetTrigger(ATTACK);
    }

}
