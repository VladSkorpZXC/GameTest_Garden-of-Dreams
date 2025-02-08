using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

public class InfoItem : MonoBehaviour
{
    [SerializeField]
    private GameObject _panelInfoItem;

    [SerializeField]
    private List<ItemConsumbles> _itemConsumbles;

    [SerializeField]
    private List<ItemCloth> _itemCloth;

    [SerializeField]
    private TMP_Text _nameText;

    [SerializeField]
    private Image _itemIcon;

    [SerializeField]
    private TMP_Text _arrmorText;

    [SerializeField]
    private TMP_Text _weightText;

    [SerializeField]
    private Button _actionItemButton;

    [SerializeField]
    private TMP_Text _actionItemText;
    public void OpenPanelInfo()
    {
        _panelInfoItem.SetActive(true);
    }

    public void DisplayItemInfo(Item item)
    {
        _nameText.text = item.Name;
        _itemIcon.sprite = item.Icon;

        _weightText.text = item.Weight.ToString() + " кг";


        for (int i = 0; i < _itemConsumbles.Count; i++)
        {
            if (_itemConsumbles[i] == item)
            {
                _arrmorText.text = " ";
                if (_itemConsumbles[i].Type == TypeConsumbles.Cartridge)
                {
                    _actionItemText.text = " упить";
                    break;
                }
                else if (_itemConsumbles[i].Type == TypeConsumbles.MedicineBox)
                {
                    _actionItemText.text = "Ћечить";
                    break;
                }
            }
        }

        for (int i = 0; i < _itemCloth.Count; i++)
        {
            if (_itemCloth[i] == item)
            {
                _arrmorText.text = "+ " + _itemCloth[i].Armor.ToString();
                _actionItemText.text = "Ёкипировать";
                break;
            }
        }
    }

    public void ClosePanelInfo()
    {
        _panelInfoItem.SetActive(false);
    }
}
