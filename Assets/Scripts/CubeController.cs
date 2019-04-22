using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{
    private Camera pCamera = new Camera();

    // Start is called before the first frame update
    void Start()
    {
        pCamera = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
