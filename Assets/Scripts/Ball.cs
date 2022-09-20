using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private Rigidbody2D rb;
    private float timer;
    private Vector3 initialPosition;
    private Quaternion initialRotation;

    private void Start() 
    {
        GoalPost.OnGoal += ResetPosition;

        rb = GetComponent<Rigidbody2D>();

        initialPosition = transform.position;
        initialRotation = transform.rotation;
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
        rb.AddForce(moverDir * 15f, ForceMode2D.Impulse);
    }

    private void ResetPosition(PlayerType playerType)
    {
        StartCoroutine(ResetPositionDelay());
    }

    private IEnumerator ResetPositionDelay()
    {
        yield return new WaitForSeconds(2f);

        rb.velocity = Vector2.zero;
        transform.position = initialPosition;
        transform.rotation = initialRotation;
    }
}
