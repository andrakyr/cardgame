using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
public class EnemyHandController : MonoBehaviour
{
    // Start is called before the first frame update
    public static EnemyHandController intance;

    private void Awake()
    {
        intance = this;
    }

    // Start is called before the first frame update
    public List<PowerCardTemplate> epowerHandCards;
    public List<PowerCardTemplate> etempPowerHandCards;
    public List<Transform> ehandPos;
    public Enemy enemyDeck;
    public PowerCardTemplate eprefab1c, eprefab2c, eprefab3c, eprefab4c, eprefab5c;
   
    public List<int> enemyManaCost=new List<int>();

    void Start()
    {
       

    }

    // Update is called once per frame
    void Update()
    {

    }


    public void HandReturner()
    {




    }

    public void EtestHand()
    {


        for (int f = 0; f < enemyDeck.masterEnemyDeck.Count; f++)
        {


            etempPowerHandCards.Add(enemyDeck.masterEnemyDeck[f]);

        }



        eprefab1c = Instantiate(etempPowerHandCards[Random.Range(0, etempPowerHandCards.Count)], transform.position, Quaternion.identity);
        
        eprefab2c = Instantiate(etempPowerHandCards[Random.Range(0, etempPowerHandCards.Count)], transform.position, Quaternion.identity);
        
        eprefab3c = Instantiate(etempPowerHandCards[Random.Range(0, etempPowerHandCards.Count)], transform.position, Quaternion.identity);
        
        eprefab4c = Instantiate(etempPowerHandCards[Random.Range(0, etempPowerHandCards.Count)], transform.position, Quaternion.identity);
        
        eprefab5c = Instantiate(etempPowerHandCards[Random.Range(0, etempPowerHandCards.Count)], transform.position, Quaternion.identity);
        
     
        if (EnemyPartyManager.instance.enemy3)
        {

            epowerHandCards.Add(eprefab1c);
            epowerHandCards.Add(eprefab2c);
            epowerHandCards.Add(eprefab3c);
            epowerHandCards.Add(eprefab4c);
            epowerHandCards.Add(eprefab5c);

           


        }
        else if (EnemyPartyManager.instance.enemy2)
        {

            epowerHandCards.Add(eprefab1c);
            epowerHandCards.Add(eprefab2c);
            epowerHandCards.Add(eprefab3c);
            epowerHandCards.Add(eprefab4c);
          
      

        }

        else if (EnemyPartyManager.instance.enemy1)
        {

            epowerHandCards.Add(eprefab1c);
            epowerHandCards.Add(eprefab2c);
            epowerHandCards.Add(eprefab3c);
            Debug.Log("Merhaba");
        }



        EsetupCards();


    }
    public void EsetupCards()
    {

        for (int v = 0; v < epowerHandCards.Count; v++)
        {



            epowerHandCards[v].MoveToPoint(ehandPos[v].position);
            epowerHandCards[v].inEHand = true;
            epowerHandCards[v].cEHandPos = v;

        }



    }

    public void clearHand()
    {



        for (int v = 0; v < epowerHandCards.Count; v++)
        {


            epowerHandCards[v].TheDestroyer();

        }


        enemyDeck.masterEnemyDeck.Clear();
       epowerHandCards.Clear();
        etempPowerHandCards.Clear();

    }
   
    
    
    
    
    
    public void EsetMasterDeck()
    {

        if (EnemyPartyManager.instance.enemy3)
        {

            if (EnemyPartyManager.instance.enemy_one.isAlive) { enemyDeck.masterEnemyDeck.AddRange(EnemyPartyManager.instance.enemy_one.masterEnemyDeck); }
            if (EnemyPartyManager.instance.enemy_two.isAlive) { enemyDeck.masterEnemyDeck.AddRange(EnemyPartyManager.instance.enemy_two.masterEnemyDeck); }
            if (EnemyPartyManager.instance.enemy_three.isAlive){ enemyDeck.masterEnemyDeck.AddRange(EnemyPartyManager.instance.enemy_three.masterEnemyDeck); }
           

        }
        else if (EnemyPartyManager.instance.enemy2)
        {

            if (EnemyPartyManager.instance.enemy_one.isAlive) { enemyDeck.masterEnemyDeck.AddRange(EnemyPartyManager.instance.enemy_one.masterEnemyDeck); }
            if (EnemyPartyManager.instance.enemy_two.isAlive) { enemyDeck.masterEnemyDeck.AddRange(EnemyPartyManager.instance.enemy_two.masterEnemyDeck); }


        }

        else if (EnemyPartyManager.instance.enemy1)
        {

            
            if (EnemyPartyManager.instance.enemy_one.isAlive) { enemyDeck.masterEnemyDeck.AddRange(EnemyPartyManager.instance.enemy_one.masterEnemyDeck); }


        }
    }
}
