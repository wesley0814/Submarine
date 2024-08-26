using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance = null;

    public GameObject submarine;

    public bool isInsideMode = false;

    public float depth;

    void Awake()
    {
        if (null == instance)
        {
            instance = this;
        }
    }

    public static GameManager Instance
    {
        get
        {
            if(null == instance)
            {
                return null;
            }
            return instance;
        }
    }

    void Update()
    {
        Depth();
    }

    public bool GetInsideMode()
    {
        return isInsideMode;
    }

    public void SetInsideMode(bool b)
    {
        isInsideMode = b;
    }

    void Depth()
    {
        depth = -submarine.transform.position.y;
    }
}
