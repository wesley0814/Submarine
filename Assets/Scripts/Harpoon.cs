using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Harpoon : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D c)
    {
        if(c.gameObject.tag == "Chest")
        {
            Debug.Log("Chest");
            Destroy(gameObject, 0.5f);
        }
        else if (c.gameObject.tag == "Wall")
        {
            Debug.Log("Wall");
            Destroy(gameObject, 0.5f);
        }
    }
}
