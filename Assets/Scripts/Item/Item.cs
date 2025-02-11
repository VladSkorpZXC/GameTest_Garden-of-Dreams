using NUnit.Framework;
using UnityEngine;

public abstract class Item : ScriptableObject
{
    [SerializeField]
    private int _idItem;
    [SerializeField]
    private string _name;
    [SerializeField]
    private Sprite _icon;
    [SerializeField]
    private int _stackMax;
    [SerializeField]
    private float _weight;
    [SerializeField]
    private Type _type;


    public int IdItem { get { return _idItem; } }
    public string Name {  get { return _name; } }
    public Sprite Icon { get { return _icon; } }
    public int StackMax { get { return _stackMax; } }
    public float Weight { get { return _weight; } }
    public Type TypeItem { get { return _type; } }
    

    virtual public string ItemActionText()
    {
        return "";
    }

    virtual public string Stats()
    {
        return "";
    }

    virtual public void UseItemInventory(Inventory inventory)
    {
        
    }
}

public enum Type
{
    Consubles, Cloth
}