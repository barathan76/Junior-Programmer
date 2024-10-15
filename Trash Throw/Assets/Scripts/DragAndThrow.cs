using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DragAndThrow : MonoBehaviour
{
    // Start is called before the first frame update
    private Vector3 mousePressDownPos;
    private Vector3 mouseReleasePos;
    private Rigidbody objectRb;
    private float forceMultiplier = 3f;

    void Start()
    {
        objectRb = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnMouseDown()
    {
        mousePressDownPos = Input.mousePosition;
    }

    void OnMouseUp()
    {
        mouseReleasePos = Input.mousePosition;
        Throw();
    }

    void Throw()
    {
        Debug.Log(mousePressDownPos + " " + mouseReleasePos);
        Vector3 direction = (mousePressDownPos - mouseReleasePos).normalized + new Vector3(0, 0, 1);
        float distance = Vector3.Distance(mousePressDownPos, mouseReleasePos);
        objectRb.AddForce(direction * distance * forceMultiplier);
    }



}
