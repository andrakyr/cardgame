using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class PowerCardERoar : PowerCardTemplate
{
    public LayerMask groundS, heroX;
    public Hero heroB;
    public Enemy enemyR;
    public List<Hero> attackHero;
    public List<Enemy> selfECast;
    public List<Enemy> enemyCast;
    public GameObject roarVFX;
   
    void Start()
    {
        if (targetPoint == Vector3.zero)
        {

            targetPoint = transform.position;
        }
        isPlayable = true;
        powerC = GetComponent<Collider>();
         manaCost = 2;
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
        
        if(BattleManager.intance.enemyCurrentMana > 1)
        { 

        if (EnemyPartyManager.instance.enemy3)
        {



                if (EnemyPartyManager.instance.enemy_one.isAlive)
                {
                    enemyCast.Add(EnemyPartyManager.instance.enemy_one);

                }

                if (EnemyPartyManager.instance.enemy_two.isAlive)
                {
                    enemyCast.Add(EnemyPartyManager.instance.enemy_two);
                }
                if (EnemyPartyManager.instance.enemy_three.isAlive)
                {
                    enemyCast.Add(EnemyPartyManager.instance.enemy_three);
                }
              

            SelfCaster();

            enemyR = selfECast[Random.Range(0, selfECast.Count)];








        }
        else if (EnemyPartyManager.instance.enemy2)
        {

                if (EnemyPartyManager.instance.enemy_one.isAlive)
                {
                    enemyCast.Add(EnemyPartyManager.instance.enemy_one);

                }

                if (EnemyPartyManager.instance.enemy_two.isAlive) { 
                enemyCast.Add(EnemyPartyManager.instance.enemy_two);
                }


                SelfCaster();
            enemyR = selfECast[Random.Range(0, selfECast.Count)];

        }

        else if (EnemyPartyManager.instance.enemy1 )
        {
           

            enemyCast.Add(EnemyPartyManager.instance.enemy_one);

            enemyR = enemyCast[0];

        }


        BattleManager.intance.enemyCurrentMana -= manaCost;

        MoveToPoint(enemyR.transform.position);
        enemyR.GetComponent<Renderer>().material.SetColor("_SolidOutline", Color.blue);
        enemyR.GetComponent<Renderer>().material.SetFloat("_OutlineEnabled", 1f);
        StartCoroutine(EPlayWait());


        EnemyHandController.intance.epowerHandCards.RemoveAt(cEHandPos);
        EnemyHandController.intance.EsetupCards();

            Destroy(this.gameObject, 3f);
        }
    
    }
    IEnumerator EPlayWait()
    {

        yield return new WaitForSeconds(1.75f);
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        EnRoarAnim();
        enemyR.GetComponent<Renderer>().material.SetFloat("_OutlineEnabled", 0f);
    }

    public void OutLiner()
    {
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

    public void EnRoarAnim()
    {
        GameObject spwanVFX = Instantiate(roarVFX, enemyR.transform.position, Quaternion.identity);
        Destroy(spwanVFX, 0.5f);

    }

public void SelfCaster()
    {

        int randomR = Random.Range(0, enemyCast.Count);
        
        for (int j = 0; j < EnemyHandController.intance.epowerHandCards.Count; j++)
        {


            
                PowerCardTemplate prefabR = EnemyHandController.intance.epowerHandCards[j];



           
            
                if (prefabR.name == "PowerCardERoar(Clone)")
                {
                Debug.Log("oley");



                for (int u = 0; u < enemyCast.Count; u++)
                {
                    for (int s = 0; s < enemyCast[u].masterEnemyDeck.Count; s++)
                    {

                        if (enemyCast[u].masterEnemyDeck[s].name == "PowerCardERoar")
                        {

                            selfECast.Add (enemyCast[u]);


                        }
                    }
                }
               
                   


                }
            
            /* 
          
            if (prefabR.name == enemyCast[randomR].masterEnemyDeck[j].name)
                        {
                
                enemyR = enemyCast[randomR];
                break;
                        }
            else
            {
                SelfCaster();
            }
                
             */



        }


    }


}
