using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
	public Transform player;
	public NavMeshAgent agent;

    public Text ScoreText;
    static int Score = 0;

    void Update()
    {
        agent.SetDestination(player.transform.position);
    }
    //Столкновение врага и пули
   void OnCollisionEnter(Collision lol){
        if(lol.gameObject.tag == "Bullet")
        {
            Destroy(gameObject);
            Score = Score + 1;
            ScoreText.text = "Score:" + Score;
            if(Score >= 6)
            {
                SceneManager.LoadScene(0);
                Score = 0;
            }
        }
    }
}