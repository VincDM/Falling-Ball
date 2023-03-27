using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.IO;
using System.Text;

public class PlayerController : MonoBehaviour {

    public float speed;
    private int count;
    public Text countText;

    // Start is called before the first frame update
    void Start() {
        count=0;
        CountText();
    }

    // Update is called once per frame
    void Update() {
        
    }

    void FixedUpdate() {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        GetComponent<Rigidbody>().AddForce(movement * speed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other) {
	    if(other.gameObject.tag == "Item") {
            other.gameObject.SetActive(false);
            count = count + 1;
            CountText();
        }

        if(other.gameObject.tag == "Hazard") {
			other.gameObject.SetActive(false);
			Vector3 jump = new Vector3(0.0f, 30, 0.0f);
			GetComponent<Rigidbody>().AddForce(jump * speed * Time.deltaTime);
		}
    }

    void CountText() {
        Console.WriteLine("Count: " + count.ToString());
    }
}
