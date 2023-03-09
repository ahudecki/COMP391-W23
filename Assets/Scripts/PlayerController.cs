using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// PlayerController is the name of the class 
// public meas anyone can access this class 
// public, protected, private 

public class PlayerController : MonoBehaviour
{
    // int --> 7,6,8,77,44,666
    public int speed;
    public float minX, minY, maxX, maxY;
    public GameObject laserSpawn;
    public GameObject laser;
    private float timer = 0;
    public float fireRate = 2.0f; 
    // Start is called before the first frame update
    void Start()
    {
        // restrict the player in the game area
        float newX, newY;
        newX = Mathf.Clamp(GetComponent<Rigidbody2D>().position.x, minX, maxX);
        newY = Mathf.Clamp(GetComponent<Rigidbody2D>().position.y, minY, maxY);
        Debug.Log("Clamp X:" + newX + "Clamp Y:" + newY);
        GetComponent<Rigidbody2D>().position = new Vector2(newX, newY);


    }


    // 60 frames in 1 second --> 1 sec video of good quality
    // Update is called once per frame
    void Update()
    {
        // float --> 1.2, 2.1, 7.99, 8.796
        float h, v;
        h = UnityEngine.Input.GetAxis("Horizontal");
        v = UnityEngine.Input.GetAxis("Vertical");
        // We use Debug.Log when we have to display the message/values on the console
        // string --> "ABCD", "Mario" 
        //   Debug.Log("horizontal values : " + h + "vertical values : " + v);
        Vector2 newvelocity = new Vector2(h, v);
        GetComponent<Rigidbody2D>().velocity = newvelocity * speed;

        // restrict the player in the game area
        float newX, newY;
        newX = Mathf.Clamp(GetComponent<Rigidbody2D>().position.x, minX, maxX);
        newY = Mathf.Clamp(GetComponent<Rigidbody2D>().position.y, minY, maxY);
        Debug.Log("Clamp X:" + newX + "Clamp Y:" + newY);
        GetComponent<Rigidbody2D>().position = new Vector2(newX, newY);

    if (Input.GetAxis("Fire1") > 0 && timer > fireRate)
        {
            //Instantiate: what do I instantiate? Where is it? WHat is it's rotation? 
            GameObject gObj;
            gObj = GameObject.Instantiate(laser, laserSpawn.transform.position, laserSpawn.transform.rotation);
            gObj.transform.Rotate(new Vector3(0, 0, 90));
            timer = 0; // reset the timer

        }
        timer += Time.deltaTime; 

    }
}
