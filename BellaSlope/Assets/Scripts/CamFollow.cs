using UnityEngine;

public class CamFollow : MonoBehaviour
{
    [SerializeField] GameObject cam;
    [SerializeField] GameObject player;

    void Update()
    {
        cam.transform.position = new Vector3(player.transform.position.x + 5, player.transform.position.y + 3, player.transform.position.z);
    }
}
