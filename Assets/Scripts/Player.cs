using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    private Transform player;
    public Transform shotSpawn;
    public float speed, maxBound, minBound, fireRate;
    public GameObject shot;
    private float nextFire;

	void Start () {
        player = GetComponent<Transform>();
	}
	
	void FixedUpdate () {
        float h = Input.GetAxis("Horizontal");

        if (player.position.x < minBound && h < 0)
            h = 0;
        else if (player.position.x > maxBound && h > 0)
            h = 0;
        player.position += Vector3.right * h * speed;
	}

    void Update() {
        if (Input.GetButton("Fire1") && Time.time > nextFire) {
            nextFire = Time.time + fireRate;
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);

        }
    }
}
