using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoviment : MonoBehaviour
{
    public GameObject player;
    public CharacterController2D controller;
    public float runSpeed = 40f;

    float horizontalMove = 0f;

    bool jump = false;
    bool crouch = false;

    public Transform respawnPoint;
    public EdgeCollider2D enemyWeapon;


    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;        

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
        }

        if (Input.GetButtonDown("Crouch"))
        {
            Debug.Log(Input.GetButtonDown("Crouch"));
            crouch = true;
        } else if (Input.GetButtonUp("Crouch"))
        {
            Debug.Log(Input.GetButtonDown("Crouch"));
            crouch = false;
        }
    }

    void FixedUpdate()
    {
        // Move the character in a fixed period of time
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
    }
    /*
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Platform"))
        {
            this.transform.parent = other.transform;
        }
    }

    void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Platform"))
        {
            this.transform.parent = null;
        }
    }
    */
    
    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Platform"))
        {
            player.transform.parent = other.transform;
            //other.GetComponent<Collider>().transform.SetParent(transform);
        }
        else if (other.collider == enemyWeapon)
        {
            player.transform.position = respawnPoint.transform.position;
        }

    }    
    
    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Platform"))
        {
            player.transform.parent = null;
        }
    }
    
}
