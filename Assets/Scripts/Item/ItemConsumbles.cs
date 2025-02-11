using UnityEngine;

[CreateAssetMenu(fileName = "ItemConsumbles", menuName = "Scriptable Objects/Item/ItemConsumbles")]
public class ItemConsumbles : Item
{
    [SerializeField]
    private TypeConsumbles _typeCloth;

    public TypeConsumbles Type { get { return _typeCloth; } }


    public override string ItemActionText()
    {
        if (Type == TypeConsumbles.Cartridge)
        {
            return "������";
        }
        else if (Type == TypeConsumbles.MedicineBox)
        {
            return "������";
        }

        return "";
    }

    public override string Stats()
    {
        if (Type == TypeConsumbles.Cartridge)
        {
            return "";
        }
        else if (Type == TypeConsumbles.MedicineBox)
        {
            return "��������������� +6 ��������";
        }

        return "";
    }

    public override void UseItemInventory(Inventory inventory)
    {
        if (Type == TypeConsumbles.Cartridge)
        {
            inventory.FullAmmountSlot(this);
        }
        else if (Type == TypeConsumbles.MedicineBox)
        {
            inventory.HealCharacter(6);
            inventory.UseItemSlot(this, 1);
        }
    }
}

public enum TypeConsumbles
{
    Cartridge, MedicineBox
}