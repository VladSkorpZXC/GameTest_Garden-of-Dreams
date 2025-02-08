using UnityEngine;

[CreateAssetMenu(fileName = "ItemConsumbles", menuName = "Scriptable Objects/Item/ItemConsumbles")]
public class ItemConsumbles : Item
{
    [SerializeField]
    private TypeConsumbles _typeCloth;

    public TypeConsumbles Type { get { return _typeCloth; } }
}

public enum TypeConsumbles
{
    Cartridge, MedicineBox
}