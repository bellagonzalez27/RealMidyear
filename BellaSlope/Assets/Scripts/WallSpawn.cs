using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    [SerializeField] GameObject [] walls;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Instantiate(walls[1]);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
