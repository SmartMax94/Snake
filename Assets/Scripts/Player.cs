using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[RequireComponent(typeof(Rigidbody2D))]


public class Player : MonoBehaviour
{

    

    public float speed = 5;

    public Text livesText;





    private float mouseDistance;
    private Rigidbody2D rb;

    private float lastYPos;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    // Start is called before the first frame update
    void Start()
    {
        lastYPos = transform.position.y; 
    }

    // Update is called once per frame
    void Update()
    {
        


        Vector3 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float xPos = worldPoint.x;

        mouseDistance = Mathf.Clamp(xPos - transform.position.x, -1, 1);


        if(transform.position.y  > lastYPos + 10)
        {

            LevelController.instance.Score(10);
            lastYPos = transform.position.y;




        }



    }
    private void FixedUpdate()
    {
        if (LevelController.instance.gameOver)
            return;





        rb.velocity = new Vector2(mouseDistance * speed, LevelController.instance.gameSpeed * LevelController.instance.multiplier);
    }

    public void SetText(int amount)
    {

livesText.text = amount.ToString();


    }




    public void TakeDamage()
    {
        if (LevelController.instance.gameOver)
            return;




        int children = transform.childCount;
        if (children <= 1)
        {

            LevelController.instance.GameOver();


        }
        else
        {
            Destroy(transform.GetChild(children - 1).gameObject);

}

SetText(children -1);




}
}
