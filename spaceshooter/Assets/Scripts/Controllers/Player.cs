using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public List<Transform> asteroidTransforms;
    public Transform enemyTransform;
    public GameObject bombPrefab;
    public Transform bombsTransform;
    public GameObject powerupPrefab;

    public float maxSpeed;
    public float accelerationTime;
    public float decelerationTime;
    float speed;
    Vector3 lastDirection = Vector3.zero;


    public float radarRadius;
    public int radarPoints;

    public float powerupRadius;
    public int numberOfPowerups;

    public GameObject missile;

    bool hasRun = false;

    void Update()
    {
        PlayerMovement();

        if (Input.GetKeyDown(KeyCode.B))
        {
            ShootBomb();
        }
        
        if (Input.GetKey(KeyCode.R)) 
        {
            EnemyRadar(radarRadius, radarPoints);
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            SpawnPowerups(powerupRadius, numberOfPowerups);
        }    
    }

    void ShootHomingMissile()
    {
        Instantiate(missile, transform.position, Quaternion.identity);
        hasRun = true;
    }

    void ShootBomb()
    {
        Instantiate(bombPrefab, transform.position, Quaternion.identity, bombsTransform);
    }

    void PlayerMovement()
    {
        float acceleration = maxSpeed / accelerationTime;
        float deceleration = maxSpeed / decelerationTime;

        if (speed > maxSpeed )
        {
            speed = maxSpeed;
        }

        Vector3 upVel = new Vector3(0, 1);
        Vector3 downVel = new Vector3(0, -1);
        Vector3 leftVel = new Vector3(-1, 0);
        Vector3 rightVel = new Vector3(1, 0);

        bool isMoving = false;

        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            speed += acceleration * Time.deltaTime;
            transform.position += upVel * speed * Time.deltaTime;
            lastDirection = upVel;
            isMoving = true;
        }
        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            speed += acceleration * Time.deltaTime;
            transform.position += downVel * speed * Time.deltaTime;
            lastDirection = downVel;
            isMoving = true;
        }
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            speed += acceleration * Time.deltaTime;
            transform.position += leftVel * speed * Time.deltaTime;
            lastDirection = leftVel;
            isMoving = true;
        }
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            speed += acceleration * Time.deltaTime;
            transform.position += rightVel * speed * Time.deltaTime;
            lastDirection = rightVel;
            isMoving = true;
        }
        if (!isMoving && speed > 0)
        {
            speed -= deceleration * Time.deltaTime;
            if (speed < 0) speed = 0;

            transform.position += lastDirection * speed * Time.deltaTime;
        }

    }

    public void EnemyRadar(float radius, int circlePoints)
    {
        Color radarColor = Color.green;

        Vector3 playerToEnemy = (enemyTransform.position - transform.position);
        float distanceToEnemy = playerToEnemy.magnitude;

        if (distanceToEnemy <= radius)
        {
            radarColor = Color.red;

            if (hasRun == false)
            {
                ShootHomingMissile();
            }
            
        }
        else
        {
            hasRun = false;
        }

        float angle = 360f / circlePoints;

        Vector3 firstPoint = Vector3.zero;
        Vector3 previousPoint = Vector3.zero;

        for (int i = 0; i < circlePoints; i++)
        {
            float currentAngle = i * angle * Mathf.Deg2Rad;

            Vector3 currentPoint = new Vector3(transform.position.x + Mathf.Cos(currentAngle) * radius, transform.position.y + Mathf.Sin(currentAngle) * radius);

            if (i > 0)
            {
                Debug.DrawLine(previousPoint, currentPoint, radarColor);
            }
            else
            {
                firstPoint = currentPoint;
            }

            previousPoint = currentPoint;
        }

        Debug.DrawLine(previousPoint, firstPoint, radarColor);
    }

    public void SpawnPowerups (float radius, int numberOfPowerups)
    {
        float angle = 360f / numberOfPowerups;

        Vector3 firstPoint = Vector3.zero;
        Vector3 previousPoint = Vector3.zero;

        for (int i = 0; i < numberOfPowerups; i++)
        {
            float currentAngle = i * angle * Mathf.Deg2Rad;

            Vector3 currentPoint = new Vector3(transform.position.x + Mathf.Cos(currentAngle) * radius, transform.position.y + Mathf.Sin(currentAngle) * radius);

            if (i > 0)
            {
                Instantiate(powerupPrefab, currentPoint, Quaternion.identity);
            }
            else
            {
                firstPoint = currentPoint;
            }

            previousPoint = currentPoint;
        }
        Instantiate(powerupPrefab, firstPoint, Quaternion.identity);

    }

}
