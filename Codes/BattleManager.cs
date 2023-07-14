using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class BattleManager : MonoBehaviour
{

    public static BattleManager intance;
    public enum BattleState {Start,CardDealTurn,PlayerTurn,EnemyTurn,Win,Lose};
    public int enemyMaxMana=5,enemyCurrentMana;
    public BattleState state;

    private void Awake()
    {
        intance = this;
    }

    void Start()
    {
        state = BattleState.Start;
        StartCoroutine (SetupBattle());
        enemyCurrentMana = enemyMaxMana;
    }

    // Update is called once per frame
    void Update()
    {
       
    }


    IEnumerator SetupBattle() {

        

       
        HeroPartyManager.instance.insPartyMember();
        
        EnemyPartyManager.instance.insEPartyMember();

        yield return new WaitForSeconds(0.25f * Time.deltaTime);

        state = BattleState.CardDealTurn;
        StartCoroutine(CardDealer());
      

    }
    IEnumerator CardDealer() {

        yield return new WaitForSeconds(0.5f);
     
        HeroHandController.intance.setMasterDeck();
        HeroHandController.intance.testHand();
        yield return new WaitForSeconds(0.5f);
        EnemyHandController.intance.EsetMasterDeck();
        EnemyHandController.intance.EtestHand();
        yield return new WaitForSeconds(0.1f);
        state = BattleState.PlayerTurn;
        for(int n=0;n< EnemyHandController.intance.epowerHandCards.Count; n++)
        {
            EnemyHandController.intance.enemyManaCost.Add(EnemyHandController.intance.epowerHandCards[n].manaCost);
        }
        
        
        int x = EnemyHandController.intance.enemyManaCost.AsQueryable().Min();
        Debug.Log(x);
        Debug.Log(EnemyHandController.intance.enemyManaCost[0]);
        Debug.Log(EnemyHandController.intance.epowerHandCards[0].manaCost);
    }
    public void endTurn() {

        state = BattleState.EnemyTurn;
        enemyCurrentMana = enemyMaxMana;
        EnemyPlay();
    }

    public void EnemyPlay()
    {

        Debug.Log("hello");
        StartCoroutine(EplayEnemyCards());
        
    }

    IEnumerator EplayEnemyCards()
    {
        while (enemyCurrentMana>0)
        {
            
            EnemyAIManager.instance.SelectCard();
            yield return new WaitForSeconds(3);
            if (EnemyHandController.intance.enemyManaCost.AsQueryable().Min() > enemyCurrentMana)
            {

                break;
            }



             
        }

        state = BattleState.CardDealTurn;
        yield return new WaitForSeconds(0.25f);
        HeroHandController.intance.clearHand();
        yield return new WaitForSeconds(0.25f);
        EnemyHandController.intance.clearHand();
        StartCoroutine(CardDealer());
    }
}
