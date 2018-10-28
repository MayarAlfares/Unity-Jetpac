using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketScript : MonoBehaviour {



	public GameObject[] rockets;
	public GameObject rocketHere;

	public GameObject[] fixedRockets;
	public GameObject fixedNow;

	public GameObject rocket1;
	

	//public GameObject player;

	public int i;
	public bool caught = false;

	Collider2D player;


	void Start () {
		//rocketHere = rockets[Random.Range(0, rockets.Length)];
		rocketHere = rockets[i];
		GetComponent<SpriteRenderer>().sprite = rocketHere.GetComponent<SpriteRenderer>().sprite;

		//fixedNow = fixedRockets[i];
		//GetComponent<SpriteRenderer>().sprite = fixedNow.GetComponent<SpriteRenderer>().sprite;
	}
	
	// Update is called once per frame
	void Update () {
		if(caught == true){
			transform.position = player.transform.position;
			if(Input.GetKeyDown(KeyCode.Keypad0) && (transform.position.x >2 && transform.position.x <4)){
				Debug.Log("drop");
				caught = false;
				i++;
				if(i == rockets.Length-1){
					Destroy(gameObject);
				}
				//delay
				rocketHere = rockets[i];
				GetComponent<SpriteRenderer>().sprite = rocketHere.GetComponent<SpriteRenderer>().sprite;
				transform.position = new Vector3(-5.5f, 2f, 0.0f); 

				Fixed();
			}
		}
	}

	public void Fixed(){
		fixedNow = fixedRockets[i];
		rocket1.GetComponent<SpriteRenderer>().sprite = fixedNow.GetComponent<SpriteRenderer>().sprite;
		//fixedNow.transform.position = new Vector3(3.5f, -3.5f, 0.0f);
		
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "Player"){
			caught = true;		
			transform.position = other.transform.position;
			player = other;
		}
	}
}
