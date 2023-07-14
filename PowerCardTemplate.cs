using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PowerCardTemplate : MonoBehaviour
{
    // Start is called before the first frame update


    public bool isSelected;
    public Vector3 targetPoint=Vector3.zero;
    public LayerMask groundX;
    public bool justPressed;
    public Collider powerC;
    public int cHandPos,cEHandPos;
    public bool inHand,inEHand, isPlayable;
    public int manaCost;
    
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

        transform.position = Vector3.Lerp(transform.position, targetPoint, 10f*Time.deltaTime);
        
        if (isSelected)
        {
            Debug.Log("selected");
            Ray rayX = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitX;
            if (Physics.Raycast(rayX, out hitX,100f, groundX)) {
                Debug.Log("ray hit");
                MoveToPoint(hitX.point);
                
               
            }
            
        }

        if (Input.GetMouseButtonDown(0) && justPressed == false)
        {
            Debug.Log("return");
            ReturnToHand();

        }

        justPressed = false;
    }


    private void OnMouseDown()
    {

        if(inHand&& BattleManager.intance.state == BattleManager.BattleState.PlayerTurn)
        {
            isSelected = true;
            justPressed = true;
            powerC.enabled = false; }
    }

    public void MoveToPoint(Vector3 pointMove)
    {

        targetPoint = pointMove;




    }

    public void ReturnToHand()
    {
        isSelected = false;
        powerC.enabled = true;

        if (inEHand)
        {
            MoveToPoint(EnemyHandController.intance.ehandPos[cEHandPos].position);
        }
        else if (inHand)
        {

            MoveToPoint(HeroHandController.intance.handPos[cHandPos].position);
        }
        
       
    }
    public void TheDestroyer()
    {
        DestroyImmediate(this.gameObject);

    }


    public virtual void OnEplay ()
    
    { }
}
