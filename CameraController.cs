using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.AI;
public class CameraController : MonoBehaviour
{	
	public GameObject bullet;
	GameObject bulletClone;
	Rigidbody rbClone; 

    public Text hpText;
    int HP;

	Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        HP = 100;
    }

    void FixedUpdate()
    {
    	//Движение
        float moveVertical = Input.GetAxis("Vertical");
    	rb.AddForce(transform.forward * moveVertical * 50f);
    
    	//Повороты
        float moveHorizontal = Input.GetAxis("Horizontal");
        transform.Rotate(0f,moveHorizontal * 10f,0f);

        //Пули
        if(Input.GetKey("space"))
        {
            bulletClone = Instantiate(bullet,new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
            rbClone = bulletClone.GetComponent<Rigidbody>();
            rbClone.AddForce(transform.forward * 600f);

        }
    }
    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            HP = HP - 20;
            hpText.text = "HP: " + HP;
            if(HP <= 0)
            {
                SceneManager.LoadScene(1);
            }
        }     
    }
}
