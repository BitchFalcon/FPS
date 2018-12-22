using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandgunFire : MonoBehaviour {

    public GameObject theGun;
    public GameObject muzzleFlash;
    public AudioSource gunFire;
    public AudioSource gunReload;
    public bool isFiring = false;



    public float damage = 10f;
    public float range = 100f;
    public Camera fpsCam;
    public GameObject impactEffect;


    public int maxAmmo = 8;
    private int currentAmmo;
    public float reloadTime = 1f;
    private bool isReloading = false;
    public Animator animator;



    private void Start()
    {
        currentAmmo = maxAmmo;
    }

    // Update is called once per frame
    void Update () {

        if (isReloading)
            return;

        if(currentAmmo <= 0)
        {

           StartCoroutine(Reload());
            return;
        }

        if (Input.GetButtonDown("Fire1"))
        {

            if (isFiring == false)
            {
                StartCoroutine(FiringHandgun());
            }
        }



	}
    IEnumerator Reload()
    {
        isReloading = true;
        Debug.Log("Reloading");
        animator.SetBool("Reloading", true);
        gunReload.Play();

        yield return new WaitForSeconds(reloadTime);

        animator.SetBool("Reloading", false);
        currentAmmo = maxAmmo;
        isReloading = false;
    }


    IEnumerator FiringHandgun()
    {



        isFiring = true;
        theGun.GetComponent<Animator>().Play("HandgunFire");
        muzzleFlash.SetActive(true);
        gunFire.Play();

        currentAmmo--;

        RaycastHit hit;
        if(Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {

            Debug.Log(hit.transform.name);

            Target target = hit.transform.GetComponent<Target>();

            if(target != null)
            {

                target.TakeDamage(damage);

            }
            Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));


        }

        yield return new WaitForSeconds(0.025f);
        muzzleFlash.SetActive(false);
        yield return new WaitForSeconds(0.225f);
        theGun.GetComponent<Animator>().Play("New State");
        isFiring = false;



    }
}

