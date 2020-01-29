using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrRotator : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector4(0, 0, 45) * Time.deltaTime);
    }
}
