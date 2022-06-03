using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCubeColor : MonoBehaviour
{
    public Material[] colorsAvailable = new Material[7];
    public CubeObject[] cubes;
    // Start is called before the first frame update
    void Start()
    {
        cubes = new CubeObject[0];
        cubes = GameObject.Find("Colored Cubes").GetComponentsInChildren<CubeObject>();
        print("Found " + cubes.Length + " Cubes");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
