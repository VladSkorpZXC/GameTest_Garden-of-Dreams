using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

public class InfoItem : MonoBehaviour
{
    [SerializeField]
    private GameObject _panelInfoItem;

    [SerializeField]
    private TMP_Text _nameText;

    [SerializeField]
    private Image _itemIcon;

    [SerializeField]
    private TMP_Text _statsText;

    [SerializeField]
    private TMP_Text _weightText;

    [SerializeField]
    private ButtonAction _actionItemButton;

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
        _weightText.text = item.Weight.ToString() + " Í„";


        _statsText.text = item.Stats();
        _actionItemText.text = item.ItemActionText();


        _actionItemButton.ChooseAction(item);
    }

    public void ClosePanelInfo()
    {
        _panelInfoItem.SetActive(false);
    }
}
