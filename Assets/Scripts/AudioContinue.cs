using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioContinue : MonoBehaviour
{
    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);

    }
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "Level1Scene1")
        {
            Destroy(transform.gameObject);
        }
    }
}
