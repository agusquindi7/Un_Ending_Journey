using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowBullet : MonoBehaviour
{
    public string playerTag = "Player";
    public PlayerMovement playerMov;
    public SpriteRenderer player;

    public float _slowSpeed, _normalSpeed;
    public float timeSlow = 1f;

    private bool isSlowed;

    public float cooldown, currentCD;


    private void Update()
    {
        if (isSlowed)
        {
            currentCD += Time.deltaTime;
            currentCD = Mathf.Clamp(currentCD, 0, cooldown);
        }
        if (currentCD == cooldown)
        {
            isSlowed = false;
            player.color = Color.white;
            playerMov.normalSpeed = _normalSpeed;
            currentCD = 0;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(playerTag))
        {
            player = collision.GetComponentInChildren<SpriteRenderer>();
            playerMov = collision.GetComponent<PlayerMovement>();
            

            if (player != null && playerMov != null)
            {
                isSlowed = true;
                player.color = Color.blue;
                playerMov.normalSpeed = _slowSpeed;
            }
        }
    }
    
    /*
    IEnumerator SlowBullet()
    {
        playerMov.normalSpeed = _slowSpeed;
        player.color = Color.cyan;
        yield return new WaitForSeconds(timeSlow);
        Debug.Log("WaitForSeconds completed");
        player.color = Color.white;
        playerMov.normalSpeed = _normalSpeed;
        Debug.Log("Termino la corrutina");
    }
    */

    
}
