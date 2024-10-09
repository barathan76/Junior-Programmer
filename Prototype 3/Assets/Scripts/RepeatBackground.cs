using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackground : MonoBehaviour
{
    // Start is called before the first frame update
    private float width;
    private Vector3 startPosition;
    void Start()
    {
        startPosition = transform.position;
        width = GetComponent<BoxCollider>().size.x / 2;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < startPosition.x - width)
        {
            transform.position = startPosition;
        }
    }
}
