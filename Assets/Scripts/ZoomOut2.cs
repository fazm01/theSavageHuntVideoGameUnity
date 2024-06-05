using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomOut2 : MonoBehaviour
{
    private Camera Cam;
    public float ZoomSpeed;
    public KeyCode Abutton;
    // Start is called before the first frame update
    void Start()
    {
        Cam = GetComponent<Camera>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(Abutton))
        {
            Cam.orthographicSize = Mathf.Lerp(Cam.orthographicSize, 12, Time.deltaTime * ZoomSpeed);
        }
        else
        {
            Cam.orthographicSize = Mathf.Lerp(Cam.orthographicSize, 8, Time.deltaTime * ZoomSpeed);

        }
    }
}
