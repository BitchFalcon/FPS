﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquippedWeapon : MonoBehaviour {
    public int selectedWeapon = 0;

	// Use this for initialization
	void Start () {

        


		
	}
	
	// Update is called once per frame
	void Update () {
        int previosSelectedWeapon = selectedWeapon;
		if(Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            if (selectedWeapon >= transform.childCount - 1)
                selectedWeapon = 0;
            else
            selectedWeapon++;
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            if (selectedWeapon <= 0)
                selectedWeapon = transform.childCount - 1;
            else
                selectedWeapon--;
        }

        if(previosSelectedWeapon != selectedWeapon)
        {
            SelectWeapon();
        }
    }

    void SelectWeapon()
    {
        int i = 0;
        foreach (Transform weapon in transform)
        {

            if (i == selectedWeapon)
            
                weapon.gameObject.SetActive(true);
                else 
                weapon.gameObject.SetActive(false);
                i++;
            
            }
            
        }


    }

