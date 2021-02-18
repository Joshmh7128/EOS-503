using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : NPC
{
    public override void OnMadeChoice(string id, int num)
    {
        switch(id)
        {
            case "xxxx":
                if (num == 0)
                {
                    myTalk.NewTalk("1xxx-start", "1xxx-end");
                }
                else if (num == 1)
                {
                    myTalk.NewTalk("0xxx-a-start", "0xxx-a-end");
                }
                else if (num == 2)
                {
                    myTalk.NewTalk("0xxx-b-start", "0xxx-b-end");
                }
                break;
            case "0xxx":
                if (num == 0)
                {
                    myTalk.NewTalk("01xx-start", "01xx-end");
                }
                else if (num == 1)
                {
                    myTalk.NewTalk("00xx-a-start", "00xx-a-end");
                }
                else if (num == 2)
                {
                    myTalk.NewTalk("00xx-b-start", "00xx-b-end");
                }
                break;
            case "00xx":
                if (num == 0)
                {
                    myTalk.NewTalk("001x-start", "001x-end");
                }
                else if (num == 1)
                {
                    myTalk.NewTalk("000x-a-start", "000x-a-end");
                }
                else if (num == 2)
                {
                    myTalk.NewTalk("000x-b-start", "000x-b-end");
                }
                break;
            case "1xxx":
                if (num == 0)
                {
                    myTalk.NewTalk("11xx-start", "11xx-end");
                }
                else if (num == 1)
                {
                    myTalk.NewTalk("10xx-a-start", "10xx-a-end");
                }
                else if (num == 2)
                {
                    myTalk.NewTalk("10xx-b-start", "10xx-b-end");
                }
                break;
            case "01xx":
                if (num == 0)
                {
                    myTalk.NewTalk("011x-start", "011x-end");
                }
                else if (num == 1)
                {
                    myTalk.NewTalk("010x-a-start", "010x-a-end");
                }
                else if (num == 2)
                {
                    myTalk.NewTalk("010x-b-start", "010x-b-end");
                }
                break;
            case "001x":
                if (num == 0)
                {
                    myTalk.NewTalk("0011-start", "0011-end");
                }
                else if (num == 1)
                {
                    myTalk.NewTalk("0010-a-start", "0010-a-end");
                }
                else if (num == 2)
                {
                    myTalk.NewTalk("0010-b-start", "0010-b-end");
                }
                break;
            case "10xx":
                if (num == 0)
                {
                    myTalk.NewTalk("101x-start", "101x-end");
                }
                else if (num == 1)
                {
                    myTalk.NewTalk("100x-a-start", "100x-a-end");
                }
                else if (num == 2)
                {
                    myTalk.NewTalk("100x-b-start", "100x-b-end");
                }
                break;
            case "010x":
                if (num == 0)
                {
                    myTalk.NewTalk("0101-start", "0101-end");
                }
                else if (num == 1)
                {
                    myTalk.NewTalk("0100-a-start", "0100-a-end");
                }
                else if (num == 2)
                {
                    myTalk.NewTalk("0100-b-start", "0100-b-end");
                }
                break;
            case "100x":
                if (num == 0)
                {
                    myTalk.NewTalk("1001-start", "1001-end");
                }
                else if (num == 1)
                {
                    myTalk.NewTalk("1000-a-start", "1000-a-end");
                }
                else if (num == 2)
                {
                    myTalk.NewTalk("1000-b-start", "1000-b-end");
                }
                break;
            case "11xx":
                if (num == 0)
                {
                    myTalk.NewTalk("win-start", "win-end");
                }
                else if (num == 1)
                {
                    myTalk.NewTalk("110x-a-start", "110x-a-end");
                }
                else if (num == 2)
                {
                    myTalk.NewTalk("110x-b-start", "110x-b-end");
                }
                break;
            case "101x":
                if (num == 0)
                {
                    myTalk.NewTalk("win-start", "win-end");
                }
                else if (num == 1)
                {
                    myTalk.NewTalk("1010-a-start", "1010-a-end");
                }
                else if (num == 2)
                {
                    myTalk.NewTalk("1010-b-start", "1010-b-end");
                }
                break;
            case "1001":
                if (num == 0)
                {
                    myTalk.NewTalk("win-start", "win-end");
                }
                else if (num == 1)
                {
                    myTalk.NewTalk("10010-a-start", "10010-a-end");
                }
                else if (num == 2)
                {
                    myTalk.NewTalk("10010-b-start", "10010-b-end");
                }
                break;
            case "011x":
                if (num == 0)
                {
                    myTalk.NewTalk("win-start", "win-end");
                }
                else if (num == 1)
                {
                    myTalk.NewTalk("0110-a-start", "0110-a-end");
                }
                else if (num == 2)
                {
                    myTalk.NewTalk("0110-b-start", "0110-b-end");
                }
                break;
            case "0101":
                if (num == 0)
                {
                    myTalk.NewTalk("win-start", "win-end");
                }
                else if (num == 1)
                {
                    myTalk.NewTalk("01010-a-start", "01010-a-end");
                }
                else if (num == 2)
                {
                    myTalk.NewTalk("01010-b-start", "01010-b-end");
                }
                break;
            case "0011":
                if (num == 0)
                {
                    myTalk.NewTalk("win-start", "win-end");
                }
                else if (num == 1)
                {
                    myTalk.NewTalk("00110-a-start", "00110-a-end");
                }
                else if (num == 2)
                {
                    myTalk.NewTalk("00110-b-start", "00110-b-end");
                }
                break;
            case "110x":
                if (num == 0)
                {
                    myTalk.NewTalk("win-start", "win-end");
                }
                else if (num == 1)
                {
                    myTalk.NewTalk("1100-a-start", "1100-a-end");
                }
                else if (num == 2)
                {
                    myTalk.NewTalk("1100-b-start", "1100-b-end");
                }
                break;
            case "1010":
                if (num == 0)
                {
                    myTalk.NewTalk("win-start", "win-end");
                }
                else if (num == 1)
                {
                    myTalk.NewTalk("10100-a-start", "10100-a-end");
                }
                else if (num == 2)
                {
                    myTalk.NewTalk("10100-b-start", "10100-b-end");
                }
                break;
            case "0110":
                if (num == 0)
                {
                    myTalk.NewTalk("win-start", "win-end");
                }
                else if (num == 1)
                {
                    myTalk.NewTalk("01100-a-start", "01100-a-end");
                }
                else if (num == 2)
                {
                    myTalk.NewTalk("01100-b-start", "01100-b-end");
                }
                break;
            case "1100":
                if (num == 0)
                {
                    myTalk.NewTalk("win-start", "win-end");
                }
                else if (num == 1)
                {
                    myTalk.NewTalk("11000-a-start", "11000-a-end");
                }
                else if (num == 2)
                {
                    myTalk.NewTalk("11000-b-start", "11000-b-end");
                }
                break;
        }
    }
}
