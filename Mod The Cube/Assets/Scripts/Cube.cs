using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public MeshRenderer Renderer;
    public Color[] colors;
    public float minScale = 1f;
    public float maxScale = 10f;
    public float scaleSpeed = 1f;

    private float scalingDirection = 1f;


    void Start()
    {
        InvokeRepeating("ChangeColor", 0f, 1f);
        transform.position = new Vector3(3, 4, 1);
        transform.localScale = Vector3.one * 2f;
    }

    void Update()
    {
        float currentScale = transform.localScale.x;
        if (currentScale >= maxScale)
        {
            scalingDirection = -1f;
        }
        else if (currentScale <= minScale)
        {
            scalingDirection = 1f;
        }
        transform.localScale += Vector3.one * scalingDirection * scaleSpeed * Time.deltaTime;
        transform.Rotate(15.0f * Time.deltaTime, 0.0f, 0.0f);

    }
    void ChangeColor()
    {
        int index = Random.Range(0, colors.Length);
        Debug.Log(index);
        Renderer.material.color = new Color(colors[index].r, colors[index].g, colors[index].b, colors[index].a);
    }
}
