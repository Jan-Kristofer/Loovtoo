using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject SpawnArea;
    GameObject[] cubes;
    GameObject SpawnCubee;
    int index;

    void Start()
    {
    }

    void Awake()
    {
        StartCoroutine(CubeCoroutine());
    }

    IEnumerator CubeCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(0,2));
            float RanX = Random.Range(30, -30);
            float RanZ = Random.Range(30, -30);
            SpawnCube(RanX, RanZ);
        }
    }

    void SpawnCube(float x, float z)
    {
        cubes = GameObject.FindGameObjectsWithTag("Cube");
        index = Random.Range(0, cubes.Length);
        SpawnCubee = cubes[index];
        Instantiate(SpawnCubee, new Vector3(x, 39, z), Quaternion.identity);
    }

}
