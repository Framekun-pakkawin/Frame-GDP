using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destorycloneobj : MonoBehaviour
{
    public int countdown = 120;
    void Start()
    {
        
    }
    void Update()
    {
        if (countdown <= 0)
        {
            Destroy(gameObject);
        }
    }
    private void FixedUpdate()
    {
        if (countdown > 0)
        {
            countdown -= 1;
        }
    }
    public void DestoryGameObj()
    {
        Destroy(gameObject);
    }
    
}
