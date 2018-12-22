
using UnityEngine;

public class Pickup : MonoBehaviour
{


    public GameObject Player;
    public GameObject realHandGun;
    public GameObject fakeHandGun;
    public GameObject realAKGun;
    public GameObject fakeAKGun;
    public GameObject realSawedGun;
    public GameObject fakeSawedGun;
    public AudioSource Pickupsound;
    public GameObject cloneHandgun;
    public GameObject cloneAKgun;
    public GameObject cloneSawedgun;

    public GameObject newParent;

    public bool boolHasHandGun;
    public bool boolHasAKGun;
    public bool boolHasSawedGun;

    void Start()
    {
        boolHasHandGun = false;
        boolHasAKGun = false;
        boolHasSawedGun = false;

    }

    private void Update()
    {

    }



    private void OnTriggerEnter(Collider dataFromCollision)
    {

        if (dataFromCollision.gameObject.name == "GunTrigger")
        {
            /// if (boolHasHandGun == false & boolHasAKGun == false & boolHasSawedGun == false)

            Pickupsound.Play();
            boolHasHandGun = true;
            realHandGun.SetActive(true);
            realAKGun.SetActive(false);
            realSawedGun.SetActive(false);
            fakeHandGun.SetActive(false);
            cloneHandgun.transform.parent = newParent.transform;
            SetParent(newParent);


            ///else if(boolHasHandGun == false & boolHasAKGun == true | boolHasSawedGun ==true)

            ///   boolHasHandGun = false;
            ///   Pickupsound.Play();
            ///   SetParent(newParent);

            ///if (boolHasAKGun == false & boolHasHandGun == false & boolHasSawedGun == false)
            /// {
            //  Pickupsound.Play();
            //  boolHasAKGun = true;
            //  realAKGun.SetActive(true);
            //  realHandGun.SetActive(false);
            // realSawedGun.SetActive(false);
            // fakeAKGun.SetActive(false);

            // }
            // else if (boolHasAKGun == false & boolHasHandGun == true | boolHasSawedGun == true)

            //  Pickupsound.Play();
            // SetParent(newParent);




            // }



            //}
            // }
            //} 
        }

        if (dataFromCollision.gameObject.name == "akTrigger")
        {
            Pickupsound.Play();
            boolHasAKGun = true;
            realHandGun.SetActive(false);
            realAKGun.SetActive(true);
            realSawedGun.SetActive(false);
            fakeAKGun.SetActive(false);
            cloneAKgun.transform.parent = newParent.transform;
            SetParent(newParent);
        }
        if (dataFromCollision.gameObject.name == "SawedoffTrigger")
        {
            Pickupsound.Play();
            boolHasSawedGun = true;
            realHandGun.SetActive(false);
            realAKGun.SetActive(false);
            realSawedGun.SetActive(true);
            fakeSawedGun.SetActive(false);

            cloneSawedgun.transform.parent = newParent.transform;
            SetParent(newParent);
        }
    }

    public void SetParent(GameObject newParent)
    {
        // Makes the GameObject "newParent" the parent of the GameObject "player".
        cloneSawedgun.transform.parent = newParent.transform;

        // Display the parent's name in the console.
        Debug.Log("Player's Parent: " + cloneSawedgun.transform.parent.name);
    }
}