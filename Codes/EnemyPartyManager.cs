using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPartyManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static EnemyPartyManager instance;


    public List<Enemy> enemyPartyMember;
    public List<Transform> enemyPos;
    public Enemy enemy_one, enemy_two, enemy_three;
    public bool enemy1, enemy2, enemy3;

    private void Awake()
    {
        instance = this;
    }


    void Start()
    {
       
        
       
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void insEPartyMember()
    {

        if (enemyPartyMember.Count==1)
        {

            enemy_one = Instantiate(enemyPartyMember[0], enemyPos[2].position, Quaternion.identity);
            enemy_one.transform.SetParent(this.transform, true);
            

            DestroyImmediate(enemy_two);
            DestroyImmediate(enemy_three);
            enemy1 = true;
        }
        else if (enemyPartyMember.Count == 2)
        {

            enemy_one = Instantiate(enemyPartyMember[0], enemyPos[2].position, Quaternion.identity);
            enemy_two = Instantiate(enemyPartyMember[1], enemyPos[1].position, Quaternion.identity);
            enemy_one.transform.SetParent(this.transform, true);
            enemy_two.transform.SetParent(this.transform, true);
            
            DestroyImmediate(enemy_three);
            enemy2 = true;
        }
        else if (enemyPartyMember.Count == 3)
        {
            Debug.Log("e tane dusman");
            enemy_one = Instantiate(enemyPartyMember[0], enemyPos[2].position, Quaternion.identity);
            enemy_two = Instantiate(enemyPartyMember[1], enemyPos[1].position, Quaternion.identity);
            enemy_three = Instantiate(enemyPartyMember[2], enemyPos[0].position, Quaternion.identity);
            enemy_one.transform.SetParent(this.transform, true);
            enemy_two.transform.SetParent(this.transform, true);
            enemy_three.transform.SetParent(this.transform, true);
            enemy3 = true;
        }

    }
}
