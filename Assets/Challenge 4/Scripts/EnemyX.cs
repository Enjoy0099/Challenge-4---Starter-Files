using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyX : MonoBehaviour
{
    public float speed = 230;
    private Rigidbody enemyRb;
    private GameObject playerGoal;

    private SpawnManagerX spawnManager_Script;

    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        spawnManager_Script = FindObjectOfType<SpawnManagerX>();
        playerGoal = GameObject.FindWithTag("PlayerGoal");
        speed += spawnManager_Script.waveCount * 10;
    }

    // Update is called once per frame
    void Update()
    {
        // Set enemy direction towards player goal and move there
        Vector3 lookDirection = (playerGoal.transform.position - transform.position).normalized;
        enemyRb.AddForce(lookDirection * speed * Time.deltaTime);

    }

    private void OnCollisionEnter(Collision other)
    {
        // If enemy collides with either goal, destroy it
        if (other.gameObject.CompareTag("EnemyGoal"))
        {
            Destroy(gameObject);
        } 
        else if (other.gameObject.CompareTag("PlayerGoal"))
        {
            Destroy(gameObject);
        }

    }

}
