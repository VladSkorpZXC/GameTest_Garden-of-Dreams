using UnityEngine;

public class ButtonAction : MonoBehaviour
{
    [SerializeField]
    private Inventory _inventory;

    [SerializeField]
    private InfoItem _infoItem;

    [SerializeField]
    private TypeActionButton _typeAction;

    [SerializeField]
    private Item _item;


    public void Action()
    {
        if (_typeAction == TypeActionButton.Buy)
        {
            Buy();
        }
        else if (_typeAction == TypeActionButton.Heal)
        {
            Heal();
        }
        else if (_typeAction == TypeActionButton.Equip)
        {
            Equip();
        }
    }

    public void ChooseAction(Item item, TypeActionButton type)
    {
        _item = item;
        _typeAction = type;
    }

    public void Buy()
    {
        _inventory.FullAmmountSlot(_item);
        _infoItem.ClosePanelInfo();
        _typeAction = TypeActionButton.None;
    }

    public void Heal()
    {
        _inventory.UseItemSlot(_item, 1);
        _infoItem.ClosePanelInfo();
        _typeAction = TypeActionButton.None;
    }

    public void Equip()
    {
        _inventory.EquipItem(_item);
        _infoItem.ClosePanelInfo();
        _typeAction = TypeActionButton.None;
    }

    public void DeleteItem()
    {
        _inventory.DestroyItemSlot(_item);
        _infoItem.ClosePanelInfo();
    }
}

public enum TypeActionButton
{
    None, Buy, Heal, Equip
}