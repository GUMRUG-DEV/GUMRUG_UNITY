using System.Collections;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections.Generic;
using UnityEngine;
public class Saving : MonoBehaviour {

    public List<int> list1 = new List<int>();

    private savedata data;

    public Vector2 xy = new Vector2();


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Save()
    {
        if (!Directory.Exists(Application.dataPath + "/saves"))
            Directory.CreateDirectory(Application.dataPath + "/saves");

        BinaryFormatter bf = new BinaryFormatter();

        FileStream file = File.Create(Application.dataPath + "/saves/SaveData.dat");

        CopySaveData();

        bf.Serialize(file, data);
        file.Close();
    }

    public void CopySaveData()
    {
        data.list1.Clear();

        foreach (int i in list1)
        {
            data.list1.Add(i);

        }


        data.position = Vector2ToSerVector2(xy);

    }


    public static SerVector2 Vector2ToSerVector2(Vector2 V2)
    {
        SerVector2 SV2 = new SerVector2();

        SV2.x = V2.x;
        SV2.y = V2.y;

        return SV2;
    }

}
[System.Serializable]
public class savedata
{
    public SerVector2 position;

    public List<int> list1 = new List<int>();
}

[System.Serializable]
public class SerVector2
{
    public float x;
    public float y;
}

