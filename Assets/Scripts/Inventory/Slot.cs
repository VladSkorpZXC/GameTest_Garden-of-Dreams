using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;


public class Slot : MonoBehaviour, IDropHandler
{
    [SerializeField]
    private Item _item;

    [SerializeField]
    private Image _itemIcon;

    [SerializeField]
    private int _count;

    [SerializeField]
    private TMP_Text _countText;

    [SerializeField]
    private InfoItem _infoItem;

    public Item Item {  get { return _item; } }

    public int Count { get { return _count; } }

    public void AddItemSlot(Item item, int count)
    {
        _item = item;
        
        if(count > item.StackMax)
        {
            _count = item.StackMax;
        }
        else if (count > 0) 
        {
            _count = count;
        }
        else
        {
            DestroyItemSlot();
        }
        
        DisplayItemSlot();
    }

    public void UseItem(int value)
    {
        if (_count - value > 0)
        {
            _count -= value;
            DisplayItemSlot();
        }
        else if(_count - value == 0)
        {
            DestroyItemSlot();
        }
        else
        {
            Debug.Log("Не хватает");
        }
    }

    public void FullAmmountSlot()
    {
        _count = _item.StackMax;
        DisplayItemSlot();
    }

    public void InfoItem()
    {
        _infoItem.DisplayItemInfo(_item);
        _infoItem.OpenPanelInfo();
    }

    public void DestroyItemSlot()
    {
        _item = null;
        _count = 0;

        UnDisplayItemSlot();
    }


    public void DisplayItemSlot()
    {
        _itemIcon.sprite = _item.Icon;
        _itemIcon.enabled = true;

        if (_count > 1)
        {
            _countText.text = _count.ToString();
            _countText.enabled = true;
        }
        else
        {
            _countText.enabled = false;
        }
    }

    public void UnDisplayItemSlot()
    {
        _itemIcon.enabled = false;
        _countText.enabled = false;

        _itemIcon.sprite = null;
        _countText.text = "0";
    }

    public void OnDrop(PointerEventData eventData)
    {
        if(_item == null)
        {
            GameObject itemObject = eventData.pointerDrag.gameObject;

            AddItemSlot(itemObject.GetComponent<Slot>().Item, itemObject.GetComponent<Slot>().Count);

            itemObject.GetComponent<Slot>().DestroyItemSlot();
        }
    }
}
