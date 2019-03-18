using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtPlayer : MonoBehaviour {

    private LevelManager levelManager;

    public int damageToGive;

    // Start is called before the first frame update
    void Start() {
        levelManager = FindObjectOfType<LevelManager>();
    }

    // Update is called once per frame
    void Update() {

    }

    void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag == "Player") {
            //levelManager.Respawn();
            levelManager.HurtPlayer(damageToGive);
        }
    }
}
