using System;
using UnityEngine;

public class Submarine : MonoBehaviour
{
    public float hAxis;
    public float vAxis;
    public float speed;
    public Vector3 harpoonArrowDegree;
    public GameObject harpoonArrow;
    public GameObject InsideGroup;

    public bool iDown;

    Rigidbody2D rigid;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        GetInput();
        Move();
        Inside();
    }

    void GetInput()
    {
        hAxis = Input.GetAxis("Horizontal");
        vAxis = Input.GetAxis("Vertical");
        iDown = Input.GetButtonDown("Inside");
    }

    void Move()
    {
        if (!GameManager.Instance.GetInsideMode())
        {
            if (hAxis != 0 || vAxis != 0)  // ����Ű�� ������ �̵��ϰ� �̵� �������� ����
            {
                rigid.velocity = new Vector3(hAxis, vAxis, 0) * speed;
                harpoonArrow.transform.rotation = Quaternion.Lerp(harpoonArrow.transform.rotation, Quaternion.Euler(harpoonArrowDegree), 1f * Time.deltaTime);
                harpoonArrowDegree = new Vector3(0, 0, (float)Math.Atan2(hAxis, -vAxis) / Mathf.Deg2Rad);
            }
            else  // ����Ű�� ������ ���� �� ���߰� ���� ������ ����
            {
                harpoonArrowDegree = harpoonArrow.transform.eulerAngles;
            }
        }
        else
        {
            rigid.velocity = Vector3.zero;
        }
    }

    void Inside()
    {
        if (iDown && !GameManager.Instance.GetInsideMode())
        {
            InsideGroup.SetActive(true);
            GameManager.Instance.SetInsideMode(true);
        }
        else if (iDown && GameManager.Instance.GetInsideMode())
        {
            InsideGroup.SetActive(false);
            GameManager.Instance.SetInsideMode(false);
        }
    }
}
