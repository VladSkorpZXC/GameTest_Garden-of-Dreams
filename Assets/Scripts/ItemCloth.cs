using UnityEngine;

[CreateAssetMenu(fileName = "ItemCloth", menuName = "Scriptable Objects/Item/ItemCloth")]
public class ItemCloth : Item
{
    [SerializeField]
    private TypeCloth _typeCloth;
    [SerializeField]
    private int _armor;
}

public enum TypeCloth
{
    Head, Body
}
