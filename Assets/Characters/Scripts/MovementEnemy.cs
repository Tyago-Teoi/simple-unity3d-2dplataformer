using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementEnemy : MonoBehaviour
{
    public Transform player;
    public Transform position1, position2;
    public Transform initialPosition;
    public float speed = 1f;

    private bool m_FacingRight = true;  

    private Vector3 nextPosition;


    void Start()
    {
        nextPosition = initialPosition.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position == position1.position)
        {
            nextPosition = position2.position;
            Flip();

        }
        if (transform.position == position2.position)
        {
            nextPosition = position1.position;
            Flip();
        }
        transform.position = Vector3.MoveTowards(transform.position, nextPosition, speed * Time.deltaTime);
    }

    private void Flip()
    {
        // Switch the way the player is labelled as facing.
        m_FacingRight = !m_FacingRight;

        // Multiply the player's x local scale by -1.
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {            
        }

    }
}
