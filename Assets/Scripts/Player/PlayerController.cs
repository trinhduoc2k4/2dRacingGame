using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;
    public float verticalInput, horizontalInput;
    private float rotationSpeed = 5f;
    private float horizontalSpeed = 4f;
    public bool isTrigger;
    void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
    }

    private void FixedUpdate()
    {
        //if (verticalInput > 0)
        //{
        if (GameManager.instance.gameStartPanel.activeSelf) return;
        transform.position += new Vector3(horizontalInput * Time.fixedDeltaTime * horizontalSpeed, 0, 0);
            
            if (horizontalInput > 0) transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, 80), rotationSpeed * Time.fixedDeltaTime);
            else if (horizontalInput < 0) transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, 100), rotationSpeed * Time.fixedDeltaTime);
            else transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, 90), 15f * Time.fixedDeltaTime);
        //} else transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, 90), 15f * Time.fixedDeltaTime);
        if (horizontalInput > 0 && transform.position.x >= 1.95f) transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, 93), 15f * Time.fixedDeltaTime);
        else if (horizontalInput < 0 && transform.position.x <= -1.95f) transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, 88), 15f * Time.fixedDeltaTime);
        Vector3 posLimit = transform.position;
        posLimit.x = Mathf.Clamp(posLimit.x, -1.95f, 1.95f);
        transform.position = posLimit;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            Time.timeScale = 0;
            isTrigger = true;
            GameManager.instance.gameOverPanel.SetActive(true);
            GameManager.instance.bgSound.Stop();
            AudioSource carCrashSound = collision.gameObject.GetComponent<AudioSource>();
            carCrashSound.Play();
        }
        if (collision.tag == "Coin")
        {
            AudioSource coinSound = collision.gameObject.GetComponent<AudioSource>();
            SpriteRenderer sr = collision.gameObject.GetComponent<SpriteRenderer>();
            coinSound.Play();
            //Destroy(collision.gameObject);
            var scoreManager = GetComponent<ScoreManager>();
            scoreManager.UpdateScore();
            StartCoroutine(DestroyAfterSecond(collision.gameObject));
            sr.enabled = false;
        }
    }

    IEnumerator DestroyAfterSecond(GameObject go)
    {
        yield return new WaitForSeconds(2);
        Destroy(go);
    }
}
