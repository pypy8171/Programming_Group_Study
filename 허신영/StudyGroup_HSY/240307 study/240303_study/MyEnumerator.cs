﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _240303_study
{
    // COROUTINE
    // C# 언어는 코루틴을 완벽하게 지원하지 않는다. (일부만 지원)
    // 콜렉션의 열거자를 만들 때 지원.
    // Linq 등이 코루틴 개념을 사용해서 작성 됨.
    
    // C# 컬렉션은 열거자를 반환할 수 있어야 한다.
    // 이걸 코루틴으로 변환해보자.

    internal class MyEnumerator
    {
        class Node
        {
            public int data;
            public Node next;

            public Node(int data, Node next) 
            {
                this.data = data;
                this.next = next;
            }
        }

        class IntLinkedListEnumerator : IEnumerator
        {
            public Node head = null;
            public Node curr = null;
            public IntLinkedListEnumerator(Node e)
            {
                head = e;
            }

            public object Current => curr.data;

            public bool MoveNext()
            {
                // 최초 호출
                if (curr is null)
                {
                    curr = head;
                }
                else
                {
                    curr = curr.next;
                }

                return curr != null;
            }

            public void Reset()
            {
                curr = null;
            }
        }

        class IntLinkedList : IEnumerable
        {
            public Node head = null;

            public void AddFirst(int data)
            {
                head = new Node(data, head);
            }

            public IEnumerator GetEnumerator()
            {
                return new IntLinkedListEnumerator(head);
            }
        }

        public static void Main()
        {
            IntLinkedList st1 = new IntLinkedList();
            st1.AddFirst(10);
            st1.AddFirst(20);
            st1.AddFirst(30);
            st1.AddFirst(40);
            st1.AddFirst(50);

            // 1. 열거자
            IEnumerator e1 = st1.GetEnumerator();
            while (e1.MoveNext())
            {
                Console.WriteLine(e1.Current);
            }
        }
    }
}
