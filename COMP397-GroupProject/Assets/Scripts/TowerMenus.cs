using UnityEngine;
using UnityEngine.UI;

public class TowerMenus : MonoBehaviour
{
    [SerializeField] private GameObject[] menus;
    
    public void ToggleTowerSelections(int selMenu)
    {
        for (int i = 0; i < menus.Length; i++)
        {
            if (i != selMenu)
            {
                menus[i].GetComponent<Toggle>().isOn = false;
            }
        }
    }
}
