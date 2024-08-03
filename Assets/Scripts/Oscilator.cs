using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscilator : MonoBehaviour
{

     Vector3 startingPos;
    [SerializeField] Vector3 movementVec;
    float movementFac;
    [SerializeField] float period = 2f;
    

    void Start()
    {
        startingPos = transform.position;
    }

    void Update()
    {
        if(period <= Mathf.Epsilon) { return; }

        float cycles = Time.time / period;

        const float tau = Mathf.PI * 2;
        float rawSinWave = Mathf.Sin(cycles * tau);

        movementFac = (rawSinWave + 1f) / 2f;

        Vector3 offset = movementVec * movementFac;
        transform.position = startingPos + offset;
    }
}
