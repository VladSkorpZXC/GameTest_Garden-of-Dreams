using UnityEngine;
using UnityEngine.UI;
public class AttackController : MonoBehaviour
{
    [SerializeField]
    private TypeAttack _typeAttack;

    [SerializeField]
    private Inventory _inventory;

    [SerializeField]
    private ItemConsumbles _gun;

    [SerializeField]
    private ItemConsumbles _machineGun;

    [SerializeField]
    private HealthCharacter _healthCharacter;

    [SerializeField]
    private HealthEnemy _healthEnemy;

    [SerializeField]
    private bool _isMoveCharacter;

    [SerializeField]
    private Button _buttonAttack;

    public void ChooseTypeAttack(int typeAttack)
    {
        if (typeAttack == 0)
        {
            _typeAttack = TypeAttack.Gun;
        }
        if (typeAttack == 1)
        {
            _typeAttack = TypeAttack.MachineGun;
        }
    }

    public void Attack()
    {
        if (_healthCharacter.Hp > 0)
        {
            _buttonAttack.enabled = false;
            _isMoveCharacter = false;

            AttackCharacter();

            IsMove();
        }
    }

    public void AttackCharacter()
    {
        if (_typeAttack == TypeAttack.Gun)
        {
            if (_inventory.UseItemSlot(_gun, 1))
            {
                _healthEnemy.DamageEnemy(5);
            }
        }
        else if (_typeAttack == TypeAttack.MachineGun)
        {
            if (_inventory.UseItemSlot(_machineGun, 3))
            {
                _healthEnemy.DamageEnemy(9);
            }
        }
    }

    public void AttackEnemy()
    {
        if (_healthEnemy.Hp > 0)
        {
            _healthCharacter.DamageCharacter(15);

            _isMoveCharacter = true;

            IsMove();
        }
    }

    public void IsMove()
    {
        if (_isMoveCharacter)
        {
            _buttonAttack.enabled = true;
        }
        else
        {
            AttackEnemy();
        }
    }
}

public enum TypeAttack
{
    Gun, MachineGun
}