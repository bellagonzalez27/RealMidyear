using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] Rigidbody playerrb;
    [SerializeField] float moveSpeed;
    [SerializeField] float startSpeed;
    [SerializeField] float timeStartSpeed;
    float jumpForce = 0.15f;
    float timeStartSpeedCounter;

    void Update()
    {
        if(timeStartSpeedCounter <= timeStartSpeed)
        {
            playerrb.AddForce(Vector3.forward * startSpeed);
            timeStartSpeedCounter+=1;
        }

        if(Input.GetKey(KeyCode.LeftArrow))
        {
            playerrb.AddForce(Vector3.back * moveSpeed);
        }

        if(Input.GetKey(KeyCode.RightArrow))
        {
            playerrb.AddForce(Vector3.forward * moveSpeed);
        }

        if(Input.GetKey(KeyCode.UpArrow))
        {
            playerrb.AddForce(new Vector3(0, jumpForce), ForceMode.Impulse);
        }

        if(Input.GetKey(KeyCode.DownArrow))
        {
            playerrb.AddForce(new Vector3(0, -jumpForce), ForceMode.Impulse);
        }
    }
}
