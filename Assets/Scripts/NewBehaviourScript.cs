using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public Transform[] inicio;

    public GameObject pato;

    float timer;
    public float setTimer;

    void Start()
    {
        timer = setTimer;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
           int randomNumber = Random.Range(0, inicio.Length);
           Instantiate(pato, inicio[randomNumber].position, Quaternion.identity);
           timer = setTimer;
        }

    }

}