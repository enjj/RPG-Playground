using UnityEngine;

[CreateAssetMenu(fileName = "CharacterStats", menuName = "ScriptableObjects/Character/CharacterStats", order = 1)]
public class CharacterStats_SO : ScriptableObject {

    [SerializeField]
    private float _movementSpeed = 1f;
    [SerializeField]
    private float _rotationSpeed = 350f;

    public float MovementSpeed {
        get { return _movementSpeed; }
        set { _movementSpeed = value; }
    }
    public float RotationSpeed {
        get { return _rotationSpeed; }
        set { _rotationSpeed = value; }
    }

}
