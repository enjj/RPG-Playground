using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[RequireComponent(typeof(CharacterStats))]
public class CharacterAttack : MonoBehaviour {

    public Action onAttack;

    [Header("Initializations")]
    [SerializeField]
    private SphereCollider _hitCollider = null;
    [SerializeField]
    private LayerMask _attackableLayerMask = 0;

    private CharacterStats _characterStats;

    private void Awake() {
        _characterStats = GetComponent<CharacterStats>();
    }

    public void Attack() {
        onAttack?.Invoke();
    }

    /// <summary>
    /// This function is going to fired by Infantry_04_Attack_A
    /// </summary>
    public void OnHit() {
        Debug.Log("Animation fired this function");
        Collider[] colliders = Physics.OverlapSphere(_hitCollider.transform.position, _hitCollider.radius, _attackableLayerMask);

        foreach (Collider collider in colliders) {
            Interactable interactedObject = collider.GetComponent<Interactable>();
            if (interactedObject != null) {
                interactedObject.OnInteracted(_characterStats);
            }
        }
    }

    private void OnDrawGizmos() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(_hitCollider.transform.position, _hitCollider.radius);
    }

}
