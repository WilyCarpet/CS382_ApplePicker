using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Basket : MonoBehaviour
{
    public ScoreCounter scoreCounter;

    public RoundCounter roundCounter;

    // Start is called before the first frame update
    void Start()
    {
        GameObject scoreGo = GameObject.Find("ScoreCounter");
        GameObject roundGo = GameObject.Find("RoundCounter");
        scoreCounter = scoreGo.GetComponent<ScoreCounter>();
        roundCounter = roundGo.GetComponent<RoundCounter>();
    }

    // Update is called once per frame
    void Update()
    {
        //Get the current screen position of the mouse form Input
        Vector3 mousePos2D = Input.mousePosition;

        mousePos2D.z = -Camera.main.transform.position.z;

        Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D);

        Vector3 pos = this.transform.position;
        pos.x = mousePos3D.x;
        this.transform.position = pos;
    }

    void OnCollisionEnter(Collision coll)
    {
        //Find out what hit this basket
        GameObject collidedWith = coll.gameObject;
        if (collidedWith.CompareTag("Apple"))
        {
            Destroy(collidedWith);
            scoreCounter.score += 100;
            HighScore.TRY_SET_HIGH_SCORE(scoreCounter.score);
            if((scoreCounter.score % 1000) == 0){
                roundCounter.round += 1;
            }

        } else if(collidedWith.CompareTag("Branch")){
            Destroy(collidedWith);
            SceneManager.LoadSceneAsync(2);
        }
    }
}
