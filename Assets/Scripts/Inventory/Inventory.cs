using UnityEngine;
using System.Collections.Generic;

public class Inventory : MonoBehaviour
{
    [SerializeField]
    private List<Slot> _slots;

    [SerializeField]
    private List<EquipSlot> _equipSlots;

    public List<EquipSlot> EquipSlots {  get { return _equipSlots; } }

    [SerializeField]
    private List<Item> _items;

    [SerializeField]
    private HealthCharacter _healthCharacter;

    public List<Slot> Slots { get { return _slots; } }

    public void Start()
    {
        for(int i = 0; i < _items.Count; i++)
        {
            AddItemInvetory(_items[i], _items[i].StackMax);
        }
    }

    public void LoadInventory(List<int> slotId, List<int> idItem, List<int> count)
    {
        for (int i = 0; i < slotId.Count; i++)
        {
            for (int j = 0; j < _items.Count; j++)
            {
                if (_items[j].IdItem == idItem[i])
                {
                    _slots[slotId[i]].AddItemSlot(_items[j], count[i]);
                    break;
                }
            }
        }

    }

    public void LoadEquipSlot(List<int> slotId, List<int> idItem)
    {
        for (int i = 0; i < idItem.Count; i++)
        {
            for (int j = 0; j < _items.Count; j++)
            {
                if (_items[j].IdItem == idItem[i])
                {
                    _items[j].UseItemInventory(this.GetComponent<Inventory>());
                }
            }
             
        }
    }

    public void AddItemInvetory(Item item, int count)
    {
        for (int i = 0; i < _slots.Count; i++)
        {
            if (_slots[i].Item == null)
            {
                _slots[i].AddItemSlot(item, count);
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
                AddItemInvetory(itemClothEquip, 1);
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

    public void HealCharacter(int heal)
    {
        _healthCharacter.Heal(heal);
    }
}
