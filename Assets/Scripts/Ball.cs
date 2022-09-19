using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private Rigidbody2D rb;
    private float timer;

    private void Start() 
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update() 
    {
        if(timer > 0)
        {
            timer -= Time.deltaTime;
            rb.drag += Time.deltaTime * 2f;
        }
    }

    public void AddForce(Vector3 moverDir)
    {
        timer = 5;
        rb.drag = 0;
        rb.AddForce(moverDir * 10f, ForceMode2D.Impulse);
    }
}
