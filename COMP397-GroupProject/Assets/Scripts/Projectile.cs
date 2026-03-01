using UnityEngine;

[RequireComponent (typeof(Rigidbody))]
public class Projectile : MonoBehaviour
{
    [SerializeField] float life;
    public float speed;
    [SerializeField] float pierce;
    [SerializeField] bool isActive;
    public enum ProjectileProperties
    {
        None = 0,
        Homing = 1,
        IgnoreDamageTypes = 2
    }
    [SerializeField] ProjectileProperties[] properties;

    public void addProjectileProperty(ProjectileProperties[] _property)
    {
        if (_property.Length < 1) return;
        for (int i = 0; i < _property.Length; i++)
        {
            
        }
    }

    void Start()
    {
        if (life < 0 && life != -1) life = 1;
    }

    void Update()
    {
        if (life <= 0) { Destroy(gameObject); }
        else { life -= Time.deltaTime; }
    }
}
