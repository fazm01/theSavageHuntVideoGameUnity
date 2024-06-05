using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {
	public GameObject CurrentCheckpoint;
	public Transform player;
	public Transform enemy;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void RespawnPlayer()
    {
		FindObjectOfType<Player>().transform.position = CurrentCheckpoint.transform.position;
    }
	public void RespawnEnemy()
    {
		Instantiate(enemy, transform.position, transform.rotation);
    }
}
