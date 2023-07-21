using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireM4Animation : MonoBehaviour
{
    public GameObject blackM4;
    public bool isFiring = false;
    public AudioSource m4Shoot;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if  (isFiring == false)
            {
                StartCoroutine(FireTheM4());
            }
        }        
    }

    IEnumerator FireTheM4()
    {
        isFiring = true;
        blackM4.GetComponent<Animator>().Play("FireM4");
        m4Shoot.Play();
        yield return new WaitForSeconds(0.25f);
        blackM4.GetComponent<Animator>().Play("New State");
        isFiring = false;
    }
}
