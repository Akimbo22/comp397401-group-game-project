using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyCollectionPool : PersistantSingleton<EnemyCollectionPool>
{
    [SerializeField] private Enemy[] enemyPrefabPool;
    private Queue<Enemy> enemyPool = new Queue<Enemy>();

    public Enemy Get()
    {
        if (enemyPool.Count == 0)
        {
            AddEnemy(1);
        }
        return enemyPool.Dequeue();
    }

    private void AddEnemy(int count)
    {
        //Add random enemy into the spawn pool
        if (enemyPrefabPool.Length < 1) return;
        for (int i = 0; i < count; i++)
        {
            System.Random r = new System.Random();
            int rand = r.Next(0,enemyPrefabPool.Length);

            var enemy = Instantiate(enemyPrefabPool[rand]);
            enemy.gameObject.SetActive(false);
            enemyPool.Enqueue(enemy);
        }
    }

    public void ReturnToPool(Enemy enemy)
    {
        enemy.gameObject.SetActive(false);
        enemyPool.Enqueue(enemy);
    }
}
