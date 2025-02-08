using UnityEngine;
using System.Collections.Generic;

public class Inventory : MonoBehaviour
{
    [SerializeField]
    private List<Slot> _slots;

    [SerializeField]
    private List<EquipSlot> _equipSlots;

    [SerializeField]
    private List<ItemCloth> _itemCloth;

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

    public void EquipItem(Item item)
    {
        ItemCloth itemCloth = null;

        for (int i = 0; i < _itemCloth.Count; i++)
        {
            if (_itemCloth[i] == item)
            {
                itemCloth = _itemCloth[i];
                break;
            }
        }

        for (int i = 0; i < _equipSlots.Count; i++)
        {
            ItemCloth itemClothEquip = _equipSlots[i].EquipItem(itemCloth);

            DestroyItemSlot(itemCloth);

            if (itemClothEquip != null)
            {
                AddItemInvetory(itemClothEquip);
            }
        }
    }

    public void UseItemSlot(Item item, int value)
    {
        for (int i = 0; i < _slots.Count; ++i)
        {
            if (_slots[i].Item != null)
            {
                if (_slots[i].Item == item)
                {
                    _slots[i].UseItem(value);
                    break;
                }
            }
        }
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
