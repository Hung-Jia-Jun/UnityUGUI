using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class ScrollBarSeletion : MonoBehaviour {

    private Transform[] TransformArray;//座標資料陣列
    private GameObject[] SkillImgArray;//圖像陣列
	public 	int Switchcase ; //多選算式計數器
	public 	Transform SeletBar;//框選框物件
	public  Scrollbar Handle;//手把位置
    public int temp;//要恢復到點擊滑鼠左鍵前的位置狀態時，使用的暫存變數
	private float MouseSeletion;//整理滑鼠的值，讓他易於進行判斷
    




	void Start () {
        string Img = "Image";
        string Skill = "Skill";
		TransformArray = new Transform[7];
        SkillImgArray = new GameObject[7];
		SeletBar=GameObject.Find("SeletBar").transform;//得到選擇框的物件
        SkillImgArray[0] = GameObject.Find("Skill1");
        




		
		for(int i = 0; i < 8; i++)
		{
            
            TransformArray[i] = GameObject.Find(Img+(i + 1)).transform;
            SkillImgArray[i] = GameObject.Find(Skill + (i + 1));
           
		}
        





	}
	
	
	void Update () {


        inputTrigger_Mouse_KeyBord_Scroll();//每次畫面更新，都呼叫此函式來偵測是否有任何按鈕按下

		switch (Switchcase)
		{
			

        

		case 0:
			SeletBar.transform.position =TransformArray[Switchcase].transform.position;//選擇框等於陣列中物件的位置
			    Handle.value=1F;//設定Value值讓視窗同步
                        SkillImgArray[0].gameObject.SetActive(enabled);//顯示第1張技能圖
                        for (int i = Switchcase; i < 8; i++)//關閉上一張圖片
                            {
                                SkillImgArray[i+1].gameObject.SetActive(false);//關閉全部的技能圖
                                SkillImgArray[Switchcase].gameObject.SetActive(enabled);//特別開啟自己的技能圖

                            }
			
			
			break;
		case 1:
			SeletBar.transform.position =TransformArray[Switchcase].transform.position;
			    Handle.value=0.9F;//設定Value值讓視窗同步
                    CloseSkillImg(Switchcase);//引入當前多項選擇式的值，並呼叫關閉所有技能圖的函式
			        SkillImgArray[1].gameObject.SetActive(enabled);//顯示第2張技能圖
                   
			
			
			
			break;
		case 2:
			SeletBar.transform.position =TransformArray[Switchcase].transform.position;
                CloseSkillImg(Switchcase);//引入當前多項選擇式的值，並呼叫關閉所有技能圖的函式
			        SkillImgArray[2].gameObject.SetActive(enabled);//顯示第3張技能圖
                   
			
			
			
			break;
		case 3:
			SeletBar.transform.position =TransformArray[Switchcase].transform.position;
                CloseSkillImg(Switchcase);//引入當前多項選擇式的值，並呼叫關閉所有技能圖的函式
			        SkillImgArray[3].gameObject.SetActive(enabled);//顯示第4張技能圖
                   
			
			
			
			break;
		case 4:
			SeletBar.transform.position =TransformArray[Switchcase].transform.position;
			Handle.value=0.294F;//設定Value值讓視窗同步
                CloseSkillImg(Switchcase);//引入當前多項選擇式的值，並呼叫關閉所有技能圖的函式
                     SkillImgArray[4].gameObject.SetActive(enabled);//顯示第5張技能圖
                    
			
			
			break;
			
			
		case 5:
		
			SeletBar.transform.position =TransformArray[Switchcase].transform.position;
                CloseSkillImg(Switchcase);//引入當前多項選擇式的值，並呼叫關閉所有技能圖的函式
		            SkillImgArray[5].gameObject.SetActive(enabled);//顯示第6張技能圖
                   
			
			
			
			
			break;
			
			
		case 6:
			//Handle.value=0;//設定Value值讓視窗同步
			SeletBar.transform.position =TransformArray[Switchcase].transform.position;	
			Handle.value=0;//設定Value值讓視窗同步
               CloseSkillImg(Switchcase);//引入當前多項選擇式的值，並呼叫關閉所有技能圖的函式
                    SkillImgArray[6].gameObject.SetActive(enabled);//顯示第7張技能圖
                  


			break;
			
			
        case 8:
                //當滑鼠進入選擇框範圍的時候執行的程式碼
            
            break;
					
			
		}

       


		
	}

    public void inputTrigger_Mouse_KeyBord_Scroll()//偵測所有滑鼠、鍵盤輸入的函式
    {







                 if (Input.GetKeyDown(KeyCode.DownArrow))//按下  下方向鍵
                     {

                         SwitchCaseLimit();//調用SwitchCase的限制，限制 SwitchCase的存取
                                Switchcase++;//每按下一次下方向鍵 都將多項選擇式+1

                     }
                if (Input.GetKeyDown(KeyCode.UpArrow))//按下  上方向鍵
                {
                    SwitchCaseLimit();//調用SwitchCase的限制，限制 SwitchCase的存取
                    if (Switchcase == 8)//判定是否在滑鼠釋放區
                        {
                        Switchcase = temp ;//將暫存值回存
                        }
                                Switchcase--;//每按下一次按紐 都將多項選擇式-1
            
                }
                
                
                if (Switchcase > 8)//設定不能跑出這個多項式的限制
                    {
                        Switchcase = temp + 1;//讀取剛剛儲存的temp值，因為要往下移動所以要+1
                    }

                if (Input.GetMouseButtonDown(0))//當滑鼠左鍵點擊時
                    {

                            if (Switchcase != 8)
                            {

                                temp = Switchcase;//將當前選擇框位置暫時存入Temp這個變數中，以便下次鍵盤呼叫時有地方可以返回

                            }

                 

                            Switchcase = 8;//進入滑鼠釋放區  


                    }



        

        if (Input.GetAxis("Mouse ScrollWheel") != 0)//因為滑鼠滾輪位置不一定每次都是0
        {
            MouseSeletion = MouseSeletion + Input.GetAxis("Mouse ScrollWheel");//設定滑鼠的初始值+得到的當前滾輪狀態
            SwitchCaseLimit();//調用SwitchCase的限制
            if (MouseSeletion < 0)//滑鼠正在向下
            {

                Switchcase++;//選擇框往下
                        MouseSeletion = 0;//執行後滑鼠滾輪值恢復到 0 的基準點
                           
                
            }
            }
            if (MouseSeletion > 0)//滑鼠正在向上
            {
               
                    temp = temp - 1;//暫存值-1
                    if (Switchcase == 8)//判定是否在滑鼠釋放區
                        {
                            Switchcase = temp + 1;//將暫存值回存
                        }

                    Switchcase--;//選擇框往上
                    MouseSeletion = 0;//執行後滑鼠值回到0   
            }


        }



    void CloseSkillImg(int Switchcase)//此函式負責關閉全部的技能圖
        {

            for (int i = Switchcase-1; i < 8; i++)
                {
                    SkillImgArray[i].gameObject.SetActive(false);//關閉全部的技能圖
                    SkillImgArray[Switchcase].gameObject.SetActive(enabled);//特別開啟自己的技能圖

                }
               
        }



    /*********************************SwitchCase的限制區*****************************************************/
    void SwitchCaseLimit()  //SwitchCase的限制區
    {
        if (Switchcase < 0)//讓框選框到頂的時候跳到最下方
        {
            Switchcase = 0;
        }

        if (Switchcase==7)//讓框選框到底的時候回到頂部
        {
            Switchcase = 6;
        }
        if (Switchcase == 8)
        {
            Switchcase = 8;
        }
    }
    /*********************************SwitchCase的限制區*****************************************************/









    /*********************************點擊圖片時觸發的函式*****************************************************/


    public void OnMouseisDown1()//當滑鼠按下的時候 要切換到哪張圖片做控制
    {
        
        Switchcase = 0;//將滑鼠點擊時，把暫存在temp的Switch值搬回來圖片顯示這邊

    }
	public void OnMouseisDown2()//當滑鼠按下的時候 要切換到哪張圖片做控制
	{
		
		Switchcase = 1;//將滑鼠點擊時，把暫存在temp的Switch值搬回來圖片顯示這邊
		
	}
	public void OnMouseisDown3()//當滑鼠按下的時候 要切換到哪張圖片做控制
	{
		
		Switchcase = 2;//將滑鼠點擊時，把暫存在temp的Switch值搬回來圖片顯示這邊
		
	}
	public void OnMouseisDown4()//當滑鼠按下的時候 要切換到哪張圖片做控制
	{

        Switchcase = 3;//將滑鼠點擊時，把暫存在temp的Switch值搬回來圖片顯示這邊
		
	}
	public void OnMouseisDown5()//當滑鼠按下的時候 要切換到哪張圖片做控制
	{
		
		Switchcase = 4;//將滑鼠點擊時，把暫存在temp的Switch值搬回來圖片顯示這邊
		
	}
	public void OnMouseisDown6()//當滑鼠按下的時候 要切換到哪張圖片做控制
	{
		
		Switchcase = 5;//將滑鼠點擊時，把暫存在temp的Switch值搬回來圖片顯示這邊
		
	}
	public void OnMouseisDown7()//當滑鼠按下的時候 要切換到哪張圖片做控制
	{
		
		Switchcase = 6;//將滑鼠點擊時，把暫存在temp的Switch值搬回來圖片顯示這邊
		
	}
    /*********************************點擊圖片時觸發的函式*****************************************************/

    }
	
	
	

