using UnityEngine;
using UnityEngine.UI;


public class SmoothCamera : MonoBehaviour
{
    [SerializeField] private GameObject player;

    private Vector3 posEnd,posSmooth;
    private void Update()
    {
        posEnd = new Vector3(player.transform.position.x,player.transform.position.y,transform.position.z);
        posSmooth = Vector3.Lerp(transform.position,posEnd,0.25f);
        transform.position = posSmooth;
    }
}
