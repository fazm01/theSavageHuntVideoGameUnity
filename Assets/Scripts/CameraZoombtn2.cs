
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoombtn2 : MonoBehaviour
{
	private Camera Cam;
	public float ZoomSpeed;
	public KeyCode Zbutton;
	// Use this for initialization
	void Start () {
		Cam = GetComponent<Camera>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void FixedUpdate()
    {
        if (Input.GetKey(Zbutton))
        {
			Cam.orthographicSize = Mathf.Lerp(Cam.orthographicSize, 4, Time.deltaTime * ZoomSpeed);
        }
        else
        {
			Cam.orthographicSize= Mathf.Lerp(Cam.orthographicSize, 8, Time.deltaTime * ZoomSpeed);

		}
    }
}
