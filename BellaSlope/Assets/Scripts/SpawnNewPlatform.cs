using UnityEngine;

public class SpawnNewPlatform : MonoBehaviour
{

    [SerializeField] GameObject [] platforms;
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Instantiate(platforms[Random.Range(0, platforms.Length)], new Vector3(transform.position.x - 7, transform.position.y - 4, transform.position.z), Quaternion.identity);
        }
    }
}
