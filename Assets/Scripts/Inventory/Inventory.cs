using UnityEngine;
using System.Collections.Generic;

public class Inventory : MonoBehaviour
{
    [SerializeField]
    private List<Slot> _slots;

    public void AddItemInvetory(Item item)
    {
        _slots[0].AddItemSlot(item, 5);
    }
}
