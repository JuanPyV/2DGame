using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour {

	public Sprite verde;
    public Sprite rojo;
    private SpriteRenderer checkpoint;
    public bool llegastes;

	void Start () {
        checkpoint = GetComponent<SpriteRenderer>();
		
	}
		
	void OnTriggerEnter2D (Collider2D other) {
        if (other.tag == "Player")
        {
            checkpoint.sprite = verde;
            llegastes = true;
        }
		
	}
}
