using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class giriþEkraný : MonoBehaviour
{
    public GameObject cikisEkrani;

    private void Start()
    {
        // bu iþlemi yaparak oyun ekranýndan ana ekrana dönünce time.timeScale 0 olarak kaldýðý için oyun çalýþmaz bunu düzeltip bug a sokmaktan kurtardýk
        if(Time.timeScale==0)
        {
            Time.timeScale = 1;
        }
    }
    public void oyundanÇýk()
    {
        cikisEkrani.SetActive(true);
        
    }
    public void cevap(string cevap)
    {
        if (cevap == "evet")
        {
            Application.Quit();
        }
        else
        {
            cikisEkrani.SetActive(false);
        }
    
    }
    public void oyunaBaþla()
    {
        SceneManager.LoadScene(1);
    }
}
