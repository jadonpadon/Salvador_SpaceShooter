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

    public float radarRadius;
    public int radarPoints;

    public float powerupRadius;
    public int numberOfPowerups;

    void Update()
    {
        PlayerMovement();
        
        if (Input.GetKey(KeyCode.R)) 
        {
            EnemyRadar(radarRadius, radarPoints);
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            SpawnPowerups(powerupRadius, numberOfPowerups);
        }    
    }

    void PlayerMovement()
    {
        float acceleration = maxSpeed / accelerationTime;
        float deceleration = maxSpeed / decelerationTime;

        if (speed > maxSpeed )
        {
            speed = maxSpeed;
        }

        Vector3 upVel = new Vector3(0, speed);
        Vector3 downVel = new Vector3(0, -speed);
        Vector3 leftVel = new Vector3(-speed, 0);
        Vector3 rightVel = new Vector3(speed, 0);

        if (Input.GetKey(KeyCode.UpArrow))
        {
            speed += acceleration * Time.deltaTime;
            transform.position += upVel * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            speed += acceleration * Time.deltaTime;
            transform.position += downVel * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            speed += acceleration * Time.deltaTime;
            transform.position += leftVel * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            speed += acceleration * Time.deltaTime;
            transform.position += rightVel * Time.deltaTime;
        }

        //Debug.Log(speed);
    }

    public void EnemyRadar(float radius, int circlePoints)
    {
        Color radarColor = Color.green;

        Vector3 playerToEnemy = (enemyTransform.position - transform.position);
        float distanceToEnemy = playerToEnemy.magnitude;

        if (distanceToEnemy <= radius)
        {
            radarColor = Color.red;
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
