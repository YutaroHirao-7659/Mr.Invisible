using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.WSA.Input;
using HoloToolkit.Unity;

public class MRWalk : MonoBehaviour
{
    private GameObject MRCamera;

    private float minYForForwardSpeed = 0.2f;
    public float forwardSpeed = 0.03f;
    public float speed = 0.01f;

    //移動時振動関連
    public bool isVibrate = true;
    private float minYForVibration = 0.2f;
    public float frequency = 5;
    public float Amplitude = 0.05f;
    private float r = 0;

    // Use this for initialization
    void Awake()
    {
        MRCamera = GameObject.FindWithTag("MainCamera");
    }

    // Update is called once per frame
    void Update()
    {
        //移動
        float leftX = Input.GetAxis("LeftStickX");
        float leftY = Input.GetAxis("LeftStickY");
        leftY *= -1;
        Debug.Log("LeftX is : " + leftX + ", LeftY is : " + leftY);
        //前進だけスピード変える
        var speedParameter = leftY > minYForForwardSpeed ? forwardSpeed : speed;
        transform.position += new Vector3(MRCamera.transform.forward.x, 0, MRCamera.transform.forward.z) * leftY * speedParameter;
        transform.position += new Vector3(MRCamera.transform.right.x, 0, MRCamera.transform.right.z) * leftX * speedParameter;

        //振動
        if (leftY > minYForVibration)
        {
            r += Time.deltaTime;
            transform.position = new Vector3(transform.position.x, Amplitude * Mathf.Abs(Mathf.Sin(r * frequency)), transform.position.z);
        }
        else if (r != 0)
        {
            r = 0;
            transform.position = new Vector3(transform.position.x, 0, transform.position.z);
        }
    }
}
