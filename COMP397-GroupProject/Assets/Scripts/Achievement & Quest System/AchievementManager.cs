using UnityEngine;

public class AchievementManager : MonoBehaviour
{
    [Header("Achievements")]
    public Achievement firstKill;
    public Achievement kill10Enemies;
    public Achievement collect100Gold;
    public Achievement wave1_1;
    public Achievement wave1_2;

    private void Start()
    {
        var events = EventChannelManager.instance;

        if (events == null)
        {
            Debug.LogError("EventChannelManager NOT FOUND!");
            return;
        }

        events.onEnemyKilled.Register(OnEnemyKilled);
        events.onGoldChanged.Register(OnGoldChanged);
        events.onWaveCompleted.Register(OnWaveCompleted);
    }

    private void OnDestroy()
    {
        var events = EventChannelManager.instance;
        if (events == null) return;

        events.onEnemyKilled.Unregister(OnEnemyKilled);
        events.onGoldChanged.Unregister(OnGoldChanged);
        events.onWaveCompleted.Unregister(OnWaveCompleted);
    }

    // ? ENEMY KILLS
    private void OnEnemyKilled(int amount)
    {
        Debug.Log("EVENT RECEIVED: Enemy Killed +" + amount);

        // First kill (instant)
        firstKill?.Unlock();

        // Kill 10 enemies (progress)
        kill10Enemies?.AddProgress(amount);
    }

    // ? GOLD
    private void OnGoldChanged(int amount)
    {
        Debug.Log("EVENT RECEIVED: Gold +" + amount);

        collect100Gold?.AddProgress(amount);
    }

    // ? WAVES
    private void OnWaveCompleted(int waveNumber)
    {
        Debug.Log("EVENT RECEIVED: Wave " + waveNumber);

        if (waveNumber == 1)
            wave1_1?.Unlock();

        if (waveNumber == 2)
            wave1_2?.Unlock();
    }
}
