using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Card", menuName = "Deck Tool/Card", order = 1)]
public class CardSO : ScriptableObject {
    //Cual es la clase base, esta o la basecard?

    List<string> CardType = new List<string>();
    public int life;
    public int energy;
    public int attack;
    public int defense;
    public int mana;
    public int stars;
    public string description;
    public Texture illustration;
    public Texture frame;
    public Texture background;
    public Texture back;
    public string cardname;
    public string autorSign;
    public string cardtype;
    public int cost;
    public string ability;

}
