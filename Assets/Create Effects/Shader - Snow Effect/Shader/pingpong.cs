using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pingpong : MonoBehaviour
{
    private Shader mat;
    void Start()
    {
        mat = GetComponent<Material>().shader;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float what;
        what = Mathf.PingPong(mat.FindPropertyIndex("_SnowLevel"), 1f);
    }
}
