using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Ally : Character
{
    [SerializeField] public float SPEED;
    [SerializeField] public float currentSPEED;
    [SerializeField] public int moneyNeeded;

    public bool isEmployed = false;
    public bool isEntrusted = false;

    public enum Job {Swordsman,  Knight, Archer, Wizard, Priest};

    //private List<Skill> skillsOfAlly;
    //private Equipment equipment;
    
}
