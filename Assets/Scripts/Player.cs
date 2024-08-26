using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    public float hAxis;
    public float vAxis;

    public bool onLadder;
    public bool isLadder;

    public Vector3 moveVec;

    Rigidbody2D rigid;
    CapsuleCollider2D capsuleCollider;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        capsuleCollider = GetComponent<CapsuleCollider2D>();
    }

    void Update()
    {
        GetInput();
        Move();
        Inside();
        Ladder();
    }

    void FixedUpdate()
    {
        
    }

    void GetInput()
    {
        hAxis = Input.GetAxisRaw("Horizontal");
        vAxis = Input.GetAxisRaw("Vertical");
    }

    void Move()
    {
        if(GameManager.Instance.GetInsideMode())
        {
            if (!isLadder)
            {
                moveVec = new Vector3(hAxis, 0, 0).normalized;
                transform.position += moveVec * speed * Time.deltaTime;
            }
            else
            {
                if (hAxis != 0)
                {
                    isLadder = false;
                }
                moveVec = new Vector3(0, vAxis, 0).normalized;
                transform.position += moveVec * speed * Time.deltaTime;
            }
        }
    }

    void Ladder()
    {
        if(onLadder && vAxis != 0)
        {
            isLadder = true;
        }
    }

    void Inside()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ladder")
        {
            onLadder = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ladder")
        {
            onLadder = false;
        }
    }
}
