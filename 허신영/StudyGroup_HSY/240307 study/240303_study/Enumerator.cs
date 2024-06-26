﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _240303_study
{
    internal class Enumerator
    {
        public static void Main()
        {
            int[] arr = { 1, 2, 3, 4, 5 };

            // 1. List
            // 연속된 메모리 공간을 가진다. 
            // 인덱서를 지원한다. => IList<T> 인터페이스를 구현한다.
            List<int> list = new List<int>(arr);
            
            list.ForEach(ele=>Console.WriteLine(ele));
            
            // 성능 상의 이점은 아래 형태가 좋다.
            foreach (var item in list)
            {
                
            }

            // 2. LinkedList
            // C++ STL의 list
            // 인덱서를 지원하지 않는다.
            // 메모리가 연속되지 않는다.
            LinkedList<int> l = new LinkedList<int>();

            // 3.반복자(iterator) 패턴
            // - 복합 객체의 내부 구조에 상관 없이 동일한 방식의 요소를 열거하는 디자인 패턴.
            // - C# 에서는 반복자(iterator) 대신 열거자(Enumerator) 라는 용어를 사용한다.
            // - C# 에서는 모든 컬렉션은 IEnumberable<T> 인터페이스를 구현한다.

            // 4. 열거자
            // - IEnumerable<T> 인터페이스를 구현 -> GetEnumerator() : 열거자를 꺼낸다.
            // 즉, 열거자는 컬렉션의 요소를 가리키는 객체를 의미한다.
            List<int> c3 = new List<int>(arr);
            LinkedList<int> c4 = new LinkedList<int>(arr);

            IEnumerator<int> e1 = c3.GetEnumerator();
            IEnumerator<int> e2 = c4.GetEnumerator();   // 4-1. 이 상태에서는 초기화가 되어 있지 않다. (핵심)
            Console.WriteLine(e1.Current);
            Console.WriteLine(e2.Current); // default 값으로 세팅.

            e1.MoveNext();  // 4-2. 최초 호출 시 초기화. (매우 중요)
            Console.WriteLine(e1.Current);

            e1.MoveNext();
            Console.WriteLine(e1.Current);

            while (e1.MoveNext()) // 4.3 MoveNext() : 다음 요소를 찾지 못하면 false.
            {
                Console.WriteLine(e1.Current);
            }

            e1.Reset(); // 4-4. 다시 초기 상태로 변경한다.

            // 5. 열거자와 foreach 원리.
            // (1) 모든 열거자는 foreach를 사용해서 열거할 수 있다.
            // - foreach 자체가 열거자를 사용해서 구현한 것이다.

            // (2) 실제 동작.
            // foreach (int i in c3) == for (IEnumerator<int> p = c3.GetEnumerator(); p.MoveNext())
            foreach (int n in c3)
                Console.WriteLine(n);
        }
    }
}
