using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : Interactable {

    new public string name = "ObjectName";

    public override void OnInteracted() {
        base.OnInteracted();

        Interact();
    }

    private void Interact() {
        Debug.Log("My name is " + name);
    }

}
