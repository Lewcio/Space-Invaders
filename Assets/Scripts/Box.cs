using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour {
    public float health = 1f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        this.GetComponent<MeshRenderer>().material.color = new Color(health, health, health, health);
        if (health <= 0) {
            Destroy(gameObject);
        }
    }
}
