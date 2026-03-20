using TMPro;
using UnityEngine;

public class GameController : PersistantSingleton<GameController>
{
    [SerializeField] private GameObject[] enemySpawnPoints;
    [SerializeField] private GameObject goldResource;
    [SerializeField] private int goldNum = 20;
    public float goldGenerationTime = 5;
    [SerializeField] private float goldGenerationTick = 5;
    public int goldGenerationRate = 10;

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

    public void FixedUpdate()
    {
        if (goldGenerationTick <= 0)
        {
            goldGenerationTick = 0;
            SetGold(GetGold() + goldGenerationRate);
            goldGenerationTick = goldGenerationTime;
        }
        if (goldGenerationTick > 0) goldGenerationTick -= Time.deltaTime;
    }

    public int GetGold() { return goldNum; }
    public void SetGold(int gold)
    {
        goldNum = gold;
        string str = "" + GetGold();
        goldResource.GetComponent<TextMeshProUGUI>().SetText(str);
    }
}
