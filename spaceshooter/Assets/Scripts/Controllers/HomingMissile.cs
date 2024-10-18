using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class HomingMissile : MonoBehaviour
{
    public Transform enemy;
    public GameObject enemyObject;
    public float speed;
    public float rotateSpeed;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector2 direction = (enemy.position - transform.position).normalized;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
        float step = rotateSpeed * Time.deltaTime;

        Quaternion targetRotation = Quaternion.Euler(0, 0, angle);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, step);

        transform.Translate(Vector2.up * speed * Time.deltaTime);

        float distance = Vector3.Distance(transform.position, enemy.transform.position);
        if (distance < 0.75f)
        {
            Destroy(enemyObject);
            Destroy(gameObject);
        }
    }
}
