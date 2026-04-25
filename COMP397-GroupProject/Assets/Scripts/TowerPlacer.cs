using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.EnhancedTouch;
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
    [SerializeField] private RectTransform shopPanelOverlay;

    void Start()
    {
        toggle = GetComponent<Toggle>();
    }

    void Awake()
    {
        EnhancedTouchSupport.Enable();
        TouchSimulation.Enable();
    }

    void Update()
    {
        #region Web Controls
        //Web controls
        /*if (toggle.isOn && Mouse.current.rightButton.wasReleasedThisFrame && gameController.GetGold() >= towerCost && !(shopPanelOverlay.rect.Contains(Mouse.current.position.ReadValue())))
        {
            Ray ray = mainCam.ScreenPointToRay(Mouse.current.position.ReadValue());
            if (Physics.Raycast(ray, out RaycastHit hitPos))
            {
                GameObject tower = (GameObject)GameObject.Instantiate(towerPrefab);
                tower.gameObject.transform.position = new Vector3(hitPos.point.x, 17.41147f, hitPos.point.z);
                gameController.SetGold(gameController.GetGold() - towerCost);
            }
        }/**/
        #endregion

        if (Input.touchCount > 0) Debug.Log("Touch Count non-0");
        if (Touchscreen.current.primaryTouch.IsPressed()) Debug.Log("Touchscreen Press");

        #region Mobile Controls
        if (Touchscreen.current.primaryTouch.IsPressed() && gameController.GetGold() >= towerCost && !(shopPanelOverlay.rect.Contains(Touchscreen.current.position.ReadValue())))
        {
            Ray ray = mainCam.ScreenPointToRay(Mouse.current.position.ReadValue());
            if (Physics.Raycast(ray, out RaycastHit hitPos))
            {
                GameObject tower = (GameObject)GameObject.Instantiate(towerPrefab);
                tower.gameObject.transform.position = new Vector3(hitPos.point.x, 17.41147f, hitPos.point.z);
                gameController.SetGold(gameController.GetGold() - towerCost);
            }
        }
        #endregion
    }
}
