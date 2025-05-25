using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pomberito : MonoBehaviour
{
    [SerializeField] private int life = 100;
    [SerializeField] private GlobalTimer tm;
    private bool enragePomberito;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!enragePomberito && tm.timeToFinish<=5)
        {
            enragePomberito = true;
            Debug.Log("Pomberito is enrage");
        }
    }
}
