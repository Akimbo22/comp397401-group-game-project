using UnityEngine;
using System;

[CreateAssetMenu(menuName = "Events/GameEvent")]
public class GameEvent : ScriptableObject
{
    private Action listeners;
    private Action<int> intListeners;

    public void Raise()
    {
        Debug.Log("EVENT RAISED: " + name);
        listeners?.Invoke();
    }

    public void Raise(int value)
    {
        Debug.Log("EVENT RAISED WITH VALUE: " + name + " = " + value);
        intListeners?.Invoke(value);
    }

    public void Register(Action listener)
    {
        listeners += listener;
    }

    public void Register(Action<int> listener)
    {
        intListeners += listener;
    }

    public void Unregister(Action listener)
    {
        listeners -= listener;
    }

    public void Unregister(Action<int> listener)
    {
        intListeners -= listener;
    }
}
