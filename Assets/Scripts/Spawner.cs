using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject prefab;

    public GameObject Spawn()
    {
        return Instantiate(prefab, transform.position, transform.rotation);
    }
}
