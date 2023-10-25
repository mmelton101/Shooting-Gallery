using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public GameObject fpsController;
    public GameObject terrain;

    SpawnPoint spawnPoint;

    void Start()
    {
        spawnPoint = new SpawnPoint();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Vector3 pos = spawnPoint.Generate(other.gameObject, terrain);

            MoveTo(other.gameObject, pos);
        }
    }

    void MoveTo(GameObject player, Vector3 pos)
    {
        CharacterController controllerScript = player.GetComponent<CharacterController>();

        controllerScript.enabled = false;
        player.transform.position = pos;
        controllerScript.enabled = true;
    }
}
