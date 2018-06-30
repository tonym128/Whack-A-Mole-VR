using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    public int score;

	// Use this for initialization
	void Start () {
        score = 0;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Fire1") || Input.GetKeyDown("space"))
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.forward, out hit))
            {
                Mole mole = hit.transform.GetComponent<Mole>();
                if (mole != null)
                {
                    mole.OnHit();
                    score += 1;
                }
            }
        }
    }
}
