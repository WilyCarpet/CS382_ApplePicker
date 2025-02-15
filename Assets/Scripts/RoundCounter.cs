using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RoundCounter : MonoBehaviour
{

    [Header("Dynamic")]
    public int round = 1;
    private TextMeshProUGUI uiRound;
    // Start is called before the first frame update
    void Start()
    {
        uiRound = GetComponent<TextMeshProUGUI>();

    }

    // Update is called once per frame
    void Update()
    {
        if(round == 5){
            SceneManager.LoadSceneAsync(2);
        } else {
            uiRound.text = "Round " + round.ToString("#,0");
        }
    }
}
