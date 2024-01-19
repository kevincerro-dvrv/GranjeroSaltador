using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundReturn : MonoBehaviour
{
    private Vector3 startPosition;

    private float middleLong = 112.8f / 2;

    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;   
    }

    // Update is called once per frame
    void Update()
    {
        if ((startPosition.x - transform.position.x) > middleLong) {
            transform.position = transform.position + Vector3.right * middleLong;
        }
    }
}
