using Unity.VisualScripting;
using UnityEngine;

public class BombExplosion : MonoBehaviour
{
    [SerializeField] Object explosionObject;

    private void OnDestroy()
    {
        GameObject explosion = (GameObject)GameObject.Instantiate(explosionObject);
        explosion.transform.position = this.transform.position;
    }
}
