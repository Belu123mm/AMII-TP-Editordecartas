using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCard : MonoBehaviour {

    //o mesh renderer
    public SpriteRenderer image;
    List<string> CardType = new List<string>();
    public int life;
    public int energy;
    public int atack;
    public int defense;
    //public List<Tuple<float, string>> PayCost;
    public int manaCost;
    public int stars;
    public string description;
    public SpriteRenderer backgroundCard;
    public SpriteRenderer framework;
    public string cardName;
    public string autorSign;


    private void Start()
    {
        // PayCost = new List<Tuple<float, string>>();
    }

    

}
