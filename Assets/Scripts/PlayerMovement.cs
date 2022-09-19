using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private PlayerDataSO playerData;

    private Vector2 moveDirection;
    private Vector3 screenBound;

    private void Start() 
    {
        screenBound = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 
                Camera.main.transform.position.z));
    }

    private void Update() 
    {
        moveDirection = CalculatedMovement();
        moveDirection.Normalize();

        transform.position = CalculatedScreenBound(moveDirection * playerData.GetMoverSpeed() * Time.deltaTime);

        if(moveDirection != Vector2.zero)
        {
            Quaternion toRotate = Quaternion.LookRotation(Vector3.forward, moveDirection);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotate, 1000 * Time.deltaTime);
        }
    }

    private Vector2 CalculatedMovement()
    {
        float valueX = InputManager.Instance.GetJoystickInput(playerData.GetPlayerType()).Horizontal;
        float valueY = InputManager.Instance.GetJoystickInput(playerData.GetPlayerType()).Vertical;

        return new Vector2(valueX, valueY);
    }

    private Vector2 CalculatedScreenBound(Vector3 movement)
    {
        float offsetX = spriteRenderer.bounds.size.x / 2;
        float offsetY = spriteRenderer.bounds.size.y / 2;

        if(playerData.IsGoalKeeper())
        {
            return GetClampedValue(movement, 
                                    playerData.goalKeeperBoundMinX, 
                                    playerData.goalKeeperBoundMaxX, 
                                    playerData.goalKeeperBoundMinY, 
                                    playerData.goalKeeperBoundMaxY
                                );
        }
        
        return GetClampedValue(movement, 
                            -screenBound.x + offsetX, 
                            screenBound.x - offsetX, 
                            -screenBound.y + offsetY, 
                            screenBound.y - offsetY
                        );
    }

    private Vector2 GetClampedValue(Vector3 movement, float minX, float maxX, float minY, float maxY)
    {
        float x = Mathf.Clamp(transform.position.x + movement.x, minX, maxX);
        float y = Mathf.Clamp(transform.position.y + movement.y, minY, maxY);

        return new Vector2(x, y);
    }

    private void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.gameObject.CompareTag("Ball"))
        {
            other.gameObject.GetComponent<Ball>().AddForce(moveDirection);
        }    
    }
}
