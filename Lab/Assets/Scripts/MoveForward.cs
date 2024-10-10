using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody enemyRb;
    private float zBound = -9f;
    public float speed = 20f;
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        enemyRb.AddForce(Vector3.forward * -speed);
        if (transform.position.z < zBound)
        {
            Destroy(gameObject);
        }
    }
}
