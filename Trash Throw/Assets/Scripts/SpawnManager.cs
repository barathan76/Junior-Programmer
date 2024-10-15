using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject[] gameObjects;
    [SerializeField] private float yPosition;
    [SerializeField] private float zPosition;
    [SerializeField] private float[] xRange;
    private GameManager gameManager;

    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        InvokeRepeating("SpawnObject", 1f, 3f);
    }

    // Update is called once per frame
    void Update()
    {

    }
    void SpawnObject()
    {
        if (!gameManager.isGameOver)
        {
            int index = GetRandomObject();
            Instantiate(gameObjects[index], GetRandomPosition(), gameObjects[index].transform.rotation);
        }
    }
    Vector3 GetRandomPosition()
    {
        return new Vector3(Random.Range(xRange[0], xRange[1]), yPosition, zPosition);
    }
    int GetRandomObject()
    {
        return Random.Range(0, gameObjects.Length);
    }

}
