using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moonspin : MonoBehaviour
{
    float timeCounter = 0;

    float speed;
    float width;
    float height;
    // Start is called before the first frame update
    void Start()
    {
        speed = 0.07f; // 0.07f
        width = 100;
        height = 30;  
        // transform.position = new Vector3 (-112.7f, 36.4f, 18.8f);
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0f, 0.5f, 0f);
        timeCounter += Time.deltaTime*speed;
        
        float x = Mathf.Cos (timeCounter)*width;
        float y = Mathf.Sin (timeCounter)*height;
        float z = 22.5f;

        transform.position = new Vector3 (x,y,z);
    }
}
