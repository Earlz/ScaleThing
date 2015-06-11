using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScaleTabs
{
    class Program
    {
        enum Note
        {
            A = 0,
            Asharp=1,
            B=2,
            C=3,
            Csharp=4,
            D=5,
            Dsharp=6,
            E=7,
            F=8,
            Fsharp=9,
            G=10,
            Gsharp=11
        }
        //I'm sure if this wasn't a one off, there'd be a better way to do this.. 
        int MajorScale(Note root,Note n)
        {
            var ni = (int)n;
            var rooti = (int)root;
            var list = new List<Note>();

            list.Add(root);
            var tmp = Wholestep(root);
            list.Add(tmp);
            tmp = Wholestep(tmp);
            list.Add(tmp);
            tmp = Halfstep(tmp);
            list.Add(tmp);
            tmp = Wholestep(tmp);
            list.Add(tmp);
            tmp = Wholestep(tmp);
            list.Add(tmp);
            tmp = Wholestep(tmp);
            list.Add(tmp);
            //tmp = Halfstep(tmp);
            //list.Add(tmp);
            if(list.Contains(n))
            {
                return list.IndexOf(n);
            }
            return -1;
        }

        int MinorScale(Note root, Note n)
        {
            var ni = (int)n;
            var rooti = (int)root;
            var list = new List<Note>();

            list.Add(root);
            var tmp = Wholestep(root);
            list.Add(tmp);
            tmp = Halfstep(tmp);
            list.Add(tmp);
            tmp = Wholestep(tmp);
            list.Add(tmp);
            tmp = Wholestep(tmp);
            list.Add(tmp);
            tmp = Halfstep(tmp);
            list.Add(tmp);
            tmp = Wholestep(tmp);
            list.Add(tmp);
            //tmp = Wholestep(tmp); //octave
            //list.Add(tmp);
            if (list.Contains(n))
            {
                return list.IndexOf(n);
            }
            return -1;
        }

        Note Halfstep(Note n)
        {
            var ni = (int)n;
            ni++;
            return (Note)(ni % 12);
        }
        Note Wholestep(Note n)
        {
            var ni = (int)n;
            ni+=2;
            return (Note)(ni % 12);
        }


        void Main(string[] args)
        {
            int fretmax = 22;

        }
    }
}
