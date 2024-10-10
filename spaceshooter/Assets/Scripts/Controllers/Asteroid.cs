using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public float moveSpeed;
    public float arrivalDistance;
    public float maxFloatDistance;

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

        //Debug.Log(randomPoint);
    }

    private void ChooseNewtarget()
    {
        randomPoint = new Vector3(transform.position.x + Random.Range(-maxFloatDistance, maxFloatDistance),
            transform.position.y + Random.Range(-maxFloatDistance, maxFloatDistance), 0);
    }
}
