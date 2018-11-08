using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour {

    public List<BaseCard> mainDeck = new List<BaseCard>();
    public List<BaseCard> hand = new List<BaseCard>();
    public List<BaseCard> tryDeck = new List<BaseCard>();
    public BaseCard card2Add;
    public int hand1stDraw;
    public int deckMaxCards;
    public int cardCounter;
    public int deckMinCards;

}
