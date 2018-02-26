using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MorseDictionary
{
    private static Dictionary<char, string> dictionaryLetterToMorse = new Dictionary<char, string>()
            {
                {'a', string.Concat(Morse.DOT, Morse.DASH)},
                {'b', string.Concat(Morse.DASH, Morse.DOT, Morse.DOT, Morse.DOT)},
                {'c', string.Concat(Morse.DASH, Morse.DOT, Morse.DASH, Morse.DOT)},
                {'d', string.Concat(Morse.DASH, Morse.DOT, Morse.DOT)},
                {'e', Morse.DOT.ToString()},
                {'f', string.Concat(Morse.DOT, Morse.DOT, Morse.DASH, Morse.DOT)},
                {'g', string.Concat(Morse.DASH, Morse.DASH, Morse.DOT)},
                {'h', string.Concat(Morse.DOT, Morse.DOT, Morse.DOT, Morse.DOT)},
                {'i', string.Concat(Morse.DOT, Morse.DOT)},
                {'j', string.Concat(Morse.DOT, Morse.DASH, Morse.DASH, Morse.DASH)},
                {'k', string.Concat(Morse.DASH, Morse.DOT, Morse.DASH)},
                {'l', string.Concat(Morse.DOT, Morse.DASH, Morse.DOT, Morse.DOT)},
                {'m', string.Concat(Morse.DASH, Morse.DASH)},
                {'n', string.Concat(Morse.DASH, Morse.DOT)},
                {'o', string.Concat(Morse.DASH, Morse.DASH, Morse.DASH)},
                {'p', string.Concat(Morse.DOT, Morse.DASH, Morse.DASH, Morse.DOT)},
                {'q', string.Concat(Morse.DASH, Morse.DASH, Morse.DOT, Morse.DASH)},
                {'r', string.Concat(Morse.DOT, Morse.DASH, Morse.DOT)},
                {'s', string.Concat(Morse.DOT, Morse.DOT, Morse.DOT)},
                {'t', string.Concat(Morse.DASH)},
                {'u', string.Concat(Morse.DOT, Morse.DOT, Morse.DASH)},
                {'v', string.Concat(Morse.DOT, Morse.DOT, Morse.DOT, Morse.DASH)},
                {'w', string.Concat(Morse.DOT, Morse.DASH, Morse.DASH)},
                {'x', string.Concat(Morse.DASH, Morse.DOT, Morse.DOT, Morse.DASH)},
                {'y', string.Concat(Morse.DASH, Morse.DOT, Morse.DASH, Morse.DASH)},
                {'z', string.Concat(Morse.DASH, Morse.DASH, Morse.DOT, Morse.DOT)},
                {'0', string.Concat(Morse.DASH, Morse.DASH, Morse.DASH, Morse.DASH, Morse.DASH)},
                {'1', string.Concat(Morse.DOT, Morse.DASH, Morse.DASH, Morse.DASH, Morse.DASH)},
                {'2', string.Concat(Morse.DOT, Morse.DOT, Morse.DASH, Morse.DASH, Morse.DASH)},
                {'3', string.Concat(Morse.DOT, Morse.DOT, Morse.DOT, Morse.DASH, Morse.DASH)},
                {'4', string.Concat(Morse.DOT, Morse.DOT, Morse.DOT, Morse.DOT, Morse.DASH)},
                {'5', string.Concat(Morse.DOT, Morse.DOT, Morse.DOT, Morse.DOT, Morse.DOT)},
                {'6', string.Concat(Morse.DASH, Morse.DOT, Morse.DOT, Morse.DOT, Morse.DOT)},
                {'7', string.Concat(Morse.DASH, Morse.DASH, Morse.DOT, Morse.DOT, Morse.DOT)},
                {'8', string.Concat(Morse.DASH, Morse.DASH, Morse.DASH, Morse.DOT, Morse.DOT)},
                {'9', string.Concat(Morse.DASH, Morse.DASH, Morse.DASH, Morse.DASH, Morse.DOT)},
                {'.', string.Concat(Morse.DOT, Morse.DASH, Morse.DOT, Morse.DASH, Morse.DOT, Morse.DASH)},
                {',', string.Concat(Morse.DASH, Morse.DASH, Morse.DOT, Morse.DOT, Morse.DASH, Morse.DASH)},
                {'?', string.Concat(Morse.DOT, Morse.DOT, Morse.DASH, Morse.DASH, Morse.DOT, Morse.DOT)},
                {'!', string.Concat(Morse.DASH, Morse.DOT, Morse.DASH, Morse.DOT, Morse.DASH, Morse.DASH)},
                //{'-', string.Concat(Morse.DASH, Morse.DOT, Morse.DOT, Morse.DOT, Morse.DOT, Morse.DASH)}, // hyphen, same on keyboard, diferent from minus - , same morse code
                {'/', string.Concat(Morse.DASH, Morse.DOT, Morse.DOT, Morse.DASH, Morse.DOT)},
                {':', string.Concat(Morse.DASH, Morse.DASH, Morse.DASH, Morse.DOT, Morse.DOT, Morse.DOT)},
                {'\'', string.Concat(Morse.DOT, Morse.DASH, Morse.DASH, Morse.DASH, Morse.DASH, Morse.DOT)}, // ' character
                {'-', string.Concat(Morse.DASH, Morse.DOT, Morse.DOT, Morse.DOT, Morse.DOT, Morse.DASH)}, // minus symbol
                {')', string.Concat(Morse.DASH, Morse.DOT, Morse.DASH, Morse.DASH, Morse.DOT, Morse.DASH)},
                {';', string.Concat(Morse.DASH, Morse.DOT, Morse.DASH, Morse.DOT, Morse.DASH)},
                {'(', string.Concat(Morse.DASH, Morse.DOT, Morse.DASH, Morse.DASH, Morse.DOT)},
                {'=', string.Concat(Morse.DASH, Morse.DOT, Morse.DOT, Morse.DOT, Morse.DASH)},
                {'@', string.Concat(Morse.DOT, Morse.DASH, Morse.DASH, Morse.DOT, Morse.DASH, Morse.DOT)},
                {'&', string.Concat(Morse.DOT, Morse.DASH, Morse.DOT, Morse.DOT, Morse.DOT)},
                {' ', " "}
            };

    private static Dictionary<string, char> dictionaryMorseToLetter = new Dictionary<string, char>()
            {
                {string.Concat(Morse.DOT, Morse.DASH), 'a'},
                {string.Concat(Morse.DASH, Morse.DOT, Morse.DOT, Morse.DOT), 'b'},
                {string.Concat(Morse.DASH, Morse.DOT, Morse.DASH, Morse.DOT), 'c'},
                {string.Concat(Morse.DASH, Morse.DOT, Morse.DOT), 'd'},
                {Morse.DOT.ToString(), 'e'},
                {string.Concat(Morse.DOT, Morse.DOT, Morse.DASH, Morse.DOT), 'f'},
                {string.Concat(Morse.DASH, Morse.DASH, Morse.DOT), 'g'},
                {string.Concat(Morse.DOT, Morse.DOT, Morse.DOT, Morse.DOT), 'h'},
                {string.Concat(Morse.DOT, Morse.DOT), 'i'},
                {string.Concat(Morse.DOT, Morse.DASH, Morse.DASH, Morse.DASH), 'j'},
                {string.Concat(Morse.DASH, Morse.DOT, Morse.DASH), 'k'},
                {string.Concat(Morse.DOT, Morse.DASH, Morse.DOT, Morse.DOT), 'l'},
                {string.Concat(Morse.DASH, Morse.DASH), 'm'},
                {string.Concat(Morse.DASH, Morse.DOT), 'n'},
                {string.Concat(Morse.DASH, Morse.DASH, Morse.DASH), 'o'},
                {string.Concat(Morse.DOT, Morse.DASH, Morse.DASH, Morse.DOT), 'p'},
                {string.Concat(Morse.DASH, Morse.DASH, Morse.DOT, Morse.DASH), 'q'},
                {string.Concat(Morse.DOT, Morse.DASH, Morse.DOT), 'r'},
                {string.Concat(Morse.DOT, Morse.DOT, Morse.DOT), 's'},
                {string.Concat(Morse.DASH), 't'},
                {string.Concat(Morse.DOT, Morse.DOT, Morse.DASH), 'u'},
                {string.Concat(Morse.DOT, Morse.DOT, Morse.DOT, Morse.DASH), 'v'},
                {string.Concat(Morse.DOT, Morse.DASH, Morse.DASH), 'w' },
                {string.Concat(Morse.DASH, Morse.DOT, Morse.DOT, Morse.DASH), 'x'},
                {string.Concat(Morse.DASH, Morse.DOT, Morse.DASH, Morse.DASH), 'y'},
                {string.Concat(Morse.DASH, Morse.DASH, Morse.DOT, Morse.DOT), 'z'},
                {string.Concat(Morse.DASH, Morse.DASH, Morse.DASH, Morse.DASH, Morse.DASH), '0'},
                {string.Concat(Morse.DOT, Morse.DASH, Morse.DASH, Morse.DASH, Morse.DASH), '1'},
                {string.Concat(Morse.DOT, Morse.DOT, Morse.DASH, Morse.DASH, Morse.DASH), '2'},
                {string.Concat(Morse.DOT, Morse.DOT, Morse.DOT, Morse.DASH, Morse.DASH), '3'},
                {string.Concat(Morse.DOT, Morse.DOT, Morse.DOT, Morse.DOT, Morse.DASH), '4'},
                {string.Concat(Morse.DOT, Morse.DOT, Morse.DOT, Morse.DOT, Morse.DOT), '5'},
                {string.Concat(Morse.DASH, Morse.DOT, Morse.DOT, Morse.DOT, Morse.DOT), '6'},
                {string.Concat(Morse.DASH, Morse.DASH, Morse.DOT, Morse.DOT, Morse.DOT), '7'},
                {string.Concat(Morse.DASH, Morse.DASH, Morse.DASH, Morse.DOT, Morse.DOT), '8'},
                {string.Concat(Morse.DASH, Morse.DASH, Morse.DASH, Morse.DASH, Morse.DOT), '9'},
                {string.Concat(Morse.DOT, Morse.DASH, Morse.DOT, Morse.DASH, Morse.DOT, Morse.DASH),  '.'},
                {string.Concat(Morse.DASH, Morse.DASH, Morse.DOT, Morse.DOT, Morse.DASH, Morse.DASH), ','},
                {string.Concat(Morse.DOT, Morse.DOT, Morse.DASH, Morse.DASH, Morse.DOT, Morse.DOT),   '?'},
                {string.Concat(Morse.DASH, Morse.DOT, Morse.DASH, Morse.DOT, Morse.DASH, Morse.DASH), '!'},
                // {string.Concat(Morse.DASH, Morse.DOT, Morse.DOT, Morse.DOT, Morse.DOT, Morse.DASH),   '-'},     // hyphen, same on keyboard, diferent from minus - , same morse code
                {string.Concat(Morse.DASH, Morse.DOT, Morse.DOT, Morse.DASH, Morse.DOT),              '/'},
                {string.Concat(Morse.DASH, Morse.DASH, Morse.DASH, Morse.DOT, Morse.DOT, Morse.DOT),  ':'},
                { string.Concat(Morse.DOT, Morse.DASH, Morse.DASH, Morse.DASH, Morse.DASH, Morse.DOT),'\'' },   // ' character
                {string.Concat(Morse.DASH, Morse.DOT, Morse.DOT, Morse.DOT, Morse.DOT, Morse.DASH),   '-'},     // minus symbol
                {string.Concat(Morse.DASH, Morse.DOT, Morse.DASH, Morse.DASH, Morse.DOT, Morse.DASH), ')'},
                {string.Concat(Morse.DASH, Morse.DOT, Morse.DASH, Morse.DOT, Morse.DASH),             ';'},
                {string.Concat(Morse.DASH, Morse.DOT, Morse.DASH, Morse.DASH, Morse.DOT),             '('},
                {string.Concat(Morse.DASH, Morse.DOT, Morse.DOT, Morse.DOT, Morse.DASH),              '='},
                {string.Concat(Morse.DOT, Morse.DASH, Morse.DASH, Morse.DOT, Morse.DASH, Morse.DOT),  '@'},
                {string.Concat(Morse.DOT, Morse.DASH, Morse.DOT, Morse.DOT, Morse.DOT),                '&'},
                {" ", ' '}
            };

    public static char TranslateMorseToLetter(string morseCode)
    {
        return dictionaryMorseToLetter.ContainsKey(morseCode) ? dictionaryMorseToLetter[morseCode] : DefaultAction(morseCode);
    }

    public static string TranslateLetterToMorse(char letter)
    {
        return dictionaryLetterToMorse.ContainsKey(letter) ? dictionaryLetterToMorse[letter] : "";
    }

    public static string TranslateStringToMorse(string text)
    {
        string result = "";
        
        for(int i = 0; i < text.Length; i++)
        {
            result += TranslateLetterToMorse(text[i]);
        }
        Debug.Log("Morse for " + "'" + text + "': " + result);
        return result;
    }

    public static bool IsAttack(string morseCode)
    {
        return morseCode.StartsWith(Morse.DASH.ToString());
    }

    public static bool IsAttack(char letter)
    {
        return dictionaryLetterToMorse.ContainsKey(letter) ? dictionaryLetterToMorse[letter].StartsWith(Morse.DASH.ToString()) : false;
    }

    public static bool IsDefense(string morseCode)
    {
        return morseCode.StartsWith(Morse.DOT.ToString());
    }

    public static bool IsDefense(char letter)
    {
        return dictionaryLetterToMorse.ContainsKey(letter) ? dictionaryLetterToMorse[letter].StartsWith(Morse.DOT.ToString()) : false;
    }

    public static bool IsChargeable(string morseCode)
    {
        return morseCode.EndsWith(Morse.DASH.ToString());
    }

    private static char DefaultAction(string morseCode)
    {
        return TranslateMorseToLetter( morseCode[0].ToString());
    }


}
