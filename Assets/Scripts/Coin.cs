using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour {

    private LevelManager levelManager;

    public int coinValue;

    // Start is called before the first frame update
    void Start() {
        levelManager = FindObjectOfType<LevelManager>();
    }

    // Update is called once per frame
    void Update() {

    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag == "Player") {
            levelManager.AddCoins(coinValue);

            Destroy(gameObject);
        }
    }
}
