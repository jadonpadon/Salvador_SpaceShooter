using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class Bomb : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        moveBomb(5f);

        Destroy(gameObject, 5f);
    }

    void moveBomb(float speed)
    {
        Vector3 bombSpeed = new Vector3(0,  speed, 0);
        transform.position += bombSpeed * Time.deltaTime;

        if (bombSpeed.y > speed)
        {
            bombSpeed.y = speed;
        }
        if (bombSpeed.y < -speed)
        {
            bombSpeed.y = -speed;
        }
    }

}
