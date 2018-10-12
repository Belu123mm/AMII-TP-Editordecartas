using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCard : MonoBehaviour {

    //o mesh renderer
    public Texture2D illustration;
    List<string> CardType = new List<string>();
    public int life;
    public int energy;
    public int attack;
    public int defense;
    //public List<Tuple<float, string>> PayCost;
    public int mana;
    public int stars;
    public string description;
    public Texture2D background;
    public Texture2D frame;
    public Texture2D back;
    public string cardname;
    public string autorSign;
    public string cardtype;
    public int cost;
    public string ability;


    private void Start()
    {
        // PayCost = new List<Tuple<float, string>>();
    }

    

}
