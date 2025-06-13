using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LuzMala : MonoBehaviour
{
    public Transform pointA;
    public Transform pointB;
    public float speed = 2f;
    private Transform currentTarget;

    // Start is called before the first frame update
    void Start()
    {
        currentTarget = pointA;    
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(transform.position, currentTarget.position);
        if(distance<0.1f)
        {
            if(currentTarget==pointA)
            {
                currentTarget = pointB;
            }
            else
            {
                currentTarget = pointA;
            }
        }
        Vector3 direction = (currentTarget.position - transform.position).normalized;
        transform.Translate(direction * speed * Time.deltaTime);
    }
}
