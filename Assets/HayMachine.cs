using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HayMachine : MonoBehaviour
{
    // Start is called before the first frame update
    public int movmentSpeed;
    public float horizontalBoundary = 22;

    public GameObject hayBalePrefab; //Reference to the Hay Bale prefab.
    public Transform haySpawnpoint; //The point from which the hay will to be shot.
    public float shootInterval; //The smallest amount of time between shots
    private float shootTimer; //A timer that to keep track whether the machine can shoot
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        UpdateMovment();
        UpdateShooting();
    }

    private void UpdateMovment()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        if (horizontalInput < 0 && transform.position.x > -horizontalBoundary)
        {
            transform.Translate(transform.right * -movmentSpeed * Time.deltaTime);
        }
        else if (horizontalInput > 0 && transform.position.x < horizontalBoundary)
        {
            transform.Translate(transform.right * movmentSpeed * Time.deltaTime);
        }
    }


    private void UpdateShooting()
    {
        shootTimer -= Time.deltaTime;
        if (shootTimer <= 0 && Input.GetKey(KeyCode.Space))
        {
            shootTimer = shootInterval;
            ShootHay();
        }
    }

    private void ShootHay()
    {
        Instantiate(hayBalePrefab, haySpawnpoint.position, Quaternion.identity);
        SoundManager.Instance.PlayShootClip();
    }
}
