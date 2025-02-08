using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Slot : MonoBehaviour
{
    [SerializeField]
    private Item _item;

    [SerializeField]
    private Image _itemIcon;

    [SerializeField]
    private int _count;

    [SerializeField]
    private TMP_Text _countText;

    public void AddItemSlot(Item item, int count)
    {
        _item = item;
        _count = count;
        DisplayItemSlot();
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

        if (_count > 0)
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
}
