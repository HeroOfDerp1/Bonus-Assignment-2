using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using UnityEngine;

public class PluginTester : MonoBehaviour
{
    //cube
    public GameObject cube;

    //set a string for the dll name
    private const string DLL_NAME = "Bonus 2 Engines- 100662337";

    [StructLayout(LayoutKind.Sequential)]
    struct Vector3D
    {
        public float x;
        public float y;
        public float z;
    }

    [DllImport(DLL_NAME)]
    private static extern int GetID();

    [DllImport(DLL_NAME)]
    private static extern void SetID(int id);

    [DllImport(DLL_NAME)]
    private static extern Vector3D GetPosition();

    [DllImport(DLL_NAME)]
    private static extern void SetPosition(float x, float y, float z);

    // Start is called before the first frame update
    void Start()
    {
        //empty but not deleting cause i got errors
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.S))
        {
            SetID(911);

            UnityEngine.Debug.Log(GetID());
        }

        if(Input.GetKeyDown(KeyCode.D))
        {
            SetPosition(3.4f, 5.7f, 9.8f);

            UnityEngine.Debug.Log(GetPosition().x);
            UnityEngine.Debug.Log(GetPosition().y);
            UnityEngine.Debug.Log(GetPosition().z);

            cube.transform.position = new Vector3(GetPosition().x, GetPosition().y, GetPosition().z);
        }
    }
}
