using Microsoft.Unity.VisualStudio.Editor;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class oyunKontrol : MonoBehaviour
{
    int secimDegeri;
    GameObject se�ilenButton;
    GameObject butonunKendisi;
    public Sprite defaultSprite;
    public AudioSource[] sesler;
    public GameObject[] butonlar;
    public GameObject[] oyunSonuPaneller;
    public GameObject grid;
    public GameObject havuz;
    public TextMeshProUGUI sayac;
    public Slider zamanSlider;
    public float toplamZaman = 120;
    float dakika;
    float saniye;
    bool zamanlayici;
    float gecenZaman;
    bool olu�turmaDurumu;
    int olu�turmaSayisi;
    int toplamElemanSayisi;
    

    public int hedefBasari;
    int anlikBasari;
    void Start()
    {
        secimDegeri = 0;
        zamanlayici = true;
        gecenZaman = 0;   
        zamanSlider.value = gecenZaman;
        zamanSlider.maxValue = toplamZaman;
        olu�turmaDurumu = true;
        olu�turmaSayisi = 0;
        toplamElemanSayisi = havuz.transform.childCount;



        StartCoroutine(Olustur());


    }

    private void Update()
    {
        if(zamanlayici && toplamZaman > 1 && gecenZaman !=toplamZaman) // -1:01: yazmas�n� engeller 1 yap�nca 
        {
            gecenZaman+= Time.deltaTime;
            
            zamanSlider.value = gecenZaman;
            if(zamanSlider.maxValue == zamanSlider.value )
            {
                
                    zamanlayici = false;
                    GameOver();
                
            }
            /*
             * if(zamanlayici && toplamZaman > 1) // -1:01: yazmas�n� engeller 1 yap�nca 
            dakika = Mathf.FloorToInt(toplamZaman / 60); // 119/2 =1
            saniye = Mathf.FloorToInt(toplamZaman % 60); // 119 /2 =1*** 5    {02:00} yapma
            // sayac.text= Mathf.FloorToInt(toplamZaman).ToString();
            sayac.text = string.Format("{0:00}:{1:00}", dakika, saniye);
            else
            zamanlayici = false;
            GameOver();
            */
        }

    }

    IEnumerator Olustur()
    {
        yield return new WaitForSeconds(.1f);
        while(olu�turmaDurumu)
        {
            int rastgeleSayi = Random.Range(0, havuz.transform.childCount - 1);
            if (havuz.transform.GetChild(rastgeleSayi).gameObject!=null)
            {
                havuz.transform.GetChild(rastgeleSayi).transform.SetParent(grid.transform);
                olu�turmaSayisi++;
                if(olu�turmaSayisi==toplamElemanSayisi)
                {
                    olu�turmaDurumu = false;
                    Destroy(havuz.gameObject);
                }
            }
        }
    }
    public void oyunuDurdur()
    {
        oyunSonuPaneller[2].SetActive(true);
        Time.timeScale = 0;
    }
    public void oyunaDevamEt()
    {
        oyunSonuPaneller[2].SetActive(false);
        Time.timeScale = 1;
    }
    void GameOver()
    {
        oyunSonuPaneller[0].SetActive(true);
    }
    void Win()
    {
        oyunSonuPaneller[1].SetActive(true);
    }
    public void AnaMenu()
    {
        SceneManager.LoadScene("AnaMenu");
    }
    public void  sonrakiLevel()
    {
        SceneManager.LoadScene(2);
    }
    public void Tekrar()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void ObjeVer(GameObject objem)
    {
        butonunKendisi = objem;
        butonunKendisi.GetComponent<UnityEngine.UI.Image>().sprite = butonunKendisi.GetComponentInChildren<SpriteRenderer>().sprite;
        butonunKendisi.GetComponent<UnityEngine.UI.Image>().raycastTarget = false;
        sesler[0].Play();

    }
    void butonDurumu(bool durum)
    {
        foreach(var item in butonlar) 
        {
            if(item!=null) 
            {
                item.GetComponent<UnityEngine.UI.Image>().raycastTarget = durum;
            }
            
        }
    }
    public void butonTiklad�(int deger)
    {
        kontrol(deger);
     
    }
    void kontrol(int gelenDeger)
    {
        if (secimDegeri == 0)
        {
            secimDegeri = gelenDeger;
            se�ilenButton = butonunKendisi;
        }
        else
        {
            StartCoroutine(KontrolEtBakal�m(gelenDeger));
        }
    }
    IEnumerator KontrolEtBakal�m(int gelenDeger)
    {
        butonDurumu(false);
        yield return new WaitForSeconds(1);
        if(secimDegeri==gelenDeger)
        {
            anlikBasari++;
            se�ilenButton.GetComponent<UnityEngine.UI.Image>().enabled = false;
            butonunKendisi.GetComponent<UnityEngine.UI.Image>().enabled = false;
            se�ilenButton.GetComponent<Button>().enabled = false;
            butonunKendisi.GetComponent<Button>().enabled = false;
            //Destroy(se�ilenButton.gameObject);
            //Destroy(butonunKendisi.gameObject); 
            se�ilenButton = null;
            secimDegeri=0;
            butonDurumu(true);
            if (hedefBasari == anlikBasari)
            {
                Win();
            }
        }
        else
        {
            
            sesler[1].Play();
            se�ilenButton.GetComponent<UnityEngine.UI.Image>().sprite = defaultSprite;
            butonunKendisi.GetComponent<UnityEngine.UI.Image>().sprite = defaultSprite;
            Debug.Log("E�le�medi");
            secimDegeri = 0;
            se�ilenButton=null;
            butonDurumu(true);
        }

    }
}
