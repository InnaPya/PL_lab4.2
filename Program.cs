using System;
using System.Threading;

namespace cs_PL_4
{
    class Program
    {
        public class Token
        {
            public string data;
            public int recipient;
            public Token (string d, int r)
            {
                data = d;
                recipient = r;
            }
        }
        public class Param
        {
            public Token t;
            public int i;
            public Param (Token tkn, int cur)
            {
                t = tkn;
                i = cur;
            }
        }
        static void Main(string[] args)
        {
            int N = 10;
            Token t = new Token("message", N);
            Param p = new Param(t, 1);
            Thread thr = new Thread(new ParameterizedThreadStart(grtn));
            thr.Start(p);
        }
        static void grtn(object p)
        {
            Param prm = (Param)p;
            if (prm.i != prm.t.recipient)
            {
                Thread thr = new Thread(new ParameterizedThreadStart(grtn));
                prm.i++;
                thr.Start(prm);
            }
            else
            {
                Console.WriteLine(prm.i + " " + prm.t.data);
                Console.Read();
            }
        }
    }
}
