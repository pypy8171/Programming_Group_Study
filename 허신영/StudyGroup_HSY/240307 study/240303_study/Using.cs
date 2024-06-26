﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _240303_study
{
    internal class Using
    {
        public static void Main()
        {
            // 가장 자주 쓰이는 Try~Finally
            FileStream fs = new FileStream("A.txt", FileMode.CreateNew);
            try
            {
                // 예외 가능성이 있는 것들은 이쪽에다 쓰자.
            }
            finally
            {
                if (fs is null)
                {
                    fs.Dispose();
                }
            }

            // 위 코드를 자동생성할 수 있다.
            // using 키워드를 통해서.
            using (FileStream fs2 = new FileStream("A.txt", FileMode.CreateNew))
            {
                // using => try~finally
                // 자원 관리를 용이하게 하기 위해 사용함.
                // 아직 예외 처리를 한 것은 아니므로 내부에 try ~ catch로 예외 처리 가능하다.
            }
        }
    }
}
