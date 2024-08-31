using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    public float hAxis;
    public float vAxis;

    public bool onLadder;
    public bool onDoor;
    public bool isLadder;
    public bool eDown;

    public GameObject Room1Group;

    public Vector3 DoorVec;
    public Vector3 ladderVec;
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
        Ladder();
        Door();
    }

    void FixedUpdate()
    {
        
    }

    void GetInput()
    {
        hAxis = Input.GetAxisRaw("Horizontal");
        vAxis = Input.GetAxisRaw("Vertical");
        eDown = Input.GetButtonDown("Interaction");
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
        if(onLadder && eDown)
        {
            isLadder = true;
            transform.position = new Vector3(ladderVec.x, transform.position.y, transform.position.z);
        }
        else if(!onLadder)
        {
            isLadder= false;
        }
    }

    void Door()
    {
        if (onDoor && eDown)
        {
            Room1Group.SetActive(true);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ladder")
        {
            onLadder = true;
            ladderVec = collision.gameObject.transform.position;
        }
        else if (collision.gameObject.tag == "Door")
        {
            onDoor = true;
            DoorVec = collision.gameObject.transform.position;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ladder")
        {
            onLadder = false;
        }
        else if (collision.gameObject.tag == "Door")
        {
            onDoor = false;
        }
    }
}
