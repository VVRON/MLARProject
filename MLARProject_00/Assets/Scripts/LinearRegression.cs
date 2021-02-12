﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LinearRegression : MonoBehaviour
{
    public TextMeshProUGUI textDatasetObject;
    List<double> yearValues = new List<double>();
    List<double> quantityValues = new List<double>();

    void Start()
    {
        TextAsset csvdata = Resources.Load<TextAsset>("dataset");

        string[] data = csvdata.text.Split(new char[] { '\n' });
        textDatasetObject.text = "Year Quantity";

        for (int i = 1; i < data.Length - 1; i++)
        {
            string[] row = data[i].Split(new char[] { ',' });

            if (row[1] != "")
            {
                DataInterface item = new DataInterface();

                int.TryParse(row[0], out item.year);
                int.TryParse(row[1], out item.quantity);

                yearValues.Add(item.year);
                quantityValues.Add(item.quantity);
                textDatasetObject.text += "\n" + item.year + " " + item.quantity;


            }
        }
    }
}