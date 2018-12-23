using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour {
    public float health = 1f;
    private MeshRenderer box;
	// Use this for initialization
	void Start ()
    {
        box = GetComponent<MeshRenderer>();
    }
	
	// Update is called once per frame
	void Update () {
        box.material.color = new Color(health, health, health, health);
        if (health <= 0) {
            Destroy(gameObject);
        }
    }
}
