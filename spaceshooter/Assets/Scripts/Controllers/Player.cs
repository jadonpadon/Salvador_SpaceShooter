using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public List<Transform> asteroidTransforms;
    public Transform enemyTransform;
    public GameObject bombPrefab;
    public Transform bombsTransform;

    void Update()
    {
        PlayerMovement();
    }

    void PlayerMovement()
    {
        Vector3 upVel = new Vector3(0, 1);
        Vector3 downVel = new Vector3(0, -1);
        Vector3 leftVel = new Vector3(-1, 0);
        Vector3 rightVel = new Vector3(1, 0);

        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.position += upVel *Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.position += downVel * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position += leftVel * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += rightVel * Time.deltaTime;
        }
    }

}
