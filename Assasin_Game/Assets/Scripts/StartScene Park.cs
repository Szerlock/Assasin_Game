using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class StartScenePark : MonoBehaviour
{
    [SerializeField]
    public GameObject objectToInstantiate; 
    public Vector3 spawnPosition = new Vector3(2.6f, 0.45f, 0f);

    [SerializeField]
    public float moveSpeed;
    [SerializeField]
    public float changeDirectionTime;

    private GameObject instantiatedObject;
    private float timer;
    private Rigidbody2D rb;

    void Start()
    {
        instantiatedObject = Instantiate(objectToInstantiate, spawnPosition, Quaternion.identity);
        rb = instantiatedObject.GetComponent<Rigidbody2D>();
        timer = changeDirectionTime;
        ChooseRandomDirection();
    }

    void Update()
    {
        if (rb == null)
        {
            return;
        }
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            ChooseRandomDirection();
            timer = changeDirectionTime;
        }
    }

    private void ChooseRandomDirection()
    {
        Vector2 randomDirection = new Vector2(UnityEngine.Random.Range(-1.0f, 1.0f), UnityEngine.Random.Range(-1.0f, 1.0f)).normalized;
        rb.velocity = randomDirection * moveSpeed;
    }
}
