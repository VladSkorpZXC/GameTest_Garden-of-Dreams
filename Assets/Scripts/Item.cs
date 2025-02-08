using UnityEngine;

public class Item : ScriptableObject
{
    [SerializeField]
    private string _name;
    [SerializeField]
    private Sprite _icon;
    [SerializeField]
    private int _stackMax;
    [SerializeField]
    private float _weight;

    public string Name {  get { return _name; } }
    public Sprite Icon { get { return _icon; } }
    public int StackMax { get { return _stackMax; } }
    public float Weight { get { return _weight; } }
}