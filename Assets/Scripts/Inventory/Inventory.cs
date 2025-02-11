using UnityEngine;
using System.Collections.Generic;

public class Inventory : MonoBehaviour
{
    [SerializeField]
    private List<Slot> _slots;

    [SerializeField]
    private List<EquipSlot> _equipSlots;

    public List<EquipSlot> EquipSlots {  get { return _equipSlots; } }


    public void AddItemInvetory(Item item)
    {
        for (int i = 0; i < _slots.Count; i++)
        {
            if (_slots[i].Item == null)
            {
                _slots[i].AddItemSlot(item, 5);
                break;
            }
        }
    }

    public void EquipItem(ItemCloth itemCloth)
    {
        for (int i = 0; i < _equipSlots.Count; i++)
        {
            Item itemClothEquip = _equipSlots[i].EquipItem(itemCloth);

            DestroyItemSlot(itemCloth);

            if (itemClothEquip != null)
            {
                AddItemInvetory(itemClothEquip);
            }
        }
    }

    public bool UseItemSlot(Item item, int value)
    {
        for (int i = 0; i < _slots.Count; ++i)
        {
            if (_slots[i].Item != null)
            {
                if (_slots[i].Item == item)
                {
                    return _slots[i].UseItem(value);
                }
            }
        }

        Debug.Log("Нет нужного предмета");
        return false;
    }

    public void FullAmmountSlot(Item item)
    {
        for (int i = 0; i < _slots.Count; ++i)
        {
            if (_slots[i].Item != null)
            {
                if (_slots[i].Item == item)
                {
                    _slots[i].FullAmmountSlot();
                    break;
                }
            }
        }
    }

    public void DestroyItemSlot(Item item)
    {
        for(int i = 0; i < _slots.Count; ++i)
        {
            if(_slots[i].Item == item)
            {
                _slots[i].DestroyItemSlot();
            }
        }
    }
}
