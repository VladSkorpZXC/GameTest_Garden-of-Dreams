using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DragItem : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler, IPointerClickHandler
{
    [SerializeField]
    private Slot _slot;

    [SerializeField]
    private RectTransform _rectTransform;

    [SerializeField]
    private GameObject _slotObject;

    [SerializeField]
    private Image _slotImage;

    public void OnPointerClick(PointerEventData eventData)
    {
        _slot.InfoItem();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (_slot.Item != null)
        {
            _slotImage.raycastTarget = false;

            _slotImage.transform.SetParent(transform.root);
            _slotImage.transform.SetAsLastSibling();
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (_slot.Item != null)
        {
            _rectTransform.anchoredPosition += eventData.delta;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        _slotImage.transform.position = _slotObject.transform.position;
        _slotImage.raycastTarget = true;
        _slotImage.transform.SetParent(_slotObject.transform);
    }
}
