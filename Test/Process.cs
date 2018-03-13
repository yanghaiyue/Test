using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Test
{
    public class Process
    {
        delegate int TestTemp(int a, int b);

        public Process()
        {
            TestTemp testTemp = new TestTemp(Sum);
            Test(testTemp, 1, 2);
        }

        public int Sum(int a, int b)
        {
            int c = a + b;
            return c;
        }

        public void Test(Delegate method, params object[] args)
        {
            object result = method.DynamicInvoke(args);
        }
    }
}
