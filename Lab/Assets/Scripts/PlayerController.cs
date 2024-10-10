using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody playerRb;
    public float speed = 20f;
    private float zbound = 6.0f;
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        playerRb.AddForce(Vector3.forward * speed * verticalInput);
        playerRb.AddForce(Vector3.right * speed * horizontalInput);

        if (transform.position.z > zbound)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zbound);
        }
        if (transform.position.z < -zbound)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -zbound);
        }

    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PowerUp"))
        {
            Destroy(other.gameObject);
        }
    }
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Collided with " + other.gameObject.name);
        }
    }
}
