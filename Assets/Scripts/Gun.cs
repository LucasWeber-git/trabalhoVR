using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    private Vector2 turn;
    public float speed = 1f;
    public int rotation = 5;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            turn.y = turn.y >= 90 ? 90 : turn.y += rotation;
            transform.localRotation = Quaternion.Euler(-turn.y, turn.x, 0);
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            Debug.Log(turn.y);
            turn.y = turn.y <= -90 ? -90 : turn.y -= rotation;
            transform.localRotation = Quaternion.Euler(-turn.y, turn.x, 0);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            turn.x = turn.x == 360 ? 0 : turn.x += rotation;
            transform.localRotation = Quaternion.Euler(-turn.y, turn.x, 0);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            turn.x = turn.x == 360 ? 0 : turn.x -= rotation;
            transform.localRotation = Quaternion.Euler(-turn.y, turn.x, 0);
        }
    }
}
