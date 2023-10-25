using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public float range = 100f;
    public ParticleSystem muzzleFlash;

    private Camera fpsCamera;
    private float nextTimeToFire;

    // Start is called before the first frame update
    void Start()
    {

        fpsCamera = GameObject.Find("FirstPersonCharacter").GetComponent<Camera>();
        nextTimeToFire = 0.0f;
        
    }

    // Update is called once per frame
    void Update()
    {
        bool ready = Time.time >= nextTimeToFire;
        if(ready && Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }


    void Shoot()
    {
        if (muzzleFlash != null)
        {
            muzzleFlash.Play();
        }
        RaycastHit hit;

        if( Physics.Raycast(fpsCamera.transform.position,fpsCamera.transform.forward,out hit, range))
        {
            Target target = hit.transform.GetComponent<Target>();
            if(target != null)
            {
                target.Process(hit);
            }

            nextTimeToFire = Time.time + 1f;
        }
    }
}
