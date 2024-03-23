using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovements : MonoBehaviour
{
    public CharacterController playerControl;

    public float speed;

    float velocityAngle;

    public float smoothTime;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Vector3 direction = new Vector3(horizontal, 0, vertical).normalized;

        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;

            float smoothAngle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref velocityAngle, smoothTime);

            transform.rotation = Quaternion.Euler(0, smoothAngle, 0);

            playerControl.Move(direction * speed * Time.deltaTime);
        }

    }
}
