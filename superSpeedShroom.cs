using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class superSpeedShroom : MonoBehaviour
{
    // teleportation random coordinates for the poweup - can alter the range to fit with the ground and also where I want the respawn to be


    // audio clips 
    public AudioSource powerUp;
    public AudioSource powerDown;
    

    void start()
    {

    }

    void OnTriggerEnter(Collider other)
    {        
        if (other.CompareTag("Player"))
        {
            Pickup(other);
            powerUp.Play();
        }
        //else for any other colliser do nothing
    }
    

    private void Pickup(Collider Player)
    {
        Debug.Log("Picked up"); //can get rid of 
        Invoke("DropPowerUP", 5f);
        //make mesh invisible and turn off the sphere collider so that it cannot be triggered
      //  gameObject.GetComponent(MeshRenderer).enabled = false;
       // gameObject.GetComponent(SphereCollider).enabled = false;

        gameObject.SetActive(false);
        
        //Destroy(gameObject.GetComponent<MeshRenderer>()); // makes mesh invisible
        //Destroy(gameObject.GetComponent<SphereCollider>()); // deactivates sphere collider
    }

    void DropPowerUP()
    {

        Debug.Log("Dropped"); //meant to say that it has been destroyed
        powerDown.Play();
        // destory after all of the code has run not right after the invoke
        Respawn();
         }

    void Respawn()
    {
        float x = Random.Range(0, 10); // change to be the range of the path
        float y = Random.Range(1, 1);
        float z = Random.Range(0, 10);

        Vector3 randomPosition = new Vector3(x,y,z);

        gameObject.transform.position = randomPosition;

       // GetComponent(MeshRenderer).enabled = true;
       // GetComponent(SphereCollider).enabled = true;
        gameObject.SetActive(true);      

    }

}

    // have a void that has the speed change and then can destroy in invoke function when getting it to work
