using Syst0...3em.Collections;
using System.Collections.Generic;
using UnityEngine;
/*위 3가지는 기본적으로 Unity Scripte file을 생성하면 자동적으로 사용됀다.*/
using Unity.VisualScripting.Antlr3.Runtime.Tree;

                            !!Warning!!
    여기 작성돼어있는 글과 클래스는 작성자 개인의 생각과 잡소리가 들어가있으니
    정확하게 알고싶다면 강사님,인터넷,책,GPT,꺼무위키 에게 물어보자.
    
    *작성자의 뇌피셜은 앞에 *이 들어갑니다(Dog드립포함).*
    *작성자는 본 글에 적혀있는 코드가 제 기능을 하지않아도 책임 지지않습니다.*
    *틀렸을시 정확한 답을 안다면 훈수 환영*

//MonoBehaviour는 Unity의 기본클래스다.
public class learnCode : MonoBehaviour
/* MonoBehaviour의 설명
    MonoBehaviour가 만약 하얀색으로 표시 됀다면 Unity와 연결이 돼어 있지 않은것이다.
    Unity의 ToolBar에 Edit-Preferences-External Script Editor 에서 본인이 사용하는 스크립트 편집 파일선택
    밑의 체크 박스는 알아서 체크하자.
*/
{
    public static GameManager gameManager = null; // 싱글톤 패턴을 사용할때 쓰는 방법. Awake로
    /*  사용 설명
        1. 싱글 톤 패턴은 GameManager Scpripte에서 관리할때 사용하는 전략 디자인이다.
        2. GameManager에 본인이 받아오고싶은 Scripte정보를 입력하여 받아와서 다른 스크립트에서
        사용 할 수 있게 만들어준다.

        사용 예시
        1. public PlayerController playercontroller
        2. public GameObject player 
         
        호출 예시
        1.GameManager.gameManager.
         */

    Rigidbody2D rbody; //Component를 불러오고 사용하기
    /*Component사용과 설명은 Start로
     Rigdbody2D를 사용 할 때 사용 3D에서 사용 할 때 2D를 빼면 됀다.
     */

    GameObject[] gameObjects;
    /*배열 사용
     Unity 에서 배열을 사용할때는 C#과 비슷하게 사용한다.
    배열을 불러올때 gameObjects[i] 이렇게 사용하면 됀다.
    i는 해당 배열의 번호 혹은 for문을 이용한 i 를 사용한다.
     */

    /*Camera이동 (Update의 Camera를 찾으시오.)
        public float leftLimit = 0.0f;
        public float rightLimit = 0.0f;
        public float topLimit = 0.0f;
        public float bottomLimit = 0.0f;
    */ // Camera의 최대 이동거리 제한.

    /*Object Pooling설명과 만들고 사용하는 방법
    
    public GameObject[] bulletPrefabType; // GameObject prefab을 배열에 등록합니다.

    GameObject[] BulletCount; // 얼마나 만들지 설정합니다.

    Awake로 가자

    *골드 메탈님의 영상을 참조하여 제 방식대로 사용하였습니다.*

    Object Pooling을 하는 이유는,
    프리팹을 생성할때 Instantiate를 사용하여 생성하고,
    Destroy를 사용하여 Object를 제거 할 때 마다 메모리가 쌓이고,
    쌓인 메모리를 비우기 위해 Unity의 Garbage collector가 동작하게 됩니다.
    이 때 랙을 유발 시키므로 ObjectPooling을 사용합니다.
    */

    //Unity Class의 LifeCycle (생명주기, 순서도)

    //GameObject가 생성 됄 때 최조 1회 실행하는 함수.
    void Awake()
    {
        //싱글톤 패턴에서 써야하는 코드
        {
            if (gameManager == null)
            {
                gameManager = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }

        }

        //ObjectPooling
        /* BulletCount = new GameObject[100]; // 생성할 갯수 입력

        //외부에서 정의한 함수입니다. FuncsionClass로
        Generate();
        */
    }

    //GameObject가 활성화 됄 때마다 1회 실행하는 함수.
    void OnEnable()
    {

    }

    //Update가 시작돼기 전 최초 1회 실행하는 함수.
    void Start()
    {
        rbody = GetComponent<Rigidbody2D>(); // Componet를 호출해서 사용하는 방법.
        /* GetComponent<>(); 설명
            C#의 제네릭 클래스와 같은 원리이다, 자세히 알고싶으면 C#책 의 제네릭클래스 부분을 읽자.
            GetComponent는 Unity의 Inspecter창의 Component의 정보를 받아오는 것이기 때문에
            Add Component에 있는 정보를 받아올수잇는것이다 
            예시로 Animator를 불러온다면 위의 사용처럼 외부에 Animator ani;
            ani = GetComponent<Animator>();를 불러와 Animator의 함수를 사용 할 수있다.
            *딱히 Start에 쓰지않아도 돼는것으로 알고있음 자세히 모르겠지만 작성자를 믿지말자.*
        */

        rbody.AddForce(transform.position * projectile); // 발사체가 포물선의 진행방향을 보며 날아가게 하는방법.
        /* 사용 방법
        상단에 public float projectile; 정의하였습니다.

        FixedUpdate()로 가시오.

        참조하였음 https://www.youtube.com/watch?v=YvdiNsuJAKc
         */
    }

    //Unity의 physics,Rigidbody등 물리연산에 관련됀 로직을 입력 할 때 사용하는 함수 (CPU많이 사용).
    void FixedUpdate()
    {
        rbody.Velrocity = new Vector2(X, Y); //Input Key로 받은 키 값에 속도를 준다. 본인이 정의한 값을 X, Y값에 주면됀다.
        /*Velrocity, Vector에 관한 설명
            Velrocity는 질량과 관성을 무시하고 주어진 속도로 이동한다. (속도) *쉽게 말해서 미는 힘이다.*
            Vector3는 x,y,z 축의 위치, 방향, 속도를 계산할때 사용한다.
            Vector2는 2D에 z축이 없기때문에 나온것이고 기본적으로 Vector3를 사용한다.
        */

        rbody.AddForce(X, Y); // AddForce는 Velrocity와 비슷하지만 다른점은 이동,물리,질량,관성에 영향을 받는다.
        /*AddForce, ForceMode2의 관련 설명
            AddForce는 질량 관성 등의 영향을 받기때문에 이동이라기 보다는 미끌어지듯 움직인다. (가속도) *쉽게 말해서 때리는 힘이다.*
            ForceMode2D.Force; // 연속적이고 질량을 무시하지 않는다. (현실적인 물리현상을 나타낼 때 많이 씀)               
            ForceMode2D.Impulse; // 불연속적이고 질량을 무시하지 않는다. (짧은 순간의 힘, 충돌, 폭발 등등 에 쓰인다)
            FoeceMode.VelocityChange; // 불연속적이고 질량을 무시한다. (질량이 다른 오브젝트에 같은 힘을줬을때 같은 속도로 움직이게 해준다)

            rbody.AddRelativeForce(Vector3 force, ForceMode mode = ForceMode.Force)강사님이 ForceMode 설명할때 잠깐 설명해준거
            위 코드의 역할은 RigidBody가 새로운 좌표계가 되어서 반영되는것이다. 처음에 RigidBody가 북쪽을 바라보고있으면
            위치가 바뀌고 회전되어도 RigidBody가 바라보고 있는 방향이 북쪽이 되는 것이다.

            //배우지는 않았지만 이런게 있다.
            FoeceMode.Accel; // 연속적이고 질량을 무시한다. (오브젝트의 질량에 관계없이 가속을 주고싶다면 사용한다)
         */

        //Joystick 이용한 이동방법(아직 미완성입니다.)
        /*
        (외부에 Public VariableJoystick variableJoystick;)

        Vector3 direction = Vector3.forward * variableJoystick.Vertical + Vector3.right * variableJoystick.Horizontal;
        rb.AddForce(direction * speed * Time.fixedDeltaTime, ForceMOde.VelocityChange);

        우리가 배웠던것들을 활용해서 사용했다.
         */

        //Linecast로 Jump하기
        {
            //외부 상단에 (public LayerMask groundLayer; bool onGround = false; bool goJump = false) 정의했다는 가정
            onGround = Physics2D.Linecast(transfrom.position, transform.posision - (transform.up * 0.1f), groundLayer);
            /* *Linecast 코드 설명(100% 뇌피셜)*
                나도 재대로 이해한게 아니라서 틀릴 수 있음.
                Player의 SpriteRanderer의 point 기준 -transform.up * 0.1f 만큼 가상의 선이 생기고 
                가상의 선이 groundLayer에 닿아있으면 true 닿지않으면 false
                groundLayer는 Unity에서 GameObjcet의 Layer에서 설정 해야됌.
             */
            if (onGround || axisH != 0)
            {
                rbody.velocity = new Vector2(axisH * speed, rbody.velocity.y);
            }
            if (onGround || goJump)
            {
                Vector2 jumppw = new Vector2(0, jump);
                rbody.AddForce(jumppw, ForceMode2D.Impulse);
                goJump = false;
            }
            //FuncsionClass에 넣기 좀그래서 여기 씀 
            void Jump
             {
                goJump = true;
            }
            /*참고로 이거 사용하려면 Unity에서 몇 가지 설정을 해야하는데 대상의 Sprite에 pivot을 Bottom으로 설정하고 사용해야 한다.
            Linecast의 기준은 Script가 적용됀 GameObject의 pivot을 기준점으로 가상의 선이 나오기 때문이다, 그리고 애니메이션 설정은 빼놓았다.
            설명 */
        }

        // 발사체가 포물선의 진행방향을 보며 날아가게 하는방법.
        {
            float angle = Mathf.Atan2(rbody.velocity.y, rbody.velocity.x) * Mathf.Rad2Deg;
            transform.eulerAngles = new Vector3(0, 0, angle);
        }

    }

    //Game의 Logic관련 Code들을 입력 할 때 사용하는 함수. 
    void Update()
    {
        if (Input.GetKey(KeyCode.D)) // 설정 키값으로 입력받기      
            /* Input.GetKey() 설명
                1.Key를 누르는 동안 true를 지속적으로 반환한다.
                2.내가 지정한 버튼을 지정하여 설정 할 수 있다.

                자매코드
                GetKeyDown() // Key를 누를때 한번 true를 반환 한다.
                GetKeyUp() // Key를 땔 때 한번 true를 반환 한다.

                사용 예시
                if (Input.GetKey(KeyCode.Escape))
                // Escape는 ESC Key이고 Unity에 등록이 돼어있는 Key이다, Escape는 받는 InputKey값이므로 
                RightArrow,D 등등 내가 입력받고 싶은 값으로 설정하면 돼는 것이다.
                ((KeyCode.RightArrow), (KeyCode.D))
                */

            axisH = Input.GetAxisRaw("Horizontal"); // Unity에 정의됀 키값으로 입력받기
        /*Input.GetAxisRaw() 설명
	        1. Unity 내부 Input Manager에 정의된 키 값을 불러와서 사용 할 수 있다.
	        2. -1, 0, 1 세 가지 값 중 하나가 반환된다.
	        3. string 값을 사용한다.
	        4. GetAxis와 차이점은 Axis는 -1.0f부터 1.0f까지의 값을받고 GetAxisRaw는 -1, 0, 1의 값을 받는다
	        GetAxis는 실수를 사용하기때문에 -0.5f처럼 절반의 값을 사용할 수있고 GetAxisRaw는 그런거 없이
	        -1, 0, 1 값이 반환됀다 
	        요약 "GetAixs는 float 값이고 GetAxisRaw는 int값이다."

            자매코드
	        GetAxis // -1.0f 부터 1.0f까지의 범위 값을 반환 한다.

            사용예시
	        변수 명 = Input.GetAxisRaw("Horizontal")
	        // "Horizontal" , "Vertical" 이 있다 Unity Input Manager에 정의된 Key 값
		    왼쪽 A , LeftArrow 오른쪽 D , RightArrow 위 W , UpArrow 아래 S , DownArrow 
        */

        //Angle 값 구하기
        {
            //외부 상단에 (public float angleZ = 90.0f;) 정의했다는 가정
            Vector2 fromPt = this.transform.position; // 스크립트를 가지고있는 GameObject의 position 정보
            Vector2 toPt = new Vector2(fromPt.x + axisH, fromPt.y + axisV);
            Debug.Log("X : " + toPt.x + "Y : " + toPt.y); // Unity 실행중 오류 발생시 알려주는코드

            angleZ = GetAngle(fromPt, toPt); /* GetAngle은 외부에서 함수를 생성하여 불러온것이다. 
                                                GetAngle은 FuncsionClass 에 정의 해 놓았다  */
            if (angleZ >= -45 && angleZ < 45)
            {
                //Right Angle 값
            }
            else if (angleZ >= 45 && angleZ <= 135)
            {
                //Up Angle 값
            }
            else if (angleZ >= -135 && angleZ <= -45)
            {
                //Down Angle 값
            }
            else // 3각을 정했기때문에 나머지 각은 자동으로 else 값으로 온다.
            {
                //Left Angle 값
            }
        } // Unity의 각도는 360도가 아니고 180도 -180도이다, 나도 정확하게 몰러... 이대로 외워...

        //Camera 
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            //Hierarchy의 GameObject의 Tag "Player"를 찾는다.
            if (player == null)
            {
                Debug.LogError("Player 게임 오브젝트를 찾을 수 없음.");
                return
            }
            /*Debug.LogError 사용 개념
                Debug.LogError는 경고 표시이다. Hierarchy에 "Player" Tag를 가진 GameObject가 없다면
                Console창에 알려주는 역활이다. Debug과정에서 삐르게 오류를 알려주기 위해 사용한다. 
                코딩 생활 하면서 습관을 들이면 나중에 본인이 편해진다.
             */
            float x = player.transform.position.x;
            float y = player.transform.position.y;
            float z = this.trasnform.position.z;
            //player의 x,y값을 받아와서 본인의 position값으로 변환하는작업

            if (x < lifeLimit)
            {
                x = liftLimit;
            }
            else if (x > rightLimit)
            {
                x = rightLimit;
            }
            if (y < BottomLimit)
            {
                y = BottomLimit;
            }
            else if (y > topLimit)
            {
                y = topLimit;
            }
        }
    }

    //모든 Update영역의 로직이 모두 실행이 끝난 후 마지막으로 실행돼는 함수. 
    void LateUpdate()
    {

    }

    //GameObject가 비활성화 됄 때마다 1회 실행하는 함수.
    void OnDisable()
    {

    }

    // GameObject가 삭제됄때 실행하는 함수. 
    void OnDestroy()
    {

    }

    //(Box)Collider 등의 Trigger설정을 하고 다른 Collider와 충돌했을때 실행.
    void OnTriggerEnter2D(collider2D collision)
    {
        transform.SetParent(collision.transform);
        // Collider2D에 닿으면 닿은 Object의 ChildObjcet가 됀다*(고양이의 키워라 닝겐 같은건가?)*
    }

    //다른 Collider에서 떨어질때 실행.
    void OnTriggerExit2D(collider2D collision)
    {

    }

    //외부에 따로 임의 생성 함수클래스들
    void FuncsionClass()
    {
        //Angle값 구하기.
        float GetAngle(Vector2 p1, Vector p2) //float 값을 반환해주는 함수다.
        {
            float angle = angleZ;

            if (axisH != 0 || axisV != 0)
            {
                float dx = p2.x - p1.x;
                float dy = p2.y - p1.y;

                float ran = Mathf.Atan2(dy, dx);
                angle = ran * Mathf.Rad2Deg;
            }
            return angle;
            //Atan2는 Y,X 값으로 들어간다.
        }
        /* GameObjcet 와 gameObjcet의 FindTag 사용방법과 차이.
         
            GameObjcet player = GameObjcet.FindGameObjcetWithTag("Player")
            GameObjcet는 Hierarchy의 GameObjcet이다. 

            gameObjcet.tag == "Player"
            gameObjcet는 GameObjcet를 변수명으로 사용한 것이다.
            이건 그냥 GameObjcet player 라고 해놓으면 player.tag가 돼는것이다.
            이를 인지하자.
         */

        // 데이터 타입 제한없는 자료구조 많이 쓰지않지만 알고있으면 좋음
        {
            ArrayList;// 배열처럼 사용이 가능하다.
            /* 사용예시
             * arrayList.Add(1); 
             괄호 안에 내가 원하는 값*/
            Queue;// 선입선출 FIFO (First In First Out)
            /* 사용예시
               que.Enqueue(10)
            괄호 안에 내가 원하는 값, Enqueue, Dequeue가 있으며 .*/
            Stack;// 후입선출 LIFO (Last In First Out)
            Hashtable;// Key와 Value를 가진 데이터를 저장하는 자료 구조이다.

            //데이터 타입 제한이 있는 구조자료.
            Dictionary;//Hashtable과 사용 방법이 같다, Playerpref으로 비슷하게 사용했었음.
        }

        //Random 설명
        int GetRandom(int x, int y)
        {
            /* Random의 사용방법
                여기서 x = 0, y = 10이라고 가정하겠다.
                Unity에서 Random은 뒤에 method가 붙어야 한다.
                Random.Range(int x, int y) : Range는 두 인자 값의 난수를 반환한다 0이상 10이하.
                Random.value(float x, floal y) : value는 두 인자 값의 실수형 난수를 반환한다 0f이상 10f미만.
             */
        }

        //Object Pooling 만들기
        void Generate()
        {
            for (int i = 0; i < bulletPrefabType.Length; i++)
            {
                for (int j = 0; j < BulletCount.Length; i++)
                {
                    BulletCount[j] = Instantiate(BulletCount[i]);
                    BulletCount[j].SetActive(false);
                }
            }
        }
        /*이중 for문을 사용하여 좀 더 손 쉽게 관리 할 수 있게 하였습니다.
         그리고 제가 사용한 설명 예시는 하나만 사용하였기때문에 한개만 사용하였습니다.
         bullet이면 bullet끼리 enemy면 enemy끼리 prefab을 정리하여 사용하세요.
         */
    }
}

//다른 스크립트에서 호출하거나 사용했던 클래스들.
public class AnotherScriptclass : MonoBehaviour
{
    
}

//상속 : 부모Class
public abstract class learnCode : MonoBehaviour // 부모 클래스 생성
{
    //접근 지정자를 protected로 사용하여 보호 수준을 자식 클래스에서 사용 할 수있게 해야한다.
    protected string broadcast = "Twitch";

    //접근 지정자를 설정하지않으면 Private로 설정돼어 자식클래스에서 사용 할 수 없다.
    protected virtual void onAir() // virtual = 가상 함수
    {
        print("이제 니 인생 살아~")
    }

    protected abstract followers(); // abstract = 추상 함수

    /*
    부모클래스 라고도 한다. 이 기능은 부모 클래스의 기능을 받아와서
    사용 할 수 있게 해줌으로써 책의 예시에서처럼 몬스터, 휴먼 클래스의 
    역활을 상속받아 기능을 구현하고 추가 기능을 추가해서 보스 혹은 NPC의 역활등을 줄 수 있습니다.

    virtual은 가상 함수로 사용하겠다는 키워드이고 부모 클래스에서 함수를 정의했지만 자식 클래스에서 추가적으로 재정의 할 수 있게 해줍니다.

    override는 부모에서 정의 한 함수를 자식클래스에서 재정의하여 사용 할 수 있게 해줍니다.

    abstract는 추상함수로 만들게 해줍니다 추상 함수는 부모 클래스에서 완성시키지 않고 자식클래스에서 완성 시켜주는 함수입니다.

    추상 함수를 사용할때는 클래스가 미완성이 돼어버리기 때문에 class도 abstract를 사용해주어야 합니다.
    추상함수의 사용 목적은 코드가 많아질 경우 반드시 사용해야하는 함수를 까먹고 놓칠 수 있기때문에 미리 토대를 만들어줄때 사용합니다.
     */

    /*접근 지시자, 보호 수준 설명
        pubilc : 어떤 Class에서든 접근 가능.
        private : 해당 클래스 내에서만 접근 가능.
        protected : 해당 클래스와 그 클래스를 상속받은 하위 클래스에서 접근 가능.
    // 아직 배우지 않은것
        internal : 같은 어셈블리 내의 클래스 또는 해당 클래스를 상속 받은 하위클래스에서 접근가능.
        protected internal : 같은 어셈블리 내의 클래스 또는 해당 클래스를 상속받은 하위 클래스에서 접근가능.
    */
}

//자식 : 부모Class
public class GoOver : learnCode //자식 클래스 생성
{

    string channelname;

    void Start()
    {
        broadcast;
        channelname = "우왁굳"
        viewers = 10000;

    }

    protected override void onAir() // override - 재정의
    {
        base.info(); //base는 부모 클래스를 가리키는 키워드입니다.
        print("뱅온"); //재정의 하였음.
    }

    protected override void followers()
    {
        print(95.1 + "만");
    }
}

//enum은 열거형식으로 사용됀다. 최상단에 사용하는게 좋다.
public enum Type
{
    1,
    2,
    3

    /*설명
    enum의 장점은 Item이나 monster등등 스크립트를 짜면서 구분하기 쉽고 편하게
    관리하기 위해 사용한다.
    */
}

//GPT에게 설명이나 모르는거 물어봄.
void chatGPT()
{
    /*GPT의 Assembly 강좌.
    Unity에서 어셈블리는 게임을 구성하는 코드의 단위 중 하나입니다.
    게임 오브젝트에 부착된 스크립트는 Unity 엔진에 의해 컴파일되어 어셈블리로 변환됩니다.
    이때, 컴파일된 어셈블리는 DLL 파일 형태로 저장됩니다.

    어셈블리는 C#과 같은 프로그래밍 언어를 이용하여 함수를 정의하고,
    이를 컴파일하여 생성됩니다. 이때, 어셈블리는 여러 개의 클래스로 구성될 수 있으며,
    각 클래스는 다양한 멤버(변수, 함수 등)를 가질 수 있습니다.
    Unity에서는 이미 정의된 API를 이용하여 게임을 개발하기 때문에,
    보통 사용자가 직접 어셈블리를 작성하는 일은 드뭅니다. 대신,
    Unity API를 활용하여 게임을 개발합니다.

    Unity의 어셈블리는 유니티 엔진에서 사용되는 다양한 기능들을 구현한 코드의 집합체입니다.
    이러한 어셈블리는 .NET Framework의 일부분인 Common Language Runtime (CLR)에서 실행됩니다.
    Unity의 어셈블리는 유니티 엔진의 코어 기능뿐만 아니라 다양한 모듈과 라이브러리, 에디터 확장 등에서도 사용됩니다.
    따라서, 유니티에서 스크립트를 작성하거나 플러그인을 개발할 때는 Unity의 어셈블리를 참조할 필요가 있습니다.
    Unity의 어셈블리는 유니티 엔진이 설치된 폴더의 "Editor" 및 "Data" 폴더 안에 위치해 있습니다.
    따라서, Unity 스크립트에서 유니티의 어셈블리를 사용하기 위해서는 해당 어셈블리를 참조해야 합니다.
    이를 위해서는 using 지시어를 사용하여 Unity의 네임스페이스를 참조하거나, 참조할 어셈블리를 명시적으로 선언할 수 있습니다.
    */

    /* GPT의 Cos Sin Atan2강좌
    Cos, Sin, Atan2는 수학 함수로 각각 삼각함수
    코사인(Cosine), 사인(Sine), 아크탄젠트(Atangent)의 변형이다.

    Cos 함수는 주어진 각도의 코사인 값을 계산해 반환한다.
    코사인 값은 삼각형의 빗변 길이를 대각선으로 하는 직각삼각형에서,
    인접변의 길이를 빗변의 길이로 나눈 값이다.
    수학적으로는 cos(x) = adjacent / hypotenuse 이다.

    Sin 함수는 주어진 각도의 사인 값을 계산해 반환한다.
    사인 값은 삼각형에서, 높이를 빗변으로 하는 직각삼각형에서,
    대각선과 인접변을 이루는 각도의 반대쪽 변의 길이를 높이로 나눈 값이다.
    수학적으로는 sin(x) = opposite / hypotenuse 이다.

    Atan2 함수는 주어진 x, y 좌표 값의 아크탄젠트 값을 계산해 반환한다.
    아크탄젠트 값은 직각삼각형에서 인접변과 높이를 알 때,
    인접변과 높이를 이루는 각도의 크기를 반환한다. atan2(y, x)는 y / x의 아크탄젠트 값을 반환하며,
    x가 0이면 결과값은 ±π / 2가 된다.

    Unity에서 이 함수들은 벡터와 관련된 작업에서 많이 활용된다.
    예를 들어, Cos와 Sin 함수는 주로 총알이나 플레이어를 회전시키는데 사용된다.
    Atan2 함수는 벡터가 가리키는 방향을 결정하거나 두 벡터 간의 각도를 계산하는데 사용된다.
     */

    /* GPT의 Rad2Deg 강좌
    Rad2Deg는 라디안 값을 각도 값으로 변환해주는 상수입니다.
    라디안(radian)은 각도의 단위로, 360도를 2π로 나눈 값으로서,
    원주의 길이와 반지름의 길이가 같을 때의 호의 중심각이 1 라디안입니다.

    Unity에서 수학적 계산을 할 때, 각도 값으로 표시된 값과 라디안 값으로 표시된 값 모두 사용됩니다.
    Rad2Deg 상수는 라디안 값을 각도 값으로 변환할 때 사용됩니다.
    예를 들어, Mathf.Sin() 함수는 라디안 값을 입력으로 받기 때문에,
    각도 값을 라디안 값으로 변환할 때 Rad2Deg 상수를 사용합니다.
    */

    /* GPT의 abstract강좌
    abstract는 클래스, 메서드, 프로퍼티, 인덱서 등을 선언할 때 사용되는 한정자입니다.
    abstract를 사용하면 해당 멤버를 구현하지 않고 선언만 할 수 있습니다.

    추상 클래스는 구현이 완전하지 않은 클래스로, 객체를 직접 생성할 수 없습니다.
    대신 해당 클래스를 상속한 하위 클래스에서 구현을 완성해야합니다.
    추상 클래스는 하위 클래스에서 공통된 특징을 추출해놓은 것으로 생각할 수 있습니다.

    추상 메서드는 구현부가 없는 메서드로, 추상 클래스에서 선언되며 하위 클래스에서 반드시 구현해야합니다.
    추상 클래스 내에 추상 메서드가 있으면 하위 클래스에서 반드시 이를 구현해야 객체를 생성할 수 있습니다.
    추상 메서드를 사용하면 여러 하위 클래스에서 공통적으로 사용되는 메서드 시그니처를 정의할 수 있습니다.

    추상 클래스와 추상 메서드는 다형성과 상속을 이용한 객체지향 프로그래밍에서 많이 사용됩니다.
    상위 클래스에서 공통된 특징을 추출해 추상화하고, 하위 클래스에서 이를 구체화하여 확장성과 유지보수성을 높일 수 있습니다.
     */

    /* GPT의 virtual, override, abstract 강좌
    virtual, override, abstract는 다형성(Polymorphism)을 구현하는 데 사용됩니다.

    virtual: 가상 메서드를 선언할 때 사용합니다.
    가상 메서드는 하위 클래스에서 재정의될 수 있습니다.
    기본적으로 가상 메서드는 해당 메서드가 선언된 클래스 또는 그 클래스의 인스턴스를 사용하여 호출됩니다.
    하지만 하위 클래스에서 해당 메서드를 재정의하면 하위 클래스의 인스턴스를 사용하여 호출됩니다.
    즉, 가상 메서드를 재정의할 때 해당 메서드를 호출하는 객체의 타입에 따라 호출되는 메서드가 달라질 수 있습니다.

    override: 재정의 메서드를 선언할 때 사용합니다.
    상위 클래스에서 선언된 가상 메서드를 하위 클래스에서 구현하거나 수정할 때 사용합니다.
    override 키워드는 반드시 가상 메서드 위에 작성되어야 합니다.

    abstract: 추상 클래스나 인터페이스에서 추상 메서드를 선언할 때 사용합니다.
    추상 메서드는 구현이 없는 메서드이며, 하위 클래스에서 반드시 구현해야 합니다.
    추상 클래스나 인터페이스는 자체적으로 객체를 생성할 수 없기 때문에, 이들을 구현한 하위 클래스에서 구현되는 메서드가 추상 메서드입니다.
    추상 메서드는 abstract 키워드를 사용하여 선언되며, 반드시 하위 클래스에서 구현되어야 합니다.
    */
}

/* 내가 자주 햇갈렸던것
 "."=> 내부에 정의 되어있다면, "()" => 외부에 정의 되어있다면, "=" => 외부 변수를 대입한다면. 

 true = 1
 false = 0

 "!=" => X값과 Y값이 다르다면 true.
 (X = true Y = false = true)

 "&&" (And) => X값과 Y값이 같을때 True.
 (X = true Y = true = true), (X = false Y = false = true), (X = false Y = true = false)

 "||" (or) =>  X값과 Y값이 하나라도 true라면 true.
 (X = ture Y = true = true), (X = ture Y = false = true), (X = false Y = false = false)

 //내가 찾고싶은 함수 변수를 클릭하고 밑의 설명을 참조 사용하자.
 Debug할때 Shift+F12를 눌러서 이 코드가 어디에 사용돼는지 확인 할 수 있다.
 F12는 함수에 사용한 변수의 원형이 어디에 정의돼어있는지 찾아주는 방법이다.
 Ctrl + Shift + F 를 사용하면 내가 찾고싶은 단어가 포함돼어있는 곳을 다 찾아준다.

// Image 를 안보이게 하고싶을때 .enabled 를 true,false를 사용한다.
SetActive는 GameObject에 사용하는것이다.

유니티의 Vector는 Vector3가 기본적이고 Vector는 X,Y,Z 방향에 대한 정보이다. 회전할때는 Vector3사용*/
