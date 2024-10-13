using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    float speed;
    [SerializeField] float horsePower;
    [SerializeField] float turnSpeed = 25.0f;
    [SerializeField] float horizontalInput;
    [SerializeField] GameObject centerOfMass;
    private float verticalInput;
    [SerializeField] private TextMeshProUGUI speedText;
    [SerializeField] private TextMeshProUGUI rpmText;
    [SerializeField] private float rpm;
    [SerializeField] List<WheelCollider> allWheels;
    [SerializeField] int wheelsOnGround;
    private Rigidbody playerRb;
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerRb.centerOfMass = centerOfMass.transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        if (IsOnGround())
        {
            //transform.Translate(Vector3.forward * Time.deltaTime * speed * verticalInput);
            speed = Mathf.Round(playerRb.velocity.magnitude * 3.6f);
            speedText.text = "Speed:" + speed;
            rpm = Mathf.Round((speed % 30) * 40);
            rpmText.text = "RPM:" + rpm;
            playerRb.AddRelativeForce(Vector3.forward * verticalInput * horsePower);
            transform.Rotate(Vector3.up, Time.deltaTime * turnSpeed * horizontalInput);
        }

    }

    bool IsOnGround()
    {
        wheelsOnGround = 0;
        foreach (WheelCollider wheel in allWheels)
        {
            if (wheel.isGrounded)
            {
                wheelsOnGround++;
            }
        }
        if (wheelsOnGround > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }






}
