using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Obstacles : MonoBehaviour
{

    public Obstacle[] allObstacles;
    public GameObject[] barriers;

    public GameObject[] effect;



    public Vector2 positionRange;
    public GameObject obstaclesGroup;

    private Transform player;


    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>().transform;
        SetObstacles();
    
    
    }

    void SetObstacles()
    {

        for (int i = 0; i < allObstacles.Length; i++)
        {
            allObstacles[i].SetAmount();

        }
for (int  i = 0; i < barriers.Length; i++)
        {

            bool randomBool = Random.value > 0.5f;
            barriers[i].SetActive(randomBool);



        }


        DecreaseDifficulty();


    }


    void Reposition()
    {

        int obstaclesAmount = FindObjectsOfType<Obstacles>().Length;




        transform.position = new Vector2(0, player.position.y + (LevelController.instance.obstaclesDistance * (obstaclesAmount - 1)));


        obstaclesGroup.transform.localPosition = new Vector2(0, Random.Range(positionRange.x, positionRange.y));


    }


    void DecreaseDifficulty()
    {


    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        


        if (other.CompareTag("Player"))


            

        {

            



            Reposition();

            SetObstacles();


        }
    }




}

