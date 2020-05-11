using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spacespin : MonoBehaviour
{
    float rot=0;
    // public float RotateSpeed = 1.2f;

    // Update is called once per frame
    void Update()
    {
        rot += 0.1f * Time.deltaTime;
        RenderSettings.skybox.SetFloat("_Rotation_", rot);  
    }
}
