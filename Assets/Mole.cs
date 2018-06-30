using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mole : MonoBehaviour {
    public float heightVisible = 6f;
    public float heightHidden = -1f;

    private Vector3 targetPosition;
    private float speed = 1f;
    public float disappearDuration = 3f;
    private float disappearTimer = 0f;
    private bool hideTimer = false;

    // Use this for initialization
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        if (hideTimer) { 
            disappearTimer -= Time.deltaTime;
        }

        if (disappearTimer <= 0)
        {
            Hide();
            hideTimer = false;
        }

        if (targetPosition != new Vector3(0, 0, 0))
        {
            transform.localPosition = Vector3.Lerp(transform.localPosition, targetPosition, Time.deltaTime * speed);
            if (transform.localPosition == targetPosition)
            {
                targetPosition = new Vector3(0, 0, 0);
            }
        }
    }

    public void Hide()
    {
        targetPosition = new Vector3(
                        transform.localPosition.x,
                        heightHidden,
                        transform.localPosition.z
                    );
    }

    public void OnHit()
    {
        Hide();
    }

    public void Rise()
    {
        targetPosition = new Vector3(
                        transform.localPosition.x,
                        heightVisible,
                        transform.localPosition.z
                    );

        disappearTimer = disappearDuration;
        hideTimer = true;
    }
}
