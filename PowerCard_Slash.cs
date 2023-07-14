using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerCard_Slash : PowerCardTemplate
{
    // Start is called before the first frame update
    
    public LayerMask groundS,enemyX;
    public Enemy enemyS;
    public GameObject slashVFX;
    
    void Start()
    {
        if (targetPoint == Vector3.zero)
        {

            targetPoint = transform.position;
        }

        powerC = GetComponent<Collider>();

    }

    // Update is called once per frame
    void Update()
    {

        transform.position = Vector3.Lerp(transform.position, targetPoint, 3f * Time.deltaTime);

        if (isSelected)
        {
            Debug.Log("selected");
            Ray rayX = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitX;
            


            if (Physics.Raycast(rayX, out hitX, 100f, groundS))
            {

                Debug.Log("ray-hit");
                targetPoint = hitX.point;

              
                

            }
            Ray rayS = new Ray(transform.position, transform.forward);
            RaycastHit hitS;
                if (Physics.Raycast(rayS, out hitS, 100f,enemyX))
                {
                
                    Debug.Log("rayzzz");
                    enemyS = hitS.transform.gameObject.GetComponent<Enemy>();
                    enemyS.GetComponent<Renderer>().material.SetColor("_SolidOutline", Color.red);
                    enemyS.GetComponent<Renderer>().material.SetFloat("_OutlineEnabled", 1f);
                actionS();
              
                }
                else
            {
                enemyS.GetComponent<Renderer>().material.SetFloat("_OutlineEnabled", 0f);
                

            }

         
        }

        if (Input.GetMouseButtonDown(0) && justPressed == false)
        {
            Debug.Log("return");
            
            
            ReturnToHand();
            enemyS.GetComponent<Renderer>().material.SetFloat("_OutlineEnabled", 0f);
           
       

        }








        justPressed = false;
    }


    private void OnMouseDown()
    {
        if (inHand&&BattleManager.intance.state == BattleManager.BattleState.PlayerTurn)
        {
            isSelected = true;
            justPressed = true;
            powerC.enabled = false;
        }
    }


   

    public void actionS()
    {
        if (Input.GetMouseButtonDown(0) && justPressed == false && enemyS.GetComponent<SpriteRenderer>().enabled)
        {
            enemyS.Damager(50f);
            GameObject spwanhVFX = Instantiate(slashVFX, enemyS.transform.position, Quaternion.identity);
            Destroy(spwanhVFX, 0.5f);
            enemyS.GetComponent<Renderer>().material.SetFloat("_OutlineEnabled", 0f);
            
            HeroHandController.intance.powerHandCards.RemoveAt(cHandPos);

           
            HeroHandController.intance.setupCards();
            DestroyImmediate(this.gameObject);
        }
    }

}
