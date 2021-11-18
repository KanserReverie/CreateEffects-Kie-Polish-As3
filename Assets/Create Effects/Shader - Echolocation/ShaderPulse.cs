using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShaderPulse : MonoBehaviour
{
    // This will get the material.
    public Material echolocationMaterial;

    private float radius;
    private float timeTime;

    [SerializeField] private float decellerationDuration = 16;
    [SerializeField] private float startSpeed = 24f;
    [SerializeField] private float endSpeed = 11f;
    private float pulseSpeedCurrent;

    // Start is called before the first frame update
    void Start()
    {
        //echolocationMaterial = GetComponent<MeshRenderer>().materials[0];
        radius = 0;
        pulseSpeedCurrent = startSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        // Will update the "_Radius" variable in shader.
        echolocationMaterial.SetFloat("_Radius", radius);
        radius += Time.deltaTime * pulseSpeedCurrent;
        
        pulseSpeedCurrent = Mathf.Lerp(startSpeed, endSpeed, timeTime / decellerationDuration);

        timeTime += Time.deltaTime;
    }

    public void ResetRadius()
    {
        radius = 0;
        pulseSpeedCurrent = startSpeed;
        timeTime = 0;
    }
}
