using UnityEngine;

[CreateAssetMenu(fileName = "New Achievement", menuName = "Achievements/Achievement")]
public class Achievement : ScriptableObject
{
    public string achievementName;

    public int targetValue = 1;
    public int currentValue = 0;

    public bool unlocked = false;

    public void AddProgress(int amount)
    {
        if (unlocked) return;

        currentValue += amount;

        if (currentValue >= targetValue)
        {
            Unlock();
        }
    }

    public void Unlock()
    {
        if (unlocked) return;

        unlocked = true;
        Debug.Log("?? ACHIEVEMENT UNLOCKED: " + achievementName);
    }

    public void ResetAchievement()
    {
        currentValue = 0;
        unlocked = false;
    }
}