using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] public float speed;
    [SerializeField] public Transform TopWall;
    [SerializeField] public Transform BottomWall;
    [SerializeField] public new Rigidbody2D rigidbody2D;


    private bool tochingTopWall = false;
    private bool tochingBottomWall = false;
    private void FixedUpdate()
    {
        float x = Input.GetAxisRaw("Vertical");
        rigidbody2D.velocity = Vector2.up * speed * x;
        
        if (tochingTopWall)
        {
            if (Input.GetKey(KeyCode.W))
            {
                var position = transform.position;
                position.y = TopWall.position.y - transform.localScale.y / 2 - TopWall.transform.localScale.y / 2;
                transform.position = position;
            }
            else if (Input.GetKey(KeyCode.S))
            {
                tochingTopWall = !tochingTopWall;
            }
        }

        if (tochingBottomWall)
        {
            if (Input.GetKey(KeyCode.S))
            {
                var position = transform.position;
                position.y = BottomWall.position.y + transform.localScale.y / 2 + TopWall.transform.localScale.y / 2;
                transform.position = position;
            }
            else if (Input.GetKey(KeyCode.W))
            {
                tochingBottomWall = !tochingBottomWall;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        
        if (col.CompareTag("TopWall"))
        {
            tochingTopWall = !tochingTopWall;
        }
        else if (col.CompareTag("BottomWall"))
        {
            tochingBottomWall = !tochingBottomWall;
        }
    }
}
