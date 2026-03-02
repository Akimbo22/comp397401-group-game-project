using UnityEngine;

public class Minecart : MonoBehaviour
{
    [SerializeField] private int MaxHP = 50;
    [SerializeField] private int hp = 50;
    [SerializeField] private Tower placedTower = null;

    public void Start()
    {
        if (hp < MaxHP) hp = MaxHP;
    }

    public void FixedUpdate()
    {
        if (hp <= 0)
        {
            OnDeath();
        }
    }

    public virtual Tower GetTower()
    {
        if (placedTower != null)
        {
            return placedTower;
        }
        else
        {
            return null;
        }
    }

    public void SetTower(Tower _tower) { this.placedTower = _tower; }

    public void OnDeath()
    {

    }
}
