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
            transform.position += upVel *Time.deltaTime;
        }
        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            speed -= decelerationTime * Time.deltaTime;
            transform.position += upVel * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            speed += acceleration * Time.deltaTime;
            transform.position += downVel * Time.deltaTime;
        }
        if(Input.GetKeyUp(KeyCode.DownArrow))
        {
            speed -= decelerationTime * Time.deltaTime;
            transform.position += downVel * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            speed += acceleration * Time.deltaTime;
            transform.position += leftVel * Time.deltaTime;
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            speed -= decelerationTime * Time.deltaTime;
            transform.position += leftVel * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            speed += acceleration * Time.deltaTime;
            transform.position += rightVel * Time.deltaTime;
        }
        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            speed -= decelerationTime * Time.deltaTime;
            transform.position += rightVel * Time.deltaTime;
        }

        Debug.Log(speed);
    }

}
