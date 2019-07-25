using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugDrawPlane : MonoBehaviour
{
    public bool Enabled = true;
    public Color DebugPlaneColor = Color.blue;
    public bool IsWireframe = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnDrawGizmos()
    {
        if(!Enabled)
            return;
        // Draw a yellow sphere at the transform's position
        Gizmos.color = DebugPlaneColor;
        Gizmos.DrawWireCube(this.transform.position + Vector3.up * 0.5f, Vector3.one);

        if(IsWireframe)
            Gizmos.DrawWireCube(this.transform.position, new Vector3(1f, 0f, 1f));
        else
            Gizmos.DrawCube(this.transform.position, new Vector3(1f, 0f, 1f));
    }
}
