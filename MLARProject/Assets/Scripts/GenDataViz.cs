using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GenDataViz : MonoBehaviour
{
    int scaleSize = 100;
    int scaleSizeFactor = 10;
    public GameObject graphContainer;
    int binDistance = 13;
    float offset = 0;

    void Start()
    {
        CreateGraph();
    }

    public void ClearChilds(Transform parent)
    {
        offset = 0;
        foreach (Transform child in parent)
        {
            Destroy(child.gameObject);
        }
    }

    public void DecreaseSize()
    {
        scaleSize += scaleSizeFactor;
        CreateGraph();
    }

    public void IncreaseeSize()
    {
        scaleSize -= scaleSizeFactor;
        CreateGraph();
    }

    public void CreateGraph()
    {
        Debug.Log("creating the graph");
        ClearChilds(graphContainer.transform);
        for (var i = 0; i < LinearRegression.quantityValues.Count; i++)
        {
            createBin(10, (float)LinearRegression.quantityValues[i] / scaleSize, 10, offset, ((float)LinearRegression.quantityValues[i] / scaleSize) / 2, graphContainer);
            offset += binDistance;
        }
    }

    void createBin(float Scale_x, float Scale_y, float Scale_z, float Padding_x, float Padding_y, GameObject _parent)
    {
        GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube.transform.SetParent(_parent.transform, true);
        cube.transform.position = new Vector3(Padding_x, Padding_y - 100, 400);

        cube.GetComponent<MeshRenderer>().material.color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);

        Vector3 scale = new Vector3(Scale_x, Scale_y, Scale_z);

        cube.transform.localScale = scale;
    }
    void Update()
    {
        
    }
}
