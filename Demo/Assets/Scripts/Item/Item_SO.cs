using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "ScriptableObjects/Item", order = 1)]
public class Item_SO : ScriptableObject {

    [SerializeField]
    private int _ID = 0;
    [SerializeField]
    private string _name = string.Empty;
    [SerializeField]
    private GameObject _prefab = null;
    [SerializeField]
    private float _currentHealth = 1f;
    [SerializeField]
    private float _maxHealth = 1f;

    public int ID {
        get { return _ID; }
    }

    public string Name {
        get { return _name; }
        set { _name = value; }
    }

    public GameObject Prefab {
        get { return _prefab; }
    }

    public float CurrentHealth {
        get { return _currentHealth; }
        set { _currentHealth = value; }
    }

    public float MaxHealth {
        get { return _maxHealth; }
        set { _maxHealth = value; }
    }

}
