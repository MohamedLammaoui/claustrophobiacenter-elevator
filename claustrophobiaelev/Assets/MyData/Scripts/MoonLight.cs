using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoonLight : MonoBehaviour
{
    public int lightFactor = 0;

    public Light controlledLight01 = null;
    // Start is called before the first frame update
    void Start()
    {   
    }

    // Update is called once per frame
    void Update()
    {
        if(controlledLight01!=null) { // If we have a light as a field
             Light l = controlledLight01.GetComponent<Light>(); // Get the Light component
             Color c = new Color();
             c.r= 1f - lightFactor / 100f;
             c.g= lightFactor / 100f;
            //  c.b= lightFactor / 100f;
             c.a=1f;
             l.color = c;
    }
}
}
