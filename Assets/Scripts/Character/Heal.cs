using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Health : MonoBehaviour
{
    [SerializeField]
    private int _health;

    [SerializeField]
    private int _maxHealth;

    [SerializeField]
    private Image _hpBarIcon;

    [SerializeField]
    private TMP_Text _hpText;

    public int Hp {  get {  return _health; } }

    virtual public void Damage(int damaged)
    {
        if (_health - damaged > 0)
        {
            _health -= damaged;
        }
        else
        {
            _health = 0;
        }
        UpdateHpBar();
    }


    public void Heal(int heal)
    {
        if (_health + heal <= _maxHealth)
        {
            _health += heal;
        }
        else
        {
            _health = _maxHealth;
        }
        UpdateHpBar();
    }

    public void UpdateHpBar()
    {
        float percentage = (float)_health / _maxHealth;
        _hpBarIcon.fillAmount = percentage;
        _hpText.text = _health + "/" + _maxHealth;
    }

    public void LoadHealth(int health)
    {
        _health = health;
        UpdateHpBar();
    }
}
