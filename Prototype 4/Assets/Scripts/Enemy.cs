using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Rigidbody enemyRb;
    private GameObject player;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 lookDirection = (player.transform.position - transform.position).normalized;
        enemyRb.AddForce((player.transform.position - transform.position).normalized * speed);
        if (enemyRb.transform.position.y < -5)
        {
            Destroy(gameObject);
        }
    }

}
