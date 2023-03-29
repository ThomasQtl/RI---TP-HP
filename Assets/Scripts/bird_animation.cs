using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bird_animation : MonoBehaviour
{
    private Animator anim;
    string[] tab_anim = new string[3];
    int mouv;
    string mouvtype;


    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();

        tab_anim[0] = "launchSpin";
        tab_anim[1] = "launchBounce";
        tab_anim[2] = "launchClicked";

        transform.Rotate(0f, Random.Range(0f,360f), 0f);
        
    }

    // Update is called once per frame
    void Update()
    {

        //on choisi si on fait un mouvement
        if (Random.Range(0, 500) == 1)
        {
            //on fait le mouvement
            mouv = Random.Range(0, 3);
            
            mouvtype = tab_anim[mouv];
            
            anim.SetTrigger(mouvtype);
           
            //Debug.Log(Random.Range(0, 3));
        }
        
        /*
        if (Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetTrigger("launchSpin");
        }

        type_anim = choixAnimation();
        */
       
        }

    }
