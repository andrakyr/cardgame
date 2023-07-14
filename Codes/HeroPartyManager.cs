using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroPartyManager : MonoBehaviour
{

    public static HeroPartyManager instance;
    
    
    public List<Hero> heroPartyMember;
    public List<Hero> heroPartyMemberActive;
    public List<Transform> heroPos;
    public Hero hero_one, hero_two, hero_three;
    public bool hero3, hero2, hero1; 

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

   public void insPartyMember() {

        if (heroPartyMember.Count==1)
        {

            hero_one = Instantiate(heroPartyMember[0], heroPos[0].position, Quaternion.identity);
            hero_one.transform.SetParent(this.transform, true);

            heroPartyMemberActive.Add(hero_one);

            DestroyImmediate(hero_two);
            DestroyImmediate(hero_three);
            hero1 = true;
        }
        else  if (heroPartyMember.Count == 2)
        {

            hero_one = Instantiate(heroPartyMember[0], heroPos[0].position, Quaternion.identity);
            hero_two = Instantiate(heroPartyMember[1], heroPos[1].position, Quaternion.identity);
            hero_one.transform.SetParent(this.transform, true);
            hero_two.transform.SetParent(this.transform, true);
            heroPartyMemberActive.Add(hero_one);
            heroPartyMemberActive.Add(hero_two);
            
            DestroyImmediate(hero_three);
            hero2 = true;
        }
        else if (heroPartyMember.Count == 3)
        {

            
            hero_one = Instantiate(heroPartyMember[0], heroPos[0].position, Quaternion.identity);
            hero_two = Instantiate(heroPartyMember[1], heroPos[1].position, Quaternion.identity);
            hero_three = Instantiate(heroPartyMember[2], heroPos[2].position, Quaternion.identity);
            hero_one.transform.SetParent(this.transform, true);
            hero_two.transform.SetParent(this.transform, true);
            hero_three.transform.SetParent(this.transform, true);

            heroPartyMemberActive.Add(hero_one);
            heroPartyMemberActive.Add(hero_two);
            heroPartyMemberActive.Add(hero_three);


            hero3 = true;
        }

    }
    
    public void setPartyMemberPos()
    {



    }


    }
