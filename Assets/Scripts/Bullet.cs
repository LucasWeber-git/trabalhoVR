using System;
using TMPro;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Duck"))
        {
            Destroy(collision.gameObject);
            UpdateScore();
        }
    }

    private void UpdateScore()
    {
        GameObject score = GameObject.FindGameObjectWithTag("Score");
        TextMeshProUGUI textMesh = score.GetComponent<TextMeshProUGUI>();
        
        int currentScore = Int32.Parse(textMesh.text);
        textMesh.text = (currentScore + 1).ToString();
    }

}
