using UnityEngine;

public class HealthCharacter : Health
{
    [SerializeField]
    private Inventory _inventory;

    [SerializeField]
    private bool _hit;

    public void ArrmorCharacter(int damage)
    {
        if (_hit)
        {
            Damage(damage - _inventory.EquipSlots[0].Armor);
        }
        else
        {
            Damage(damage - _inventory.EquipSlots[1].Armor);
        }

        _hit = !_hit;
    }
}
