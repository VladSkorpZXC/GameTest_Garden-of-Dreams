using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UIElements;
public class SaveLoad : MonoBehaviour
{
    private const string saveItem = "saveItem";
    private const string saveHealth = "saveHealth";
    // Переменные для сохранения 

    [SerializeField]
    private bool saveLoad = false;

    [SerializeField]
    private List<int> _slotId;

    [SerializeField]
    private List<int> _slotEquipId;

    [SerializeField]
    private List<int> _idItem;

    [SerializeField]
    private List<int> _idEquipItem;

    [SerializeField]
    private List<int> _count;

    [SerializeField]
    private int _healthCharacter;

    [SerializeField]
    private int _healthEnemy;

    [SerializeField]
    private Inventory _inventory;

    [SerializeField]
    private HealthCharacter healthCharacter;

    [SerializeField]
    private HealthEnemy healthEnemy;

    private void Start()
    {
        LoadGame();
        StartCoroutine(SaveTime());
    }

    private IEnumerator SaveTime()
    {
        yield return new WaitForSeconds(3f);
        SaveGame();
        StartCoroutine(SaveTime());
    }

    public void SaveGame()
    {
        SeaveHealth();
        SeveItem();

        Save();
        saveLoad = true;
    }

    public void SeaveHealth()
    {
        _healthCharacter = healthCharacter.Hp;
        _healthEnemy = healthEnemy.Hp;
    }

    public void SeveItem()
    {
        ClearListSaveItem();

        for (int i = 0; i < _inventory.Slots.Count; i++)
        {
            if( _inventory.Slots[i].Item != null )
            {
                _slotId.Add(i);
                _idItem.Add(_inventory.Slots[i].Item.IdItem);
                _count.Add(_inventory.Slots[i].Count);
            }
        }

        for(int i = 0; i < _inventory.EquipSlots.Count; i++)
        {
            if (_inventory.EquipSlots[i].ItemEquip != null )
            {
                _slotEquipId.Add(i);
                _idEquipItem.Add(_inventory.EquipSlots[i].ItemEquip.IdItem);
            }
        }
    }

    public void ClearListSaveItem()
    {
        _slotId.Clear();
        _idItem.Clear();
        _count.Clear();
        _slotEquipId.Clear();
        _idEquipItem.Clear();
    }

    public void LoadGame()
    {
        LoadHealth();
        LoadItem();
    }

    public void LoadItem()
    {
        var data = SaveManager.Load<SaveDate.SaveItemData>(saveItem);
        
        if (data.SaveLoad)
        {
            _inventory.LoadInventory(data.SlotId, data.IdItem, data.Count);

            _inventory.LoadEquipSlot(data.SlotEqupId, data.IdEqupItem);
        }
    }

    public void LoadHealth()
    {
        var data = SaveManager.Load<SaveDate.SaveHealthData>(saveHealth);

        if (data.SaveLoad)
        {
            healthCharacter.LoadHealth(data.HealthCharacter);
            healthEnemy.LoadHealth(data.HealthEnemy);
        }
    }

    public void Save()
    {
        SaveManager.Save(saveItem, GetSaveItemData());
        SaveManager.Save(saveHealth, GetSaveHealthData());
    }

    private SaveDate.SaveItemData GetSaveItemData()
    {
        var data = new SaveDate.SaveItemData()
        {
            SaveLoad = saveLoad,

            SlotId = _slotId,
            IdItem = _idItem,
            Count = _count,

            SlotEqupId = _slotEquipId,
            IdEqupItem = _idEquipItem
        };

        return data;
    }

    private SaveDate.SaveHealthData GetSaveHealthData()
    {
        var data = new SaveDate.SaveHealthData()
        {
            SaveLoad = saveLoad,

            HealthCharacter = _healthCharacter,
            HealthEnemy = _healthEnemy,
        };

        return data;
    }
}
