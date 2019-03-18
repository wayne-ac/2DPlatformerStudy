using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour {

    public float waitToRespawn;
    public PlayerController playerController;

    public GameObject deathExplosion;

    public int coinCount;

    public Text coinText;
    public Image heart1;
    public Image heart2;
    public Image heart3;

    public Sprite heartFull;
    public Sprite heartHalf;
    public Sprite heartEmpty;

    public int maxHealth;
    public int healtCount;

    private bool respawning;

    // Start is called before the first frame update
    void Start() {
        playerController = FindObjectOfType<PlayerController>();

        coinText.text = "Coins: " + coinCount;

        healtCount = maxHealth;
    }

    // Update is called once per frame
    void Update() {
        if (healtCount <= 0 && !respawning) {
            Respawn();
            respawning = true;
        }
    }

    public void Respawn() {
        StartCoroutine("RespawnCo");
    }

    public IEnumerator RespawnCo() {
        playerController.gameObject.SetActive(false);

        Instantiate(deathExplosion, playerController.transform.position, playerController.transform.rotation);

        yield return new WaitForSeconds(waitToRespawn);

        healtCount = maxHealth;
        respawning = false;
        UpdateHeartMeter();

        playerController.transform.position = playerController.respawnPosition;
        playerController.gameObject.SetActive(true);
    }

    public void AddCoins(int coinsToAdd) {
        coinCount += coinsToAdd;

        coinText.text = "Coins: " + coinCount;
    }

    public void HurtPlayer(int damageToTake) {
        healtCount -= damageToTake;
        UpdateHeartMeter();
    }

    public void UpdateHeartMeter() {
        switch(healtCount) {
            case 6:
                heart1.sprite = heartFull;
                heart2.sprite = heartFull;
                heart3.sprite = heartFull;
                return;
            case 5:
                heart1.sprite = heartFull;
                heart2.sprite = heartFull;
                heart3.sprite = heartHalf;
                return;
            case 4:
                heart1.sprite = heartFull;
                heart2.sprite = heartFull;
                heart3.sprite = heartEmpty;
                return;
            case 3:
                heart1.sprite = heartFull;
                heart2.sprite = heartHalf;
                heart3.sprite = heartEmpty;
                return;
            case 2:
                heart1.sprite = heartFull;
                heart2.sprite = heartEmpty;
                heart3.sprite = heartEmpty;
                return;
            case 1:
                heart1.sprite = heartHalf;
                heart2.sprite = heartEmpty;
                heart3.sprite = heartEmpty;
                return;
            case 0:
                heart1.sprite = heartEmpty;
                heart2.sprite = heartEmpty;
                heart3.sprite = heartEmpty;
                return;
            default:
                heart1.sprite = heartEmpty;
                heart2.sprite = heartEmpty;
                heart3.sprite = heartEmpty;
                return;

        }
    }
}
