using UnityEngine.UI;
using UnityEngine;
using System.Collections;
using System;

public class Game : MonoBehaviour
{

    //=====================================================================
    [Header("Очки")]
    public Text scoreText;      //Показатель(счетчик очков)
    private int score;          //Количество очков(Не выводится на экран)
    private int bonusScore = 1; //Изначальный скилл
    private int ScoreSec = 0;   //Очки в секунду
    //====================
    [Header("Нижняя панелька")]
    public GameObject upgradeBttn;    //Кнопка открытия апгрейдов
    public GameObject profileBttn; //Кнопка открытия профиля
    //====================
    [Header("Улучшения")]
    public int[] upgradeCostsSec;       //Список цен на улучшения (очки/сек)
    public int[] upgradeCostsClick;     //Список цен на улучшения (очки/клик)
    public int[] upgradeBonusesSec;     //Сила улучшения (очки/сек)
    public int[] upgradeBonusesClick;   //Сила улучшения (очки/клик)

    public Text[] upgradeBttnTextSec;   //Текст улучшения(товара очки/сек)
    public Text[] upgradeBttnTextClick; //Текст улучшения(товара очки/клик)

    public GameObject upgradePan;  //Открытие меню улучшений
    public GameObject upClickBttn; //Кнопка раздела "Очки/Клик"
    public GameObject upClickPan;  //Открытие раздела "Очки/Клик"
    public GameObject upSecBttn;   //Кнопка раздела "Очки/Сек"
    public GameObject upSecPan; //Открытие раздела "Очки/Сек"
    //====================
    [Header("Профиль")]
    public Text ScoreClickProf;    //Характеристика в профиле
    public Text ScoreSecProf;      //Характеристика в профиле
    public GameObject profilePan;  //Открытие меню профиля
    //======================================================================



    private void Start() //При запуске игры
    {
        StartCoroutine(BonusSec()); //Даются очки в секунду
    }

    private void Update()
    {
        scoreText.text = score + "";  //Обновление показателя очков
        ScoreClickProf.text = "Очки/Клик: " + bonusScore;
        ScoreSecProf.text = "Очки/Сек: " + ScoreSec;
        if (Input.deviceOrientation == DeviceOrientation.FaceUp)
        {
            Screen.orientation = ScreenOrientation.Portrait;
        }
    }





    //=========================================UPGRADES============================================================
    //=========================================        ============================================================
    //=========================================UPGRADES============================================================
    public void upgrade_OpenHide() //Открытие меню прокачки
    {
        upgradePan.SetActive(!upgradePan.activeSelf);         //Появляется меню с выбором раздела
        upgradeBttn.SetActive(!upgradeBttn.activeSelf);       //Прячется кнопка магазина
        profileBttn.SetActive(!profileBttn.activeSelf);       //Прячется кнопка профиля
    }

    public void upClick_open() //РАЗДЕЛ очко/клик (открытие)
    {
        upSecBttn.SetActive(!upSecBttn.activeSelf);     //Исчезает выбор раздела
        upClickBttn.SetActive(!upClickBttn.activeSelf); //Исчезает выбор раздела
        upClickPan.SetActive(!upClickPan.activeSelf);   //Появляется список улучшений
    }

    public void upSec_open()
    {
        upClickBttn.SetActive(!upClickBttn.activeSelf); //Исчезает выбор раздела
        upSecBttn.SetActive(!upSecBttn.activeSelf);     //Исчезает выбор раздела
        upSecPan.SetActive(!upSecPan.activeSelf);       //Появляется список улучшений
    }

    public void upgradeClick_buy(int index)           //Механика апгрейдов (Очки/Клик)
    {
        if (score >= upgradeCostsClick[index])        //Проверка наличия средств
        {
            bonusScore += upgradeBonusesClick[index]; //Скилл + бонус улучшения
            score -= upgradeCostsClick[index];        //Очки - стоимость покупки
            upgradeCostsClick[index] = upgradeCostsClick[index] / 3 * 5;            //Повышение цен после покупки
            upgradeBttnTextClick[index].text = "Обнимашки - " + upgradeCostsClick[index] + "(+" + upgradeBonusesClick[index] + "/click)" ; //Текст кнопки улучшения
        }
        else
        {
            Debug.Log("Недостаточно средств!");
        }
    }

    public void upgradeSec_buy(int index)         //Механика апгрейдов(Очки/Сек)
    {
        if (score >= upgradeCostsSec[index])      //Проверка наличия средств
        {
            ScoreSec += upgradeBonusesSec[index]; //Скилл + бонус улучшения
            score -= upgradeCostsSec[index];      //Очки - стоимость покупки
            upgradeCostsSec[index] = upgradeCostsSec[index] / 3 * 5; //Повышение цен после покупки
            upgradeBttnTextSec[index].text = "Писать \"доброе утро\" - " + upgradeCostsSec[index] + "(+" + upgradeBonusesSec[index] + "/sec)";//Текст кнопки улучшения
        }
        else
        {
            Debug.Log("Недостаточно денех");
        }
    }

    IEnumerator BonusSec()
    {
        while (true)
        {
            score += ScoreSec;
            yield return new WaitForSeconds(1);
        }
    }
    //===========================================PROFILE============================================================
    //===========================================       ============================================================
    //===========================================PROFILE===========================================================

    public void profile_OpenHide() //Открытие профиля
    {
        profilePan.SetActive(!profilePan.activeSelf);   //Появляются характеристики в профиле
        upgradeBttn.SetActive(!upgradeBttn.activeSelf);       //Прячется кнопка магазина
        profileBttn.SetActive(!profileBttn.activeSelf); //Прячется кнопка профиля
    }


    public void profileTab() //Оформление профиля
    {
    }


    public void OnClick() //Добавление очков при клике
    {
        score += bonusScore;
    }

}
