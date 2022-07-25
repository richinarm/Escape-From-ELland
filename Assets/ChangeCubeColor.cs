using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ChangeCubeColor : MonoBehaviour
{
    public List<Material> colorsAvailable = new List<Material>();
    public CubeObject[] cubes;
    public string colorToFind;
    public TextMeshProUGUI objectivesText;
    public TextMeshProUGUI successfailureText;
    // Start is called before the first frame update
    void Start()
    {
        cubes = new CubeObject[0];
        cubes = GameObject.Find("Colored Cubes").GetComponentsInChildren<CubeObject>();
        objectivesText = GameObject.Find("Canvas").transform.Find("Objective Text").GetComponent<TextMeshProUGUI>();
        successfailureText = GameObject.Find("Canvas").transform.Find("Success Failure Text").GetComponent<TextMeshProUGUI>();
        setCubeColor();


    }

    // Update is called once per frame
    public void setCubeColor()
    {
        var listCopy = new List<Material>(colorsAvailable);
        var listToTagColor = new List<Material>();
        print("BEFORE: " + listCopy.Count);

        for (int i = 0; i < cubes.Length; i++)
        {
            var randomNumber = Random.Range(0, listCopy.Count);
            //print(listCopy[randomNumber].name);
            cubes[i].GetComponent<Renderer>().material = listCopy[randomNumber];
            listToTagColor.Add(listCopy[randomNumber]);
            listCopy.RemoveAt(randomNumber);
            
        }
        print("AFTER: " + listToTagColor.Count);

        int randnum = Random.Range(0, listToTagColor.Count);
        objectivesText.text = "Find the color: " + listToTagColor[randnum].name;
        //print("Find the color: " + listToTagColor[randnum].name);
        colorToFind = listToTagColor[randnum].name;

    }


  
}
