using UnityEngine;
using System.Collections.Generic;
public class HealthEnemy : Health
{
    [SerializeField]
    private Inventory _inventory;

    [SerializeField]
    private List<Item> _items;

    public void DamageEnemy(int damage)
    {
        Damage(damage);

        if (Hp <= 0)
        {
            Dead();
        }
    }

    public void Dead()
    {
        int randItem = Random.Range(0, _items.Count);

        _inventory.AddItemInvetory(_items[randItem], 1);
    }
}