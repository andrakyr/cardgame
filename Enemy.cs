using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    public List<PowerCardTemplate> masterEnemyDeck;
    public float emaxHP = 100, ecurrentHP = 100;
    public Image ehealthBarHP;
    public TMP_Text ehealthText;
    public TMP_Text enemyNameText;
    public float lerpSpeed;
    public bool isAlive=true;
    void Start()
    {
        ecurrentHP = emaxHP;
        isAlive = true;
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


    public void HealthBarFiller()
    {

        ehealthBarHP.fillAmount = Mathf.Lerp(ehealthBarHP.fillAmount, (ecurrentHP / emaxHP), lerpSpeed);
     

    }

    public void BarColorC()
    {

        Color hpColor = Color.Lerp(Color.yellow, Color.red, (ecurrentHP / emaxHP));
        ehealthBarHP.color = hpColor;
    }


    public void Damager(float damage)
    {
        
        ecurrentHP -= damage;


    }

    public void Healerr(float heal)
    {
        heal = 5f;
        ecurrentHP += heal;


    }
}
