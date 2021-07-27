using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collidable : MonoBehaviour
{
    private BoxCollider2D boxCollider2D;
    // Start is called before the first frame update
    void Start()
    {
        boxCollider2D = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    private void OnCollisionEnter(Collision collision)
    {
        if(collision!=null)
        {
            if(collision.collider.gameObject.tag=="Floor")
            {
                Debug.Log(collision.gameObject.tag);
            }
            else if(collision.gameObject.tag=="Fighter")
            {

            }
        }
    }

}
