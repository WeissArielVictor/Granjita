using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class T1 : MonoBehaviour
{
    private float n1=2;
    public float n2 = 3;

    // Start is called before the first frame update
    void Start()
    {
        float n3 = 4;
        float n4 = n1 * n2;

        Debug.Log("Resultado" + n4);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
