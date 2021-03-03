using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hitboxcreate : MonoBehaviour
{
    public GameObject hitbox;

    void Start()
    {
        
    }
    
    void Update()
    {
        
    }
    public void Active_hitbox()
    {
        hitbox.SetActive(true);
    }
    public void Deactive_hitbox()
    {
        hitbox.SetActive(false);
    }
}
