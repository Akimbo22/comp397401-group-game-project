using UnityEngine;
using UnityEngine.InputSystem;
using EnhancedTouch = UnityEngine.InputSystem.EnhancedTouch;
using UnityEngine.UI;
using System.Linq;

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
    private bool touchState = false;
    [SerializeField] private GameController gameController;
    [SerializeField] private Object towerPrefab;
    [SerializeField] private RectTransform shopPanelOverlay;

    void Start()
    {
        toggle = GetComponent<Toggle>();
        EnhancedTouch.Touch.onFingerDown += FingerDown;
        EnhancedTouch.Touch.onFingerUp += FingerUp;
    }

    //Touch requirements
    void Awake()
    {
        EnhancedTouch.EnhancedTouchSupport.Enable();
        EnhancedTouch.TouchSimulation.Enable();
    }

    //Ditto
    private void OnDisable()
    {
        EnhancedTouch.EnhancedTouchSupport.Disable();
        EnhancedTouch.TouchSimulation.Disable();
    }

    void Update()
    {
        #region Web Controls
        //Web controls
        /*if (toggle.isOn && Mouse.current.rightButton.wasReleasedThisFrame && gameController.GetGold() >= towerCost && shopPanelOverlay.rect.Contains(Mouse.current.position.ReadValue())==false)
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
    }

    private void FingerDown(EnhancedTouch.Finger finger)
    {
        #region Mobile Controls
        if (toggle.isOn && gameController.GetGold() >= towerCost && touchState==false && shopPanelOverlay.rect.Contains(finger.screenPosition)==false)
        {
            Ray ray = mainCam.ScreenPointToRay(EnhancedTouch.Touch.fingers[0].screenPosition);
            if (Physics.Raycast(ray, out RaycastHit hitPos))
            {
                GameObject tower = (GameObject)GameObject.Instantiate(towerPrefab);
                tower.gameObject.transform.position = new Vector3(hitPos.point.x, 17.41147f, hitPos.point.z);
                gameController.SetGold(gameController.GetGold() - towerCost);
                touchState = true;
            }
        }
        #endregion
    }

    private void FingerUp(EnhancedTouch.Finger finger)
    {
        touchState = false;
    }
}
