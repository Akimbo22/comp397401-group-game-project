using UnityEngine;

public class QuestManager : MonoBehaviour
{
    [Header("Quests")]
    public Quest killEnemiesQuest;
    public Quest collectGoldQuest;

    private void Start()
    {
        var events = EventChannelManager.instance;

        if (events == null)
        {
            Debug.LogError("EventChannelManager NOT FOUND!");
            return;
        }

        // Reset quests on play (important for testing)
        killEnemiesQuest?.ResetQuest();
        collectGoldQuest?.ResetQuest();

        events.onEnemyKilled.Register(OnEnemyKilled);
        events.onGoldChanged.Register(OnGoldChanged);
    }

    private void OnDestroy()
    {
        var events = EventChannelManager.instance;
        if (events == null) return;

        events.onEnemyKilled.Unregister(OnEnemyKilled);
        events.onGoldChanged.Unregister(OnGoldChanged);
    }

    private void OnEnemyKilled(int amount)
    {
        killEnemiesQuest?.AddProgress(amount);
    }

    private void OnGoldChanged(int amount)
    {
        collectGoldQuest?.AddProgress(amount);
    }
}