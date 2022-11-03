using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pato2 : MonoBehaviour
{
    Vector3 teste;
    public float a, b, c, d;
    float x,z;
    public float speed;
    void Start()
    {
        Destroy(this.gameObject,7);
        x = Random.Range(a, b);
        z = Random.Range(c, d);
        teste.Set(x, 30, z);
    }

    // Update is called once per frame
    void Update()
    { 
        transform.Translate(teste * speed * Time.deltaTime);
    }
}
