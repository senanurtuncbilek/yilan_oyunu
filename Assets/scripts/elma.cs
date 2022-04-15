using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class elma : MonoBehaviour
{
    public TMPro.TextMeshProUGUI skor_txt;
    int skor = 0;

    hareket kuyruk_olustur;




    private void Start()
    {
        kuyruk_olustur = GameObject.Find("bas").GetComponent<hareket>();
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "bas")
        {
            skor += 10;
            skor_txt.text = "SKOR " + skor;


            koordinat_degistir();


            kuyruk_olustur.kuyruk_arttir();

        }

        if(other.gameObject.tag== "kuyruk")
        {
            koordinat_degistir();
        }
    }

    void koordinat_degistir()
    {
        float x_deger = Random.Range(-4.0f, 15.0f);
        float z_deger = Random.Range(-14, 12);

        transform.position = new Vector3(x_deger, 0, z_deger);    }




}
