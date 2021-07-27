using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    public SpriteRenderer Player_sprite;
    private BoxCollider2D On_collide;
   
    private Vector3 Vector;
    protected virtual void  Start()
    {
        Player_sprite= GetComponent<SpriteRenderer>();
        On_collide = GetComponent<BoxCollider2D>();
        
    }

    // Update is called once per frame
    protected virtual void  Update_mover(Vector3 Input)
    {
        Vector = new Vector3(Input.x, Input.y, 0);
        if(Vector.x==-1)
        {
            transform.localScale = new Vector3(-1,1,1);
        }
        else if(Vector.x==1)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        transform.Translate(Vector);

    }
}
