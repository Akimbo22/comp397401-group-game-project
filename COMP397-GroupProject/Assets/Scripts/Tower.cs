<<<<<<< HEAD
using UnityEngine;
=======
using Unity.VectorGraphics;
using UnityEngine;
using UnityEngine.SceneManagement;
>>>>>>> 16e3405c35b14b645687d9d094ab624863deddd3

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
    [SerializeField] float shotDelay = 0;
    [SerializeField] Quaternion shotOffsetRotation;
<<<<<<< HEAD
=======
    [SerializeField] private bool isPlayerTower;
    [SerializeField] AudioController audioController;
>>>>>>> 16e3405c35b14b645687d9d094ab624863deddd3
    LayerMask enemyLayer;

    void Awake()
    {
        enemyLayer = LayerMask.GetMask("EnemyLayer");
    }

    void Start()
    {
        if (maxHealth < 0) maxHealth = 1;
        health = maxHealth;
    }

    public void setProjectile(GameObject _projecitle) { projectile = _projecitle; }
    public void resetProjectile() { projectile = baseProjectile; }

    void FixedUpdate()
    {
        if (Physics.Linecast(projectileSpawnPos.position,(projectileSpawnPos.forward * range) + new Vector3(projectileSpawnPos.position.x, projectileSpawnPos.position.y, 0),enemyLayer))
        {
            if (shotDelay <= 0)
            {
                shotDelay = 0;
                Shoot();
                shotDelay = baseShotDelay;
            }
        }
        if (shotDelay > 0) shotDelay -= Time.deltaTime;
    }

    private void OnDrawGizmos()
    {
        if (!enabled || range <= 0) return;
        //Gizmos.DrawLine(projectileSpawnPos.position, new Vector3(projectileSpawnPos.position.x, projectileSpawnPos.position.y, projectileSpawnPos.position.z + range));
        Gizmos.DrawLine(projectileSpawnPos.position, (projectileSpawnPos.forward * range) + new Vector3(projectileSpawnPos.position.x,projectileSpawnPos.position.y,0));
        //Gizmos.DrawWireCube(new Vector3(projectileSpawnPos.position.x, projectileSpawnPos.position.y, projectileSpawnPos.position.z + (range / 2)), new Vector3(0.5f, 0.5f, range));
        //Gizmos.DrawWireCube((projectileSpawnPos.position + (projectileSpawnPos.forward * range)) / 2, new Vector3(0.5f, 0.5f, range));
    }

    public void Shoot()
    {
        //Quaternion shotRotation = new Quaternion(projectileSpawnPos.rotation.x + shotOffsetRotation.x, projectileSpawnPos.rotation.y + shotOffsetRotation.y, projectileSpawnPos.rotation.z + shotOffsetRotation.z, projectileSpawnPos.rotation.w + shotOffsetRotation.w);
        //GameObject shot = GameObject.Instantiate(projectile, projectileSpawnPos.transform.position, shotRotation);
        GameObject shot = GameObject.Instantiate(projectile, projectileSpawnPos.transform.position, projectileSpawnPos.rotation);
        shot.GetComponent<Rigidbody>().AddForce(projectileSpawnPos.transform.forward * shot.GetComponent<Projectile>().speed, ForceMode.Impulse);
<<<<<<< HEAD
=======
        audioController.PlayShootSFX();
>>>>>>> 16e3405c35b14b645687d9d094ab624863deddd3
    }

    public void takeDamage(int damage, string type, bool isNonLethal = false)
    {
        //

<<<<<<< HEAD

=======
        audioController.PlayHitSFX();
>>>>>>> 16e3405c35b14b645687d9d094ab624863deddd3
        health -= damage;
        if (health < 0 && isNonLethal) health = 1;
        else
        {
            OnDeath();
        }
    }

    public void OnDeath()
    {
<<<<<<< HEAD

=======
        if (!isPlayerTower)
        {
            audioController.PlayDeathSFX();
            Destroy(gameObject);
        }
        else
        {
            SceneManager.LoadScene("GameOverScene");
        }
>>>>>>> 16e3405c35b14b645687d9d094ab624863deddd3
    }
}
