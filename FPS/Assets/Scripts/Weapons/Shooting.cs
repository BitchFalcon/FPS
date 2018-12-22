using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour {

    int whichBarrel = 1;
    public float damage = 10f;
    public float range = 100f;

    public Camera fpsCam;
    public ParticleSystem muzzleFlash;
    public ParticleSystem muzzleFlash1;
    public GameObject impactEffect;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Fire1"))
        {

            Shoot();
        }
        if (Input.GetButtonDown("Fire2"))
        {

            Shoot2();
        }

        
	}

    void Shoot()
    {
        if(whichBarrel == 1)
        {
            muzzleFlash1.Play();
            
            whichBarrel++;
        }
        else
        {
            muzzleFlash.Play();
            whichBarrel--;
        }
        
        
        RaycastHit hit;
       if(Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);
        Target target = hit.transform.GetComponent<Target>();
            if (target != null)
            {
                target.TakeDamage(damage);

            }
            Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
        }


    }
    void Shoot2()
    {
        
            muzzleFlash1.Play();
            muzzleFlash.Play();  


        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);
            Target target = hit.transform.GetComponent<Target>();
            if (target != null)
            {
                target.TakeDamage(damage);

            }
            Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
        }


    }
}
