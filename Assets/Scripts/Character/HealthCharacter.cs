using UnityEngine;

public class HealthCharacter : Health
{
    [SerializeField]
    private Inventory _inventory;

    [SerializeField]
    private bool _hit;

    [SerializeField]
    private GameObject _gameOver;

    public void DamageCharacter(int damage)
    {
        if (_hit)
        {
            Damage(damage - _inventory.EquipSlots[0].Armor);
        }
        else
        {
            Damage(damage - _inventory.EquipSlots[1].Armor);
        }

        if (Hp <= 0)
        {
            Dead();
        }
        _hit = !_hit;
    }

    public void Dead()
    {
        _gameOver.SetActive(true);
    }
}
