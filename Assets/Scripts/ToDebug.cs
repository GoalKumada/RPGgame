using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToDebug : MonoBehaviour
{
    void Start()
    {
        foreach (Ally ally in SystemManager.allyComponentsOfCurrentPartyMember)
        {
            Debug.Log(ally.characterName);
        }
        foreach (Sprite sprite in SystemManager.spritesOfCurrentPartyMember)
        {
            Debug.Log(sprite);
        }
        foreach (RuntimeAnimatorController controller in SystemManager.controllersOfCurrentPartyMember)
        {
            Debug.Log(controller);
        }
        foreach (Skill[] skill in SystemManager.skillsOfCurrentPartyMember)
        {
            foreach (Skill s in skill)
            {
                Debug.Log(s.skillName);
            }
        }
    }

    void Update()
    {
        
    }
}