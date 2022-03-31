using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class CSVWriter : MonoBehaviour
{
    public Text location;
    public Text data;
    private TextWriter tw;
    private string filename;
    private bool dataCollectionStarted = false;

    private void Start() {
        // make sure the application uses american decimals '.'
        System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");

        InputSystem.EnableDevice(AttitudeSensor.current);


        filename = Application.persistentDataPath + "/unityCSVtest.csv";
        tw = new StreamWriter(filename, false);
        tw.WriteLine("x,y,z");
        tw.Close();
    }


    private void Update() {
        location.text = filename;

        if (AttitudeSensor.current.enabled && dataCollectionStarted)
        {
            SaveSensorData();
        }
    }

    public void ButtonPress()
    {
        dataCollectionStarted = !dataCollectionStarted;
    }



    private void SaveSensorData()
    {
        Quaternion sensorData = GyroAxisConvert(AttitudeSensor.current.attitude.ReadValue());
        data.text = sensorData.ToString();

        tw = new StreamWriter(filename, true);
        tw.WriteLine(sensorData.x + "," + sensorData.y + "," + sensorData.z);
        tw.Close();
    }

    private Quaternion GyroAxisConvert(Quaternion q)
    {
        return new Quaternion(q.x, q.z, q.y, -q.w);
    }
}
