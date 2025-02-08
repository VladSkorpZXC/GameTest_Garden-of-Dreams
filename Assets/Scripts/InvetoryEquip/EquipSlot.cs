using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class EquipSlot : MonoBehaviour
{
    [SerializeField]
    private Inventory _inventory;

    [SerializeField]
    private TypeCloth _typeCloth;

    [SerializeField]
    private int _arrmor;

    [SerializeField]
    private Image _iconEquipItem;

    [SerializeField]
    private TMP_Text _arrmorText;

    [SerializeField]
    private ItemCloth _itemCloth;

    public ItemCloth ItemEquip {  get { return _itemCloth; } }

    public ItemCloth EquipItem(ItemCloth itemCloth)
    {
        if (itemCloth.Type == _typeCloth)
        {
            if (_itemCloth == null)
            {
                _itemCloth = itemCloth;
                DisplayItem();
            }
            else
            {
                ItemCloth itemClothInventory = _itemCloth;
                _itemCloth = itemCloth;
                DisplayItem();

                return itemClothInventory;
            }
        }

        return null;
    }
    

    public void DisplayItem()
    {
        _arrmor = _itemCloth.Armor;
        _iconEquipItem.sprite = _itemCloth.Icon;

        _arrmorText.text = "+ " + _arrmor.ToString();
    }
}
