using UnityEngine;

public class LevelSetup : MonoBehaviour
{
    public int killsNeeded = 3;

    void Start()
    {
        KillCounter.Instance.ResetCounter(killsNeeded);
    }
}