using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*�� 3������ �⺻������ Unity Scripte file�� �����ϸ� �ڵ������� ���´�.*/
using Unity.VisualScripting.Antlr3.Runtime.Tree;

                            !!Warning!!
    ���� �ۼ��ž��ִ� �۰� Ŭ������ �ۼ��� ������ ������ ��Ҹ��� ��������
    ��Ȯ�ϰ� �˰�ʹٸ� �����,���ͳ�,å,GPT,������Ű ���� �����.
    
    *�ۼ����� ���Ǽ��� �տ� *�� ���ϴ�(Dog�帳����).*
    *�ۼ��ڴ� �� �ۿ� �����ִ� �ڵ尡 �� ����� �����ʾƵ� å�� �����ʽ��ϴ�.*
    *Ʋ������ ��Ȯ�� ���� �ȴٸ� �Ƽ� ȯ��*

public class learnCode : MonoBehaviour 
    /* MonoBehaviour�� Unity�� �⺻Ŭ������.
        MonoBehaviour�� ���� �Ͼ������ ǥ�� �´ٸ� Unity�� ������ �ž� ���� �������̴�.
        Unity�� ToolBar�� Edit-Preferences-External Script Editor ���� ������ ����ϴ� ��ũ��Ʈ ���� ���ϼ���
        ���� üũ �ڽ��� �˾Ƽ� üũ����.
    */
{
    public static GameManager gameManager = null; /*   
        ��� ����
        1. �̱� �� ������ GameManager Scpripte���� �����Ҷ� ����ϴ� ���� �������̴�.
        2. GameManager�� ������ �޾ƿ������ Scripte������ �Է��Ͽ� �޾ƿͼ� �ٸ� ��ũ��Ʈ����
        ��� �� �� �ְ� ������ش�.

        ��� ����
        1. public PlayerController playercontroller
        2. public GameObject player 
         
        ȣ�� ����
        1.GameManager.gameManager.
         */
    // �̱��� ������ ����Ҷ� ���� ���. Awake��

    Rigidbody2D rbody;

    GameObject[] gameObjects;
    /*�迭 ���
     Unity ���� �迭�� ����Ҷ��� C#�� ����ϰ� ����Ѵ�.
    �迭�� �ҷ��ö� gameObjects[i] �̷��� ����ϸ� �´�.
    i�� �ش� �迭�� ��ȣ Ȥ�� for���� �̿��� i �� ����Ѵ�.
     */

    /*Component���� ������ Start��
     Rigdbody2D�� ��� �� �� ��� 3D���� ��� �� �� 2D�� ���� �´�.
     */

    /*���� ���� ���� ����
        pubilc : � Class������ ���� ����.
        private : �ش� Ŭ���� �������� ���� ����.
        protected : �ش� Ŭ������ �� Ŭ������ ��ӹ��� ���� Ŭ�������� ���� ����.
    // ���� ����� ������
        internal : ���� ����� ���� Ŭ���� �Ǵ� �ش� Ŭ������ ��� ���� ����Ŭ�������� ���ٰ���.
        protected internal : ���� ����� ���� Ŭ���� �Ǵ� �ش� Ŭ������ ��ӹ��� ���� Ŭ�������� ���ٰ���.
    */

    /*Camera�̵� (Update�� Camera�� ã���ÿ�.)
        public float leftLimit = 0.0f;
        public float rightLimit = 0.0f;
        public float topLimit = 0.0f;
        public float bottomLimit = 0.0f;
    */

    //Unity Class�� LifeCycle (�����ֱ�, ������)
    void Awake() // GameObject�� ���� �� �� ���� 1ȸ �����ϴ� �Լ�. 
    {
        /*�̱��� ���Ͽ��� ����ϴ� �ڵ�*/
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
       
    } 

    void OnEnable() // GameObject�� Ȱ��ȭ �� ������ 1ȸ �����ϴ� �Լ�. 
    {

    } 

    void Start() //  Update�� ���۵ű� �� ���� 1ȸ �����ϴ� �Լ�. 
    {
        rbody = GetComponent<Rigidbody2D>();
        /* GetComponent<>(); ����
            C#�� ���׸� Ŭ������ ���� �����̴�, �ڼ��� �˰������ C#å �� ���׸�Ŭ���� �κ��� ����.
            GetComponent�� Unity�� Inspecterâ�� Component�� ������ �޾ƿ��� ���̱� ������
            Add Component�� �ִ� ������ �޾ƿü��մ°��̴� 
            ���÷� Animator�� �ҷ��´ٸ� ���� ���ó�� �ܺο� Animator ani;
            ani = GetComponent<Animator>();�� �ҷ��� Animator�� �Լ��� ��� �� ���ִ�.
            *���� Start�� �����ʾƵ� �Ŵ°����� �˰����� �ڼ��� �𸣰����� �ۼ��ڸ� ��������.*
        */
    } 

    void FixedUpdate() //Unity�� physics,Rigidbody�� �������꿡 ���É� ������ �Է� �� �� ����ϴ� �Լ� (CPU���� ���). 
    {

        rbody.Velrocity = new Vector2(X, Y); //Input Key�� ���� Ű ���� �ӵ��� �ش�. ������ ������ ���� X, Y���� �ָ�´�.
        /*Velrocity, Vector�� ���� ����
            Velrocity�� ������ ������ �����ϰ� �־��� �ӵ��� �̵��Ѵ�. (�ӵ�) *���� ���ؼ� �̴� ���̴�.*
            Vector3�� x,y,z ���� ��ġ, ����, �ӵ��� ����Ҷ� ����Ѵ�.
            Vector2�� 2D�� z���� ���⶧���� ���°��̰� �⺻������ Vector3�� ����Ѵ�.
        */

        rbody.AddForce(X, Y); // AddForce�� Velrocity�� ��������� �ٸ����� �̵�,����,����,������ ������ �޴´�.
        /*AddForce, ForceMode2�� ���� ����
            AddForce�� ���� ���� ���� ������ �ޱ⶧���� �̵��̶�� ���ٴ� �̲������� �����δ�. (���ӵ�) *���� ���ؼ� ������ ���̴�.*
            ForceMode2D.Force; // �������̰� ������ �������� �ʴ´�. (�������� ���������� ��Ÿ�� �� ���� ��)               
            ForceMode2D.Impulse; // �ҿ������̰� ������ �������� �ʴ´�. (ª�� ������ ��, �浹, ���� ��� �� ���δ�)
            FoeceMode.VelocityChange; // �ҿ������̰� ������ �����Ѵ�. (������ �ٸ� ������Ʈ�� ���� ���������� ���� �ӵ��� �����̰� ���ش�)

            rbody.AddRelativeForce(Vector3 force, ForceMode mode = ForceMode.Force)������� ForceMode �����Ҷ� ��� �������ذ�
            �� �ڵ��� ������ RigidBody�� ���ο� ��ǥ�谡 �Ǿ �ݿ��Ǵ°��̴�. ó���� RigidBody�� ������ �ٶ󺸰�������
            ��ġ�� �ٲ�� ȸ���Ǿ RigidBody�� �ٶ󺸰� �ִ� ������ ������ �Ǵ� ���̴�.

            //������� �ʾ����� �̷��� �ִ�.
            FoeceMode.Accel; // �������̰� ������ �����Ѵ�. (������Ʈ�� ������ ������� ������ �ְ�ʹٸ� ����Ѵ�)
         */


        //Joystick �̿��� �̵����(���� �̿ϼ��Դϴ�.)
        /*
        (�ܺο� Public VariableJoystick variableJoystick;)

        Vector3 direction = Vector3.forward * variableJoystick.Vertical + Vector3.right * variableJoystick.Horizontal;
        rb.AddForce(direction * speed * Time.fixedDeltaTime, ForceMOde.VelocityChange);

        �츮�� ������͵��� Ȱ���ؼ� ����ߴ�.
         */
        
        //Linecast�� Jump�ϱ�
        {
            //�ܺ� ��ܿ� (public LayerMask groundLayer; bool onGround = false; bool goJump = false) �����ߴٴ� ����
            onGround = Physics2D.Linecast(transfrom.position, transform.posision - (transform.up * 0.1f), groundLayer);
            /* *Linecast �ڵ� ����(100% ���Ǽ�)*
                ���� ���� �����Ѱ� �ƴ϶� Ʋ�� �� ����.
                Player�� SpriteRanderer�� point ���� -transform.up * 0.1f ��ŭ ������ ���� ����� 
                ������ ���� groundLayer�� ��������� true ���������� false
                groundLayer�� Unity���� GameObjcet�� Layer���� ���� �ؾ߉�.
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
             //FuncsionClass�� �ֱ� ���׷��� ���� �� 
             void Jump
             {
                goJump = true;
             }
            /*����� �̰� ����Ϸ��� Unity���� �� ���� ������ �ؾ��ϴµ� ����� Sprite�� pivot�� Bottom���� �����ϰ� ����ؾ� �Ѵ�.
            Linecast�� ������ Script�� ����� GameObject�� pivot�� ���������� ������ ���� ������ �����̴�, �׸��� �ִϸ��̼� ������ �����Ҵ�.
            ���� */
        }
    } 

    void Update() // Game�� Logic���� Code���� �Է� �� �� ����ϴ� �Լ�. 
    {
        if (Input.GetKey(KeyCode.D)) 
        {
            /*
            Input.GetKey()
            ����
            1.Key�� ������ ���� true�� ���������� ��ȯ�Ѵ�.
            2.���� ������ ��ư�� �����Ͽ� ���� �� �� �ִ�.
            
            �ڸ��ڵ�
            GetKeyDown() // Key�� ������ �ѹ� true�� ��ȯ �Ѵ�.
            GetKeyUp() // Key�� �� �� �ѹ� true�� ��ȯ �Ѵ�.

            ��� ����
            if (Input.GetKey(KeyCode.Escape))
            // Escape�� ESC Key�̰� Unity�� ����� �ž��ִ� Key�̴�, Escape�� �޴� InputKey���̹Ƿ� 
            RightArrow,D ��� ���� �Է¹ް� ���� ������ �����ϸ� �Ŵ� ���̴�.
            ((KeyCode.RightArrow), (KeyCode.D))
            */
        }// ���� Ű������ �Է¹ޱ�

        axisH = Input.GetAxisRaw("Horizontal"); {
            /*
            Input.GetAxisRaw() 
            ����
	        1. Unity ���� Input Manager�� ���ǵ� Ű ���� �ҷ��ͼ� ��� �� �� �ִ�.
	        2. -1, 0, 1 �� ���� �� �� �ϳ��� ��ȯ�ȴ�.
	        3. string ���� ����Ѵ�.
	        4. GetAxis�� �������� Axis�� -1.0f���� 1.0f������ �����ް� GetAxisRaw�� -1, 0, 1�� ���� �޴´�
	        GetAxis�� �Ǽ��� ����ϱ⶧���� -0.5fó�� ������ ���� ����� ���ְ� GetAxisRaw�� �׷��� ����
	        -1, 0, 1 ���� ��ȯ�´� 
	        ��� "GetAixs�� float ���̰� GetAxisRaw�� int���̴�."

            �ڸ��ڵ�
	        GetAxis // -1.0f ���� 1.0f������ ���� ���� ��ȯ �Ѵ�.

            ��뿹��
	        ���� �� = Input.GetAxisRaw("Horizontal")
	        // "Horizontal" , "Vertical" �� �ִ� Unity Input Manager�� ���ǵ� Key ��
		    ���� A , LeftArrow ������ D , RightArrow �� W , UpArrow �Ʒ� S , DownArrow 
            */
        }// Unity�� ���ǉ� Ű������ �Է¹ޱ�

        //Angle �� ���ϱ�
        {
            //�ܺ� ��ܿ� (public float angleZ = 90.0f;) �����ߴٴ� ����
            Vector2 fromPt = this.transform.position;
            Vector2 toPt = new Vector2(fromPt.x + axisH, fromPt.y + axisV);
            Debug.Log("X : " + toPt.x + "Y : " + toPt.y); // Unity ������ ���� �߻��� �˷��ִ��ڵ�

            angleZ = GetAngle(fromPt, toPt); /* GetAngle�� �ܺο��� �Լ��� �����Ͽ� �ҷ��°��̴�. 
                                                GetAngle�� FuncsionClass �� ���� �� ���Ҵ�  */           
            if (angleZ >= -45 && angleZ < 45)
            {
                //Right Angle ��
            }
            else if (angleZ >= 45 && angleZ <= 135)
            {
                //Up Angle ��
            }
            else if (angleZ >= -135 && angleZ <= -45)
            {
                //Down Angle ��
            }
            else // 3���� ���߱⶧���� ������ ���� �ڵ����� else ������ �´�.
            {
                //Left Angle ��
            }
        } // Unity�� ������ 360���� �ƴϰ� 180�� -180���̴�, ���� ��Ȯ�ϰ� ����... �̴�� �ܿ�...

        //Camera 
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            //Hierarchy�� GameObject�� Tag "Player"�� ã�´�.
            if (player == null)
            {
                Debug.LogError("Player ���� ������Ʈ�� ã�� �� ����.");
                return
            }
            /*Debug.LogError ��� ����
                Debug.LogError�� ��� ǥ���̴�. Hierarchy�� "Player" Tag�� ���� GameObject�� ���ٸ�
                Consoleâ�� �˷��ִ� ��Ȱ�̴�. Debug�������� �߸��� ������ �˷��ֱ� ���� ����Ѵ�. 
                �ڵ� ��Ȱ �ϸ鼭 ������ ���̸� ���߿� ������ ��������.
             */
            float x = player.transform.position.x;
            float y = player.transform.position.y;
            float z = this.trasnform.position.z;
            //player�� x,y���� �޾ƿͼ� ������ position������ ��ȯ�ϴ��۾�

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

    void LateUpdate() // ��� Update������ ������ ��� ������ ���� �� ���������� ����Ŵ� �Լ�. 
    {
        
    }

    void OnDisable() // GameObject�� ��Ȱ��ȭ �� ������ 1ȸ �����ϴ� �Լ�. 
    {

    }

    void OnDestroy() // GameObject�� �����ƶ� �����ϴ� �Լ�. 
    {

    }

    //(Box)Collider ���� Trigger������ �ϰ� �ٸ� Collider�� �浹������ ����.
    void OnTriggerEnter2D(collider2D collision) 
    {
        transform.SetParent(collision.transform);
        // Collider2D�� ������ ���� Object�� ChildObjcet�� �´�*(������� Ű���� �װ� �����ǰ�?)*
    }

    //�ٸ� Collider���� �������� ����.
    void OnTriggerExit2D(collider2D collision)
    {

    }

    //�ܺο� ���� ���� ���� �Լ�Ŭ������
    void FuncsionClass()
    {
        float GetAngle(Vector2 p1, Vector p2) //float ���� ��ȯ���ִ� �Լ���.
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
            //Atan2�� Y,X ������ ����.
        }

        // GameObjcet �� gameObjcet�� FindTag ������� ����.
        /*
            GameObjcet player = GameObjcet.FindGameObjcetWithTag("Player")
            GameObjcet�� Hierarchy�� GameObjcet�̴�. 

            gameObjcet.tag == "Player"
            gameObjcet�� GameObjcet�� ���������� ����� ���̴�.
            �̰� �׳� GameObjcet player ��� �س����� player.tag�� �Ŵ°��̴�.
            �̸� ��������.
         */

        // ������ Ÿ�� ���Ѿ��� �ڷᱸ�� ���� ���������� �˰������� ����
        {
            ArrayList;// �迭ó�� ����� �����ϴ�.
            /* ��뿹��
             * arrayList.Add(1); 
             ��ȣ �ȿ� ���� ���ϴ� ��*/
            Queue;// ���Լ��� FIFO (First In First Out)
            /* ��뿹��
               que.Enqueue(10)
            ��ȣ �ȿ� ���� ���ϴ� ��, Enqueue, Dequeue�� ������ .*/
            Stack;// ���Լ��� LIFO (Last In First Out)
            Hashtable;// Key�� Value�� ���� �����͸� �����ϴ� �ڷ� �����̴�.

            //������ Ÿ�� ������ �ִ� �����ڷ�.
            Dictionary;//Hashtable�� ��� ����� ����, Playerpref���� ����ϰ� ����߾���.
        }
       
        int GetRandom(int x), int y)
        {
            //Random�� �����
            /*
                ���⼭ x = 0, y = 10�̶�� �����ϰڴ�.
                Unity���� Random�� �ڿ� method�� �پ�� �Ѵ�.
                Random.Range(int x, int y) : Range�� �� ���� ���� ������ ��ȯ�Ѵ� 0�̻� 10����.
                Random.value(float x, floal y) : value�� �� ���� ���� �Ǽ��� ������ ��ȯ�Ѵ� 0f�̻� 10f�̸�.
             */
        }

    }

    void chatGPT()// GPT�� �����̳� �𸣴°� ���.
    {
        /*GPT�� Assembly ����.
        Unity���� ������� ������ �����ϴ� �ڵ��� ���� �� �ϳ��Դϴ�.
        ���� ������Ʈ�� ������ ��ũ��Ʈ�� Unity ������ ���� �����ϵǾ� ������� ��ȯ�˴ϴ�.
        �̶�, �����ϵ� ������� DLL ���� ���·� ����˴ϴ�.

        ������� C#�� ���� ���α׷��� �� �̿��Ͽ� �Լ��� �����ϰ�,
        �̸� �������Ͽ� �����˴ϴ�. �̶�, ������� ���� ���� Ŭ������ ������ �� ������,
        �� Ŭ������ �پ��� ���(����, �Լ� ��)�� ���� �� �ֽ��ϴ�.
        Unity������ �̹� ���ǵ� API�� �̿��Ͽ� ������ �����ϱ� ������,
        ���� ����ڰ� ���� ������� �ۼ��ϴ� ���� �年�ϴ�. ���,
        Unity API�� Ȱ���Ͽ� ������ �����մϴ�.

        Unity�� ������� ����Ƽ �������� ���Ǵ� �پ��� ��ɵ��� ������ �ڵ��� ����ü�Դϴ�.
        �̷��� ������� .NET Framework�� �Ϻκ��� Common Language Runtime (CLR)���� ����˴ϴ�.
        Unity�� ������� ����Ƽ ������ �ھ� ��ɻӸ� �ƴ϶� �پ��� ���� ���̺귯��, ������ Ȯ�� ����� ���˴ϴ�.
        ����, ����Ƽ���� ��ũ��Ʈ�� �ۼ��ϰų� �÷������� ������ ���� Unity�� ������� ������ �ʿ䰡 �ֽ��ϴ�.
        Unity�� ������� ����Ƽ ������ ��ġ�� ������ "Editor" �� "Data" ���� �ȿ� ��ġ�� �ֽ��ϴ�.
        ����, Unity ��ũ��Ʈ���� ����Ƽ�� ������� ����ϱ� ���ؼ��� �ش� ������� �����ؾ� �մϴ�.
        �̸� ���ؼ��� using ���þ ����Ͽ� Unity�� ���ӽ����̽��� �����ϰų�, ������ ������� ��������� ������ �� �ֽ��ϴ�.
        */

        /* GPT�� Cos Sin Atan2����
        Cos, Sin, Atan2�� ���� �Լ��� ���� �ﰢ�Լ�
        �ڻ���(Cosine), ����(Sine), ��ũź��Ʈ(Atangent)�� �����̴�.

        Cos �Լ��� �־��� ������ �ڻ��� ���� ����� ��ȯ�Ѵ�.
        �ڻ��� ���� �ﰢ���� ���� ���̸� �밢������ �ϴ� �����ﰢ������,
        �������� ���̸� ������ ���̷� ���� ���̴�.
        ���������δ� cos(x) = adjacent / hypotenuse �̴�.

        Sin �Լ��� �־��� ������ ���� ���� ����� ��ȯ�Ѵ�.
        ���� ���� �ﰢ������, ���̸� �������� �ϴ� �����ﰢ������,
        �밢���� �������� �̷�� ������ �ݴ��� ���� ���̸� ���̷� ���� ���̴�.
        ���������δ� sin(x) = opposite / hypotenuse �̴�.

        Atan2 �Լ��� �־��� x, y ��ǥ ���� ��ũź��Ʈ ���� ����� ��ȯ�Ѵ�.
        ��ũź��Ʈ ���� �����ﰢ������ �������� ���̸� �� ��,
        �������� ���̸� �̷�� ������ ũ�⸦ ��ȯ�Ѵ�. atan2(y, x)�� y / x�� ��ũź��Ʈ ���� ��ȯ�ϸ�,
        x�� 0�̸� ������� ���� / 2�� �ȴ�.

        Unity���� �� �Լ����� ���Ϳ� ���õ� �۾����� ���� Ȱ��ȴ�.
        ���� ���, Cos�� Sin �Լ��� �ַ� �Ѿ��̳� �÷��̾ ȸ����Ű�µ� ���ȴ�.
        Atan2 �Լ��� ���Ͱ� ����Ű�� ������ �����ϰų� �� ���� ���� ������ ����ϴµ� ���ȴ�.
         */

        /* GPT�� Rad2Deg ����
        Rad2Deg�� ���� ���� ���� ������ ��ȯ���ִ� ����Դϴ�.
        ����(radian)�� ������ ������, 360���� 2��� ���� �����μ�,
        ������ ���̿� �������� ���̰� ���� ���� ȣ�� �߽ɰ��� 1 �����Դϴ�.

        Unity���� ������ ����� �� ��, ���� ������ ǥ�õ� ���� ���� ������ ǥ�õ� �� ��� ���˴ϴ�.
        Rad2Deg ����� ���� ���� ���� ������ ��ȯ�� �� ���˴ϴ�.
        ���� ���, Mathf.Sin() �Լ��� ���� ���� �Է����� �ޱ� ������,
        ���� ���� ���� ������ ��ȯ�� �� Rad2Deg ����� ����մϴ�.
        */
    }

    // ���� ���� �ް��ȴ���
    /*
     * "."=> ���ο� ���� �Ǿ��ִٸ�, "()" => �ܺο� ���� �Ǿ��ִٸ�, "=" => �ܺ� ������ �����Ѵٸ�. 
     *
     *true = 1
     *false = 0
     * 
     *"!=" => X���� Y���� �ٸ��ٸ� true.
     *(X = true Y = false = true)
     *
     *"&&" (And) => X���� Y���� ������ True.
     *(X = true Y = true = true), (X = false Y = false = true), (X = false Y = true = false)
     *
     *"||" (or) =>  X���� Y���� �ϳ��� true��� true.
     *(X = ture Y = true = true), (X = ture Y = false = true), (X = false Y = false = false)

     //���� ã����� �Լ� ������ Ŭ���ϰ� ���� ������ ���� �������.
     Debug�Ҷ� Shift+F12�� ������ �� �ڵ尡 ��� ���Ŵ��� Ȯ�� �� �� �ִ�.
     F12�� �Լ��� ����� ������ ������ ��� ���ǵž��ִ��� ã���ִ� ����̴�.
     Ctrl + Shift + F �� ����ϸ� ���� ã����� �ܾ ���Եž��ִ� ���� �� ã���ش�.

    // Image �� �Ⱥ��̰� �ϰ������ .enabled �� true,false�� ����Ѵ�.
    SetActive�� GameObject�� ����ϴ°��̴�.

    ����Ƽ�� Vector�� Vector3�� �⺻���̰� Vector�� X,Y,Z ���⿡ ���� �����̴�. ȸ���Ҷ��� Vector3���
     */
}

//enum�� ������������ ���´�
public enum Type
{
    1,
    2,
    3
}