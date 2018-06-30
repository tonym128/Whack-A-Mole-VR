using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {
    public GameObject moleContainer;
    public TextMesh scoreboard;
    public Player player;

    public float minimumSpawnDuration = 0.5f;
    public float InitialMaximumSpawnDuration = 1.5f;
    public float maximumSpawnDuration = 1.5f;
    public float spawnDecrement = 0.1f;
    public float gameTimer = 15f;
    public bool gameRunning = true;

    private Mole[] moles;
    private float spawnTimer = 0f;

    private void Awake()
    {
        moles = moleContainer.GetComponentsInChildren<Mole>();
        SetSpawnTimer();
    }

    private void SetSpawnTimer()
    {
        spawnTimer = Random.Range(minimumSpawnDuration, maximumSpawnDuration);
    }

    // Use this for initialization
    void Start () {
        InitialMaximumSpawnDuration = maximumSpawnDuration;
        gameRunning = true;
    }
	
	// Update is called once per frame
	void Update () {

        if (gameRunning)
        {
            if (gameTimer > 0f)
            {
                gameTimer -= Time.deltaTime;
                spawnTimer -= Time.deltaTime;

                if (spawnTimer <= 0f)
                {
                    moles[Random.Range(0, moles.Length)].Rise();
                    maximumSpawnDuration -= maximumSpawnDuration > minimumSpawnDuration ? spawnDecrement : 0;
                    SetSpawnTimer();
                }

                scoreboard.text = "Hit all the moles\nTime : " + Mathf.Floor(gameTimer) + "\nScore : " + player.score;
            }
            else
            {
                scoreboard.text = "Game Over\nTime : 0\nScore : " + player.score;
                gameRunning = false;
            }
        }
    }
}
