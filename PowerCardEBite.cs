using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PowerCardEBite : PowerCardTemplate
{
    // Start is called before the first frame update
    public LayerMask groundS, heroX;
    public Hero heroB;
    public List<Hero> attackHero;
    public GameObject biteVFX;
 
    void Start()
    {
        if (targetPoint == Vector3.zero)
        {

            targetPoint = transform.position;
        }
        isPlayable = true;
        powerC = GetComponent<Collider>();
        manaCost = 3;
    }

    // Update is called once per frame
    void Update()
    {
        
        transform.position = Vector3.Lerp(transform.position, targetPoint, 3f * Time.deltaTime);



            


        

    }


    private void OnMouseDown()
    {
        if (inHand)
        {
            isSelected = true;
            justPressed = true;
            powerC.enabled = false;
        }
    }




    public override void OnEplay()
    {
        if (BattleManager.intance.enemyCurrentMana > 2)
        { 
        if (HeroPartyManager.instance.hero3)
        {

                if (HeroPartyManager.instance.hero_one.isAlive) {
                    attackHero.Add(HeroPartyManager.instance.hero_one);
                }

                if (HeroPartyManager.instance.hero_two.isAlive) {
                    attackHero.Add(HeroPartyManager.instance.hero_two);
                }
                if (HeroPartyManager.instance.hero_three.isAlive) {
                    attackHero.Add(HeroPartyManager.instance.hero_three);
                }
               

               
            heroB = attackHero[Random.Range(0, 3)];



        }
        else if (HeroPartyManager.instance.hero2)
        {

                if (HeroPartyManager.instance.hero_one.isAlive) {
                    attackHero.Add(HeroPartyManager.instance.hero_one);
                }
            
                if (HeroPartyManager.instance.hero_two.isAlive) {
                    attackHero.Add(HeroPartyManager.instance.hero_two);
                }
              
                heroB = attackHero[Random.Range(0, 2)];

        }

        else if (HeroPartyManager.instance.hero1)
        {
            attackHero.Add(HeroPartyManager.instance.hero_one);

            heroB = attackHero[0];
        }



        BattleManager.intance.enemyCurrentMana -= manaCost;
        MoveToPoint(heroB.transform.position);
        heroB.GetComponent<Renderer>().material.SetColor("_SolidOutline", Color.red);
        heroB.GetComponent<Renderer>().material.SetFloat("_OutlineEnabled", 1f);
        StartCoroutine(EPlayWait());


        EnemyHandController.intance.epowerHandCards.RemoveAt(cEHandPos);
        EnemyHandController.intance.EsetupCards();

            Destroy(this.gameObject, 3f);

    }
    }
    IEnumerator EPlayWait() {

        yield return new WaitForSeconds(1.75f);
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        EnBiteAnim();
        heroB.Damager(50);
        heroB.GetComponent<Renderer>().material.SetFloat("_OutlineEnabled", 0f);
    }

    public void OutLiner() {
        Ray rayS = new Ray(transform.position, transform.forward);
        RaycastHit hitS;
        if (Physics.Raycast(rayS, out hitS, 100f, heroX))
        {

            Debug.Log("rayzzz");
            heroB = hitS.transform.gameObject.GetComponent<Hero>();
            heroB.GetComponent<Renderer>().material.SetColor("_SolidOutline", Color.red);
            heroB.GetComponent<Renderer>().material.SetFloat("_OutlineEnabled", 1f);
            

        }
        else
        {
            heroB.GetComponent<Renderer>().material.SetFloat("_OutlineEnabled", 0f);


        }
    
   
    
    
   
    
    }

    public void EnBiteAnim()
    {
        GameObject spwanVFX = Instantiate(biteVFX, heroB.transform.position, Quaternion.identity);
        Destroy(spwanVFX, 0.5f);

    }
}
