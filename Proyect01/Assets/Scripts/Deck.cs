using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour {

    public List<GameObject> mainDeck = new List<GameObject>();
    public List<GameObject> hand = new List<GameObject>();
    public List<GameObject> tryDeck = new List<GameObject>();
    public GameObject card2Add;
    public int hand1stDraw;
    public int deckMaxCards;
    public int cardCounter;
    public int deckMinCards;

}
