using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Hero : MonoBehaviour
{
    // Start is called before the first frame update

    public List<PowerCardTemplate> masterDeck;
    public float maxHP=100, currentHP = 100;
    public Image healthBarHP;
    public TMP_Text healthText;
    public TMP_Text heroNameText;
    float lerpSpeed;
    public bool isAlive=true;
    void Start()
    {
        currentHP = maxHP;
        isAlive = true;
    }

    // Update is called once per frame
    void Update()
    {
        healthText.text = currentHP.ToString();
        heroNameText.text = "HeroTemplate";
        HealthBarFiller();
        BarColorC();
        lerpSpeed = 3f * Time.deltaTime;
        if (currentHP > maxHP) { currentHP = maxHP; }
        if (currentHP < 0) { currentHP = 0; }
        if (currentHP == 0)
        {

            isAlive = false;
            this.GetComponent<Renderer>().material.SetFloat("_OutlineEnabled", 1f);
            this.GetComponent<Renderer>().material.SetColor("_Color", Color.red);
        }
    }


    public void HealthBarFiller(){

        healthBarHP.fillAmount = Mathf.Lerp(healthBarHP.fillAmount, (currentHP/maxHP),lerpSpeed) ;
        
}

    public void BarColorC()
    {

        Color hpColor = Color.Lerp(Color.yellow, Color.red, (currentHP / maxHP));
        healthBarHP.color = hpColor;
    }


    public void Damager(float damage)
    {
        
        currentHP -= damage;


    }

    public void Healerr(float heal)
    {
       
        currentHP += heal;


    }
}
