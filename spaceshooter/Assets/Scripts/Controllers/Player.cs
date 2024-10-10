using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public List<Transform> asteroidTransforms;
    public Transform enemyTransform;
    public GameObject bombPrefab;
    public Transform bombsTransform;

    public float maxSpeed;
    public float accelerationTime;
    public float decelerationTime;
    float speed;

    void Update()
    {
        PlayerMovement();
    }

    void PlayerMovement()
    {
        float acceleration = maxSpeed / accelerationTime;
        float deceleration = maxSpeed / decelerationTime;

        Vector3 movementDirection = Vector3.zero;

        if (speed > maxSpeed )
        {
            speed = maxSpeed;
        }
        if (speed < 0)
        {
            speed = 0;
        }

        Vector3 upVel = new Vector3(0, speed);
        Vector3 downVel = new Vector3(0, -speed);
        Vector3 leftVel = new Vector3(-speed, 0);
        Vector3 rightVel = new Vector3(speed, 0);

        if (Input.GetKey(KeyCode.UpArrow))
        {
            speed += acceleration * Time.deltaTime;
            movementDirection = Vector3.up;
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            speed += acceleration * Time.deltaTime;
            movementDirection = Vector3.down;
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            speed += acceleration * Time.deltaTime;
            movementDirection = Vector3.left;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            speed += acceleration * Time.deltaTime;
            movementDirection = Vector3.right;
        }
        else
        {
            speed -= decelerationTime * Time.deltaTime;
        }


        if (speed > 0)
        {
            transform.position += movementDirection * speed * Time.deltaTime;

            Debug.Log("Transform Position: " + transform.position);
            Debug.Log("Speed: " + speed);
            Debug.Log("Movement Direction: " + movementDirection);
        }

        //Debug.Log(speed);
    }

}
