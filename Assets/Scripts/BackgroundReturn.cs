using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundReturn : MonoBehaviour {
    private Vector3 startPosition;
    private float semiLongitud = 112.8f/2;

    void Start() {
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update() {
        if(startPosition.x - transform.position.x > semiLongitud) {
            transform.position = transform.position + Vector3.right * semiLongitud;
        }        
    }
}
