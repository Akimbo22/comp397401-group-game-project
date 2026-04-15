using UnityEngine;

[CreateAssetMenu(fileName = "New Quest", menuName = "Quests/Quest")]
public class Quest : ScriptableObject
{
    public string questName;

    public int targetAmount;
    public int currentAmount;

    public bool completed;

    public void AddProgress(int amount)
    {
        if (completed) return;

        currentAmount += amount;

        Debug.Log(questName + " Progress: " + currentAmount + "/" + targetAmount);

        if (currentAmount >= targetAmount)
        {
            CompleteQuest();
        }
    }

    public void CompleteQuest()
    {
        if (completed) return;

        completed = true;

        Debug.Log("? QUEST COMPLETED: " + questName);
    }

    public void ResetQuest()
    {
        currentAmount = 0;
        completed = false;
    }
}