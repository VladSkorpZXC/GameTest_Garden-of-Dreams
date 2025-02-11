using UnityEngine;

public class ButtonAction : MonoBehaviour
{
    [SerializeField]
    private Inventory _inventory;

    [SerializeField]
    private InfoItem _infoItem;

    [SerializeField]
    private Item _item;


    public void Action()
    {
        _item.UseItemInventory(_inventory);
        _infoItem.ClosePanelInfo();
        _item = null;
    }

    public void DeleteItem()
    {
        _inventory.DestroyItemSlot(_item);
        _infoItem.ClosePanelInfo();
    }

    public void ChooseAction(Item item)
    {
        _item = item;
    }
}

public enum TypeActionButton
{
    None, Buy, Heal, Equip
}