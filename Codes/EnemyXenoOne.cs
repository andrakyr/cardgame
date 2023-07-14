using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyXenoOne : Enemy
{
    // Start is called before the first frame update
    void Start()
    {
        ecurrentHP = emaxHP;
    }

    // Update is called once per frame
    void Update()
    {
        ehealthText.text = ecurrentHP.ToString();
        enemyNameText.text = "HeroTemplate";
        HealthBarFiller();
        BarColorC();
        lerpSpeed = 3f * Time.deltaTime;
        if (ecurrentHP > emaxHP) { ecurrentHP = emaxHP; }
        if (ecurrentHP < 0) { ecurrentHP = 0; }
        if (ecurrentHP == 0)
        {

            isAlive = false;
            this.GetComponent<Renderer>().material.SetFloat("_OutlineEnabled", 1f);
            this.GetComponent<Renderer>().material.SetColor("_Color", Color.red);
        }



    }
}
