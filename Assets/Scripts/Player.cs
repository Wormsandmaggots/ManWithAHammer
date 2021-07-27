using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Collidable
{
    // Start is called before the first frame updat
    public Vector2 speed;
    public Animator animation;
    private Rigidbody2D rigidbody2D;
    public Vector2 jump_vector;
    private BoxCollider2D boxCollider2D;
    public float attack_cooldown;
    public float Hp_max;
    private float Hp_current;
    protected void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        boxCollider2D = GetComponent<BoxCollider2D>();
        Hp_current = Hp_max;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        float x = Input.GetAxisRaw("Horizontal");
        // float y = Input.GetAxisRaw("Vertical");
        Vector3 movement = new Vector3(speed.x * x, 0, 0);
        Vector3 temp = movement;
        if (x == -1)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (x == 1)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        movement *= Time.deltaTime;
        rigidbody2D.SetRotation(0);
        Walking(movement, temp, animation);
        Jump(animation, rigidbody2D,jump_vector,boxCollider2D);
        Attack(animation);
        transform.Translate(movement);
    }
    private void Walking(Vector3 movement, Vector3 temp, Animator animation)
    {
        animation.SetBool("Falling", false);
        if (movement.x != temp.x)
        {
            animation.SetBool("Not_walking", false);
            animation.SetTrigger("Walking");

        }
        else
        {
            animation.SetBool("Walking", false);
            animation.SetTrigger("Not_walking");
        }

    }
    private void Jump(Animator animation, Rigidbody2D rigidbody2D, Vector2 jump_vector, BoxCollider2D boxCollider2D)
    {
        Vector2 current_vector = new Vector2(0, 0);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rigidbody2D.AddForce(jump_vector, ForceMode2D.Force);
            animation.SetTrigger("Jump");
        }
        else if(rigidbody2D.GetVector(current_vector).y<0)
        {
            Falling(animation,rigidbody2D);
        }

    }

    private void Falling(Animator animation, Rigidbody2D rigidbody2D)
    {
        animation.SetBool("Jump", false);
        animation.SetTrigger("Falling");
        if (rigidbody2D.gameObject.tag == "Floor")
            animation.SetBool("Falling", false);
    } 

    private void Attack(Animator animation)
    {
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            animation.SetTrigger("Attack");
        }
    }
    private void Death(Animator animation)
    {
        if(Hp_current==0)
        {
            animation.SetTrigger("Death");
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision != null)
        {
            if (collision.collider.gameObject.tag == "Floor")
            {
                Debug.Log(collision.gameObject.tag);
            }
            else if (collision.gameObject.tag == "Fighter")
            {

            }
        }
    }
}
