using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderController : MonoBehaviour {

    public float moveSpeed;
    private bool canMove;

    private Rigidbody2D rigidBody;

    // Start is called before the first frame update
    void Start() {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update() {
        if (canMove) {
            rigidBody.velocity = new Vector3(-moveSpeed, rigidBody.velocity.y, 0f);
        }
    }

    private void OnBecameVisible() {
        canMove = true;
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag == "KillPlane") {
            Destroy(gameObject);
        }
    }
}
