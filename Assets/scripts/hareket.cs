using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class hareket : MonoBehaviour
{
    public GameObject kuyruk;
    List<GameObject> kuyruklar;

    Vector3 eski_koordinat;
    GameObject eski_kuyruk;

    float hiz = 50.0f;

    public GameObject bitti_pnl;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "duvar")
        {
            bitti_pnl.SetActive(true);
            Time.timeScale = 0.0f;
        }
        if(other.gameObject.tag == "kuyruk")
        {
            bitti_pnl.SetActive(true);
            Time.timeScale = 0.0f;
        }
    }

    public void tekrar_oyna()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("Scenes/oyun");
    }


    // Start is called before the first frame update
    void Start()
    {
        kuyruklar = new List<GameObject>();

        for(int i=0; i<5; i++)
        {
            GameObject yeni_kuyruk = Instantiate(kuyruk, transform.position, Quaternion.identity);
            kuyruklar.Add(yeni_kuyruk);
        }

        InvokeRepeating("hareket_et", 0.0f, 0.1f);
    }

    void hareket_et()
    {
        eski_koordinat = transform.position;

        transform.Translate(0, 0, hiz * Time.deltaTime);

        kuyruk_takip();
        
    }

  
    public void kuyruk_arttir()
    {
        GameObject yeni_kuyruk = Instantiate(kuyruk, transform.position, Quaternion.identity);
        kuyruklar.Add(yeni_kuyruk);
    }

    void kuyruk_takip()
    {
        kuyruklar[0].transform.position = eski_koordinat;
        eski_kuyruk = kuyruklar[0];
        kuyruklar.RemoveAt(0);
        kuyruklar.Add(eski_kuyruk);
    }

    public void dondur(float aci)
    {
        transform.Rotate(0, aci, 0);
    }



}
