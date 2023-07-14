using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAIManager : MonoBehaviour
{

    public static EnemyAIManager instance;
    public List<PowerCardTemplate> unplayebleCards;


    private void Awake()
    {
        instance = this;
    }

    public PowerCardTemplate playCard;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      
    }

public void SelectCard()
    {


       int airandom = Random.Range(0, EnemyHandController.intance.epowerHandCards.Count);


        if (EnemyHandController.intance.epowerHandCards[airandom].isPlayable)
        {
            if (BattleManager.intance.state == BattleManager.BattleState.EnemyTurn)
            {
                playCard = EnemyHandController.intance.epowerHandCards[airandom];

                playCard.OnEplay();
            }
        }
        
    }


}
