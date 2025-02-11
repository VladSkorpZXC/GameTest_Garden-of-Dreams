using UnityEngine;

[CreateAssetMenu(fileName = "ItemCloth", menuName = "Scriptable Objects/Item/ItemCloth")]
public class ItemCloth : Item
{
    [SerializeField]
    private TypeCloth _typeCloth;
    [SerializeField]
    private int _armor;

    public TypeCloth Type { get { return _typeCloth; } }
    public int Armor { get { return _armor; } }

    public override string ItemActionText()
    {
        return "Ёкиперовать";
    }

    public override string Stats()
    {
        return "+ " + _armor;
    }

    public override void UseItemInventory(Inventory inventory)
    {
        inventory.EquipItem(this);
    }
}

public enum TypeCloth
{
    Head, Body
}
