using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    TextMeshProUGUI score;
    string team;
    int team_length;
    // Start is called before the first frame update
    void Start()
    {
        if(tag == "_blueTeam")
        {
            score = GameObject.Find("BlueScore").GetComponent<TextMeshProUGUI>();
            team = "Blue";
            team_length = 4;
            score.text = "Blue : 0";
        }
        if (tag == "_redTeam")
        {
            score = GameObject.Find("RedScore").GetComponent<TextMeshProUGUI>();
            team = "Red";
            team_length = 4;
            score.text = "Red : 0";
        }
    }

    // Update is called once per frame
    void Update()
    {
    
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.name == "Souafle")
        {
            score.text = team + " : " + (int.Parse((score.text).Substring(team_length+3))+1).ToString() ;
        }
    }
}
