using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class Spirit_Behavior : MonoBehaviour
{
    public Transform target;
    public float speed = 200f;
    public float nextWaypointDistance = 3f;
    public Transform enemy;
    Path path;
    int currentWaypoint = 0;
    bool reachedEndOfPath = true;
    Seeker seeker;
    Rigidbody2D rb;
    Transform starttranform;
    void Start()
    {
        starttranform = gameObject.transform;
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();

        InvokeRepeating("UpdatePath", 0f, 1f);
        
    }

    void UpdatePath()
    {
        if (seeker.IsDone()) 
            seeker.StartPath(rb.position, target.position, OnPathComplete);
    }

    void OnPathComplete(Path p)
    {
        if (!p.error)
        {
            path = p;
            currentWaypoint = 0;
        }
    }

    void FixedUpdate()
    {
        if (path == null)
            return;

        if(currentWaypoint >= path.vectorPath.Count)
        {
            reachedEndOfPath = true;
            return;
        }
        else
        {
            reachedEndOfPath = false;
        }
        
            Vector2 direction = ((Vector2)path.vectorPath[currentWaypoint] - rb.position).normalized;
            Vector2 force = direction * speed * Time.deltaTime;

            rb.AddForce(force);
        
        
            transform.position = Vector2.MoveTowards(transform.position, starttranform.position, speed * Time.deltaTime);
        
            float distance = Vector2.Distance(rb.position, path.vectorPath[currentWaypoint]);
       

        if (distance < nextWaypointDistance)
        {
            currentWaypoint++;
        }

        if (rb.velocity.x >= 0.01f)
        {
            enemy.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
        }
        else if (rb.velocity.x <= -0.01f)
        {
            enemy.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        }
    }
}
