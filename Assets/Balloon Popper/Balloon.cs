using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balloon : MonoBehaviour
{
    public int points = 1;
    public int health = 5;
    public float scaleIncreasePerClick = 0.1f;

    public float gravity;
    Rigidbody rb;

    public ScoreManager scoreManager;

    void Awake() {
        rb = GetComponent<Rigidbody>();
        gravity = Random.Range(0.15f, 0.3f);
    }

    void FixedUpdate() {
        rb.AddForce(0, 0.2f, 0, ForceMode.Impulse);
    }

    void OnMouseDown() {
        health -= 1;

        transform.localScale += Vector3.one * scaleIncreasePerClick;

        if (health == 0)
        {
            scoreManager.increaseScore(points);
            Destroy(gameObject);
        }
    }
    
}
