using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FirstFighter : MonoBehaviour {


    public Text ChooseFighter;

    public void HighlightPoke()
    {
        ChooseFighter.text = "Who will you choose?";
    }
    public void HiglightPika()
    {
        ChooseFighter.text = "Pikachu";
    }
    public void HighlightRai()
    {
        ChooseFighter.text = "Raichu";
    }
    public void HighlightGr()
    {
        ChooseFighter.text = "Growlithe";
    }
    public void HighlightEv()
    {
        ChooseFighter.text = "Eevee";
    }
    public void HighlightMu()
    {
        ChooseFighter.text = "Mudkip";
    }
    public void HighlightPs()
    {
        ChooseFighter.text = "Psyduck";
    }
}
