using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public float moveSpeed;
    public float arrivalDistance;
    public float maxFloatDistance;

    public GameObject miniAsteroid;
    public int numberOfDebris;
    public float debrisRadius;
    public float debrisTimer;

    Vector3 randomPoint;

    // Start is called before the first frame update
    void Start()
    {
        ChooseNewtarget();
    }

    // Update is called once per frame
    void Update()
    {
        AsteroidMovement();

        Bomb[] bombs = FindObjectsOfType<Bomb>();
        foreach (Bomb bomb in bombs)
        {
            float distance =  Vector3.Distance(transform.position, bomb.transform.position);
            if (distance <= 0.5f)
            {
                Explode();
                Destroy(gameObject); 
            }
        }

    }

    public void Explode()
    {
        float angle = 360f / numberOfDebris;
        Vector3 scale = transform.localScale / 3;

        Vector3 firstPoint = Vector3.zero;
        Vector3 previousPoint = Vector3.zero;

        for (int i = 0; i < numberOfDebris; i++)
        {
            float currentAngle = i * angle * Mathf.Deg2Rad;

            Vector3 currentPoint = new Vector3(transform.position.x + Mathf.Cos(currentAngle) * debrisRadius, transform.position.y + Mathf.Sin(currentAngle) * debrisRadius);

            if (i > 0)
            {
                GameObject debris = Instantiate(miniAsteroid, currentPoint, Quaternion.identity);
                debris.transform.localScale = scale;

                Destroy(debris, debrisTimer);
            }
            else
            {
                firstPoint = currentPoint;
            }

            previousPoint = currentPoint;
        }

        GameObject debris2 = Instantiate(miniAsteroid, firstPoint, Quaternion.identity);
        debris2.transform.localScale = scale;

        Destroy(debris2, debrisTimer);
    }

    public void AsteroidMovement()
    {
        Vector3 direction = (randomPoint - transform.position).normalized;
        float distance = (randomPoint - transform.position).magnitude;
        Vector3 move = direction * moveSpeed * Time.deltaTime;

        if (distance <= arrivalDistance)
        {
            ChooseNewtarget();
        }
        else
        {
           transform.position += move;
        }
    }

    private void ChooseNewtarget()
    {
        randomPoint = new Vector3(transform.position.x + Random.Range(-maxFloatDistance, maxFloatDistance),
            transform.position.y + Random.Range(-maxFloatDistance, maxFloatDistance), 0);
    }
}
