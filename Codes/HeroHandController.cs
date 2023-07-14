using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HeroHandController : MonoBehaviour
{
    
    public static HeroHandController intance;
    int aliveChecker;
    private void Awake()
    {
        intance = this;
    }

    // Start is called before the first frame update
    public List<PowerCardTemplate> powerHandCards;
    public List<PowerCardTemplate> tempPowerHandCards;
    public List<Transform> handPos;
    public Hero heroDeck;
    public PowerCardTemplate prefab1c,prefab2c,prefab3c,prefab4c,prefab5c;
   


    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void HandReturner() {


  

    }

    public void testHand()
    {

      
        for(int f = 0; f < heroDeck.masterDeck.Count; f++)
        {

          
            tempPowerHandCards.Add(heroDeck.masterDeck[f]);

        }
     

            prefab1c = Instantiate(tempPowerHandCards[Random.Range(0,tempPowerHandCards.Count)], transform.position, Quaternion.identity);
            prefab2c = Instantiate(tempPowerHandCards[Random.Range(0, tempPowerHandCards.Count)], transform.position, Quaternion.identity);
            prefab3c = Instantiate(tempPowerHandCards[Random.Range(0, tempPowerHandCards.Count)], transform.position, Quaternion.identity);
            prefab4c = Instantiate(tempPowerHandCards[Random.Range(0, tempPowerHandCards.Count)], transform.position, Quaternion.identity);
            prefab5c = Instantiate(tempPowerHandCards[Random.Range(0, tempPowerHandCards.Count)], transform.position, Quaternion.identity);

        if (HeroPartyManager.instance.hero3)
        {


            AliveCounter();
          

           
            Debug.Log("alive= "+aliveChecker);
            if (aliveChecker == 3)
            {
                powerHandCards.Add(prefab1c);
                powerHandCards.Add(prefab2c);
                powerHandCards.Add(prefab3c);
                powerHandCards.Add(prefab4c);
                powerHandCards.Add(prefab5c);
            }
            else if (aliveChecker == 2)
            {
                powerHandCards.Add(prefab1c);
                powerHandCards.Add(prefab2c);
                powerHandCards.Add(prefab3c);
                powerHandCards.Add(prefab4c);
            }
            else if (aliveChecker == 1)
            {
                powerHandCards.Add(prefab1c);
                powerHandCards.Add(prefab2c);
                powerHandCards.Add(prefab3c);
               
            }


        }
        else if (HeroPartyManager.instance.hero2)
        {
            for (int l = 0; l > HeroPartyManager.instance.heroPartyMember.Count; l++)
            {

                if (HeroPartyManager.instance.heroPartyMember[0].isAlive)
                {

                    aliveChecker++;

                }

            }

          
             if (aliveChecker == 2)
            {
                powerHandCards.Add(prefab1c);
                powerHandCards.Add(prefab2c);
                powerHandCards.Add(prefab3c);
                powerHandCards.Add(prefab4c);
            }
            else if (aliveChecker == 1)
            {
                powerHandCards.Add(prefab1c);
                powerHandCards.Add(prefab2c);
                powerHandCards.Add(prefab3c);

            }


        }

        else if (HeroPartyManager.instance.hero1)
        {

            powerHandCards.Add(prefab1c);
            powerHandCards.Add(prefab2c);
            powerHandCards.Add(prefab3c);

        }



        setupCards();


    }
    public void setupCards()
    {

        for (int v = 0; v < powerHandCards.Count; v++)
        {



            powerHandCards[v].MoveToPoint(handPos[v].position);
            powerHandCards[v].inHand = true;
            powerHandCards[v].cHandPos = v;

        }



    }

    public void clearHand()
    {
       
        
        
        for (int v = 0; v < powerHandCards.Count; v++)
        {
            
            
                powerHandCards[v].TheDestroyer();
            

        }



        powerHandCards.Clear();
        tempPowerHandCards.Clear();
        heroDeck.masterDeck.Clear();
    }
    public void setMasterDeck()
    {
       
        if(HeroPartyManager.instance.hero3)
        {
            if (HeroPartyManager.instance.hero_one.isAlive)
            {
                heroDeck.masterDeck.AddRange(HeroPartyManager.instance.hero_one.masterDeck);
            }
            if (HeroPartyManager.instance.hero_two.isAlive)
            {
                heroDeck.masterDeck.AddRange(HeroPartyManager.instance.hero_two.masterDeck);
            }
            if (HeroPartyManager.instance.hero_three.isAlive)
            {
                heroDeck.masterDeck.AddRange(HeroPartyManager.instance.hero_three.masterDeck);
            }
   

        }
        else if (HeroPartyManager.instance.hero2)
        {

            if (HeroPartyManager.instance.hero_one.isAlive)
            {
                heroDeck.masterDeck.AddRange(HeroPartyManager.instance.hero_one.masterDeck);
            }
            if (HeroPartyManager.instance.hero_two.isAlive)
            {
                heroDeck.masterDeck.AddRange(HeroPartyManager.instance.hero_two.masterDeck);
            }


        }

        else if (HeroPartyManager.instance.hero1)
        {

            if (HeroPartyManager.instance.hero_one.isAlive)
            {
                heroDeck.masterDeck.AddRange(HeroPartyManager.instance.hero_one.masterDeck);
            }

        }

    }

    public void AliveCounter()
    {

        Debug.Log("I'm SuperAlive");
        aliveChecker = 0;
        
      

            if (HeroPartyManager.instance.heroPartyMemberActive[0].currentHP>0)
            {

            aliveChecker++;

            }
        if (HeroPartyManager.instance.heroPartyMemberActive[1].currentHP > 0)
        {

            aliveChecker++;

        }
        if (HeroPartyManager.instance.heroPartyMemberActive[2].currentHP > 0)
        {

            aliveChecker++;

        }

    }

}
