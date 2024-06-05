using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            GoToSecondScene();
            Destroy(this.gameObject);
        }
    }
    public void GoToSecondScene()
    {
        NavigationController.instance.GoToLevel4();

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
