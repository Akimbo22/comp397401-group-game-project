using UnityEngine;
using Unity.VectorGraphics;
using UnityEngine.SceneManagement;

public class Tower : MonoBehaviour
{
    [SerializeField] Transform projectileSpawnPos;
    [SerializeField] float range = 10f;
    [SerializeField] int maxHealth;
    [SerializeField] int health;
    [SerializeField] int projectileDamage;
    [SerializeField] GameObject projectile;
    [SerializeField] GameObject baseProjectile;
    [SerializeField] float baseShotDelay = 10;
    [SerializeField] float shotDelay;
    private float shotDelayTick = 0;
    [SerializeField] Quaternion shotOffsetRotation;

    public enum CostType
    {
        Gold = 0,
        Crystal = 1,
        Oil = 2
    }
    [SerializeField] CostType costType;
    [SerializeField] int cost;

    [SerializeField] private bool isPlayerTower;
    [SerializeField] AudioController audioController;

    LayerMask enemyLayer;

    void Awake()
    {
        enemyLayer = LayerMask.GetMask("EnemyLayer");
    }

    void Start()
    {
        if (shotDelay < 0) shotDelay = baseShotDelay;
        if (maxHealth < 0) maxHealth = 1;
        health = maxHealth;
        if (cost < 0) cost = 0;
    }

    public void setProjectile(GameObject _projecitle) { projectile = _projecitle; }
    public void resetProjectile() { projectile = baseProjectile; }

    void FixedUpdate()
    {
        if (Physics.Linecast(projectileSpawnPos.position,(projectileSpawnPos.forward * range) + new Vector3(projectileSpawnPos.position.x, projectileSpawnPos.position.y, 0),enemyLayer))
        {
            if (shotDelayTick <= 0)
            {
                shotDelayTick = 0;
                Shoot();
                shotDelayTick = shotDelay;
            }
        }
        if (shotDelayTick > 0) shotDelayTick -= Time.deltaTime;
    }

    //Draw range in editor
    private void OnDrawGizmos()
    {
        if (!enabled || range <= 0) return;
        Gizmos.DrawLine(projectileSpawnPos.position, (projectileSpawnPos.forward * range) + new Vector3(projectileSpawnPos.position.x,projectileSpawnPos.position.y,0));
    }

    ///Shoots a Projectile, if no GameObject is passed under _projectile then it shoots the tower's default projectile
    ///Applies special projectile modifiers propertiesModifiers if any are passed
    public void Shoot(GameObject _projectile = null, Projectile.ProjectileProperties[] propertiesModifiers = null)
    {
        if (_projectile == null) _projectile = projectile;

        GameObject shot = GameObject.Instantiate(projectile, projectileSpawnPos.transform.position, projectileSpawnPos.rotation);
        shot.GetComponent<Rigidbody>().AddForce(projectileSpawnPos.transform.forward * shot.GetComponent<Projectile>().speed, ForceMode.Impulse);

        if (propertiesModifiers != null)
        {

        }

        audioController.PlayShootSFX();
    }



    public void OnPlaced()
    {

    }

    public void takeDamage(int damage, string type, bool isNonLethal = false)
    {
        audioController.PlayHitSFX();

        health -= damage;
        if (health < 0 && isNonLethal) health = 1;
        else
        {
            OnDeath();
        }
    }

    public void OnDeath()
    {
        if (!isPlayerTower)
        {
            audioController.PlayDeathSFX();
            Destroy(gameObject);
        }
        else
        {
            SceneManager.LoadScene("GameOverScene");
        }
    }
}
