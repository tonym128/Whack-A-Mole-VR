using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mole : MonoBehaviour {
    public float heightVisible = 6f;
    public float heightHidden = -1f;

    private Vector3 targetPosition;
    private float speed = 1f;

	// Use this for initialization
	void Start () {
        targetPosition = new Vector3(
                transform.localPosition.x,
                heightHidden,
                transform.localPosition.z
            );
    }

    // Update is called once per frame
    void Update () {
        transform.localPosition = Vector3.Lerp(transform.localPosition, targetPosition, Time.deltaTime * speed);
	}
}
