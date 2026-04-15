using UnityEngine;

public class EventChannelManager : MonoBehaviour
{
    public static EventChannelManager instance;

    [Header("Combat Events")]
    public GameEvent onEnemyKilled;
    public GameEvent onFirstEnemyKilled;

    [Header("Economy Events")]
    public GameEvent onGoldChanged;

    [Header("Wave Events")]
    public GameEvent onWaveCompleted; // passes wave number

    private void Awake()
    {
        instance = this;
    }
}