namespace _08_HashTable
{
    // #######################################
    // 2023-04-26
    // 김용준
    // HashTable
    // #######################################

    // 2. 해싱과 해시함수에 대한 조사(해시의 원리, 해싱함수의 효율, 등)
    // 해시의 원리 : 임의의 길이를 갖는 임의의 데이터를 고정된 길이의 데이터로 매핑하는 단방향 함수
    //              큰 숫자를 넣더라도 정해진 크기의 숫자가 나오는 함수
    // 
    // 해싱 : HashTable이라는 기억공간을 할당하고 해시함수를 이용하여
    //       레코드 키에 대한 HashTable 내의 HomeAddress를 계산한 후
    //       주어진 레코드를 해단 기억장소에 저장하거나 검색작업을 수행하는 방식
    //       해싱은 직접접근(DAM) 파일을 구성할 때 사용되며 접근속도는 빠르나 기억공간이 많이 요구됨
    //       검색속도가 빠르며 삽입,삭제 작업의 빈도가 많을 때 유리한 방식이다
    //       키-주소 변환 방법이라고도 한다.
    // 
    // 해싱함수의 종류로는 
    // 제산법, 제곱법, 폴딩법, 기수변환법, 대수적 코딩법, 계수 분석법, 무작위법이 있고
    // 해싱함수의 효율은 함수의 처리속도가 빠를수록, 결과의 밀집도가 낮을수록 빠르다
    // 해시테이블의 크기가 클수록 빠르지만 이 경우엔 메모리에 부담이 된다.


    // 3. 해시테이블의 충돌과 충돌해결방안
    // 
    // 
    // c#에서 체이닝은 노드기반이라 사용하지 않고 개방주소법을 사용
    // 

    internal class Program
    {
        static void Main(string[] args)
        {
            DataStructure.Dictionary<string, string> dic = new DataStructure.Dictionary<string, string>();
            // var dic = new DataStructure.Dictionary<string, string>();

            dic.Add("겜창부", "아리스");
            dic.Add("세미나", "유우카");
            dic.Add("엔지니어부", "히비키");

            Console.WriteLine(dic["세미나"]);

            dic.Remove("겜창부");
            Console.WriteLine(dic["겜창부"]);

            Console.ReadKey();
        }
    }
}