using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudGenerator : MonoBehaviour
{
    
    [SerializeField] GameObject[] cloud;

    [SerializeField] float spawnFrequency;

    [SerializeField] GameObject endPoint;

    Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
