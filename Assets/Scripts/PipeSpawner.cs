using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    [SerializeField] GameObject pipe;
    [SerializeField] float spawnTime;
    [SerializeField] float yPosMin;
    [SerializeField] float yPosMax;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnPipeCouroutine());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnPipeCouroutine()
    {
        yield return new WaitForSeconds(spawnTime);
        Instantiate(pipe, transform.position + Vector3.up * Random.Range(yPosMin, yPosMax), Quaternion.identity);
        StartCoroutine(SpawnPipeCouroutine());
    }
}
