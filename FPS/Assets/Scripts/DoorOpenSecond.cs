using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpenSecond : MonoBehaviour {

    public GameObject theDoor;
    public AudioSource doorFX;


    private void OnTriggerEnter(Collider other)
    {
        doorFX.Play();

            theDoor.GetComponent<Animator>().Play("DoorOpen2");
        this.GetComponent<BoxCollider>().enabled = false;
        StartCoroutine(CloseDoor());
    }

  IEnumerator CloseDoor()
    {
        yield return new WaitForSeconds(5);
        doorFX.Play();
        theDoor.GetComponent<Animator>().Play("DoorClose2");
        this.GetComponent<BoxCollider>().enabled = true;

    }

}
