using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour {

    public virtual void OnInteracted(CharacterStats characterStats) {
        Debug.Log("Interacted with " + this.gameObject.name);
    }

}
