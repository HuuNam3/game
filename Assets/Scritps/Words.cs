using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Word
{
    public string word;

    private int typeIndex;

    WordDisplay display;
    public Word(string _word, WordDisplay _display)
    {
        word = _word;
        typeIndex = 0;
        display=  _display;
        display.SetWord(word);
    }

    public char GetNextLetter()
    {
        return word[typeIndex];
    }
    public void typeLetter()
    {
        typeIndex++;
        display.removeLetter();
    }
    public bool Typed() 
    {
        bool WordType = (typeIndex>= word.Length);

        if(WordType)
        {
            display.RemoveWord();
        }
        return WordType;
    }

    public string getWord()
    {
        return this.word;
    }

    public WordDisplay getDisplay()
    {
        return display;
    }
}