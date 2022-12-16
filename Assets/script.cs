using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using System.Linq;

public class script : MonoBehaviour
{
    public InputField kafesboyutuInput, toplamInput;
    public int kafesboyutu, toplam;
    public int[] sonucDizi, ornekDizi, durdurmaDizisi;
    public bool swittch;
    public Text[] textler;


    public void Hesapla()
    {
        #region Textboxlari temizleme
        foreach (var item in textler)
        {
            item.text = "";
        }

        #endregion


        //butona tıklandığında kutulara girilenler kafesboyutu ve toplam değişkenlerine atanır.
        #region Input Alma
        kafesboyutu = int.Parse(kafesboyutuInput.text);
        toplam = int.Parse(toplamInput.text);
        #endregion

        #region Sirali Dizi olusturma
        sonucDizi = new int[kafesboyutu];
        ornekDizi = new int[kafesboyutu];
        for (int i = 0; i < kafesboyutu; i++)
        {
            sonucDizi[i] = ornekDizi[i] = i + 1;
        }
        #endregion

        #region Durdurma Dizisi
        durdurmaDizisi = new int[kafesboyutu];
        for (int i = 0; i < kafesboyutu; i++)
        {
            durdurmaDizisi[i] = 10 - (kafesboyutu - i);
        }
        #endregion


        //dizinin son elemanı birer birer artacak, 10-(kafesboyutu-bulunduğu sıra) sayısına ulaşan elemanlar 
        //eski hallerine dönüp kendilerinden önceki sayıyı bir arttıracaklar.
        #region bishiler
        for (int i = 0; i < 5555; i++)
        {



            sonucDizi[kafesboyutu - 1] += 1;

            for (int j = 0; j < kafesboyutu; j++)
            {
                if (sonucDizi[j] == 11 - (kafesboyutu - j))
                {
                    sonucDizi[j] = ornekDizi[j];
                    if (sonucDizi[j] > 0)
                    {
                        sonucDizi[j - 1] += 1;
                        swittch = true;
                    }
                }



                if ((sonucDizi.Sum() == toplam) && (sonucDizi.Distinct().ToArray().Length == sonucDizi.Length) && (sonucDizi[kafesboyutu - 1] != 10) && (swittch == true))
                {
                    Debug.Log("< " + string.Join(",", sonucDizi) + " >");
                    swittch = false;
                    //sonucTextBox.text += "< " + string.Join(",", sonucDizi) + " >" + Environment.NewLine;
                    textler[UnityEngine.Random.Range(0, textler.Length)].text += "< " + string.Join(",", sonucDizi) + " >" + Environment.NewLine;
                }

                if (durdurmaDizisi.SequenceEqual(sonucDizi))
                {
                    break;
                }
            }
            if (durdurmaDizisi.SequenceEqual(sonucDizi))
            {
                break;
            }

        }
        #endregion



    }

}
