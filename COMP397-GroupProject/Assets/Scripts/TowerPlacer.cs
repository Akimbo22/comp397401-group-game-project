using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class TowerPlacer : MonoBehaviour
{
    private Toggle toggle;
    [SerializeField] private Camera mainCam;

    //public enum Currency
    //{
    //    Gold,
    //    Oil
    //}
    //public Currency towerCurrency;
    public int towerCost;
    [SerializeField] private GameController gameController;
    [SerializeField] private Object towerPrefab;

    void Start()
    {
        toggle = GetComponent<Toggle>();
    }

    void Update()
    {
        if (toggle.isOn && Mouse.current.rightButton.wasReleasedThisFrame && gameController.GetGold() >= towerCost)
        {
            Ray ray = mainCam.ScreenPointToRay(Mouse.current.position.ReadValue());
            if (Physics.Raycast(ray, out RaycastHit hitPos))
            {
                GameObject tower = (GameObject)GameObject.Instantiate(towerPrefab);
                tower.gameObject.transform.position = new Vector3(hitPos.point.x, 17.41147f, hitPos.point.z);
                gameController.SetGold(gameController.GetGold() - towerCost);
            }
        }
    }
}
