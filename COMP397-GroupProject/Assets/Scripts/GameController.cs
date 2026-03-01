using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private GameObject[] enemySpawnPoints;

    public void SpawnEnemy(int row = -1, Enemy _enemy = null)
    {
        if (row == -1 && _enemy == null && enemySpawnPoints.Length > 0)
        {
            Enemy enemy = EnemyCollectionPool.Instance.Get();
            
            System.Random r = new System.Random();
            int rand = r.Next(0, enemySpawnPoints.Length);

            enemy.transform.SetPositionAndRotation(enemySpawnPoints[rand].transform.position, enemySpawnPoints[rand].transform.rotation);
        }
    }
}
