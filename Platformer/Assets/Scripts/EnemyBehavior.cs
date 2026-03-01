using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    private float speed = 2f;
    private float patrolRange = 1.5f;

    private Vector2 initialPosition;
    private int direction = 1;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        initialPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(speed * direction * Time.deltaTime, 0, 0);

        float distanceFromInitial = Vector2.Distance(transform.position, initialPosition);

        if (distanceFromInitial >= patrolRange)
        {
            direction *= -1; 
        }
    }
}
