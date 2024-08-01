using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscilator : MonoBehaviour
{

     Vector3 startingPos;
    [SerializeField] Vector3 movementVec;
    [SerializeField] [Range(0,1)] float movementFac;
    

    void Start()
    {
        startingPos = transform.position;
    }

    void Update()
    {
        Vector3 offset = movementVec * movementFac;
        transform.position = startingPos + offset;
    }
}
